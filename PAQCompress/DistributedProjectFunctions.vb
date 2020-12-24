Imports System.IO
Imports System.Net.Http

Public Class DistributedProjectFunctions
    Private Function GenerateCommandLineArguments() As String
        Dim Flags As String = String.Empty
        If Form1.CompressRButton.Checked Then
            If Form1.PAQSeries.SelectedItem Is "PAQ8PX" Then
                Flags = Form1.GetPAQ8PXCompressionFlags()
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

    Private Function CanProcessFile(filename As String) As Boolean
        If (Form1.PAQSeries.SelectedItem Is "PAQ8PX" And Form1.PAQVersion.SelectedIndex > Form1.Flags_enable) Or Form1.PAQSeries.SelectedItem Is "PAQ8PXd" Or Form1.PAQSeries.SelectedItem Is "PAQ8PXv" Then
            If IO.Path.GetExtension(filename).Contains(Form1.PAQSeries.SelectedItem.ToString.ToLower + Form1.PAQVersion.SelectedItem.ToString().Remove(0, 1)) Then
                If Form1.CompressRButton.Checked Then Return False Else Return True
            Else
                If Form1.CompressRButton.Checked Then Return True Else Return False
            End If
        Else
            If IO.Path.GetExtension(filename).Contains(Form1.PAQSeries.SelectedItem.ToString.ToLower + "_" + Form1.PAQVersion.SelectedItem.ToString()) Then
                If Form1.CompressRButton.Checked Then Return False Else Return True
            Else
                If Form1.CompressRButton.Checked Then Return True Else Return False
            End If
        End If
    End Function
    Public Function Upload(ByVal key As String, ByVal format As String, ByVal filename As String, ByVal category As String, ByVal file As String) As String
        If CanProcessFile(filename) Then
            Using client = New HttpClient()
                Using formData = New MultipartFormDataContent()
                    If True Then
                        Dim serverUrl As String = "https://boinc.moisescardona.me/"
                        If My.Settings.localServer Then
                            serverUrl = "http://127.0.0.1/test_server/"
                        End If
                        formData.Add(New StringContent(key), "k")
                        formData.Add(New StreamContent(New FileStream(file, FileMode.Open)), "filedata", Path.GetFileName(file))
                        formData.Add(New StringContent(category), "a")
                        formData.Add(New StringContent(format), "f")
                        formData.Add(New StringContent(GenerateCommandLineArguments()), "c")
                        formData.Add(New StringContent(GetOutputFilename(filename)), "n")
                        Dim uri As Uri = New Uri(serverUrl + "media_put.php")
                        client.DefaultRequestHeaders.Add("Accept-Language", "en-GB,en-US;q=0.8,en;q=0.6,ru;q=0.4")
                        client.Timeout = Threading.Timeout.InfiniteTimeSpan
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
        End If
        Return String.Empty
    End Function
End Class
