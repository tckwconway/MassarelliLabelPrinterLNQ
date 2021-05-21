Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Collections

Public Class GetExcelData

    Public Function GetDataFromExcel(ByVal FileName As String, _
                                     ByVal SheetName As String, ByVal RangeName As String, _
                                     ByVal ImportType As String, ByVal WhseID As String) As DataSet
        ' Returns a DataSet containing information from a named range
        ' from the Excel worksheet

        Try
            Dim strConn As String = _
                "Provider=Microsoft.Jet.OLEDB.4.0;" & _
                "Data Source=" & FileName & "; Extended Properties=Excel 8.0;"
            Dim oCn _
                As New System.Data.OleDb.OleDbConnection(strConn)
            oCn.Open()
            ' Create oects ready to grab data
            Dim oCmd As New System.Data.OleDb.OleDbCommand( _
                "SELECT * FROM [" & SheetName & RangeName & "]", oCn)
            Dim oDA As New System.Data.OleDb.OleDbDataAdapter()
            oDA.SelectCommand = oCmd

            ' Fill DataSet
            Dim oDS As New DataSet()
            oDA.Fill(oDS)
            Return oDS

        Catch

            MsgBox(Err.Description)
            'MsgBox("STOP")
            Return Nothing
            Exit Function
        End Try

    End Function
    Public Function GetDataFromExcel(ByVal FileName As String, _
                                     ByVal SheetName As String, ByVal RangeName As String) As DataSet
        ' Returns a DataSet containing information from a named range
        ' from the Excel worksheet
        Dim ExcelVersion As String
        Dim SQL As String
        If Right(FileName, 1) = "x" Then
            ExcelVersion = "xlsx"
        Else
            ExcelVersion = "xls"
        End If
        'FileName = FileName & "$"
        ' MsgBox("START: Open xls connection")
        Try
            Dim strConn As String
            If ExcelVersion = "xls" Then
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & FileName & ";Extended Properties=""Excel 8.0;IMEX=1;"""
                SQL = "SELECT * FROM [" & SheetName & "$" & RangeName & "]"
            Else
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & FileName & ";Extended Properties=""Excel 12.0;HDR=YES;"""
                SQL = "SELECT * FROM [" & SheetName & "$]"
                'strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & FileName & ";Extended Properties=""Excel 12.0;HDR=YES;"""
            End If

            Dim oCn _
                As New System.Data.OleDb.OleDbConnection(strConn)

            oCn.Open()

            'MsgBox("END: Open xls connection")

            ' Create oects ready to grab data

            Dim oCmd As New System.Data.OleDb.OleDbCommand( _
               SQL, oCn)
            Dim oDA As New System.Data.OleDb.OleDbDataAdapter()
            oDA.SelectCommand = oCmd

            ' MsgBox("START: Fill Dataset")

            ' Fill DataSet
            Dim oDS As New DataSet()
            oDS.Tables.Add("MasterPriceList")
            Dim dt As DataTable = oDS.Tables(0)
            dt.Columns.Add("SKU", GetType(String))
            dt.Columns.Add("Description", GetType(String))
            dt.Columns.Add("Retail", GetType(String))
            dt.Columns.Add("MfgItemNo", GetType(String))
            dt.Columns.Add("MfgFinishNo", GetType(String))
            dt.Columns.Add("UPC", GetType(String))
            oDA.Fill(oDS, "MasterPriceList")

            'MsgBox("END: Fill Dataset")


            Return oDS




            'Dim oDS As New DataSet()
            'oDA.Fill(oDS)

            'Return oDS

        Catch

            MsgBox(Err.Description)
            'MsgBox("STOP")
            Return Nothing
            Exit Function
        End Try

    End Function
    Private Sub IsValid()
        '' '' ''Or FilePath = "" ---Or FileName = ""
        ' '' ''If Range = "" Or CompanyCode = "" Or _
        ' '' ''ImportType = "" Or SQLDatabase = "" Or MissingDataGrid = True Or IsImporting = True Then
        ' '' ''    Validate = False
        ' '' ''Else
        ' '' ''    Validate = True
        ' '' ''End If
        Validate = True
    End Sub
    Private m_DSExcel As System.Data.DataSet

    Public Property DSExcel() As System.Data.DataSet
        Get
            Return m_DSExcel
        End Get
        Set(ByVal value As System.Data.DataSet)
            m_DSExcel = value
        End Set
    End Property
    Private m_DSExcelValidate As System.Data.DataSet

    Public Property DSExcelValidate() As System.Data.DataSet
        Get
            Return m_DSExcelValidate
        End Get
        Set(ByVal value As System.Data.DataSet)
            m_DSExcelValidate = value
        End Set
    End Property
    Private m_CustKey As Integer
    Public Property Key_Cust() As Integer
        Get
            Return m_CustKey
        End Get
        Set(ByVal value As Integer)
            m_CustKey = value
        End Set
    End Property
    Private m_NationalAcctKey As Integer
    Public Property Key_NationalAcct() As Integer
        Get
            Return m_NationalAcctKey
        End Get
        Set(ByVal value As Integer)
            m_NationalAcctKey = value
        End Set
    End Property
    Private m_NatAcctItemPriceKey As Integer
    Public Property Key_NatAcctItemPrice() As Integer
        Get
            Return m_NatAcctItemPriceKey
        End Get
        Set(ByVal value As Integer)
            m_NatAcctItemPriceKey = value
        End Set
    End Property

    Private m_CustAddrKey As Integer
    Public Property Key_CustAddr() As Integer
        Get
            Return m_CustAddrKey
        End Get
        Set(ByVal value As Integer)
            m_CustAddrKey = value
        End Set
    End Property

    Private m_ItemKey As Integer
    Public Property Key_Item() As Integer
        Get
            Return m_ItemKey
        End Get
        Set(ByVal value As Integer)
            m_ItemKey = value
        End Set
    End Property
    Private m_WhseKey As Integer
    Public Property Key_Whse() As Integer
        Get
            Return m_WhseKey
        End Get
        Set(ByVal value As Integer)
            m_WhseKey = value
        End Set
    End Property
    Private m_PricingKey As Integer
    Public Property Key_Pricing() As Integer
        Get
            Return m_PricingKey
        End Get
        Set(ByVal value As Integer)
            m_PricingKey = value
        End Set
    End Property
    Private m_CustItemPriceKey As Integer
    Public Property Key_CustItemPrice() As Integer
        Get
            Return m_CustItemPriceKey
        End Get
        Set(ByVal value As Integer)
            m_CustItemPriceKey = value
        End Set
    End Property
    Private m_CustProdGrpPrcKey As Integer
    Public Property Key_CustProdGrpPrc() As Integer
        Get
            Return m_CustProdGrpPrcKey
        End Get
        Set(ByVal value As Integer)
            m_CustProdGrpPrcKey = value
        End Set
    End Property
    Private m_Key_ProdPriceGroup As Integer
    Public Property Key_ProdPriceGroup() As Integer
        Get
            Return m_Key_ProdPriceGroup
        End Get
        Set(ByVal value As Integer)
            m_Key_ProdPriceGroup = value
        End Set
    End Property
    Private m_Key_ProdPriceGroupPrice As Integer
    Public Property Key_ProdPriceGroupPrice() As Integer
        Get
            Return m_Key_ProdPriceGroupPrice
        End Get
        Set(ByVal value As Integer)
            m_Key_ProdPriceGroupPrice = value
        End Set
    End Property

    Private m_FilePath As String
    Public Property FilePath() As String
        Get
            Return m_FilePath
        End Get
        Set(ByVal value As String)
            'If Right(value, 1) = "\" Then
            '    m_FilePath = value
            'Else
            m_FilePath = value
            'End If
            'IsValid()
        End Set
    End Property
    Private m_CompanyCode As String
    Public Property CompanyCode() As String
        Get
            Return m_CompanyCode
        End Get
        Set(ByVal value As String)
            m_CompanyCode = value
            IsValid()
        End Set
    End Property

    Private m_Range As String
    Public Property Range() As String
        Get
            Return m_Range
        End Get
        Set(ByVal value As String)
            m_Range = value
            IsValid()
        End Set
    End Property
    Private m_ImportType As String
    Public Property ImportType() As String
        Get
            Return m_ImportType
        End Get
        Set(ByVal value As String)

            m_ImportType = value
            IsValid()
        End Set
    End Property
    Private m_bEnableExcelBtn As Boolean
    Public Property bEnableExcelBtn() As Boolean
        Get
            IsValid()
            Return m_bEnableExcelBtn
        End Get
        Set(ByVal value As Boolean)
            m_bEnableExcelBtn = value
        End Set
    End Property
    Private bValidate As Boolean
    Public Property Validate() As Boolean
        Get
            Return bValidate
        End Get
        Set(ByVal value As Boolean)
            bValidate = value
        End Set
    End Property
    Private m_SQLDatabase As String
    Public Property SQLDatabase() As String
        Get
            Return m_SQLDatabase
        End Get
        Set(ByVal value As String)
            m_SQLDatabase = value
            IsValid()
        End Set
    End Property

    Private sConnectionString As String
    Public Property ConnectionString() As String
        Get
            Return sConnectionString
        End Get
        Set(ByVal value As String)
            sConnectionString = value
        End Set
    End Property
    Private sFileName As String
    Public Property FileName() As String
        Get
            Return sFileName
        End Get
        Set(ByVal value As String)
            If Right(value, 4) = ".xls" Then
                sFileName = value
            Else
                sFileName = value & ".xls"
            End If
            IsValid()
        End Set
    End Property

    Private dsWarehouses As DataSet
    Public Property DSWarehouse() As DataSet
        Get
            Return dsWarehouses
        End Get
        Set(ByVal value As DataSet)
            dsWarehouses = value
        End Set
    End Property
    Private sWhseID As String
    Public Property WhseID() As String
        Get
            Return sWhseID
        End Get
        Set(ByVal value As String)
            sWhseID = value
        End Set
    End Property
    Private sWarehouse_CASE As String
    Public Property Warehouse_CASE() As String
        Get
            Return sWarehouse_CASE
        End Get
        Set(ByVal value As String)
            sWarehouse_CASE = value
        End Set
    End Property
    Private sWarehouseCount As String
    Public Property WarehouseCount() As String
        Get
            Return sWarehouseCount
        End Get
        Set(ByVal value As String)
            sWarehouseCount = value
        End Set
    End Property
    Private iKeyFromImport As Integer
    Public Property KeyFromImport() As Integer
        Get
            Return iKeyFromImport
        End Get
        Set(ByVal value As Integer)
            iKeyFromImport = value
        End Set
    End Property
    Private bIsImporting As Boolean
    Public Property IsImporting() As Boolean
        Get
            Return bIsImporting
        End Get
        Set(ByVal value As Boolean)
            bIsImporting = value
            If value = True Then
                ComboEnabled = False
            Else
                ComboEnabled = True
            End If
        End Set
    End Property
    Private bComboEnabled As Boolean
    Public Property ComboEnabled() As Boolean
        Get
            Return bComboEnabled
        End Get
        Set(ByVal value As Boolean)
            bComboEnabled = value
        End Set
    End Property
    Private m_CustPriceGroupKey As Integer
    Public Property Key_CustPriceGroup() As Integer
        Get
            Return m_CustPriceGroupKey
        End Get
        Set(ByVal value As Integer)
            m_CustPriceGroupKey = value
        End Set
    End Property
    Private m_ItemPriceKey As Integer
    Public Property Key_ItemPrice() As Integer
        Get
            Return m_ItemPriceKey
        End Get
        Set(ByVal value As Integer)
            m_ItemPriceKey = value
        End Set
    End Property
    Private sSQLLogin As String
    Public Property SQLLogin() As String
        Get
            Return sSQLLogin
        End Get
        Set(ByVal value As String)
            sSQLLogin = value
        End Set
    End Property
    Private sSQLPassword As String
    Public Property SQLPassword() As String
        Get
            Return sSQLPassword
        End Get
        Set(ByVal value As String)
            sSQLPassword = value
        End Set
    End Property
    Private sSQLServer As String
    Public Property SQLServer() As String
        Get
            Return sSQLServer
        End Get
        Set(ByVal value As String)
            sSQLServer = value
        End Set
    End Property
    Private sMissingDataTable As DataTable
    Public Property MissingDataTable() As DataTable
        Get
            Return sMissingDataTable
        End Get
        Set(ByVal value As DataTable)
            sMissingDataTable = value
        End Set
    End Property

    Private mExcelDupeDataTable As DataTable
    Public Property ExcelDupeDataTable() As DataTable
        Get
            Return mExcelDupeDataTable
        End Get
        Set(ByVal value As DataTable)
            mExcelDupeDataTable = value
        End Set
    End Property

    Private mValidateData As DataTable
    Public Property ValidateData() As DataTable
        Get
            Return mValidateData
        End Get
        Set(ByVal value As DataTable)
            mValidateData = value
        End Set
    End Property

    Private oReturned As Object
    Public Property Returned() As Object
        Get
            Return oReturned
        End Get
        Set(ByVal value As Object)
            oReturned = value
        End Set
    End Property
    Private bIsMissing As Boolean
    Public Property IsMissing() As Boolean
        Get
            Return bIsMissing
        End Get
        Set(ByVal value As Boolean)
            bIsMissing = value
        End Set
    End Property
    Private bMissingDataGrid As Boolean
    Public Property MissingDataGrid() As Boolean
        Get
            Return bMissingDataGrid
        End Get
        Set(ByVal value As Boolean)
            bMissingDataGrid = value
        End Set
    End Property

    Private mUseWindowsAuthentication As Boolean
    Public Property UseWindowsAuthentication() As Boolean
        Get
            Return mUseWindowsAuthentication
        End Get
        Set(ByVal value As Boolean)
            mUseWindowsAuthentication = value
        End Set
    End Property

    Private mImportSuccessful As DataTable
    Public Property ImportSuccessful() As DataTable
        Get
            Return mImportSuccessful
        End Get
        Set(ByVal value As DataTable)
            mImportSuccessful = value
        End Set
    End Property

    Private mImportFail As DataTable
    Public Property ImportFail() As DataTable
        Get
            Return mImportFail
        End Get
        Set(ByVal value As DataTable)
            mImportFail = value
        End Set
    End Property

End Class
