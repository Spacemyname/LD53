Public Class Input
    Shared CurrentKeyState As KeyboardState
    Shared LastKeyState As KeyboardState
    Public Shared Sub Update()
        LastKeyState = CurrentKeyState
        CurrentKeyState = Keyboard.GetState
        LastGamepadState = CurrentGamepadState
        CurrentGamepadState = GamePad.GetState(PlayerIndex.One)
        If KeyDown(ActionUp) Or KeyDown(ActionUpAlt) Or ButtonDown(Buttons.LeftThumbstickUp) Or ButtonDown(Buttons.RightThumbstickUp) Or ButtonPressed(Buttons.DPadUp) Then
            GA_Up = True
        Else
            GA_Up = False
        End If
        If KeyDown(ActionDown) Or KeyDown(ActionDownAlt) Or ButtonDown(Buttons.LeftThumbstickDown) Or ButtonDown(Buttons.RightThumbstickDown) Or ButtonPressed(Buttons.DPadDown) Then
            GA_Down = True
        Else
            GA_Down = False
        End If
        If KeyDown(ActionLeft) Or KeyDown(ActionLeftAlt) Or ButtonDown(Buttons.LeftThumbstickLeft) Or ButtonDown(Buttons.RightThumbstickLeft) Or ButtonPressed(Buttons.DPadLeft) Then
            GA_Left = True
        Else
            GA_Left = False
        End If
        If KeyDown(ActionRight) Or KeyDown(ActionRightAlt) Or ButtonDown(Buttons.LeftThumbstickRight) Or ButtonDown(Buttons.RightThumbstickRight) Or ButtonPressed(Buttons.DPadRight) Then
            GA_Right = True
        Else
            GA_Right = False
        End If
        If KeyPressed(ActionSpace) Or KeyPressed(ActionMenuSel) Or ButtonPressed(Buttons.RightShoulder) Or ButtonPressed(Buttons.A) Then
            GA_Forward = True
        Else
            GA_Forward = False
        End If
        If KeyPressed(ActionMenuBack) Or ButtonPressed(Buttons.B) Then
            GA_Backward = True
        Else
            GA_Backward = False
        End If
        If KeyPressed(ActionShoot) Or ButtonPressed(Buttons.Y) Then
            GA_Shoot = True
        Else
            GA_Shoot = False
        End If
        If KeyPressed(ActionQuest) Or ButtonPressed(Buttons.X) Then
            GA_Quest = True
        Else
            GA_Quest = False
        End If
        If KeyPressed(ActionTablet) Or ButtonPressed(Buttons.Start) Then
            GA_Tablet = True
        Else
            GA_Tablet = False
        End If
        If KeyPressed(ActionOres) Or ButtonPressed(Buttons.LeftShoulder) Then
            GA_OreMenu = True
        Else
            GA_OreMenu = False
        End If
        If KeyDown(ActionShift) Or ButtonDown(Buttons.LeftTrigger) Then
            GA_Turbo = True
        Else
            GA_Turbo = False
        End If
        If KeyPressed(ActionReloadMods) Or ButtonPressed(Buttons.BigButton) Then
            GA_DevReload = True
        Else
            GA_DevReload = False
        End If
        If KeyPressed(ActionTab) Or ButtonPressed(Buttons.RightTrigger) Then
            GA_Cling = True
        Else
            GA_Cling = False
        End If

    End Sub
    Public Shared Function KeyDown(key As Keys) As Boolean
        If GamepadAnalogBypass(key) Then
            Return True
        Else
            Return CurrentKeyState.IsKeyDown(key)
        End If
    End Function
    Public Shared Function KeyPressed(key As Keys) As Boolean
        If CurrentKeyState.IsKeyDown(key) And LastKeyState.IsKeyUp(key) Then
            Return True
            'ElseIf LastKeyState.IsKeyUp(key) And GamepadBypass(key) Then
            '    Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function ButtonDown(Button As Buttons) As Boolean
        Return CurrentGamepadState.IsButtonDown(Button)
    End Function
    Public Shared Function ButtonPressed(Button As Buttons) As Boolean
        If CurrentGamepadState.IsButtonDown(Button) And LastGamepadState.IsButtonUp(Button) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function KeyPoll() As Integer
        For q As Integer = 0 To 200
            If Input.KeyDown(q) Then
                Return q
                Exit For
            End If
            'If Input.ButtonDown(q) Then
            '    Return q
            '    Exit For
            'End If
        Next
        Return -1
    End Function
    Public Shared ActionUp As Integer = AscW("W")
    Public Shared ActionLeft As Integer = AscW("A")
    Public Shared ActionDown As Integer = AscW("S")
    Public Shared ActionRight As Integer = AscW("D")
    Public Shared ActionUpAlt As Integer = 38 'U
    Public Shared ActionLeftAlt As Integer = 37 'L
    Public Shared ActionDownAlt As Integer = 40 'D
    Public Shared ActionRightAlt As Integer = 39 'R
    Public Shared ActionMenuSel As Integer = 13 'ENTER
    Public Shared ActionMenuBack As Integer = 27 'ESC
    Public Shared ActionQuest As Integer = AscW("Q")
    Public Shared ActionTablet As Integer = AscW("L")
    Public Shared ActionShoot As Integer = AscW("Y")
    Public Shared ActionSpace As Integer = 32 'Space
    Public Shared ActionCharge As Integer = AscW("C")
    Public Shared ActionMine As Integer = AscW("M")
    Public Shared ActionShift As Integer = 160
    Public Shared ActionOres As Integer = AscW("O")
    Public Shared ActionTab As Integer = 9
    Public Shared ActionReloadMods As Integer = 116

    Public Shared GA_Up As Boolean = False
    Public Shared GA_Left As Boolean = False
    Public Shared GA_Down As Boolean = False
    Public Shared GA_Right As Boolean = False
    Public Shared GA_Forward As Boolean = False
    Public Shared GA_Backward As Boolean = False
    Public Shared GA_Shoot As Boolean = False
    Public Shared GA_Quest As Boolean = False
    Public Shared GA_Tablet As Boolean = False
    Public Shared GA_OreMenu As Boolean = False
    Public Shared GA_Turbo As Boolean = False
    Public Shared GA_DevReload As Boolean = False
    Public Shared GA_Cling As Boolean = False

    Shared CurrentGamepadState As GamePadState
    Shared LastGamepadState As GamePadState
    Public Shared Function GamepadBypass(key As Keys)
        If CurrentGamepadState <> LastGamepadState And CurrentKeyState = LastKeyState Then
            'Triggers
            If GamePad.GetState(PlayerIndex.One).Triggers.Left > 0 Then
                If key = ActionShift Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).Triggers.Right > 0 Then
                If key = ActionTab Then Return True
            End If
            'Small buttons
            If GamePad.GetState(PlayerIndex.One).Buttons.Start = ButtonState.Pressed Then
                If key = ActionTablet Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).Buttons.Back = ButtonState.Pressed Then

            End If
            If GamePad.GetState(PlayerIndex.One).Buttons.BigButton = ButtonState.Pressed Then
                If key = ActionReloadMods Then Return True
            End If
            'Letter Buttons
            If GamePad.GetState(PlayerIndex.One).Buttons.A = ButtonState.Pressed Then
                If key = ActionMenuSel Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).Buttons.B = ButtonState.Pressed Then
                If key = ActionMenuBack Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).Buttons.X = ButtonState.Pressed Then
                If key = ActionQuest Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).Buttons.Y = ButtonState.Pressed Then
                If key = ActionShoot Then Return True
            End If
            'Dpad
            If GamePad.GetState(PlayerIndex.One).DPad.Down = ButtonState.Pressed Then
                If key = ActionDown Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).DPad.Up = ButtonState.Pressed Then
                If key = ActionUp Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).DPad.Left = ButtonState.Pressed Then
                If key = ActionLeft Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).DPad.Right = ButtonState.Pressed Then
                If key = ActionRight Then Return True
            End If
            'Analog Sticks
            If GamePad.GetState(PlayerIndex.One).Buttons.LeftStick = ButtonState.Pressed Then
                If key = ActionCharge Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).Buttons.RightStick = ButtonState.Pressed Then
                If key = ActionMine Then Return True
            End If
            'Shoulders
            If GamePad.GetState(PlayerIndex.One).Buttons.LeftShoulder = ButtonState.Pressed Then
                If key = ActionOres Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).Buttons.RightShoulder = ButtonState.Pressed Then
                If key = ActionSpace Then Return True
            End If
        End If
    End Function
    Public Shared Function GamepadAnalogBypass(key As Keys)
        'Triggers
        If GamePad.GetState(PlayerIndex.One).Triggers.Left > 0 Then
            If key = ActionShift Then Return True
        End If
        'Thunbstick L
        If GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < 0 Then
            If key = ActionLeft Then
                Return True
            End If
        ElseIf GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0 Then
            If key = ActionRight Then
                Return True
            End If
        End If
        If GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0 Then
            If key = ActionUp Then
                Return True
            End If
        ElseIf GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < 0 Then
            If key = ActionDown Then
                Return True
            End If
        End If
        'Thunbstick R
        If GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X < 0 Then
            If key = ActionLeftAlt Then Return True
        ElseIf GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X > 0 Then
            If key = ActionRightAlt Then Return True
        End If
        If GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y > 0 Then
            If key = ActionUpAlt Then Return True
        ElseIf GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y < 0 Then
            If key = ActionDownAlt Then Return True
        End If
        'Dpad backup
        If CurrentGamepadState <> LastGamepadState Then
            If GamePad.GetState(PlayerIndex.One).DPad.Down = ButtonState.Pressed Then
                If key = ActionDown Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).DPad.Up = ButtonState.Pressed Then
                If key = ActionUp Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).DPad.Left = ButtonState.Pressed Then
                If key = ActionLeft Then Return True
            End If
            If GamePad.GetState(PlayerIndex.One).DPad.Right = ButtonState.Pressed Then
                If key = ActionRight Then Return True
            End If
        End If
    End Function
    Public Shared Function ActionMapping(ByVal action As String, Optional ByVal ActGetSet As Integer = 0, Optional ByVal keychg As String = "")
        '0=Action
        '1=Get
        '2=Set
        Select Case ActGetSet
            Case 0
                Select Case action
                    Case "Up"
                        If Input.KeyDown(AscW(ActionUp)) Then

                        End If
                    Case "Down"
                        If Input.KeyDown(AscW(ActionLeft)) Then

                        End If
                    Case "Left"
                        If Input.KeyDown(AscW(ActionDown)) Then

                        End If
                    Case "Right"
                        If Input.KeyDown(AscW(ActionRight)) Then

                        End If
                    Case "Menu Select"
                        If Input.KeyDown(AscW(ActionMenuSel)) Then

                        End If
                    Case "Menu Back"
                        If Input.KeyDown(AscW(ActionMenuBack)) Then

                        End If
                    Case "Quest"
                        If Input.KeyDown(AscW(ActionQuest)) Then

                        End If
                    Case "Tablet"
                        If Input.KeyDown(AscW(ActionTablet)) Then

                        End If
                    Case "Shoot"
                        If Input.KeyDown(AscW(ActionShoot)) Then

                        End If
                    Case "Space"
                        If Input.KeyDown(AscW(ActionSpace)) Then

                        End If
                End Select
            Case 1
                Select Case action
                    Case "Up"
                        Return ActionUp
                    Case "Down"
                        Return ActionLeft
                    Case "Left"
                        Return ActionDown
                    Case "Right"
                        Return ActionRight
                    Case "Menu Select"
                        Return ActionMenuSel
                    Case "Menu Back"
                        Return ActionMenuBack
                    Case "Quest"
                        Return ActionQuest
                    Case "Tablet"
                        Return ActionTablet
                    Case "Shoot"
                        Return ActionShoot
                    Case "Space"
                        Return ActionSpace
                End Select
            Case 2
                Select Case action
                    Case "Up"
                        ActionUp = keychg
                    Case "Down"
                        ActionLeft = keychg
                    Case "Left"
                        ActionDown = keychg
                    Case "Right"
                        ActionRight = keychg
                    Case "Menu Select"
                        ActionMenuSel = keychg
                    Case "Menu Back"
                        ActionMenuBack = keychg
                    Case "Quest"
                        ActionQuest = keychg
                    Case "Tablet"
                        ActionTablet = keychg
                    Case "Shoot"
                        ActionShoot = keychg
                    Case "Space"
                        ActionSpace = keychg
                End Select
        End Select
    End Function
End Class