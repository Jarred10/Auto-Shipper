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
    Dim calendarItem As Object
    Dim shipItem As Object

    Dim unshippedItems As New List(Of Object)
    Dim shippedItems As New List(Of Object)

    ' Get a date object for three weeks ago. '
    Dim dt As Date = Date.Now.AddDays(-21)

    Private Sub finderButton_Click(sender As Object, e As EventArgs) Handles finderButton.Click


        ' Sort by oldest item first. 
        sentItemsList.Sort("[ReceivedTime]")
        calendarItemsList.Sort("[Start]")

        ' Loops through all updates in last three weeks.
        For Each myItem In sentItemsList
            ' Checks if subject of update contains SV. All updates will contain this.
            If myItem.Subject.ToString.ToUpper.Contains("SV") Then
                ' Checks if contents of update contain outgoing parts.
                If myItem.Body.ToString.ToUpper.Contains("OUT:") Then
                    Dim x As Integer
                    Dim found As Boolean = False
                    'Checks for duplicate jobs, ie. if there is communication about a job and original update is in the email chain.
                    For x = 1 To unshippedItems.Count
                        If findSV(myItem.Subject.ToString).Contains(findSV(unshippedItems.ElementAt(x - 1).Subject.ToString)) Then
                            found = True
                            Exit For
                        End If
                    Next
                    If Not found Then
                        ' Adds mail item to a list of updates with parts.
                        unshippedItems.Add(myItem)
                    End If
                    ' If not an update with outgoing parts, check if the job has already had its parts shipped by looking at the subject or body.
                ElseIf myItem.Body.ToString.ToUpper.Contains("SHIPPING") Or myItem.Subject.ToString.ToUpper.Contains("SHIPPING") Then
                    shippedItems.Add(myItem)
                End If
            End If
        Next

        ' Loops through all updates with shipped parts, and removed them from unshipped parts.
        For Each myItem In shippedItems
            For Each partItem In unshippedItems
                If findSV(partItem.Subject.ToString).Contains(findSV(myItem.Subject.ToString)) Then
                    unshippedItems.Remove(partItem)
                    Exit For
                End If
            Next
        Next

        'Loops through all recent calendar items, looking for unshipped updates.
        For Each calendarItem In calendarItemsList
            If calendarItem.Subject.ToString.ToUpper.Contains("SV") Then
                For Each myItem In unshippedItems
                    If findSV(calendarItem.Subject.ToString).Contains(findSV(myItem.Subject.ToString)) Then
                        ListBox1.Items.Add(calendarItem.Subject.ToString)
                    End If
                Next
            End If

        Next



    End Sub

    ' Function that returns the SV number of an update.
    Public Function findSV(Name As String) As String
        Try
            Return Name.Substring(Name.ToUpper.IndexOf("SV"), 12).ToUpper
        Catch
            Return ""
        End Try
    End Function

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        For Each myItem In unshippedItems
            Dim SV = findSV(myItem.Subject.ToString)
            If SV.Contains(findSV(ListBox1.SelectedItem.ToString)) Then
                Dim contents() As String = myItem.Body.ToString.ToUpper.Split(Chr(10))

                TextBox1.Text = SV
                TextBox2.Text = contents(4)
                TextBox3.Text = contents(5)
                TextBox4.Text = contents(7)

                shipItem = myItem
                Exit For
            End If
        Next
    End Sub


    'Initialise all the needed outlook items when form is loaded.
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Start Outlook.
        ' If it is already running, you'll use the same instance.
        olApp = CreateObject("Outlook.Application")

        ' Logon. Doesn't hurt if you are already running and logged on.
        olNs = olApp.GetNamespace("MAPI")
        olNs.Logon()

        ' Grab the inbox, sent items folder and calendar.
        inboxFolder = olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox).Folders("Shipping Docs")
        sentFolder = olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail)
        calendarFolder = olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar)

        ' Get the list of all emails and calendar appointments. Restrict to last three weeks.
        inboxItemsList = inboxFolder.Items.Restrict("[ReceivedTime] >= '" + dt.ToString("MM/dd/yyyy HH:mm") + "'")
        sentItemsList = sentFolder.Items.Restrict("[ReceivedTime] >= '" + dt.ToString("MM/dd/yyyy HH:mm") + "'")
        calendarItemsList = calendarFolder.Items.Restrict("[Start] >= '" + dt.ToString("MM/dd/yyyy HH:mm") + "'")


    End Sub

    Private Sub ShipButton_Click(sender As Object, e As EventArgs) Handles ShipButton.Click
        For Each myItem In inboxItemsList
            If myItem.Subject.ToString.ToUpper.Contains("SV") Then
                If findSV(myItem.Subject.ToString).Contains(findSV(shipItem.Subject.ToString)) And myItem.Subject.ToString.ToUpper.Contains("SHIP DOC") Then
                    Dim fileName = myItem.Attachments.Item(1).FileName
                    myItem.Attachments.Item(1).SaveAsFile("C:\Users\Jarred\Documents\Visual Studio 2015\Projects\Auto Shipper\java\test.PDF")
                    System.Diagnostics.Process.Start("C:\Users\Jarred\Documents\Visual Studio 2015\Projects\Auto Shipper\java\runJava.bat")
                End If
            End If
        Next
    End Sub
End Class
