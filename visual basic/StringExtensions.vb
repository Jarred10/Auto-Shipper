Imports System.Runtime.CompilerServices

Public Module StringExtensions

    <Extension()>
    Public Function Contains(ByVal source As String,
                             ByVal value As String,
                             ByVal comparisonType As StringComparison) As Boolean
        Return source.IndexOf(value, comparisonType) >= 0
    End Function

End Module
