Public Class Item

    Public item As Object
    Public jobNumber As String

    Public site As String
    Public fs As Boolean

    Public Sub New(item As Object, jobNumber As String)
        MyClass.item = item
        MyClass.jobNumber = jobNumber
    End Sub

End Class
