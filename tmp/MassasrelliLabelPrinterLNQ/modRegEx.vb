Imports System.Text.RegularExpressions

Module modRegEx
    Public Function RegExStripCharacters(ByVal input As String) As String
        Dim output As String

        output = Regex.Replace(input, "[a-zA-Z]", "")

        Return output
    End Function
End Module
