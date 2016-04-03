Imports System.Text.RegularExpressions
Imports Microsoft.Office.Interop
Imports System.Runtime.CompilerServices
Imports Auto_Shipper

Public Class Form1

    Dim olApp As Outlook.Application
    Dim olNs As Outlook.NameSpace
    Dim shipDocFolder As Outlook.MAPIFolder

    Dim sentItemsSearch As Outlook.Search
    Dim calendarSearch As Outlook.Search

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

    'When user selects a job from the list, populate the text boxes with relevant information so they can edit or choose what to be added to form.
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles unshippedJobsListBox.SelectedIndexChanged
        If unshippedJobsListBox.SelectedItem IsNot Nothing Then
            For Each unshippedJob In unshippedJobs
                If unshippedJob.jobNumber.Contains(findJobNumber(unshippedJobsListBox.SelectedItem), StringComparison.OrdinalIgnoreCase) Then
                    Dim contents() As String = Split(unshippedJob.item.Body, vbCrLf)
                    jobNumberTextBox.Text = unshippedJob.jobNumber
                    siteTextBox.Text = unshippedJob.site
                    jobTypeTextBox.Text = unshippedJob.jobType.ToString

                    For i = 0 To contents.Length - 1
                        With contents(i)
                            If .Contains("in: ", StringComparison.OrdinalIgnoreCase) Then
                                serialInTextBox.Text = .Substring(.IndexOf("IN: ") + 5)
                            ElseIf .Contains("out: ", StringComparison.OrdinalIgnoreCase) Then
                                serialOutTextBox.Text = .Substring(.IndexOf("OUT: ") + 6)
                                faultTextBox.Text = contents(i + 2)
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

        'Finds and downloads shipping document for selected job, if it exists.
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


        'Creates object to store data on job, which java will read to fill form.

        Dim objWriter As New System.IO.StreamWriter("data.txt")
        objWriter.WriteLine(unshippedJob.jobType.ToString)
        objWriter.WriteLine(unshippedJob.jobNumber)
        objWriter.WriteLine(serialInTextBox.Text)
        objWriter.WriteLine(serialOutTextBox.Text)
        objWriter.WriteLine(unshippedJob.site)
        objWriter.WriteLine(faultTextBox.Text)
        objWriter.Flush()
        objWriter.Close()


        Process.Start("cmd", "/C java -jar fillForm.jar")
    End Sub


    Private Sub printButton_Click(sender As Object, e As EventArgs) Handles printButton.Click
        If unshippedJob.jobType = jobTypes.Foodstuffs Then Process.Start("cmd", "/C SumatraPDF.exe -print-to-default fsDoc-Filled.pdf")
        If unshippedJob.jobType = jobTypes.Lotto Then Process.Start("cmd", "/C SumatraPDF.exe -print-to-default lottoDoc-Filled.pdf")
        Process.Start("cmd", "/C SumatraPDF.exe -print-to-default shipDoc-Filled.pdf")

        ' Deletes files after printing if set in config
        If deleteOnPrint Then
            With My.Computer.FileSystem
                If .FileExists("shipDoc.pdf") Then .DeleteFile("shipDoc.pdf")
                If .FileExists("shipDoc-Filled.pdf") Then .DeleteFile("shipDoc-Filled.pdf")
                If .FileExists("fsDoc-Filled.pdf") Then .DeleteFile("fsDoc-Filled.pdf")
                If .FileExists("lottoDoc-Filled.docx") Then .DeleteFile("lottoDoc-Filled.docx")
            End With
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

        ' Restrict to last three weeks.
        sentItemsSearch = olApp.AdvancedSearch("'" + olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail).FolderPath _
            + "'", "urn:schemas:httpmail:subject LIKE '%SV%' AND urn:schemas:httpmail:datereceived >= '" + Format(DateAdd("d", -21, Now), "Short Date") + "'", False)
        calendarSearch = olApp.AdvancedSearch("'" + olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).FolderPath _
            + "'", "urn:schemas:httpmail:subject LIKE '%SV%' AND urn:schemas:calendar:dtstart >= '" + Format(DateAdd("d", -21, Now), "Short Date") + "'", False)


        ' Sort by oldest items first. This is to try and find the original update/appointment before finding replies/further appointments
        sentItemsSearch.Results.Sort("[ReceivedTime]")
        calendarSearch.Results.Sort("[Start]")


        ' Loops through all sent mail in last three weeks that contain "SV"
        For Each sentItem In sentItemsSearch.Results
            Dim sentItemJobNo As String = findJobNumber(sentItem.Subject)
            If sentItemJobNo = "SV1603240021" Then
                Dim b = True
            End If
            ' Checks if update was for a job that used parts, and not for 
            If sentItem.Body.ToString.Contains("out: ", StringComparison.OrdinalIgnoreCase) Then
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
        Next

    End Sub

    ' Function that returns the job number of an update if the argument contains it.
    Public Function findJobNumber(jobName As String)
        Dim jobNumberMatch = jobNumberRegex.Match(jobName.ToUpper)
        If jobNumberMatch.Success Then Return jobName.Substring(jobNumberMatch.Index, 12).ToUpper
        Return vbNullString
    End Function

    ' Reads CSV file to set the folder where shipping docs are found
    Public Function loadConfig()
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("config.txt")
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(":")

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
