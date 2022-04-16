<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileListOptions
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SortByExtension = New System.Windows.Forms.RadioButton()
        Me.SortByName = New System.Windows.Forms.RadioButton()
        Me.SortByPath = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ExtensionsTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.AddExtensionsMode = New System.Windows.Forms.RadioButton()
        Me.SkipExtensionsMode = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SortByExtension)
        Me.GroupBox1.Controls.Add(Me.SortByName)
        Me.GroupBox1.Controls.Add(Me.SortByPath)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(257, 55)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "When compressing a folder, sort the File List by:"
        '
        'SortByExtension
        '
        Me.SortByExtension.AutoSize = True
        Me.SortByExtension.Location = New System.Drawing.Point(156, 19)
        Me.SortByExtension.Name = "SortByExtension"
        Me.SortByExtension.Size = New System.Drawing.Size(71, 17)
        Me.SortByExtension.TabIndex = 2
        Me.SortByExtension.TabStop = True
        Me.SortByExtension.Text = "Extension"
        Me.SortByExtension.UseVisualStyleBackColor = True
        '
        'SortByName
        '
        Me.SortByName.AutoSize = True
        Me.SortByName.Location = New System.Drawing.Point(78, 19)
        Me.SortByName.Name = "SortByName"
        Me.SortByName.Size = New System.Drawing.Size(72, 17)
        Me.SortByName.TabIndex = 1
        Me.SortByName.TabStop = True
        Me.SortByName.Text = "File Name"
        Me.SortByName.UseVisualStyleBackColor = True
        '
        'SortByPath
        '
        Me.SortByPath.AutoSize = True
        Me.SortByPath.Location = New System.Drawing.Point(6, 19)
        Me.SortByPath.Name = "SortByPath"
        Me.SortByPath.Size = New System.Drawing.Size(66, 17)
        Me.SortByPath.TabIndex = 0
        Me.SortByPath.TabStop = True
        Me.SortByPath.Text = "File Path"
        Me.SortByPath.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 176)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(257, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.ExtensionsTextBox)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.AddExtensionsMode)
        Me.GroupBox2.Controls.Add(Me.SkipExtensionsMode)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 73)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(257, 97)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "File Extension options"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 26)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Example: .txt .csv .exe" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Extensions separated by whitespace"
        '
        'ExtensionsTextBox
        '
        Me.ExtensionsTextBox.Location = New System.Drawing.Point(6, 42)
        Me.ExtensionsTextBox.Name = "ExtensionsTextBox"
        Me.ExtensionsTextBox.Size = New System.Drawing.Size(245, 20)
        Me.ExtensionsTextBox.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(99, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "the following extensions:"
        '
        'AddExtensionsMode
        '
        Me.AddExtensionsMode.AutoSize = True
        Me.AddExtensionsMode.Location = New System.Drawing.Point(58, 19)
        Me.AddExtensionsMode.Name = "AddExtensionsMode"
        Me.AddExtensionsMode.Size = New System.Drawing.Size(44, 17)
        Me.AddExtensionsMode.TabIndex = 4
        Me.AddExtensionsMode.TabStop = True
        Me.AddExtensionsMode.Text = "Add"
        Me.AddExtensionsMode.UseVisualStyleBackColor = True
        '
        'SkipExtensionsMode
        '
        Me.SkipExtensionsMode.AutoSize = True
        Me.SkipExtensionsMode.Location = New System.Drawing.Point(6, 19)
        Me.SkipExtensionsMode.Name = "SkipExtensionsMode"
        Me.SkipExtensionsMode.Size = New System.Drawing.Size(46, 17)
        Me.SkipExtensionsMode.TabIndex = 3
        Me.SkipExtensionsMode.TabStop = True
        Me.SkipExtensionsMode.Text = "Skip"
        Me.SkipExtensionsMode.UseVisualStyleBackColor = True
        '
        'FileListOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(290, 211)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FileListOptions"
        Me.Text = "Folder File List Options"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents SortByExtension As RadioButton
    Friend WithEvents SortByName As RadioButton
    Friend WithEvents SortByPath As RadioButton
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ExtensionsTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents AddExtensionsMode As RadioButton
    Friend WithEvents SkipExtensionsMode As RadioButton
End Class
