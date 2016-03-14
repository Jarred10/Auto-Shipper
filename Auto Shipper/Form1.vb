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

        ' Set some variables. '
        Dim myItems As Outlook.Items = myInbox.Items
        Dim myItem As Object
        Dim Found As Boolean = False

        ' Get a date object for two weeks ago. '
        Dim dt As Date = Date.Now.AddDays(-14)

        ' Limit items to last two weeks. '
        myItems = myItems.Restrict("[ReceivedTime] >= '" + dt.ToString("MM/dd/yyyy HH:mm") + "'")

        ' Sort by oldest item first. '
        myItems.Sort("[ReceivedTime]")


        For Each myItem In myItems
            If InStr(1, myItem.Subject, "SV") > 0 Then
                If InStr(1, myItem.Body, "Out: ") > 0 Then
                    Debug.Print("Found job " + myItem.Subject + ". Received date: " + myItem.ReceivedTime)
                End If
            End If
        Next

    End Sub
End Class
