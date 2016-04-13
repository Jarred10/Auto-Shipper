Public Class Settings

    Dim errorColor As Color = Color.FromArgb(112, 44, 43)
    Dim submitted As Boolean

    Dim textBoxes(3) As Control
    Dim labels(3) As Control

    Private indexOfItemUnderMouseToDrag As Integer
    Private indexOfItemUnderMouseToDrop As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        submitted = True

        Dim ctrl As Control
        Dim missingField As Boolean
        'setups up for config

        For i = 0 To textBoxes.Count - 1
            ctrl = textBoxes(i)
            If ctrl.Text = "" Then
                ctrl.BackColor = errorColor
                labels(i).ForeColor = errorColor
                missingField = True
            Else
                labels(i).ForeColor = SystemColors.ControlText
            End If
        Next

        'if all fields are completed
        If Not missingField Then
            Dim objWriter As New System.IO.StreamWriter("config.txt")
            With objWriter
            End With
            objWriter.WriteLine("name=" + nameTextBox.Text)
            objWriter.WriteLine("folder=" + folderTextBox.Text)
            objWriter.WriteLine("deleteOnPrint=" + deleteCheckBox.Checked.ToString)
            objWriter.WriteLine("ingoingPartsKeyword=" + inTextBox.Text)
            objWriter.WriteLine("outgoingPartsKeyword=" + outTextBox.Text)
            objWriter.WriteLine("emaiLayout=" + emailLayoutListBox.Items(0) + "," + emailLayoutListBox.Items(1) + "," + emailLayoutListBox.Items(2))
            objWriter.Close()

            MsgBox("Configuration succesfully created.")
            Me.Close()
        End If
    End Sub

    Private Sub textBox_Enter(sender As Object, e As EventArgs) Handles nameTextBox.Enter, folderTextBox.Enter, inTextBox.Enter, outTextBox.Enter
        sender.BackColor = SystemColors.Window
    End Sub

    Private Sub textBox_Leave(sender As Object, e As EventArgs) Handles nameTextBox.Leave, folderTextBox.Leave, inTextBox.Leave, outTextBox.Leave
        If submitted Then
            If sender.Text = "" Then
                sender.BackColor = errorColor
            Else
                labels(Array.IndexOf(textBoxes, sender)).ForeColor = SystemColors.ControlText
            End If
        End If
    End Sub

    Private Sub configCreate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        textBoxes = {nameTextBox, folderTextBox, inTextBox, outTextBox}
        labels = {Label1, Label2, Label3, Label4}
        emailLayoutListBox.ItemHeight = 25
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
        Dim ctrl As Control
        'loops through all textboxes and labels, reseting them to default
        For i = 0 To textBoxes.Count - 1
            ctrl = textBoxes(i)
            ctrl.Text = ""
            ctrl.BackColor = SystemColors.Window
            labels(i).ForeColor = SystemColors.ControlText
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
End Class