Public Class Compress

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If CheckBox1.Checked = True Then
            If RadioButton1.Checked = True Then Process.Start("cmd.exe", "/C paq8o10t.exe -0 """ & TextBox1.Text & """")
            If RadioButton2.Checked = True Then Process.Start("cmd.exe", "/C paq8o10t.exe -1 """ & TextBox1.Text & """")
            If RadioButton3.Checked = True Then Process.Start("cmd.exe", "/C paq8o10t.exe -2 """ & TextBox1.Text & """")
            If RadioButton4.Checked = True Then Process.Start("cmd.exe", "/C paq8o10t.exe -3 """ & TextBox1.Text & """")
            If RadioButton5.Checked = True Then Process.Start("cmd.exe", "/C paq8o10t.exe -4 """ & TextBox1.Text & """")
            If RadioButton6.Checked = True Then Process.Start("cmd.exe", "/C paq8o10t.exe -5 """ & TextBox1.Text & """")
            If RadioButton7.Checked = True Then Process.Start("cmd.exe", "/C paq8o10t.exe -6 """ & TextBox1.Text & """")
            If RadioButton8.Checked = True Then Process.Start("cmd.exe", "/C paq8o10t.exe -7 """ & TextBox1.Text & """")
            If RadioButton9.Checked = True Then Process.Start("cmd.exe", "/C paq8o10t.exe -8 """ & TextBox1.Text & """")
        End If
        If CheckBox1.Checked = False Then
            If RadioButton1.Checked = True Then Process.Start("cmd.exe", "/C paq8o10t.exe -0 """ & TextBox2.Text & """ """ & TextBox1.Text & """")
            If RadioButton2.Checked = True Then Process.Start("cmd.exe", "/C paq8o10t.exe -1 """ & TextBox2.Text & """ """ & TextBox1.Text & """")
            If RadioButton3.Checked = True Then Process.Start("cmd.exe", "/C paq8o10t.exe -2 """ & TextBox2.Text & """ """ & TextBox1.Text & """")
            If RadioButton4.Checked = True Then Process.Start("cmd.exe", "/C paq8o10t.exe -3 """ & TextBox2.Text & """ """ & TextBox1.Text & """")
            If RadioButton5.Checked = True Then Process.Start("cmd.exe", "/C paq8o10t.exe -4 """ & TextBox2.Text & """ """ & TextBox1.Text & """")
            If RadioButton6.Checked = True Then Process.Start("cmd.exe", "/C paq8o10t.exe -5 """ & TextBox2.Text & """ """ & TextBox1.Text & """")
            If RadioButton7.Checked = True Then Process.Start("cmd.exe", "/C paq8o10t.exe -6 """ & TextBox2.Text & """ """ & TextBox1.Text & """")
            If RadioButton8.Checked = True Then Process.Start("cmd.exe", "/C paq8o10t.exe -7 """ & TextBox2.Text & """ """ & TextBox1.Text & """")
            If RadioButton9.Checked = True Then Process.Start("cmd.exe", "/C paq8o10t.exe -8 """ & TextBox2.Text & """ """ & TextBox1.Text & """")
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.ReadOnly = True
            Button4.Enabled = False
        End If
        If CheckBox1.Checked = False Then
            TextBox2.ReadOnly = False
            Button4.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.OpenFileDialog1.Title = "Please select File to compress"
        Me.OpenFileDialog1.Filter = "All Files|*.*"
        Me.OpenFileDialog1.FileName = ""
        Me.OpenFileDialog1.ShowDialog()
        Me.TextBox1.Text = Me.OpenFileDialog1.FileName
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.FolderBrowserDialog1.ShowDialog()
        Me.TextBox1.Text = Me.FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.SaveFileDialog1.Title = "Enter Archive Name"
        Me.SaveFileDialog1.Filter = "PAQ8O Compression Format (*.paq8o10t)|"
        Me.SaveFileDialog1.ShowDialog()
        Me.TextBox2.Text = Me.SaveFileDialog1.FileName
    End Sub
End Class