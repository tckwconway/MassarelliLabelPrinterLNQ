Public Class OrderObj

    Public OrderNo As String
    Public OrderDt As Integer
    Public CusNo As String
    Public CusAltAdrNo As String
    Public BillToName As String
    Public ShipToName As String
    Public Status As String


    Public Sub New( _
       ByVal mOrderNo As String, _
       ByVal mOrderDt As Integer, _
       ByVal mCusNo As String, _
       ByVal mCusAltAdrNo As String, _
       ByVal mBillToName As String, _
       ByVal mShipToName As String,
       ByVal mStatus As String)
        OrderNo = mOrderNo
        OrderDt = mOrderDt
        mCusNo = CusNo
        CusAltAdrNo = mCusAltAdrNo
        BillToName = mBillToName
        ShipToName = mShipToName
        Status = mStatus
    End Sub
End Class
