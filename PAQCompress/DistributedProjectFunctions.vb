Imports System.IO
Imports System.Net.Http

Public Class DistributedProjectFunctions
    Private Function GenerateCommandLineArguments() As String
        Dim Flags As String
        If Form1.CompressRButton.Checked Then
            Flags = "-" + Form1.CompressionLevel.Text
            If Form1.PAQSeries.SelectedItem Is "PAQ8PX" Then
                If Form1.PAQVersion.SelectedIndex > Form1.Flags_enable Then
                    If Form1.b_flag.Checked Then Flags += "b"
                    If Form1.e_flag.Checked Then Flags += "e"
                    If Form1.t_flag.Checked Then Flags += "t"
                    If Form1.a_flag.Checked Then Flags += "a"
                    If Form1.s_flag.Checked Then Flags += "s"
                    If Form1.PAQVersion.SelectedIndex > Form1.f_flag_available Then If Form1.f_flag.Checked Then Flags += "f"
                End If
            End If
        Else
            Flags = "-d"
        End If
        Return Flags
    End Function
    Private Function GetOutputFilename(filename As String) As String
        If Form1.CompressRButton.Checked Then
            Return Form1.AdjustOutputFilename(filename, True)
        Else
            Return IO.Path.GetFileNameWithoutExtension(filename)
        End If
    End Function
    Public Function Upload(ByVal key As String, ByVal format As String, ByVal filename As String, ByVal category As String, ByVal file As String) As String
        Using client = New HttpClient()
            Using formData = New MultipartFormDataContent()
                If True Then
                    formData.Add(New StringContent(key), "k")
                    formData.Add(New StreamContent(New FileStream(file, FileMode.Open)), "filedata", Path.GetFileName(file))
                    formData.Add(New StringContent(category), "a")
                    formData.Add(New StringContent(format), "f")
                    formData.Add(New StringContent(GenerateCommandLineArguments()), "c")
                    formData.Add(New StringContent(GetOutputFilename(filename)), "n")
                    Dim uri As Uri = New Uri("http://boinc.moisescardona.me/media_put.php")
                    client.DefaultRequestHeaders.Add("Accept-Language", "en-GB,en-US;q=0.8,en;q=0.6,ru;q=0.4")
                    Dim response As HttpResponseMessage = client.PostAsync(uri, formData).Result

                    If Not response.IsSuccessStatusCode Then
                        Console.WriteLine("Error")
                        Console.WriteLine(response.StatusCode)
                    End If
                    Dim reader As StreamReader = New StreamReader(response.Content.ReadAsStreamAsync().Result)
                    Dim result As String = reader.ReadToEnd()
                    Return result
                End If
                Return String.Empty
            End Using
        End Using
    End Function
End Class
