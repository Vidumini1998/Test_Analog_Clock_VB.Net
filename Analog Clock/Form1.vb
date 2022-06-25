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

    Dim GreenPen As Pen = New Pen(Color.Green, 4)
    Dim Bluepen As Pen = New Pen(Color.Blue, 4)
    Dim OrangePen As Pen = New Pen(Color.DarkOrange, 5)
    Dim BlackPen As Pen = New Pen(Color.Black, 6)
    Dim myPen As New Pen(Color.DarkBlue, 8)
    Dim NumberFont As New Font("Arial", 25, FontStyle.Bold)
    Dim ClockFont As New Font("Arial", 18, FontStyle.Bold)
    Dim ClockFace As New Bitmap(445, 445)
    Dim gr As Graphics = Graphics.FromImage(ClockFace)

    Private Sub Form1_Load(Sender As Object, e As EventArgs) Handles MyBase.Load
        Bluepen.SetLineCap(LineCap.Round, LineCap.ArrowAnchor, DashCap.Flat)
        OrangePen.SetLineCap(LineCap.Round, LineCap.ArrowAnchor, DashCap.Flat)
        DoubleBuffered = True
        Me.Size = New Size(570, 470)
        'Me.FormBorderStyle = WindowsFormsSection.Forms.FormBorderStyle.None
        Me.TransparencyKey = SystemColors.Control
        Me.CenterToScreen()
        CalculatePerimeter()
        DrawFace()
        Timer1.Interval = 999
        Timer1.Start()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        e.Graphics.DrawImage(ClockFace, Point.Empty)
        e.Graphics.DrawString(TimeString, ClockFont, Brushes.White, 170, 260)
        e.Graphics.DrawLine(BlackPen, 220, 220, HrX, HrY)
        e.Graphics.FillEllipse(Brushes.Black, 210, 210, 20, 20)
        e.Graphics.DrawLine(OrangePen, 220, 220, MinX, MinY)
        e.Graphics.FillEllipse(Brushes.DarkOrange, 212, 212, 16, 16)
        e.Graphics.DrawLine(Bluepen, 220, 220, SecX, SecY)
        e.Graphics.FillEllipse(Brushes.Blue, 215, 215, 10, 10)
    End Sub

    Sub DrawFace()
        gr.SmoothingMode = SmoothingMode.HighQuality
        gr.FillEllipse(Brushes.Beige, 20, 20, 400, 400)
        gr.DrawEllipse(GreenPen, 20, 20, 400, 400)
        gr.DrawEllipse(Pens.Red, 120, 120, 200, 200)
        For I As Integer = 1 To 60
            gr.DrawLine(GreenPen, StartPoint(I), EndPoints(I))
        Next

        For I As Integer = 1 To 12
            gr.DrawString(I.ToString, NumberFont, Brushes.Black, NumberPoint(I - 1))
        Next

        gr.FillRectangle(Brushes.DarkBlue, 170, 260, 100, 30)
        myPen.LineJoin = LineJoin.Round
        gr.DrawRectangle(myPen, 170, 260, 100, 30)
    End Sub

    Sub CalculatePerimeter()
        Dim X, Y As Integer
        Dim radius As Integer
        For I As Integer = 1 To 60
            If I Mod 5 = 0 Then
                radius = 182
            Else
                radius = 190
            End If
            X = CInt(radius * Math.Cos((90 - I * 6) * Convert)) + 200
            Y = 220 - CInt(radius * Math.Sin((90 - I * 6) * Convert))
            StartPoint(I) = New PointF(X, Y)

            X = CInt(200 * Math.Cos((90 - I * 6) * Convert)) + 200
            Y = 220 - CInt(200 * Math.Sin((90 - I * 6) * Convert))
            EndPoints(I) = New PointF(X, Y)
        Next
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TimeString = Now.ToString("HH:MM:SS")

        SecAngle = (Now.Second * 6)
        MinAngle = (Now.Minute + Now.Second / 60) * 6
        HrAngle = (Now.Hour + Now.Minute / 60) * 30
        SecX = CInt(SecRadius * Math.Cos((90 - SecAngle) * Convert)) + 220
        SecY = 220 - CInt(SecRadius * Math.Sin((90 - SecAngle) * Convert))

    End Sub
End Class
