Public Class Form1

    Dim Captura As String
    Dim connect As String = "aiw://connect/"
    Dim savestart As String
    Dim ers As String = "\conector"
    Dim red1 As String = "<META HTTP-EQUIV="
    Dim red2 As String = """REFRESH""" & " CONTENT="
    Dim red3 As String = """3;URL="
    Dim red4 As String = """" & ">"
    Dim urls As String
    Dim cab1 As String = "<!DOCTYPE HTML PUBLIC "
    Dim cab2 As String = """-//W3C//DTD HTML 4.01 Transitional//EN"""
    Dim cab3 As String = ">"
    Dim cab4 As String = "<html>"
    Dim cab5 As String = "  <head>"
    Dim cab6 As String = "      <title>Redirigir al navegador a otra URL</title>"
    Dim cab7 As String = "  </head>"
    Dim cab71 As String = "<body>"
    Dim cab8 As String = "<Strong><a>Conectando en 5, 4, 3, 2, 1...</a></strong>"
    Dim cab81 As String = "</body>"
    Dim cab10 As String = "</html>"
    Dim proceso As New System.Diagnostics.Process

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Debe introducir al menos una direccion IP", MsgBoxStyle.Exclamation, "Atencion")
        Else
            urls = connect & TextBox1.Text
            savestart = cab1 & cab2 & cab3 & vbNewLine & vbNewLine & cab4 & vbNewLine & cab5 & vbNewLine & cab6 & vbNewLine & _
            red1 & red2 & red3 & urls & red4 & vbNewLine & cab7 & vbNewLine & cab71 & vbNewLine & cab8 & vbNewLine & cab81 & _
            vbNewLine & cab10
            System.IO.File.WriteAllText(Application.StartupPath & "\conector.html", savestart)
            With (proceso)
                .StartInfo.FileName = Application.StartupPath & "\conector.html"
                .Start()
            End With
        End If

        If CheckBox1.Checked = True Then
            ListBox1.Items.Add(TextBox1.Text.Trim)
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form2.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ListBox1.Items.Remove(ListBox1.SelectedItem)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        TextBox1.Text = ""
        TextBox1.Text = ListBox1.SelectedItem
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ListBox1.Items.Clear()
    End Sub

    Sub cargar()
        On Error Resume Next
        If My.Computer.FileSystem.FileExists(Application.StartupPath + "/lista.xml") Then
            ListBox1.Items.Clear()
            Dim sr As New System.IO.StreamReader(Application.StartupPath + "/lista.xml", System.Text.Encoding.Default, True)
            While sr.Peek() <> -1
                Dim s As String = sr.ReadLine()
                If String.IsNullOrEmpty(s) Then
                    Continue While
                End If
                ListBox1.Items.Add(s)
            End While
            sr.Close()
        Else
            MsgBox("Puede ser la primera vez que se ejecute" + vbNewLine + "la aplicacion por tanto no existe el archivo.", MsgBoxStyle.Information, "Error")
            ListBox1.Items.Clear()
        End If
    End Sub

    Sub guardar()
      
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        cargar()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        guardar()
    End Sub
End Class
