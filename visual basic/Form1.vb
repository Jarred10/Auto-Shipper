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
    Dim ingoingPartsKeyword As String
    Dim outgoingPartsKeyword As String


    Private Sub jobButton_Click(sender As Object, e As EventArgs) Handles jobButton.Click

        ' Loops through all sent mail in last three weeks that contain "SV"
        For Each sentItem In sentItemsSearch.Results
            Dim sentItemJobNo As String = findJobNumber(sentItem.Subject)
            ' Checks if update was for a job that used parts, and not for 
            If sentItem.Body.ToString.Contains("out: ", StringComparison.OrdinalIgnoreCase) Then
                If Not unshippedJobs.Contains(New Item(sentItem, sentItemJobNo)) Then
                    ' Adds mail item to a list of unshipped jobs.
                    unshippedJobs.Add(New Item(sentItem, sentItemJobNo))
                End If
                ' If update wasnt for job that used parts, checks if update was for shipping parts
            ElseIf sentItem.Subject.ToString.Contains("shippingg", StringComparison.OrdinalIgnoreCase) Or sentItem.Body.ToString.Contains("shippingg", StringComparison.OrdinalIgnoreCase) Then
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
                            If .Contains("in: ", StringComparison.OrdinalIgnoreCase) Then
                                serialInTextBox.Text = .Substring(.IndexOf("IN: ") + 5)
                            ElseIf .Contains("out: ", StringComparison.OrdinalIgnoreCase) Then
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
            outlookSearch = olApp.AdvancedSearch("'" + shipDocFolder.FolderPath + "'", "urn:schemas:httpmail:subject LIKE '%" + unshippedJob.jobNumber + "%'")

            'If the results of the search turn up nothing, throw error
            If outlookSearch.Results.Count = 0 Then
                MsgBox("No shipping document email found for selected job in folder: " + shipDocFolderName + ".")
            Else
                'Loop through all results
                For i = 1 To outlookSearch.Results.Count
                    shipDocItem = outlookSearch.Results.Item(i)
                    'Checks if email has any attachments, and either the subject or body of email contain ship doc in some form
                    If shipDocItem.Attachments.Count > 0 AndAlso (LCase(shipDocItem.Subject) Like "*ship*doc*" Or LCase(shipDocItem.Body) Like "*ship*doc*") Then
                        Console.WriteLine(shipDocItem.Attachments(1).DisplayName)
                        'Loops through all attachments, in most cases this will be only one file
                        For a = 1 To shipDocItem.Attachments.Count
                            'Checks if the name of attachment indicates that it is a shipping document
                            If UCase(shipDocItem.Attachments(a).DisplayName) Like "_DT*.PDF" Then
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

        ' Restrict to last three weeks.
        sentItemsSearch = olApp.AdvancedSearch("'" + olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail).FolderPath _
            + "'", "urn:schemas:httpmail:subject LIKE '%SV%' AND urn:schemas:httpmail:datereceived >= '" + Format(DateAdd("d", -21, Now), "Short Date") + "'", False)
        calendarSearch = olApp.AdvancedSearch("'" + olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar).FolderPath _
            + "'", "urn:schemas:httpmail:subject LIKE '%SV%' AND urn:schemas:calendar:dtstart >= '" + Format(DateAdd("d", -21, Now), "Short Date") + "'", False)


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

    ' Reads CSV file to set the folder where shipping docs are found
    Public Function loadConfig()

        Dim FILE_NAME As String = "config.txt"
        Dim LINES As Integer = 5

        Dim lineArray() As String
        Dim key As String
        Dim value As String

        If System.IO.File.Exists(FILE_NAME) Then

            Dim objReader As New System.IO.StreamReader(FILE_NAME)

            For i = 0 To LINES - 1
                lineArray = objReader.ReadLine().Split("="c)
                If (lineArray.Count < 2) Then
                    MsgBox("Corrupt configuration file at line: " + i + ".")
                    Environment.Exit(0)
                End If
                key = lineArray(0)
                value = lineArray(1)
                Select Case i
                    Case 0
                    Case 1
                        If key = "folder" Then
                            Dim objFolder = olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox)
                            Dim folderExists As Boolean

                            If String.IsNullOrEmpty(value) Or LCase(value) = "inbox" Then
                                Try
                                    shipDocFolder = objFolder
                                    shipDocFolderName = "Inbox"
                                Catch
                                    MsgBox("Unable to find inbox in outlook.")
                                    Environment.Exit(0)
                                End Try
                            Else
                                For x = 1 To objFolder.Folders.Count
                                    If objFolder.Folders.Item(x).Name = value Then
                                        shipDocFolder = objFolder.Folders(x)
                                        folderExists = True
                                        Exit For
                                    End If
                                Next
                                If Not folderExists Then
                                    objFolder = objFolder.Parent.Folder
                                    For x = 1 To objFolder.Folders.Count
                                        If objFolder.Folders.Item(x).Name = value Then
                                            shipDocFolder = objFolder.Folders(x)
                                            folderExists = True
                                            Exit For
                                        End If
                                    Next
                                End If
                                If Not folderExists Then
                                    MsgBox("Unable to find " + value + " in your outlook folders.")
                                    Environment.Exit(0)
                                End If
                            End If
                        Else
                            MsgBox("Unexpected value at line " + i + " in config file. Expected: folder. Actual: " + key + ".")
                            Environment.Exit(0)
                        End If
                    Case 2
                    Case 3
                    Case 4
                    Case 5
                End Select
            Next
        Else
            If MsgBoxResult.Yes = MsgBox("Unable to find configuartion file with name: " + FILE_NAME + ". Would you like to create one?", MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1 Or MsgBoxStyle.Critical) Then
                If Not createConfig(FILE_NAME) Then
                    MsgBox("Configuration not created correctly.")
                    Environment.Exit(0)
                End If
            Else
                Environment.Exit(0)
            End If
        End If
        loadConfig = ""
    End Function

    Public Function createConfig(FILE_NAME As String) As Boolean
        Dim SecondForm As New configCreate
        SecondForm.ShowDialog()
        Return System.IO.File.Exists(FILE_NAME)
    End Function
End Class
