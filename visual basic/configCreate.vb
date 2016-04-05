Public Class configCreate
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Refresh()

        Dim ErrorText As String = "No values in following fields: "
        Dim g As Graphics = Me.CreateGraphics
        Dim pen As New Pen(Color.Red, 2.0)


        If nameTextBox.Text = Nothing Then
            ErrorText += vbCrLf & "Name text box. "
            g.DrawRectangle(pen, New Rectangle(nameTextBox.Location, nameTextBox.Size))
        End If
        If folderTextBox.Text = Nothing Then
            ErrorText += vbCrLf & "Folder text box."
            g.DrawRectangle(pen, New Rectangle(folderTextBox.Location, folderTextBox.Size))
        End If
        If inTextBox.Text = Nothing Then
            ErrorText += vbCrLf & "Input serial keyword text box."
            g.DrawRectangle(pen, New Rectangle(inTextBox.Location, inTextBox.Size))
        End If
        If outTextBox.Text = Nothing Then
            ErrorText += vbCrLf & "Output serial keyword text box."
            g.DrawRectangle(pen, New Rectangle(outTextBox.Location, outTextBox.Size))
        End If
        If ErrorText = "No values in following fields: " Then
            Dim objWriter As New System.IO.StreamWriter("config.txt")
            objWriter.WriteLine("name=" + nameTextBox.Text)
            objWriter.WriteLine("folder=" + folderTextBox.Text)
            objWriter.WriteLine("deleteOnPrint=" + deleteCheckBox.Checked.ToString)
            objWriter.WriteLine("ingoingPartsKeyword=" + inTextBox.Text)
            objWriter.WriteLine("outgoingPartsKeyword=" + outTextBox.Text)
            objWriter.Close()

            MsgBox("Configuration succesfully created.")
            Me.Close()

        Else
            MsgBox(ErrorText)

        End If
    End Sub
End Class