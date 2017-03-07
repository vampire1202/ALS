Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel

Public Class RichLabel
    Inherits Label

    Private _BackColor2 As Color = Color.PowderBlue

    'Private _BackColor1Hover As Color = Me.BackColor
    'Private _BackColor2Hover As Color = Me.BackColor
    <DisplayName("BackColor1")> Public Overrides Property BackColor() As System.Drawing.Color
        Get
            Return MyBase.BackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            MyBase.BackColor = value
        End Set
    End Property

    <Category("Appearance")> Public Property BackColor2() As Color
        Get
            Return Me._BackColor2
        End Get
        Set(ByVal value As Color)
            Me._BackColor2 = value
            Me.Invalidate()
        End Set
    End Property
    '<Category("Appearance")> Public Property BackColor1Hover() As Color
    'Get
    '    Return Me._BackColor1Hover
    'End Get
    'Set(ByVal value As Color)
    '    Me._BackColor1Hover = value
    '    Me.Invalidate()
    'End Set
    ' End Property
    '<Category("Appearance")> Public Property BackColor2Hover() As Color
    'Get
    '    Return Me._BackColor2Hover
    'End Get
    'Set(ByVal value As Color)
    '    Me._BackColor2Hover = value
    '    Me.Invalidate()
    'End Set
    'End Property

    Private _BorderTop As Color = Color.Transparent
    Private _BorderRight As Color = Color.Transparent
    Private _BorderBottom As Color = Color.Transparent
    Private _BorderLeft As Color = Color.Transparent
    <Category("Appearance")> Public Property BorderTop() As Color
        Get
            Return Me._BorderTop
        End Get
        Set(ByVal value As Color)
            Me._BorderTop = value
            Me.Invalidate()
        End Set
    End Property
    <Category("Appearance")> Public Property BorderRight() As Color
        Get
            Return Me._BorderRight
        End Get
        Set(ByVal value As Color)
            Me._BorderRight = value
            Me.Invalidate()
        End Set
    End Property
    <Category("Appearance")> Public Property BorderBottom() As Color
        Get
            Return Me._BorderBottom
        End Get
        Set(ByVal value As Color)
            Me._BorderBottom = value
            Me.Invalidate()
        End Set
    End Property
    <Category("Appearance")> Public Property BorderLeft() As Color
        Get
            Return Me._BorderLeft
        End Get
        Set(ByVal value As Color)
            Me._BorderLeft = value
            Me.Invalidate()
        End Set
    End Property

    Private _GradientMode As System.Drawing.Drawing2D.LinearGradientMode = Drawing2D.LinearGradientMode.Horizontal
    Private _GradientModeHover As System.Drawing.Drawing2D.LinearGradientMode = Drawing2D.LinearGradientMode.Horizontal
    <Category("Appearance")> Public Property GradientMode() As System.Drawing.Drawing2D.LinearGradientMode
        Get
            Return Me._GradientMode
        End Get
        Set(ByVal value As System.Drawing.Drawing2D.LinearGradientMode)
            Me._GradientMode = value
            Me.Invalidate()
        End Set
    End Property
    <Category("Appearance")> Public Property GradientModeHover() As System.Drawing.Drawing2D.LinearGradientMode
        Get
            Return Me._GradientModeHover
        End Get
        Set(ByVal value As System.Drawing.Drawing2D.LinearGradientMode)
            Me._GradientModeHover = value
            Me.Invalidate()
        End Set
    End Property

    Private _Shadow As Boolean
    <DefaultValue(GetType(Boolean), "False"), Category("Appearance")> Public Property Shadow() As Boolean
        Get
            Return Me._Shadow
        End Get
        Set(ByVal value As Boolean)
            Me._Shadow = value
            Me.Invalidate()
        End Set
    End Property

    'Private _IsHovering As Boolean
    'Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
    '    MyBase.OnMouseEnter(e)
    'Me._IsHovering = True
    '    Me.Invalidate()
    'End Sub
    'Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
    '    MyBase.OnMouseLeave(e)
    'Me._IsHovering = False
    '    Me.Invalidate()
    'End Sub
    Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaintBackground(pevent)

        Dim rec As Rectangle = Me.Bounds
        With rec
            .X = 0
            .Y = 0
        End With

        Dim LinearBrush As Brush = New Drawing2D.LinearGradientBrush(rec, Me.BackColor, Me.BackColor2, Me.GradientMode)

        'If Me._IsHovering Then
        '    LinearBrush = New Drawing2D.LinearGradientBrush(rec, Me.BackColor1Hover, Me.BackColor2Hover, Me.GradientModeHover)
        'End If

        pevent.Graphics.FillRectangle(LinearBrush, rec)
    End Sub
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        If Me.BorderStyle = Windows.Forms.BorderStyle.None Then

            e.Graphics.DrawLine(New Pen(Me.BorderTop, 1), 0, 0, Me.Width, 0)
            e.Graphics.DrawLine(New Pen(Me.BorderBottom, 1), 0, Me.Height - 1, Me.Width, Me.Height - 1)
            e.Graphics.DrawLine(New Pen(Me.BorderLeft, 1), -0, 0, -0, Me.Height)
            e.Graphics.DrawLine(New Pen(Me.BorderRight, 1), Me.Width - 1, 0, Me.Width - 1, Me.Height - 1)

            If Me.Shadow Then e.Graphics.DrawLine(New Pen(Color.White, 1), 1, 1, Me.Width - 2, 1)
            If Me.Shadow Then e.Graphics.DrawLine(New Pen(Color.White, 1), 1, 1, 1, Me.Height - 2)

        End If
    End Sub

End Class


