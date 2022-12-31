Imports System.IO
Public Class frmRenameCDAExportedImages
    Dim blnExit As Boolean = False
    Dim blnQuit As Boolean = False
    Dim fs As FileInfo
    Dim di As DirectoryInfo
    Dim diSub As DirectoryInfo

    Public Declare Function GetAsyncKeyState Lib "user32" (ByVal key As Keys) As Integer
    Dim sw As StreamWriter
    Dim SourcePath As String = ""
    Dim pct As New PictureBox
    Private Sub frmRenameCDAExportedImages_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not IsNothing(sw) Then
            sw.Close()
            sw = Nothing
        End If
    End Sub
    Private Sub frmRenameCDAExportedImages_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub txtPath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPath.TextChanged
        enableDisable()
    End Sub
    Private Sub enableDisable()
        If txtPath.Text.Trim = "" Then
            btnRenameImages.Enabled = False
        Else
            btnRenameImages.Enabled = True
        End If
    End Sub
    Private Sub btnRenameImages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenameImages.Click
        Dim FilePath As String = txtPath.Text
        Dim FileFullPath As String = FilePath & "\RenameImagesLog.csv"
        Try
            lblFileName.Text = ""
            If Trim(txtPath.Text) = "" Then
                MsgBox("Please Select Path")
                txtPath.Focus()
                Exit Sub
            End If
            If Directory.Exists(txtPath.Text) = False Then
                MsgBox("Directory Not Exists " & txtPath.Text)
                txtPath.Focus()
                Exit Sub
            End If
            sw = New StreamWriter(FileFullPath, True)
            GrpMain.Enabled = False
            'lblFileName.Text = "CSV FILE PATH: " & FilePat
            Application.DoEvents()

            SourcePath = txtPath.Text

            ProcessDirectory(SourcePath, 1)
            If Not IsNothing(sw) Then
                sw.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            GoTo out
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
            Clipboard.Clear()
            Clipboard.SetText(FileFullPath)
            MsgBox("OVER" & vbNewLine & "Path has been copied to Clipboard: " & FileFullPath)
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
                Dim fileEntries As String() = Directory.GetFiles(targetDirectory) ', "*." & ImgExtension

                'If Directory.GetFiles(targetDirectory, "*.TIF").Length > 0 Then
                '    ConvertTiffToJpg(New DirectoryInfo(targetDirectory), "TIF")
                'End If

                'If Directory.GetFiles(targetDirectory, "*.TIFF").Length > 0 Then
                '    ConvertTiffToJpg(New DirectoryInfo(targetDirectory), "TIFF")
                'End If

                If (fileEntries.Length > 0) Then
                    Me.Text = "Current Directory:" & targetDirectory & "  TOTAL IMGs: " & fileEntries.Length
                    Application.DoEvents()
                    ChangeFile(targetDirectory, sw, lblFileName, chkForImgCorruption.Checked, pct)
                End If
            Else
                'Dim totFiles As Integer = 0
                'totFiles = Directory.GetFiles(targetDirectory, "*." & ImgExtension).Length

                'Me.Text = "Current Directory:" & targetDirectory & "  TOTAL FILES: " & totFiles
                'Application.DoEvents()
                'Dim DI As DirectoryInfo = New DirectoryInfo(targetDirectory)
                ''PgCount(targetDirectory)
                'sw.WriteLine(DI.FullName & vbTab & "'" & DI.Name & vbTab & Format(DI.CreationTime, "yyyy/MM/dd") & vbTab & totFiles)
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
End Class