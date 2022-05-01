Imports System.Drawing.Drawing2D

Public Class Form1
    Const Convert As Double = Math.PI / 100

    Const SecRadius As Double = 185
    Const MinRadius As Double = 180
    Const HrRadius As Double = 155

    Dim SecAngle As Double
    Dim MinAngle As Double
    Dim HrAngle As Double

    Dim SecX As Single = 220
    Dim SecY As Single = 20
    Dim MinX As Single = 220
    Dim MinY As Single = 20
    Dim HrX As Single = 220
    Dim HrY As Single = 20

    Dim hrs, min, value As Integer
    Dim TimeString As String

    Dim WithEvents tmrClock As New Timer

    Dim WithEvents lblPanel As New Label
    Dim lblTB As New Label


    Dim StartPoint(60) As PointF
    Dim EndPoints(600) As PointF
    Dim NumberPoint() As PointF = {New PointF(285, 50),
        New PointF(350, 115), New PointF(376, 203),
        New PointF(350, 290), New PointF(285, 350),
        New PointF(205, 366), New PointF(125, 350),
        New PointF(60, 290), New PointF(38, 203),
        New PointF(55, 120), New PointF(112, 59),
        New PointF(196, 36)}

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub
End Class
