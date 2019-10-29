Imports System.Environment
Imports System.Data.SqlClient

Module MacolaStartup

    Friend cn As SqlConnection
    Public myForm As MassarelliLabelPrinter ' = New MassarelliLabelPrinter
    Friend msCompanyID As String = "Massarelli"
    Friend msUserID As String = ""
    Friend msBusinessDate As Date = Now
    Friend db As String
    Public Sub Main()

        Try
            cn = New SqlConnection(My.Settings.MassDATAConnection)
            'cn = New SqlConnection(My.Settings.MassDATA_TCOPTIPLEX)
            'cn = New SqlConnection(My.Settings.MassDATA_TCHPServerConnectionString)

            cn.Open()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim st As Integer = cn.State

        myForm = New MassarelliLabelPrinter
        Application.Run(myForm)

    End Sub

End Module

