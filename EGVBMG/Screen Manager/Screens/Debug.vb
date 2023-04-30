﻿Public Class Debug
    Inherits BaseScreen
    Public Shared Screens As String = ""
    Public FocusScreen As String = ""
    Private fps As Integer
    Private fpsCounter As Integer
    Private fpsTimer As Double
    Private fpsText As String = ""
    Private BGRect As Rectangle
    Private KeyDown As Boolean = False
    Public Sub New()
        Name = "Debug"
        State = ScreenState.Debug
        GrabFocus = False
        Permission = 5
    End Sub
    Public Overrides Sub HandleInput()
        'If Input.KeyPressed(Keys.F1) Then
        '    If Globals.Debugging Then
        '        Globals.Debugging = False
        '        Debug_Console.Close()
        '    Else
        '        Globals.Debugging = True
        '    End If
        'End If
        'If Globals.Debugging Then
        '    If Input.KeyPressed(Keys.F2) Then
        '        Debug_Console.Show()
        '        Debug_Console.GameInput = False
        '        Debug_Console.chkInput.Checked = False
        '    End If
        'End If
    End Sub
    Public Overrides Sub Update()
        MyBase.Update()
        If Screens.Length > 0 Then
            Screens = Screens.Substring(0, Screens.Length - 2)
        End If
        Dim txtWidth As Integer = 0
        Dim txtHeight As Integer = 0
        If Fonts.Arial_8.MeasureString(Screens).X > txtWidth Then
            txtWidth = Fonts.Arial_8.MeasureString(Screens).X
        End If
        If Fonts.Arial_8.MeasureString(FocusScreen).X > txtWidth Then
            txtWidth = Fonts.Arial_8.MeasureString(FocusScreen).X
        End If
        txtHeight = Fonts.Arial_8.MeasureString(fpsText).Y * 3
        BGRect = New Rectangle(0, 0, txtWidth + 20, txtHeight + 20)
    End Sub
    Public Overrides Sub Draw()
        MyBase.Draw()
        If Globals.GameTime.TotalGameTime.TotalMilliseconds > fpsTimer Then
            fps = fpsCounter
            fpsTimer = Globals.GameTime.TotalGameTime.TotalMilliseconds + 1000
            fpsCounter = 1
            fpsText = "FPS: " & fps
        Else
            fpsCounter += 1
        End If
        Globals.SpriteBatch.Draw(Textures.Null, BGRect, Color.Black * 0.6F)
        Globals.SpriteBatch.DrawString(Fonts.Arial_8, fpsText, New Vector2(10, 10), Color.White)
        Globals.SpriteBatch.DrawString(Fonts.Arial_8, Screens, New Vector2(10, 22), Color.White)
        Globals.SpriteBatch.DrawString(Fonts.Arial_8, FocusScreen, New Vector2(10, 34), Color.White)
    End Sub
End Class