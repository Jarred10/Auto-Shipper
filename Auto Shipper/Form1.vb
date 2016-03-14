Imports Microsoft.Office
Imports Microsoft.Office.Interop

Public Class Form1

    Private Sub finderButton_Click(sender As Object, e As EventArgs) Handles finderButton.Click
        ' Start Outlook.
        ' If it is already running, you'll use the same instance...
        Dim olApp As Outlook.Application
        olApp = CreateObject("Outlook.Application")

        ' Logon. Doesn't hurt if you are already running and logged on...
        Dim olNs As Outlook.NameSpace
        olNs = olApp.GetNamespace("MAPI")
        olNs.Logon()

        ' Grab the sent items folder. '
        Dim myInbox As Outlook.MAPIFolder = olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail)
        Dim oCalendar As Outlook.MAPIFolder = olNs.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar)

        ' Set some variables. '
        Dim myItems As Outlook.Items = myInbox.Items
        Dim myItem As Object
        Dim myCalendarItems As Outlook.Items = oCalendar.Items
        Dim calendarItem As Object

        Dim partsItems As New List(Of Object)
        Dim sentItems As New List(Of Object)

        ' Get a date object for two weeks ago. '
        Dim dt As Date = Date.Now.AddDays(-14)

        ' Limit items to last two weeks. '
        myItems = myItems.Restrict("[ReceivedTime] >= '" + dt.ToString("MM/dd/yyyy HH:mm") + "'")
        myCalendarItems = myCalendarItems.Restrict("[Start] >= '" + dt.ToString("MM/dd/yyyy HH:mm") + "'")


        ' Sort by oldest item first. '
        myItems.Sort("[ReceivedTime]")
        myCalendarItems.Sort("[Start]")

        For Each calendarItem In myCalendarItems
            Debug.WriteLine(calendarItem.Subject)
        Next
        ' Loops through all updates in last 2 weeks. '
        For Each myItem In myItems
            ' Checks if subject of update contains SV. All updates will contain this. '
            If myItem.Subject.ToString.ToUpper.Contains("SV") Then
                ' Checks if contents of update contain outgoing parts. '
                If myItem.Body.ToString.ToUpper.Contains("OUT:") Then
                    Dim x As Integer
                    Dim found As Boolean = False
                    'Checks for duplicate jobs, ie. if there is communication about a job and original update is in the email chain. '
                    For x = 1 To partsItems.Count
                        If findSV(myItem).Contains(findSV(partsItems.ElementAt(x - 1))) Then
                            found = True
                        End If
                    Next
                    If Not found Then
                        ' Adds mail item to a list of updates with parts. '
                        partsItems.Add(myItem)
                        ' TODO: remove debug statement. '
                        Debug.Print("Found job update " + myItem.Subject + ". Received Date: " + myItem.ReceivedTime)
                    End If
                    ' If not an update with outgoing parts, check if the job has already had its parts shipped by looking at the subject or body '
                ElseIf myItem.Body.ToString.ToUpper.Contains("SHIPPING") Or myItem.Subject.ToString.ToUpper.Contains("SHIPPING") Then
                    sentItems.Add(myItem)
                    Debug.Print("Found shipped job " + myItem.Subject + ". Received Date: " + myItem.ReceivedTime)
                End If
            End If
        Next

        ' Loops through all updates with shipped parts. '
        For Each myItem In sentItems
            For Each partItem In partsItems
                If findSV(partItem).Contains(findSV(myItem)) Then
                    partsItems.Remove(partItem)
                    Debug.Print("Removed shipped job " + partItem.Subject)
                    Exit For
                End If
            Next
        Next

        For Each calendarItem In myCalendarItems
            If calendarItem.Subject.ToString.ToUpper.Contains("SV") Then
                For Each myItem In partsItems
                    If findSV(calendarItem).Contains(findSV(myItem)) Then
                        ListBox1.Items.Add(calendarItem.Subject.ToString)
                    End If
                Next
            End If

        Next



    End Sub

    ' Function that returns the SV number of an update '
    Public Function findSV(Update As Object) As String
        Dim subject As String = Update.Subject.ToString.ToUpper
        Dim jobNumberIndex = subject.IndexOf("SV")
        Return subject.Substring(jobNumberIndex, 12)
    End Function

End Class
