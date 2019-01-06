Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub PAQSeries_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PAQSeries.SelectedIndexChanged
        PAQVersion.Items.Clear()
        PAQVersion.Text = String.Empty
        If PAQSeries.SelectedItem = "PAQ8o10t" Or PAQSeries.SelectedItem = "PAQ8PXPRE" Then
            PAQVersion.Enabled = False
        ElseIf PAQSeries.SelectedItem = "PAQ8KX" Then
            PAQVersion.Items.AddRange({"v1", "v2", "v3", "v4", "v4a", "v4adual2", "v5", "v6", "v7"})
            PAQVersion.Enabled = True
        ElseIf PAQSeries.SelectedItem = "PAQ8PF" Then
            PAQVersion.Items.AddRange({"beta1", "beta2", "beta3"})
            PAQVersion.Enabled = True
        End If
    End Sub
End Class
