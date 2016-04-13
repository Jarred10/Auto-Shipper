<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Settings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.folderTextBox = New System.Windows.Forms.TextBox()
        Me.inTextBox = New System.Windows.Forms.TextBox()
        Me.outTextBox = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.resetButton = New System.Windows.Forms.Button()
        Me.deleteCheckBox = New System.Windows.Forms.CheckBox()
        Me.nameTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.upButton = New System.Windows.Forms.Button()
        Me.downButton = New System.Windows.Forms.Button()
        Me.emailLayoutListBox = New System.Windows.Forms.ListBox()
        Me.loadButton = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.weeksNumericUpDown = New System.Windows.Forms.NumericUpDown()
        CType(Me.weeksNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Folder:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 433)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 20)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Delete On Print:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 154)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(181, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Ingoing Parts Keyword:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 227)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(195, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Outgoing Parts Keyword:"
        '
        'folderTextBox
        '
        Me.folderTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.folderTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.folderTextBox.Location = New System.Drawing.Point(17, 101)
        Me.folderTextBox.Name = "folderTextBox"
        Me.folderTextBox.Size = New System.Drawing.Size(376, 27)
        Me.folderTextBox.TabIndex = 6
        '
        'inTextBox
        '
        Me.inTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.inTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inTextBox.Location = New System.Drawing.Point(17, 177)
        Me.inTextBox.Name = "inTextBox"
        Me.inTextBox.Size = New System.Drawing.Size(376, 27)
        Me.inTextBox.TabIndex = 8
        '
        'outTextBox
        '
        Me.outTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.outTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.outTextBox.Location = New System.Drawing.Point(17, 250)
        Me.outTextBox.Name = "outTextBox"
        Me.outTextBox.Size = New System.Drawing.Size(376, 27)
        Me.outTextBox.TabIndex = 9
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(16, 471)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(191, 40)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Create Configuration"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'resetButton
        '
        Me.resetButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.resetButton.Location = New System.Drawing.Point(317, 471)
        Me.resetButton.Name = "resetButton"
        Me.resetButton.Size = New System.Drawing.Size(75, 40)
        Me.resetButton.TabIndex = 11
        Me.resetButton.Text = "Reset"
        Me.resetButton.UseVisualStyleBackColor = True
        '
        'deleteCheckBox
        '
        Me.deleteCheckBox.AutoSize = True
        Me.deleteCheckBox.Location = New System.Drawing.Point(149, 437)
        Me.deleteCheckBox.Name = "deleteCheckBox"
        Me.deleteCheckBox.Size = New System.Drawing.Size(18, 17)
        Me.deleteCheckBox.TabIndex = 12
        Me.deleteCheckBox.UseVisualStyleBackColor = True
        '
        'nameTextBox
        '
        Me.nameTextBox.BackColor = System.Drawing.Color.White
        Me.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nameTextBox.Location = New System.Drawing.Point(17, 32)
        Me.nameTextBox.Name = "nameTextBox"
        Me.nameTextBox.Size = New System.Drawing.Size(376, 27)
        Me.nameTextBox.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 300)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 20)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Email Layout:"
        '
        'upButton
        '
        Me.upButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.upButton.Location = New System.Drawing.Point(173, 323)
        Me.upButton.Name = "upButton"
        Me.upButton.Size = New System.Drawing.Size(72, 29)
        Me.upButton.TabIndex = 16
        Me.upButton.Text = "Up"
        Me.upButton.UseVisualStyleBackColor = True
        '
        'downButton
        '
        Me.downButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.downButton.Location = New System.Drawing.Point(173, 358)
        Me.downButton.Name = "downButton"
        Me.downButton.Size = New System.Drawing.Size(72, 29)
        Me.downButton.TabIndex = 17
        Me.downButton.Text = "Down"
        Me.downButton.UseVisualStyleBackColor = True
        '
        'emailLayoutListBox
        '
        Me.emailLayoutListBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.emailLayoutListBox.FormattingEnabled = True
        Me.emailLayoutListBox.ItemHeight = 20
        Me.emailLayoutListBox.Items.AddRange(New Object() {"Times", "Parts", "Update"})
        Me.emailLayoutListBox.Location = New System.Drawing.Point(17, 323)
        Me.emailLayoutListBox.Name = "emailLayoutListBox"
        Me.emailLayoutListBox.Size = New System.Drawing.Size(150, 64)
        Me.emailLayoutListBox.TabIndex = 18
        '
        'loadButton
        '
        Me.loadButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.loadButton.Location = New System.Drawing.Point(226, 471)
        Me.loadButton.Name = "loadButton"
        Me.loadButton.Size = New System.Drawing.Size(75, 40)
        Me.loadButton.TabIndex = 19
        Me.loadButton.Text = "Load"
        Me.loadButton.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 400)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(179, 20)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Weeks Back to Check:"
        '
        'weeksNumericUpDown
        '
        Me.weeksNumericUpDown.Location = New System.Drawing.Point(199, 397)
        Me.weeksNumericUpDown.Name = "weeksNumericUpDown"
        Me.weeksNumericUpDown.Size = New System.Drawing.Size(46, 22)
        Me.weeksNumericUpDown.TabIndex = 21
        Me.weeksNumericUpDown.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'configCreate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 534)
        Me.Controls.Add(Me.weeksNumericUpDown)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.loadButton)
        Me.Controls.Add(Me.emailLayoutListBox)
        Me.Controls.Add(Me.downButton)
        Me.Controls.Add(Me.upButton)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.nameTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.deleteCheckBox)
        Me.Controls.Add(Me.resetButton)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.outTextBox)
        Me.Controls.Add(Me.inTextBox)
        Me.Controls.Add(Me.folderTextBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Name = "configCreate"
        Me.Text = "Configuration Creator"
        CType(Me.weeksNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents folderTextBox As TextBox
    Friend WithEvents inTextBox As TextBox
    Friend WithEvents outTextBox As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents resetButton As Button
    Friend WithEvents deleteCheckBox As CheckBox
    Friend WithEvents nameTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents upButton As Button
    Friend WithEvents downButton As Button
    Friend WithEvents emailLayoutListBox As ListBox
    Friend WithEvents loadButton As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents weeksNumericUpDown As NumericUpDown
End Class
