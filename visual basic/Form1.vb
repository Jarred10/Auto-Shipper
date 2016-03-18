Imports System.Text.RegularExpressions
Imports Microsoft.Office.Interop

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
    Dim myUnshippedItem As Object
    Dim calendarItem As Object
    Dim shipItem As Item

    Dim unshippedItems As New List(Of Item)

    Dim jobNumberRegex = New Regex("SV\d{10}")

    'Config
    Dim updateFolder As String

    ' Get a date object for three weeks ago.
    Dim dt As Date = Date.Now.AddDays(-21)

    Private Sub finderButton_Click(sender As Object, e As EventArgs) Handles finderButton.Click

        ' Loops through all sent mail in last three weeks.
        For Each sentItem In sentItemsList
            Dim itemSubject = sentItem.Subject.ToUpper
            Dim itemJobNumber = findJobNumber(itemSubject)
            Dim itemBody = sentItem.Body.ToUpper
            ' Checks if subject of sent mail contains SV. Filters to all updates about jobs
            If Not String.IsNullOrEmpty(itemJobNumber) Then
                ' Checks if update was for a job that used parts, and not for 
                If itemBody.Contains("OUT: ") Then
                    Dim x As Integer
                    Dim found As Boolean = False
                    'Checks for duplicate jobs, ie. if there is communication about a job and original update is in the email chain.
                    For x = 0 To unshippedItems.Count - 1
                        If itemJobNumber.Contains(unshippedItems.ElementAt(x).jobNumber) Then
                            found = True
                            Exit For
                        End If
                    Next
                    If Not found Then
                        ' Adds mail item to a list of updates with parts.
                        unshippedItems.Add(New Item(sentItem, itemJobNumber))
                    End If
                    ' If update wasnt for job that used parts, checks if update was for shipping parts
                ElseIf itemSubject.Contains("SHIPPING") Or itemBody.Contains("SHIPPING") Then
                    ' Removes shipped updates from list of unshipped updates
                    For Each myUnshippedItem In unshippedItems
                        If itemJobNumber.Contains(myUnshippedItem.jobNumber) Then
                            unshippedItems.Remove(myUnshippedItem)
                            Exit For
                        End If
                    Next
                End If
            End If
        Next

        'Loops through all recent calendar items, looking for unshipped updates.
        For Each calendarItem In calendarItemsList
            Dim calendarItemJobNumber = findJobNumber(calendarItem.Subject)
            If Not String.IsNullOrEmpty(calendarItemJobNumber) Then
                For Each sentItem In unshippedItems
                    If calendarItemJobNumber.Contains(sentItem.jobNumber) Then
                        unshippedJobsListBox.Items.Add(calendarItem.Subject)
                        Dim siteMatch = New Regex("SITE ::").Match(calendarItem.Body.ToUpper)
                        Dim contactMatch = New Regex("CONTACT ::").Match(calendarItem.Body.ToUpper)
                        If siteMatch.Success And contactMatch.Success Then
                            sentItem.site = calendarItem.Body.Substring(siteMatch.Index + 8, contactMatch.Index)
                            sentItem.fs = True
                        Else
                            sentItem.fs = False
                        End If
                    End If
                Next
            End If

        Next



    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles unshippedJobsListBox.SelectedIndexChanged
        If unshippedJobsListBox.SelectedItem IsNot Nothing Then
            For Each shipItem In unshippedItems
                If shipItem.jobNumber.Contains(findJobNumber(unshippedJobsListBox.SelectedItem)) Then
                    Dim contents() As String = Split(shipItem.item.Body, vbCrLf)

                    jobNumberTextBox.Text = shipItem.jobNumber
                    siteTextBox.Text = shipItem.site
                    serialInTextBox.Text = contents(4).Substring(contents(4).IndexOf("IN: ") + 5)
                    serialOutTextBox.Text = contents(5).Substring(contents(5).IndexOf("OUT: ") + 6)
                    faultTextBox.Text = contents(7)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub ShipButton_Click(sender As Object, e As EventArgs) Handles ShipButton.Click
        For Each inboxItem In inboxItemsList
            Dim inboxItemJobNumber = findJobNumber(inboxItem.Subject)
            If Not String.IsNullOrEmpty(inboxItemJobNumber) Then
                If inboxItemJobNumber.Contains(shipItem.jobNumber) And inboxItem.Subject.ToUpper.Contains("SHIP DOC") Then
                    inboxItem.Attachments.Item(1).SaveAsFile(IO.Path.Combine(IO.Directory.GetParent(Application.ExecutablePath).FullName, "shipDoc.pdf"))
                    If shipItem.fs Then
                        Process.Start("cmd", "/c java -jar testProgram.jar " + shipItem.fs.ToString + "|" + jobNumberTextBox.Text + "|" + serialInTextBox.Text + "|" + serialOutTextBox.Text + "|" + siteTextBox.Text + "|" + faultTextBox.Text)
                        Process.Start("cmd", "/c SumatraPDF.exe -silent -print-to-default fsDoc-Filled.pdf")
                    Else
                        Process.Start("cmd", "/c java -jar testProgram.jar " + Chr(34) + shipItem.fs.ToString + "|" + serialOutTextBox.Text + "|" + faultTextBox.Text + Chr(34))
                    End If
                    Process.Start("cmd", "/c SumatraPDF.exe -silent -print-to-default shipDoc-Filled.pdf")
                    Exit For
                End If
            End If
        Next

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
        Dim dateRestrict = dt.ToString("MM/dd/yyyy HH:mm")
        inboxItemsList = inboxFolder.Items.Restrict("[ReceivedTime] >= '" + dateRestrict + "'")
        sentItemsList = sentFolder.Items.Restrict("[ReceivedTime] >= '" + dateRestrict + "'")
        calendarItemsList = calendarFolder.Items.Restrict("[Start] >= '" + dateRestrict + "'")


        ' Sort by oldest items first. This is to try and find the original update/appointment before finding replies/further appointments
        inboxItemsList.Sort("[ReceivedTime]")
        sentItemsList.Sort("[ReceivedTime]")
        calendarItemsList.Sort("[Start]")

    End Sub

    ' Function that returns the job number of an update.
    Public Function findJobNumber(jobName As String) As String
        Dim jobNumberMatch = jobNumberRegex.Match(jobName.ToUpper)

        If jobNumberMatch.Success Then
            Return jobName.Substring(jobNumberMatch.Index, 12).ToUpper
        Else
            Return vbNullString
        End If
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
    End Function
End Class
