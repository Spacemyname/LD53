Public Class ScriptGrabber
    Public Shared Workingdoc() As String
    Public Shared Sub Init(language As Integer)
        IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\content")
        IO.File.Create(My.Application.Info.DirectoryPath & "\content\Script_English.txt").Dispose()
        IO.File.WriteAllText(My.Application.Info.DirectoryPath & "\content\Script_English.txt", scripteng)
        Select Case language
            Case 0
                Workingdoc = IO.File.ReadAllLines(My.Application.Info.DirectoryPath & "\content\Script_English.txt")
            Case 1
                Workingdoc = IO.File.ReadAllLines(My.Application.Info.DirectoryPath & "\content\Script_Spanish.txt")
            Case Else
                Workingdoc = IO.File.ReadAllLines(My.Application.Info.DirectoryPath & "\content\Script_English.txt")
        End Select
    End Sub
    Public Shared Function GrabText(line As Integer)
        Dim rts As String = Workingdoc(line)
        Return rts
    End Function

    Public Shared scripteng As String = "NOTICE!
This game is actively in development!
Join our community and share your feedback!
More info in the Options Menu
Start New Game
Continue Game
Options
Credits
Quit Game
Version

"
End Class