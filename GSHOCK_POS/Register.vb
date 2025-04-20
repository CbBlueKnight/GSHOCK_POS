Public Class Register

    Private DragHandler As Drag
    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AllowTransparency = True
        Panel1.BackColor = Color.FromArgb(220, 0, 0, 0)
        Button1.BackColor = Color.FromArgb(200, 255, 255, 255)
        DragHandler = New Drag(Panel2, Me)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim url As String = "https://gshock.casio.com/ph/"
        Dim psi As New ProcessStartInfo()
        psi.FileName = url
        psi.UseShellExecute = True ' Ensure compatibility with newer frameworks
        Process.Start(psi)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

End Class