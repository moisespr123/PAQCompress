Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Compress.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Extract.ShowDialog()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.DirectoryExists("Data") = False Then My.Computer.FileSystem.CreateDirectory("Data")
        If My.Computer.FileSystem.FileExists("Data\PAQEV.pcsf") = False Then My.Computer.FileSystem.WriteAllText("Data\PAQEV.pcsf", "paq8pf_beta3.exe", False)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        About.ShowDialog()
    End Sub
End Class
