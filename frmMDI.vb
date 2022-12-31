Public Class frmMDI

    Private Sub PDFPageCountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PDFPageCountToolStripMenuItem.Click
        Dim frm As New frmPDFPageCount
        frm.ShowDialog()
    End Sub

    Private Sub RenameExportedImageNameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenameExportedImageNameToolStripMenuItem.Click
        Dim frm As New frmRenameCDAExportedImages
        frm.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub frmMDI_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub
    Private Sub ImageCorruptionCheckingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageCorruptionCheckingToolStripMenuItem.Click
        Dim frm As New frmImageCorruptionChecking
        frm.ShowDialog()
    End Sub
    Private Sub GenerateBranchFileFromFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerateBranchFileFromFolderToolStripMenuItem.Click
        Dim frm As New frmGenerateBranchCSVFRomFolder
        frm.ShowDialog()
    End Sub
    Private Sub CreateGapToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateGapToolStripMenuItem.Click
        Dim frm As New frmCreateImageGap
        frm.ShowDialog()
    End Sub
End Class