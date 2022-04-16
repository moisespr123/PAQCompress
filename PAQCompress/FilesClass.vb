Public Class FilesClass
    Public Property FullPath As String
    Public Property FileName As String
    Public Property Extension As String

    Public Sub New()

    End Sub

    Public Sub New(Full_Path As String, File_Name As String, Ext As String)
        FullPath = Full_Path
        FileName = File_Name
        Extension = Ext
    End Sub

End Class
