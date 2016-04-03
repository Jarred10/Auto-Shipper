Imports System.Text.RegularExpressions
Imports Microsoft.Office.Interop
Imports System.Runtime.CompilerServices

Public Class Form1

    Dim olApp As Outlook.Application
    Dim olNs As Outlook.NameSpace
    Dim shipDocFolder As Outlook.MAPIFolder
    Dim sentFolder As Outlook.MAPIFolder
    Dim calendarFolder As Outlook.MAPIFolder

    Dim shipDocItemsList As Outlook.Items
    Dim sentItemsList As Outlook.Items
    Dim calendarItemsList As Outlook.Items

    Dim outlookSearch As Outlook.Search

    Dim shipDocItem As Object
    Dim sentItem As Object
    Dim shippedJob As Object
    Dim unshippedJob As Item
    Dim calendarItem As Object

    Dim unshippedJobs As New List(Of Item)

    'Regular expression to find SV numbers
    Dim jobNumberRegex = New Regex("SV\d{10}")

    'Config
    Dim shipDocFolderName As String
    Dim deleteOnPrint As Boolean

    Private Sub finderButton_Click(sender As Object, e As EventArgs) Handles finderButton.Click

        'Clears all textboxes and listbox
        unshippedJobsListBox.Items.Clear()
        jobNumberTextBox.Clear()
        serialInTextBox.Clear()
        serialOutTextBox.Clear()
        siteTextBox.Clear()
        faultTextBox.Clear()

        ' Loops through all sent mail in last three weeks.
        For Each sentItem In sentItemsList
            Dim sentItemJobNo As String = findJobNumber(sentItem.Subject)
            ' Checks if subject of sent mail contains SV. Filters to all updates about jobs
            If Not String.IsNullOrEmpty(sentItemJobNo) Then
                ' Checks if update was for a job that used parts, and not for 
                If sentItem.Body.ToString.Contains("out: ", StringComparison.OrdinalIgnoreCase) Then
                    Dim found As Boolean = False
                    'Checks for duplicate jobs, ie. if there is communication about a job and original update is in the email chain.
                    For i = 0 To unshippedJobs.Count - 1
                        If sentItemJobNo.Contains(unshippedJobs.ElementAt(i).jobNumber, StringComparison.OrdinalIgnoreCase) Then
                            found = True
                            Exit For
                        End If
                    Next
                    If Not found Then
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
            End If
        Next

        'Loops through all recent calendar items, looking for unshipped updates.
        For Each calendarItem In calendarItemsList
            Dim calendarItemJobNumber As String = findJobNumber(calendarItem.Subject)
            'If calendar subject contained SV. Filters to all calendar appointments about jobs
            If Not String.IsNullOrEmpty(calendarItemJobNumber) Then
                'Loops through all unshipped jobs
                For Each unshippedJob In unshippedJobs
                    'If calendar job number matches unshipped job number, need to add it to the listbox
                    If calendarItemJobNumber.Contains(unshippedJob.jobNumber, StringComparison.OrdinalIgnoreCase) AndAlso Not unshippedJobsListBox.Items.Contains(calendarItem.Subject) Then
                        unshippedJobsListBox.Items.Add(calendarItem.Subject)
                        'Tries to find the site for job using pre-existing format for foodstuffs job details. If it can't find site, assumes that job is not for foodstuffs
                        Dim siteIndex = calendarItem.Body.IndexOf("site ::", StringComparison.OrdinalIgnoreCase)
                        Dim contactIndex = calendarItem.Body.IndexOf("contact name ::", StringComparison.OrdinalIgnoreCase)
                        If siteIndex <> -1 And contactIndex <> -1 Then
                            unshippedJob.site = Trim(calendarItem.Body.Substring(siteIndex + 8, contactIndex - (siteIndex + 10)))
                            unshippedJob.fs = True
                        End If
                    End If
                Next
            End If
        Next
    End Sub

    'When user selects a job from the list, populate the text boxes with relevant information so they can edit or choose what to be added to form.
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles unshippedJobsListBox.SelectedIndexChanged
        If unshippedJobsListBox.SelectedItem IsNot Nothing Then
            For Each unshippedJob In unshippedJobs
                If unshippedJob.jobNumber.Contains(findJobNumber(unshippedJobsListBox.SelectedItem), StringComparison.OrdinalIgnoreCase) Then
                    Dim contents() As String = Split(unshippedJob.item.Body, vbCrLf)
                    Dim index As Integer
                    jobNumberTextBox.Text = unshippedJob.jobNumber
                    siteTextBox.Text = unshippedJob.site
                    foodstuffsJobCheckBox.Checked = unshippedJob.fs

                    For index = 0 To contents.Length - 1
                        With contents(index)
                            If .Contains("in: ", StringComparison.OrdinalIgnoreCase) Then
                                serialInTextBox.Text = .Substring(.IndexOf("IN: ") + 5)
                            ElseIf .Contains("out: ", StringComparison.OrdinalIgnoreCase) Then
                                serialOutTextBox.Text = .Substring(.IndexOf("OUT: ") + 6)
                                faultTextBox.Text = contents(index + 2)
                            End If
                        End With
                    Next
                    Exit For
                End If
            Next
        End If
    End Sub

    ' Searches for email with subject that contains the chosen job to ship. Searches all matching emails for one with attachments.
    Private Sub shipDocButton_Click(sender As Object, e As EventArgs) Handles shipDocButton.Click
        Dim attachmentDownloaded = False
        outlookSearch = olApp.AdvancedSearch("'" + shipDocFolder.FolderPath + "'", "urn:schemas:httpmail:subject LIKE '%" + unshippedJob.jobNumber + "%'", False)

        If outlookSearch.Results.Count = 0 Then
            MsgBox("Error: No shipping document email found for selected job.")

        Else
            For i = 1 To outlookSearch.Results.Count
                shipDocItem = outlookSearch.Results.Item(i)
                If shipDocItem.Attachments.Count > 0 AndAlso (LCase(shipDocItem.Subject) Like "*ship*doc*" Or LCase(shipDocItem.Body) Like "*ship*doc*") Then
                    shipDocItem.Attachments(1).SaveAsFile(IO.Path.Combine(IO.Directory.GetParent(Application.ExecutablePath).FullName, "shipDoc.pdf"))
                    attachmentDownloaded = True
                    Exit For
                End If
            Next

            If Not attachmentDownloaded Then
                MsgBox("Error: None of the emails found for job contain attachments.")
            End If

        End If


    End Sub


    Private Sub produceButton_Click(sender As Object, e As EventArgs) Handles produceButton.Click
        If foodstuffsJobCheckBox.Checked Then
            Process.Start("cmd", "/C java -jar fillForm.jar " + Chr(34) + "True|" + jobNumberTextBox.Text + "|" + serialInTextBox.Text + "|" + serialOutTextBox.Text + "|" + siteTextBox.Text + "|" + faultTextBox.Text + Chr(34))
            Process.Start("cmd", "/C SumatraPDF.exe -print-to-default fsDoc-Filled.pdf")
        Else
            Process.Start("cmd", "/C java -jar fillForm.jar " + Chr(34) + "False|" + serialOutTextBox.Text + "|" + faultTextBox.Text + Chr(34))
        End If
    End Sub


    Private Sub printButton_Click(sender As Object, e As EventArgs) Handles printButton.Click
        Dim printProcess As New ProcessStartInfo("cmd")
        printProcess.CreateNoWindow = True
        printProcess.Arguments = "/C SumatraPDF.exe -print-to-default shipDoc-Filled.pdf"

        Process.Start(printProcess)

        ' Deletes files after printing if set in config
        If deleteOnPrint Then
            If My.Computer.FileSystem.FileExists("shipDoc.pdf") Then My.Computer.FileSystem.DeleteFile("shipDoc.pdf")
            If My.Computer.FileSystem.FileExists("shipDoc-Filled.pdf") Then My.Computer.FileSystem.DeleteFile("shipDoc-Filled.pdf")
            If My.Computer.FileSystem.FileExists("fsDoc-Filled.pdf") Then My.Computer.FileSystem.DeleteFile("fsDoc-Filled.pdf")
        End If
    End Sub


    'Initialise all the needed outlook items when form is loaded.
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Start Outlook.
        ' If it is already running, you'll use the same instance.
        olApp = CreateObject("Outlook.Application")

        ' Logon. Doesn't hurt if you are already running and logged on.
        olNs = olApp.GetNamespace("MAPI")
        olNs.Logon()

        loadConfig()

        ' Grab the shipping doc folder, sent items folder and calendar.
        If String.IsNullOrEmpty(shipDocFolderName) Then
            shipDocFolder = olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox)
        Else
            Try
                shipDocFolder = olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox).Folders(shipDocFolderName)
            Catch
                MsgBox("Error: Invalid update folder in config file.")
                Environment.Exit(0)
            End Try
        End If

        sentFolder = olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail)
        calendarFolder = olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar)

        ' Restrict to last three weeks.
        shipDocItemsList = shipDocFolder.Items.Restrict("[ReceivedTime] >= '" + Format(DateAdd("d", -21, Now), "Short Date") + "'")
        sentItemsList = sentFolder.Items.Restrict("[ReceivedTime] >= '" + Format(DateAdd("d", -21, Now), "Short Date") + "'")
        calendarItemsList = calendarFolder.Items.Restrict("[Start] >= '" + Format(DateAdd("d", -21, Now), "Short Date") + "'")


        ' Sort by oldest items first. This is to try and find the original update/appointment before finding replies/further appointments
        shipDocItemsList.Sort("[ReceivedTime]", True)
        sentItemsList.Sort("[ReceivedTime]")
        calendarItemsList.Sort("[Start]")

    End Sub

    ' Function that returns the job number of an update if the argument contains it.
    Public Function findJobNumber(jobName As String)
        Dim jobNumberMatch = jobNumberRegex.Match(jobName.ToUpper)
        If jobNumberMatch.Success Then Return jobName.Substring(jobNumberMatch.Index, 12).ToUpper
        Return vbNullString
    End Function

    ' Reads CSV file to set the folder where shipping docs are found
    Public Function loadConfig()
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("config.csv")
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(";")

            Dim currentRow As String()

            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    If String.IsNullOrEmpty(shipDocFolderName) And currentRow(0) = "Folder" And Not String.IsNullOrEmpty(currentRow(1)) Then
                        shipDocFolderName = currentRow(1)
                    ElseIf currentRow(0) = "DeleteOnPrint" And Not String.IsNullOrEmpty(currentRow(1)) Then
                        deleteOnPrint = currentRow(1) = "True"
                    End If
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
                End Try
            End While
        End Using
        loadConfig = ""
    End Function

End Class