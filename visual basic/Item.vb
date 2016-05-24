Imports Microsoft.Office.Interop

Public Class Item
    Implements IComparable

    'unique identifier, the number for the job
    Public Property jobNumber As String
    'the outlook object that stores all data about the email
    Public Property item As Outlook.MailItem
    'the outlook object that stores all data about the calendar appointment
    Public WithEvents appointment As Outlook.AppointmentItem
    'the location the job took place
    Public Property site As String
    'enum of job type, either foodstuffs, lotto or other
    Public Property jobType As jobTypes
    'whether or not a associated shipping document was downloaded for this job
    Public Property shipDocFound As Boolean

    'constructor
    Public Sub New(_item As Object, _jobNumber As String)
        item = _item
        jobNumber = _jobNumber
    End Sub

    'Custom compare so when adding new jobs, using List.Contains will not check hash but check the job numbers
    Overrides Function Equals(obj As Object) As Boolean
        If Not obj Is Nothing AndAlso obj.GetType() Is GetType(Item) Then
            Return obj.jobNumber = jobNumber
        End If
        Return False
    End Function

    'orders jobs based on job number, earlier jobs first
    Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        Try
            Return Integer.Parse(jobNumber.Substring(2)).CompareTo(Integer.Parse(obj.jobNumber.Substring(2)))
        Catch
            Return 0
        End Try
    End Function

    Public Overrides Function ToString() As String
        If Not String.IsNullOrEmpty(appointment.Subject) Then Return appointment.Subject
        If Not String.IsNullOrEmpty(item.Subject) Then Return item.Subject
        Return jobNumber
    End Function

    Private Sub appointment_close(Cancel As Boolean)

        MsgBox(" The item was saved.")
    End Sub
End Class