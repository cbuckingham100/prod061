<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTTOTrackingSystem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTTOTrackingSystem))
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblTTO = New System.Windows.Forms.Label()
        Me.txtSerialNumber = New System.Windows.Forms.TextBox()
        Me.lblPrinterType = New System.Windows.Forms.Label()
        Me.txtPrinterType = New System.Windows.Forms.TextBox()
        Me.btnComplete1 = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.grpMachine1 = New System.Windows.Forms.GroupBox()
        Me.grpMachine2 = New System.Windows.Forms.GroupBox()
        Me.btnComplete2 = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblVersion = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMachine1.SuspendLayout()
        Me.grpMachine2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(153, 35)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(279, 26)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "TTO Component Tracking"
        '
        'lblTTO
        '
        Me.lblTTO.AutoSize = True
        Me.lblTTO.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTTO.Location = New System.Drawing.Point(13, 100)
        Me.lblTTO.Name = "lblTTO"
        Me.lblTTO.Size = New System.Drawing.Size(120, 19)
        Me.lblTTO.TabIndex = 1
        Me.lblTTO.Text = "TTO Serial No:"
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.txtSerialNumber.Location = New System.Drawing.Point(192, 100)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(250, 26)
        Me.txtSerialNumber.TabIndex = 2
        '
        'lblPrinterType
        '
        Me.lblPrinterType.AutoSize = True
        Me.lblPrinterType.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblPrinterType.Location = New System.Drawing.Point(13, 150)
        Me.lblPrinterType.Name = "lblPrinterType"
        Me.lblPrinterType.Size = New System.Drawing.Size(107, 19)
        Me.lblPrinterType.TabIndex = 3
        Me.lblPrinterType.Text = "Printer Type:"
        '
        'txtPrinterType
        '
        Me.txtPrinterType.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.txtPrinterType.Location = New System.Drawing.Point(192, 150)
        Me.txtPrinterType.Name = "txtPrinterType"
        Me.txtPrinterType.ReadOnly = True
        Me.txtPrinterType.Size = New System.Drawing.Size(250, 26)
        Me.txtPrinterType.TabIndex = 4
        '
        'btnComplete1
        '
        Me.btnComplete1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.btnComplete1.Location = New System.Drawing.Point(487, 185)
        Me.btnComplete1.Name = "btnComplete1"
        Me.btnComplete1.Size = New System.Drawing.Size(120, 33)
        Me.btnComplete1.TabIndex = 5
        Me.btnComplete1.Text = "Complete"
        Me.btnComplete1.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.btnClear.Location = New System.Drawing.Point(505, 147)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(120, 33)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "Clear All"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(505, 27)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(120, 50)
        Me.PictureBox1.TabIndex = 103
        Me.PictureBox1.TabStop = False
        '
        'grpMachine1
        '
        Me.grpMachine1.Controls.Add(Me.btnComplete1)
        Me.grpMachine1.Location = New System.Drawing.Point(12, 199)
        Me.grpMachine1.Name = "grpMachine1"
        Me.grpMachine1.Size = New System.Drawing.Size(613, 235)
        Me.grpMachine1.TabIndex = 104
        Me.grpMachine1.TabStop = False
        Me.grpMachine1.Text = "Bench 2"
        '
        'grpMachine2
        '
        Me.grpMachine2.Controls.Add(Me.btnComplete2)
        Me.grpMachine2.Location = New System.Drawing.Point(12, 447)
        Me.grpMachine2.Name = "grpMachine2"
        Me.grpMachine2.Size = New System.Drawing.Size(613, 191)
        Me.grpMachine2.TabIndex = 105
        Me.grpMachine2.TabStop = False
        Me.grpMachine2.Text = "Bench 4"
        '
        'btnComplete2
        '
        Me.btnComplete2.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.btnComplete2.Location = New System.Drawing.Point(487, 145)
        Me.btnComplete2.Name = "btnComplete2"
        Me.btnComplete2.Size = New System.Drawing.Size(120, 30)
        Me.btnComplete2.TabIndex = 7
        Me.btnComplete2.Text = "Complete"
        Me.btnComplete2.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(637, 24)
        Me.MenuStrip1.TabIndex = 106
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(44, 20)
        Me.ToolStripMenuItem1.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.AboutToolStripMenuItem.Text = "Report"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(14, 645)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(68, 16)
        Me.lblVersion.TabIndex = 107
        Me.lblVersion.Text = "lblVersion"
        '
        'frmTTOTrackingSystem
        '
        Me.ClientSize = New System.Drawing.Size(637, 670)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.grpMachine1)
        Me.Controls.Add(Me.grpMachine2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.lblTTO)
        Me.Controls.Add(Me.txtSerialNumber)
        Me.Controls.Add(Me.lblPrinterType)
        Me.Controls.Add(Me.txtPrinterType)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmTTOTrackingSystem"
        Me.Text = "TTO Serial Number Tracking System"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMachine1.ResumeLayout(False)
        Me.grpMachine2.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    ' Declare form controls
    Friend WithEvents lblHeader As Label
    Friend WithEvents lblTTO As Label
    Friend WithEvents txtSerialNumber As TextBox
    Friend WithEvents lblPrinterType As Label
    Friend WithEvents txtPrinterType As TextBox
    Friend WithEvents btnComplete1 As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents grpMachine1 As GroupBox
    Friend WithEvents grpMachine2 As GroupBox
    Friend WithEvents btnComplete2 As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblVersion As Label
End Class
