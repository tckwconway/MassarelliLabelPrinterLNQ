Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data
Imports System.Text
Imports System.ComponentModel
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices.Marshal
Imports System.Runtime.InteropServices
Imports Seagull.BarTender.Print
Imports Seagull.BarTender.Print.Database
Imports Seagull.BarTender.Print.Message
Imports System.Data.Common
Imports System.Linq.Queryable
Imports System.Linq.Expressions
Imports System.Linq.Expressions.DynamicExpression

Public Class frmViewDataTable
    Private dtLabelData As DataTable


    Public Sub New(dt As DataTable)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dtLabelData = dt
    End Sub

    Public Sub LoadData(dt As DataTable)
        Dim dg As DataGridView
        dg = CType(Me.DataGridView1, DataGridView)
        With dg
            dg.DataSource = dt
        End With
    End Sub

    Private Sub frmViewDataTable_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadData(dtLabelData)
    End Sub
End Class