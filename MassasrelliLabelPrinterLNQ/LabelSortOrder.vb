Public Class LabelSortOrder

    Private mColumn As String
    Public Property Column() As String
        Get
            Return mColumn
        End Get
        Set(ByVal value As String)
            mColumn = value
        End Set
    End Property


    Public Sub New(ByVal mcolumn As String)
        column = mcolumn
    End Sub

End Class
