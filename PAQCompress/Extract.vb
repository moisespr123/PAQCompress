Public Class Extract

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim PAQDir As String = ""
        Dim PAQ As New ProcessStartInfo
        Dim StartPAQ As Process
        PAQ.WorkingDirectory = PAQDir
        PAQ.FileName = My.Computer.FileSystem.ReadAllText("Data\PAQEV.pcsf")
        PAQ.Arguments = """" & TextBox1.Text & """ """ & TextBox2.Text & """"
        PAQ.CreateNoWindow = True 'creates no cmd window
        StartPAQ = Process.Start(PAQ)
        StartPAQ.WaitForExit()
        MsgBox("PAQ Archive Extracted!")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        OpenFileDialog1.Title = "Please select File to Extract"
        OpenFileDialog1.Filter = "PAQ8 Compressed Archive|*.paq8o10t; *.paq8px; *.paq8pf; *.paq8kx; *.paq8pxpre; *.fp8"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName = "" = False Then TextBox1.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then PAQ8PXExtract.ShowDialog()
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then PAQ8PFExtract.ShowDialog()
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then PAQ8KXExtract.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        FolderBrowserDialog1.ShowNewFolderButton = True
        FolderBrowserDialog1.ShowDialog()
        If FolderBrowserDialog1.SelectedPath = "" = False Then TextBox2.Text = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged
        If RadioButton6.Checked = True Then FP8Extract.ShowDialog()
    End Sub
End Class