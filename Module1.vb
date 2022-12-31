Imports System.IO
Module Module1
    Public ImgExtension As String = "JPG"
    Public Sub ConvertTiffToJpg(ByRef di As DirectoryInfo, ByRef curImgExtension As String)
        Try
            Dim FileName As String = ""
            '   Dim FileCnt As Integer = 1
            For Each fi As FileInfo In di.GetFiles("*." & curImgExtension) '.OrderBy(Function(fn) fn.Name) 'fi.length
                'lblInfo.Text = fi.FullName
                'Application.DoEvents()
                FileName = fi.Name
                'If fi.Name.Contains("(") Then
                '    MsgBox("FIRST REPAIR FILENAME FOR FOLDER" & fi.DirectoryName)
                '    GoTo OUT
                'End If
                If File.Exists(fi.DirectoryName & "\" & fi.Name.ToUpper.Replace("." & curImgExtension, ".JPG")) Then
                    File.Delete(fi.DirectoryName & "\" & fi.Name.ToUpper.Replace("." & curImgExtension, ".JPG"))
                End If
                File.Move(fi.FullName, fi.DirectoryName & "\" & fi.Name.ToUpper.Replace("." & curImgExtension, "." & ImgExtension))
            Next
        Catch ex As Exception
            Throw ex
        End Try
OUT:
    End Sub
    Public Sub process_KeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal BlnNumeric As Boolean)
        Select Case e.KeyChar
            Case ControlChars.Cr
                SendKeys.Send(ControlChars.Tab)
            Case ControlChars.Back
            Case "0" To "9"
            Case Else
                If BlnNumeric Then
                    e.Handled = True
                End If
        End Select
    End Sub
    Public Sub ChangeFile(ByVal targetDir As String, ByRef sw As StreamWriter, ByRef lblFileName As Label, ByRef blnimgCorruptChk As Boolean, ByRef PCT As PictureBox)
        Try
            Dim di As DirectoryInfo = New DirectoryInfo(targetDir)
            Dim blnEr As Boolean = False
            Dim PreFix As Char = ""

            For ind As Integer = 65 To (65 + 26)
                PreFix = Chr(ind)
                If di.GetFiles(PreFix & "_*." & ImgExtension).Length = 0 Then
                    Exit For
                End If
            Next

            If di.GetFiles(PreFix & "_*." & ImgExtension).Length > 0 Then
                sw.WriteLine(targetDir & vbTab & "ALL PREFIX ARE USED")
                GoTo OUT
            End If

            'Dim ext As String() = {"*.jpg", "*.bmp", "*png"}
            'Dim files As String() = ext.SelectMany(Function(f) Directory.GetFiles(romPath, f)).ToArray
            'Array.Sort(files)

            Dim cnt As Integer = 1
            Dim Ext As String
            For Each fi In di.GetFiles().OrderBy(Function(fn) fn.Name) '"*." & ImgExtension
                Ext = fi.Extension.ToUpper()
                If Ext = ".CSV" OrElse Ext = ".TXT" OrElse Ext = ".TMP" OrElse Ext = ".TEMP" OrElse Ext = ".DB" Then
                    Continue For
                End If
                Try
                    Rename(fi.FullName, fi.DirectoryName & "\" & PreFix & "_" & fi.Name)
                Catch ex As Exception
                    sw.WriteLine(fi.FullName & vbTab & ex.Message)
                End Try
            Next

            'MsgBox("Prefix - " & PreFix & " Added Please Check and Continue....")

            For Each fi In di.GetFiles().OrderBy(Function(fn) fn.Name) '.ToList() '"*." & ImgExtension
                Ext = fi.Extension.ToUpper()
                If Ext = ".CSV" OrElse Ext = ".TXT" OrElse Ext = ".TMP" OrElse Ext = ".TEMP" OrElse Ext = ".DB" Then
                    Continue For
                End If
                lblFileName.Text = fi.FullName
                Application.DoEvents()
                Dim fileNM As String = fi.Name
                Dim ptrn As String = ""
                blnEr = False
                Try
                    'If fi.Name.IndexOf("_") = 1 Then
                    '    cnt += 1
                    '    Continue For
                    'End If

                    If blnimgCorruptChk Then 'chkForImgCorruption.Checked
                        Try
                            pct.Load(fi.FullName)
                        Catch ex As Exception
                            blnEr = False
                            sw.WriteLine(fi.FullName & vbTab & " Corrupted Image")
                        Finally
                            pct.Image.Dispose()
                            pct.Dispose()
                        End Try
                    End If

                    'If fileNM.Contains("_L_") Then
                    '    'ptrn = Mid(fileNM, InStrRev(fileNM, "_L_") - 4, 4)
                    '    'If File.Exists(fi.DirectoryName & "\" & ptrn & "." & ImgExtension) Then
                    '    '    sw.WriteLine(fi.FullName & vbTab & ptrn & "." & ImgExtension & "Already Exists")
                    '    'End If
                    '    'Rename(fi.FullName, fi.DirectoryName & "\" & ptrn & "." & ImgExtension)
                    '    Rename(fi.FullName, fi.DirectoryName & "\" & PreFix & "_" & Format(cnt, "0000") & "." & ImgExtension)
                    'Else
                    If fileNM.EndsWith("_L." & ImgExtension) Then
                        sw.WriteLine(fi.FullName & vbTab & " NO Page to Display Image")
                        'fi.Delete()
                    Else
                        'If Len(fileNM) > 13 Then
                        '    blnEr = True
                        'End If
                        Dim newFileNm As String = ""
                        If fi.Name.ToUpper.Contains("_R") Then
                            newFileNm = Format(cnt, "0000") & "_R" & fi.Extension
                        Else
                            newFileNm = Format(cnt, "0000") & fi.Extension
                        End If
                        If File.Exists(fi.DirectoryName & "\" & newFileNm) Then
                            sw.WriteLine(fi.FullName & vbTab & newFileNm & "Already Exists")
                        End If
                        Rename(fi.FullName, fi.DirectoryName & "\" & newFileNm) 'Format(cnt, "0000") & fi.Extension
                        cnt += 1
                    End If
                Catch ex As Exception
                    blnEr = False
                    sw.WriteLine(fi.FullName & vbTab & ex.Message)
                End Try
                If blnEr Then
                    sw.WriteLine(fi.FullName)
                End If
            Next
        Catch ex As Exception
            sw.WriteLine(targetDir & vbTab & ex.Message)
            'Throw ex
        End Try
OUT:
    End Sub
End Module
