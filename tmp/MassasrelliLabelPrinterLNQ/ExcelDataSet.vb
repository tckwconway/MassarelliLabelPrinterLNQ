Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Collections

Module ExcelDataSet
    Private mXLDataset As DataSet
    Public Property XLDataset() As DataSet
        Get
            Return mXLDataset
        End Get
        Set(ByVal value As DataSet)
            mXLDataset = value
        End Set
    End Property
    Private mOrderItemDataset As DataSet
    Public Property OrderItemDataset() As DataSet
        Get
            Return mOrderItemDataset
        End Get
        Set(ByVal value As DataSet)
            mOrderItemDataset = value
        End Set
    End Property
    Private mLabelDataTable As DataTable
    Public Property LabelDataTable() As DataTable
        Get
            Return mLabelDataTable
        End Get
        Set(ByVal value As DataTable)
            mLabelDataTable = value
        End Set
    End Property

    Private mXLFileName As String
    Public Property XLFileName() As String
        Get
            Return mXLFileName
        End Get
        Set(ByVal value As String)
            mXLFileName = value
        End Set
    End Property

    Private mShowHide As String
    Public Property ShowHide() As String
        Get
            Return mShowHide
        End Get
        Set(ByVal value As String)
            mShowHide = value
        End Set
    End Property
    Private mOrderNo As String
    Public Property OrderNo() As String
        Get
            Return mOrderNo
        End Get
        Set(ByVal value As String)
            mOrderNo = ("00000000" & value).ToString.Substring(("00000000" & value).Length - 8)
        End Set
    End Property
    Private mDataSourcePathFile As String
    Public Property LabelDataSourcePathFile() As String
        Get
            Return mDataSourcePathFile
        End Get
        Set(ByVal value As String)
            mDataSourcePathFile = value
        End Set
    End Property
    Private mPrinterName As String
    Public Property PrinterName() As String
        Get
            Return mPrinterName
        End Get
        Set(ByVal value As String)
            mPrinterName = value
        End Set
    End Property
    Private mPrintType As String
    Public Property PrintType() As String
        Get
            Return mPrintType
        End Get
        Set(ByVal value As String)
            mPrintType = value
        End Set
    End Property
    Private mBTLabelPathFileName As String
    Public Property BTLabelPathFileName() As String
        Get
            Return mBTLabelPathFileName
        End Get
        Set(ByVal value As String)
            mBTLabelPathFileName = value
        End Set
    End Property
    Private mIsLoading As Boolean
    Public Property IsLoading() As Boolean
        Get
            Return mIsLoading
        End Get
        Set(ByVal value As Boolean)
            mIsLoading = value
        End Set
    End Property
    Private mMissingDataTable As DataTable
    Public Property MissingDataTable() As DataTable
        Get
            Return mMissingDataTable
        End Get
        Set(ByVal value As DataTable)
            mMissingDataTable = value
        End Set
    End Property
    Private mImportType As String
    Public Property ImportType() As String
        Get
            Return mImportType
        End Get
        Set(ByVal value As String)
            mImportType = value
        End Set
    End Property

End Module
