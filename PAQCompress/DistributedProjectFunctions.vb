Public Class DistributedProjectFunctions
    Private Function GenerateCommandLineArguments() As String
        Dim CompressionFlags As String = "-" + Form1.CompressionLevel.Text
        If Form1.PAQSeries.SelectedItem Is "PAQ8PX" Then
            If Form1.PAQVersion.SelectedIndex > Form1.Flags_enable Then
                If Form1.b_flag.Checked Then CompressionFlags += "b"
                If Form1.e_flag.Checked Then CompressionFlags += "e"
                If Form1.t_flag.Checked Then CompressionFlags += "t"
                If Form1.a_flag.Checked Then CompressionFlags += "a"
                If Form1.s_flag.Checked Then CompressionFlags += "s"
                If Form1.PAQVersion.SelectedIndex > Form1.f_flag_available Then If Form1.f_flag.Checked Then CompressionFlags += "f"
            End If
        End If
        Return CompressionFlags
    End Function
End Class
