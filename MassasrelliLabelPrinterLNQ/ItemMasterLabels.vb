Public Class ItemsToPrintFromItemMaster


    Private mItemNo As String
    Public Property ItemNo() As String
        Get
            Return mItemNo
        End Get
        Set(ByVal value As String)
            mItemNo = value
        End Set
    End Property

    Private mFinish As String
    Public Property Finish() As String
        Get
            Return mFinish
        End Get
        Set(ByVal value As String)
            mFinish = value
        End Set
    End Property

    Private mQty As String
    Public Property Qty() As String
        Get
            Return mQty
        End Get
        Set(ByVal value As String)
            mQty = value
        End Set
    End Property

    Public Sub New(ByVal mItemNo As String, mFinish As String, mQty As String)
        ItemNo = mItemNo
        Finish = mFinish
        Qty = mQty
    End Sub

End Class

