Imports System.Data.SqlClient
Public Class BusObj

    Public Shared Function ExecuteSQLDataTable(ByVal sql As String, ByVal tablename As String, ByVal cn As SqlConnection) As DataTable
        Dim dt As DataTable

        dt = DAC.ExecuteSQL_DataTable(sql, cn, tablename)
        Return dt

    End Function

    Public Shared Function ExecuteSQLScalar(sql As String, cn As SqlConnection) As Object

        Dim o As Object
        o = DAC.Execute_Scalar(sql, cn)
        Return o

    End Function

    Public Shared Sub Execute_NonSQL(ssql, cn)
        DAC.Execute_NonSQL(ssql, cn)
    End Sub

    'Public Shared Function Execute_SP_GetMissingItems(ord_no As String, cn As SqlConnection) As DataTable
    '    'Dim dt As DataTable = _
    '    '    DAC.ExecuteSP_DataTable(My.Resources.SP_spIMLabelGetMissingItems_MAS, cn, _
    '    '                            DAC.Parameter(My.Resources.PARAM_iord_no, ord_no, ParameterDirection.Input))
    '    'Return dt
    'End Function

    Public Shared Function Execute_SP_GetMissingItemsfromOE(ord_no As String, dtTVP As DataTable, cn As SqlConnection) As DataTable

        Dim dt As DataTable = DAC.ExecuteSP_MissingItems_DataTable(My.Resources.SP_spIMLabelGetMissingItemsfromOE_MAS, cn, _
                                                                   "@iord_no", ord_no, _
                                                                   dtTVP, "@imissing_data")

        Return dt

    End Function

End Class
