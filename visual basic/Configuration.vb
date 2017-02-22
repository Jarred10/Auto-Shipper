Imports Microsoft.Office.Interop

Public Class Configuration

    Dim folderID As String

    'List of tuples to match textboxes with their labels, for colouring purposes
    Dim tuples As New List(Of Tuple(Of TextBox, PictureBox))

    Private indexOfItemUnderMouseToDrag As Integer
    Private indexOfItemUnderMouseToDrop As Integer

    Private Sub saveSettingsButton_Click(sender As Object, e As EventArgs) Handles saveSettingsButton.Click

        Dim missingField As Boolean

        'checks all text boxes have some text in them
        For Each item In tuples
            If String.IsNullOrEmpty(item.Item1.Text) Then
                item.Item2.Visible = True
                missingField = True
            Else
                item.Item2.Visible = False
            End If
        Next


        'if all fields are completed
        If Not missingField Then
            My.Settings.Name = nameTextBox.Text
            My.Settings.Folder = folderID
            My.Settings.DeleteOnPrint = deleteCheckBox.Checked
            My.Settings.InstalledSerialKeyword = installedSerialTextBox.Text
            My.Settings.InstalledAssetKeyword = installedAssetTextBox.Text
            My.Settings.FaultySerialKeyword = faultySerialTextBox.Text
            My.Settings.FaultyAssetKeyword = faultyAssetTextBox.Text
            My.Settings.ToSiteTimeKeyword = toTextBox.Text
            My.Settings.OnsiteTimeKeyword = onsiteTextBox.Text
            My.Settings.OffsiteTimeKeyword = offsiteTextBox.Text
            My.Settings.AwaySiteTimeKeyword = awayTextBox.Text
            My.Settings.FaultDescriptionKeyword = faultTextBox.Text
            My.Settings.ShippingKeyword = shippingTextBox.Text
            My.Settings.WeeksToCheck = weeksNumericUpDown.Value
            My.Settings.Save()

            DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub textBox_Enter(sender As Object, e As EventArgs) Handles nameTextBox.Leave, folderTextBox.Leave, installedSerialTextBox.Leave, installedAssetTextBox.Leave, toTextBox.Leave, awayTextBox.Leave, shippingTextBox.Leave
        sender.BackColor = SystemColors.Window
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tuples = New List(Of Tuple(Of TextBox, PictureBox)) From
        {
            Tuple.Create(nameTextBox, nameError),
            Tuple.Create(installedSerialTextBox, installedSerialError),
            Tuple.Create(installedAssetTextBox, installedAssetError),
            Tuple.Create(faultySerialTextBox, faultySerialError),
            Tuple.Create(faultyAssetTextBox, faultyAssetError),
            Tuple.Create(toTextBox, toSiteError),
            Tuple.Create(onsiteTextBox, onsiteError),
            Tuple.Create(offsiteTextBox, offsiteError),
            Tuple.Create(awayTextBox, awaySiteError),
            Tuple.Create(faultTextBox, faultError),
            Tuple.Create(shippingTextBox, shippingError),
            Tuple.Create(folderTextBox, folderError)
        }

        If Not String.IsNullOrEmpty(My.Settings.Name) Then nameTextBox.Text = My.Settings.Name
        If Not String.IsNullOrEmpty(My.Settings.Folder) Then
            folderID = My.Settings.Folder
            Dim folder = main.olNs.GetFolderFromID(folderID)
            If Not folder Is Nothing Then
                folderTextBox.Text = folder.Name
            End If
        End If
        If Not String.IsNullOrEmpty(My.Settings.InstalledSerialKeyword) Then installedSerialTextBox.Text = My.Settings.InstalledSerialKeyword
        If Not String.IsNullOrEmpty(My.Settings.InstalledAssetKeyword) Then installedAssetTextBox.Text = My.Settings.InstalledAssetKeyword
        If Not String.IsNullOrEmpty(My.Settings.FaultySerialKeyword) Then faultySerialTextBox.Text = My.Settings.FaultySerialKeyword
        If Not String.IsNullOrEmpty(My.Settings.FaultyAssetKeyword) Then faultyAssetTextBox.Text = My.Settings.FaultyAssetKeyword
        If Not String.IsNullOrEmpty(My.Settings.ToSiteTimeKeyword) Then toTextBox.Text = My.Settings.ToSiteTimeKeyword
        If Not String.IsNullOrEmpty(My.Settings.OnsiteTimeKeyword) Then onsiteTextBox.Text = My.Settings.OnsiteTimeKeyword
        If Not String.IsNullOrEmpty(My.Settings.OffsiteTimeKeyword) Then offsiteTextBox.Text = My.Settings.OffsiteTimeKeyword
        If Not String.IsNullOrEmpty(My.Settings.AwaySiteTimeKeyword) Then awayTextBox.Text = My.Settings.AwaySiteTimeKeyword
        If Not String.IsNullOrEmpty(My.Settings.FaultDescriptionKeyword) Then faultTextBox.Text = My.Settings.FaultDescriptionKeyword
        If Not String.IsNullOrEmpty(My.Settings.ShippingKeyword) Then shippingTextBox.Text = My.Settings.ShippingKeyword

        deleteCheckBox.Checked = My.Settings.DeleteOnPrint
        weeksNumericUpDown.Value = My.Settings.WeeksToCheck

        If My.Settings.BlackList.Count > 0 Then
            blacklistListBox.Items.Clear()
            For Each item In My.Settings.BlackList
                blacklistListBox.Items.Add(item)
            Next
        End If

        For Each item In tuples
            item.Item2.Visible = False
        Next

    End Sub

    Private Sub clearButton_Click(sender As Object, e As EventArgs) Handles clearButton.Click
        'loops through all textboxes and labels, reseting them to default
        For Each item In tuples
            item.Item1.Text = ""
            item.Item2.Visible = False
        Next

        'sets week to check back number to 4
        weeksNumericUpDown.Value = 4

        'sets checkbox to default
        deleteCheckBox.Checked = False

    End Sub

    Private Sub browseFolderButton_Click(sender As Object, e As EventArgs) Handles browseFolderButton.Click
        Dim folder As Outlook.MAPIFolder = main.olNs.PickFolder()
        If Not folder Is Nothing Then
            folderTextBox.Text = folder.Name
            folderID = folder.EntryID
        Else
            MsgBox("Incorrect folder selected.")
        End If
    End Sub

    Private Sub DeleteBlacklistedItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteBlacklistedItemToolStripMenuItem.Click
        If blacklistListBox.SelectedIndex > -1 Then
            My.Settings.BlackList.Remove(blacklistListBox.SelectedItem)
            My.Settings.Save()
            blacklistListBox.Items.Remove(blacklistListBox.SelectedItem)
        End If
    End Sub

    Private Sub blacklistListBox_MouseDown(sender As Object, e As MouseEventArgs) Handles blacklistListBox.MouseDown
        If e.Button = MouseButtons.Right Then
            Dim index As Integer = blacklistListBox.IndexFromPoint(New Point(e.X, e.Y))
            If index >= 0 Then
                blacklistListBox.SelectedItem = blacklistListBox.Items(index)
                blackListContextMenuStrip.Show(MousePosition)
            End If
        End If
    End Sub
End Class