Imports System.Runtime.CompilerServices

Public Module StringExtensions

    <Extension()>
    Public Function ContainsIgnoreCase(ByVal source As String, ByVal value As String) As Boolean
        Return source.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0
    End Function

End Module