<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Configuration
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
        Me.components = New System.ComponentModel.Container()
        Me.folderLabel = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.newLabel = New System.Windows.Forms.Label()
        Me.faultyLabel = New System.Windows.Forms.Label()
        Me.folderTextBox = New System.Windows.Forms.TextBox()
        Me.newTextBox = New System.Windows.Forms.TextBox()
        Me.faultyTextBox = New System.Windows.Forms.TextBox()
        Me.saveSettingsButton = New System.Windows.Forms.Button()
        Me.clearButton = New System.Windows.Forms.Button()
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
        Me.onsiteTextBox = New System.Windows.Forms.TextBox()
        Me.onsiteLabel = New System.Windows.Forms.Label()
        Me.browseFolderButton = New System.Windows.Forms.Button()
        Me.nameError = New System.Windows.Forms.PictureBox()
        Me.newPartError = New System.Windows.Forms.PictureBox()
        Me.faultyPartError = New System.Windows.Forms.PictureBox()
        Me.toSiteError = New System.Windows.Forms.PictureBox()
        Me.onsiteError = New System.Windows.Forms.PictureBox()
        Me.awaySiteError = New System.Windows.Forms.PictureBox()
        Me.shippingError = New System.Windows.Forms.PictureBox()
        Me.blackListContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteBlacklistedItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.folderError = New System.Windows.Forms.PictureBox()
        CType(Me.weeksNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nameError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.newPartError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.faultyPartError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.toSiteError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.onsiteError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.awaySiteError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.shippingError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.blackListContextMenuStrip.SuspendLayout()
        CType(Me.folderError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'folderLabel
        '
        Me.folderLabel.AutoSize = True
        Me.folderLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.folderLabel.Location = New System.Drawing.Point(13, 380)
        Me.folderLabel.Name = "folderLabel"
        Me.folderLabel.Size = New System.Drawing.Size(221, 20)
        Me.folderLabel.TabIndex = 1
        Me.folderLabel.Text = "Shipping Documents Folder:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(317, 494)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 20)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Delete On Print:"
        '
        'newLabel
        '
        Me.newLabel.AutoSize = True
        Me.newLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newLabel.Location = New System.Drawing.Point(12, 62)
        Me.newLabel.Name = "newLabel"
        Me.newLabel.Size = New System.Drawing.Size(161, 20)
        Me.newLabel.TabIndex = 3
        Me.newLabel.Text = "New Parts Keyword:"
        '
        'faultyLabel
        '
        Me.faultyLabel.AutoSize = True
        Me.faultyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.faultyLabel.Location = New System.Drawing.Point(12, 115)
        Me.faultyLabel.Name = "faultyLabel"
        Me.faultyLabel.Size = New System.Drawing.Size(173, 20)
        Me.faultyLabel.TabIndex = 4
        Me.faultyLabel.Text = "Faulty Parts Keyword:"
        '
        'folderTextBox
        '
        Me.folderTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.folderTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.folderTextBox.Location = New System.Drawing.Point(16, 403)
        Me.folderTextBox.Name = "folderTextBox"
        Me.folderTextBox.ReadOnly = True
        Me.folderTextBox.Size = New System.Drawing.Size(240, 27)
        Me.folderTextBox.TabIndex = 15
        Me.folderTextBox.TabStop = False
        '
        'newTextBox
        '
        Me.newTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.newTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newTextBox.Location = New System.Drawing.Point(16, 85)
        Me.newTextBox.Name = "newTextBox"
        Me.newTextBox.Size = New System.Drawing.Size(239, 27)
        Me.newTextBox.TabIndex = 2
        '
        'faultyTextBox
        '
        Me.faultyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.faultyTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.faultyTextBox.Location = New System.Drawing.Point(16, 138)
        Me.faultyTextBox.Name = "faultyTextBox"
        Me.faultyTextBox.Size = New System.Drawing.Size(239, 27)
        Me.faultyTextBox.TabIndex = 3
        '
        'saveSettingsButton
        '
        Me.saveSettingsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveSettingsButton.Location = New System.Drawing.Point(100, 527)
        Me.saveSettingsButton.Name = "saveSettingsButton"
        Me.saveSettingsButton.Size = New System.Drawing.Size(156, 32)
        Me.saveSettingsButton.TabIndex = 15
        Me.saveSettingsButton.Text = "Save Settings"
        Me.saveSettingsButton.UseVisualStyleBackColor = True
        '
        'clearButton
        '
        Me.clearButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clearButton.Location = New System.Drawing.Point(319, 527)
        Me.clearButton.Name = "clearButton"
        Me.clearButton.Size = New System.Drawing.Size(75, 32)
        Me.clearButton.TabIndex = 16
        Me.clearButton.Text = "Clear"
        Me.clearButton.UseVisualStyleBackColor = True
        '
        'deleteCheckBox
        '
        Me.deleteCheckBox.AutoSize = True
        Me.deleteCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deleteCheckBox.Location = New System.Drawing.Point(453, 497)
        Me.deleteCheckBox.Name = "deleteCheckBox"
        Me.deleteCheckBox.Size = New System.Drawing.Size(18, 17)
        Me.deleteCheckBox.TabIndex = 14
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
        Me.nameTextBox.TabIndex = 1
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
        Me.Label7.Location = New System.Drawing.Point(317, 327)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 20)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Email Layout:"
        '
        'upButton
        '
        Me.upButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.upButton.Location = New System.Drawing.Point(432, 353)
        Me.upButton.Name = "upButton"
        Me.upButton.Size = New System.Drawing.Size(72, 29)
        Me.upButton.TabIndex = 11
        Me.upButton.Text = "Up"
        Me.upButton.UseVisualStyleBackColor = True
        '
        'downButton
        '
        Me.downButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.downButton.Location = New System.Drawing.Point(432, 388)
        Me.downButton.Name = "downButton"
        Me.downButton.Size = New System.Drawing.Size(72, 29)
        Me.downButton.TabIndex = 12
        Me.downButton.Text = "Down"
        Me.downButton.UseVisualStyleBackColor = True
        '
        'emailLayoutListBox
        '
        Me.emailLayoutListBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.emailLayoutListBox.FormattingEnabled = True
        Me.emailLayoutListBox.ItemHeight = 20
        Me.emailLayoutListBox.Location = New System.Drawing.Point(321, 353)
        Me.emailLayoutListBox.Name = "emailLayoutListBox"
        Me.emailLayoutListBox.Size = New System.Drawing.Size(107, 24)
        Me.emailLayoutListBox.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(317, 460)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(179, 20)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Weeks Back to Check:"
        '
        'weeksNumericUpDown
        '
        Me.weeksNumericUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.weeksNumericUpDown.Location = New System.Drawing.Point(500, 458)
        Me.weeksNumericUpDown.Name = "weeksNumericUpDown"
        Me.weeksNumericUpDown.Size = New System.Drawing.Size(53, 27)
        Me.weeksNumericUpDown.TabIndex = 13
        Me.weeksNumericUpDown.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'toTextBox
        '
        Me.toTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.toTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toTextBox.Location = New System.Drawing.Point(16, 191)
        Me.toTextBox.Name = "toTextBox"
        Me.toTextBox.Size = New System.Drawing.Size(239, 27)
        Me.toTextBox.TabIndex = 4
        '
        'toLabel
        '
        Me.toLabel.AutoSize = True
        Me.toLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toLabel.Location = New System.Drawing.Point(12, 168)
        Me.toLabel.Name = "toLabel"
        Me.toLabel.Size = New System.Drawing.Size(178, 20)
        Me.toLabel.TabIndex = 22
        Me.toLabel.Text = "To Site Time Keyword:"
        '
        'awayTextBox
        '
        Me.awayTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.awayTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.awayTextBox.Location = New System.Drawing.Point(15, 297)
        Me.awayTextBox.Name = "awayTextBox"
        Me.awayTextBox.Size = New System.Drawing.Size(239, 27)
        Me.awayTextBox.TabIndex = 6
        '
        'awayLabel
        '
        Me.awayLabel.AutoSize = True
        Me.awayLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.awayLabel.Location = New System.Drawing.Point(11, 274)
        Me.awayLabel.Name = "awayLabel"
        Me.awayLabel.Size = New System.Drawing.Size(243, 20)
        Me.awayLabel.TabIndex = 24
        Me.awayLabel.Text = "Away From Site Time Keyword:"
        '
        'shippingTextBox
        '
        Me.shippingTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.shippingTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.shippingTextBox.Location = New System.Drawing.Point(15, 350)
        Me.shippingTextBox.Name = "shippingTextBox"
        Me.shippingTextBox.Size = New System.Drawing.Size(239, 27)
        Me.shippingTextBox.TabIndex = 7
        '
        'shippingLabel
        '
        Me.shippingLabel.AutoSize = True
        Me.shippingLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.shippingLabel.Location = New System.Drawing.Point(11, 327)
        Me.shippingLabel.Name = "shippingLabel"
        Me.shippingLabel.Size = New System.Drawing.Size(205, 20)
        Me.shippingLabel.TabIndex = 26
        Me.shippingLabel.Text = "Shipping Update Keyword:"
        '
        'blacklistListBox
        '
        Me.blacklistListBox.FormattingEnabled = True
        Me.blacklistListBox.ItemHeight = 16
        Me.blacklistListBox.Location = New System.Drawing.Point(319, 30)
        Me.blacklistListBox.Name = "blacklistListBox"
        Me.blacklistListBox.Size = New System.Drawing.Size(347, 292)
        Me.blacklistListBox.TabIndex = 28
        Me.blacklistListBox.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(317, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 20)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Blacklist:"
        '
        'onsiteTextBox
        '
        Me.onsiteTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.onsiteTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.onsiteTextBox.Location = New System.Drawing.Point(16, 244)
        Me.onsiteTextBox.Name = "onsiteTextBox"
        Me.onsiteTextBox.Size = New System.Drawing.Size(239, 27)
        Me.onsiteTextBox.TabIndex = 5
        '
        'onsiteLabel
        '
        Me.onsiteLabel.AutoSize = True
        Me.onsiteLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.onsiteLabel.Location = New System.Drawing.Point(12, 221)
        Me.onsiteLabel.Name = "onsiteLabel"
        Me.onsiteLabel.Size = New System.Drawing.Size(174, 20)
        Me.onsiteLabel.TabIndex = 31
        Me.onsiteLabel.Text = "Onsite Time Keyword:"
        '
        'browseFolderButton
        '
        Me.browseFolderButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.browseFolderButton.Location = New System.Drawing.Point(100, 436)
        Me.browseFolderButton.Name = "browseFolderButton"
        Me.browseFolderButton.Size = New System.Drawing.Size(156, 31)
        Me.browseFolderButton.TabIndex = 8
        Me.browseFolderButton.Text = "Browse Folders..."
        Me.browseFolderButton.UseVisualStyleBackColor = True
        '
        'nameError
        '
        Me.nameError.BackgroundImage = Global.OneShipper.My.Resources.Resources._error
        Me.nameError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.nameError.Location = New System.Drawing.Point(262, 32)
        Me.nameError.Name = "nameError"
        Me.nameError.Size = New System.Drawing.Size(36, 27)
        Me.nameError.TabIndex = 34
        Me.nameError.TabStop = False
        Me.nameError.Visible = False
        '
        'newPartError
        '
        Me.newPartError.BackgroundImage = Global.OneShipper.My.Resources.Resources._error
        Me.newPartError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.newPartError.Location = New System.Drawing.Point(262, 85)
        Me.newPartError.Name = "newPartError"
        Me.newPartError.Size = New System.Drawing.Size(36, 27)
        Me.newPartError.TabIndex = 35
        Me.newPartError.TabStop = False
        Me.newPartError.Visible = False
        '
        'faultyPartError
        '
        Me.faultyPartError.BackgroundImage = Global.OneShipper.My.Resources.Resources._error
        Me.faultyPartError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.faultyPartError.Location = New System.Drawing.Point(262, 138)
        Me.faultyPartError.Name = "faultyPartError"
        Me.faultyPartError.Size = New System.Drawing.Size(36, 27)
        Me.faultyPartError.TabIndex = 36
        Me.faultyPartError.TabStop = False
        Me.faultyPartError.Visible = False
        '
        'toSiteError
        '
        Me.toSiteError.BackgroundImage = Global.OneShipper.My.Resources.Resources._error
        Me.toSiteError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.toSiteError.Location = New System.Drawing.Point(262, 191)
        Me.toSiteError.Name = "toSiteError"
        Me.toSiteError.Size = New System.Drawing.Size(36, 27)
        Me.toSiteError.TabIndex = 37
        Me.toSiteError.TabStop = False
        Me.toSiteError.Visible = False
        '
        'onsiteError
        '
        Me.onsiteError.BackgroundImage = Global.OneShipper.My.Resources.Resources._error
        Me.onsiteError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.onsiteError.Location = New System.Drawing.Point(262, 244)
        Me.onsiteError.Name = "onsiteError"
        Me.onsiteError.Size = New System.Drawing.Size(36, 27)
        Me.onsiteError.TabIndex = 38
        Me.onsiteError.TabStop = False
        Me.onsiteError.Visible = False
        '
        'awaySiteError
        '
        Me.awaySiteError.BackgroundImage = Global.OneShipper.My.Resources.Resources._error
        Me.awaySiteError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.awaySiteError.Location = New System.Drawing.Point(262, 297)
        Me.awaySiteError.Name = "awaySiteError"
        Me.awaySiteError.Size = New System.Drawing.Size(36, 27)
        Me.awaySiteError.TabIndex = 39
        Me.awaySiteError.TabStop = False
        Me.awaySiteError.Visible = False
        '
        'shippingError
        '
        Me.shippingError.BackgroundImage = Global.OneShipper.My.Resources.Resources._error
        Me.shippingError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.shippingError.Location = New System.Drawing.Point(262, 350)
        Me.shippingError.Name = "shippingError"
        Me.shippingError.Size = New System.Drawing.Size(36, 27)
        Me.shippingError.TabIndex = 40
        Me.shippingError.TabStop = False
        Me.shippingError.Visible = False
        '
        'blackListContextMenuStrip
        '
        Me.blackListContextMenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.blackListContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteBlacklistedItemToolStripMenuItem})
        Me.blackListContextMenuStrip.Name = "blackListContextMenuStrip"
        Me.blackListContextMenuStrip.Size = New System.Drawing.Size(238, 30)
        '
        'DeleteBlacklistedItemToolStripMenuItem
        '
        Me.DeleteBlacklistedItemToolStripMenuItem.Name = "DeleteBlacklistedItemToolStripMenuItem"
        Me.DeleteBlacklistedItemToolStripMenuItem.Size = New System.Drawing.Size(237, 26)
        Me.DeleteBlacklistedItemToolStripMenuItem.Text = "Delete Blacklisted Item"
        '
        'folderError
        '
        Me.folderError.BackgroundImage = Global.OneShipper.My.Resources.Resources._error
        Me.folderError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.folderError.Location = New System.Drawing.Point(262, 403)
        Me.folderError.Name = "folderError"
        Me.folderError.Size = New System.Drawing.Size(36, 27)
        Me.folderError.TabIndex = 41
        Me.folderError.TabStop = False
        Me.folderError.Visible = False
        '
        'Configuration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 580)
        Me.Controls.Add(Me.folderError)
        Me.Controls.Add(Me.shippingError)
        Me.Controls.Add(Me.awaySiteError)
        Me.Controls.Add(Me.onsiteError)
        Me.Controls.Add(Me.toSiteError)
        Me.Controls.Add(Me.faultyPartError)
        Me.Controls.Add(Me.newPartError)
        Me.Controls.Add(Me.nameError)
        Me.Controls.Add(Me.browseFolderButton)
        Me.Controls.Add(Me.onsiteTextBox)
        Me.Controls.Add(Me.onsiteLabel)
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
        Me.Controls.Add(Me.clearButton)
        Me.Controls.Add(Me.saveSettingsButton)
        Me.Controls.Add(Me.faultyTextBox)
        Me.Controls.Add(Me.newTextBox)
        Me.Controls.Add(Me.folderTextBox)
        Me.Controls.Add(Me.faultyLabel)
        Me.Controls.Add(Me.newLabel)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.folderLabel)
        Me.Name = "Configuration"
        Me.Text = "Configuration"
        CType(Me.weeksNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nameError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.newPartError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.faultyPartError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.toSiteError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.onsiteError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.awaySiteError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.shippingError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.blackListContextMenuStrip.ResumeLayout(False)
        CType(Me.folderError, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents clearButton As Button
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
    Friend WithEvents onsiteTextBox As TextBox
    Friend WithEvents onsiteLabel As Label
    Friend WithEvents browseFolderButton As Button
    Friend WithEvents nameError As PictureBox
    Friend WithEvents newPartError As PictureBox
    Friend WithEvents faultyPartError As PictureBox
    Friend WithEvents toSiteError As PictureBox
    Friend WithEvents onsiteError As PictureBox
    Friend WithEvents awaySiteError As PictureBox
    Friend WithEvents shippingError As PictureBox
    Friend WithEvents blackListContextMenuStrip As ContextMenuStrip
    Friend WithEvents DeleteBlacklistedItemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents folderError As PictureBox
End Class
