Public Class Item
    Implements IEquatable(Of Item)

    Public item As Object
    Public jobNumber As String
    Public site As String
    Public jobType As jobTypes
    Public shipDocFound As Boolean

    Public Sub New(item As Object, jobNumber As String)
        MyClass.item = item
        MyClass.jobNumber = jobNumber
    End Sub

    'Custom compare so when adding new jobs, using List.Contains will not check hash but check the job numbers
    Public Overloads Function Equals(other As Item) As Boolean Implements IEquatable(Of Item).Equals
        If other Is Nothing Then
            Return False
        End If
        Return Me.jobNumber = other.jobNumber
    End Function
End Class