<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPDFPageCount
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
        Me.chkDeleteCorruptedPDF = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnProcessFileCount = New System.Windows.Forms.Button
        Me.rptPDFs = New System.Windows.Forms.RadioButton
        Me.rptAll = New System.Windows.Forms.RadioButton
        Me.lblCSVPath = New System.Windows.Forms.Label
        Me.btnPGCountSubDir = New System.Windows.Forms.Button
        Me.btnMergePDF = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnProcess = New System.Windows.Forms.Button
        Me.lblFileName = New System.Windows.Forms.Label
        Me.txtOutputFileNm = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.btnSelectPath = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.GrpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpMain
        '
        Me.GrpMain.Controls.Add(Me.chkDeleteCorruptedPDF)
        Me.GrpMain.Controls.Add(Me.Label3)
        Me.GrpMain.Controls.Add(Me.btnProcessFileCount)
        Me.GrpMain.Controls.Add(Me.rptPDFs)
        Me.GrpMain.Controls.Add(Me.rptAll)
        Me.GrpMain.Controls.Add(Me.lblCSVPath)
        Me.GrpMain.Controls.Add(Me.btnPGCountSubDir)
        Me.GrpMain.Controls.Add(Me.btnMergePDF)
        Me.GrpMain.Controls.Add(Me.btnExit)
        Me.GrpMain.Controls.Add(Me.btnProcess)
        Me.GrpMain.Controls.Add(Me.lblFileName)
        Me.GrpMain.Controls.Add(Me.txtOutputFileNm)
        Me.GrpMain.Controls.Add(Me.Label2)
        Me.GrpMain.Controls.Add(Me.txtPath)
        Me.GrpMain.Controls.Add(Me.btnSelectPath)
        Me.GrpMain.Controls.Add(Me.Label1)
        Me.GrpMain.Location = New System.Drawing.Point(22, 31)
        Me.GrpMain.Name = "GrpMain"
        Me.GrpMain.Size = New System.Drawing.Size(616, 313)
        Me.GrpMain.TabIndex = 0
        Me.GrpMain.TabStop = False
        '
        'chkDeleteCorruptedPDF
        '
        Me.chkDeleteCorruptedPDF.AutoSize = True
        Me.chkDeleteCorruptedPDF.Location = New System.Drawing.Point(357, 68)
        Me.chkDeleteCorruptedPDF.Name = "chkDeleteCorruptedPDF"
        Me.chkDeleteCorruptedPDF.Size = New System.Drawing.Size(133, 17)
        Me.chkDeleteCorruptedPDF.TabIndex = 24
        Me.chkDeleteCorruptedPDF.Text = "Delete Corrupted PDF "
        Me.chkDeleteCorruptedPDF.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(61, 161)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Apply on File Count Process"
        '
        'btnProcessFileCount
        '
        Me.btnProcessFileCount.Enabled = False
        Me.btnProcessFileCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcessFileCount.Location = New System.Drawing.Point(495, 191)
        Me.btnProcessFileCount.Name = "btnProcessFileCount"
        Me.btnProcessFileCount.Size = New System.Drawing.Size(115, 44)
        Me.btnProcessFileCount.TabIndex = 22
        Me.btnProcessFileCount.Text = "&Process Dir/SubDir File Count "
        '
        'rptPDFs
        '
        Me.rptPDFs.AutoSize = True
        Me.rptPDFs.Location = New System.Drawing.Point(323, 159)
        Me.rptPDFs.Name = "rptPDFs"
        Me.rptPDFs.Size = New System.Drawing.Size(66, 17)
        Me.rptPDFs.TabIndex = 21
        Me.rptPDFs.TabStop = True
        Me.rptPDFs.Text = "2> PDFs"
        Me.rptPDFs.UseVisualStyleBackColor = True
        '
        'rptAll
        '
        Me.rptAll.AutoSize = True
        Me.rptAll.Checked = True
        Me.rptAll.Location = New System.Drawing.Point(226, 159)
        Me.rptAll.Name = "rptAll"
        Me.rptAll.Size = New System.Drawing.Size(75, 17)
        Me.rptAll.TabIndex = 20
        Me.rptAll.TabStop = True
        Me.rptAll.Text = "&1> All Files"
        Me.rptAll.UseVisualStyleBackColor = True
        '
        'lblCSVPath
        '
        Me.lblCSVPath.Location = New System.Drawing.Point(30, 256)
        Me.lblCSVPath.Name = "lblCSVPath"
        Me.lblCSVPath.Size = New System.Drawing.Size(580, 42)
        Me.lblCSVPath.TabIndex = 19
        Me.lblCSVPath.Text = "-"
        Me.lblCSVPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnPGCountSubDir
        '
        Me.btnPGCountSubDir.Enabled = False
        Me.btnPGCountSubDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPGCountSubDir.Location = New System.Drawing.Point(346, 191)
        Me.btnPGCountSubDir.Name = "btnPGCountSubDir"
        Me.btnPGCountSubDir.Size = New System.Drawing.Size(143, 44)
        Me.btnPGCountSubDir.TabIndex = 18
        Me.btnPGCountSubDir.Text = "&Process Dir/SubDir Page Count "
        '
        'btnMergePDF
        '
        Me.btnMergePDF.Enabled = False
        Me.btnMergePDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMergePDF.Location = New System.Drawing.Point(173, 191)
        Me.btnMergePDF.Name = "btnMergePDF"
        Me.btnMergePDF.Size = New System.Drawing.Size(80, 44)
        Me.btnMergePDF.TabIndex = 17
        Me.btnMergePDF.Text = "&Merge PDF"
        '
        'btnExit
        '
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(259, 191)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(80, 44)
        Me.btnExit.TabIndex = 6
        Me.btnExit.TabStop = False
        Me.btnExit.Text = "E&xit"
        '
        'btnProcess
        '
        Me.btnProcess.Enabled = False
        Me.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcess.Location = New System.Drawing.Point(21, 191)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(146, 44)
        Me.btnProcess.TabIndex = 5
        Me.btnProcess.Text = "&Process Page Count Current Dir"
        '
        'lblFileName
        '
        Me.lblFileName.ForeColor = System.Drawing.Color.Maroon
        Me.lblFileName.Location = New System.Drawing.Point(17, 108)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(593, 47)
        Me.lblFileName.TabIndex = 16
        Me.lblFileName.Text = "-"
        Me.lblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtOutputFileNm
        '
        Me.txtOutputFileNm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOutputFileNm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOutputFileNm.Location = New System.Drawing.Point(112, 68)
        Me.txtOutputFileNm.Name = "txtOutputFileNm"
        Me.txtOutputFileNm.Size = New System.Drawing.Size(201, 20)
        Me.txtOutputFileNm.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Output File Name"
        '
        'txtPath
        '
        Me.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPath.Location = New System.Drawing.Point(82, 19)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(429, 20)
        Me.txtPath.TabIndex = 1
        '
        'btnSelectPath
        '
        Me.btnSelectPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectPath.Location = New System.Drawing.Point(517, 19)
        Me.btnSelectPath.Name = "btnSelectPath"
        Me.btnSelectPath.Size = New System.Drawing.Size(80, 24)
        Me.btnSelectPath.TabIndex = 2
        Me.btnSelectPath.Text = "Select &Path"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select Path"
        '
        'frmPDFPageCount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 368)
        Me.Controls.Add(Me.GrpMain)
        Me.Name = "frmPDFPageCount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PDF Page Count"
        Me.GrpMain.ResumeLayout(False)
        Me.GrpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpMain As System.Windows.Forms.GroupBox
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents btnSelectPath As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents txtOutputFileNm As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnMergePDF As System.Windows.Forms.Button
    Friend WithEvents btnPGCountSubDir As System.Windows.Forms.Button
    Friend WithEvents lblCSVPath As System.Windows.Forms.Label
    Friend WithEvents rptPDFs As System.Windows.Forms.RadioButton
    Friend WithEvents rptAll As System.Windows.Forms.RadioButton
    Friend WithEvents btnProcessFileCount As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkDeleteCorruptedPDF As System.Windows.Forms.CheckBox

End Class
