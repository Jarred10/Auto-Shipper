Imports System.Text.RegularExpressions
Imports Auto_Shipper
Imports Microsoft.Office.Interop

Public Class Form1

    'basic outlook objects
    Public olApp As Outlook.Application
    Public olNs As Outlook.NameSpace

    'folder where shipping docs are held
    Public shipDocFolder As Outlook.MAPIFolder

    'variables for searching outlook folders
    Public shipDocSearch As Outlook.Search
    Public partsItemsSearch As Outlook.Search
    Public shippedItemsSearch As Outlook.Search
    Public calendarSearch As Outlook.Search

    Dim sentItems As New List(Of Object)
    Dim calendarItems As New List(Of Object)

    'objects used to store items while looping
    Dim shipDocItem As Object
    Dim sentItem As Object
    Dim shippedJob As Object
    Dim unshippedJob As Item
    Dim calendarItem As Object

    'list of jobs that arent shipped
    Dim unshippedJobs As New SortedSet(Of Item)

    'Regular expression to find SV numbers. Pattern = SV followed by 10 digits
    Dim jobNumberRegex As Regex = New Regex("SV\d{10}", RegexOptions.IgnoreCase)

    'finds unshipped jobs
    Private Sub jobButton_Click(sender As Object, e As EventArgs) Handles jobButton.Click

        Dim activeBlackList = My.Settings.BlackList.Count > 0
        Dim modifiedDate = DateTime.Now.AddDays(-7 * My.Settings.WeeksToCheck)

        clearControls()
        unshippedJobsListBox.Items.Clear()
        unshippedJobs.Clear()

        setName("Searching for jobs.")

        partsItemsSearch = olApp.AdvancedSearch("'" + olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail).FolderPath _
        + "'", "urn:schemas:httpmail:subject LIKE '%SV%' 
        AND urn:schemas:httpmail:textdescription LIKE '%" + My.Settings.NewPartKeyword + "%' 
        AND urn:schemas:httpmail:textdescription LIKE '%" + My.Settings.FaultyPartKeyword + "%' 
        AND urn:schemas:httpmail:textdescription LIKE '%" + My.Settings.OnsiteTimeKeyword + "%' 
        AND urn:schemas:httpmail:datereceived >= '" + Format(modifiedDate, "Short Date") + "'", False)

        shippedItemsSearch = olApp.AdvancedSearch("'" + olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail).FolderPath _
        + "'", "urn:schemas:httpmail:subject LIKE '%SV%' 
        AND (urn:schemas:httpmail:subject LIKE '%" + My.Settings.ShippingKeyword + "%' 
        OR urn:schemas:httpmail:textdescription LIKE '%" + My.Settings.ShippingKeyword + "%') 
        AND urn:schemas:httpmail:datereceived >= '" + Format(modifiedDate, "Short Date") + "'", False)


        partsItemsSearch.Results.Sort("[SentOn]")
        shippedItemsSearch.Results.Sort("[SentOn]")

        ' Loops through results of search for sent mail with SV in subject
        For Each partItem In partsItemsSearch.Results
            Dim jobNumberMatch As Match = findJobNumber(partItem.Subject)
            If jobNumberMatch.Success Then
                Dim job As Item = New Item(partItem, jobNumberMatch.Value)
                If activeBlackList Then
                    If Not My.Settings.BlackList.Contains(job.jobNumber) Then
                        ' Adds mail item to a list of unshipped jobs.
                        unshippedJobs.Add(job)
                    End If
                Else
                    unshippedJobs.Add(job)
                End If
            End If
        Next

        setName("Removing shipped jobs.")

        For Each shippedItem In shippedItemsSearch.Results
            Dim jobNumberMatch As Match = findJobNumber(shippedItem.Subject)
            If jobNumberMatch.Success Then
                unshippedJobs.Remove(New Item(shippedItem, jobNumberMatch.Value))
            End If
        Next

        setName("Parsing found jobs.")

        calendarSearch = olApp.AdvancedSearch("'" + olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).FolderPath _
        + "'", "urn:schemas:httpmail:subject LIKE '%SV%' 
        AND urn:schemas:calendar:dtstart >= '" + Format(modifiedDate, "Short Date") + "'", False)
        calendarSearch.Results.Sort("[Start]")

        'Loops through all unshipped jobs, determining the customer of the job and sets variables based on customer
        For Each unshippedJob In unshippedJobs
            For Each calendarItem In calendarSearch.Results
                If calendarItem.Subject.ToString.ContainsIgnoreCase(unshippedJob.jobNumber) Then
                    unshippedJob.calendarSubject = calendarItem.Subject
                    unshippedJobsListBox.Items.Add(unshippedJob)
                    unshippedJobsListBox.Refresh()
                    Dim siteIndex As Integer
                    Dim secondIndex As Integer
                    If calendarItem.Body.ToString.ContainsIgnoreCase("foodstuffs") Then
                        'Determines if job is for foodstuffs
                        siteIndex = calendarItem.Body.IndexOf("site ::", StringComparison.OrdinalIgnoreCase)
                        secondIndex = calendarItem.Body.IndexOf("contact name ::", StringComparison.OrdinalIgnoreCase)
                        If siteIndex <> -1 And secondIndex <> -1 Then
                            siteIndex += 8
                            unshippedJob.site = Trim(calendarItem.Body.Substring(siteIndex, secondIndex - siteIndex - 2))
                            unshippedJob.jobType = jobTypes.Foodstuffs
                        End If

                    ElseIf calendarItem.Body.ToString.ContainsIgnoreCase("nzlotteries") Then
                        'Determines if job is for Lotto
                        siteIndex = calendarItem.Body.IndexOf("retailer name:", StringComparison.OrdinalIgnoreCase)
                        secondIndex = calendarItem.Body.IndexOf("address:", StringComparison.OrdinalIgnoreCase)
                        If siteIndex <> -1 And secondIndex <> -1 Then
                            siteIndex += 15
                            unshippedJob.site = Trim(calendarItem.Body.Substring(siteIndex, secondIndex - siteIndex - 2))
                            unshippedJob.jobType = jobTypes.Lotto
                        End If
                    Else
                        'If job is not for foodstuffs or lotto, no additional forms required
                        unshippedJob.jobType = jobTypes.Other
                    End If
                    Exit For
                End If
            Next
        Next

        setName("Job search complete.")
    End Sub

    'When user selects a job from the list, populate the text boxes with relevant information so they can edit or choose what to be added to form.
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles unshippedJobsListBox.SelectedIndexChanged
        clearControls()
        If unshippedJobsListBox.SelectedIndex > -1 Then
            For Each unshippedJob In unshippedJobs
                'if selected items job number matches a job number from list of unshipped jobs
                If unshippedJob.jobNumber.ContainsIgnoreCase(unshippedJobsListBox.SelectedItem.jobNumber) Then
                    'sets textboxes to already stored values
                    jobNumberTextBox.Text = unshippedJob.jobNumber
                    siteTextBox.Text = unshippedJob.site
                    jobTypeComboBox.Text = unshippedJob.jobType.ToString
                    faultTextBox.Clear()

                    Dim index = 0
                    Dim contents() As String = unshippedJob.item.Body.Split(vbCrLf.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

                    For i = 0 To My.Settings.EmailLayout.Count - 1
                        If index = contents.Length Then
                            MsgBox("Unable to parse job. Could not find " + My.Settings.EmailLayout(i) + ".")
                            Exit For
                        End If
                        If My.Settings.EmailLayout(i) = "Times" Then
                            While Not contents(index).Contains(My.Settings.OnsiteTimeKeyword)
                                index += 1
                            End While
                            index += 1
                            If index = contents.Length Then
                                MsgBox("Unable to parse job. Could not find onsite time keyword: " + My.Settings.OnsiteTimeKeyword)
                                Exit For
                            End If
                            If contents(index).Contains(My.Settings.AwaySiteTimeKeyword) Then
                                index += 1
                            ElseIf contents(index + 1).Contains(My.Settings.AwaySiteTimeKeyword) Then
                                index += 2
                            End If
                        ElseIf My.Settings.EmailLayout(i) = "Parts" Then
                            While Not contents(index).Contains(My.Settings.FaultyPartKeyword)
                                If contents(index).Contains(My.Settings.NewPartKeyword) Then
                                    serialInTextBox.Text = contents(index).Substring(My.Settings.NewPartKeyword.Length).Trim()
                                End If
                                index += 1
                                If index = contents.Length Then
                                    MsgBox("Unable to parse job. Could not find faulty part keyword: " + My.Settings.FaultyPartKeyword)
                                    Exit For
                                End If

                            End While
                            serialOutTextBox.Text = contents(index).Substring(My.Settings.FaultyPartKeyword.Length).Trim()
                            index += 1
                        ElseIf My.Settings.EmailLayout(i) = "Update" Then
                            'if the fault text is not at the end of the update
                            If i < 2 Then
                                'check what follows the fault text, if parts
                                If My.Settings.EmailLayout(i + 1) = "Parts" Then
                                    While Not contents(index).Contains(My.Settings.NewPartKeyword)
                                        faultTextBox.Text += contents(index)
                                        index += 1
                                        If index = contents.Length Then
                                            MsgBox("Unable to parse job. Could not find new part keyword: " + My.Settings.NewPartKeyword)
                                            Exit For
                                        End If
                                    End While
                                    'if times
                                ElseIf My.Settings.EmailLayout(i + 1) = "Time" Then
                                    While Not contents(index).Contains(My.Settings.OnsiteTimeKeyword) Or Not contents(index).Contains(My.Settings.ToSiteTimeKeyword)
                                        faultTextBox.Text += contents(index) + Environment.NewLine
                                        index += 1
                                        If index = contents.Length Then
                                            MsgBox("Unable to parse job. Could not find onsite time keyword: " + My.Settings.OnsiteTimeKeyword)
                                            Exit For
                                        End If
                                    End While
                                End If
                            Else
                                While index < contents.Length
                                    faultTextBox.Text += contents(index) + Environment.NewLine
                                    index += 1
                                End While
                            End If
                        Else
                            MsgBox("Invalid email layout settings.")
                        End If
                    Next
                    Exit For
                End If
            Next
        End If
    End Sub

    ' Searches for email with subject that contains the chosen job to ship. Searches all matching emails for one with attachments.
    Private Sub shipDocButton_Click(sender As Object, e As EventArgs) Handles getDocButton.Click
        If IsNothing(unshippedJob) Then
            MsgBox("No job selected.")
        Else
            unshippedJob.shipDocFound = False

            'Performs outlook seearch for emails in the shipping document folder with the job number in the subject line
            shipDocSearch = olApp.AdvancedSearch("'" + shipDocFolder.FolderPath + "'", "urn:schemas:httpmail:subject LIKE '%" + unshippedJob.jobNumber + "%'
            AND urn:schemas:httpmail:hasattachment = True")

            'If the results of the search turn up nothing, throw error
            If shipDocSearch.Results.Count = 0 Then
                MsgBox("No shipping document email found for selected job in folder: " + My.Settings.Folder + ".")
            Else
                'Loop through all results
                For i = 1 To shipDocSearch.Results.Count
                    shipDocItem = shipDocSearch.Results.Item(i)
                    'Checks if email has any attachments, and either the subject or body of email contain ship doc in some form
                    If shipDocItem.Attachments.Count > 0 AndAlso (LCase(shipDocItem.Subject) Like "*ship*doc*" Or LCase(shipDocItem.Body) Like "*ship*doc*") Then
                        'Loops through all attachments, in most cases this will be only one file
                        For a = 1 To shipDocItem.Attachments.Count
                            'Checks if the name of attachment indicates that it is a shipping document
                            If UCase(shipDocItem.Attachments(a).DisplayName) Like "_D*.PDF" Then
                                'Saves attachment and sets flag on item that it has an appropriate shipping document downloaded for it
                                shipDocItem.Attachments(a).SaveAsFile(IO.Path.Combine(IO.Directory.GetParent(Application.ExecutablePath).FullName, "shipDoc.pdf"))
                                unshippedJob.shipDocFound = True
                                Exit For
                            End If
                        Next
                        Exit For
                    End If
                Next
                If Not unshippedJob.shipDocFound Then
                    MsgBox("None of the emails found for job contain attachments.")
                End If
            End If
        End If
    End Sub


    Private Sub produceButton_Click(sender As Object, e As EventArgs) Handles produceButton.Click
        If IsNothing(unshippedJob) Then
            MsgBox("No job selected.")

            'Checks if selected job has had a shipping document downloaded for it
        ElseIf Not unshippedJob.shipDocFound Then

            MsgBox("No shipping document has been downloaded for the selected job.")
        Else

            'Creates object to store data on job, which java will read to fill form.
            Dim objWriter As New System.IO.StreamWriter("data.txt")
            objWriter.WriteLine(My.Settings.Name)
            objWriter.WriteLine(unshippedJob.jobType.ToString)
            objWriter.WriteLine(unshippedJob.jobNumber)
            objWriter.WriteLine(serialInTextBox.Text)
            objWriter.WriteLine(serialOutTextBox.Text)
            objWriter.WriteLine(unshippedJob.site)
            objWriter.WriteLine(faultTextBox.Text)
            objWriter.Close()

            'Code to execute the java, which fills the form
            Process.Start("cmd", "/C java -jar fillForm.jar")
        End If
    End Sub


    Private Sub printButton_Click(sender As Object, e As EventArgs) Handles printButton.Click
        If IsNothing(unshippedJob) Then
            MsgBox("No job selected.")
            'Checks if selected job has had a shipping document downloaded for it
        ElseIf Not unshippedJob.shipDocFound Then
            MsgBox("No shipping document has been downloaded for the selected job.")
        Else
            If unshippedJob.jobType = jobTypes.Foodstuffs Then Process.Start("cmd", "/C SumatraPDF.exe -silent -print-to-default fsDoc-Filled.pdf")
            If unshippedJob.jobType = jobTypes.Lotto Then Process.Start("cmd", "/C start wordpad.exe /p lottoDoc-Filled.docx")
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

    Private Sub blacklistButton_Click(sender As Object, e As EventArgs) Handles blacklistButton.Click
        If IsNothing(unshippedJob) Then
            MsgBox("No job selected.")
        Else
            If unshippedJobsListBox.SelectedIndex > -1 AndAlso Not My.Settings.BlackList.Contains(unshippedJob.jobNumber) Then
                My.Settings.BlackList.Add(unshippedJob.jobNumber)
                unshippedJobsListBox.Items.RemoveAt(unshippedJobsListBox.SelectedIndex)
                clearControls()
                My.Settings.Save()
            End If
        End If
    End Sub


    'Initialise all the needed outlook items when form is loaded.
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        setName("Loading form.")

        ' Start Outlook.
        ' If it is already running, use the same instance.
        olApp = CreateObject("Outlook.Application")

        ' Logon. Doesn't hurt if you are already running and logged on.
        olNs = olApp.GetNamespace("MAPI")
        olNs.Logon()

        'initializes both string collections in settings if they are not already
        If My.Settings.EmailLayout Is Nothing Then My.Settings.EmailLayout = New Specialized.StringCollection
        If My.Settings.BlackList Is Nothing Then My.Settings.BlackList = New Specialized.StringCollection
        My.Settings.Save()

        'when first opening form, checks settings are valid
        checkSettings(False)

    End Sub

    ' Checks if all settings are present. If not, open settings menu.
    Public Sub checkSettings(incorrectSetting As Boolean)
        If incorrectSetting Or Not allSettingsFound() Then
            If Settings.ShowDialog() = DialogResult.OK Then
                initializeSettings()
                setName("Settings saved.")
            Else
                MsgBox("Application cannot function without settings. Please re-open and fill in settings page.")
                Environment.Exit(0)
            End If
        Else
            initializeSettings()
            setName("Settings found and loaded.")
        End If
    End Sub


    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        'opens the settings form. if form returns ok, settings were saved
        If Settings.ShowDialog() = DialogResult.OK Then
            initializeSettings()
            setName("Settings saved.")
        Else
            setName("Settings not saved.")
        End If
    End Sub

    Public Sub initializeSettings()
        setName("Finding shipping documents folder.")
        Try
            shipDocFolder = olNs.GetFolderFromID(My.Settings.Folder)
        Catch
            MsgBox("Invalid folder selected. Please choose different folder.")
            checkSettings(True)
        End Try
    End Sub

    'clears all set variables and all controls on form
    Public Sub clearControls()
        shipDocItem = Nothing
        sentItem = Nothing
        shippedJob = Nothing
        unshippedJob = Nothing
        calendarItem = Nothing

        jobNumberTextBox.Clear()
        serialInTextBox.Clear()
        serialOutTextBox.Clear()
        jobTypeComboBox.SelectedIndex = -1
        siteTextBox.Clear()
        faultTextBox.Clear()
    End Sub

    'sets the name of form
    Sub setName(value As String)
        If String.IsNullOrEmpty(value) Then
            Text = "Quick Shipper"
        Else
            Text = "Quick Shipper - " + value
        End If
    End Sub

    'checks that all settings have a value
    Public Function allSettingsFound()
        Return Not String.IsNullOrEmpty(My.Settings.Name) AndAlso
            Not String.IsNullOrEmpty(My.Settings.Folder) AndAlso
            Not String.IsNullOrEmpty(My.Settings.NewPartKeyword) AndAlso
            Not String.IsNullOrEmpty(My.Settings.FaultyPartKeyword) AndAlso
            Not String.IsNullOrEmpty(My.Settings.ToSiteTimeKeyword) AndAlso
            Not String.IsNullOrEmpty(My.Settings.OnsiteTimeKeyword) AndAlso
            Not String.IsNullOrEmpty(My.Settings.AwaySiteTimeKeyword) AndAlso
            Not String.IsNullOrEmpty(My.Settings.ShippingKeyword) AndAlso
            My.Settings.EmailLayout.Count = 3
    End Function

    ' Function that returns the job number of an update if the argument contains it.
    Public Function findJobNumber(jobName As String)
        Return jobNumberRegex.Match(jobName)
    End Function

End Class
