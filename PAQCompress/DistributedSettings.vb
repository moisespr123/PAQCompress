Public Class DistributedSettings
    Private Sub DistributedAccountWeakKey_TextChanged(sender As Object, e As EventArgs) Handles DistributedAccountWeakKey.TextChanged
        My.Settings.DistributedAccountWeakKey = DistributedAccountWeakKey.Text
        My.Settings.Save()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub DistributedSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DistributedAccountWeakKey.Text = My.Settings.DistributedAccountWeakKey
    End Sub
End Class