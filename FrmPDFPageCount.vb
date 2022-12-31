Imports PDFSplitMerge
Imports System.Threading
Imports O2S.Components.PDF4NET
Imports System.IO
Public Class frmPDFPageCount
    Dim fs As FileInfo
    Dim di As DirectoryInfo
    Dim diSub As DirectoryInfo

    Dim SrPDFPAth As StreamReader
    Dim SwPDFPath As StreamWriter
    Dim PDFPathFileNm As String

    Dim cmb As New ComboBox
    Dim StrSeleFolderPath As String
    Dim blnExit As Boolean = False
    Dim blnQuit As Boolean = False
    Public Declare Function GetAsyncKeyState Lib "user32" (ByVal key As Keys) As Integer
    Dim ImgExtension As String = "PDF"
    Dim sw As StreamWriter
    Private Sub frmPDFPageCount_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not IsNothing(SrPDFPAth) Then
            SrPDFPAth.Close()
            SrPDFPAth = Nothing
        End If
        If Not IsNothing(SwPDFPath) Then
            SwPDFPath.Close()
            SwPDFPath = Nothing
        End If
    End Sub
    Private Sub frmPDFPageCount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            PDFPathFileNm = Application.StartupPath & "\" & "PDFPAth.DAT"
            If File.Exists(PDFPathFileNm) Then
                Dim Line1 As String
                Try
                    SrPDFPAth = New StreamReader(PDFPathFileNm)
                    If IsNothing(SrPDFPAth) = False Then
                        Do While IsNothing(SrPDFPAth.EndOfStream) = False
                            Line1 = SrPDFPAth.ReadLine()
                            If (Line1 = Nothing And SrPDFPAth.EndOfStream) Then
                                Exit Do
                            End If
                            If Directory.Exists(Line1) Then
                                txtPath.Text = Line1
                            End If
                        Loop
                    End If
                Catch ex As Exception
                    SrPDFPAth = Nothing
                    File.Delete(PDFPathFileNm)
                Finally
                    If Not IsNothing(SrPDFPAth) Then
                        SrPDFPAth.Close()
                        SrPDFPAth = Nothing
                    End If
                End Try
            End If
            enableDisable()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Exit Sub
OUT:
        GrpMain.Enabled = False
    End Sub
    Private Sub btnSelectPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectPath.Click
        If txtPath.Text <> "" Then
            FolderBrowserDialog1.SelectedPath = txtPath.Text
        End If
        txtPath.Text = ""
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPath.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        lblFileName.Text = ""
        If Trim(txtPath.Text) = "" Then
            MsgBox("Please Select Path")
            txtPath.Focus()
            Exit Sub
        End If
        If Trim(txtOutputFileNm.Text) = "" Then
            MsgBox("Please Enter File Name")
            txtOutputFileNm.Focus()
            Exit Sub
        End If
        If Directory.Exists(txtPath.Text) = False Then
            MsgBox("Directory Not Exists " & txtPath.Text)
            txtPath.Focus()
            Exit Sub
        End If
        SwPDFPath = New StreamWriter(PDFPathFileNm, False)
        GrpMain.Enabled = False
        Dim sw As StreamWriter
        Dim FilePath As String
        Dim SourcePath As String
        Dim PageCount As Integer
        Dim pdfDoc As PDFDocument = Nothing
        'Dim inttmp As String
        Dim blnCorrupted As Boolean = False
        FilePath = txtPath.Text & "\" & txtOutputFileNm.Text & "_PageCount.txt"
        sw = New StreamWriter(FilePath, False)

        Try
            SourcePath = txtPath.Text
            lblCSVPath.Text = "CSV FILE PATH: " & FilePath
            Application.DoEvents()

            di = New DirectoryInfo(SourcePath)
            'For Each diSub As DirectoryInfo In di.GetDirectories()
            For Each fs As FileInfo In di.GetFiles("*.pdf").OrderBy(Function(fn) fn.CreationTime + fn.Name)

                PageCount = 0
                lblFileName.Text = fs.Name
                Application.DoEvents()
                blnCorrupted = False
                Try
                    pdfDoc = New PDFDocument(fs.FullName)
                    'inttmp = InStrRev(fs.FullName, "\")
                    PageCount = pdfDoc.Pages.Count
                    sw.WriteLine(Format(fs.CreationTime, "yyyy/MM/dd") & vbTab & Mid(fs.Name, 1, InStrRev(fs.Name, ".") - 1) & vbTab & PageCount)
                Catch ex As Exception
                    sw.WriteLine(di.FullName & vbTab & di.Name & vbTab & fs.Name & "-PDF CORRUPTED-" & ex.Message & vbTab & PageCount)
                    blnCorrupted = True
                Finally
                    If Not IsNothing(pdfDoc) Then
                        pdfDoc.Dispose()
                    End If
                End Try

                Try
                    If blnCorrupted AndAlso chkDeleteCorruptedPDF.Checked Then ' DIS CHECK FOR OTHER PROJECT NOT TO DELETE ALL FILES
                        Dim docNo As String = ""
                        If fs.Name.Contains("_") Then
                            docNo = Mid(fs.Name, 1, InStr(fs.Name, "_") - 1)
                        Else
                            docNo = Mid(fs.Name, 1, InStrRev(fs.Name, ".") - 1)
                        End If
                        GC.Collect()
                        For Each fi In Directory.GetFiles(SourcePath, docNo & "*.PDF")
                            File.Delete(fi)
                        Next
                        If File.Exists(SourcePath & "\" & docNo & ".PDF") Then
                            File.Delete(SourcePath & "\" & docNo & ".PDF")
                        End If
                    End If
                Catch ex As Exception
                    sw.WriteLine(di.FullName & vbTab & di.Name & vbTab & fs.Name & "-PDF CORRUPTED-" & ex.Message & vbTab & PageCount)
                End Try
                
            Next
            'Next

            If Not IsNothing(sw) Then
                sw.Close()
            End If
            SwPDFPath.WriteLine(SourcePath)
        Catch ex As Exception
            MsgBox(ex.Message)
            GoTo OUT
        Finally
            If Not IsNothing(pdfDoc) Then
                pdfDoc.Dispose()
            End If
            If Not IsNothing(sw) Then
                sw.Close()
                sw = Nothing
            End If
            If Not IsNothing(SwPDFPath) Then
                SwPDFPath.Close()
                SwPDFPath = Nothing
            End If
            If File.Exists(FilePath) Then
                If New FileInfo(FilePath).Length = 0 Then
                    File.Delete(FilePath)
                End If
            End If
        End Try
        If File.Exists(FilePath) Then
            Clipboard.Clear()
            Clipboard.SetText(FilePath)
            MsgBox("OVER" & vbNewLine & "Path has been copied to Clipboard: " & FilePath)
        Else
            MsgBox("OVER")
        End If
OUT:
        GrpMain.Enabled = True
    End Sub
    Private Sub txtPath_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPath.Enter
        txtPath.SelectAll()
    End Sub
    Private Sub txtPath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPath.TextChanged
        enableDisable()
    End Sub
    Private Sub txtOutputFileNm_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOutputFileNm.Enter
        txtOutputFileNm.SelectAll()
    End Sub
    Private Sub txtOutputFileNm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOutputFileNm.TextChanged
        enableDisable()
    End Sub
    Private Sub enableDisable()
        If txtPath.Text.Trim <> "" AndAlso txtOutputFileNm.Text.Trim <> "" Then
            btnProcess.Enabled = True
            btnMergePDF.Enabled = True
            btnPGCountSubDir.Enabled = True
            btnProcessFileCount.Enabled = True
        Else
            btnProcess.Enabled = False
            btnMergePDF.Enabled = False
            btnPGCountSubDir.Enabled = False
            btnProcessFileCount.Enabled = False
        End If
    End Sub
    Private Sub btnMergePDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMergePDF.Click
        lblFileName.Text = ""
        If Trim(txtPath.Text) = "" Then
            MsgBox("Please Select Path")
            txtPath.Focus()
            Exit Sub
        End If
        If Trim(txtOutputFileNm.Text) = "" Then
            MsgBox("Please Enter File Name")
            txtOutputFileNm.Focus()
            Exit Sub
        End If
        If Directory.Exists(txtPath.Text) = False Then
            MsgBox("Directory Not Exists " & txtPath.Text)
            txtPath.Focus()
            Exit Sub
        End If
        GrpMain.Enabled = False
        Dim Job1 As Thread
        Try
            StrSeleFolderPath = txtPath.Text
            Job1 = New Thread(AddressOf MergePDF)
            Job1.Start()
            Job1.Join()
            MsgBox("Over")
        Catch ex As Exception
            MsgBox(ex.Message)
            GoTo OUT
        End Try
OUT:
        GrpMain.Enabled = True
    End Sub
    Private Sub MergePDF()
        Dim pdf As PDFSplitMerge.CPDFSplitMergeObj = Nothing
        Dim StrFileToMergeList As String
        Dim blnInsertBlankPage As Boolean = False
        Try
            Try
                pdf = New CPDFSplitMergeObj
            Catch ex As Exception
                Throw ex
            End Try
            cmb.Items.Clear()
            Dim dIDest As New DirectoryInfo(txtPath.Text)
            Dim FIDest As FileInfo
            pdf.SetCode("Your license code here")

            StrFileToMergeList = ""
            Application.DoEvents()

            If Not Directory.Exists(StrSeleFolderPath & "\MergedFile") Then
                Directory.CreateDirectory(StrSeleFolderPath & "\MergedFile")
            End If
            For Each FIDest In dIDest.GetFiles("*.PDF")
                cmb.Items.Add(FIDest.FullName)
            Next
            cmb.Sorted = True
            Dim pageNo As Integer
            Dim StrDestFileName As String = ""
            '  For Each FIDest In dIDest.GetFiles("*.PDF")
            For ind As Integer = 0 To cmb.Items.Count - 1
                lblFileName.Text = cmb.Items(ind)
                Application.DoEvents()
                pageNo = 0
                If StrFileToMergeList <> "" Then
                    StrFileToMergeList = StrFileToMergeList & cmb.Items(ind) & "|"
                Else
                    StrFileToMergeList = cmb.Items(ind) & "|"
                End If

                pageNo = pdf.GetNumberOfPages(cmb.Items(ind), "")
                'If chkEvenPageFile.Checked Then
                '    If pageNo Mod 2 <> 0 Then
                '        StrFileToMergeList = StrFileToMergeList & strBlankPagePATH & "|"
                '    End If
                'End If
            Next

            'Debug.Print(StrFileToMergeList)
            StrDestFileName = StrSeleFolderPath & "\MergedFile\" & txtOutputFileNm.Text & ".pdf"
            StrFileToMergeList = StrFileToMergeList.TrimEnd("|")
            Try
                pdf.Merge(StrFileToMergeList, StrDestFileName)
            Catch ex As Exception
                Throw ex
            End Try
            dIDest = Nothing
            FIDest = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(pdf) Then
                pdf = Nothing
            End If
            pdf = Nothing
        End Try
        'Dim fi As FileInfo
    End Sub
    Private Sub btnPGCountSubDir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPGCountSubDir.Click
        lblFileName.Text = ""
        If Trim(txtPath.Text) = "" Then
            MsgBox("Please Select Path")
            txtPath.Focus()
            Exit Sub
        End If
        If Trim(txtOutputFileNm.Text) = "" Then
            MsgBox("Please Enter File Name")
            txtOutputFileNm.Focus()
            Exit Sub
        End If
        If Directory.Exists(txtPath.Text) = False Then
            MsgBox("Directory Not Exists " & txtPath.Text)
            txtPath.Focus()
            Exit Sub
        End If
        SwPDFPath = New StreamWriter(PDFPathFileNm, False)
        GrpMain.Enabled = False

        Dim FilePath As String
        Dim SourcePath As String
        Dim PageCount As Integer = 0
        Dim pdfDoc As PDFDocument = Nothing
        'Dim inttmp As String

        FilePath = txtPath.Text & "\" & txtOutputFileNm.Text & "_PageCount.txt"
        sw = New StreamWriter(FilePath, False)

        Try
            lblCSVPath.Text = "CSV FILE PATH: " & FilePath
            Application.DoEvents()

            SourcePath = txtPath.Text
            'di = New DirectoryInfo(SourcePath)
            ''For Each diSub As DirectoryInfo In di.GetDirectories()
            'For Each fs As FileInfo In di.GetFiles("*.pdf").OrderBy(Function(fn) fn.CreationTime + fn.Name)
            '    PageCount = 0
            '    lblFileName.Text = fs.Name
            '    Application.DoEvents()
            '    pdfDoc = New PDFDocument(fs.FullName)
            '    'inttmp = InStrRev(fs.FullName, "\")
            '    PageCount = pdfDoc.Pages.Count
            '    sw.WriteLine(Format(fs.CreationTime, "yyyy/MM/dd") & vbTab & Mid(fs.Name, 1, InStrRev(fs.Name, ".") - 1) & vbTab & PageCount)
            '    If Not IsNothing(pdfDoc) Then
            '        pdfDoc.Dispose()
            '    End If
            'Next
            'Next

            ProcessDirectory(SourcePath, 1)
            If Not IsNothing(sw) Then
                sw.Close()
            End If
            SwPDFPath.WriteLine(SourcePath)
        Catch ex As Exception
            MsgBox(ex.Message)
            GoTo OUT
        Finally
            If Not IsNothing(pdfDoc) Then
                pdfDoc.Dispose()
            End If
            If Not IsNothing(sw) Then
                sw.Close()
                sw = Nothing
            End If
            If Not IsNothing(SwPDFPath) Then
                SwPDFPath.Close()
                SwPDFPath = Nothing
            End If
            If File.Exists(FilePath) Then
                If New FileInfo(FilePath).Length = 0 Then
                    File.Delete(FilePath)
                End If
            End If
        End Try
        If File.Exists(FilePath) Then
            Clipboard.Clear()
            Clipboard.SetText(FilePath)
            MsgBox("OVER" & vbNewLine & "Path has been copied to Clipboard: " & FilePath)
        Else
            MsgBox("OVER")
        End If
OUT:
        GrpMain.Enabled = True
    End Sub
    Private Sub ProcessDirectory(ByVal targetDirectory As String, ByVal formatType As Integer)
        Try
            If blnExit Or blnQuit Then
                Exit Sub
            End If
            If GetAsyncKeyState(Keys.Escape) < 0 Then '060509
                If MsgBox("Are You Sure You Want Quit From Process", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    blnExit = True
                    Exit Sub
                End If
            End If

            Me.Text = "Current Directory:" & targetDirectory
            Application.DoEvents()
            If formatType = 1 Then
                Dim fileEntries As String() = Directory.GetFiles(targetDirectory, "*." & ImgExtension)

                If (fileEntries.Length > 0) Then
                    Me.Text = "Current Directory:" & targetDirectory & "  TOTAL PDFs: " & fileEntries.Length
                    Application.DoEvents()
                    PgCount(targetDirectory)
                End If
            Else
                Dim totFiles As Integer = 0
                If rptAll.Checked Then
                    totFiles = Directory.GetFiles(targetDirectory).Length
                Else
                    totFiles = Directory.GetFiles(targetDirectory, "*." & ImgExtension).Length
                End If
                Me.Text = "Current Directory:" & targetDirectory & "  TOTAL FILES: " & totFiles
                Application.DoEvents()
                Dim DI As DirectoryInfo = New DirectoryInfo(targetDirectory)
                'PgCount(targetDirectory)
                sw.WriteLine(DI.FullName & vbTab & "'" & DI.Name & vbTab & Format(DI.CreationTime, "yyyy/MM/dd") & vbTab & totFiles)
            End If

            If blnExit Or blnQuit Then
                Exit Sub
            End If

            Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
            Array.Sort(subdirectoryEntries)


            Dim subdirectory As String
            For Each subdirectory In subdirectoryEntries
                If GetAsyncKeyState(Keys.Escape) < 0 Then '060509
                    If MsgBox("Are You Sure You Want Quit From Process", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        blnExit = True
                        Exit For
                    End If
                End If
                Try
                    ProcessDirectory(subdirectory, formatType)
                Catch ex As Exception
                    Throw ex
                End Try
                If blnExit Or blnQuit Then
                    Exit For
                End If
            Next subdirectory

            If blnExit Then
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub PgCount(ByRef SourcePath As String)
        Dim pageCount As Integer = 0
        Dim pdfDoc As PDFDocument = Nothing
        Dim blnCorrupted As Boolean = False
        Try
            di = New DirectoryInfo(SourcePath)
            'For Each diSub As DirectoryInfo In di.GetDirectories()
            For Each fs As FileInfo In di.GetFiles("*." & ImgExtension).OrderBy(Function(fn) fn.CreationTime + fn.Name)
                PageCount = 0
                lblFileName.Text = fs.Name
                Application.DoEvents()
                If File.Exists(fs.FullName) = False Then
                    Continue For
                End If
                blnCorrupted = False
                Try
                    pdfDoc = New PDFDocument(fs.FullName)
                    'inttmp = InStrRev(fs.FullName, "\")
                    pageCount = pdfDoc.Pages.Count
                    sw.WriteLine(di.FullName & vbTab & di.Name & vbTab & Format(fs.CreationTime, "yyyy/MM/dd") & vbTab & Mid(fs.Name, 1, InStrRev(fs.Name, ".") - 1) & vbTab & pageCount)
                Catch ex As Exception
                    sw.WriteLine(di.FullName & vbTab & di.Name & vbTab & fs.Name & "-PDF CORRUPTED-" & ex.Message & vbTab & pageCount)
                    blnCorrupted = True
                Finally
                    If Not IsNothing(pdfDoc) Then
                        pdfDoc.Dispose()
                    End If
                End Try
                Try
                    If blnCorrupted AndAlso chkDeleteCorruptedPDF.Checked Then ' DIS CHECK FOR OTHER PROJECT NOT TO DELETE ALL FILES
                        Dim docNo As String = ""
                        If fs.Name.Contains("_") Then
                            docNo = Mid(fs.Name, 1, InStr(fs.Name, "_") - 1)
                        Else
                            docNo = Mid(fs.Name, 1, InStrRev(fs.Name, ".") - 1)
                        End If
                        GC.Collect()
                        For Each fi In Directory.GetFiles(SourcePath, docNo & "*.PDF")
                            File.Delete(fi)
                        Next
                        If File.Exists(SourcePath & "\" & docNo & ".PDF") Then
                            File.Delete(SourcePath & "\" & docNo & ".PDF")
                        End If
                    End If
                Catch ex As Exception
                    sw.WriteLine(di.FullName & vbTab & di.Name & vbTab & fs.Name & "-PDF CORRUPTED-" & ex.Message & vbTab & pageCount)
                End Try
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnProcessFileCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcessFileCount.Click
        lblFileName.Text = ""
        If Trim(txtPath.Text) = "" Then
            MsgBox("Please Select Path")
            txtPath.Focus()
            Exit Sub
        End If
        If Trim(txtOutputFileNm.Text) = "" Then
            MsgBox("Please Enter File Name")
            txtOutputFileNm.Focus()
            Exit Sub
        End If
        If Directory.Exists(txtPath.Text) = False Then
            MsgBox("Directory Not Exists " & txtPath.Text)
            txtPath.Focus()
            Exit Sub
        End If
        SwPDFPath = New StreamWriter(PDFPathFileNm, False)
        GrpMain.Enabled = False

        Dim FilePath As String
        Dim SourcePath As String
        Dim PageCount As Integer
        Dim pdfDoc As PDFDocument = Nothing
        'Dim inttmp As String

        FilePath = txtPath.Text & "\" & txtOutputFileNm.Text & "_FileCount.txt"
        sw = New StreamWriter(FilePath, False)

        Try
            lblCSVPath.Text = "CSV FILE PATH: " & FilePath
            Application.DoEvents()

            SourcePath = txtPath.Text

            ProcessDirectory(SourcePath, 2)
            If Not IsNothing(sw) Then
                sw.Close()
            End If
            SwPDFPath.WriteLine(SourcePath)
        Catch ex As Exception
            MsgBox(ex.Message)
            GoTo OUT
        Finally
            If Not IsNothing(pdfDoc) Then
                pdfDoc.Dispose()
            End If
            If Not IsNothing(sw) Then
                sw.Close()
                sw = Nothing
            End If
            If Not IsNothing(SwPDFPath) Then
                SwPDFPath.Close()
                SwPDFPath = Nothing
            End If
            If File.Exists(FilePath) Then
                If New FileInfo(FilePath).Length = 0 Then
                    File.Delete(FilePath)
                End If
            End If
        End Try
        If File.Exists(FilePath) Then
            Clipboard.Clear()
            Clipboard.SetText(FilePath)
            MsgBox("OVER" & vbNewLine & "Path has been copied to Clipboard: " & FilePath)
        Else
            MsgBox("OVER")
        End If
OUT:
        GrpMain.Enabled = True
    End Sub
End Class
