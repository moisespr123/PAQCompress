Public Class Extract

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Process.Start("cmd.exe", "/C paq8o10t.exe -d """ & TextBox1.Text & """")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.OpenFileDialog1.Title = "Please select File to Extract"
        Me.OpenFileDialog1.Filter = "PAQ8O Compression Format| *.paq8o10t"
        Me.OpenFileDialog1.FileName = ""
        Me.OpenFileDialog1.ShowDialog()
        Me.TextBox1.Text = Me.OpenFileDialog1.FileName
    End Sub
End Class