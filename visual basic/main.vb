Imports System.Text.RegularExpressions
Imports Microsoft.Office.Interop

Public Class main

    'basic outlook objects
    Public olApp As Outlook.Application
    Public olNs As Outlook.NameSpace
    Public olExplorer As Outlook.Explorer

    'folder where shipping docs are held
    Public shipDocFolder As Outlook.MAPIFolder

    'objects used to store items while looping
    Dim sentItem As Object
    Dim shippedJob As Object
    Dim selectedJob As Item
    Dim calendarItem As Object

    'list of jobs that arent shipped
    Dim unshippedJobs As New SortedSet(Of Item)

    'Regular expression to find SV numbers. Pattern = SV followed by 10 digits
    Dim jobNumberRegex As Regex = New Regex("SV\d{10}", RegexOptions.IgnoreCase)
    Dim restrictiveJobNumberRegex As Regex = New Regex("SV\d{6}\d+0\d{3}", RegexOptions.IgnoreCase)

    'finds unshipped jobs
    Private Sub jobButton_Click(sender As Object, e As EventArgs) Handles jobButton.Click

        'checks if any items on blacklist
        Dim activeBlackList = My.Settings.BlackList.Count > 0

        'calculates the date to search back to for job updates
        Dim modifiedDate = DateTime.Now.AddDays(-7 * My.Settings.WeeksToCheck)

        'clears all things that might need clearing
        clearControls()
        unshippedJobsListBox.Items.Clear()

        setStatus("Searching for jobs.")

        'seaches for jobs that have in and out parts aswell as onsite time
        Dim partsItemsSearch As Outlook.Items = olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail).Items
        partsItemsSearch = partsItemsSearch.Restrict("[SentOn] >= '" + modifiedDate.ToShortDateString + "'")
        partsItemsSearch = partsItemsSearch.Restrict("@SQL=" + quote("urn:schemas:httpmail:subject") + " LIKE '%SV%' AND " _
            + quote("urn:schemas:httpmail:textdescription") + " LIKE '%" + My.Settings.InstalledSerialKeyword + "%' AND " _
            + quote("urn:schemas:httpmail:textdescription") + " LIKE '%" + My.Settings.FaultySerialKeyword + "%' AND " _
            + quote("urn:schemas:httpmail:textdescription") + " LIKE '%" + My.Settings.OnsiteTimeKeyword + "%'")

        partsItemsSearch.Sort("[SentOn]")

        'searches for updates that are within timeframe and contain the shipping keyword in the subject or body
        Dim shippedItemsSearch As Outlook.Items = olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail).Items
        shippedItemsSearch = shippedItemsSearch.Restrict("[SentOn] >= '" + modifiedDate.ToShortDateString + "'")

        shippedItemsSearch = shippedItemsSearch.Restrict("@SQL=" + quote("urn:schemas:httpmail:subject") + " LIKE '%SV%' AND (" _
            + quote("urn:schemas:httpmail:subject") + " LIKE '%" + My.Settings.ShippingKeyword + "%' OR " _
            + quote("urn:schemas:httpmail:textdescription") + " LIKE '%" + My.Settings.ShippingKeyword + "%')")

        Dim checkNewPart = ContainsNonAlphaChars(My.Settings.InstalledSerialKeyword)
        Dim checkFaultyPart = ContainsNonAlphaChars(My.Settings.FaultySerialKeyword)
        Dim checkOnsite = ContainsNonAlphaChars(My.Settings.OnsiteTimeKeyword)
        Dim checkShipping = ContainsNonAlphaChars(My.Settings.ShippingKeyword)

        ' Loops through results of search for sent mail with SV in subject
        For Each partItem As Outlook.MailItem In partsItemsSearch
            Dim jobNumberMatch As Match = findJobNumber(partItem.Subject)
            If jobNumberMatch.Success Then
                If Not checkNewPart Or (checkNewPart AndAlso partItem.Body.ToString.ContainsIgnoreCase(My.Settings.InstalledSerialKeyword)) Then
                    If Not checkFaultyPart Or (checkFaultyPart AndAlso partItem.Body.ToString.ContainsIgnoreCase(My.Settings.FaultySerialKeyword)) Then
                        If Not checkOnsite Or (checkOnsite AndAlso partItem.Body.ToString.ContainsIgnoreCase(My.Settings.OnsiteTimeKeyword)) Then
                            Dim job As Item = New Item(partItem, jobNumberMatch.Value)
                            If Not activeBlackList Or (activeBlackList AndAlso Not My.Settings.BlackList.Contains(job.jobNumber)) Then
                                ' Adds mail item to a list of unshipped jobs.
                                unshippedJobs.Add(job)
                            End If
                        End If
                    End If
                End If
            End If
        Next

        setStatus("Removing shipped jobs.")

        For Each shippedItem As Outlook.MailItem In shippedItemsSearch
            Dim jobNumberMatch As Match = findJobNumber(shippedItem.Subject)
            If jobNumberMatch.Success Then
                If Not checkShipping Or (checkShipping AndAlso (shippedItem.Subject.ContainsIgnoreCase(My.Settings.ShippingKeyword) Or shippedItem.Body.ToString.ContainsIgnoreCase(My.Settings.ShippingKeyword))) Then
                    unshippedJobs.Remove(New Item(shippedItem, jobNumberMatch.Value))
                End If
            End If
        Next

        setStatus("Parsing found jobs.")

        Dim calendarSearch As Outlook.Items = olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).Items.Restrict("[Start] >= '" + modifiedDate.ToShortDateString + "'")
        calendarSearch = calendarSearch.Restrict("@SQL=" + quote("urn:schemas:httpmail:subject") + " LIKE '%SV%'")
        calendarSearch.Sort("[Start]")

        'Loops through all unshipped jobs, determining the customer of the job and sets variables based on customer
        For Each unshippedJob As Item In unshippedJobs
            Dim jobCalendarSearch = calendarSearch.Restrict("@SQL=" + quote("urn:schemas:httpmail:subject") + " LIKE '%" + unshippedJob.jobNumber + "%'")
            For Each calendarItem As Outlook.AppointmentItem In jobCalendarSearch
                Dim itemString = calendarItem.Body.ToLower
                If itemString.ContainsIgnoreCase("1639") Then
                    'Determines if job is for foodstuffs
                    If itemString.Contains("site :: ") Then
                        unshippedJob.site = parseLine(calendarItem.Body, "site ::")
                        unshippedJob.jobType = jobTypes.Foodstuffs
                        unshippedJob.appointment = calendarItem
                        Exit For
                    ElseIf itemString.Contains("site name:") Then
                        unshippedJob.site = parseLine(calendarItem.Body, "site name:")
                        unshippedJob.jobType = jobTypes.Foodstuffs
                        unshippedJob.appointment = calendarItem
                        Exit For
                    ElseIf itemString.Contains("location:") Then
                        unshippedJob.site = parseLine(calendarItem.Body, "location:")
                        unshippedJob.jobType = jobTypes.Foodstuffs
                        unshippedJob.appointment = calendarItem
                        Exit For
                    End If
                ElseIf itemString.Contains("nzlotteries") Then
                    'Determines if job is for Lotto
                    unshippedJob.site = parseLine(calendarItem.Body, "retailer name:")
                    unshippedJob.jobType = jobTypes.Lotto
                    unshippedJob.appointment = calendarItem
                    Exit For
                ElseIf itemString.Contains("4611nzptwncorp") Then
                    'Determines if job is for post
                    unshippedJob.site = parseLine(calendarItem.Body, "customer contact at site:")
                    unshippedJob.jobType = jobTypes.NZPost
                    unshippedJob.appointment = calendarItem
                    Exit For
                Else
                    unshippedJob.site = ""
                    unshippedJob.jobType = jobTypes.Other
                    unshippedJob.appointment = calendarItem
                End If
            Next

            unshippedJobsListBox.Items.Add(unshippedJob)
            unshippedJobsListBox.Refresh()
        Next

        setStatus("Job search complete.")
    End Sub

    'When user selects a job from the list, populate the text boxes with relevant information so they can edit or choose what to be added to form.
    Private Sub unshippedJobsListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles unshippedJobsListBox.SelectedIndexChanged
        clearControls()
        If unshippedJobsListBox.SelectedIndex > -1 Then
            For Each selectedJob In unshippedJobs
                'if selected items job number matches a job number from list of unshipped jobs
                If selectedJob.jobNumber.ContainsIgnoreCase(unshippedJobsListBox.SelectedItem.jobNumber) Then
                    'sets textboxes to already stored values
                    jobNumberTextBox.Text = selectedJob.jobNumber
                    siteTextBox.Text = selectedJob.site
                    jobTypeComboBox.Text = selectedJob.jobType.ToString
                    faultTextBox.Clear()

                    Dim index = 0
                    Dim contents() As String = selectedJob.item.Body.Split(vbCrLf.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

                    For Each line As String In contents
                        If line.StartsWith(My.Settings.InstalledSerialKeyword) Then installedSerialTextBox.Text = parseLine(line, My.Settings.InstalledSerialKeyword)
                        If line.StartsWith(My.Settings.InstalledAssetKeyword) Then installedAssetTextBox.Text = parseLine(line, My.Settings.InstalledAssetKeyword)
                        If line.StartsWith(My.Settings.FaultySerialKeyword) Then faultySerialTextBox.Text = parseLine(line, My.Settings.FaultySerialKeyword)
                        If line.StartsWith(My.Settings.FaultyAssetKeyword) Then faultyAssetTextBox.Text = parseLine(line, My.Settings.FaultyAssetKeyword)
                        If line.StartsWith(My.Settings.FaultDescriptionKeyword) Then faultTextBox.Text = parseLine(line, My.Settings.FaultDescriptionKeyword)
                    Next
                    Exit For
                End If
            Next
        End If
    End Sub

    ' Searches for email with subject that contains the chosen job to ship. Searches all matching emails for one with attachments.
    Private Sub shipDocButton_Click(sender As Object, e As EventArgs) Handles getDocButton.Click
        If IsNothing(selectedJob) Then
            MsgBox("No job selected.")
        Else
            selectedJob.shipDocFound = False
            setStatus("Searching for shipping document.")
            Dim shipDocSearch = shipDocFolder.Items
            shipDocSearch = shipDocSearch.Restrict("@SQL=" + quote("urn:schemas:httpmail:subject") + " LIKE '%" + selectedJob.jobNumber + "%'")
            shipDocSearch = shipDocSearch.Restrict("[Attachment] > 0")

            'If the results of the search turn up nothing, throw error
            If shipDocSearch.Count = 0 Then
                MsgBox("No shipping document email found for selected job in folder: " + shipDocFolder.Name + ".")
            Else
                setStatus("Parsing found shipping documents.")
                Dim shipDocItem As Outlook.MailItem
                'Loop through all results
                For i = 1 To shipDocSearch.Count
                    shipDocItem = shipDocSearch.Item(i)
                    'Checks if email has any attachments, and either the subject or body of email contain ship doc in some form
                    If shipDocItem.Attachments.Count > 0 AndAlso (LCase(shipDocItem.Subject) Like "*ship*doc*" Or LCase(shipDocItem.Body) Like "*ship*doc*" Or LCase(shipDocItem.Subject) Like "*ship*list*" Or LCase(shipDocItem.Body) Like "*ship*list*") Then
                        'Loops through all attachments, in most cases this will be only one file
                        For a = 1 To shipDocItem.Attachments.Count
                            'Checks if the name of attachment indicates that it is a shipping document
                            If UCase(shipDocItem.Attachments(a).DisplayName) Like "_D*.PDF" Then
                                'Saves attachment and sets flag on item that it has an appropriate shipping document downloaded for it
                                shipDocItem.Attachments(a).SaveAsFile(IO.Path.Combine(IO.Directory.GetParent(Application.ExecutablePath).FullName, "shipDoc.pdf"))
                                selectedJob.shipDocFound = True
                                setStatus("Finished retrieving shipping document.")
                                Exit For
                            End If
                        Next
                        Exit For
                    End If
                Next
                If Not selectedJob.shipDocFound Then
                    MsgBox("None of the emails found for job contain attachments.")
                End If
            End If
        End If
    End Sub


    Private Sub produceButton_Click(sender As Object, e As EventArgs) Handles produceButton.Click
        If IsNothing(selectedJob) Then
            MsgBox("No job selected.")

            'Checks if selected job has had a shipping document downloaded for it
        ElseIf Not selectedJob.shipDocFound Then

            MsgBox("No shipping document has been downloaded for the selected job.")
        Else

            'Creates object to store data on job, which java will read to fill form.
            Dim writer As New IO.StreamWriter("data.txt")
            writer.WriteLine(My.Settings.Name)
            writer.WriteLine(jobTypeComboBox.Text)
            writer.WriteLine(jobNumberTextBox.Text)
            writer.WriteLine(installedSerialTextBox.Text)
            writer.WriteLine(faultySerialTextBox.Text)
            writer.WriteLine(installedAssetTextBox.Text)
            writer.WriteLine(faultyAssetTextBox.Text)
            writer.WriteLine(siteTextBox.Text)
            writer.WriteLine(faultTextBox.Text)
            writer.Flush()
            writer.Close()

            'Code to execute the java, which fills the form
            Process.Start("cmd", "/C java -jar fillForm.jar")
        End If
    End Sub


    Private Sub printButton_Click(sender As Object, e As EventArgs) Handles printButton.Click
        If IsNothing(selectedJob) Then
            MsgBox("No job selected.")
            'Checks if selected job has had a shipping document downloaded for it
        ElseIf Not selectedJob.shipDocFound Then
            MsgBox("No shipping document has been downloaded for the selected job.")
        Else
            If selectedJob.jobType = jobTypes.Foodstuffs Then Process.Start("cmd", "/C SumatraPDF.exe -silent -print-to-default fsDoc-Filled.pdf")
            If selectedJob.jobType = jobTypes.Lotto Then Process.Start("cmd", "/C start wordpad.exe /p lottoDoc-Filled.docx")
            Process.Start("cmd", "/C SumatraPDF.exe -silent -print-to-default shipDoc-Filled.pdf")

            ' Deletes files after printing if set in config
            If My.Settings.DeleteOnPrint Then
                With My.Computer.FileSystem
                    If .FileExists("shipDoc.pdf") Then .DeleteFile("shipDoc.pdf")
                    If .FileExists("shipDoc-Filled.pdf") Then .DeleteFile("shipDoc-Filled.pdf")
                    If .FileExists("fsDoc-Filled.pdf") Then .DeleteFile("fsDoc-Filled.pdf")
                    If .FileExists("lottoDoc-Filled.docx") Then .DeleteFile("lottoDoc-Filled.docx")
                End With
            End If
        End If
    End Sub

    'Initialise all the needed outlook items when form is loaded.
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        setStatus("Loading form.")

        ' Start Outlook.
        ' If it is already running, use the same instance.
        olApp = CreateObject("Outlook.Application")

        ' Logon. Doesn't hurt if you are already running and logged on.
        olNs = olApp.GetNamespace("MAPI")
        Try
            olNs.Logon()
        Catch
            MsgBox("Unable to open an outlook window.")
            Environment.Exit(0)
        End Try

        ' Keeps a reference to an explorer window. Outlook closes if there are 0 open windows detected, so this will keep outlook open after user closes any windows.
        olExplorer = olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox).GetExplorer()

        'initializes black list if it doesnt exist
        If My.Settings.BlackList Is Nothing Then My.Settings.BlackList = New Specialized.StringCollection
        My.Settings.Save()

        'when first opening form, checks settings are valid
        checkSettings(False)

    End Sub

    ' Checks if all settings are present. If not, open settings menu.
    Public Sub checkSettings(incorrectSetting As Boolean)
        If incorrectSetting Or Not allSettingsFound() Then
            If Configuration.ShowDialog() = DialogResult.OK Then
                initializeSettings()
                setStatus("Settings saved.")
            Else
                MsgBox("Application cannot function without settings. Please re-open and fill in settings page.")
                Environment.Exit(0)
            End If
        Else
            initializeSettings()
            setStatus("Settings found and loaded.")
        End If
    End Sub


    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        'opens the settings form. if form returns ok, settings were saved
        If Configuration.ShowDialog() = DialogResult.OK Then
            initializeSettings()
            setStatus("Settings saved.")
        Else
            setStatus("Settings not saved.")
        End If
    End Sub

    Public Sub initializeSettings()
        setStatus("Finding shipping documents folder.")
        Try
            shipDocFolder = olNs.GetFolderFromID(My.Settings.Folder)
        Catch
            MsgBox("Invalid folder selected. Please choose different folder.")
            checkSettings(True)
        End Try
    End Sub

    'clears all set variables and all controls on form
    Public Sub clearControls()
        sentItem = Nothing
        shippedJob = Nothing
        selectedJob = Nothing
        calendarItem = Nothing

        jobNumberTextBox.Clear()
        installedSerialTextBox.Clear()
        faultySerialTextBox.Clear()
        jobTypeComboBox.SelectedIndex = -1
        siteTextBox.Clear()
        faultTextBox.Clear()
    End Sub

    'sets the name of form
    Sub setStatus(value As String)
        If String.IsNullOrEmpty(value) Then
            Text = "OneShipper"
        Else
            Text = "OneShipper - " + value
        End If
    End Sub

    'checks that all settings have a value
    Public Function allSettingsFound()
        Return Not String.IsNullOrEmpty(My.Settings.Name) AndAlso
            Not String.IsNullOrEmpty(My.Settings.Folder) AndAlso
            Not String.IsNullOrEmpty(My.Settings.InstalledSerialKeyword) AndAlso
            Not String.IsNullOrEmpty(My.Settings.FaultySerialKeyword) AndAlso
            Not String.IsNullOrEmpty(My.Settings.ToSiteTimeKeyword) AndAlso
            Not String.IsNullOrEmpty(My.Settings.OnsiteTimeKeyword) AndAlso
            Not String.IsNullOrEmpty(My.Settings.AwaySiteTimeKeyword) AndAlso
            Not String.IsNullOrEmpty(My.Settings.ShippingKeyword)
    End Function

    ' Function that returns the job number of an update if the argument contains it.
    Public Function findJobNumber(jobName As String)
        Dim errorMatch = restrictiveJobNumberRegex.Match(jobName)
        If errorMatch.Success Then
            jobName = errorMatch.Value.Substring(0, 8) + errorMatch.Value.Substring(errorMatch.Value.Length - 4, 4)
        End If
        Return jobNumberRegex.Match(jobName)
    End Function

    Private Sub unshippedJobsListBox_MouseDown(sender As Object, e As MouseEventArgs) Handles unshippedJobsListBox.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim index As Integer = unshippedJobsListBox.IndexFromPoint(New Point(e.X, e.Y))
            If index >= 0 Then
                unshippedJobsListBox.SelectedItem = unshippedJobsListBox.Items(index)
                itemsContextMenu.Show(MousePosition)
            End If
        End If
    End Sub

    Function ContainsNonAlphaChars(ByVal StringToCheck As String)
        For i = 0 To StringToCheck.Length - 1
            If Not Char.IsLetter(StringToCheck.Chars(i)) Then
                Return True
            End If
        Next
        Return False
    End Function

    Function quote(toQuote As String)
        Return Chr(34) + toQuote + Chr(34)
    End Function

    Private Sub AddToBlacklistToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToBlacklistToolStripMenuItem.Click
        If IsNothing(selectedJob) Then
            MsgBox("No job selected.")
        Else
            If unshippedJobsListBox.SelectedIndex > -1 AndAlso Not My.Settings.BlackList.Contains(selectedJob.jobNumber) Then
                My.Settings.BlackList.Add(selectedJob.jobNumber)
                unshippedJobsListBox.Items.RemoveAt(unshippedJobsListBox.SelectedIndex)
                clearControls()
                My.Settings.Save()
            End If
        End If
    End Sub

    Private Sub OpenUpdateEmailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenUpdateEmailToolStripMenuItem.Click
        If IsNothing(selectedJob) Then
            MsgBox("No job selected.")
        Else
            If unshippedJobsListBox.SelectedIndex > -1 Then
                selectedJob.item.Display()
            End If
        End If
    End Sub

    Private Sub OpenCalendarAppointmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenCalendarAppointmentToolStripMenuItem.Click
        If IsNothing(selectedJob) Then
            MsgBox("No job selected.")
        Else
            If unshippedJobsListBox.SelectedIndex > -1 Then
                selectedJob.appointment.GetInspector.Display()
            End If
        End If
    End Sub

    Private Sub AttachShipDocToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AttachShipDocToolStripMenuItem.Click
        fd.InitialDirectory = IO.Directory.GetParent(Application.ExecutablePath).FullName
        fd.Filter = "PDF files (*.pdf)|*.pdf"
        If fd.ShowDialog() = DialogResult.OK Then
            My.Computer.FileSystem.CopyFile(fd.FileName, IO.Path.Combine(IO.Directory.GetParent(Application.ExecutablePath).FullName, "shipDoc.pdf"), True)
            selectedJob.shipDocFound = True
        Else
            MsgBox("Unable to copy selected Ship Doc.")
        End If
    End Sub

    Function parseLine(line As String, token As String) As String
        Dim site = ""
        Dim index = line.IndexOf(token, StringComparison.CurrentCultureIgnoreCase)
        If index > -1 Then
            For i = token.Length + 1 To line.Length - 1
                Dim currentChar = line(index + i)
                If currentChar <> vbCr And currentChar <> vbLf Then
                    site += currentChar
                Else
                    Exit For
                End If
            Next
        End If
        Return Trim(site)
    End Function
End Class
