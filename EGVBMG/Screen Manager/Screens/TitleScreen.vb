﻿Public Class TitleScreen
    Inherits BaseScreen
    Private AniTime As Double = 0
    Public Sub New()
        Name = "TitleScreen"
        State = ScreenState.Active
    End Sub
    Public Overrides Sub HandleInput()
        MyBase.HandleInput()
    End Sub
    Public Overrides Sub Update()
        'Example of how to control your updates
        AniTime += Globals.GameTime.ElapsedGameTime.TotalMilliseconds
        If AniTime > 255 Then
            AniTime = 0

        End If
    End Sub
    Public Overrides Sub Draw()
        Globals.SpriteBatch.Draw(Textures.Null, New Rectangle(0, 0, Globals.GameSize.X, Globals.GameSize.Y), New Color(100, 0, 200))

        Globals.SpriteBatch.DrawString(Fonts.MotorWerk_16, GameVersion.Name, New Vector2(Globals.GameSize.X / 2.05 - Fonts.MotorWerk_16.MeasureString(GameVersion.Name).X, Globals.GameSize.Y / 4), New Color(CInt((Game1.Aminate Mod 20) * 30), 0, 0), 0, New Vector2(0, 0), 2.4, SpriteEffects.None, 0)

    End Sub
    Public Overrides Sub remove()
        MyBase.remove()
    End Sub
End Class