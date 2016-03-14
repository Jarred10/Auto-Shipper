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

        Dim myItems As Outlook.Items = myInbox.Items
        Dim myItem As Object
        Dim Found As Boolean = False

        For Each myItem In myItems
            If InStr(1, myItem.Subject, "SV") > 0 Then
                If InStr(1, myItem.Body, "Out: ") > 0 Then
                    Debug.Print("Found job " + myItem.Subject)
                End If
            End If
        Next

    End Sub
End Class
