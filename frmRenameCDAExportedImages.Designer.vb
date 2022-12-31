<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRenameCDAExportedImages
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
        Me.GrpMain = New System.Windows.Forms.GroupBox
        Me.lblFileName = New System.Windows.Forms.Label
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnRenameImages = New System.Windows.Forms.Button
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.btnSelectPath = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.chkForImgCorruption = New System.Windows.Forms.CheckBox
        Me.GrpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpMain
        '
        Me.GrpMain.Controls.Add(Me.chkForImgCorruption)
        Me.GrpMain.Controls.Add(Me.lblFileName)
        Me.GrpMain.Controls.Add(Me.btnExit)
        Me.GrpMain.Controls.Add(Me.btnRenameImages)
        Me.GrpMain.Controls.Add(Me.txtPath)
        Me.GrpMain.Controls.Add(Me.btnSelectPath)
        Me.GrpMain.Controls.Add(Me.Label1)
        Me.GrpMain.Location = New System.Drawing.Point(36, 34)
        Me.GrpMain.Name = "GrpMain"
        Me.GrpMain.Size = New System.Drawing.Size(657, 292)
        Me.GrpMain.TabIndex = 0
        Me.GrpMain.TabStop = False
        '
        'lblFileName
        '
        Me.lblFileName.AutoSize = True
        Me.lblFileName.ForeColor = System.Drawing.Color.Maroon
        Me.lblFileName.Location = New System.Drawing.Point(18, 176)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(10, 13)
        Me.lblFileName.TabIndex = 8
        Me.lblFileName.Text = "-"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(295, 90)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(144, 68)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnRenameImages
        '
        Me.btnRenameImages.Enabled = False
        Me.btnRenameImages.Location = New System.Drawing.Point(163, 90)
        Me.btnRenameImages.Name = "btnRenameImages"
        Me.btnRenameImages.Size = New System.Drawing.Size(125, 68)
        Me.btnRenameImages.TabIndex = 6
        Me.btnRenameImages.Text = "Rename Exported Images"
        Me.btnRenameImages.UseVisualStyleBackColor = True
        '
        'txtPath
        '
        Me.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPath.Location = New System.Drawing.Point(97, 34)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(429, 20)
        Me.txtPath.TabIndex = 4
        '
        'btnSelectPath
        '
        Me.btnSelectPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectPath.Location = New System.Drawing.Point(532, 34)
        Me.btnSelectPath.Name = "btnSelectPath"
        Me.btnSelectPath.Size = New System.Drawing.Size(80, 24)
        Me.btnSelectPath.TabIndex = 5
        Me.btnSelectPath.Text = "Select &Path"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(32, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Select Path"
        '
        'chkForImgCorruption
        '
        Me.chkForImgCorruption.AutoSize = True
        Me.chkForImgCorruption.Location = New System.Drawing.Point(463, 90)
        Me.chkForImgCorruption.Name = "chkForImgCorruption"
        Me.chkForImgCorruption.Size = New System.Drawing.Size(106, 17)
        Me.chkForImgCorruption.TabIndex = 9
        Me.chkForImgCorruption.Text = "Image Corruption"
        Me.chkForImgCorruption.UseVisualStyleBackColor = True
        '
        'frmRenameCDAExportedImages
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(751, 384)
        Me.Controls.Add(Me.GrpMain)
        Me.KeyPreview = True
        Me.Name = "frmRenameCDAExportedImages"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rename CDA Exported Images"
        Me.GrpMain.ResumeLayout(False)
        Me.GrpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpMain As System.Windows.Forms.GroupBox
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents btnSelectPath As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnRenameImages As System.Windows.Forms.Button
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents chkForImgCorruption As System.Windows.Forms.CheckBox
End Class
