﻿Public Class Default_Screen
    Inherits BaseScreen
    Private AniTime As Double = 0
    Public Sub New()
        Name = "DefaultScreen"
        State = ScreenState.Active
    End Sub
    Public Overrides Sub HandleInput()

    End Sub
    Public Overrides Sub Update()
        AniTime += Globals.GameTime.ElapsedGameTime.TotalMilliseconds
        If AniTime > 255 Then
            AniTime = 0

        End If
    End Sub
    Public Overrides Sub Draw()

    End Sub
End Class