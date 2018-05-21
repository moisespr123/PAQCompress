Public Class PAQ8PFExtract

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        My.Computer.FileSystem.DeleteFile("Data\PAQEV.pcsf")
        My.Computer.FileSystem.WriteAllText("Data\PAQEV.pcsf", "paq8pf_beta1.exe", False)
        MsgBox("You choose PAQ8PF Beta 1")
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Computer.FileSystem.DeleteFile("Data\PAQEV.pcsf")
        My.Computer.FileSystem.WriteAllText("Data\PAQEV.pcsf", "paq8pf_beta2.exe", False)
        MsgBox("You choose PAQ8PF Beta 2")
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        My.Computer.FileSystem.DeleteFile("Data\PAQEV.pcsf")
        My.Computer.FileSystem.WriteAllText("Data\PAQEV.pcsf", "paq8pf_beta3.exe", False)
        MsgBox("You choose PAQ8PF Beta 3")
        Me.Close()
    End Sub
End Class