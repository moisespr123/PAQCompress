Public Class Form1
    Public Const Flags_enable As Integer = 47
    Public Const f_flag_available As Integer = 56
    Public Const f_flag_disable As Integer = 81
    Private Const paq8px_use_exe_in_folder As Integer = 74
    Private Const paq8px_enable_levels_10_12 = 94
    Private Const paq8px_enable_l_flag = 98
    Private Const paq8px_enable_r_flag = 100
    Private Const change_r_flag_text = 102
    Private Const fp8sk_enable_level_9 = 6
    Private Const paq8pxd_add_x_levels As Integer = 28
    Private Const paq8px_nativecpus As Integer = 100
    Private Const paq8pxd_nativecpus As Integer = 44 'Starting on v90.
    Private Const paq8gen_enable_a_flag As Integer = 1 'v2fixa
    Private ReadOnly DistributedPAQCompressors As New Dictionary(Of String, String())() From {{"PAQ8PX", {"v185", "v186", "v186fix1", "v187",
                                                                                                          "v187fix3", "v187fix5", "v188", "v189",
                                                                                                          "v193fix2", "v198", "v201"}},
                                                                                              {"PAQ8PXd", {"v85", "v86"}}}

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
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
        l_flag.Checked = My.Settings.l_flag
        r_flag.Checked = My.Settings.r_flag
        deleteFileList.Checked = My.Settings.deleteFileList
        useNativeCPU.Checked = My.Settings.useNativeCPU
        ShowCMD.Checked = My.Settings.ShowCMD
        GenerateBatchScriptOnly.Checked = My.Settings.OnlyGenerateBatchFile
        DontCreateTextFile.Checked = My.Settings.DontCreateTextFile
        EnableDisableFlags()
        Dim vars As String() = Environment.GetCommandLineArgs
        If vars.Count > 1 Then
            InputLocation.Text = vars(1)
            CheckAndAdjust()
        End If
        If My.Settings.ShowDistributedOption Then
            SendToDistributedProject.Visible = True
            SendToDistributedProject.Checked = My.Settings.SendToDistributedProject
            DistributedProcessingOptions.Visible = True
        Else
            My.Settings.SendToDistributedProject = False
            My.Settings.Save()
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
            ElseIf Filename.Contains(".fp8sk") Then
                PAQSeries.SelectedItem = "FP8sk"
                SetPAQVersion(Filename, ".fp8sk")
                Exit For
            ElseIf Filename.Contains(".paq8gen") Then
                PAQSeries.SelectedItem = "PAQ8gen"
                SetPAQVersion(Filename, ".paq8gen")
                Exit For
            ElseIf Filename.Contains(".paq8pxd") Then
                PAQSeries.SelectedItem = "PAQ8PXd"
                SetPAQVersion(Filename, ".paq8pxd")
                Exit For
            ElseIf Filename.Contains(".paq8sk") Then
                PAQSeries.SelectedItem = "PAQ8SK"
                SetPAQVersion(Filename, ".paq8sk")
                Exit For
            ElseIf Filename.Contains(".paq8pxv") Then
                PAQSeries.SelectedItem = "PAQ8PXv"
                SetPAQVersion(Filename, ".paq8pxv")
                Exit For
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
        If Filename.Contains(".native.") Then
            useNativeCPU.Checked = True
        Else
            useNativeCPU.Checked = False
        End If
    End Sub
    Private Sub SetPAQVersion(Filename As String, Extension As String, Optional append_v As Boolean = True, Optional split_after_dot As Boolean = True)
        Dim split_paq_version As String() = Filename.Split({Extension}, StringSplitOptions.RemoveEmptyEntries)
        For Each splitted_item In split_paq_version
            Dim paq_version As String
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
        ElseIf PAQSeries.SelectedItem Is "PAQ8gen" Then
            PAQVersion.Items.AddRange({"v1", "v2", "v2fixa", "v3", "v4"})
            CompressionLevel.Items.AddRange({"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
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
        ElseIf PAQSeries.SelectedItem Is "FP8sk" Then
            PAQVersion.Items.AddRange({"v1", "v3", "v4", "v5", "v9", "v12", "v13", "v14", "v15", "v16"})
            PAQVersion.Enabled = True
        ElseIf PAQSeries.SelectedItem Is "PAQ8PXd" Then
            PAQVersion.Items.AddRange({"v45", "v46", "v47", "v48", "v49", "v50", "v51", "v52", "v53", "v54", "v55", "v56", "v57", "v58", "v59", "v60",
                                       "v61", "v62", "v63", "v64", "v66", "v67", "v68", "v69f", "v69", "v70", "v71", "v72", "v73", "v74", "v75", "v76",
                                       "v77", "v78", "v79", "v80", "v81", "v82", "v83", "v84", "v85", "v86", "v87", "v88", "v89", "v90", "v91", "v92",
                                       "v93", "v94", "v95", "v96", "v97", "v98", "v99", "v100", "v101"})
            CompressionLevel.Text = "s5"
            CompressionLevel.Items.AddRange({"s0", "s1", "s2", "s3", "s4", "s5", "s6", "s7", "s8", "s9", "s10", "s11", "s12", "s13", "s14", "s15"})
            paq_other.Text = "Threads"
            paq_other_dropbox.Enabled = True
            paq_other_dropbox.Items.AddRange({"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"})
            paq_other_dropbox.SelectedItem = My.Settings.pxdThreads
            PAQVersion.Enabled = True
        ElseIf PAQSeries.SelectedItem Is "PAQ8SK" Then
            PAQVersion.Items.AddRange({"v2", "v5", "v7", "v9", "v10", "v13", "v14", "v15", "v18", "v19", "v22", "v23", "v25", "v26", "v28", "v29",
                                      "v30", "v31", "v32", "v39", "v40", "v43"})
            CompressionLevel.Text = "s5"
            CompressionLevel.Items.AddRange({"s0", "s1", "s2", "s3", "s4", "s5", "s6", "s7", "s8", "s9", "s10", "s11", "s12", "s13", "s14", "s15",
                                             "x0", "x1", "x2", "x3", "x4", "x5", "x6", "x7", "x8", "x9", "x10", "x11", "x12", "x13", "x14", "x15"})
            paq_other.Text = "Threads"
            paq_other_dropbox.Enabled = True
            paq_other_dropbox.Items.AddRange({"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"})
            paq_other_dropbox.SelectedItem = My.Settings.pxdThreads
            PAQVersion.Enabled = True
        ElseIf PAQSeries.SelectedItem Is "PAQ8PXv" Then
            PAQVersion.Items.AddRange({"v4", "v5", "v6", "v7", "v8", "v9", "v10", "v11", "v12", "v13", "v14", "v15", "v16"})
            CompressionLevel.Text = "s5"
            CompressionLevel.Items.AddRange({"s0", "s1", "s2", "s3", "s4", "s5", "s6", "s7", "s8", "s9", "s10", "s11", "s12", "s13", "s14", "s15"})
            paq_other.Text = "Compiler"
            paq_other_dropbox.Enabled = True
            checkPAQ8PXVExecutables()
            PAQVersion.Enabled = True
        ElseIf PAQSeries.SelectedItem Is "PAQ8PX" Then
            PAQVersion.Items.AddRange({"v42", "v44", "v45", "v46", "v47", "v48", "v49", "v51", "v52", "v53", "v54", "v57", "v58", "v60", "v60_Intel_SSE2",
                                      "v61_Intel_SSE2", "v64", "v64_Intel_SSE2", "v65", "v66", "v66_Intel_SSE2", "v67", "v67_Intel_SSE2", "v68",
                                      "v68_Intel_SSE2", "v68e", "v68p3", "v69", "v69_Intel_SSE2", "v70", "v71", "v72", "v73", "v74", "v75", "v77", "v80b",
                                      "v83", "v85", "v87", "v88", "v90", "v93", "v95", "v105", "v122", "v126", "v132_fix1", "v137", "v141", "v141fix1",
                                      "v141fix2", "v141fix4", "v144", "v145", "v146", "v147", "v156", "v157", "v159", "v163", "v164", "v167", "v167cm",
                                      "v168", "v169", "v170", "v171", "v172", "v173", "v174", "v175", "v176", "v177", "v178", "v179", "v179fix1",
                                      "v179fix2", "v179fix3", "v179fix4", "v179fix5", "v180", "v181", "v181fix1", "v182", "v182fix1", "v182fix2",
                                      "v183", "v183fix1", "v184", "v185", "v186", "v186fix1", "v187", "v187fix1", "v187fix2", "v187fix3", "v187fix4", "v187fix5",
                                      "v188", "v189", "v190", "v191", "v191a", "v192", "v193", "v193fix1", "v193fix2", "v194", "v195", "v196", "v197", "v198",
                                      "v199", "v200", "v201"})
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
        If Not String.IsNullOrWhiteSpace(InputLocation.Text) Then AdjustOutputFilename(InputLocation.Text)
        My.Settings.PAQSeries = PAQSeries.SelectedItem.ToString()
        My.Settings.Save()
    End Sub
    Private Sub checkPAQ8PXVExecutables()
        paq_other_dropbox.Items.Clear()
        Dim CompressorToUse As String = IO.Path.GetDirectoryName(Process.GetCurrentProcess.MainModule.FileName) + "/Executables/" + PAQSeries.Text + "/" + PAQVersion.Text + "/" + PAQSeries.Text.ToLower() + "_" + PAQVersion.Text
        Dim PAQ8PXV_variants As String() = {"jit", "vm", "_AVX2", "_MMX", "_NONE", "_SSE2", "_SSE4", "_SSE42", "_SSSE3", "_VM", "_JIT_AVX2", "_JIT_SSE4"}
        For Each item In PAQ8PXV_variants
            If IO.File.Exists(CompressorToUse + item + ".exe") Then paq_other_dropbox.Items.Add(item)
        Next
        If paq_other_dropbox.Items.Count = 0 Then
            paq_other_dropbox.Enabled = False
            paq_other_dropbox.Text = String.Empty
        Else
            paq_other_dropbox.Enabled = True
            If paq_other_dropbox.Items.Contains(My.Settings.compiler) Then
                paq_other_dropbox.SelectedItem = My.Settings.compiler
            Else
                paq_other_dropbox.Text = String.Empty
            End If
        End If
    End Sub
    Private Sub PAQVersion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PAQVersion.SelectedIndexChanged
        CompressionLevel.Items.Clear()
        CompressionLevel.Items.AddRange({"0", "1", "2", "3", "4", "5", "6", "7", "8"})
        If PAQSeries.SelectedItem Is "FP8sk" Then
            If PAQVersion.SelectedIndex > fp8sk_enable_level_9 Then
                CompressionLevel.Items.Add("9")
            Else
                CheckCompressionLevelAndChange()
            End If
        ElseIf PAQSeries.SelectedItem Is "PAQ8gen" Then
            CompressionLevel.Items.AddRange({"9", "10", "11", "12"})
        ElseIf PAQSeries.SelectedItem Is "PAQ8PX" Then
            If PAQVersion.SelectedIndex > Flags_enable Then
                CompressionLevel.Items.Add("9")
                If PAQVersion.SelectedIndex > paq8px_enable_levels_10_12 Then
                    CompressionLevel.Items.AddRange({"10", "11", "12"})
                Else
                    CheckCompressionLevelAndChange()
                End If
            Else
                CheckCompressionLevelAndChange()
            End If
        ElseIf PAQSeries.SelectedItem Is "PAQ8PXd" Then
            CompressionLevel.Items.Clear()
            CompressionLevel.Items.AddRange({"s0", "s1", "s2", "s3", "s4", "s5", "s6", "s7", "s8", "s9", "s10", "s11", "s12", "s13", "s14", "s15"})
            If PAQVersion.SelectedIndex >= paq8pxd_add_x_levels Then
                CompressionLevel.Items.AddRange({"x0", "x1", "x2", "x3", "x4", "x5", "x6", "x7", "x8", "x9", "x10", "x11", "x12", "x13", "x14", "x15"})
            Else
                CheckCompressionLevelAndChange()
            End If
        ElseIf PAQSeries.SelectedItem Is "PAQ8PXv" Then
            CompressionLevel.Items.Clear()
            CompressionLevel.Items.AddRange({"s0", "s1", "s2", "s3", "s4", "s5", "s6", "s7", "s8", "s9", "s10", "s11", "s12", "s13", "s14", "s15"})
            checkPAQ8PXVExecutables()
        ElseIf PAQSeries.SelectedItem Is "PAQ8SK" Then
            CompressionLevel.Items.Clear()
            CompressionLevel.Items.AddRange({"s0", "s1", "s2", "s3", "s4", "s5", "s6", "s7", "s8", "s9", "s10", "s11", "s12", "s13", "s14", "s15",
                                             "x0", "x1", "x2", "x3", "x4", "x5", "x6", "x7", "x8", "x9", "x10", "x11", "x12", "x13", "x14", "x15"})
        Else
            CheckCompressionLevelAndChange()
        End If
        EnableDisableFlags()
        If Not String.IsNullOrWhiteSpace(InputLocation.Text) Then AdjustOutputFilename(InputLocation.Text)
        My.Settings.PAQVersion = PAQVersion.SelectedItem.ToString()
        My.Settings.Save()
    End Sub
    Public Function AdjustOutputFilename(Item As String, Optional OnlyReturn As Boolean = False) As String
        Dim OutputName As String = String.Empty
        If Not String.IsNullOrWhiteSpace(Item) Then
            If Not SendToDistributedProject.Checked Or OnlyReturn Then
                If CompressRButton.Checked Then
                    If PAQVersion.Enabled Then
                        Dim PAQSeriesToCheck As String() = {"PAQ8gen", "PAQ8PXd", "PAQ8PXv", "PAQ8SK", "FP8sk"}
                        If (PAQSeries.SelectedItem Is "PAQ8PX" And PAQVersion.SelectedIndex > Flags_enable) Or PAQSeriesToCheck.Contains(PAQSeries.SelectedItem.ToString()) Then
                            If useNativeCPU.Checked Then
                                OutputName = Item + ".native." + PAQSeries.SelectedItem.ToString.ToLower + PAQVersion.SelectedItem.ToString().Remove(0, 1)
                            Else
                                OutputName = Item + "." + PAQSeries.SelectedItem.ToString.ToLower + PAQVersion.SelectedItem.ToString().Remove(0, 1)
                            End If
                        Else
                            OutputName = Item + "." + PAQSeries.SelectedItem.ToString.ToLower + "_" + PAQVersion.SelectedItem.ToString()
                        End If
                    Else
                        OutputName = IO.Path.ChangeExtension(Item, "." + PAQSeries.SelectedItem.ToString.ToLower)
                    End If
                Else
                    OutputName = IO.Path.GetDirectoryName(InputLocation.Text)
                End If
                If Not OnlyReturn Then
                    OutputLocation.Text = OutputName
                End If
            Else
                OutputLocation.Text = IO.Path.GetFileName(InputLocation.Text)
            End If
        End If
        Return OutputName
    End Function

    Private Function GetDirectoriesAndFiles(ByVal OrigLocation As String, ByVal BaseFolder As IO.DirectoryInfo, Optional ByVal TextFile As IO.StreamWriter = Nothing, Optional FileList As List(Of String) = Nothing) As List(Of String)
        If TextFile Is Nothing Then
            For Each FI As IO.FileInfo In BaseFolder.GetFiles()
                FileList.Add(FI.FullName)
            Next
            For Each subF As IO.DirectoryInfo In BaseFolder.GetDirectories()
                GetDirectoriesAndFiles(OrigLocation, subF, TextFile, FileList)
            Next
        Else
            For Each FI As IO.FileInfo In BaseFolder.GetFiles()
                TextFile.WriteLine(FI.FullName.Remove(0, OrigLocation.Count + 1))
            Next
            For Each subF As IO.DirectoryInfo In BaseFolder.GetDirectories()
                GetDirectoriesAndFiles(OrigLocation, subF, TextFile)
            Next
        End If
        Return FileList
    End Function
    Private Sub CheckCompressionLevelAndChange()
        If PAQSeries.SelectedItem Is "PAQ8PX" Or PAQSeries.SelectedItem Is "FP8sk" Then
            Try
                If Convert.ToInt32(CompressionLevel.Text) >= 9 Then
                    CompressionLevel.Text = "8"
                    CompressionLevel.SelectedItem = "8"
                End If
            Catch
                CompressionLevel.Text = "8"
                CompressionLevel.SelectedItem = "8"
            End Try
        ElseIf PAQSeries.SelectedItem Is "PAQ8PXd" Or PAQSeries.SelectedItem Is "PAQ8PXv" Or PAQSeries.SelectedItem Is "PAQ8SK" Then
            If Not (CompressionLevel.Text.Contains("s") And Not CompressionLevel.Text.Contains("x")) Then
                CompressionLevel.Text = "s5"
            End If
        End If
    End Sub
    Private Sub EnableDisableFlags()
        DisableFlagsCheckboxes()
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
            If PAQVersion.SelectedIndex > paq8px_nativecpus Then
                useNativeCPU.Enabled = True
            Else
                useNativeCPU.Enabled = False
            End If
        ElseIf PAQSeries.SelectedItem Is "PAQ8PXd" Then
            If PAQVersion.SelectedIndex > paq8pxd_nativecpus Then
                useNativeCPU.Enabled = True
            Else
                useNativeCPU.Enabled = False
        End If
        ElseIf PAQSeries.SelectedItem Is "PAQ8gen" Then
            If CompressRButton.Checked Then
                EnableFlagsCheckboxes()
            Else
                DisableFlagsCheckboxes()
            End If
            useNativeCPU.Enabled = True
        Else
            DisableFlagsCheckboxes()
            useNativeCPU.Enabled = False
        End If
    End Sub
    Private Sub EnableFlagsCheckboxes()
        If PAQSeries.SelectedItem Is "PAQ8PX" Then
            b_flag.Enabled = True
            e_flag.Enabled = True
            t_flag.Enabled = True
            a_flag.Enabled = True
            s_flag.Enabled = True
            deleteFileList.Enabled = True
            DontCreateTextFile.Enabled = True
            If PAQVersion.SelectedIndex > f_flag_available And PAQVersion.SelectedIndex <= f_flag_disable Then
                f_flag.Enabled = True
            Else
                f_flag.Enabled = False
            End If
            If PAQVersion.SelectedIndex > paq8px_enable_l_flag Then
                l_flag.Enabled = True
            Else
                l_flag.Enabled = False
            End If
            If PAQVersion.SelectedIndex > paq8px_enable_r_flag Then
                r_flag.Enabled = True
            Else
                r_flag.Enabled = False
            End If
            If PAQVersion.SelectedIndex > change_r_flag_text Then
                r_flag.Text = "Load LSTM models when appropriate"
            Else
                r_flag.Text = "Perform initial retraining of the LSTM on text blocks"
            End If
        ElseIf PAQSeries.SelectedItem Is "PAQ8gen" Then
            If PAQVersion.SelectedIndex > paq8gen_enable_a_flag Then
                a_flag.Enabled = True
            End If
            l_flag.Enabled = True
        End If
    End Sub
    Private Sub DisableFlagsCheckboxes()
        b_flag.Enabled = False
        e_flag.Enabled = False
        t_flag.Enabled = False
        a_flag.Enabled = False
        s_flag.Enabled = False
        f_flag.Enabled = False
        l_flag.Enabled = False
        r_flag.Enabled = False
        r_flag.Text = "Perform initial retraining of the LSTM on text blocks"
        useNativeCPU.Enabled = False
        deleteFileList.Enabled = False
        DontCreateTextFile.Enabled = False
    End Sub

    Public Function GetPAQ8CompressionFlags() As String
        Dim CompressionFlags As String = "-" + CompressionLevel.Text
        If PAQSeries.SelectedItem Is "PAQ8PX" Then
            If b_flag.Checked Then CompressionFlags += "b"
            If e_flag.Checked Then CompressionFlags += "e"
            If t_flag.Checked Then CompressionFlags += "t"
            If a_flag.Checked Then CompressionFlags += "a"
            If s_flag.Checked Then CompressionFlags += "s"
            If PAQVersion.SelectedIndex > f_flag_available And PAQVersion.SelectedIndex <= f_flag_disable Then If f_flag.Checked Then CompressionFlags += "f"
            If PAQVersion.SelectedIndex > paq8px_enable_l_flag Then If l_flag.Checked Then CompressionFlags += "l"
            If PAQVersion.SelectedIndex > paq8px_enable_r_flag Then If r_flag.Checked Then CompressionFlags += "r"
        ElseIf PAQSeries.SelectedItem Is "PAQ8gen" Then
            If l_flag.Checked Then CompressionFlags += "l"
            If PAQVersion.SelectedIndex > paq8gen_enable_a_flag Then If a_flag.Checked Then CompressionFlags += "a"
        End If
        Return CompressionFlags
    End Function
    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        Dim CompressorToUse As String = String.Empty
        Dim CompressionParameters As String = String.Empty
        Dim textFile As String = String.Empty
        If String.IsNullOrWhiteSpace(InputLocation.Text) Then
            MessageBox.Show("The Input field cannot be empty.")
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(OutputLocation.Text) Then
            If Not My.Settings.SendToDistributedProject Then MessageBox.Show("The Output field cannot be empty.") Else MessageBox.Show("The Category field cannot be empty.")
            Exit Sub
        End If
        If My.Settings.SendToDistributedProject Then
            If Not DistributedPAQCompressors.ContainsKey(PAQSeries.Text) Then
                MessageBox.Show("The selected PAQ Series cannot be used on the Distributed project.")
                Exit Sub
            End If
            If Not DistributedPAQCompressors(PAQSeries.Text).Contains(PAQVersion.Text) Then
                MessageBox.Show("The selected PAQ compressor cannot be used on the Distributed project.")
                Exit Sub
            End If
            If String.IsNullOrWhiteSpace(My.Settings.DistributedAccountWeakKey) Then
                MessageBox.Show("The User Account Weak Key is not set.")
                Exit Sub
            End If
            Dim UserKey As String = My.Settings.DistributedAccountWeakKey
            Dim Category As String = OutputLocation.Text
            Dim DistributedProject As New DistributedProjectFunctions
            If IO.Directory.Exists(InputLocation.Text) Then
                Dim TwoGBExceeded As Boolean = False
                Dim Files As List(Of String) = GetDirectoriesAndFiles(IO.Path.GetDirectoryName(InputLocation.Text), New IO.DirectoryInfo(InputLocation.Text), Nothing, New List(Of String))
                For Each file As String In Files
                    If New IO.FileInfo(file).Length <= Integer.MaxValue Then
                        DistributedProject.Upload(UserKey, PAQSeries.Text.ToLower() + "_" + PAQVersion.Text.ToLower(), IO.Path.GetFileName(file), Category, file)
                    Else
                        TwoGBExceeded = True
                    End If
                Next
                Dim message As String = "The file(s)"
                If TwoGBExceeded Then
                    message = "Some file(s)"
                End If
                MessageBox.Show(message + " in the directory have been sent to the Distributed Data and Media Processing project for processing.")
            Else
                Dim TwoGBExceeded As Boolean = False
                Dim file As String = InputLocation.Text
                Dim message As String = "The file have been sent to the Distributed Data and Media Processing project for processing."
                If New IO.FileInfo(file).Length <= Integer.MaxValue Then
                    DistributedProject.Upload(UserKey, PAQSeries.Text.ToLower() + "_" + PAQVersion.Text.ToLower(), IO.Path.GetFileName(file), Category, file)
                Else
                    message = "The file could not be sent to the Distributed Data and Media Processing project for processing because it exceeds 2GB of size."
                End If
                MessageBox.Show(message)
            End If
        Else
            If CompressionLevel.Items.Contains(CompressionLevel.Text) Then
                If PAQSeries.SelectedItem IsNot "PAQ8PX" Then
                    If Not {"PAQ8o10t", "PAQ8gen", "PAQ8PXPRE", "PAQ8PXd", "PAQ8SK", "FP8sk", "PAQ8PXv", "PAQ8P_PC"}.Contains(PAQSeries.SelectedItem.ToString) Then
                        If PAQVersion.Items.Contains(PAQVersion.Text) Then
                            CompressorToUse = "Executables/" + PAQSeries.Text + "/" + PAQSeries.Text.ToLower + "_" + PAQVersion.Text + ".exe"
                        Else
                            MessageBox.Show("Select an item from the version dropdown")
                        End If
                    ElseIf PAQSeries.SelectedItem Is "PAQ8gen" Then
                        If useNativeCPU.Enabled And useNativeCPU.Checked Then
                            CompressorToUse = "Executables/PAQ8gen/" + PAQVersion.Text + "/paq8gen_" + PAQVersion.Text + "_nativecpu.exe"
                        Else
                            CompressorToUse = "Executables/PAQ8gen/" + PAQVersion.Text + "/paq8gen_" + PAQVersion.Text + ".exe"
                        End If
                    ElseIf PAQSeries.SelectedItem Is "PAQ8PXd" Then
                        If useNativeCPU.Enabled And useNativeCPU.Checked Then
                            CompressorToUse = "Executables/" + PAQSeries.Text + "/" + PAQVersion.Text + "/" + PAQSeries.Text.ToLower() + "_" + PAQVersion.Text + "_mt_nativecpu.exe"
                        Else
                            If PAQVersion.SelectedIndex > paq8pxd_nativecpus Then
                                CompressorToUse = "Executables/" + PAQSeries.Text + "/" + PAQVersion.Text + "/" + PAQSeries.Text.ToLower() + "_" + PAQVersion.Text + "_mt.exe"
                            Else
                                CompressorToUse = "Executables/" + PAQSeries.Text + "/" + PAQVersion.Text + "/" + PAQSeries.Text.ToLower() + "_" + PAQVersion.Text + ".exe"
                            End If
                        End If
                    ElseIf PAQSeries.SelectedItem Is "PAQ8SK" Or PAQSeries.SelectedItem Is "FP8sk" Then
                        CompressorToUse = "Executables/" + PAQSeries.Text + "/" + PAQSeries.Text.ToLower() + PAQVersion.Text.Remove(0, 1) + ".exe"
                    ElseIf PAQSeries.SelectedItem Is "PAQ8PXv" Then
                        CompressorToUse = "Executables/" + PAQSeries.Text + "/" + PAQVersion.Text + "/" + PAQSeries.Text.ToLower() + "_" + PAQVersion.Text + paq_other_dropbox.Text.ToLower() + ".exe"
                    ElseIf PAQSeries.SelectedItem Is "PAQ8P_PC" Then
                        CompressorToUse = "Executables/" + PAQSeries.Text + "/" + PAQVersion.Text + "/" + PAQSeries.Text.ToLower() + ".exe"
                    Else
                        CompressorToUse = "Executables/" + PAQSeries.Text + "/" + PAQSeries.Text.ToLower + ".exe"
                    End If
                    If CompressRButton.Checked Then
                        If {"PAQ8o10t", "PAQ8PXPRE", "PAQ8PXv", "FP8sk"}.Contains(PAQSeries.SelectedItem.ToString()) Then
                            If InputLocation.Text = IO.Path.ChangeExtension(OutputLocation.Text, Nothing) Then
                                CompressionParameters = "-" + CompressionLevel.Text + " """ + InputLocation.Text + """"
                            Else
                                CompressionParameters = "-" + CompressionLevel.Text + " """ + IO.Path.ChangeExtension(OutputLocation.Text, Nothing) + """ """ + InputLocation.Text + """"
                            End If
                        ElseIf {"PAQ8PXd", "PAQ8SK"}.Contains(PAQSeries.SelectedItem.ToString()) Then
                            If InputLocation.Text = IO.Path.ChangeExtension(OutputLocation.Text, Nothing) Then
                                CompressionParameters = "-" + CompressionLevel.Text + ":" + paq_other_dropbox.Text + " """ + InputLocation.Text + """"
                            Else
                                CompressionParameters = "-" + CompressionLevel.Text + ":" + paq_other_dropbox.Text + " """ + IO.Path.ChangeExtension(OutputLocation.Text, Nothing) + """ """ + InputLocation.Text + """"
                            End If
                        ElseIf PAQSeries.SelectedItem Is "PAQ8gen" Then
                            If IO.Directory.Exists(InputLocation.Text) Then
                                MsgBox("PAQ8gen supports compressing files only.")
                                Return
                            End If
                            CompressionParameters = GetPAQ8CompressionFlags() + " """ + InputLocation.Text + """ """ + OutputLocation.Text + """"
                        Else
                            CompressionParameters = "-" + CompressionLevel.Text + " """ + OutputLocation.Text + """ """ + InputLocation.Text + """"
                        End If
                    Else
                        CompressionParameters = "-d """ + InputLocation.Text + """ """ + OutputLocation.Text + """"
                    End If
                ElseIf PAQSeries.SelectedItem Is "PAQ8PX" Then
                    If PAQVersion.Items.Contains(PAQVersion.Text) Then
                        If PAQVersion.SelectedIndex > paq8px_use_exe_in_folder Then
                            If useNativeCPU.Enabled And useNativeCPU.Checked Then
                                CompressorToUse = "Executables/PAQ8PX/" + PAQVersion.Text + "/paq8px_" + PAQVersion.Text + "_nativecpu.exe"
                            Else
                                CompressorToUse = "Executables/PAQ8PX/" + PAQVersion.Text + "/paq8px_" + PAQVersion.Text + ".exe"
                            End If
                        Else
                            CompressorToUse = "Executables/PAQ8PX/paq8px_" + PAQVersion.Text + ".exe"
                        End If
                        If CompressRButton.Checked Then
                            If PAQVersion.SelectedIndex > Flags_enable Then
                                Dim CompressionFlags As String = GetPAQ8CompressionFlags()
                                textFile = OutputLocation.Text + ".txt"
                                If IO.Directory.Exists(InputLocation.Text) Then
                                    Dim textFileStream As New IO.StreamWriter(textFile, False)
                                    textFileStream.WriteLine()
                                    GetDirectoriesAndFiles(IO.Path.GetDirectoryName(InputLocation.Text), New IO.DirectoryInfo(InputLocation.Text), textFileStream)
                                    textFileStream.Close()
                                    CompressionParameters = CompressionFlags + " ""@" + textFile + """ """ + OutputLocation.Text + """"
                                Else
                                    If DontCreateTextFile.Checked Then
                                        CompressionParameters = CompressionFlags + " """ + InputLocation.Text + """ """ + OutputLocation.Text + """"
                                    Else
                                        IO.File.WriteAllText(textFile, Environment.NewLine + IO.Path.GetFileName(InputLocation.Text))
                                        CompressionParameters = CompressionFlags + " ""@" + textFile + """ """ + OutputLocation.Text + """"
                                    End If
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
                Dim CompressorPath As String = IO.Path.GetDirectoryName(CompressorToUse)
                If IO.File.Exists(CompressorToUse) Then
                    If Not GenerateBatchScriptOnly.Checked Then
                        StartButton.Enabled = False
                        SaveLogButton.Enabled = False
                        If ShowCMD.Checked Then
                            CompressionParameters = "/C @""" + CompressorToUse + """ " + CompressionParameters + " & pause"
                            CompressorToUse = "cmd.exe"
                        End If
                        Dim StartCompressionThread = New Threading.Thread(Sub() CompressionThread(CompressorToUse, CompressionParameters, CompressorPath, textFile, PAQSeries.SelectedItem.ToString()))
                        StartCompressionThread.Start()
                    Else
                        Dim OutputPath As String
                        If IO.Directory.Exists(OutputLocation.Text) Then
                            OutputPath = OutputLocation.Text + "\" + IO.Path.GetFileName(OutputLocation.Text) + ".bat"
                        Else
                            OutputPath = IO.Path.ChangeExtension(OutputLocation.Text, ".bat")
                        End If
                        IO.File.WriteAllText(OutputPath, """" + CompressorToUse + """ " + CompressionParameters + " & pause")
                        MsgBox("Batch file written to the output location.")
                    End If
                Else
                    MsgBox("The selected compressor version could not be found. Cannot proceed.")
                End If
            Else
                MessageBox.Show("No compressor has been selected. Cannot proceed.")
            End If
        End If
    End Sub
    Private Sub CompressionThread(Compressor As String, Params As String, CompressorPath As String, textFile As String, PAQSeries As String)
        Using process As New Process()
            process.StartInfo.WorkingDirectory = CompressorPath
            process.StartInfo.FileName = Compressor
            process.StartInfo.Arguments = Params
            process.StartInfo.UseShellExecute = ShowCMD.Checked
            process.StartInfo.RedirectStandardOutput = Not ShowCMD.Checked
            process.StartInfo.RedirectStandardError = Not ShowCMD.Checked
            process.StartInfo.CreateNoWindow = Not ShowCMD.Checked
            process.Start()
            If Not ShowCMD.Checked Then
                AddHandler process.OutputDataReceived, New DataReceivedEventHandler(AddressOf UpdateLogEventHandler)
                AddHandler process.ErrorDataReceived, New DataReceivedEventHandler(AddressOf UpdateLogEventHandler)
                process.BeginOutputReadLine()
                process.BeginErrorReadLine()
            End If
            process.WaitForExit()
            If deleteFileList.Checked And PAQSeries = "PAQ8PX" Then
                If IO.File.Exists(textFile) Then
                    IO.File.Delete(textFile)
                End If
            End If
            StartButton.BeginInvoke(Sub() StartButton.Enabled = True)
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
        If SendToDistributedProject.Checked Then
            Step2Label.Text = "Step 2: Enter a Category name:"
        Else
            Step2Label.Text = "Step 2: Browse for a location to store the compressed file:"
        End If
        My.Settings.CompressChecked = CompressRButton.Checked
        My.Settings.Save()
    End Sub

    Private Sub ExtractRButton_CheckedChanged(sender As Object, e As EventArgs) Handles ExtractRButton.CheckedChanged
        EnableDisableFlags()
        Step1Label.Text = "Step 1: Browse for a file/archive to extract:"
        If SendToDistributedProject.Checked Then
            Step2Label.Text = "Step 2: Enter a Category name:"
            BrowseFolder.Enabled = True
        Else
            Step2Label.Text = "Step 2: Browse for a location to extract the file/archive:"
            BrowseFolder.Enabled = False
        End If
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
        If CompressRButton.Checked Then
            OpenFileDialog1.Title = "Browse for a file to compress"
        Else
            OpenFileDialog1.Title = "Browse for a file to extract"
        End If
        If Not String.IsNullOrWhiteSpace(InputLocation.Text) Then OpenFileDialog1.FileName = IO.Path.GetFileName(InputLocation.Text)
        Dim result As DialogResult = OpenFileDialog1.ShowDialog
        If result = DialogResult.OK Then
            InputLocation.Text = OpenFileDialog1.FileName
            CheckAndAdjust()
        End If
    End Sub
    Private Sub CheckAndAdjust()
        If IO.Path.GetExtension(InputLocation.Text).Contains(".paq8") Or IO.Path.GetExtension(InputLocation.Text).Contains(".fp8") Then ExtractRButton.Checked = True Else CompressRButton.Checked = True
        If ExtractRButton.Checked Then
            AdjustPAQVersion(IO.Path.GetFileName(InputLocation.Text))
        Else
            If Not SendToDistributedProject.Checked Then OutputLocation.Text = InputLocation.Text
        End If
        AdjustOutputFilename(InputLocation.Text)
    End Sub
    Private Sub BrowseFolder_Click(sender As Object, e As EventArgs) Handles BrowseFolder.Click
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog
        If result = DialogResult.OK Then
            InputLocation.Text = FolderBrowserDialog1.SelectedPath
            If Not SendToDistributedProject.Checked Then OutputLocation.Text = InputLocation.Text
            AdjustOutputFilename(InputLocation.Text)
        End If
    End Sub

    Private Sub BrowseOutput_Click(sender As Object, e As EventArgs) Handles BrowseOutput.Click
        If CompressRButton.Checked Then
            SaveFileDialog1.Filter = "PAQ file|*.paq"
            SaveFileDialog1.Title = "Browse for a location to save the compressed PAQ file"
            If Not String.IsNullOrWhiteSpace(OutputLocation.Text) Then SaveFileDialog1.FileName = IO.Path.GetFileName(OutputLocation.Text)
            Dim result As DialogResult = SaveFileDialog1.ShowDialog
            If result = DialogResult.OK Then
                OutputLocation.Text = SaveFileDialog1.FileName
                AdjustOutputFilename(InputLocation.Text)
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
            If Not String.IsNullOrWhiteSpace(SaveDialog.FileName) Then IO.File.WriteAllText(SaveDialog.FileName, Log.Text)
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

    Private Sub ShowCMD_CheckedChanged(sender As Object, e As EventArgs) Handles ShowCMD.CheckedChanged
        My.Settings.ShowCMD = ShowCMD.Checked
        My.Settings.Save()
    End Sub

    Private Sub GenerateBatchScriptOnly_CheckedChanged(sender As Object, e As EventArgs) Handles GenerateBatchScriptOnly.CheckedChanged
        My.Settings.OnlyGenerateBatchFile = GenerateBatchScriptOnly.Checked
        My.Settings.Save()
    End Sub

    Private Sub SendToDistributedProject_CheckedChanged(sender As Object, e As EventArgs) Handles SendToDistributedProject.CheckedChanged
        My.Settings.SendToDistributedProject = SendToDistributedProject.Checked
        My.Settings.Save()
        If SendToDistributedProject.Checked Then
            Step2Label.Text = "Step 2: Enter a Category name:"
            BrowseOutput.Enabled = False
            BrowseFolder.Enabled = True
        Else
            If CompressRButton.Checked Then
                Step2Label.Text = "Step 2: Browse for a location to store the compressed file:"
            Else
                Step2Label.Text = "Step 2: Browse for a location to extract the file/archive:"
                BrowseOutput.Enabled = True
                BrowseFolder.Enabled = False
            End If
        End If
        AdjustOutputFilename(InputLocation.Text)
    End Sub

    Private Sub DistributedProcessingOptions_Click(sender As Object, e As EventArgs) Handles DistributedProcessingOptions.Click
        DistributedSettings.ShowDialog()
    End Sub

    Private Sub InputLocation_TextChanged(sender As Object, e As EventArgs) Handles InputLocation.TextChanged
        If IO.File.Exists(InputLocation.Text) Or IO.Directory.Exists(InputLocation.Text) Then
            AdjustOutputFilename(InputLocation.Text)
        End If
    End Sub

    Private Sub DontCreateTextFile_CheckedChanged(sender As Object, e As EventArgs) Handles DontCreateTextFile.CheckedChanged
        My.Settings.DontCreateTextFile = DontCreateTextFile.Checked
        My.Settings.Save()
    End Sub

    Private Sub l_flag_CheckedChanged(sender As Object, e As EventArgs) Handles l_flag.CheckedChanged
        My.Settings.l_flag = l_flag.Checked
        My.Settings.Save()
    End Sub

    Private Sub r_flag_CheckedChanged(sender As Object, e As EventArgs) Handles r_flag.CheckedChanged
        My.Settings.r_flag = r_flag.Checked
        My.Settings.Save()
    End Sub

    Private Sub useNativeCPU_CheckedChanged(sender As Object, e As EventArgs) Handles useNativeCPU.CheckedChanged
        My.Settings.useNativeCPU = useNativeCPU.Checked
        My.Settings.Save()
        AdjustOutputFilename(InputLocation.Text)
    End Sub

    Private Sub deleteFileList_CheckedChanged(sender As Object, e As EventArgs) Handles deleteFileList.CheckedChanged
        My.Settings.deleteFileList = deleteFileList.Checked
        My.Settings.Save()
    End Sub
End Class
