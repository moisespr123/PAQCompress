Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PAQSeries.SelectedItem = My.Settings.PAQSeries
        PAQVersion.SelectedItem = My.Settings.PAQVersion
        CompressionLevel.SelectedItem = My.Settings.CompressionLevel
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
        EnableDisableFlags()
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
            If PAQSeries.SelectedItem Is "PAQ8KX" Then
                If PAQVersion.Items.Contains(PAQVersion.Text) Then
                    CompressorToUse = "Executables/PAQ8KX/paq8kx_" + PAQVersion.Text + ".exe"
                    If CompressRButton.Checked Then
                        CompressionParameters = "-" + CompressionLevel.Text + " """ + OutputLocation.Text + """ """ + InputLocation.Text + """"
                    End If
                Else
                    MessageBox.Show("Select an item from the version dropdown")
                End If
            End If
            If PAQSeries.SelectedItem Is "PAQ8PX" Then
                If PAQVersion.Items.Contains(PAQVersion.Text) Then
                    CompressorToUse = "Executables/PAQ8PX/paq8px_" + PAQVersion.Text + ".exe"
                    If CompressRButton.Checked Then
                        CompressionParameters = "-" + CompressionLevel.Text + " """ + InputLocation.Text + """ """ + OutputLocation.Text + """"
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
            process.StartInfo.CreateNoWindow = False
            AddHandler process.OutputDataReceived, New DataReceivedEventHandler(Sub(sender, e)
                                                                                    If Not e.Data = Nothing Then
                                                                                        UpdateLog(e.Data)
                                                                                    End If
                                                                                End Sub)
            AddHandler process.ErrorDataReceived, New DataReceivedEventHandler(Sub(sender, e)
                                                                                   If Not e.Data = Nothing Then
                                                                                       UpdateLog(e.Data)
                                                                                   End If
                                                                               End Sub)
            process.Start()
            process.BeginOutputReadLine()
            process.BeginErrorReadLine()
            process.WaitForExit()
            StartButton.BeginInvoke(Sub() StartButton.Enabled = True)
        End Using
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
End Class
