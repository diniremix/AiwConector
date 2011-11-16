Public Class Form2
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Debe especificar al menos la Direccion IP", MsgBoxStyle.Exclamation, "Atencion")
        Else
            Form1.ListBox1.Items.Add(TextBox1.Text.Trim)
        End If
    End Sub
End Class