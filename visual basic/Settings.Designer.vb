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
        Me.folderLabel = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.newLabel = New System.Windows.Forms.Label()
        Me.faultyLabel = New System.Windows.Forms.Label()
        Me.folderTextBox = New System.Windows.Forms.TextBox()
        Me.newTextBox = New System.Windows.Forms.TextBox()
        Me.faultyTextBox = New System.Windows.Forms.TextBox()
        Me.saveSettingsButton = New System.Windows.Forms.Button()
        Me.resetButton = New System.Windows.Forms.Button()
        Me.deleteCheckBox = New System.Windows.Forms.CheckBox()
        Me.nameTextBox = New System.Windows.Forms.TextBox()
        Me.nameLabel = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.upButton = New System.Windows.Forms.Button()
        Me.downButton = New System.Windows.Forms.Button()
        Me.emailLayoutListBox = New System.Windows.Forms.ListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.weeksNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.toTextBox = New System.Windows.Forms.TextBox()
        Me.toLabel = New System.Windows.Forms.Label()
        Me.awayTextBox = New System.Windows.Forms.TextBox()
        Me.awayLabel = New System.Windows.Forms.Label()
        Me.shippingTextBox = New System.Windows.Forms.TextBox()
        Me.shippingLabel = New System.Windows.Forms.Label()
        Me.blacklistListBox = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.deleteBlacklistButton = New System.Windows.Forms.Button()
        Me.onsiteTextBox = New System.Windows.Forms.TextBox()
        Me.onsiteLabel = New System.Windows.Forms.Label()
        CType(Me.weeksNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'folderLabel
        '
        Me.folderLabel.AutoSize = True
        Me.folderLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.folderLabel.Location = New System.Drawing.Point(13, 62)
        Me.folderLabel.Name = "folderLabel"
        Me.folderLabel.Size = New System.Drawing.Size(61, 20)
        Me.folderLabel.TabIndex = 1
        Me.folderLabel.Text = "Folder:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 553)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 20)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Delete On Print:"
        '
        'newLabel
        '
        Me.newLabel.AutoSize = True
        Me.newLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newLabel.Location = New System.Drawing.Point(13, 115)
        Me.newLabel.Name = "newLabel"
        Me.newLabel.Size = New System.Drawing.Size(161, 20)
        Me.newLabel.TabIndex = 3
        Me.newLabel.Text = "New Parts Keyword:"
        '
        'faultyLabel
        '
        Me.faultyLabel.AutoSize = True
        Me.faultyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.faultyLabel.Location = New System.Drawing.Point(13, 168)
        Me.faultyLabel.Name = "faultyLabel"
        Me.faultyLabel.Size = New System.Drawing.Size(173, 20)
        Me.faultyLabel.TabIndex = 4
        Me.faultyLabel.Text = "Faulty Parts Keyword:"
        '
        'folderTextBox
        '
        Me.folderTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.folderTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.folderTextBox.Location = New System.Drawing.Point(17, 85)
        Me.folderTextBox.Name = "folderTextBox"
        Me.folderTextBox.Size = New System.Drawing.Size(238, 27)
        Me.folderTextBox.TabIndex = 6
        '
        'newTextBox
        '
        Me.newTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.newTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newTextBox.Location = New System.Drawing.Point(17, 138)
        Me.newTextBox.Name = "newTextBox"
        Me.newTextBox.Size = New System.Drawing.Size(239, 27)
        Me.newTextBox.TabIndex = 8
        '
        'faultyTextBox
        '
        Me.faultyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.faultyTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.faultyTextBox.Location = New System.Drawing.Point(17, 191)
        Me.faultyTextBox.Name = "faultyTextBox"
        Me.faultyTextBox.Size = New System.Drawing.Size(239, 27)
        Me.faultyTextBox.TabIndex = 9
        '
        'saveSettingsButton
        '
        Me.saveSettingsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveSettingsButton.Location = New System.Drawing.Point(15, 580)
        Me.saveSettingsButton.Name = "saveSettingsButton"
        Me.saveSettingsButton.Size = New System.Drawing.Size(139, 40)
        Me.saveSettingsButton.TabIndex = 10
        Me.saveSettingsButton.Text = "Save Settings"
        Me.saveSettingsButton.UseVisualStyleBackColor = True
        '
        'resetButton
        '
        Me.resetButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.resetButton.Location = New System.Drawing.Point(168, 580)
        Me.resetButton.Name = "resetButton"
        Me.resetButton.Size = New System.Drawing.Size(75, 40)
        Me.resetButton.TabIndex = 11
        Me.resetButton.Text = "Reset"
        Me.resetButton.UseVisualStyleBackColor = True
        '
        'deleteCheckBox
        '
        Me.deleteCheckBox.AutoSize = True
        Me.deleteCheckBox.Location = New System.Drawing.Point(148, 557)
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
        Me.nameTextBox.Size = New System.Drawing.Size(239, 27)
        Me.nameTextBox.TabIndex = 5
        '
        'nameLabel
        '
        Me.nameLabel.AutoSize = True
        Me.nameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nameLabel.Location = New System.Drawing.Point(13, 9)
        Me.nameLabel.Name = "nameLabel"
        Me.nameLabel.Size = New System.Drawing.Size(58, 20)
        Me.nameLabel.TabIndex = 0
        Me.nameLabel.Text = "Name:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 436)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 20)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Email Layout:"
        '
        'upButton
        '
        Me.upButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.upButton.Location = New System.Drawing.Point(129, 459)
        Me.upButton.Name = "upButton"
        Me.upButton.Size = New System.Drawing.Size(72, 29)
        Me.upButton.TabIndex = 16
        Me.upButton.Text = "Up"
        Me.upButton.UseVisualStyleBackColor = True
        '
        'downButton
        '
        Me.downButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.downButton.Location = New System.Drawing.Point(129, 494)
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
        Me.emailLayoutListBox.Location = New System.Drawing.Point(15, 459)
        Me.emailLayoutListBox.Name = "emailLayoutListBox"
        Me.emailLayoutListBox.Size = New System.Drawing.Size(107, 64)
        Me.emailLayoutListBox.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 529)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(179, 20)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Weeks Back to Check:"
        '
        'weeksNumericUpDown
        '
        Me.weeksNumericUpDown.Location = New System.Drawing.Point(197, 529)
        Me.weeksNumericUpDown.Name = "weeksNumericUpDown"
        Me.weeksNumericUpDown.Size = New System.Drawing.Size(46, 22)
        Me.weeksNumericUpDown.TabIndex = 21
        Me.weeksNumericUpDown.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'toTextBox
        '
        Me.toTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.toTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toTextBox.Location = New System.Drawing.Point(17, 244)
        Me.toTextBox.Name = "toTextBox"
        Me.toTextBox.Size = New System.Drawing.Size(239, 27)
        Me.toTextBox.TabIndex = 23
        '
        'toLabel
        '
        Me.toLabel.AutoSize = True
        Me.toLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toLabel.Location = New System.Drawing.Point(13, 221)
        Me.toLabel.Name = "toLabel"
        Me.toLabel.Size = New System.Drawing.Size(178, 20)
        Me.toLabel.TabIndex = 22
        Me.toLabel.Text = "To Site Time Keyword:"
        '
        'awayTextBox
        '
        Me.awayTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.awayTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.awayTextBox.Location = New System.Drawing.Point(16, 350)
        Me.awayTextBox.Name = "awayTextBox"
        Me.awayTextBox.Size = New System.Drawing.Size(239, 27)
        Me.awayTextBox.TabIndex = 25
        '
        'awayLabel
        '
        Me.awayLabel.AutoSize = True
        Me.awayLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.awayLabel.Location = New System.Drawing.Point(12, 327)
        Me.awayLabel.Name = "awayLabel"
        Me.awayLabel.Size = New System.Drawing.Size(243, 20)
        Me.awayLabel.TabIndex = 24
        Me.awayLabel.Text = "Away From Site Time Keyword:"
        '
        'shippingTextBox
        '
        Me.shippingTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.shippingTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.shippingTextBox.Location = New System.Drawing.Point(16, 403)
        Me.shippingTextBox.Name = "shippingTextBox"
        Me.shippingTextBox.Size = New System.Drawing.Size(239, 27)
        Me.shippingTextBox.TabIndex = 27
        '
        'shippingLabel
        '
        Me.shippingLabel.AutoSize = True
        Me.shippingLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.shippingLabel.Location = New System.Drawing.Point(12, 380)
        Me.shippingLabel.Name = "shippingLabel"
        Me.shippingLabel.Size = New System.Drawing.Size(205, 20)
        Me.shippingLabel.TabIndex = 26
        Me.shippingLabel.Text = "Shipping Update Keyword:"
        '
        'blacklistListBox
        '
        Me.blacklistListBox.FormattingEnabled = True
        Me.blacklistListBox.ItemHeight = 16
        Me.blacklistListBox.Location = New System.Drawing.Point(304, 30)
        Me.blacklistListBox.Name = "blacklistListBox"
        Me.blacklistListBox.Size = New System.Drawing.Size(362, 356)
        Me.blacklistListBox.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(300, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 20)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Blacklist:"
        '
        'deleteBlacklistButton
        '
        Me.deleteBlacklistButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deleteBlacklistButton.Location = New System.Drawing.Point(378, 392)
        Me.deleteBlacklistButton.Name = "deleteBlacklistButton"
        Me.deleteBlacklistButton.Size = New System.Drawing.Size(189, 40)
        Me.deleteBlacklistButton.TabIndex = 30
        Me.deleteBlacklistButton.Text = "Delete Blacklist Item"
        Me.deleteBlacklistButton.UseVisualStyleBackColor = True
        '
        'onsiteTextBox
        '
        Me.onsiteTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.onsiteTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.onsiteTextBox.Location = New System.Drawing.Point(17, 297)
        Me.onsiteTextBox.Name = "onsiteTextBox"
        Me.onsiteTextBox.Size = New System.Drawing.Size(239, 27)
        Me.onsiteTextBox.TabIndex = 32
        '
        'onsiteLabel
        '
        Me.onsiteLabel.AutoSize = True
        Me.onsiteLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.onsiteLabel.Location = New System.Drawing.Point(13, 274)
        Me.onsiteLabel.Name = "onsiteLabel"
        Me.onsiteLabel.Size = New System.Drawing.Size(174, 20)
        Me.onsiteLabel.TabIndex = 31
        Me.onsiteLabel.Text = "Onsite Time Keyword:"
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 630)
        Me.Controls.Add(Me.onsiteTextBox)
        Me.Controls.Add(Me.onsiteLabel)
        Me.Controls.Add(Me.deleteBlacklistButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.blacklistListBox)
        Me.Controls.Add(Me.shippingTextBox)
        Me.Controls.Add(Me.shippingLabel)
        Me.Controls.Add(Me.awayTextBox)
        Me.Controls.Add(Me.awayLabel)
        Me.Controls.Add(Me.toTextBox)
        Me.Controls.Add(Me.toLabel)
        Me.Controls.Add(Me.weeksNumericUpDown)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.emailLayoutListBox)
        Me.Controls.Add(Me.downButton)
        Me.Controls.Add(Me.upButton)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.nameTextBox)
        Me.Controls.Add(Me.nameLabel)
        Me.Controls.Add(Me.deleteCheckBox)
        Me.Controls.Add(Me.resetButton)
        Me.Controls.Add(Me.saveSettingsButton)
        Me.Controls.Add(Me.faultyTextBox)
        Me.Controls.Add(Me.newTextBox)
        Me.Controls.Add(Me.folderTextBox)
        Me.Controls.Add(Me.faultyLabel)
        Me.Controls.Add(Me.newLabel)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.folderLabel)
        Me.Name = "Settings"
        Me.Text = "Configuration Creator"
        CType(Me.weeksNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents folderLabel As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents newLabel As Label
    Friend WithEvents faultyLabel As Label
    Friend WithEvents folderTextBox As TextBox
    Friend WithEvents newTextBox As TextBox
    Friend WithEvents faultyTextBox As TextBox
    Friend WithEvents saveSettingsButton As Button
    Friend WithEvents resetButton As Button
    Friend WithEvents deleteCheckBox As CheckBox
    Friend WithEvents nameTextBox As TextBox
    Friend WithEvents nameLabel As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents upButton As Button
    Friend WithEvents downButton As Button
    Friend WithEvents emailLayoutListBox As ListBox
    Friend WithEvents Label6 As Label
    Friend WithEvents weeksNumericUpDown As NumericUpDown
    Friend WithEvents toTextBox As TextBox
    Friend WithEvents toLabel As Label
    Friend WithEvents awayTextBox As TextBox
    Friend WithEvents awayLabel As Label
    Friend WithEvents shippingTextBox As TextBox
    Friend WithEvents shippingLabel As Label
    Friend WithEvents blacklistListBox As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents deleteBlacklistButton As Button
    Friend WithEvents onsiteTextBox As TextBox
    Friend WithEvents onsiteLabel As Label
End Class
