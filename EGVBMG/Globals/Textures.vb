Public Class Textures
    'Public Shared texture As Texture2D
    Public Shared Null As Texture2D
    Public Shared SpriteSheet As Texture2D

    Public Shared Sub Load()
        'texture = Globals.Content.Load(Of Texture2D)("GFX/name")
        Null = Globals.Content.Load(Of Texture2D)("menuscreen")
        SpriteSheet = Globals.Content.Load(Of Texture2D)("SpriteSheet")
    End Sub
End Class
