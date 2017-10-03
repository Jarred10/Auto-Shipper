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
        Me.installedSerialTextBox = New System.Windows.Forms.TextBox()
        Me.installedAssetTextBox = New System.Windows.Forms.TextBox()
        Me.saveSettingsButton = New System.Windows.Forms.Button()
        Me.clearButton = New System.Windows.Forms.Button()
        Me.deleteCheckBox = New System.Windows.Forms.CheckBox()
        Me.nameTextBox = New System.Windows.Forms.TextBox()
        Me.nameLabel = New System.Windows.Forms.Label()
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
        Me.installedSerialError = New System.Windows.Forms.PictureBox()
        Me.installedAssetError = New System.Windows.Forms.PictureBox()
        Me.toSiteError = New System.Windows.Forms.PictureBox()
        Me.onsiteError = New System.Windows.Forms.PictureBox()
        Me.awaySiteError = New System.Windows.Forms.PictureBox()
        Me.shippingError = New System.Windows.Forms.PictureBox()
        Me.blackListContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteBlacklistedItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.folderError = New System.Windows.Forms.PictureBox()
        Me.faultySerialError = New System.Windows.Forms.PictureBox()
        Me.faultySerialTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.faultyAssetError = New System.Windows.Forms.PictureBox()
        Me.faultyAssetTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.offsiteError = New System.Windows.Forms.PictureBox()
        Me.offsiteTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.faultError = New System.Windows.Forms.PictureBox()
        Me.faultTextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.weeksNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nameError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.installedSerialError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.installedAssetError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.toSiteError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.onsiteError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.awaySiteError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.shippingError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.blackListContextMenuStrip.SuspendLayout()
        CType(Me.folderError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.faultySerialError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.faultyAssetError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.offsiteError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.faultError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'folderLabel
        '
        Me.folderLabel.AutoSize = True
        Me.folderLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.folderLabel.Location = New System.Drawing.Point(318, 398)
        Me.folderLabel.Name = "folderLabel"
        Me.folderLabel.Size = New System.Drawing.Size(221, 20)
        Me.folderLabel.TabIndex = 1
        Me.folderLabel.Text = "Shipping Documents Folder:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(317, 364)
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
        Me.newLabel.Size = New System.Drawing.Size(257, 20)
        Me.newLabel.TabIndex = 3
        Me.newLabel.Text = "Installed Serial Number Keyword:"
        '
        'faultyLabel
        '
        Me.faultyLabel.AutoSize = True
        Me.faultyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.faultyLabel.Location = New System.Drawing.Point(12, 115)
        Me.faultyLabel.Name = "faultyLabel"
        Me.faultyLabel.Size = New System.Drawing.Size(226, 20)
        Me.faultyLabel.TabIndex = 4
        Me.faultyLabel.Text = "Installed Asset Tag Keyword:"
        '
        'folderTextBox
        '
        Me.folderTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.folderTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.folderTextBox.Location = New System.Drawing.Point(321, 421)
        Me.folderTextBox.Name = "folderTextBox"
        Me.folderTextBox.ReadOnly = True
        Me.folderTextBox.Size = New System.Drawing.Size(240, 27)
        Me.folderTextBox.TabIndex = 0
        Me.folderTextBox.TabStop = False
        '
        'installedSerialTextBox
        '
        Me.installedSerialTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.installedSerialTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.installedSerialTextBox.Location = New System.Drawing.Point(16, 85)
        Me.installedSerialTextBox.Name = "installedSerialTextBox"
        Me.installedSerialTextBox.Size = New System.Drawing.Size(239, 27)
        Me.installedSerialTextBox.TabIndex = 2
        '
        'installedAssetTextBox
        '
        Me.installedAssetTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.installedAssetTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.installedAssetTextBox.Location = New System.Drawing.Point(16, 138)
        Me.installedAssetTextBox.Name = "installedAssetTextBox"
        Me.installedAssetTextBox.Size = New System.Drawing.Size(239, 27)
        Me.installedAssetTextBox.TabIndex = 3
        '
        'saveSettingsButton
        '
        Me.saveSettingsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveSettingsButton.Location = New System.Drawing.Point(102, 683)
        Me.saveSettingsButton.Name = "saveSettingsButton"
        Me.saveSettingsButton.Size = New System.Drawing.Size(156, 32)
        Me.saveSettingsButton.TabIndex = 15
        Me.saveSettingsButton.Text = "Save Settings"
        Me.saveSettingsButton.UseVisualStyleBackColor = True
        '
        'clearButton
        '
        Me.clearButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clearButton.Location = New System.Drawing.Point(319, 683)
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
        Me.deleteCheckBox.Location = New System.Drawing.Point(453, 367)
        Me.deleteCheckBox.Name = "deleteCheckBox"
        Me.deleteCheckBox.Size = New System.Drawing.Size(18, 17)
        Me.deleteCheckBox.TabIndex = 13
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(317, 330)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(179, 20)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Weeks Back to Check:"
        '
        'weeksNumericUpDown
        '
        Me.weeksNumericUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.weeksNumericUpDown.Location = New System.Drawing.Point(500, 328)
        Me.weeksNumericUpDown.Name = "weeksNumericUpDown"
        Me.weeksNumericUpDown.Size = New System.Drawing.Size(53, 27)
        Me.weeksNumericUpDown.TabIndex = 12
        Me.weeksNumericUpDown.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'toTextBox
        '
        Me.toTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.toTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toTextBox.Location = New System.Drawing.Point(17, 305)
        Me.toTextBox.Name = "toTextBox"
        Me.toTextBox.Size = New System.Drawing.Size(239, 27)
        Me.toTextBox.TabIndex = 6
        '
        'toLabel
        '
        Me.toLabel.AutoSize = True
        Me.toLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toLabel.Location = New System.Drawing.Point(13, 282)
        Me.toLabel.Name = "toLabel"
        Me.toLabel.Size = New System.Drawing.Size(187, 20)
        Me.toLabel.TabIndex = 22
        Me.toLabel.Text = "Travel To Site Keyword:"
        '
        'awayTextBox
        '
        Me.awayTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.awayTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.awayTextBox.Location = New System.Drawing.Point(19, 463)
        Me.awayTextBox.Name = "awayTextBox"
        Me.awayTextBox.Size = New System.Drawing.Size(239, 27)
        Me.awayTextBox.TabIndex = 9
        '
        'awayLabel
        '
        Me.awayLabel.AutoSize = True
        Me.awayLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.awayLabel.Location = New System.Drawing.Point(15, 440)
        Me.awayLabel.Name = "awayLabel"
        Me.awayLabel.Size = New System.Drawing.Size(252, 20)
        Me.awayLabel.TabIndex = 24
        Me.awayLabel.Text = "Travel Away From Site Keyword:"
        '
        'shippingTextBox
        '
        Me.shippingTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.shippingTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.shippingTextBox.Location = New System.Drawing.Point(19, 569)
        Me.shippingTextBox.Name = "shippingTextBox"
        Me.shippingTextBox.Size = New System.Drawing.Size(239, 27)
        Me.shippingTextBox.TabIndex = 11
        '
        'shippingLabel
        '
        Me.shippingLabel.AutoSize = True
        Me.shippingLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.shippingLabel.Location = New System.Drawing.Point(15, 546)
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
        Me.onsiteTextBox.Location = New System.Drawing.Point(19, 357)
        Me.onsiteTextBox.Name = "onsiteTextBox"
        Me.onsiteTextBox.Size = New System.Drawing.Size(239, 27)
        Me.onsiteTextBox.TabIndex = 7
        '
        'onsiteLabel
        '
        Me.onsiteLabel.AutoSize = True
        Me.onsiteLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.onsiteLabel.Location = New System.Drawing.Point(15, 334)
        Me.onsiteLabel.Name = "onsiteLabel"
        Me.onsiteLabel.Size = New System.Drawing.Size(174, 20)
        Me.onsiteLabel.TabIndex = 31
        Me.onsiteLabel.Text = "Onsite Time Keyword:"
        '
        'browseFolderButton
        '
        Me.browseFolderButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.browseFolderButton.Location = New System.Drawing.Point(405, 459)
        Me.browseFolderButton.Name = "browseFolderButton"
        Me.browseFolderButton.Size = New System.Drawing.Size(156, 31)
        Me.browseFolderButton.TabIndex = 14
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
        'installedSerialError
        '
        Me.installedSerialError.BackgroundImage = Global.OneShipper.My.Resources.Resources._error
        Me.installedSerialError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.installedSerialError.Location = New System.Drawing.Point(262, 85)
        Me.installedSerialError.Name = "installedSerialError"
        Me.installedSerialError.Size = New System.Drawing.Size(36, 27)
        Me.installedSerialError.TabIndex = 35
        Me.installedSerialError.TabStop = False
        Me.installedSerialError.Visible = False
        '
        'installedAssetError
        '
        Me.installedAssetError.BackgroundImage = Global.OneShipper.My.Resources.Resources._error
        Me.installedAssetError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.installedAssetError.Location = New System.Drawing.Point(262, 138)
        Me.installedAssetError.Name = "installedAssetError"
        Me.installedAssetError.Size = New System.Drawing.Size(36, 27)
        Me.installedAssetError.TabIndex = 36
        Me.installedAssetError.TabStop = False
        Me.installedAssetError.Visible = False
        '
        'toSiteError
        '
        Me.toSiteError.BackgroundImage = Global.OneShipper.My.Resources.Resources._error
        Me.toSiteError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.toSiteError.Location = New System.Drawing.Point(263, 305)
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
        Me.onsiteError.Location = New System.Drawing.Point(265, 357)
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
        Me.awaySiteError.Location = New System.Drawing.Point(266, 463)
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
        Me.shippingError.Location = New System.Drawing.Point(266, 569)
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
        Me.blackListContextMenuStrip.Size = New System.Drawing.Size(232, 28)
        '
        'DeleteBlacklistedItemToolStripMenuItem
        '
        Me.DeleteBlacklistedItemToolStripMenuItem.Name = "DeleteBlacklistedItemToolStripMenuItem"
        Me.DeleteBlacklistedItemToolStripMenuItem.Size = New System.Drawing.Size(231, 24)
        Me.DeleteBlacklistedItemToolStripMenuItem.Text = "Delete Blacklisted Item"
        '
        'folderError
        '
        Me.folderError.BackgroundImage = Global.OneShipper.My.Resources.Resources._error
        Me.folderError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.folderError.Location = New System.Drawing.Point(567, 421)
        Me.folderError.Name = "folderError"
        Me.folderError.Size = New System.Drawing.Size(36, 27)
        Me.folderError.TabIndex = 41
        Me.folderError.TabStop = False
        Me.folderError.Visible = False
        '
        'faultySerialError
        '
        Me.faultySerialError.BackgroundImage = Global.OneShipper.My.Resources.Resources._error
        Me.faultySerialError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.faultySerialError.Location = New System.Drawing.Point(262, 193)
        Me.faultySerialError.Name = "faultySerialError"
        Me.faultySerialError.Size = New System.Drawing.Size(36, 27)
        Me.faultySerialError.TabIndex = 44
        Me.faultySerialError.TabStop = False
        Me.faultySerialError.Visible = False
        '
        'faultySerialTextBox
        '
        Me.faultySerialTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.faultySerialTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.faultySerialTextBox.Location = New System.Drawing.Point(16, 193)
        Me.faultySerialTextBox.Name = "faultySerialTextBox"
        Me.faultySerialTextBox.Size = New System.Drawing.Size(239, 27)
        Me.faultySerialTextBox.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 170)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(240, 20)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Faulty Serial Number Keyword:"
        '
        'faultyAssetError
        '
        Me.faultyAssetError.BackgroundImage = Global.OneShipper.My.Resources.Resources._error
        Me.faultyAssetError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.faultyAssetError.Location = New System.Drawing.Point(262, 247)
        Me.faultyAssetError.Name = "faultyAssetError"
        Me.faultyAssetError.Size = New System.Drawing.Size(36, 27)
        Me.faultyAssetError.TabIndex = 47
        Me.faultyAssetError.TabStop = False
        Me.faultyAssetError.Visible = False
        '
        'faultyAssetTextBox
        '
        Me.faultyAssetTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.faultyAssetTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.faultyAssetTextBox.Location = New System.Drawing.Point(16, 247)
        Me.faultyAssetTextBox.Name = "faultyAssetTextBox"
        Me.faultyAssetTextBox.Size = New System.Drawing.Size(239, 27)
        Me.faultyAssetTextBox.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 224)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(206, 20)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Faulty Asset Tag Ketword:"
        '
        'offsiteError
        '
        Me.offsiteError.BackgroundImage = Global.OneShipper.My.Resources.Resources._error
        Me.offsiteError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.offsiteError.Location = New System.Drawing.Point(265, 409)
        Me.offsiteError.Name = "offsiteError"
        Me.offsiteError.Size = New System.Drawing.Size(36, 27)
        Me.offsiteError.TabIndex = 50
        Me.offsiteError.TabStop = False
        Me.offsiteError.Visible = False
        '
        'offsiteTextBox
        '
        Me.offsiteTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.offsiteTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.offsiteTextBox.Location = New System.Drawing.Point(19, 409)
        Me.offsiteTextBox.Name = "offsiteTextBox"
        Me.offsiteTextBox.Size = New System.Drawing.Size(239, 27)
        Me.offsiteTextBox.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 386)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(175, 20)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Offsite Time Keyword:"
        '
        'faultError
        '
        Me.faultError.BackgroundImage = Global.OneShipper.My.Resources.Resources._error
        Me.faultError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.faultError.Location = New System.Drawing.Point(268, 516)
        Me.faultError.Name = "faultError"
        Me.faultError.Size = New System.Drawing.Size(36, 27)
        Me.faultError.TabIndex = 53
        Me.faultError.TabStop = False
        Me.faultError.Visible = False
        '
        'faultTextBox
        '
        Me.faultTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.faultTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.faultTextBox.Location = New System.Drawing.Point(21, 516)
        Me.faultTextBox.Name = "faultTextBox"
        Me.faultTextBox.Size = New System.Drawing.Size(239, 27)
        Me.faultTextBox.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 493)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(211, 20)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "Fault Description Keyword:"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(453, 683)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(156, 32)
        Me.Button1.TabIndex = 54
        Me.Button1.Text = "Default"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Configuration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 735)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.faultError)
        Me.Controls.Add(Me.faultTextBox)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.offsiteError)
        Me.Controls.Add(Me.offsiteTextBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.faultyAssetError)
        Me.Controls.Add(Me.faultyAssetTextBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.faultySerialError)
        Me.Controls.Add(Me.faultySerialTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.folderError)
        Me.Controls.Add(Me.shippingError)
        Me.Controls.Add(Me.awaySiteError)
        Me.Controls.Add(Me.onsiteError)
        Me.Controls.Add(Me.toSiteError)
        Me.Controls.Add(Me.installedAssetError)
        Me.Controls.Add(Me.installedSerialError)
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
        Me.Controls.Add(Me.nameTextBox)
        Me.Controls.Add(Me.nameLabel)
        Me.Controls.Add(Me.deleteCheckBox)
        Me.Controls.Add(Me.clearButton)
        Me.Controls.Add(Me.saveSettingsButton)
        Me.Controls.Add(Me.installedAssetTextBox)
        Me.Controls.Add(Me.installedSerialTextBox)
        Me.Controls.Add(Me.folderTextBox)
        Me.Controls.Add(Me.faultyLabel)
        Me.Controls.Add(Me.newLabel)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.folderLabel)
        Me.Name = "Configuration"
        Me.Text = "Configuration"
        CType(Me.weeksNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nameError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.installedSerialError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.installedAssetError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.toSiteError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.onsiteError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.awaySiteError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.shippingError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.blackListContextMenuStrip.ResumeLayout(False)
        CType(Me.folderError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.faultySerialError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.faultyAssetError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.offsiteError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.faultError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents folderLabel As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents newLabel As Label
    Friend WithEvents faultyLabel As Label
    Friend WithEvents folderTextBox As TextBox
    Friend WithEvents installedSerialTextBox As TextBox
    Friend WithEvents installedAssetTextBox As TextBox
    Friend WithEvents saveSettingsButton As Button
    Friend WithEvents clearButton As Button
    Friend WithEvents deleteCheckBox As CheckBox
    Friend WithEvents nameTextBox As TextBox
    Friend WithEvents nameLabel As Label
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
    Friend WithEvents installedSerialError As PictureBox
    Friend WithEvents installedAssetError As PictureBox
    Friend WithEvents toSiteError As PictureBox
    Friend WithEvents onsiteError As PictureBox
    Friend WithEvents awaySiteError As PictureBox
    Friend WithEvents shippingError As PictureBox
    Friend WithEvents blackListContextMenuStrip As ContextMenuStrip
    Friend WithEvents DeleteBlacklistedItemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents folderError As PictureBox
    Friend WithEvents faultySerialError As PictureBox
    Friend WithEvents faultySerialTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents faultyAssetError As PictureBox
    Friend WithEvents faultyAssetTextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents offsiteError As PictureBox
    Friend WithEvents offsiteTextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents faultError As PictureBox
    Friend WithEvents faultTextBox As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Button1 As Button
End Class
