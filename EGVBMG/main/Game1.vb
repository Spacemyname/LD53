Public Class Game1
    'A lot of the code found here was made by Aardaerimus D'Aritonyss, I simply followed his tutorials to get started but added my own code snippets to the engine
    Inherits Microsoft.Xna.Framework.Game
    Private ScreenManager As ScreenManager
    Public Sub New()
        Globals.Graphics = New GraphicsDeviceManager(Me)
        Content.RootDirectory = "Content"
    End Sub
    Public Shared Change As Boolean = False
    Public Sub Synch()
        If Globals.Graphics.SynchronizeWithVerticalRetrace = True Then
            Globals.Graphics.SynchronizeWithVerticalRetrace = False
            Me.IsFixedTimeStep = False
        Else
            Globals.Graphics.SynchronizeWithVerticalRetrace = True
            Me.IsFixedTimeStep = True
        End If
        Globals.Graphics.ApplyChanges()
    End Sub
    Protected Overrides Sub Initialize()
        Me.IsMouseVisible = True
        Window.AllowUserResizing = False
        Globals.GameSize = New Vector2(1920, 1080)
        Globals.Graphics.PreferredBackBufferWidth = Globals.GameSize.X
        Globals.Graphics.PreferredBackBufferHeight = Globals.GameSize.Y
        Globals.Graphics.ApplyChanges()
        Globals.BackBuffer = New RenderTarget2D(Globals.Graphics.GraphicsDevice, Globals.GameSize.X, Globals.GameSize.Y, False, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.PreserveContents)
        MyBase.Initialize()
        Globals.Graphics.SynchronizeWithVerticalRetrace = True
        Me.IsFixedTimeStep = True
        Globals.Graphics.ApplyChanges()
        Globals.Debugging = False
        ScriptGrabber.Init(0)
        Mouse.SetCursor(MouseCursor.Crosshair)
        Window.Title = GameVersion.Name
    End Sub
    Protected Overrides Sub LoadContent()
        Globals.SpriteBatch = New SpriteBatch(GraphicsDevice)
        Globals.Content = Me.Content
        Fonts.Load()
        Textures.Load()
        Sounds.Load()
        Shaders.Load()
        ScreenManager = New ScreenManager()
        ScreenManager.AddScreen(New Speech)
        'ScreenManager.AddScreen(New MainMenu)
    End Sub
    Private AniTime As Double = 0
    Private KeyTime As Double = 0
    Private DTpass As Double = 0
    Public Shared Aminate As Integer = 0
    Protected Overrides Sub Update(ByVal gameTime As GameTime)
        MyBase.Update(gameTime)
        Globals.GameTime = gameTime
        DTpass = Globals.GameTime.ElapsedGameTime.TotalMilliseconds
        KeyTime += DTpass
        AniTime += DTpass
        If KeyTime > (1.0F / 180.0F) Then
            KeyTime = 0
            Globals.WindowFocused = Me.IsActive
            If Change Then
                Synch()
                Change = False
            End If
            ScreenManager.Update()
            Input.Update()
        End If
        If AniTime > 20 Then
            AniTime = 0
            Aminate += 1
            If Aminate > 255 Then Aminate = 0
            Globals.GameSize = New Vector2(Globals.Graphics.PreferredBackBufferWidth, Globals.Graphics.PreferredBackBufferHeight)
        End If
    End Sub
    Public Shared SSM As SpriteSortMode = SpriteSortMode.Immediate
    Public Shared BlS As BlendState = BlendState.AlphaBlend
    Public Shared SmS As SamplerState = SamplerState.PointClamp
    Public Shared DSS As DepthStencilState = DepthStencilState.Default
    Public Shared RrS As RasterizerState = RasterizerState.CullNone
    Public Shared SpE As Effect = Nothing
    Protected Overrides Sub Draw(ByVal gameTime As GameTime)
        GraphicsDevice.Clear(Color.Black)
        MyBase.Draw(gameTime)
        Globals.SpriteBatch.Begin(SSM, BlS, SmS, DSS, RrS, SpE)
        ScreenManager.Draw()
        Globals.SpriteBatch.End()
    End Sub
End Class
