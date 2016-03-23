Imports System.Text.RegularExpressions
Imports Microsoft.Office.Interop
Imports System.Runtime.CompilerServices

Public Class Form1

    Dim olApp As Outlook.Application
    Dim olNs As Outlook.NameSpace
    Dim inboxFolder As Outlook.MAPIFolder
    Dim sentFolder As Outlook.MAPIFolder
    Dim calendarFolder As Outlook.MAPIFolder

    Dim inboxItemsList As Outlook.Items
    Dim sentItemsList As Outlook.Items
    Dim calendarItemsList As Outlook.Items

    Dim inboxItem As Object
    Dim sentItem As Object
    Dim shippedJob As Object
    Dim unshippedJob As Object
    Dim calendarItem As Object

    Dim unshippedJobs As New List(Of Item)

    'Regular expression to find SV numbers
    Dim jobNumberRegex = New Regex("SV\d{10}")

    'Config
    Dim updateFolder As String

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
            Dim sentItemJob = findJobNumber(sentItem.Subject)
            ' Checks if subject of sent mail contains SV. Filters to all updates about jobs
            If Not String.IsNullOrEmpty(sentItemJob) Then
                ' Checks if update was for a job that used parts, and not for 
                If Contains(sentItem.Body, "out: ") Then
                    Dim x As Integer
                    Dim found As Boolean = False
                    'Checks for duplicate jobs, ie. if there is communication about a job and original update is in the email chain.
                    For x = 0 To unshippedJobs.Count - 1
                        If Contains(sentItemJob, unshippedJobs.ElementAt(x).jobNumber) Then
                            found = True
                            Exit For
                        End If
                    Next
                    If Not found Then
                        ' Adds mail item to a list of unshipped jobs.
                        unshippedJobs.Add(New Item(sentItem, sentItemJob))
                    End If
                    ' If update wasnt for job that used parts, checks if update was for shipping parts
                ElseIf Contains(sentItem.Subject, "shipping") Or Contains(sentItem.Body, "shipping") Then
                    ' Removes shipped updates from list of unshipped updates by looping through all current unshipped jobs and comparing job number
                    For Each unshippedJob In unshippedJobs
                        If Contains(sentItemJob, unshippedJob.jobNumber) Then
                            unshippedJobs.Remove(unshippedJob)
                            Exit For
                        End If
                    Next
                End If
            End If
        Next

        'Loops through all recent calendar items, looking for unshipped updates.
        For Each calendarItem In calendarItemsList
            Dim calendarItemJobNumber = findJobNumber(calendarItem.Subject)
            'If calendar subject contained SV. Filters to all calendar appointments about jobs
            If Not String.IsNullOrEmpty(calendarItemJobNumber) Then
                'Loops through all unshipped jobs
                For Each unshippedJob In unshippedJobs
                    'If calendar job number matches unshipped job number, need to add it to the listbox
                    If Contains(calendarItemJobNumber, unshippedJob.jobNumber) Then
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

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles unshippedJobsListBox.SelectedIndexChanged
        If unshippedJobsListBox.SelectedItem IsNot Nothing Then
            For Each unshippedJob In unshippedJobs
                If Contains(unshippedJob.jobNumber, findJobNumber(unshippedJobsListBox.SelectedItem)) Then
                    Dim contents() As String = Split(unshippedJob.item.Body, vbCrLf)
                    Dim index As Integer
                    jobNumberTextBox.Text = unshippedJob.jobNumber
                    siteTextBox.Text = unshippedJob.site
                    foodstuffsJobCheckBox.Checked = unshippedJob.fs

                    For index = 0 To contents.Length - 1
                        If Contains(contents(index), "IN: ") Then
                            serialInTextBox.Text = contents(index).Substring(contents(index).IndexOf("IN: ") + 5)
                        ElseIf Contains(contents(index), "OUT: ") Then
                            serialOutTextBox.Text = contents(index).Substring(contents(index).IndexOf("OUT: ") + 6)
                            faultTextBox.Text = contents(index + 2)
                        End If
                    Next
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub ShipButton_Click(sender As Object, e As EventArgs) Handles ShipButton.Click
        Dim shipped As Boolean
        For Each inboxItem In inboxItemsList
            Dim inboxItemJobNumber = findJobNumber(inboxItem.Subject)
            If Not String.IsNullOrEmpty(inboxItemJobNumber) And Not IsNothing(unshippedJob) Then
                If Contains(inboxItemJobNumber, unshippedJob.jobNumber) And Contains(inboxItem.Subject, "SHIP DOC") Then
                    inboxItem.Attachments.Item(1).SaveAsFile(IO.Path.Combine(IO.Directory.GetParent(Application.ExecutablePath).FullName, "shipDoc.pdf"))
                    If foodstuffsJobCheckBox.Checked Then
                        Process.Start("cmd", "/C java -jar fillForm.jar " + Chr(34) + "True|" + jobNumberTextBox.Text + "|" + serialInTextBox.Text + "|" + serialOutTextBox.Text + "|" + siteTextBox.Text + "|" + faultTextBox.Text + Chr(34))
                        Process.Start("cmd", "/C SumatraPDF.exe -print-to-default fsDoc-Filled.pdf")
                    Else
                        Process.Start("cmd", "/C java -jar fillForm.jar " + Chr(34) + "False|" + serialOutTextBox.Text + "|" + faultTextBox.Text + Chr(34))
                    End If
                    Process.Start("cmd", "/C SumatraPDF.exe -print-to-default shipDoc-Filled.pdf")
                    shipped = True
                    Exit For
                End If
            End If
        Next

        If Not shipped Then MsgBox("Error: No job selected or shipping document found for job.")

        ' Deletes files after printing
        'If My.Computer.FileSystem.FileExists("shipDoc.pdf") Then My.Computer.FileSystem.DeleteFile("shipDoc.pdf")
        'If My.Computer.FileSystem.FileExists("shipDoc-Filled.pdf") Then My.Computer.FileSystem.DeleteFile("shipDoc-Filled.pdf")
        'If My.Computer.FileSystem.FileExists("fsDoc-Filled.pdf") Then My.Computer.FileSystem.DeleteFile("fsDoc-Filled.pdf")

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
        If String.IsNullOrEmpty(updateFolder) Then
            inboxFolder = olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox)
        Else
            Try
                inboxFolder = olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox).Folders(updateFolder)
            Catch
                MsgBox("Error: Invalid update folder in config file.")
                Environment.Exit(0)
            End Try
        End If

        sentFolder = olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail)
        calendarFolder = olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar)

        ' Restrict to last three weeks.
        inboxItemsList = inboxFolder.Items.Restrict("[ReceivedTime] >= '" + Format(DateAdd("d", -21, Now), "Short Date") + "'")
        sentItemsList = sentFolder.Items.Restrict("[ReceivedTime] >= '" + Format(DateAdd("d", -21, Now), "Short Date") + "'")
        calendarItemsList = calendarFolder.Items.Restrict("[Start] >= '" + Format(DateAdd("d", -21, Now), "Short Date") + "'")


        ' Sort by oldest items first. This is to try and find the original update/appointment before finding replies/further appointments
        inboxItemsList.Sort("[ReceivedTime]", True)
        sentItemsList.Sort("[ReceivedTime]")
        calendarItemsList.Sort("[Start]")

    End Sub

    ' Function that returns the job number of an update.
    Public Function findJobNumber(jobName As String)
        Dim jobNumberMatch = jobNumberRegex.Match(jobName.ToUpper)
        If jobNumberMatch.Success Then Return jobName.Substring(jobNumberMatch.Index, 12).ToUpper
        Return vbNullString
    End Function

    Public Function loadConfig()
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("config.csv")
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(";")

            Dim currentRow As String()

            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    If currentRow(0) = "folder" And Not String.IsNullOrEmpty(currentRow(1)) Then
                        updateFolder = currentRow(1)
                    End If
                Catch ex As Microsoft.VisualBasic.
                            FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message &
                    "is not valid and will be skipped.")
                End Try
            End While
        End Using
        loadConfig = ""
    End Function

    'Case insensative string comparison added to base type String
    Public Overloads Function Contains(source As String, toCheck As String)
        Return source.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) <> -1
    End Function
End Class



