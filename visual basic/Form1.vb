Imports Auto_Shipper
Imports Microsoft.Office.Interop

Public Class Form1

    'basic outlook objects
    Dim olApp As Outlook.Application
    Dim olNs As Outlook.NameSpace

    'folder where shipping docs are held
    Dim shipDocFolder As Outlook.MAPIFolder

    'variables for searching outlook folders
    Dim shipDocSearch As Outlook.Search
    Dim sentItemsSearch As Outlook.Search
    Dim calendarSearch As Outlook.Search

    'objects used to store items while looping
    Dim shipDocItem As Object
    Dim sentItem As Object
    Dim shippedJob As Object
    Dim unshippedJob As Item
    Dim calendarItem As Object

    'list of jobs that arent shipped
    Dim unshippedJobs As New List(Of Item)

    'Regular expression to find SV numbers. Pattern = SV followed by 10 digits
    Dim jobNumberRegex = New System.Text.RegularExpressions.Regex("SV\d{10}")

    ' --- Config ---

    'file name of config. in future this may be configurable if needed
    Dim FILE_NAME As String = "config.txt"

    'finds unshipped jobs
    Private Sub jobButton_Click(sender As Object, e As EventArgs) Handles jobButton.Click

        unshippedJobsListBox.Items.Clear()

        ' Loops through all sent mail in last three weeks that contain "SV"
        For Each sentItem In sentItemsSearch.Results
            Dim sentItemJobNo As String = findJobNumber(sentItem.Subject)
            ' Checks if update was for a job that used parts, and not for 
            If sentItem.Body.ToString.Contains(My.Settings.NewPartKeyword, StringComparison.OrdinalIgnoreCase) AndAlso sentItem.Body.ToString.Contains(My.Settings.FaultyPartKeyword, StringComparison.OrdinalIgnoreCase) Then
                If Not unshippedJobs.Contains(New Item(sentItem, sentItemJobNo)) Then
                    ' Adds mail item to a list of unshipped jobs.
                    unshippedJobs.Add(New Item(sentItem, sentItemJobNo))
                End If
                ' If update wasnt for job that used parts, checks if update was for shipping parts
            ElseIf sentItem.Subject.ToString.Contains("shipping", StringComparison.OrdinalIgnoreCase) Or sentItem.Body.ToString.Contains("shipping", StringComparison.OrdinalIgnoreCase) Then
                ' Removes shipped updates from list of unshipped updates by looping through all current unshipped jobs and comparing job number
                For Each unshippedJob In unshippedJobs
                    If sentItemJobNo.Contains(unshippedJob.jobNumber, StringComparison.OrdinalIgnoreCase) Then
                        unshippedJobs.Remove(unshippedJob)
                        Exit For
                    End If
                Next
            End If
        Next

        'Loops through all unshipped jobs, determining the customer of the job and sets variables based on customer
        For Each unshippedJob In unshippedJobs
            For Each calendarItem In calendarSearch.Results
                Dim calendarItemJobNumber As String = findJobNumber(calendarItem.Subject)
                If calendarItemJobNumber Like unshippedJob.jobNumber Then
                    unshippedJobsListBox.Items.Add(calendarItem.Subject)
                    Dim siteIndex As Integer
                    Dim secondIndex As Integer
                    If calendarItem.Body.ToString.Contains("foodstuffs", StringComparison.OrdinalIgnoreCase) Then
                        'Determines if job is for foodstuffs
                        siteIndex = calendarItem.Body.IndexOf("site ::", StringComparison.OrdinalIgnoreCase)
                        secondIndex = calendarItem.Body.IndexOf("contact name ::", StringComparison.OrdinalIgnoreCase)
                        If siteIndex <> -1 And secondIndex <> -1 Then
                            siteIndex += 8
                            unshippedJob.site = Trim(calendarItem.Body.Substring(siteIndex, secondIndex - siteIndex - 2))
                            unshippedJob.jobType = jobTypes.Foodstuffs
                        End If

                    ElseIf calendarItem.Body.ToString.Contains("nzlotteries", StringComparison.OrdinalIgnoreCase) Then
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
            unshippedJob = Nothing
        Next
    End Sub

    'When user selects a job from the list, populate the text boxes with relevant information so they can edit or choose what to be added to form.
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles unshippedJobsListBox.SelectedIndexChanged
        If unshippedJobsListBox.SelectedItem IsNot Nothing Then
            For i = 0 To unshippedJobs.Count
                unshippedJob = unshippedJobs(i)
                If unshippedJob.jobNumber.Contains(findJobNumber(unshippedJobsListBox.SelectedItem), StringComparison.OrdinalIgnoreCase) Then
                    Dim contents() As String = Split(unshippedJob.item.Body, vbCrLf)
                    jobNumberTextBox.Text = unshippedJob.jobNumber
                    siteTextBox.Text = unshippedJob.site
                    jobTypeTextBox.Text = unshippedJob.jobType.ToString

                    For x = 0 To contents.Length - 1
                        With contents(x)
                            If .Contains(My.Settings.NewPartKeyword, StringComparison.OrdinalIgnoreCase) Then
                                serialInTextBox.Text = .Substring(.IndexOf("IN: ") + 5)
                            ElseIf .Contains(My.Settings.FaultyPartKeyword, StringComparison.OrdinalIgnoreCase) Then
                                serialOutTextBox.Text = .Substring(.IndexOf("OUT: ") + 6)
                                faultTextBox.Text = contents(x + 2)
                            End If
                        End With
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
            shipDocSearch = olApp.AdvancedSearch("'" + shipDocFolder.FolderPath + "'", "urn:schemas:httpmail:subject LIKE '%" + unshippedJob.jobNumber + "%'")

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


    'Initialise all the needed outlook items when form is loaded.
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Settings.EmailLayout Is Nothing Then
            My.Settings.EmailLayout = New System.Collections.Specialized.StringCollection
        End If

        checkSettings()


        ' Start Outlook.
        ' If it is already running, you'll use the same instance.
        olApp = CreateObject("Outlook.Application")

        ' Logon. Doesn't hurt if you are already running and logged on.
        olNs = olApp.GetNamespace("MAPI")
        olNs.Logon()


        ' Restrict to last three weeks.
        sentItemsSearch = olApp.AdvancedSearch("'" + olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail).FolderPath _
            + "'", "urn:schemas:httpmail:subject LIKE '%SV%' AND urn:schemas:httpmail:datereceived >= '" + Format(DateAdd("d", -(7 * My.Settings.WeeksToCheck), Now), "Short Date") + "'", False)
        calendarSearch = olApp.AdvancedSearch("'" + olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).FolderPath _
            + "'", "urn:schemas:httpmail:subject LIKE '%SV%' AND urn:schemas:calendar:dtstart >= '" + Format(DateAdd("d", -(7 * My.Settings.WeeksToCheck), Now), "Short Date") + "'", False)


        ' Sort by oldest items first. This is to try and find the original update/appointment before finding replies/further appointments
        sentItemsSearch.Results.Sort("[ReceivedTime]")
        calendarSearch.Results.Sort("[Start]")

    End Sub

    ' Function that returns the job number of an update if the argument contains it.
    Public Function findJobNumber(jobName As String)
        Dim jobNumberMatch = jobNumberRegex.Match(jobName.ToUpper)
        If jobNumberMatch.Success Then Return jobName.Substring(jobNumberMatch.Index, 12).ToUpper
        Return vbNullString
    End Function

    ' Checks if all settings are present. If not, open settings menu.
    Public Function checkSettings()
        If Not allSettingsFound() Then
            'If settings menu returns OK, update status. Otherwise, alert user and exit.
            If Settings.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Text = "Quick Shipper - Settings created sucessfully."
            Else
                MsgBox("Settings couldn't be saved.")
                Environment.Exit(1)
            End If
        Else
            Text = "Quick Shipper - Settings found and loaded."
        End If
    End Function


    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        If Settings.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Text = "Quick Shipper - Settings saved."
        Else
            MsgBox("Settings couldn't be saved.")
            Environment.Exit(1)
        End If
    End Sub

    Public Function allSettingsFound()
        Return String.IsNullOrEmpty(My.Settings.Name) Or String.IsNullOrEmpty(My.Settings.Folder) Or String.IsNullOrEmpty(My.Settings.NewPartKeyword) Or Not String.IsNullOrEmpty(My.Settings.FaultyPartKeyword) Or My.Settings.EmailLayout.Count = 0
    End Function
End Class
