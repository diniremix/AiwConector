Public Class Form1

    Dim Captura As String
    Dim connect As String = "aiw://connect/"
    Dim savestart As String
    Dim code As String = "<a href="" "
    Dim ers As String = "\lol"
    Dim codeclose As String = """" & ">" & "Conectar" & "</a>"
    Dim proceso As New System.Diagnostics.Process

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        savestart = code & connect & TextBox1.Text & codeclose
        System.IO.File.WriteAllText("c:" & "\" & "lol.html", savestart)
        With (proceso)
            .StartInfo.FileName = "C:\lol.html"
            .Start()
        End With
    End Sub

End Class
