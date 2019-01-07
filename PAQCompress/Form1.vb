Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PAQSeries.SelectedItem = My.Settings.PAQSeries
        PAQVersion.SelectedItem = My.Settings.PAQVersion
        CompressionLevel.SelectedItem = My.Settings.CompressionLevel
        CompressRButton.Checked = My.Settings.CompressChecked
        ExtractRButton.Checked = My.Settings.ExtractChecked
        b_flag.Checked = My.Settings.b_flag
        e_flag.Checked = My.Settings.e_flag
        t_flag.Checked = My.Settings.t_flag
        a_flag.Checked = My.Settings.a_flag
        s_flag.Checked = My.Settings.s_flag
        f_flag.Checked = My.Settings.f_flag
        EnableDisableFlags()
    End Sub

    Private Sub PAQSeries_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PAQSeries.SelectedIndexChanged
        PAQVersion.Items.Clear()
        PAQVersion.Text = String.Empty
        CompressionLevel.Items.Clear()
        CompressionLevel.Text = "0"
        If PAQSeries.SelectedItem Is "PAQ8o10t" Or PAQSeries.SelectedItem Is "PAQ8PXPRE" Then
            CompressionLevel.Items.AddRange({"0", "1", "2", "3", "4", "5", "6", "7", "8"})
            PAQVersion.Enabled = False
        ElseIf PAQSeries.SelectedItem Is "PAQ8KX" Then
            PAQVersion.Items.AddRange({"v1", "v1_alt", "v2", "v2_alt", "v3", "v3_alt", "v4", "v4a", "v4adual2", "v5", "v6", "v7"})
            PAQVersion.Enabled = True
        ElseIf PAQSeries.SelectedItem Is "PAQ8PF" Then
            PAQVersion.Items.AddRange({"beta1", "beta2", "beta3"})
            PAQVersion.Enabled = True
        ElseIf PAQSeries.SelectedItem Is "FP8" Then
            PAQVersion.Items.AddRange({"v1", "v2", "v3", "v4", "v5", "v6"})
            PAQVersion.Enabled = True
        ElseIf PAQSeries.SelectedItem Is "PAQ8PX" Then
            PAQVersion.Items.AddRange({"v42", "v44", "v45", "v46", "v47", "v48", "v49", "v51", "v52", "v53", "v54", "v57", "v58",
                                      "v60", "v60_Intel_SSE2", "v61_Intel_SSE2", "v64", "v64_Intel_SSE2", "v65", "v66", "v66_Intel_SSE2",
                                      "v67", "v67_Intel_SSE2", "v68", "v68_Intel_SSE2", "v68e", "v68p3", "v69", "v69_Intel_SSE2", "v174"})
            PAQVersion.Enabled = True
        End If
        If PAQVersion.Enabled Then PAQVersion.SelectedItem = PAQVersion.Items(PAQVersion.Items.Count - 1)
        EnableDisableFlags()
        AdjustOutputFilename()
        My.Settings.PAQSeries = PAQSeries.SelectedItem.ToString()
        My.Settings.Save()
    End Sub

    Private Sub PAQVersion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PAQVersion.SelectedIndexChanged
        CompressionLevel.Items.Clear()
        CompressionLevel.Items.AddRange({"0", "1", "2", "3", "4", "5", "6", "7", "8"})
        If PAQSeries.SelectedItem Is "PAQ8PX" Then
            If PAQVersion.SelectedIndex > 28 Then
                CompressionLevel.Items.Add("9")
            Else
                CheckCompressionLevelAndChange()
            End If
        Else
            CheckCompressionLevelAndChange()
        End If
        EnableDisableFlags()
        AdjustOutputFilename()
        My.Settings.PAQVersion = PAQVersion.SelectedItem.ToString()
        My.Settings.Save()
    End Sub
    Private Sub AdjustOutputFilename()
        If Not String.IsNullOrWhiteSpace(OutputLocation.Text) Then
            If PAQVersion.Enabled Then
                OutputLocation.Text = IO.Path.GetDirectoryName(OutputLocation.Text) + "\" + IO.Path.GetFileNameWithoutExtension(OutputLocation.Text) + "." + PAQSeries.SelectedItem.ToString.ToLower + "_" + PAQVersion.SelectedItem.ToString()
            Else
                OutputLocation.Text = IO.Path.GetDirectoryName(OutputLocation.Text) + "\" + IO.Path.GetFileNameWithoutExtension(OutputLocation.Text) + "." + PAQSeries.SelectedItem.ToString.ToLower
            End If
        End If
    End Sub

    Private Sub GetDirectoriesAndFiles(ByVal BaseFolder As IO.DirectoryInfo, ByVal TextFile As IO.StreamWriter)
        For Each FI As IO.FileInfo In BaseFolder.GetFiles()
            TextFile.WriteLine(FI.FullName)
        Next
        For Each subF As IO.DirectoryInfo In BaseFolder.GetDirectories()
            GetDirectoriesAndFiles(subF, TextFile)
        Next
    End Sub
    Private Sub CheckCompressionLevelAndChange()
        If CompressionLevel.Text = "9" Then
            CompressionLevel.Text = "8"
            CompressionLevel.SelectedItem = "8"
        End If
    End Sub
    Private Sub EnableDisableFlags()
        If PAQSeries.SelectedItem Is "PAQ8PX" Then
            If PAQVersion.SelectedIndex > 28 Then
                EnableFlagsCheckboxes()
            Else
                DisableFlagsCheckboxes()
            End If
        Else
            DisableFlagsCheckboxes()
        End If
    End Sub
    Private Sub EnableFlagsCheckboxes()
        b_flag.Enabled = True
        e_flag.Enabled = True
        t_flag.Enabled = True
        a_flag.Enabled = True
        s_flag.Enabled = True
        f_flag.Enabled = True
    End Sub
    Private Sub DisableFlagsCheckboxes()
        b_flag.Enabled = False
        e_flag.Enabled = False
        t_flag.Enabled = False
        a_flag.Enabled = False
        s_flag.Enabled = False
        f_flag.Enabled = False
    End Sub
    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        Dim CompressorToUse As String = String.Empty
        Dim CompressionParameters As String = String.Empty
        If CompressionLevel.Items.Contains(CompressionLevel.Text) Then
            If PAQSeries.SelectedItem IsNot "PAQ8PX" Then
                If PAQSeries.SelectedItem IsNot "PAQ8o10t" And PAQSeries.SelectedItem IsNot "PAQ8PXPRE" Then
                    If PAQVersion.Items.Contains(PAQVersion.Text) Then
                        CompressorToUse = "Executables/" + PAQSeries.Text + "/" + PAQSeries.Text.ToLower + "_" + PAQVersion.Text + ".exe"
                    Else
                        MessageBox.Show("Select an item from the version dropdown")
                    End If
                Else
                    CompressorToUse = "Executables/" + PAQSeries.Text + "/" + PAQSeries.Text.ToLower + ".exe"
                End If
                If CompressRButton.Checked Then
                    CompressionParameters = "-" + CompressionLevel.Text + " """ + OutputLocation.Text + """ """ + InputLocation.Text + """"
                Else
                    CompressionParameters = "-d """ + InputLocation.Text + """ """ + OutputLocation.Text + """"
                End If
            ElseIf PAQSeries.SelectedItem Is "PAQ8PX" Then
                If PAQVersion.Items.Contains(PAQVersion.Text) Then
                    CompressorToUse = "Executables/PAQ8PX/paq8px_" + PAQVersion.Text + ".exe"
                    If CompressRButton.Checked Then
                        If PAQVersion.SelectedIndex > 28 Then
                            Dim CompressionFlags As String = "-" + CompressionLevel.Text
                            If b_flag.Checked Then CompressionFlags += "b"
                            If e_flag.Checked Then CompressionFlags += "e"
                            If t_flag.Checked Then CompressionFlags += "t"
                            If a_flag.Checked Then CompressionFlags += "a"
                            If s_flag.Checked Then CompressionFlags += "s"
                            If f_flag.Checked Then CompressionFlags += "f"
                            If My.Computer.FileSystem.DirectoryExists(InputLocation.Text) Then
                                Dim textFile As String = IO.Path.GetDirectoryName(OutputLocation.Text) + "\" + IO.Path.GetFileNameWithoutExtension(OutputLocation.Text) + ".txt"
                                Dim textFileStream As New IO.StreamWriter(textFile, False)
                                GetDirectoriesAndFiles(New IO.DirectoryInfo(InputLocation.Text), textFileStream)
                                textFileStream.Close()
                                CompressionParameters = CompressionFlags + " ""@" + textFile + """ """ + OutputLocation.Text + """"
                            Else
                                CompressionParameters = CompressionFlags + " """ + InputLocation.Text + """ """ + OutputLocation.Text + """"
                            End If
                        Else
                            CompressionParameters = "-" + CompressionLevel.Text + " """ + OutputLocation.Text + """ """ + InputLocation.Text + """"
                        End If
                    Else
                        CompressionParameters = "-d """ + InputLocation.Text + """ """ + OutputLocation.Text + """"

                    End If
                Else
                    MessageBox.Show("Select an item from the version dropdown")
                End If
            End If
        End If
        If Not String.IsNullOrEmpty(CompressorToUse) And Not String.IsNullOrEmpty(CompressionParameters) Then
            StartButton.Enabled = False
            Dim StartCompressionThread = New Threading.Thread(Sub() CompressionThread(CompressorToUse, CompressionParameters))
            StartCompressionThread.Start()
        Else
            MessageBox.Show("No compressor has been selected. Cannot proceed.")
        End If
    End Sub

    Private Sub CompressionThread(Compressor As String, Params As String)
        Using process As New Process()
            process.StartInfo.WorkingDirectory = Environment.CurrentDirectory
            process.StartInfo.FileName = Compressor
            process.StartInfo.Arguments = Params
            process.StartInfo.UseShellExecute = False
            process.StartInfo.RedirectStandardOutput = True
            process.StartInfo.RedirectStandardError = True
            process.StartInfo.CreateNoWindow = True
            AddHandler process.OutputDataReceived, New DataReceivedEventHandler(AddressOf UpdateLogEventHandler)
            AddHandler process.ErrorDataReceived, New DataReceivedEventHandler(AddressOf UpdateLogEventHandler)
            process.Start()
            process.BeginOutputReadLine()
            process.BeginErrorReadLine()
            process.WaitForExit()
            StartButton.BeginInvoke(Sub() StartButton.Enabled = True)
        End Using
    End Sub

    Private Sub UpdateLogEventHandler(sender As Object, e As DataReceivedEventArgs)
        If Not e.Data = Nothing Then
            UpdateLog(e.Data)
        End If
    End Sub
    Private Delegate Sub UpdateLogInvoker(message As String)
    Private Sub UpdateLog(message As String)
        If Log.InvokeRequired Then
            Log.Invoke(New UpdateLogInvoker(AddressOf UpdateLog), message)
        Else
            If Not String.IsNullOrWhiteSpace(message) Then
                message = message.Replace(vbBack, "")
                Log.AppendText(Date.Now().ToString() + " || " + message + vbCrLf)
                Log.SelectionStart = Log.Text.Length - 1
                Log.ScrollToCaret()
            End If
        End If
    End Sub

    Private Sub CompressRButton_CheckedChanged(sender As Object, e As EventArgs) Handles CompressRButton.CheckedChanged
        My.Settings.CompressChecked = CompressRButton.Checked
        My.Settings.Save()
    End Sub

    Private Sub ExtractRButton_CheckedChanged(sender As Object, e As EventArgs) Handles ExtractRButton.CheckedChanged
        My.Settings.ExtractChecked = ExtractRButton.Checked
        My.Settings.Save()
    End Sub

    Private Sub b_flag_CheckedChanged(sender As Object, e As EventArgs) Handles b_flag.CheckedChanged
        My.Settings.b_flag = b_flag.Checked
        My.Settings.Save()
    End Sub

    Private Sub e_flag_CheckedChanged(sender As Object, e As EventArgs) Handles e_flag.CheckedChanged
        My.Settings.e_flag = e_flag.Checked
        My.Settings.Save()
    End Sub

    Private Sub t_flag_CheckedChanged(sender As Object, e As EventArgs) Handles t_flag.CheckedChanged
        My.Settings.t_flag = t_flag.Checked
        My.Settings.Save()
    End Sub

    Private Sub a_flag_CheckedChanged(sender As Object, e As EventArgs) Handles a_flag.CheckedChanged
        My.Settings.a_flag = a_flag.Checked
        My.Settings.Save()
    End Sub

    Private Sub s_flag_CheckedChanged(sender As Object, e As EventArgs) Handles s_flag.CheckedChanged
        My.Settings.s_flag = s_flag.Checked
        My.Settings.Save()
    End Sub

    Private Sub f_flag_CheckedChanged(sender As Object, e As EventArgs) Handles f_flag.CheckedChanged
        My.Settings.f_flag = s_flag.Checked
        My.Settings.Save()
    End Sub

    Private Sub CompressionLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CompressionLevel.SelectedIndexChanged
        My.Settings.CompressionLevel = CompressionLevel.SelectedItem.ToString()
        My.Settings.Save()
    End Sub

    Private Sub BrowseFile_Click(sender As Object, e As EventArgs) Handles BrowseFile.Click
        OpenFileDialog1.Filter = "All Files|*.*"
        OpenFileDialog1.Title = "Browse for a file to compress"
        If Not String.IsNullOrWhiteSpace(InputLocation.Text) Then OpenFileDialog1.FileName = IO.Path.GetFileName(InputLocation.Text)
        Dim result As DialogResult = OpenFileDialog1.ShowDialog
        If result = DialogResult.OK Then
            InputLocation.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog
        If result = DialogResult.OK Then
            InputLocation.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub BrowseOutput_Click(sender As Object, e As EventArgs) Handles BrowseOutput.Click
        If CompressRButton.Checked Then
            SaveFileDialog1.Filter = "PAQ file|*.paq"
            SaveFileDialog1.Title = "Browse for a file to compress"
            If Not String.IsNullOrWhiteSpace(InputLocation.Text) Then SaveFileDialog1.FileName = IO.Path.GetFileName(OutputLocation.Text)
            Dim result As DialogResult = SaveFileDialog1.ShowDialog
            If result = DialogResult.OK Then
                OutputLocation.Text = SaveFileDialog1.FileName
                AdjustOutputFilename()
            End If
        End If
    End Sub
End Class
