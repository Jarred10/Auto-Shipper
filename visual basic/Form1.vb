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
    Dim myUnshippedItem As Object
    Dim calendarItem As Object
    Dim shipItem As Item

    Dim unshippedItems As New List(Of Item)

    'Regular expression to find SV numbers
    Dim jobNumberRegex = New Regex("SV\d{10}")

    'Config
    Dim updateFolder As String

    Private Sub finderButton_Click(sender As Object, e As EventArgs) Handles finderButton.Click

        ' Loops through all sent mail in last three weeks.
        For Each sentItem In sentItemsList
            Dim itemJobNumber = findJobNumber(sentItem.Subject)
            ' Checks if subject of sent mail contains SV. Filters to all updates about jobs
            If Not String.IsNullOrEmpty(itemJobNumber) Then
                ' Checks if update was for a job that used parts, and not for 
                If Contains(sentItem.Body, "out: ") Then
                    Dim x As Integer
                    Dim found As Boolean = False
                    'Checks for duplicate jobs, ie. if there is communication about a job and original update is in the email chain.
                    For x = 0 To unshippedItems.Count - 1
                        If Contains(itemJobNumber, unshippedItems.ElementAt(x).jobNumber) Then
                            found = True
                            Exit For
                        End If
                    Next
                    If Not found Then
                        ' Adds mail item to a list of updates with parts.
                        unshippedItems.Add(New Item(sentItem, itemJobNumber))
                    End If
                    ' If update wasnt for job that used parts, checks if update was for shipping parts
                ElseIf Contains(sentItem.Subject, "shipping") Or Contains(sentItem.Body, "shipping") Then
                    ' Removes shipped updates from list of unshipped updates
                    For Each myUnshippedItem In unshippedItems
                        If Contains(itemJobNumber, myUnshippedItem.jobNumber) Then
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
                    If Contains(calendarItemJobNumber, sentItem.jobNumber) Then
                        unshippedJobsListBox.Items.Add(calendarItem.Subject)
                        Dim siteIndex = calendarItem.Body.IndexOf("site ::", StringComparison.OrdinalIgnoreCase)
                        Dim contactIndex = calendarItem.Body.IndexOf("contact name ::", StringComparison.OrdinalIgnoreCase)
                        If siteIndex <> -1 And contactIndex <> -1 Then
                            sentItem.site = Trim(calendarItem.Body.Substring(siteIndex + 8, contactIndex - (siteIndex + 10)))
                            sentItem.fs = True
                        End If
                    End If
                Next
            End If

        Next



    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles unshippedJobsListBox.SelectedIndexChanged
        If unshippedJobsListBox.SelectedItem IsNot Nothing Then
            For Each shipItem In unshippedItems
                If Contains(shipItem.jobNumber, findJobNumber(unshippedJobsListBox.SelectedItem)) Then
                    Dim contents() As String = Split(shipItem.item.Body, vbCrLf)
                    Dim index = 0
                    jobNumberTextBox.Text = shipItem.jobNumber
                    siteTextBox.Text = shipItem.site

                    While index < contents.Length
                        If Contains(contents(index), "IN: ") Then
                            serialInTextBox.Text = contents(index).Substring(contents(index).IndexOf("IN: ") + 5)
                        ElseIf Contains(contents(index), "OUT: ") Then
                            serialOutTextBox.Text = contents(index).Substring(contents(index).IndexOf("OUT: ") + 6)
                            faultTextBox.Text = contents(index + 2)
                        End If
                        index += 1
                    End While
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub ShipButton_Click(sender As Object, e As EventArgs) Handles ShipButton.Click
        Dim shipped As Boolean
        For Each inboxItem In inboxItemsList
            Dim inboxItemJobNumber = findJobNumber(inboxItem.Subject)
            If Not String.IsNullOrEmpty(inboxItemJobNumber) Then
                If Contains(inboxItemJobNumber, shipItem.jobNumber) And Contains(inboxItem.Subject, "SHIP DOC") Then
                    inboxItem.Attachments.Item(1).SaveAsFile(IO.Path.Combine(IO.Directory.GetParent(Application.ExecutablePath).FullName, "shipDoc.pdf"))
                    If shipItem.fs Then
                        Process.Start("cmd", "/c java -jar testProgram.jar " + Chr(34) + shipItem.fs.ToString + "|" + jobNumberTextBox.Text + "|" + serialInTextBox.Text + "|" + serialOutTextBox.Text + "|" + siteTextBox.Text + "|" + faultTextBox.Text + Chr(34))
                        Process.Start("cmd", "/c SumatraPDF.exe -silent -print-to-default fsDoc-Filled.pdf")
                    Else
                        Process.Start("cmd", "/c java -jar testProgram.jar " + Chr(34) + shipItem.fs.ToString + "|" + serialOutTextBox.Text + "|" + faultTextBox.Text + Chr(34))
                    End If
                    Process.Start("cmd", "/c SumatraPDF.exe -silent -print-to-default shipDoc-Filled.pdf")
                    shipped = True
                    Exit For
                End If
            End If
        Next

        If Not shipped Then MsgBox("Error: No shipping document found for job.")

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



