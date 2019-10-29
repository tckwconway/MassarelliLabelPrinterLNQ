Public Class ItemsToPrintFromItemMaster
    Private mPrnt As Boolean
    Public Property Prnt() As Boolean
        Get
            Return mPrnt
        End Get
        Set(ByVal value As Boolean)
            mPrnt = value
        End Set
    End Property

    Private mSKU As String
    Public Property SKU() As String
        Get
            Return mSKU
        End Get
        Set(ByVal value As String)
            mSKU = value
        End Set
    End Property
    Private mDescription As String
    Public Property Description() As String
        Get
            Return mDescription
        End Get
        Set(ByVal value As String)
            mDescription = value
        End Set
    End Property
    Private mRetail As String
    Public Property Retail() As Decimal
        Get
            Return mRetail
        End Get
        Set(ByVal value As Decimal)
            mRetail = value
        End Set
    End Property

    Private mMfgPart As String
    Public Property MfgPart() As String
        Get
            Return mMfgPart
        End Get
        Set(ByVal value As String)
            mMfgPart = value
        End Set
    End Property

    Private mMfgFinish As String
    Public Property MfgFinish() As String
        Get
            Return mMfgFinish
        End Get
        Set(ByVal value As String)
            mMfgFinish = value
        End Set
    End Property

    Private mQtyOrd As String
    Public Property QtyOrd() As Decimal
        Get
            Return mQtyOrd
        End Get
        Set(ByVal value As Decimal)
            mQtyOrd = value
        End Set
    End Property

    Private mUPC As String
    Public Property UPC() As String
        Get
            Return mUPC
        End Get
        Set(ByVal value As String)
            mUPC = value
        End Set
    End Property

    Public Sub New(ByVal mPrnt As Boolean, mSKU As String, mDescription As String, mRetail As String, ByVal mMfgPart As String, mFinish As String, mQtyOrd As String)
        Prnt = mPrnt
        SKU = mSKU
        Description = mDescription
        Retail = mRetail
        MfgPart = mMfgPart
        MfgFinish = mFinish
        QtyOrd = mQtyOrd
    End Sub
    Public Sub New(ByVal mPrnt As Boolean, mSKU As String, mDescription As String, mRetail As String, ByVal mMfgPart As String, mFinish As String, mQtyOrd As String, mUPC As String)
        Prnt = mPrnt
        SKU = mSKU
        Description = mDescription
        Retail = Convert.ToDouble(IIf(mRetail = "", 0, mRetail))
        MfgPart = mMfgPart
        MfgFinish = mFinish
        QtyOrd = mQtyOrd
        UPC = mUPC
    End Sub

End Class

