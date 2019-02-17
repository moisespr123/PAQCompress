Public Class Form1
    Private Flags_enable As Integer = 47
    Private f_flag_available As Integer = 56
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PAQSeries.SelectedItem = My.Settings.PAQSeries
        PAQVersion.SelectedItem = My.Settings.PAQVersion
        If paq_other.Text = "Threads" Then
            paq_other_dropbox.SelectedItem = My.Settings.pxdThreads
        Else
            paq_other_dropbox.SelectedItem = My.Settings.compiler
        End If
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
        Dim vars As String() = Environment.GetCommandLineArgs
        If vars.Count > 1 Then
            InputLocation.Text = vars(1)
            CheckAndAdjust()
        End If
    End Sub

    Private Sub AdjustPAQVersion(Filename As String)
        Dim split_filename As String() = Filename.Split({"."}, StringSplitOptions.RemoveEmptyEntries)
        For Each filename_split As String In split_filename
            Dim extension_split As String() = filename_split.Split({"_"}, StringSplitOptions.RemoveEmptyEntries)
            If extension_split.Count >= 2 Then
                For Each item As String In PAQSeries.Items
                    If item.ToLower = extension_split(0).ToLower Then
                        PAQSeries.SelectedItem = item
                    End If
                Next
                For Each item As String In PAQVersion.Items
                    If item.ToLower = extension_split(1).ToLower Then
                        PAQVersion.SelectedItem = item
                    End If
                Next
            ElseIf Filename.Contains(".paq8pxd") Then
                PAQSeries.SelectedItem = "PAQ8PXd"
                SetPAQVersion(Filename, ".paq8pxd")
                Exit For
            ElseIf Filename.Contains(".paq8pxv") Then
                PAQSeries.SelectedItem = "PAQ8PXv"
                SetPAQVersion(Filename, ".paq8pxv")
            ElseIf Filename.Contains(".paq8px") Then
                PAQSeries.SelectedItem = "PAQ8PX"
                SetPAQVersion(Filename, ".paq8px")
                Exit For
            ElseIf Filename.Contains(".paq8p_pc_") Then
                PAQSeries.SelectedItem = "PAQ8P_PC"
                SetPAQVersion(Filename, ".paq8p_pc_", False)
                Exit For
            End If
        Next
    End Sub
    Private Sub SetPAQVersion(Filename As String, Extension As String, Optional append_v As Boolean = True, Optional split_after_dot As Boolean = True)
        Dim split_paq_version As String() = Filename.Split({Extension}, StringSplitOptions.RemoveEmptyEntries)
        For Each splitted_item In split_paq_version
            Dim paq_version As String = String.Empty
            If append_v Then
                paq_version = "v" + splitted_item
            Else
                If split_after_dot Then
                    paq_version = splitted_item.Split({"."}, StringSplitOptions.RemoveEmptyEntries)(0)
                Else
                    paq_version = splitted_item
                End If
            End If
            For Each item As String In PAQVersion.Items
                If item.ToLower = paq_version Then
                    PAQVersion.SelectedItem = item
                End If
            Next
        Next
    End Sub
    Private Sub PAQSeries_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PAQSeries.SelectedIndexChanged
        PAQVersion.Items.Clear()
        PAQVersion.Text = String.Empty
        CompressionLevel.Items.Clear()
        CompressionLevel.Text = "0"
        paq_other_dropbox.Enabled = False
        paq_other_dropbox.Items.Clear()
        If PAQSeries.SelectedItem Is "PAQ8o10t" Or PAQSeries.SelectedItem Is "PAQ8PXPRE" Then
            CompressionLevel.Items.AddRange({"0", "1", "2", "3", "4", "5", "6", "7", "8"})
            PAQVersion.Enabled = False
        ElseIf PAQSeries.SelectedItem Is "PAQ8KX" Then
            PAQVersion.Items.AddRange({"v1", "v1_alt", "v2", "v2_alt", "v3", "v3_alt", "v4", "v4a", "v4adual2", "v5", "v6", "v7"})
            PAQVersion.Enabled = True
        ElseIf PAQSeries.SelectedItem Is "PAQ8PF" Then
            PAQVersion.Items.AddRange({"beta1", "beta2", "beta3"})
            PAQVersion.Enabled = True
        ElseIf PAQSeries.SelectedItem Is "PAQ8P_PC" Then
            PAQVersion.Items.AddRange({"v0"})
            PAQVersion.Enabled = True
        ElseIf PAQSeries.SelectedItem Is "FP8" Then
            PAQVersion.Items.AddRange({"v1", "v2", "v3", "v4", "v5", "v6"})
            PAQVersion.Enabled = True
        ElseIf PAQSeries.SelectedItem Is "PAQ8PXd" Then
            PAQVersion.Items.AddRange({"v60", "v61", "v62", "v63"})
            CompressionLevel.Text = "s5"
            CompressionLevel.Items.AddRange({"s0", "s1", "s2", "s3", "s4", "s5", "s6", "s7", "s8", "s9", "s10", "s11", "s12", "s13", "s14", "s15"})
            paq_other.Text = "Threads"
            paq_other_dropbox.Enabled = True
            paq_other_dropbox.Items.AddRange({"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"})
            paq_other_dropbox.SelectedItem = My.Settings.pxdThreads
            PAQVersion.Enabled = True
        ElseIf PAQSeries.SelectedItem Is "PAQ8PXv" Then
            PAQVersion.Items.AddRange({"v4", "v5"})
            CompressionLevel.Text = "s5"
            CompressionLevel.Items.AddRange({"s0", "s1", "s2", "s3", "s4", "s5", "s6", "s7", "s8", "s9", "s10", "s11", "s12", "s13", "s14", "s15"})
            paq_other.Text = "Compiler"
            paq_other_dropbox.Enabled = True
            paq_other_dropbox.Items.AddRange({"jit", "vm"})
            paq_other_dropbox.SelectedItem = My.Settings.compiler
            PAQVersion.Enabled = True
        ElseIf PAQSeries.SelectedItem Is "PAQ8PX" Then
            PAQVersion.Items.AddRange({"v42", "v44", "v45", "v46", "v47", "v48", "v49", "v51", "v52", "v53", "v54", "v57", "v58",
                                      "v60", "v60_Intel_SSE2", "v61_Intel_SSE2", "v64", "v64_Intel_SSE2", "v65", "v66", "v66_Intel_SSE2",
                                      "v67", "v67_Intel_SSE2", "v68", "v68_Intel_SSE2", "v68e", "v68p3", "v69", "v69_Intel_SSE2", "v70",
                                      "v71", "v72", "v73", "v74", "v75", "v77", "v80b", "v83", "v85", "v87", "v88", "v90", "v93", "v95",
                                      "v105", "v122", "v126", "v132_fix1", "v137", "v141", "v141fix1", "v141fix2", "v141fix4", "v144",
                                      "v145", "v146", "v156", "v157", "v159", "v163", "v164", "v167", "v168", "v169", "v170", "v171",
                                      "v172", "v173", "v174", "v175", "v176", "v177", "v178"})
            PAQVersion.Enabled = True
        End If
        If PAQVersion.Enabled Then
            If PAQVersion.Items.Contains(My.Settings.PAQVersion) Then
                PAQVersion.SelectedItem = My.Settings.PAQVersion
            Else
                PAQVersion.SelectedItem = PAQVersion.Items(PAQVersion.Items.Count - 1)
            End If
        End If
        EnableDisableFlags()
        AdjustOutputFilename()
        My.Settings.PAQSeries = PAQSeries.SelectedItem.ToString()
        My.Settings.Save()
    End Sub

    Private Sub PAQVersion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PAQVersion.SelectedIndexChanged
        CompressionLevel.Items.Clear()
        CompressionLevel.Items.AddRange({"0", "1", "2", "3", "4", "5", "6", "7", "8"})
        If PAQSeries.SelectedItem Is "PAQ8PX" Then
            If PAQVersion.SelectedIndex > Flags_enable Then
                CompressionLevel.Items.Add("9")
            Else
                CheckCompressionLevelAndChange()
            End If
        ElseIf PAQSeries.SelectedItem Is "PAQ8PXd" Or PAQSeries.SelectedItem Is "PAQ8PXv" Then
            CompressionLevel.Items.Clear()
            CompressionLevel.Items.AddRange({"s0", "s1", "s2", "s3", "s4", "s5", "s6", "s7", "s8", "s9", "s10", "s11", "s12", "s13", "s14", "s15"})
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
                If (PAQSeries.SelectedItem Is "PAQ8PX" And PAQVersion.SelectedIndex > Flags_enable) Or PAQSeries.SelectedItem Is "PAQ8PXd" Or PAQSeries.SelectedItem Is "PAQ8PXv" Then
                    OutputLocation.Text = IO.Path.GetDirectoryName(OutputLocation.Text) + "\" + IO.Path.GetFileNameWithoutExtension(OutputLocation.Text) + "." + PAQSeries.SelectedItem.ToString.ToLower + PAQVersion.SelectedItem.ToString().Remove(0, 1)
                Else
                    OutputLocation.Text = IO.Path.GetDirectoryName(OutputLocation.Text) + "\" + IO.Path.GetFileNameWithoutExtension(OutputLocation.Text) + "." + PAQSeries.SelectedItem.ToString.ToLower + "_" + PAQVersion.SelectedItem.ToString()
                End If

            Else
                OutputLocation.Text = IO.Path.GetDirectoryName(OutputLocation.Text) + "\" + IO.Path.GetFileNameWithoutExtension(OutputLocation.Text) + "." + PAQSeries.SelectedItem.ToString.ToLower
            End If
        End If
    End Sub

    Private Sub GetDirectoriesAndFiles(ByVal OrigLocation As String, ByVal BaseFolder As IO.DirectoryInfo, ByVal TextFile As IO.StreamWriter)
        For Each FI As IO.FileInfo In BaseFolder.GetFiles()
            TextFile.WriteLine(FI.FullName.Remove(0, OrigLocation.Count + 1))
        Next
        For Each subF As IO.DirectoryInfo In BaseFolder.GetDirectories()
            GetDirectoriesAndFiles(OrigLocation, subF, TextFile)
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
            If CompressRButton.Checked Then
                If PAQVersion.SelectedIndex > Flags_enable Then
                    EnableFlagsCheckboxes()
                Else
                    DisableFlagsCheckboxes()
                End If
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
        If PAQVersion.SelectedIndex > f_flag_available Then
            f_flag.Enabled = True
        Else
            f_flag.Enabled = False
        End If
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
                If PAQSeries.SelectedItem IsNot "PAQ8o10t" And PAQSeries.SelectedItem IsNot "PAQ8PXPRE" And PAQSeries.SelectedItem IsNot "PAQ8PXv" And PAQSeries.SelectedItem IsNot "PAQ8P_PC" Then
                    If PAQVersion.Items.Contains(PAQVersion.Text) Then
                        CompressorToUse = "Executables/" + PAQSeries.Text + "/" + PAQSeries.Text.ToLower + "_" + PAQVersion.Text + ".exe"
                    Else
                        MessageBox.Show("Select an item from the version dropdown")
                    End If
                ElseIf PAQSeries.SelectedItem Is "PAQ8PXv" Then
                    CompressorToUse = "Executables/" + PAQSeries.Text + "/" + PAQVersion.Text + "/" + PAQSeries.Text.ToLower() + "_" + PAQVersion.Text + paq_other_dropbox.Text.ToLower() + ".exe"
                ElseIf PAQSeries.SelectedItem Is "PAQ8P_PC" Then
                    CompressorToUse = "Executables/" + PAQSeries.Text + "/" + PAQVersion.Text + "/" + PAQSeries.Text.ToLower() + ".exe"
                Else
                    CompressorToUse = "Executables/" + PAQSeries.Text + "/" + PAQSeries.Text.ToLower + ".exe"
                End If
                If CompressRButton.Checked Then
                    If PAQSeries.SelectedItem Is "PAQ8o10t" Or PAQSeries.SelectedItem Is "PAQ8PXv" Then
                        CompressionParameters = "-" + CompressionLevel.Text + " """ + IO.Path.GetDirectoryName(OutputLocation.Text) + "\" + IO.Path.GetFileNameWithoutExtension(OutputLocation.Text) + """ """ + InputLocation.Text + """"
                    ElseIf PAQSeries.SelectedItem Is "PAQ8PXd" Then
                        CompressionParameters = "-" + CompressionLevel.Text + ":" + paq_other_dropbox.Text + " """ + IO.Path.GetDirectoryName(OutputLocation.Text) + "\" + IO.Path.GetFileNameWithoutExtension(OutputLocation.Text) + """ """ + InputLocation.Text + """"
                    Else
                        CompressionParameters = "-" + CompressionLevel.Text + " """ + OutputLocation.Text + """ """ + InputLocation.Text + """"
                    End If
                Else
                    CompressionParameters = "-d """ + InputLocation.Text + """ """ + OutputLocation.Text + """"
                End If
            ElseIf PAQSeries.SelectedItem Is "PAQ8PX" Then
                If PAQVersion.Items.Contains(PAQVersion.Text) Then
                    CompressorToUse = "Executables/PAQ8PX/paq8px_" + PAQVersion.Text + ".exe"
                    If CompressRButton.Checked Then
                        If PAQVersion.SelectedIndex > Flags_enable Then
                            Dim CompressionFlags As String = "-" + CompressionLevel.Text
                            If b_flag.Checked Then CompressionFlags += "b"
                            If e_flag.Checked Then CompressionFlags += "e"
                            If t_flag.Checked Then CompressionFlags += "t"
                            If a_flag.Checked Then CompressionFlags += "a"
                            If s_flag.Checked Then CompressionFlags += "s"
                            If PAQVersion.SelectedIndex > f_flag_available Then If f_flag.Checked Then CompressionFlags += "f"
                            Dim textFile As String = OutputLocation.Text + ".txt"
                            If My.Computer.FileSystem.DirectoryExists(InputLocation.Text) Then
                                Dim textFileStream As New IO.StreamWriter(textFile, False)
                                textFileStream.WriteLine()
                                GetDirectoriesAndFiles(IO.Path.GetDirectoryName(InputLocation.Text), New IO.DirectoryInfo(InputLocation.Text), textFileStream)
                                textFileStream.Close()
                                CompressionParameters = CompressionFlags + " ""@" + textFile + """ """ + OutputLocation.Text + """"
                            Else
                                My.Computer.FileSystem.WriteAllText(textFile, Environment.NewLine + IO.Path.GetFileName(InputLocation.Text), False)
                                CompressionParameters = CompressionFlags + " ""@" + textFile + """ """ + OutputLocation.Text + """"
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
            CompressorToUse = IO.Path.GetDirectoryName(Process.GetCurrentProcess.MainModule.FileName) + "/" + CompressorToUse
            If IO.File.Exists(CompressorToUse) Then
                StartButton.Enabled = False
                ClearLogButton.Enabled = False
                SaveLogButton.Enabled = False
                Dim StartCompressionThread = New Threading.Thread(Sub() CompressionThread(CompressorToUse, CompressionParameters))
                StartCompressionThread.Start()
            Else
                MsgBox("The selected compressor version could not be found. Cannot proceed")
            End If
        Else
            MessageBox.Show("No compressor has been selected. Cannot proceed.")
        End If
    End Sub

    Private Sub CompressionThread(Compressor As String, Params As String)
        Using process As New Process()
            process.StartInfo.WorkingDirectory = IO.Path.GetDirectoryName(Compressor)
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
            ClearLogButton.BeginInvoke(Sub() ClearLogButton.Enabled = True)
            SaveLogButton.BeginInvoke(Sub() SaveLogButton.Enabled = True)
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
        EnableDisableFlags()
        BrowseFolder.Enabled = True
        Step1Label.Text = "Step 1: Browse for a file or folder to compress:"
        Step2Label.Text = "Step 2: Browse for a location to store the compressed file:"
        My.Settings.CompressChecked = CompressRButton.Checked
        My.Settings.Save()
    End Sub

    Private Sub ExtractRButton_CheckedChanged(sender As Object, e As EventArgs) Handles ExtractRButton.CheckedChanged
        EnableDisableFlags()
        BrowseFolder.Enabled = False
        Step1Label.Text = "Step 1: Browse for a file/archive to extract:"
        Step2Label.Text = "Step 2: Browse for a location to extract the file/archive:"
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
            CheckAndAdjust()
        End If
    End Sub
    Private Sub CheckAndAdjust()
        If ExtractRButton.Checked Then
            AdjustPAQVersion(IO.Path.GetFileName(InputLocation.Text))
        Else
            OutputLocation.Text = InputLocation.Text
            AdjustOutputFilename()
        End If
    End Sub
    Private Sub BrowseFolder_Click(sender As Object, e As EventArgs) Handles BrowseFolder.Click
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog
        If result = DialogResult.OK Then
            InputLocation.Text = FolderBrowserDialog1.SelectedPath
            OutputLocation.Text = InputLocation.Text
            AdjustOutputFilename()
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
        Else
            Dim result As DialogResult = FolderBrowserDialog2.ShowDialog
            If result = DialogResult.OK Then
                OutputLocation.Text = FolderBrowserDialog2.SelectedPath
            End If
        End If
    End Sub

    Private Sub SaveLogButton_Click(sender As Object, e As EventArgs) Handles SaveLogButton.Click
        Dim SaveDialog As New SaveFileDialog With {
           .Filter = "Text file|*.txt",
           .FileName = String.Empty,
           .Title = "Browse to save the log"}
        Dim result As DialogResult = SaveDialog.ShowDialog
        If result = DialogResult.OK Then
            If Not String.IsNullOrWhiteSpace(SaveDialog.FileName) Then My.Computer.FileSystem.WriteAllText(SaveDialog.FileName, Log.Text, False)
        End If
    End Sub

    Private Sub ClearLogButton_Click(sender As Object, e As EventArgs) Handles ClearLogButton.Click
        Log.Text = String.Empty
    End Sub

    Private Sub pxdThreads_SelectedIndexChanged(sender As Object, e As EventArgs) Handles paq_other_dropbox.SelectedIndexChanged
        If paq_other.Text = "Threads" Then
            My.Settings.pxdThreads = paq_other_dropbox.SelectedItem.ToString()
        Else
            My.Settings.compiler = paq_other_dropbox.SelectedItem.ToString()
        End If
        My.Settings.Save()
    End Sub
    Private Sub Form1_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
        InputLocation.Text = CType(e.Data.GetData(DataFormats.FileDrop), String())(0)
        CheckAndAdjust()
    End Sub
End Class
