<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMDI
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.JobsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PDFPageCountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CDAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RenameExportedImageNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageCorruptionCheckingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GenerateBranchFileFromFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CreateGapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.JobsToolStripMenuItem, Me.CDAToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1303, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'JobsToolStripMenuItem
        '
        Me.JobsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PDFPageCountToolStripMenuItem})
        Me.JobsToolStripMenuItem.Name = "JobsToolStripMenuItem"
        Me.JobsToolStripMenuItem.Size = New System.Drawing.Size(42, 20)
        Me.JobsToolStripMenuItem.Text = "Jobs"
        '
        'PDFPageCountToolStripMenuItem
        '
        Me.PDFPageCountToolStripMenuItem.Name = "PDFPageCountToolStripMenuItem"
        Me.PDFPageCountToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.PDFPageCountToolStripMenuItem.Text = "PDF Page Count "
        '
        'CDAToolStripMenuItem
        '
        Me.CDAToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RenameExportedImageNameToolStripMenuItem, Me.ImageCorruptionCheckingToolStripMenuItem, Me.GenerateBranchFileFromFolderToolStripMenuItem, Me.CreateGapToolStripMenuItem})
        Me.CDAToolStripMenuItem.Name = "CDAToolStripMenuItem"
        Me.CDAToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.CDAToolStripMenuItem.Text = "CDA"
        '
        'RenameExportedImageNameToolStripMenuItem
        '
        Me.RenameExportedImageNameToolStripMenuItem.Name = "RenameExportedImageNameToolStripMenuItem"
        Me.RenameExportedImageNameToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.RenameExportedImageNameToolStripMenuItem.Text = "Rename Exported Image Name"
        '
        'ImageCorruptionCheckingToolStripMenuItem
        '
        Me.ImageCorruptionCheckingToolStripMenuItem.Name = "ImageCorruptionCheckingToolStripMenuItem"
        Me.ImageCorruptionCheckingToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.ImageCorruptionCheckingToolStripMenuItem.Text = "Image Corruption Checking"
        '
        'GenerateBranchFileFromFolderToolStripMenuItem
        '
        Me.GenerateBranchFileFromFolderToolStripMenuItem.Name = "GenerateBranchFileFromFolderToolStripMenuItem"
        Me.GenerateBranchFileFromFolderToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.GenerateBranchFileFromFolderToolStripMenuItem.Text = "Generate Branch File From Folder"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'CreateGapToolStripMenuItem
        '
        Me.CreateGapToolStripMenuItem.Name = "CreateGapToolStripMenuItem"
        Me.CreateGapToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.CreateGapToolStripMenuItem.Text = "Create Gap(Image Numbering)"
        '
        'frmMDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1303, 510)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMDI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMDI"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents JobsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PDFPageCountToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CDAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenameExportedImageNameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageCorruptionCheckingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerateBranchFileFromFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateGapToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
