<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateImageGap
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
        Me.txtFileNo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbBranch = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnConnect = New System.Windows.Forms.Button
        Me.txtImagePath = New System.Windows.Forms.TextBox
        Me.btnSelectPath = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.GrpSub = New System.Windows.Forms.GroupBox
        Me.btnDisconnect = New System.Windows.Forms.Button
        Me.btnCreateGap = New System.Windows.Forms.Button
        Me.txtImageNewNo = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtImageStartNo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblFileName = New System.Windows.Forms.Label
        Me.lblFolderInfo = New System.Windows.Forms.Label
        Me.GrpMain.SuspendLayout()
        Me.GrpSub.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpMain
        '
        Me.GrpMain.Controls.Add(Me.txtFileNo)
        Me.GrpMain.Controls.Add(Me.Label3)
        Me.GrpMain.Controls.Add(Me.cmbBranch)
        Me.GrpMain.Controls.Add(Me.Label2)
        Me.GrpMain.Controls.Add(Me.btnExit)
        Me.GrpMain.Controls.Add(Me.btnConnect)
        Me.GrpMain.Controls.Add(Me.txtImagePath)
        Me.GrpMain.Controls.Add(Me.btnSelectPath)
        Me.GrpMain.Controls.Add(Me.Label1)
        Me.GrpMain.Location = New System.Drawing.Point(31, 15)
        Me.GrpMain.Name = "GrpMain"
        Me.GrpMain.Size = New System.Drawing.Size(657, 106)
        Me.GrpMain.TabIndex = 1
        Me.GrpMain.TabStop = False
        '
        'txtFileNo
        '
        Me.txtFileNo.Location = New System.Drawing.Point(310, 67)
        Me.txtFileNo.Name = "txtFileNo"
        Me.txtFileNo.Size = New System.Drawing.Size(100, 20)
        Me.txtFileNo.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(253, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "&3> File No"
        '
        'cmbBranch
        '
        Me.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBranch.FormattingEnabled = True
        Me.cmbBranch.Location = New System.Drawing.Point(123, 65)
        Me.cmbBranch.Name = "cmbBranch"
        Me.cmbBranch.Size = New System.Drawing.Size(121, 21)
        Me.cmbBranch.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "&2> Branch"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(501, 63)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(87, 32)
        Me.btnExit.TabIndex = 8
        Me.btnExit.TabStop = False
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnConnect
        '
        Me.btnConnect.Enabled = False
        Me.btnConnect.Location = New System.Drawing.Point(426, 65)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(69, 30)
        Me.btnConnect.TabIndex = 7
        Me.btnConnect.Text = "&Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'txtImagePath
        '
        Me.txtImagePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImagePath.Location = New System.Drawing.Point(123, 34)
        Me.txtImagePath.Name = "txtImagePath"
        Me.txtImagePath.Size = New System.Drawing.Size(467, 20)
        Me.txtImagePath.TabIndex = 1
        '
        'btnSelectPath
        '
        Me.btnSelectPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectPath.Location = New System.Drawing.Point(596, 34)
        Me.btnSelectPath.Name = "btnSelectPath"
        Me.btnSelectPath.Size = New System.Drawing.Size(42, 24)
        Me.btnSelectPath.TabIndex = 2
        Me.btnSelectPath.TabStop = False
        Me.btnSelectPath.Text = "..."
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(2, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "&1> Select Image Path"
        '
        'GrpSub
        '
        Me.GrpSub.Controls.Add(Me.lblFileName)
        Me.GrpSub.Controls.Add(Me.btnDisconnect)
        Me.GrpSub.Controls.Add(Me.btnCreateGap)
        Me.GrpSub.Controls.Add(Me.txtImageNewNo)
        Me.GrpSub.Controls.Add(Me.Label5)
        Me.GrpSub.Controls.Add(Me.txtImageStartNo)
        Me.GrpSub.Controls.Add(Me.Label4)
        Me.GrpSub.Location = New System.Drawing.Point(31, 211)
        Me.GrpSub.Name = "GrpSub"
        Me.GrpSub.Size = New System.Drawing.Size(657, 100)
        Me.GrpSub.TabIndex = 2
        Me.GrpSub.TabStop = False
        '
        'btnDisconnect
        '
        Me.btnDisconnect.Enabled = False
        Me.btnDisconnect.Location = New System.Drawing.Point(530, 34)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(75, 23)
        Me.btnDisconnect.TabIndex = 5
        Me.btnDisconnect.Text = "&Disconnect"
        Me.btnDisconnect.UseVisualStyleBackColor = True
        '
        'btnCreateGap
        '
        Me.btnCreateGap.Enabled = False
        Me.btnCreateGap.Location = New System.Drawing.Point(449, 34)
        Me.btnCreateGap.Name = "btnCreateGap"
        Me.btnCreateGap.Size = New System.Drawing.Size(75, 23)
        Me.btnCreateGap.TabIndex = 4
        Me.btnCreateGap.Text = "Create &Gap"
        Me.btnCreateGap.UseVisualStyleBackColor = True
        '
        'txtImageNewNo
        '
        Me.txtImageNewNo.Location = New System.Drawing.Point(329, 31)
        Me.txtImageNewNo.Name = "txtImageNewNo"
        Me.txtImageNewNo.Size = New System.Drawing.Size(100, 20)
        Me.txtImageNewNo.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(232, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "&5> Image New No"
        '
        'txtImageStartNo
        '
        Me.txtImageStartNo.Location = New System.Drawing.Point(123, 31)
        Me.txtImageStartNo.Name = "txtImageStartNo"
        Me.txtImageStartNo.Size = New System.Drawing.Size(100, 20)
        Me.txtImageStartNo.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "&4> Image Start No"
        '
        'lblFileName
        '
        Me.lblFileName.AutoSize = True
        Me.lblFileName.ForeColor = System.Drawing.Color.Maroon
        Me.lblFileName.Location = New System.Drawing.Point(12, 84)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(10, 13)
        Me.lblFileName.TabIndex = 9
        Me.lblFileName.Text = "-"
        '
        'lblFolderInfo
        '
        Me.lblFolderInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolderInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblFolderInfo.Location = New System.Drawing.Point(33, 124)
        Me.lblFolderInfo.Name = "lblFolderInfo"
        Me.lblFolderInfo.Size = New System.Drawing.Size(655, 90)
        Me.lblFolderInfo.TabIndex = 10
        Me.lblFolderInfo.Text = "-"
        '
        'frmCreateImageGap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(725, 437)
        Me.Controls.Add(Me.lblFolderInfo)
        Me.Controls.Add(Me.GrpSub)
        Me.Controls.Add(Me.GrpMain)
        Me.KeyPreview = True
        Me.Name = "frmCreateImageGap"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create Image Gap"
        Me.GrpMain.ResumeLayout(False)
        Me.GrpMain.PerformLayout()
        Me.GrpSub.ResumeLayout(False)
        Me.GrpSub.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpMain As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents txtImagePath As System.Windows.Forms.TextBox
    Friend WithEvents btnSelectPath As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents txtFileNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbBranch As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GrpSub As System.Windows.Forms.GroupBox
    Friend WithEvents txtImageNewNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtImageStartNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnDisconnect As System.Windows.Forms.Button
    Friend WithEvents btnCreateGap As System.Windows.Forms.Button
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents lblFolderInfo As System.Windows.Forms.Label
End Class
