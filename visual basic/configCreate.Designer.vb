<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class configCreate
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nameTextBox = New System.Windows.Forms.TextBox()
        Me.folderTextBox = New System.Windows.Forms.TextBox()
        Me.inTextBox = New System.Windows.Forms.TextBox()
        Me.outTextBox = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.deleteCheckBox = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Folder:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Delete On Print:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(153, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Ingoing Parts Keyword:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(165, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Outgoing Parts Keyword:"
        '
        'nameTextBox
        '
        Me.nameTextBox.BackColor = System.Drawing.Color.White
        Me.nameTextBox.Location = New System.Drawing.Point(68, 21)
        Me.nameTextBox.Name = "nameTextBox"
        Me.nameTextBox.Size = New System.Drawing.Size(305, 22)
        Me.nameTextBox.TabIndex = 5
        '
        'folderTextBox
        '
        Me.folderTextBox.Location = New System.Drawing.Point(68, 53)
        Me.folderTextBox.Name = "folderTextBox"
        Me.folderTextBox.Size = New System.Drawing.Size(305, 22)
        Me.folderTextBox.TabIndex = 6
        '
        'inTextBox
        '
        Me.inTextBox.Location = New System.Drawing.Point(184, 90)
        Me.inTextBox.Name = "inTextBox"
        Me.inTextBox.Size = New System.Drawing.Size(189, 22)
        Me.inTextBox.TabIndex = 8
        '
        'outTextBox
        '
        Me.outTextBox.Location = New System.Drawing.Point(184, 127)
        Me.outTextBox.Name = "outTextBox"
        Me.outTextBox.Size = New System.Drawing.Size(189, 22)
        Me.outTextBox.TabIndex = 9
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(35, 201)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(162, 34)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Create Configuration"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(256, 201)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 34)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Clear"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'deleteCheckBox
        '
        Me.deleteCheckBox.AutoSize = True
        Me.deleteCheckBox.Location = New System.Drawing.Point(128, 165)
        Me.deleteCheckBox.Name = "deleteCheckBox"
        Me.deleteCheckBox.Size = New System.Drawing.Size(18, 17)
        Me.deleteCheckBox.TabIndex = 12
        Me.deleteCheckBox.UseVisualStyleBackColor = True
        '
        'configCreate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 263)
        Me.Controls.Add(Me.deleteCheckBox)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.outTextBox)
        Me.Controls.Add(Me.inTextBox)
        Me.Controls.Add(Me.folderTextBox)
        Me.Controls.Add(Me.nameTextBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "configCreate"
        Me.Text = "Configuration Creator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents nameTextBox As TextBox
    Friend WithEvents folderTextBox As TextBox
    Friend WithEvents inTextBox As TextBox
    Friend WithEvents outTextBox As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents deleteCheckBox As CheckBox
End Class
