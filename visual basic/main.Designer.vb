﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class main
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
        Me.getDocButton = New System.Windows.Forms.Button()
        Me.unshippedJobsListBox = New System.Windows.Forms.ListBox()
        Me.jobNumberTextBox = New System.Windows.Forms.TextBox()
        Me.installedSerialTextBox = New System.Windows.Forms.TextBox()
        Me.faultySerialTextBox = New System.Windows.Forms.TextBox()
        Me.faultTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.siteTextBox = New System.Windows.Forms.TextBox()
        Me.produceButton = New System.Windows.Forms.Button()
        Me.printButton = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.jobButton = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.jobTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.itemsContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToBlacklistToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenUpdateEmailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenCalendarAppointmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AttachShipDocToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.installedAssetTextBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.faultyAssetTextBox = New System.Windows.Forms.TextBox()
        Me.fd = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip1.SuspendLayout()
        Me.itemsContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'getDocButton
        '
        Me.getDocButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.getDocButton.Location = New System.Drawing.Point(195, 331)
        Me.getDocButton.Margin = New System.Windows.Forms.Padding(4)
        Me.getDocButton.Name = "getDocButton"
        Me.getDocButton.Size = New System.Drawing.Size(134, 38)
        Me.getDocButton.TabIndex = 19
        Me.getDocButton.Text = "Find Ship Doc"
        Me.getDocButton.UseVisualStyleBackColor = True
        '
        'unshippedJobsListBox
        '
        Me.unshippedJobsListBox.ColumnWidth = 60
        Me.unshippedJobsListBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unshippedJobsListBox.FormattingEnabled = True
        Me.unshippedJobsListBox.HorizontalScrollbar = True
        Me.unshippedJobsListBox.ItemHeight = 20
        Me.unshippedJobsListBox.Location = New System.Drawing.Point(13, 32)
        Me.unshippedJobsListBox.Margin = New System.Windows.Forms.Padding(4)
        Me.unshippedJobsListBox.Name = "unshippedJobsListBox"
        Me.unshippedJobsListBox.Size = New System.Drawing.Size(776, 284)
        Me.unshippedJobsListBox.TabIndex = 1
        '
        'jobNumberTextBox
        '
        Me.jobNumberTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.jobNumberTextBox.Location = New System.Drawing.Point(13, 405)
        Me.jobNumberTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.jobNumberTextBox.Name = "jobNumberTextBox"
        Me.jobNumberTextBox.Size = New System.Drawing.Size(366, 27)
        Me.jobNumberTextBox.TabIndex = 2
        '
        'installedSerialTextBox
        '
        Me.installedSerialTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.installedSerialTextBox.Location = New System.Drawing.Point(13, 460)
        Me.installedSerialTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.installedSerialTextBox.Name = "installedSerialTextBox"
        Me.installedSerialTextBox.Size = New System.Drawing.Size(366, 27)
        Me.installedSerialTextBox.TabIndex = 3
        '
        'faultySerialTextBox
        '
        Me.faultySerialTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.faultySerialTextBox.Location = New System.Drawing.Point(419, 461)
        Me.faultySerialTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.faultySerialTextBox.Name = "faultySerialTextBox"
        Me.faultySerialTextBox.Size = New System.Drawing.Size(370, 27)
        Me.faultySerialTextBox.TabIndex = 4
        '
        'faultTextBox
        '
        Me.faultTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.faultTextBox.Location = New System.Drawing.Point(13, 570)
        Me.faultTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.faultTextBox.Multiline = True
        Me.faultTextBox.Name = "faultTextBox"
        Me.faultTextBox.Size = New System.Drawing.Size(776, 243)
        Me.faultTextBox.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 381)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Job Number:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 437)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(188, 20)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Installed Serial Number:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(415, 437)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(171, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Faulty Serial Number:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 546)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(142, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Fault Description:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(415, 381)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 20)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Site:"
        '
        'siteTextBox
        '
        Me.siteTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.siteTextBox.Location = New System.Drawing.Point(419, 405)
        Me.siteTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.siteTextBox.Name = "siteTextBox"
        Me.siteTextBox.Size = New System.Drawing.Size(366, 27)
        Me.siteTextBox.TabIndex = 11
        '
        'produceButton
        '
        Me.produceButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.produceButton.Location = New System.Drawing.Point(337, 331)
        Me.produceButton.Margin = New System.Windows.Forms.Padding(4)
        Me.produceButton.Name = "produceButton"
        Me.produceButton.Size = New System.Drawing.Size(120, 38)
        Me.produceButton.TabIndex = 15
        Me.produceButton.Text = "Create Forms"
        Me.produceButton.UseVisualStyleBackColor = True
        '
        'printButton
        '
        Me.printButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.printButton.Location = New System.Drawing.Point(465, 331)
        Me.printButton.Margin = New System.Windows.Forms.Padding(4)
        Me.printButton.Name = "printButton"
        Me.printButton.Size = New System.Drawing.Size(106, 38)
        Me.printButton.TabIndex = 16
        Me.printButton.Text = "Print Forms"
        Me.printButton.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(579, 331)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 20)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Job Type:"
        '
        'jobButton
        '
        Me.jobButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.jobButton.Location = New System.Drawing.Point(13, 331)
        Me.jobButton.Margin = New System.Windows.Forms.Padding(4)
        Me.jobButton.Name = "jobButton"
        Me.jobButton.Size = New System.Drawing.Size(174, 38)
        Me.jobButton.TabIndex = 0
        Me.jobButton.Text = "Find Unshipped Jobs"
        Me.jobButton.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(805, 28)
        Me.MenuStrip1.TabIndex = 21
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(44, 24)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(137, 26)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'jobTypeComboBox
        '
        Me.jobTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.jobTypeComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.jobTypeComboBox.FormattingEnabled = True
        Me.jobTypeComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.jobTypeComboBox.Items.AddRange(New Object() {"Foodstuffs", "Lotto", "NZPost", "Other"})
        Me.jobTypeComboBox.Location = New System.Drawing.Point(583, 355)
        Me.jobTypeComboBox.Margin = New System.Windows.Forms.Padding(4)
        Me.jobTypeComboBox.Name = "jobTypeComboBox"
        Me.jobTypeComboBox.Size = New System.Drawing.Size(206, 28)
        Me.jobTypeComboBox.TabIndex = 23
        '
        'itemsContextMenu
        '
        Me.itemsContextMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.itemsContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToBlacklistToolStripMenuItem, Me.OpenUpdateEmailToolStripMenuItem, Me.OpenCalendarAppointmentToolStripMenuItem, Me.AttachShipDocToolStripMenuItem})
        Me.itemsContextMenu.Name = "ContextMenuStrip1"
        Me.itemsContextMenu.Size = New System.Drawing.Size(276, 108)
        '
        'AddToBlacklistToolStripMenuItem
        '
        Me.AddToBlacklistToolStripMenuItem.Name = "AddToBlacklistToolStripMenuItem"
        Me.AddToBlacklistToolStripMenuItem.Size = New System.Drawing.Size(275, 26)
        Me.AddToBlacklistToolStripMenuItem.Text = "Add To Blacklist"
        '
        'OpenUpdateEmailToolStripMenuItem
        '
        Me.OpenUpdateEmailToolStripMenuItem.Name = "OpenUpdateEmailToolStripMenuItem"
        Me.OpenUpdateEmailToolStripMenuItem.Size = New System.Drawing.Size(275, 26)
        Me.OpenUpdateEmailToolStripMenuItem.Text = "Open Update Email"
        '
        'OpenCalendarAppointmentToolStripMenuItem
        '
        Me.OpenCalendarAppointmentToolStripMenuItem.Name = "OpenCalendarAppointmentToolStripMenuItem"
        Me.OpenCalendarAppointmentToolStripMenuItem.Size = New System.Drawing.Size(275, 26)
        Me.OpenCalendarAppointmentToolStripMenuItem.Text = "Open Calendar Appointment"
        '
        'AttachShipDocToolStripMenuItem
        '
        Me.AttachShipDocToolStripMenuItem.Name = "AttachShipDocToolStripMenuItem"
        Me.AttachShipDocToolStripMenuItem.Size = New System.Drawing.Size(275, 26)
        Me.AttachShipDocToolStripMenuItem.Text = "Attach Ship Doc"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 492)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(157, 20)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Installed Asset Tag:"
        '
        'installedAssetTextBox
        '
        Me.installedAssetTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.installedAssetTextBox.Location = New System.Drawing.Point(13, 515)
        Me.installedAssetTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.installedAssetTextBox.Name = "installedAssetTextBox"
        Me.installedAssetTextBox.Size = New System.Drawing.Size(366, 27)
        Me.installedAssetTextBox.TabIndex = 24
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(415, 492)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(140, 20)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Faulty Asset Tag:"
        '
        'faultyAssetTextBox
        '
        Me.faultyAssetTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.faultyAssetTextBox.Location = New System.Drawing.Point(419, 515)
        Me.faultyAssetTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.faultyAssetTextBox.Name = "faultyAssetTextBox"
        Me.faultyAssetTextBox.Size = New System.Drawing.Size(366, 27)
        Me.faultyAssetTextBox.TabIndex = 26
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(805, 827)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.faultyAssetTextBox)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.installedAssetTextBox)
        Me.Controls.Add(Me.jobTypeComboBox)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.jobButton)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.printButton)
        Me.Controls.Add(Me.produceButton)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.siteTextBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.faultTextBox)
        Me.Controls.Add(Me.faultySerialTextBox)
        Me.Controls.Add(Me.installedSerialTextBox)
        Me.Controls.Add(Me.jobNumberTextBox)
        Me.Controls.Add(Me.unshippedJobsListBox)
        Me.Controls.Add(Me.getDocButton)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "main"
        Me.Text = "OneShipper"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.itemsContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents getDocButton As Button
    Friend WithEvents unshippedJobsListBox As ListBox
    Friend WithEvents jobNumberTextBox As TextBox
    Friend WithEvents installedSerialTextBox As TextBox
    Friend WithEvents faultySerialTextBox As TextBox
    Friend WithEvents faultTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents siteTextBox As TextBox
    Friend WithEvents produceButton As Button
    Friend WithEvents printButton As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents jobButton As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents jobTypeComboBox As ComboBox
    Friend WithEvents itemsContextMenu As ContextMenuStrip
    Friend WithEvents AddToBlacklistToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenUpdateEmailToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenCalendarAppointmentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AttachShipDocToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label7 As Label
    Friend WithEvents installedAssetTextBox As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents faultyAssetTextBox As TextBox
    Friend WithEvents fd As OpenFileDialog
End Class
