Public Class Form1

    Private dragging As Boolean = False
    Private dragCursorPoint As Point
    Private dragFormPoint As Point

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim GShockIcon = Svg.SvgDocument.Open(My.Settings.GSHOCKSVG)
            GShockIcon.Width = 106.28
            GShockIcon.Height = 17.98
            Dim GShockGitmap = GShockIcon.Draw()
            PictureBox1.Image = GShockGitmap
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            dragging = True
            dragCursorPoint = Cursor.Position
            dragFormPoint = Me.Location
        End If
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If dragging Then
            Dim diff As Point = Point.Subtract(Cursor.Position, New Size(dragCursorPoint))
            Me.Location = Point.Add(dragFormPoint, New Size(diff))
        End If
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        If e.Button = MouseButtons.Left Then
            dragging = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

End Class
