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
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.OutputLocation = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.PAQSeries = New System.Windows.Forms.ComboBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.PAQVersion = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CompressionLevel = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Log = New System.Windows.Forms.RichTextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
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
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(304, 76)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(104, 23)
        Me.Button4.TabIndex = 2
        Me.Button4.Text = "Browse file"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(414, 76)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(104, 23)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "Browse folder"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(304, 126)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(104, 23)
        Me.Button7.TabIndex = 6
        Me.Button7.Text = "Browse file"
        Me.Button7.UseVisualStyleBackColor = True
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
        Me.GroupBox3.Controls.Add(Me.RadioButton1)
        Me.GroupBox3.Controls.Add(Me.RadioButton2)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(160, 47)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Action"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(6, 19)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(71, 17)
        Me.RadioButton1.TabIndex = 10
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Compress"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(83, 19)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(58, 17)
        Me.RadioButton2.TabIndex = 11
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Extract"
        Me.RadioButton2.UseVisualStyleBackColor = True
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
        Me.GroupBox2.Controls.Add(Me.CheckBox6)
        Me.GroupBox2.Controls.Add(Me.CheckBox5)
        Me.GroupBox2.Controls.Add(Me.CheckBox4)
        Me.GroupBox2.Controls.Add(Me.CheckBox3)
        Me.GroupBox2.Controls.Add(Me.CheckBox2)
        Me.GroupBox2.Controls.Add(Me.CheckBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 231)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(562, 94)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "PAQ8PX Additional Options:"
        '
        'StartButton
        '
        Me.StartButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.StartButton.Location = New System.Drawing.Point(12, 331)
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
        Me.Log.Size = New System.Drawing.Size(460, 300)
        Me.Log.TabIndex = 18
        Me.Log.Text = ""
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(6, 19)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(227, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "Brute-force detection of DEFLATE streams"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(6, 42)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(138, 17)
        Me.CheckBox2.TabIndex = 1
        Me.CheckBox2.Text = "Pre-train x86/x64 model"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(6, 65)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(261, 17)
        Me.CheckBox3.TabIndex = 2
        Me.CheckBox3.Text = "Pre-train main model  with word and expression list"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(268, 19)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(128, 17)
        Me.CheckBox4.TabIndex = 3
        Me.CheckBox4.Text = "adaptive learning rate"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(268, 42)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(285, 17)
        Me.CheckBox5.TabIndex = 4
        Me.CheckBox5.Text = "Skip the color transform, just reorder the RGB channels"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Location = New System.Drawing.Point(268, 65)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(239, 17)
        Me.CheckBox6.TabIndex = 5
        Me.CheckBox6.Text = "Bypass modeling and mixing on long matches"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(832, 331)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(208, 53)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "Save Log"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button2.Location = New System.Drawing.Point(580, 331)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(241, 53)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "Clear Log"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1052, 394)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Log)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.OutputLocation)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
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
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents OutputLocation As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
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
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox6 As CheckBox
    Friend WithEvents CheckBox5 As CheckBox
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
