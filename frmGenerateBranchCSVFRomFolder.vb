Imports System.IO
Public Class frmGenerateBranchCSVFRomFolder
    Dim blnExit As Boolean = False
    Dim blnQuit As Boolean = False
    Dim fs As FileInfo
    Dim di As DirectoryInfo
    Dim diSub As DirectoryInfo

    Public Declare Function GetAsyncKeyState Lib "user32" (ByVal key As Keys) As Integer
    Dim sw As StreamWriter
    Dim SourcePath As String = ""
    Dim pct As New PictureBox
    Private Sub frmGenerateBranchCSVFRomFolder_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not IsNothing(sw) Then
            sw.Close()
            sw = Nothing
        End If
    End Sub
    Private Sub txtPath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPath.TextChanged
        enableDisable()
    End Sub
    Private Sub enableDisable()
        If txtPath.Text.Trim = "" Then
            btnGenerateBranchFileFromFld.Enabled = False
        Else
            btnGenerateBranchFileFromFld.Enabled = True
        End If
    End Sub
    Private Sub btnGenerateBranchFileFromFld_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateBranchFileFromFld.Click
        Dim FilePath As String = txtPath.Text
        Dim FileFullPath As String = FilePath & "\Branch.txt"

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
            Application.DoEvents()

            SourcePath = txtPath.Text

            For Each dirNm As String In Directory.GetDirectories(txtPath.Text)
                Dim di As DirectoryInfo = New DirectoryInfo(dirNm)

                sw.WriteLine(di.Name)
            Next

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
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class