Public Class Settings

    'Color to make textbox background and label colours when invalid input
    Dim errorColor As Color = Color.FromArgb(112, 44, 43)

    'List of tuples to match textboxes with their labels, for colouring purposes
    Dim tuples As New List(Of Tuple(Of TextBox, Label))

    Private indexOfItemUnderMouseToDrag As Integer
    Private indexOfItemUnderMouseToDrop As Integer

    Private Sub saveSettingsButton_Click(sender As Object, e As EventArgs) Handles saveSettingsButton.Click

        Dim missingField As Boolean

        For Each item In tuples
            If String.IsNullOrEmpty(item.Item1.Text) Then
                item.Item1.BackColor = errorColor
                item.Item2.ForeColor = errorColor
                missingField = True
            Else
                item.Item2.ForeColor = SystemColors.ControlText
            End If
        Next

        'if all fields are completed
        If Not missingField Then
            My.Settings.Name = nameTextBox.Text
            My.Settings.Folder = folderTextBox.Text
            My.Settings.DeleteOnPrint = deleteCheckBox.Checked
            My.Settings.NewPartKeyword = newTextBox.Text
            My.Settings.FaultyPartKeyword = faultyTextBox.Text
            My.Settings.ToSiteTimeKeyword = toTextBox.Text
            My.Settings.AwaySiteTimeKeyword = awayTextBox.Text
            My.Settings.ShippingKeyword = shippingTextBox.Text
            My.Settings.EmailLayout.Clear()
            My.Settings.EmailLayout.AddRange(emailLayoutListBox.Items.Cast(Of String).ToArray)
            My.Settings.WeeksToCheck = weeksNumericUpDown.Value
            My.Settings.BlackList.Clear()
            For Each item In blacklistListBox.Items
                My.Settings.BlackList.Add(item)
            Next
            My.Settings.Save()

            DialogResult = System.Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub textBox_Enter(sender As Object, e As EventArgs) Handles nameTextBox.Leave, folderTextBox.Leave, newTextBox.Leave, faultyTextBox.Leave, toTextBox.Leave, awayTextBox.Leave, shippingTextBox.Leave
        sender.BackColor = SystemColors.Window
    End Sub

    Private Sub textBox_Leave(sender As Object, e As EventArgs) Handles nameTextBox.Leave, folderTextBox.Leave, newTextBox.Leave, faultyTextBox.Leave, toTextBox.Leave, awayTextBox.Leave, shippingTextBox.Leave

        Dim tuple As Tuple(Of TextBox, Label) = Nothing

        For Each item In tuples
            If ReferenceEquals(item.Item1, sender) Then
                tuple = item
                Exit For
            End If
        Next

        If tuple.Item1.Text = "" Then
            tuple.Item1.BackColor = errorColor
            tuple.Item2.ForeColor = errorColor
        Else
            tuple.Item2.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tuples = New List(Of Tuple(Of TextBox, Label)) From
        {
            Tuple.Create(nameTextBox, nameLabel),
            Tuple.Create(folderTextBox, folderLabel),
            Tuple.Create(newTextBox, newLabel),
            Tuple.Create(faultyTextBox, faultyLabel),
            Tuple.Create(toTextBox, toLabel),
            Tuple.Create(awayTextBox, awayLabel),
            Tuple.Create(shippingTextBox, shippingLabel)
        }

        If Not String.IsNullOrEmpty(My.Settings.Name) Then
            nameTextBox.Text = My.Settings.Name
        End If
        If Not String.IsNullOrEmpty(My.Settings.Folder) Then
            folderTextBox.Text = My.Settings.Folder
        End If
        If Not String.IsNullOrEmpty(My.Settings.NewPartKeyword) Then
            newTextBox.Text = My.Settings.NewPartKeyword
        End If
        If Not String.IsNullOrEmpty(My.Settings.FaultyPartKeyword) Then
            faultyTextBox.Text = My.Settings.FaultyPartKeyword
        End If
        If Not String.IsNullOrEmpty(My.Settings.ToSiteTimeKeyword) Then
            toTextBox.Text = My.Settings.ToSiteTimeKeyword
        End If
        If Not String.IsNullOrEmpty(My.Settings.AwaySiteTimeKeyword) Then
            awayTextBox.Text = My.Settings.AwaySiteTimeKeyword
        End If
        If Not String.IsNullOrEmpty(My.Settings.ShippingKeyword) Then
            shippingTextBox.Text = My.Settings.ShippingKeyword
        End If

        emailLayoutListBox.Items.Clear()

        If Not (String.IsNullOrEmpty(My.Settings.EmailLayout(0)) Or String.IsNullOrEmpty(My.Settings.EmailLayout(1)) Or String.IsNullOrEmpty(My.Settings.EmailLayout(2))) Then
            emailLayoutListBox.Items.Add(My.Settings.EmailLayout(0))
            emailLayoutListBox.Items.Add(My.Settings.EmailLayout(1))
            emailLayoutListBox.Items.Add(My.Settings.EmailLayout(2))
        End If

        deleteCheckBox.Checked = My.Settings.DeleteOnPrint
        weeksNumericUpDown.Value = My.Settings.WeeksToCheck

        If My.Settings.BlackList.Count > 0 Then
            blacklistListBox.Items.Clear()
            For Each item In My.Settings.BlackList
                blacklistListBox.Items.Add(item)
            Next
        End If

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

    Private Sub clearButton_Click(sender As Object, e As EventArgs) Handles resetButton.Click
        'loops through all textboxes and labels, reseting them to default
        For Each item In tuples
            item.Item1.Text = ""
            item.Item1.BackColor = SystemColors.Window
            item.Item2.ForeColor = SystemColors.ControlText
        Next

        'returns listbox to default
        emailLayoutListBox.Items.Clear()
        emailLayoutListBox.Items.Add("Time")
        emailLayoutListBox.Items.Add("Parts")
        emailLayoutListBox.Items.Add("Update")

        'sets week to check back number to 4
        weeksNumericUpDown.Value = 4

        'sets checkbox to default
        deleteCheckBox.Checked = False
    End Sub

    Private Sub deleteBlacklistButton_Click(sender As Object, e As EventArgs) Handles deleteBlacklistButton.Click
        If blacklistListBox.SelectedIndex <> -1 Then
            blacklistListBox.Items.Remove(blacklistListBox.SelectedItem)
        End If
    End Sub
End Class