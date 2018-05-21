Public Class FP8Extract

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        My.Computer.FileSystem.DeleteFile("Data\PAQEV.pcsf")
        My.Computer.FileSystem.WriteAllText("Data\PAQEV.pcsf", "fp8_v1.exe", False)
        MsgBox("You choose FP8 v1.")
        Me.Close()
    End Sub
End Class