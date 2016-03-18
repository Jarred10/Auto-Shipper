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

    Dim myItem As Object
    Dim myUnshippedItem As Object
    Dim calendarItem As Object
    Dim shipItem As Object

    Dim unshippedItems As New List(Of Object)
    Dim sites As New List(Of String)

    Dim foodstuffsJob As Boolean

    Dim jobNumberRegex As Regex = New Regex("SV\d{10}")

    Dim updateFolder As String

    ' Get a date object for three weeks ago.
    Dim dt As Date = Date.Now.AddDays(-21)

    Private Sub finderButton_Click(sender As Object, e As EventArgs) Handles finderButton.Click


        ' Loops through all sent mail in last three weeks.
        For Each myItem In sentItemsList
            Dim myItemSubject = myItem.Subject.ToUpper
            Dim myItemJobNumber = findJobNumber(myItemSubject)
            Dim myItemBody = myItem.Body.ToUpper
            ' Checks if subject of sent mail contains SV. Filters to all updates about jobs
            If Not String.IsNullOrEmpty(myItemJobNumber) Then
                ' Checks if update was for a job that used parts, and not for 
                If myItemBody.Contains("OUT: ") Then
                    Dim x As Integer
                    Dim found As Boolean = False
                    'Checks for duplicate jobs, ie. if there is communication about a job and original update is in the email chain.
                    For x = 0 To unshippedItems.Count - 1
                        If myItemJobNumber.Contains(findJobNumber(unshippedItems.ElementAt(x).Subject)) Then
                            found = True
                            Exit For
                        End If
                    Next
                    If Not found Then
                        ' Adds mail item to a list of updates with parts.
                        unshippedItems.Add(myItem)
                    End If
                    ' If update wasnt for job that used parts, checks if update was for shipping parts
                ElseIf myItemSubject.Contains("SHIPPING") Or myItemBody.Contains("SHIPPING") Then
                    ' Removes shipped updates from list of unshipped updates
                    For Each myUnshippedItem In unshippedItems
                        If myItemJobNumber.Contains(findJobNumber(myUnshippedItem.Subject)) Then
                            unshippedItems.Remove(myUnshippedItem)
                            Exit For
                        End If
                    Next
                End If
            End If
        Next

        'Loops through all recent calendar items, looking for unshipped updates.
        For Each calendarItem In calendarItemsList
            If calendarItem.Subject.ToUpper.Contains("SV") Then
                For Each myItem In unshippedItems
                    If findJobNumber(calendarItem.Subject).Contains(findJobNumber(myItem.Subject)) Then
                        unshippedJobsListBox.Items.Add(calendarItem.Subject)
                        Try
                            sites.Add(calendarItem.Body.Substring(calendarItem.Body.ToUpper.IndexOf("SITE ::") + 8, calendarItem.Body.ToUpper.IndexOf("CONTACT NAME::")))
                        Catch
                            sites.Add("No site found. Not foodstuffs job.")
                        End Try
                    End If
                Next
            End If

        Next



    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles unshippedJobsListBox.SelectedIndexChanged
        If unshippedJobsListBox.SelectedItem IsNot Nothing Then
            For Each myItem In unshippedItems
                Dim jobNumber As String = findJobNumber(myItem.Subject)
                If jobNumber.Contains(findJobNumber(unshippedJobsListBox.SelectedItem)) Then
                    Dim body = myItem.Body
                    Dim contents() As String = Split(body, vbCrLf)

                    foodstuffsJob = Not sites(unshippedJobsListBox.SelectedIndex) Like "No site found. Not foodstuffs job."

                    jobNumberTextBox.Text = jobNumber
                    siteTextBox.Text = sites(unshippedJobsListBox.SelectedIndex)
                    serialInTextBox.Text = contents(4).Substring(contents(4).IndexOf("IN: ") + 5)
                    serialOutTextBox.Text = contents(5).Substring(contents(5).IndexOf("OUT: ") + 6)
                    faultTextBox.Text = contents(7)

                    shipItem = myItem
                    Exit For
                End If
            Next
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

    Private Sub ShipButton_Click(sender As Object, e As EventArgs) Handles ShipButton.Click
        For Each myItem In inboxItemsList
            If myItem.Subject.ToUpper.Contains("SV") Then
                If findJobNumber(myItem.Subject).Contains(findJobNumber(shipItem.Subject)) And myItem.Subject.ToUpper.Contains("SHIP DOC") Then
                    myItem.Attachments.Item(1).SaveAsFile(IO.Path.Combine(IO.Directory.GetParent(Application.ExecutablePath).FullName, "shipDoc.pdf"))
                    If foodstuffsJob Then
                        Process.Start("cmd", "/c java -jar testProgram.jar " + foodstuffsJob + "|" + jobNumberTextBox.Text + "|" + serialInTextBox.Text + "|" + serialOutTextBox.Text + "|" + siteTextBox.Text + "|" + faultTextBox.Text)
                        Process.Start("cmd", "/c SumatraPDF.exe -silent -print-to-default fsDoc-Filled.pdf")
                    Else
                        Process.Start("cmd", "/c java -jar testProgram.jar " + Chr(34) + foodstuffsJob.ToString + "|" + serialOutTextBox.Text + "|" + faultTextBox.Text + Chr(34))
                    End If
                    Process.Start("cmd", "/c SumatraPDF.exe -silent -print-to-default shipDoc-Filled.pdf")
                    Exit For
                End If
            End If
        Next

        If My.Computer.FileSystem.FileExists("shipDoc.pdf") Then My.Computer.FileSystem.DeleteFile("shipDoc.pdf")
        If My.Computer.FileSystem.FileExists("shipDoc-Filled.pdf") Then My.Computer.FileSystem.DeleteFile("shipDoc-Filled.pdf")
        If My.Computer.FileSystem.FileExists("fsDoc-Filled.pdf") Then My.Computer.FileSystem.DeleteFile("fsDoc-Filled.pdf")

    End Sub

    ' Function that returns the job number of an update.
    Public Function findJobNumber(jobName As String) As String
        Dim match = jobNumberRegex.Match(jobName)

        If match.Success Then
            Return jobName.Substring(match.Index, 12).ToUpper
        Else
            Return ""
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
