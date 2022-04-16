Public Class FileListOptions
    Private Sub FileListOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.FileListSortMethod = 1 Then
            SortByPath.Checked = True
        ElseIf My.Settings.FileListSortMethod = 2 Then
            SortByName.Checked = True
        Else
            SortByExtension.Checked = True
        End If
        If My.Settings.ExtensionFilteringMode = 1 Then
            SkipExtensionsMode.Checked = True
        Else
            AddExtensionsMode.Checked = True
        End If
        ExtensionsTextBox.Text = My.Settings.ExtensionFilterList
    End Sub

    Private Sub SortByPath_CheckedChanged(sender As Object, e As EventArgs) Handles SortByPath.CheckedChanged
        My.Settings.FileListSortMethod = 1
        My.Settings.Save()
    End Sub

    Private Sub SortByName_CheckedChanged(sender As Object, e As EventArgs) Handles SortByName.CheckedChanged
        My.Settings.FileListSortMethod = 2
        My.Settings.Save()
    End Sub

    Private Sub SortByExtension_CheckedChanged(sender As Object, e As EventArgs) Handles SortByExtension.CheckedChanged
        My.Settings.FileListSortMethod = 3
        My.Settings.Save()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub SkipExtensionsMode_CheckedChanged(sender As Object, e As EventArgs) Handles SkipExtensionsMode.CheckedChanged
        My.Settings.ExtensionFilteringMode = 1
        My.Settings.Save()
    End Sub

    Private Sub AddExtensionsMode_CheckedChanged(sender As Object, e As EventArgs) Handles AddExtensionsMode.CheckedChanged
        My.Settings.ExtensionFilteringMode = 2
        My.Settings.Save()
    End Sub

    Private Sub ExtensionsTextBox_TextChanged(sender As Object, e As EventArgs) Handles ExtensionsTextBox.TextChanged
        My.Settings.ExtensionFilterList = ExtensionsTextBox.Text
        My.Settings.Save()
    End Sub
End Class