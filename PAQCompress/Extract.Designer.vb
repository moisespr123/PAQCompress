<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Extract
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select a PAQ Family"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(16, 115)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(204, 20)
        Me.TextBox1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 187)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(285, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Extract"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(225, 115)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Open File"
        Me.Button2.UseVisualStyleBackColor = true
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = true
        Me.RadioButton1.Location = New System.Drawing.Point(15, 25)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(67, 17)
        Me.RadioButton1.TabIndex = 4
        Me.RadioButton1.TabStop = true
        Me.RadioButton1.Text = "PAQ8PX"
        Me.RadioButton1.UseVisualStyleBackColor = true
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = true
        Me.RadioButton2.Location = New System.Drawing.Point(109, 25)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(67, 17)
        Me.RadioButton2.TabIndex = 5
        Me.RadioButton2.TabStop = true
        Me.RadioButton2.Text = "PAQ8KX"
        Me.RadioButton2.UseVisualStyleBackColor = true
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = true
        Me.RadioButton3.Location = New System.Drawing.Point(16, 48)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(66, 17)
        Me.RadioButton3.TabIndex = 6
        Me.RadioButton3.TabStop = true
        Me.RadioButton3.Text = "PAQ8PF"
        Me.RadioButton3.UseVisualStyleBackColor = true
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = true
        Me.RadioButton4.Location = New System.Drawing.Point(109, 48)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(89, 17)
        Me.RadioButton4.TabIndex = 7
        Me.RadioButton4.TabStop = true
        Me.RadioButton4.Text = "PAQ8PXPRE"
        Me.RadioButton4.UseVisualStyleBackColor = true
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = true
        Me.RadioButton5.Location = New System.Drawing.Point(16, 71)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(70, 17)
        Me.RadioButton5.TabIndex = 8
        Me.RadioButton5.TabStop = true
        Me.RadioButton5.Text = "paq8o10t"
        Me.RadioButton5.UseVisualStyleBackColor = true
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(13, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Browse for a PAQ Archive:"
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(15, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(201, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Browse for a Folder to extract the archive"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(224, 158)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "Browse"
        Me.Button3.UseVisualStyleBackColor = true
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(15, 158)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(204, 20)
        Me.TextBox2.TabIndex = 11
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = true
        Me.RadioButton6.Location = New System.Drawing.Point(109, 71)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(44, 17)
        Me.RadioButton6.TabIndex = 13
        Me.RadioButton6.TabStop = true
        Me.RadioButton6.Text = "FP8"
        Me.RadioButton6.UseVisualStyleBackColor = true
        '
        'Extract
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(313, 220)
        Me.Controls.Add(Me.RadioButton6)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.RadioButton5)
        Me.Controls.Add(Me.RadioButton4)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Extract"
        Me.Text = "Extract"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
End Class
