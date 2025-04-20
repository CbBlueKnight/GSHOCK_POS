Public Class Drag

    Private WithEvents DragControl As Control
    Private WithEvents Target As Control

    Private Dragging As Boolean = False
    Private DragCursorPoint As Point
    Private DragFormPoint As Point

    Public Sub New(ByVal DragControl As Control, ByVal Target As Control)
        Me.DragControl = DragControl
        Me.Target = Target
        AddHandler Me.DragControl.MouseDown, AddressOf DragControl_MouseDown
        AddHandler Me.DragControl.MouseMove, AddressOf DragControl_MouseMove
        AddHandler Me.DragControl.MouseUp, AddressOf DragControl_MouseUp
    End Sub

    Private Sub DragControl_MouseDown(sender As Object, e As MouseEventArgs) Handles DragControl.MouseDown
        If e.Button = MouseButtons.Left Then
            Dragging = True
            DragCursorPoint = Cursor.Position
            DragFormPoint = Target.Location
        End If
    End Sub

    Private Sub DragControl_MouseMove(sender As Object, e As MouseEventArgs) Handles DragControl.MouseMove
        If Dragging Then
            Dim diff As Point = Point.Subtract(Cursor.Position, New Size(DragCursorPoint))
            Target.Location = Point.Add(DragFormPoint, New Size(diff))
        End If
    End Sub

    Private Sub DragControl_MouseUp(sender As Object, e As MouseEventArgs) Handles DragControl.MouseUp
        If e.Button = MouseButtons.Left Then
            Dragging = False
        End If
    End Sub
End Class
