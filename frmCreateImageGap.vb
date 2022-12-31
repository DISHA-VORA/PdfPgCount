Imports System.IO
Public Class frmCreateImageGap
    Dim strImgPath As String = ""
    Dim fsLogFileStream As FileStream
    Dim fsLogStreamWriter As StreamWriter
    Dim SrCatalog As StreamReader
    Dim SwCatalog As StreamWriter
    Dim TargetLogFileNm As String = ""
    Dim srBranch As StreamReader
    Dim CatalogFileNm As String = Application.StartupPath & "\GapCatalog.txt"
    Dim ImgFldPath As String = ""
    Dim MinImgNo As Integer = 0
    Dim MaxImgNo As Integer = 0

    Private Sub frmCreateImageGap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'txtImagePath.Text = ExportImgPAth
        Dim Line As String = ""
        Dim BranchFileNm As String = Application.StartupPath & "\Branch.txt"
        Try
            If File.Exists(BranchFileNm) Then
                srBranch = New StreamReader(BranchFileNm)
                Do While IsNothing(srBranch.EndOfStream) = False
                    Line = srBranch.ReadLine
                    If (Line = Nothing AndAlso srBranch.EndOfStream AndAlso Trim(Line) = "") Then
                        Exit Do
                    End If
                    cmbBranch.Items.Add(Line)
                Loop
                srBranch.Close()
                If Not IsNothing(srBranch) Then
                    srBranch.Dispose()
                End If
            End If
            If cmbBranch.Items.Count = 0 Then
                MsgBox("Please Load Branch First")
                GoTo Out
            Else
                cmbBranch.Sorted = True
                cmbBranch.SelectedIndex = 0
            End If
            GrpSub.Enabled = False

            ReadCatalog()
        Catch ex As Exception
            MsgBox(ex.Message)
            GoTo Out
        End Try
        Exit Sub
Out:
        GrpMain.Enabled = False
    End Sub
    Private Sub btnSelectPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectPath.Click
        txtImagePath.Text = ""
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim strPath As String = FolderBrowserDialog1.SelectedPath
            txtImagePath.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
    Private Sub ReadCatalog()
        Try
            Dim LINE1 As String = ""
            Dim LineIndex As String = ""
            Dim LineValue As String = ""

            If File.Exists(CatalogFileNm) Then
                Try
                    SrCatalog = New StreamReader(CatalogFileNm)
                Catch ex As Exception
                    SrCatalog = Nothing
                    File.Delete(CatalogFileNm)
                End Try
            End If
            If IsNothing(SrCatalog) = False Then
                Do While IsNothing(SrCatalog.EndOfStream) = False
                    LINE1 = SrCatalog.ReadLine()
                    If (LINE1 = Nothing And SrCatalog.EndOfStream) Then
                        Exit Do
                    End If
                    If Trim(LINE1) = "" Then
                        Continue Do
                    End If
                    LineIndex = Mid(LINE1, 4, 1)
                    LineValue = Mid(LINE1, InStr(LINE1, "=") + 1)
                    If LINE1.Contains("KEY0") Then
                        txtImagePath.Text = LineValue
                    ElseIf LINE1.Contains("KEY1") Then
                        cmbBranch.Text = LineValue
                    End If
                Loop
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(SrCatalog) Then
                SrCatalog.Close()
                SrCatalog = Nothing
            End If
        End Try
    End Sub
    Private Sub WriteCatalog()
        Try
            SwCatalog = New StreamWriter(CatalogFileNm, False)
            SwCatalog.WriteLine("KEY0=" & txtImagePath.Text)
            SwCatalog.WriteLine("KEY1=" & cmbBranch.Text)
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(SwCatalog) Then
                SwCatalog.Close()
                SwCatalog = Nothing
            End If
        End Try
    End Sub
    Private Sub txtImagePath_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtImagePath.Enter, txtFileNo.Enter, txtImageStartNo.Enter, txtImageNewNo.Enter
        EnterControl(sender, e)
    End Sub
    Private Sub EnterControl(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txt As TextBox = CType(sender, TextBox)
        txt.SelectAll()
    End Sub
    Private Sub txtImagePath_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtImagePath.TextChanged
        enabledisablebtn()
    End Sub
    Private Sub enabledisablebtn()
        If txtImagePath.Text.Trim = "" OrElse txtFileNo.Text.Trim = "" Then
            btnConnect.Enabled = False
            btnDisconnect.Enabled = False
        Else
            btnConnect.Enabled = True
            btnDisconnect.Enabled = False
        End If
    End Sub
    Private Sub txtImageMinNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImageStartNo.TextChanged
        enableDisableGapBtn()
    End Sub
    Private Sub txtImageMaxNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImageNewNo.TextChanged
        enableDisableGapBtn()
    End Sub
    Private Sub enableDisableGapBtn()
        If txtImageStartNo.Text.Trim <> "" AndAlso txtImageNewNo.Text.Trim <> "" Then
            btnCreateGap.Enabled = True
        Else
            btnCreateGap.Enabled = False
        End If
    End Sub
    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        If Directory.Exists(txtImagePath.Text) = False Then
            MsgBox("Image Path does not Exists" & vbNewLine & txtImagePath.Text)
            GoTo OUT
        End If
        strImgPath = txtImagePath.Text
        Dim docNo As String = txtFileNo.Text
        If docNo.Contains("_") Then
            docNo = Format(CInt(Mid(docNo, 1, InStr(docNo, "_") - 1)), "00000") & Mid(docNo, InStr(docNo, "_"))
        Else
            docNo = Format(CInt(docNo), "00000")
        End If
        ImgFldPath = strImgPath & "\" & cmbBranch.Text & "\" & docNo
        If Directory.Exists(ImgFldPath) = False Then
            MsgBox("Image Path does not Exists" & vbNewLine & ImgFldPath)
            GoTo OUT
        End If
        If Directory.GetFiles(ImgFldPath).Length = 0 Then
            MsgBox("NO IMAGES EXISTS" & vbNewLine & ImgFldPath)
            GoTo OUT
        End If

        Dim di As DirectoryInfo = New DirectoryInfo(ImgFldPath)
        Dim TotImages As Integer = 0
        Dim TotNumberedImg As Integer = 0
        Dim TotUnNumberedImg As Integer = 0
        Dim JpegImg As Integer = 0
        Dim tiffImg As Integer = 0
        Dim OtherFiles As Integer = 0
        MinImgNo = 0
        MaxImgNo = 0

        For Each FI In di.GetFiles().OrderBy(Function(fn) fn.Name)
            Dim ext As String = FI.Extension.ToUpper
            If ext = ".CSV" OrElse ext = ".TXT" OrElse ext = ".TMP" OrElse ext = ".TEMP" OrElse ext = ".DB" Then
                Continue For
            End If
            Dim FileNo As String = ""
            If FI.Name.ToUpper.Contains("_R") Then
                FileNo = Mid(FI.Name, 1, InStr(FI.Name, "_R") - 1)
            Else
                FileNo = Mid(FI.Name, 1, InStr(FI.Name, ".") - 1)
            End If

            If ext = ".JPG" Then
                JpegImg += 1
            ElseIf ext = ".TIF" OrElse ext = ".TIFF" Then
                tiffImg += 1
            Else
                OtherFiles += 1
            End If
            TotImages += 1
            If IsNumeric(FileNo) AndAlso Len(FileNo) = 4 Then
                TotNumberedImg += 1
                If MinImgNo = 0 Then
                    MinImgNo = FileNo
                End If
                If MaxImgNo < FileNo Then
                    MaxImgNo = FileNo
                End If
            Else
                TotUnNumberedImg += 1
            End If
        Next

        Dim strMsgInfo As String = ""
        strMsgInfo = " IMAGE PATH: " & di.FullName & vbNewLine & vbNewLine
        strMsgInfo &= " IMAGES: " & TotImages & Space(5) & "JPEG: " & JpegImg & Space(5) & " TIF: " & tiffImg & Space(5) & " OTHERS: " & OtherFiles & vbNewLine & vbNewLine
        strMsgInfo &= " NUMBERED: " & TotNumberedImg & Space(5) & " UNNUMBERED: " & TotUnNumberedImg & Space(5) & " MINNO: " & MinImgNo & Space(5) & " MAXNO: " & MaxImgNo

        lblFolderInfo.Text = strMsgInfo

        If TotImages = 0 Then
            MsgBox("NO IMAGES EXISTS")
            GoTo OUT
        ElseIf TotUnNumberedImg > 0 Then
            If MsgBox("RE-NUMBERING is Required Do You wish to Continue? ", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Confirmation") = MsgBoxResult.No Then
                GoTo OUT
            End If
            Dim pct As PictureBox = Nothing
            Dim sw As StreamWriter = Nothing
            Dim FileFullPath As String = strImgPath & "\RenameImagesLog.csv"
            Try
                sw = New StreamWriter(FileFullPath, True)
                ChangeFile(ImgFldPath, Nothing, lblFileName, False, pct)
            Catch ex As Exception
                MsgBox(ex.Message)
                GoTo OUT
            Finally
                If Not IsNothing(sw) Then
                    sw.Close()
                    sw = Nothing
                End If
                If File.Exists(FileFullPath) Then
                    If New FileInfo(FileFullPath).Length = 0 Then
                        File.Delete(FileFullPath)
                    End If
                End If
            End Try
            If File.Exists(FileFullPath) Then
                MsgBox("Log File is Generated Please Check First")
                GoTo OUT
            End If
        End If
        WriteCatalog()
        GrpMain.Enabled = False
        GrpSub.Enabled = True
        btnDisconnect.Enabled = True
        txtImageStartNo.Focus()
        Exit Sub
OUT:
        txtImagePath.Focus()
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub btnDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnect.Click
        GrpSub.Enabled = False
        btnDisconnect.Enabled = False
        GrpMain.Enabled = True
        btnConnect.Enabled = False
        txtFileNo.Text = ""
        txtFileNo.Focus()
        lblFileName.Text = ""
        Application.DoEvents()
    End Sub
    Private Sub btnCreateGap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateGap.Click
        Dim ImgStNo As Integer = 0
        Dim ImgNewNo As Integer = 0
        Dim IncGap As Integer = 0
        Try
            ImgStNo = txtImageStartNo.Text
            ImgNewNo = txtImageNewNo.Text

            If Not (ImgStNo >= MinImgNo AndAlso ImgStNo <= MaxImgNo) Then
                MsgBox("Please Enter Start number in Range " & MinImgNo & " and " & MaxImgNo)
                GoTo Out
            End If

            'If Not (ImgNewNo > MaxImgNo) Then
            '    MsgBox("Please Enter New Number Higher than MaxImageNo" & MaxImgNo)
            '    GoTo Out
            'End If

            If Not (ImgNewNo > ImgStNo) Then
                MsgBox("Please Enter New Number Higher than Image Start No:" & ImgStNo)
                GoTo Out
            End If

            IncGap = ImgNewNo - ImgStNo
            Dim di As DirectoryInfo = New DirectoryInfo(ImgFldPath)
            For Each FI In di.GetFiles().OrderByDescending(Function(fn) fn.Name)
                Dim ext As String = FI.Extension.ToUpper
                If ext = ".CSV" OrElse ext = ".TXT" OrElse ext = ".TMP" OrElse ext = ".TEMP" OrElse ext = ".DB" Then
                    Continue For
                End If
                Dim FileNo As String = "" 'Mid(FI.Name, 1, InStr(FI.Name, ".") - 1)
                If FI.Name.ToUpper.Contains("_R") Then
                    FileNo = Mid(FI.Name, 1, InStr(FI.Name, "_R") - 1)
                Else
                    FileNo = Mid(FI.Name, 1, InStr(FI.Name, ".") - 1)
                End If
                If CInt(FileNo) < ImgStNo Then
                    Exit For
                End If
                Dim newFileNo As String = "" 'Format(CInt(FileNo) + IncGap, "0000")
                If FI.Name.ToUpper.Contains("_R") Then
                    newFileNo = Format(CInt(FileNo) + IncGap, "0000") & "_R"
                Else
                    newFileNo = Format(CInt(FileNo) + IncGap, "0000")
                End If
                If File.Exists(FI.DirectoryName & "\" & newFileNo & FI.Extension) Then
                    MsgBox(FI.DirectoryName & "\" & newFileNo & FI.Extension & " ALREADY EXISTS")
                End If
                Rename(FI.FullName, FI.DirectoryName & "\" & newFileNo & FI.Extension)
            Next

            Clipboard.Clear()
            Clipboard.SetText(ImgFldPath)
            GrpSub.Enabled = False
            GrpMain.Enabled = True
            txtFileNo.Focus()
            txtImageNewNo.Text = ""
            txtImageStartNo.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Exit Sub
Out:
        GrpSub.Enabled = True
        txtImageStartNo.Focus()
    End Sub
    Private Sub txtFileNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFileNo.TextChanged
        enabledisablebtn()
        lblFolderInfo.Text = ""
        lblFileName.Text = ""
    End Sub
    Private Sub txtImagePath_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtImagePath.KeyPress
        process_KeyPress(e, False)
    End Sub
    Private Sub cmbBranch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbBranch.KeyPress
        process_KeyPress(e, False)
    End Sub

    Private Sub txtFileNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFileNo.KeyPress
        process_KeyPress(e, False)
    End Sub

    Private Sub txtImageMinNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtImageStartNo.KeyPress
        process_KeyPress(e, True)
    End Sub

    Private Sub txtImageMaxNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtImageNewNo.KeyPress
        process_KeyPress(e, True)
    End Sub
End Class