Imports System.Text.RegularExpressions

Public Class ImportSettingsObj

    Private mExcelSheetName As String
    Public Property ExcelSheetName() As String
        Get
            Return mExcelSheetName
        End Get
        Set(ByVal value As String)
            mExcelSheetName = value
        End Set
    End Property

    Private mExecelRangeStart As String
    Public Property ExecelRangeStart() As String
        Get
            Return mExecelRangeStart
        End Get
        Set(ByVal value As String)
            mExecelRangeStart = value
            ExcelRangeStartNumber = CInt(modRegEx.RegExStripCharacters(value))
        End Set
    End Property

    Private mExecelRangeEnd As String
    Public Property ExecelRangeEnd() As String
        Get
            Return mExecelRangeEnd
        End Get
        Set(ByVal value As String)
            mExecelRangeEnd = value

        End Set
    End Property

    Private mExcelRangeStartNumber As Integer
    Public Property ExcelRangeStartNumber() As Integer
        Get
            Return mExcelRangeStartNumber
        End Get
        Set(ByVal value As Integer)
            mExcelRangeStartNumber = value
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

    Private mImportWarehouse As String
    Public Property ImportWarehouse() As String
        Get
            Return mImportWarehouse
        End Get
        Set(ByVal value As String)
            mImportWarehouse = value
        End Set
    End Property

    Private mImportCompanyID As String
    Public Property ImportCompanyID() As String
        Get
            Return mImportCompanyID
        End Get
        Set(ByVal value As String)
            mImportCompanyID = value
        End Set
    End Property


    'Private mTempTable_Keys As String
    'Public Property TempTable_Keys() As String
    '    Get
    '        Return mTempTable_Keys
    '    End Get
    '    Set(ByVal value As String)
    '        mTempTable_Keys = value
    '    End Set
    'End Property

    'Private mTempTableExcel As String
    'Public Property TempTableExcel() As String
    '    Get
    '        Return mTempTableExcel
    '    End Get
    '    Set(ByVal value As String)
    '        mTempTableExcel = value
    '    End Set
    'End Property

End Class
