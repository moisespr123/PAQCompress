<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.InputLocation = New System.Windows.Forms.TextBox()
        Me.BrowseFile = New System.Windows.Forms.Button()
        Me.BrowseFolder = New System.Windows.Forms.Button()
        Me.BrowseOutput = New System.Windows.Forms.Button()
        Me.OutputLocation = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CompressRButton = New System.Windows.Forms.RadioButton()
        Me.ExtractRButton = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.PAQSeries = New System.Windows.Forms.ComboBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.PAQVersion = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CompressionLevel = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.f_flag = New System.Windows.Forms.CheckBox()
        Me.s_flag = New System.Windows.Forms.CheckBox()
        Me.a_flag = New System.Windows.Forms.CheckBox()
        Me.t_flag = New System.Windows.Forms.CheckBox()
        Me.e_flag = New System.Windows.Forms.CheckBox()
        Me.b_flag = New System.Windows.Forms.CheckBox()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Log = New System.Windows.Forms.RichTextBox()
        Me.SaveLogButton = New System.Windows.Forms.Button()
        Me.ClearLogButton = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.FolderBrowserDialog2 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(223, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Step 1: Browse for a file or folder to compress:"
        '
        'InputLocation
        '
        Me.InputLocation.Location = New System.Drawing.Point(12, 78)
        Me.InputLocation.Name = "InputLocation"
        Me.InputLocation.Size = New System.Drawing.Size(286, 20)
        Me.InputLocation.TabIndex = 4
        '
        'BrowseFile
        '
        Me.BrowseFile.Location = New System.Drawing.Point(304, 76)
        Me.BrowseFile.Name = "BrowseFile"
        Me.BrowseFile.Size = New System.Drawing.Size(104, 23)
        Me.BrowseFile.TabIndex = 2
        Me.BrowseFile.Text = "Browse file"
        Me.BrowseFile.UseVisualStyleBackColor = True
        '
        'BrowseFolder
        '
        Me.BrowseFolder.Location = New System.Drawing.Point(414, 76)
        Me.BrowseFolder.Name = "BrowseFolder"
        Me.BrowseFolder.Size = New System.Drawing.Size(104, 23)
        Me.BrowseFolder.TabIndex = 5
        Me.BrowseFolder.Text = "Browse folder"
        Me.BrowseFolder.UseVisualStyleBackColor = True
        '
        'BrowseOutput
        '
        Me.BrowseOutput.Location = New System.Drawing.Point(304, 126)
        Me.BrowseOutput.Name = "BrowseOutput"
        Me.BrowseOutput.Size = New System.Drawing.Size(104, 23)
        Me.BrowseOutput.TabIndex = 6
        Me.BrowseOutput.Text = "Browse"
        Me.BrowseOutput.UseVisualStyleBackColor = True
        '
        'OutputLocation
        '
        Me.OutputLocation.Location = New System.Drawing.Point(12, 128)
        Me.OutputLocation.Name = "OutputLocation"
        Me.OutputLocation.Size = New System.Drawing.Size(286, 20)
        Me.OutputLocation.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(278, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Step 2: Browse for a location to store the compressed file:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CompressRButton)
        Me.GroupBox3.Controls.Add(Me.ExtractRButton)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(160, 47)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Action"
        '
        'CompressRButton
        '
        Me.CompressRButton.AutoSize = True
        Me.CompressRButton.Location = New System.Drawing.Point(6, 19)
        Me.CompressRButton.Name = "CompressRButton"
        Me.CompressRButton.Size = New System.Drawing.Size(71, 17)
        Me.CompressRButton.TabIndex = 10
        Me.CompressRButton.TabStop = True
        Me.CompressRButton.Text = "Compress"
        Me.CompressRButton.UseVisualStyleBackColor = True
        '
        'ExtractRButton
        '
        Me.ExtractRButton.AutoSize = True
        Me.ExtractRButton.Location = New System.Drawing.Point(83, 19)
        Me.ExtractRButton.Name = "ExtractRButton"
        Me.ExtractRButton.Size = New System.Drawing.Size(58, 17)
        Me.ExtractRButton.TabIndex = 11
        Me.ExtractRButton.TabStop = True
        Me.ExtractRButton.Text = "Extract"
        Me.ExtractRButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 162)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(243, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Step 3: PAQ version and Compression Parameters"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.PAQSeries)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 178)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(141, 47)
        Me.GroupBox4.TabIndex = 12
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Series:"
        '
        'PAQSeries
        '
        Me.PAQSeries.FormattingEnabled = True
        Me.PAQSeries.Items.AddRange(New Object() {"FP8", "PAQ8KX", "PAQ8o10t", "PAQ8PF", "PAQ8PX", "PAQ8PXPRE"})
        Me.PAQSeries.Location = New System.Drawing.Point(6, 19)
        Me.PAQSeries.Name = "PAQSeries"
        Me.PAQSeries.Size = New System.Drawing.Size(116, 21)
        Me.PAQSeries.Sorted = True
        Me.PAQSeries.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.PAQVersion)
        Me.GroupBox5.Location = New System.Drawing.Point(157, 178)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(141, 47)
        Me.GroupBox5.TabIndex = 13
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Version:"
        '
        'PAQVersion
        '
        Me.PAQVersion.FormattingEnabled = True
        Me.PAQVersion.Location = New System.Drawing.Point(6, 19)
        Me.PAQVersion.Name = "PAQVersion"
        Me.PAQVersion.Size = New System.Drawing.Size(116, 21)
        Me.PAQVersion.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CompressionLevel)
        Me.GroupBox1.Location = New System.Drawing.Point(304, 178)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(141, 47)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Compression Level:"
        '
        'CompressionLevel
        '
        Me.CompressionLevel.FormattingEnabled = True
        Me.CompressionLevel.Location = New System.Drawing.Point(6, 19)
        Me.CompressionLevel.Name = "CompressionLevel"
        Me.CompressionLevel.Size = New System.Drawing.Size(116, 21)
        Me.CompressionLevel.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.f_flag)
        Me.GroupBox2.Controls.Add(Me.s_flag)
        Me.GroupBox2.Controls.Add(Me.a_flag)
        Me.GroupBox2.Controls.Add(Me.t_flag)
        Me.GroupBox2.Controls.Add(Me.e_flag)
        Me.GroupBox2.Controls.Add(Me.b_flag)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 231)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(562, 92)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "PAQ8PX Additional Options:"
        '
        'f_flag
        '
        Me.f_flag.AutoSize = True
        Me.f_flag.Location = New System.Drawing.Point(268, 65)
        Me.f_flag.Name = "f_flag"
        Me.f_flag.Size = New System.Drawing.Size(239, 17)
        Me.f_flag.TabIndex = 5
        Me.f_flag.Text = "Bypass modeling and mixing on long matches"
        Me.f_flag.UseVisualStyleBackColor = True
        '
        's_flag
        '
        Me.s_flag.AutoSize = True
        Me.s_flag.Location = New System.Drawing.Point(268, 42)
        Me.s_flag.Name = "s_flag"
        Me.s_flag.Size = New System.Drawing.Size(285, 17)
        Me.s_flag.TabIndex = 4
        Me.s_flag.Text = "Skip the color transform, just reorder the RGB channels"
        Me.s_flag.UseVisualStyleBackColor = True
        '
        'a_flag
        '
        Me.a_flag.AutoSize = True
        Me.a_flag.Location = New System.Drawing.Point(268, 19)
        Me.a_flag.Name = "a_flag"
        Me.a_flag.Size = New System.Drawing.Size(129, 17)
        Me.a_flag.TabIndex = 3
        Me.a_flag.Text = "Adaptive learning rate"
        Me.a_flag.UseVisualStyleBackColor = True
        '
        't_flag
        '
        Me.t_flag.AutoSize = True
        Me.t_flag.Location = New System.Drawing.Point(6, 65)
        Me.t_flag.Name = "t_flag"
        Me.t_flag.Size = New System.Drawing.Size(261, 17)
        Me.t_flag.TabIndex = 2
        Me.t_flag.Text = "Pre-train main model  with word and expression list"
        Me.t_flag.UseVisualStyleBackColor = True
        '
        'e_flag
        '
        Me.e_flag.AutoSize = True
        Me.e_flag.Location = New System.Drawing.Point(6, 42)
        Me.e_flag.Name = "e_flag"
        Me.e_flag.Size = New System.Drawing.Size(138, 17)
        Me.e_flag.TabIndex = 1
        Me.e_flag.Text = "Pre-train x86/x64 model"
        Me.e_flag.UseVisualStyleBackColor = True
        '
        'b_flag
        '
        Me.b_flag.AutoSize = True
        Me.b_flag.Location = New System.Drawing.Point(6, 19)
        Me.b_flag.Name = "b_flag"
        Me.b_flag.Size = New System.Drawing.Size(227, 17)
        Me.b_flag.TabIndex = 0
        Me.b_flag.Text = "Brute-force detection of DEFLATE streams"
        Me.b_flag.UseVisualStyleBackColor = True
        '
        'StartButton
        '
        Me.StartButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.StartButton.Location = New System.Drawing.Point(12, 329)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(562, 53)
        Me.StartButton.TabIndex = 16
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(577, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Log:"
        '
        'Log
        '
        Me.Log.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Log.Location = New System.Drawing.Point(580, 25)
        Me.Log.Name = "Log"
        Me.Log.ReadOnly = True
        Me.Log.Size = New System.Drawing.Size(460, 298)
        Me.Log.TabIndex = 18
        Me.Log.Text = ""
        '
        'SaveLogButton
        '
        Me.SaveLogButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SaveLogButton.Location = New System.Drawing.Point(832, 329)
        Me.SaveLogButton.Name = "SaveLogButton"
        Me.SaveLogButton.Size = New System.Drawing.Size(208, 53)
        Me.SaveLogButton.TabIndex = 19
        Me.SaveLogButton.Text = "Save Log"
        Me.SaveLogButton.UseVisualStyleBackColor = True
        '
        'ClearLogButton
        '
        Me.ClearLogButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ClearLogButton.Location = New System.Drawing.Point(580, 329)
        Me.ClearLogButton.Name = "ClearLogButton"
        Me.ClearLogButton.Size = New System.Drawing.Size(241, 53)
        Me.ClearLogButton.TabIndex = 20
        Me.ClearLogButton.Text = "Clear Log"
        Me.ClearLogButton.UseVisualStyleBackColor = True
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.ShowNewFolderButton = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 392)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "v0.1 - GUI by: Moisés Cardona"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1052, 414)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ClearLogButton)
        Me.Controls.Add(Me.SaveLogButton)
        Me.Controls.Add(Me.Log)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.BrowseOutput)
        Me.Controls.Add(Me.OutputLocation)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.BrowseFolder)
        Me.Controls.Add(Me.BrowseFile)
        Me.Controls.Add(Me.InputLocation)
        Me.Controls.Add(Me.Label4)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "PAQCompress"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents Label4 As Label
    Friend WithEvents InputLocation As TextBox
    Friend WithEvents BrowseFile As Button
    Friend WithEvents BrowseFolder As Button
    Friend WithEvents BrowseOutput As Button
    Friend WithEvents OutputLocation As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents CompressRButton As RadioButton
    Friend WithEvents ExtractRButton As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents PAQSeries As ComboBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents PAQVersion As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CompressionLevel As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents StartButton As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Log As RichTextBox
    Friend WithEvents b_flag As CheckBox
    Friend WithEvents f_flag As CheckBox
    Friend WithEvents s_flag As CheckBox
    Friend WithEvents a_flag As CheckBox
    Friend WithEvents t_flag As CheckBox
    Friend WithEvents e_flag As CheckBox
    Friend WithEvents SaveLogButton As Button
    Friend WithEvents ClearLogButton As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents FolderBrowserDialog2 As FolderBrowserDialog
    Friend WithEvents Label3 As Label
End Class
