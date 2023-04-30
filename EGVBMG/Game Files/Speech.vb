Public Class Speech
    Inherits BaseScreen
    Private AniTime As Double = 0
    Public Sub New()
        Name = "Speech"
        State = ScreenState.Active
        resetlevel()
    End Sub
    Dim Offset As Vector2
    Public Clicked As Boolean = False
    Dim level As Integer = 0
    Dim CurrentWord As String = "TOP"
    Dim PuzzleSet As String = "999"
    Dim Lips As String = "PBMFWQ"
    Dim Teeth As String = "TNZSCV"
    Dim Nasal As String = "AEIOU"
    Dim Throat As String = "RKGH"
    Dim Tongue As String = "LXJYD"
    Dim dragging As Boolean = False
    Dim Selected As Integer = -1
    Dim Soundout As Integer = 0
    Dim currentletter = 0
    Dim correct As Boolean = False
    Dim levels() As String = {"A", "BE", "THE", "AND", "TOP", "LEAP", "FRUIT", "GLIDE", "QUEEN", "VULKAN", "FATHER", "UNREAL", "PSYCHE", "VEHICLE", "COMPUTER"}
    Dim EndofGame As Boolean = False
    Dim hold As Boolean = False
    Public Overrides Sub HandleInput()
        If Mouse.GetState.LeftButton = ButtonState.Pressed And Not Clicked And Maths.CursorOnScreen Then
            Sounds.Click.Play()
            Clicked = True
            hold = True
            If Selected <> -1 Then dragging = True
            If correct Then
                If level < levels.Length - 1 Then
                    level += 1
                Else
                    EndofGame = True
                End If
                resetlevel()
            End If
            If EndofGame Then
                End
            End If
        ElseIf Mouse.GetState.LeftButton = ButtonState.Released And Clicked Then
            Clicked = False
            Selected = -1
            dragging = False
            hold = False
        End If
    End Sub
    Sub resetlevel()
        correct = False
        CurrentWord = levels(level)
        PuzzleSet = "9999999999"
    End Sub
    Public Overrides Sub Update()
        AniTime += Globals.GameTime.ElapsedGameTime.TotalMilliseconds
        If AniTime > (1.0F / 180.0F) Then
            AniTime = 0
            If Not dragging Then
                For q As Integer = 0 To CurrentWord.Length - 1
                    If Maths.Inside(New Rectangle(Mouse.GetState.X, Mouse.GetState.Y, 10, 10), New Rectangle(2 + (q * 150), Globals.GameSize.Y / 2, 146, 146)) Then
                        Selected = q
                        Offset = New Vector2(2 + (q * 150) - Mouse.GetState.X, Globals.GameSize.Y / 2 - Mouse.GetState.Y)
                        Exit For
                    End If
                Next
            Else
                'Throat
                If Maths.Inside(New Rectangle(Mouse.GetState.X, Mouse.GetState.Y, 10, 10), New Rectangle(1512, 709, 153, 371)) Then
                    PuzzleSet = PuzzleSet.Substring(0, Selected) & "4" & PuzzleSet.Substring(Selected + 1)
                End If
                'Tongue
                If Maths.Inside(New Rectangle(Mouse.GetState.X, Mouse.GetState.Y, 10, 10), New Rectangle(1301, 662, 248, 181)) Then
                    PuzzleSet = PuzzleSet.Substring(0, Selected) & "3" & PuzzleSet.Substring(Selected + 1)
                End If
                'Nose
                If Maths.Inside(New Rectangle(Mouse.GetState.X, Mouse.GetState.Y, 10, 10), New Rectangle(1173, 459, 449, 142)) Then
                    PuzzleSet = PuzzleSet.Substring(0, Selected) & "1" & PuzzleSet.Substring(Selected + 1)
                End If
                'Teeth
                If Maths.Inside(New Rectangle(Mouse.GetState.X, Mouse.GetState.Y, 10, 10), New Rectangle(1247, 628, 40, 75)) Then
                    PuzzleSet = PuzzleSet.Substring(0, Selected) & "0" & PuzzleSet.Substring(Selected + 1)
                End If
                'Lips
                If Maths.Inside(New Rectangle(Mouse.GetState.X, Mouse.GetState.Y, 10, 10), New Rectangle(1222, 629, 38, 73)) Then
                    PuzzleSet = PuzzleSet.Substring(0, Selected) & "2" & PuzzleSet.Substring(Selected + 1)
                End If

            End If
            If Not PuzzleSet.Substring(0, CurrentWord.Length - 1).Contains("9") And Not correct And Not dragging And Not PuzzleSet.Substring(0, 1).Contains("9") And Not hold Then
                Soundout += 1
                If Soundout = 100 Then
                    Soundout = 0
                    currentletter += 1
                    If currentletter > CurrentWord.Length Then
                        currentletter = 0
                        hold = True
                        Dim testcorrect As Boolean = True
                        For q As Integer = 0 To CurrentWord.Length - 1
                            Select Case PuzzleSet.Substring(q, 1)
                                Case "0"
                                    If Not Teeth.Contains(CurrentWord.Substring(q, 1)) Then
                                        testcorrect = False
                                        Exit For
                                    End If
                                Case "1"
                                    If Not Nasal.Contains(CurrentWord.Substring(q, 1)) Then
                                        testcorrect = False
                                        Exit For
                                    End If
                                Case "2"
                                    If Not Lips.Contains(CurrentWord.Substring(q, 1)) Then
                                        testcorrect = False
                                        Exit For
                                    End If
                                Case "3"
                                    If Not Tongue.Contains(CurrentWord.Substring(q, 1)) Then
                                        testcorrect = False
                                        Exit For
                                    End If
                                Case "4"
                                    If Not Throat.Contains(CurrentWord.Substring(q, 1)) Then
                                        testcorrect = False
                                        Exit For
                                    End If
                                Case Else
                                    testcorrect = False
                                    Exit For
                            End Select
                        Next
                        If testcorrect Then
                            correct = True
                            Sounds.Ding.Play()
                        End If
                    End If
                    If currentletter > 0 Then
                        Dim testcorrect As Boolean = True
                        Select Case PuzzleSet.Substring(currentletter - 1, 1)
                            Case "0"
                                If Not Teeth.Contains(CurrentWord.Substring(currentletter - 1, 1)) Then
                                    testcorrect = False
                                End If
                            Case "1"
                                If Not Nasal.Contains(CurrentWord.Substring(currentletter - 1, 1)) Then
                                    testcorrect = False
                                End If
                            Case "2"
                                If Not Lips.Contains(CurrentWord.Substring(currentletter - 1, 1)) Then
                                    testcorrect = False
                                End If
                            Case "3"
                                If Not Tongue.Contains(CurrentWord.Substring(currentletter - 1, 1)) Then
                                    testcorrect = False
                                End If
                            Case "4"
                                If Not Throat.Contains(CurrentWord.Substring(currentletter - 1, 1)) Then
                                    testcorrect = False
                                End If
                            Case Else
                                testcorrect = False
                        End Select
                        If testcorrect Then
                            Select Case CurrentWord.Substring(currentletter - 1, 1)
                                Case "A"
                                    Sounds.A.Play()
                                Case "B"
                                    Sounds.B.Play()
                                Case "C"
                                    Sounds.C.Play()
                                Case "D"
                                    Sounds.D.Play()
                                Case "E"
                                    Sounds.E.Play()
                                Case "F"
                                    Sounds.F.Play()
                                Case "G"
                                    Sounds.G.Play()
                                Case "H"
                                    Sounds.H.Play()
                                Case "I"
                                    Sounds.I.Play()
                                Case "J"
                                    Sounds.J.Play()
                                Case "K"
                                    Sounds.K.Play()
                                Case "L"
                                    Sounds.L.Play()
                                Case "M"
                                    Sounds.M.Play()
                                Case "N"
                                    Sounds.N.Play()
                                Case "O"
                                    Sounds.O.Play()
                                Case "P"
                                    Sounds.P.Play()
                                Case "Q"
                                    Sounds.Q.Play()
                                Case "R"
                                    Sounds.R.Play()
                                Case "S"
                                    Sounds.S.Play()
                                Case "T"
                                    Sounds.T.Play()
                                Case "U"
                                    Sounds.U.Play()
                                Case "V"
                                    Sounds.V.Play()
                                Case "W"
                                    Sounds.W.Play()
                                Case "X"
                                    Sounds.X.Play()
                                Case "Y"
                                    Sounds.Y.Play()
                                Case "Z"
                                    Sounds.Z.Play()
                            End Select
                        Else
                            Select Case PuzzleSet.Substring(currentletter - 1, 1)
                                Case "0"
                                    Sounds.HZ.Play()
                                Case "1"
                                    Sounds.HW.Play()
                                Case "2"
                                    Sounds.BP.Play()
                                Case "3"
                                    Sounds.RR.Play()
                                Case "4"
                                    Sounds.XH.Play()
                            End Select
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Public Overrides Sub Draw()
        Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(0, 0, Globals.GameSize.X, Globals.GameSize.X / 16 * 9), New Rectangle(0, 0, 1920, 1080), Color.White)

        If Not EndofGame Then
            For q As Integer = 0 To CurrentWord.Length - 1
                Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(2 + (q * 150), Globals.GameSize.Y / 2 - 150, 146, 146), New Rectangle(1927, 153, 146, 146), Color.White)
                Globals.SpriteBatch.DrawString(Fonts.Georgia_16, CurrentWord.Substring(q, 1), New Vector2(40 + (q * 150), Globals.GameSize.Y / 2 - 130), Color.White) 'New Rectangle(2 + (q * 150), Globals.GameSize.Y / 2, 146, 146), New Rectangle(1927, 153, 146, 146), Color.White)
            Next

            For q As Integer = 0 To CurrentWord.Length - 1
                If Selected = q Then
                    If dragging Then
                        Select Case PuzzleSet.Substring(q, 1)
                            Case "0"
                                Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(Mouse.GetState.X + Offset.X, Mouse.GetState.Y + Offset.Y, 146, 146), New Rectangle(1927, 4, 146, 146), Color.White)
                            Case "1"
                                Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(Mouse.GetState.X + Offset.X, Mouse.GetState.Y + Offset.Y, 146, 146), New Rectangle(2076, 4, 146, 146), Color.White)
                            Case "2"
                                Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(Mouse.GetState.X + Offset.X, Mouse.GetState.Y + Offset.Y, 146, 146), New Rectangle(2225, 4, 146, 146), Color.White)
                            Case "3"
                                Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(Mouse.GetState.X + Offset.X, Mouse.GetState.Y + Offset.Y, 146, 146), New Rectangle(2374, 4, 146, 146), Color.White)
                            Case "4"
                                Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(Mouse.GetState.X + Offset.X, Mouse.GetState.Y + Offset.Y, 146, 146), New Rectangle(2523, 4, 146, 146), Color.White)
                            Case Else
                                Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(Mouse.GetState.X + Offset.X, Mouse.GetState.Y + Offset.Y, 146, 146), New Rectangle(1927, 153, 146, 146), Color.White)
                        End Select
                        Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(Mouse.GetState.X + Offset.X, Mouse.GetState.Y + Offset.Y, 146, 146), New Rectangle(1927, 153, 146, 146), Color.Yellow)
                    Else
                        Select Case PuzzleSet.Substring(q, 1)
                            Case "0"
                                Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(2 + (q * 150), Globals.GameSize.Y / 2, 146, 146), New Rectangle(1927, 4, 146, 146), Color.White)
                            Case "1"
                                Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(2 + (q * 150), Globals.GameSize.Y / 2, 146, 146), New Rectangle(2076, 4, 146, 146), Color.White)
                            Case "2"
                                Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(2 + (q * 150), Globals.GameSize.Y / 2, 146, 146), New Rectangle(2225, 4, 146, 146), Color.White)
                            Case "3"
                                Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(2 + (q * 150), Globals.GameSize.Y / 2, 146, 146), New Rectangle(2374, 4, 146, 146), Color.White)
                            Case "4"
                                Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(2 + (q * 150), Globals.GameSize.Y / 2, 146, 146), New Rectangle(2523, 4, 146, 146), Color.White)
                            Case Else
                                Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(2 + (q * 150), Globals.GameSize.Y / 2, 146, 146), New Rectangle(1927, 153, 146, 146), Color.White)
                        End Select
                        Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(2 + (q * 150), Globals.GameSize.Y / 2, 146, 146), New Rectangle(1927, 153, 146, 146), Color.Yellow)
                    End If
                Else
                    Select Case PuzzleSet.Substring(q, 1)
                        Case "0"
                            Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(2 + (q * 150), Globals.GameSize.Y / 2, 146, 146), New Rectangle(1927, 4, 146, 146), Color.White)
                        Case "1"
                            Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(2 + (q * 150), Globals.GameSize.Y / 2, 146, 146), New Rectangle(2076, 4, 146, 146), Color.White)
                        Case "2"
                            Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(2 + (q * 150), Globals.GameSize.Y / 2, 146, 146), New Rectangle(2225, 4, 146, 146), Color.White)
                        Case "3"
                            Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(2 + (q * 150), Globals.GameSize.Y / 2, 146, 146), New Rectangle(2374, 4, 146, 146), Color.White)
                        Case "4"
                            Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(2 + (q * 150), Globals.GameSize.Y / 2, 146, 146), New Rectangle(2523, 4, 146, 146), Color.White)
                        Case Else
                            Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(2 + (q * 150), Globals.GameSize.Y / 2, 146, 146), New Rectangle(1927, 153, 146, 146), Color.White)
                    End Select
                End If
            Next

            If currentletter > 0 Then
                Select Case PuzzleSet.Substring(currentletter - 1, 1)
                    Case "0"
                        If Not Teeth.Contains(CurrentWord.Substring(currentletter - 1, 1)) Then
                            Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(2 + ((currentletter - 1) * 150), Globals.GameSize.Y / 2, 146, 146), New Rectangle(1927, 153, 146, 146), Color.Orange)
                        Else
                            Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(2 + ((currentletter - 1) * 150), Globals.GameSize.Y / 2, 146, 146), New Rectangle(1927, 153, 146, 146), Color.LimeGreen)
                        End If
                        Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(1247, 628, 24, 75), New Rectangle(1099, 1438, 24, 75), Color.White)
                    Case "1"
                        If Not Nasal.Contains(CurrentWord.Substring(currentletter - 1, 1)) Then
                            Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(2 + ((currentletter - 1) * 150), Globals.GameSize.Y / 2, 146, 146), New Rectangle(1927, 153, 146, 146), Color.Orange)
                        Else
                            Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(2 + ((currentletter - 1) * 150), Globals.GameSize.Y / 2, 146, 146), New Rectangle(1927, 153, 146, 146), Color.LimeGreen)
                        End If
                        Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(1172, 459, 450, 143), New Rectangle(1061, 1204, 450, 143), Color.White)
                    Case "2"
                        If Not Lips.Contains(CurrentWord.Substring(currentletter - 1, 1)) Then
                            Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(2 + ((currentletter - 1) * 150), Globals.GameSize.Y / 2, 146, 146), New Rectangle(1927, 153, 146, 146), Color.Orange)
                        Else
                            Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(2 + ((currentletter - 1) * 150), Globals.GameSize.Y / 2, 146, 146), New Rectangle(1927, 153, 146, 146), Color.LimeGreen)
                        End If
                        Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(1220, 628, 42, 74), New Rectangle(1261, 1440, 42, 74), Color.White)
                    Case "3"
                        If Not Tongue.Contains(CurrentWord.Substring(currentletter - 1, 1)) Then
                            Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(2 + ((currentletter - 1) * 150), Globals.GameSize.Y / 2, 146, 146), New Rectangle(1927, 153, 146, 146), Color.Orange)
                        Else
                            Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(2 + ((currentletter - 1) * 150), Globals.GameSize.Y / 2, 146, 146), New Rectangle(1927, 153, 146, 146), Color.LimeGreen)
                        End If
                        Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(1301, 662, 248, 181), New Rectangle(728, 1602, 248, 181), Color.White)
                    Case "4"
                        If Not Throat.Contains(CurrentWord.Substring(currentletter - 1, 1)) Then
                            Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(2 + ((currentletter - 1) * 150), Globals.GameSize.Y / 2, 146, 146), New Rectangle(1927, 153, 146, 146), Color.Orange)
                        Else
                            Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(2 + ((currentletter - 1) * 150), Globals.GameSize.Y / 2, 146, 146), New Rectangle(1927, 153, 146, 146), Color.LimeGreen)
                        End If
                        Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(1512, 709, 153, 371), New Rectangle(833, 1160, 153, 371), Color.White)
                End Select
            End If
        End If



        If correct And Not EndofGame Then
            Globals.SpriteBatch.DrawString(Fonts.Georgia_16, "That's Correct!", New Vector2(2, 50), Color.White)
        ElseIf EndofGame Then
            Globals.SpriteBatch.DrawString(Fonts.Georgia_16, "End of Game! :)", New Vector2(2, 50), Color.White)
        End If

        Globals.SpriteBatch.DrawString(Fonts.Georgia_16, "Level: " & level, New Vector2(2, Globals.GameSize.Y - 100), Color.White)


        '  Globals.SpriteBatch.Draw(Textures.SpriteSheet, New Rectangle(Mouse.GetState.X, Mouse.GetState.Y, 19, 19), New Rectangle(1927, 308, 19, 19), Color.White)
    End Sub
End Class