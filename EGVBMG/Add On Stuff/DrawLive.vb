Public Class DrawLive
    Public Shared Scren As RenderTarget2D
    Public Shared freedraw As GraphicsDeviceManager
    Public Shared livedraw As SpriteBatch
    Public Shared tempgfx As Texture2D
    Public Shared Sub Send(tex As Texture2D)
        tempgfx = New Texture2D(freedraw.GraphicsDevice, tex.Width, tex.Height)
        tempgfx = tex
        Scren = New RenderTarget2D(freedraw.GraphicsDevice, tempgfx.Width, tempgfx.Height, False, SurfaceFormat.ColorSRgb, DepthFormat.None)
        freedraw.GraphicsDevice.SetRenderTarget(Scren)
        livedraw = New SpriteBatch(freedraw.GraphicsDevice)
        livedraw.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)
        livedraw.End()
        tex.Dispose()
    End Sub
    Public Shared Sub Modify(tex As Texture2D, ByVal DrawTo As Rectangle, ByVal DrawFrom As Rectangle, ByVal col As Color)
        tempgfx = tex
        livedraw.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)
        livedraw.Draw(tempgfx, DrawTo, DrawFrom, col)
        livedraw.End()
    End Sub
    Public Shared Sub ModifyTrans(tex As Texture2D, ByVal DrawTo As Rectangle, ByVal DrawFrom As Rectangle, ByVal col As Color)
        tempgfx = tex
        Dim Transblend As New BlendState()
        Transblend.ColorBlendFunction = BlendFunction.Add
        Transblend.ColorSourceBlend = Blend.Zero
        Transblend.ColorDestinationBlend = Blend.InverseSourceAlpha

        Transblend.AlphaBlendFunction = BlendFunction.Add
        Transblend.AlphaSourceBlend = Blend.Zero
        Transblend.AlphaDestinationBlend = Blend.InverseSourceAlpha

        livedraw.Begin(SpriteSortMode.Immediate, Transblend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)
        livedraw.Draw(tempgfx, DrawTo, DrawFrom, Color.White)
        livedraw.End()
    End Sub
    'Modify Transparent Custom is for non integer alpha values (50% opacity)
    Public Shared Sub ModifyTransCust(tex As Texture2D, ByVal DrawTo As Rectangle, ByVal DrawFrom As Rectangle, ByVal col As Color)
        tempgfx = tex
        Dim Transblend As New BlendState()
        Transblend.ColorBlendFunction = BlendFunction.Add
        Transblend.ColorSourceBlend = Blend.Zero
        Transblend.ColorDestinationBlend = Blend.InverseSourceAlpha

        Transblend.AlphaBlendFunction = BlendFunction.Add
        Transblend.AlphaSourceBlend = Blend.Zero
        Transblend.AlphaDestinationBlend = Blend.InverseSourceAlpha

        livedraw.Begin(SpriteSortMode.Immediate, Transblend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)
        livedraw.Draw(tempgfx, DrawTo, DrawFrom, col)
        livedraw.End()
    End Sub
    Public Shared PermGFX As Texture2D
    Public Shared Function Retrieve(colo As Color) As Texture2D
        freedraw.GraphicsDevice.SetRenderTarget(Nothing)
        PermGFX = Scren
        Return PermGFX
        Scren.Dispose()
        livedraw.Dispose()
        PermGFX.Dispose()
        freedraw.Dispose()
        tempgfx.Dispose()
        PermGFX.Dispose()
    End Function
    Public Shared Function Transparancy(ByVal td2 As Texture2D, ByVal col As Color) As Texture2D
        Dim colo(td2.Width * td2.Height - 1) As Color
        td2.GetData(Of Color)(colo)
        For q As Integer = 0 To colo.Length - 1
            If colo(q) = col Then
                colo(q) = Nothing
            End If
        Next
        td2.SetData(Of Color)(colo)
        Return td2
    End Function
End Class