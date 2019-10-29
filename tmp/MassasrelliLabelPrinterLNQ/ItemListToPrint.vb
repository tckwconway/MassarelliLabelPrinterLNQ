Public Class ItemListToPrint

    Private mItemNo As String
    Public Property ItemNo() As String
        Get
            Return mItemNo
        End Get
        Set(ByVal value As String)
            mItemNo = value
        End Set
    End Property
    Private mItemDesc As String
    Public Property ItemDesc() As String
        Get
            Return mItemDesc
        End Get
        Set(ByVal value As String)
            mItemDesc = value
        End Set
    End Property

    Public Sub New(ByVal mItemNo As String, ByVal mItemDesc As String)
        ItemNo = mItemNo
        ItemDesc = mItemDesc
    End Sub

End Class

