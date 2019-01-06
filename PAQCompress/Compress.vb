Public Class Compress

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim PAQVersion As String = "NotAsigned"
        If RadioButton10.Checked = True Then PAQVersion = "paq8o10t.exe"
        If RadioButton11.Checked = True Then PAQVersion = "paq8px_v69.exe"
        If RadioButton12.Checked = True Then PAQVersion = "paq8pf_beta3.exe"
        If RadioButton13.Checked = True Then PAQVersion = "paq8kx_v3.exe"
        If RadioButton14.Checked = True Then PAQVersion = "paq8pxpre.exe"
        If RadioButton15.Checked = True Then PAQVersion = "fp8_v1.exe"
        Dim Level As String = "NotAsigned"
        'If RadioButton1.Checked = True Then Level = "-0"
        'If RadioButton2.Checked = True Then Level = "-1"
        'If RadioButton3.Checked = True Then Level = "-2"
        'If RadioButton4.Checked = True Then Level = "-3"
        'If RadioButton5.Checked = True Then Level = "-4"
        'If RadioButton6.Checked = True Then Level = "-5"
        'If RadioButton7.Checked = True Then Level = "-6"
        'If RadioButton8.Checked = True Then Level = "-7"
        'If RadioButton9.Checked = True Then Level = "-8"
        If PAQVersion = Not "NotAsigned" Or Level = Not "NotAsigned" Then
            If CheckBox1.Checked = True Then
                Dim PAQDir As String = ""
                Dim PAQ As New ProcessStartInfo
                Dim StartPAQ As Process
                PAQ.WorkingDirectory = PAQDir
                PAQ.FileName = PAQVersion
                PAQ.Arguments = "" & Level & " """ & TextBox1.Text & """"
                PAQ.CreateNoWindow = True 'creates no cmd window
                StartPAQ = Process.Start(PAQ)
                StartPAQ.WaitForExit()
                MsgBox("File/folder Compressed to PAQ")
            End If
            If CheckBox1.Checked = False Then
                Dim PAQDir As String = ""
                Dim PAQ As New ProcessStartInfo
                Dim StartPAQ As Process
                PAQ.WorkingDirectory = PAQDir
                PAQ.FileName = PAQVersion
                PAQ.Arguments = "" & Level & " """ & TextBox2.Text & """ """ & TextBox1.Text & """"
                PAQ.CreateNoWindow = True 'creates no cmd window
                StartPAQ = Process.Start(PAQ)
                StartPAQ.WaitForExit()
                MsgBox("File/folder Compressed to PAQ")
            End If
        Else : MsgBox("An Error has ocurred. Compression could not start. Please check that a compression version and a compression level has been selected. If This error keeps prompting, please restart the software or restart the PC")
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
        OpenFileDialog1.Title = "Please select File to compress"
        OpenFileDialog1.Filter = "All Files|*.*"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName = "" = False Then TextBox1.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        FolderBrowserDialog1.ShowDialog()
        If FolderBrowserDialog1.SelectedPath = "" = False Then TextBox1.Text = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        SaveFileDialog1.Title = "Enter Archive Name"
        SaveFileDialog1.Filter = "PAQ Compression Format|*.*"
        SaveFileDialog1.ShowDialog()
        If SaveFileDialog1.FileName = "" = False Then TextBox2.Text = SaveFileDialog1.FileName
    End Sub
End Class