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
            My.Settings.NewPartKeyword = newTextBox.Text
            My.Settings.FaultyPartKeyword = faultyTextBox.Text
            My.Settings.ToSiteTimeKeyword = toTextBox.Text
            My.Settings.OnsiteTimeKeyword = onsiteTextBox.Text
            My.Settings.AwaySiteTimeKeyword = awayTextBox.Text
            My.Settings.ShippingKeyword = shippingTextBox.Text
            My.Settings.EmailLayout.Clear()
            My.Settings.EmailLayout.AddRange(emailLayoutListBox.Items.Cast(Of String).ToArray)
            My.Settings.WeeksToCheck = weeksNumericUpDown.Value
            My.Settings.Save()

            DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub textBox_Enter(sender As Object, e As EventArgs) Handles nameTextBox.Leave, folderTextBox.Leave, newTextBox.Leave, faultyTextBox.Leave, toTextBox.Leave, awayTextBox.Leave, shippingTextBox.Leave
        sender.BackColor = SystemColors.Window
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        emailLayoutListBox.AutoSize = True

        tuples = New List(Of Tuple(Of TextBox, PictureBox)) From
        {
            Tuple.Create(nameTextBox, nameError),
            Tuple.Create(newTextBox, newPartError),
            Tuple.Create(faultyTextBox, faultyPartError),
            Tuple.Create(toTextBox, toSiteError),
            Tuple.Create(onsiteTextBox, onsiteError),
            Tuple.Create(awayTextBox, awaySiteError),
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
        If Not String.IsNullOrEmpty(My.Settings.NewPartKeyword) Then newTextBox.Text = My.Settings.NewPartKeyword
        If Not String.IsNullOrEmpty(My.Settings.FaultyPartKeyword) Then faultyTextBox.Text = My.Settings.FaultyPartKeyword
        If Not String.IsNullOrEmpty(My.Settings.ToSiteTimeKeyword) Then toTextBox.Text = My.Settings.ToSiteTimeKeyword
        If Not String.IsNullOrEmpty(My.Settings.OnsiteTimeKeyword) Then onsiteTextBox.Text = My.Settings.OnsiteTimeKeyword
        If Not String.IsNullOrEmpty(My.Settings.AwaySiteTimeKeyword) Then awayTextBox.Text = My.Settings.AwaySiteTimeKeyword
        If Not String.IsNullOrEmpty(My.Settings.ShippingKeyword) Then shippingTextBox.Text = My.Settings.ShippingKeyword

        emailLayoutListBox.Items.Clear()

        If My.Settings.EmailLayout.Count = 3 Then
            emailLayoutListBox.Items.Add(My.Settings.EmailLayout(0))
            emailLayoutListBox.Items.Add(My.Settings.EmailLayout(1))
            emailLayoutListBox.Items.Add(My.Settings.EmailLayout(2))
        Else
            emailLayoutListBox.Items.Add("Times")
            emailLayoutListBox.Items.Add("Parts")
            emailLayoutListBox.Items.Add("Update")
        End If

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

    Private Sub upButton_Click(sender As Object, e As EventArgs) Handles upButton.Click
        If emailLayoutListBox.SelectedIndex > 0 Then
            Dim index = emailLayoutListBox.SelectedIndex
            Dim item = emailLayoutListBox.SelectedItem
            emailLayoutListBox.Items(index) = emailLayoutListBox.Items(index - 1)
            emailLayoutListBox.Items(index - 1) = item
            emailLayoutListBox.SelectedIndex = index - 1
        End If
    End Sub

    Private Sub downButton_Click(sender As Object, e As EventArgs) Handles downButton.Click
        If emailLayoutListBox.SelectedIndex > -1 AndAlso emailLayoutListBox.SelectedIndex < 2 Then
            Dim index = emailLayoutListBox.SelectedIndex
            Dim item = emailLayoutListBox.SelectedItem
            emailLayoutListBox.Items(index) = emailLayoutListBox.Items(index + 1)
            emailLayoutListBox.Items(index + 1) = item
            emailLayoutListBox.SelectedIndex = index + 1
        End If
    End Sub

    Private Sub ListDragSource_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles emailLayoutListBox.MouseDown
        ' Get the index of the item the mouse is below.
        indexOfItemUnderMouseToDrag = emailLayoutListBox.SelectedIndex
    End Sub

    Private Sub emailLayoutListBox_MouseUp(sender As Object, e As MouseEventArgs) Handles emailLayoutListBox.MouseUp
        'when user stops dragging item, swaps it with selected item
        If indexOfItemUnderMouseToDrag <> -1 AndAlso emailLayoutListBox.SelectedIndex <> -1 Then
            Dim item As Object = emailLayoutListBox.Items(indexOfItemUnderMouseToDrag)
            emailLayoutListBox.Items(indexOfItemUnderMouseToDrag) = emailLayoutListBox.Items(emailLayoutListBox.SelectedIndex)
            emailLayoutListBox.Items(emailLayoutListBox.SelectedIndex) = item
        End If
    End Sub

    Private Sub clearButton_Click(sender As Object, e As EventArgs) Handles clearButton.Click
        'loops through all textboxes and labels, reseting them to default
        For Each item In tuples
            item.Item1.Text = ""
            item.Item2.Visible = False
        Next

        'returns listbox to default
        emailLayoutListBox.Items.Clear()
        emailLayoutListBox.Items.Add("Times")
        emailLayoutListBox.Items.Add("Parts")
        emailLayoutListBox.Items.Add("Update")

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