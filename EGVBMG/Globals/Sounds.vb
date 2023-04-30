Public Class Sounds
    'Public Shared sound As SoundEffect
    Public Shared Ding As SoundEffect
    Public Shared Click As SoundEffect
    Public Shared A As SoundEffect
    Public Shared B As SoundEffect
    Public Shared C As SoundEffect
    Public Shared D As SoundEffect
    Public Shared E As SoundEffect
    Public Shared F As SoundEffect
    Public Shared G As SoundEffect
    Public Shared H As SoundEffect
    Public Shared I As SoundEffect
    Public Shared J As SoundEffect
    Public Shared K As SoundEffect
    Public Shared L As SoundEffect
    Public Shared M As SoundEffect
    Public Shared N As SoundEffect
    Public Shared O As SoundEffect
    Public Shared P As SoundEffect
    Public Shared Q As SoundEffect
    Public Shared R As SoundEffect
    Public Shared S As SoundEffect
    Public Shared T As SoundEffect
    Public Shared U As SoundEffect
    Public Shared V As SoundEffect
    Public Shared W As SoundEffect
    Public Shared X As SoundEffect
    Public Shared Y As SoundEffect
    Public Shared Z As SoundEffect

    Public Shared BP As SoundEffect
    Public Shared HW As SoundEffect
    Public Shared HZ As SoundEffect
    Public Shared RR As SoundEffect
    Public Shared XH As SoundEffect

    'Public Shared sound_ as soundeffectinstance 'This part is needed for being able to use the effect multiple times/layered
    Public Shared Sub Load()
        Ding = Globals.Content.Load(Of SoundEffect)("Ding")
        Click = Globals.Content.Load(Of SoundEffect)("Click")
        A = Globals.Content.Load(Of SoundEffect)("A")
        B = Globals.Content.Load(Of SoundEffect)("B")
        C = Globals.Content.Load(Of SoundEffect)("C")
        D = Globals.Content.Load(Of SoundEffect)("D")
        E = Globals.Content.Load(Of SoundEffect)("E")
        F = Globals.Content.Load(Of SoundEffect)("F")
        G = Globals.Content.Load(Of SoundEffect)("G")
        H = Globals.Content.Load(Of SoundEffect)("H")
        I = Globals.Content.Load(Of SoundEffect)("I")
        J = Globals.Content.Load(Of SoundEffect)("J")
        K = Globals.Content.Load(Of SoundEffect)("K")
        L = Globals.Content.Load(Of SoundEffect)("L")
        M = Globals.Content.Load(Of SoundEffect)("M")
        N = Globals.Content.Load(Of SoundEffect)("N")
        O = Globals.Content.Load(Of SoundEffect)("O")
        P = Globals.Content.Load(Of SoundEffect)("P")
        Q = Globals.Content.Load(Of SoundEffect)("Q")
        R = Globals.Content.Load(Of SoundEffect)("R")
        S = Globals.Content.Load(Of SoundEffect)("S")
        T = Globals.Content.Load(Of SoundEffect)("T")
        U = Globals.Content.Load(Of SoundEffect)("U")
        V = Globals.Content.Load(Of SoundEffect)("V")
        W = Globals.Content.Load(Of SoundEffect)("W")
        X = Globals.Content.Load(Of SoundEffect)("X")
        Y = Globals.Content.Load(Of SoundEffect)("Y")
        Z = Globals.Content.Load(Of SoundEffect)("Z")

        BP = Globals.Content.Load(Of SoundEffect)("BP")
        HW = Globals.Content.Load(Of SoundEffect)("HW")
        HZ = Globals.Content.Load(Of SoundEffect)("HZ")
        RR = Globals.Content.Load(Of SoundEffect)("RR")
        XH = Globals.Content.Load(Of SoundEffect)("XH")

    End Sub
    Public Shared Sub Volume()
        'Abandoned.Volume = PlayerSettings.Music / 100
        'Music2.Volume = PlayerSettings.Music / 100
        'Music3.Volume = PlayerSettings.Music / 100
    End Sub
    Public Shared Sub SwitchSong(PlayTrack As Integer)
        'Abandoned.Stop
        'Music2.Stop
        'Music3.Stop
        Select Case PlayTrack
            Case 0

        End Select
    End Sub
    Public Shared Sub KillSFX()
        'Abandoned.Stop
        'Music2.Stop
        'Music3.Stop
    End Sub
End Class