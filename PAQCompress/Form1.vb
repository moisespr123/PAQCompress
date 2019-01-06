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
        ElseIf PAQSeries.SelectedItem = "FP8" Then
            PAQVersion.Items.AddRange({"v1", "v2", "v3", "v4", "v5", "v6"})
            PAQVersion.Enabled = True
        ElseIf PAQSeries.SelectedItem = "PAQ8PX" Then
            PAQVersion.Items.AddRange({"v42", "v44", "v45", "v46", "v47", "v48", "v49", "v51", "v52", "v53", "v54", "v57", "v58",
                                      "v60", "v60_Intel_SSE2", "v61_Intel_SSE2", "v64", "v64_Intel_SSE2", "v65", "v66", "v66_Intel_SSE2",
                                      "v67", "v67_Intel_SSE2", "v68", "v68_Intel_SSE2", "v68e", "v68p3", "v69", "v69_Intel_SSE2"})
            PAQVersion.Enabled = True
        End If
    End Sub

    Private Sub PAQVersion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PAQVersion.SelectedIndexChanged

    End Sub
End Class
