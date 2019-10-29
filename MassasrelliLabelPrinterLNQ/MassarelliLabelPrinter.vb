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


Public Class MassarelliLabelPrinter

    '****************************************************************************************************************
    ' Notes on Massarelli configuration
    ' 1. Bartender version is 10.0.0 SR3 (not SR4)
    ' 2. Reference is made in project through .NET tab in references, not Browse
    ' 3. Build Configuration: Compile Platform (Target CPU) must be x86, not "Any CPU" for all .exe and .dll
    ' 4. Build Configuration: Target Framework must be .NET Framework 4.0 (not .NET Framework 4.0 Client Profile)
    ' 5. Must have app.config setup with this: 
    '   <startup useLegacyV2RuntimeActivationPolicy="true">
    '       <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.0"/>
    '     <startup useLegacyV2RuntimeActivationPolicy="true" />
    '   </startup>
    ' 6. App.Config must be used in deployment
    '****************************************************************************************************************

    Private Const appName As String = "Print Preview"
    Private Const DatabaseConnectionNameInLabel As String = "LabelData"
    Const sCheckMark1 As Char = ChrW(&H2611)  'Check with box
    Const sCheckMark2 As Char = ChrW(&H2713)  'Light check mark
    Const sCheckMark3 As Char = ChrW(&H2714)  'Heavy check mark
    Const sGlyphDown As Char = ChrW(&H25BC) 'Glyph (down pointing triangle)
    Const sGlyphUp As Char = ChrW(&H25B2) 'Glyph (up pointing triangle)
    Const sHeavyMultiplicationX As Char = ChrW(&H2716)
    Private engine As Engine = Nothing ' The BarTender Print Engine.
    Private format As LabelFormatDocument = Nothing ' The format that will be exported.
    Private previewPath As String = "" ' The path to the folder where the previews will be exported.
    Private datapath As String = "" ' The path to the folder where the text file data will be stored
    Private currentPage As Integer = 1 ' The current page being viewed.
    Private totalPages As Integer ' Number of pages.
    Private messages As Messages
    Private retcall As String ' String for returing the call if error occurs 
    Private colSort As New Collection
    Private colArr As New Collection
    Private itmToPrint As ItemsToPrintFromItemMaster
    Private itmsToPrint As New Collection
    Private tblLabelData As DataTable
    Private bEndProcessing As Boolean = False
    Private frmviewdt As New Form
    Private dragBoxFromMouseDown As Rectangle
    Private rowIndexFromMouseDown As Integer
    Private rowIndexOfItemUnderMouseToDrop As Integer

    Public Enum SQLOrderByDirection
        asc
        desc
    End Enum

    Public Enum PendingOrHistory
        pending = 1
        history = 2
    End Enum

#Region "   WORKING ON   "

    Private Sub PreviewLabel(sender As System.Object, e As System.EventArgs) Handles btnPreview.Click

        'Check for problems first, No data, No orderNo, No Label selected etc...
        If ExcelDataSet.BTLabelPathFileName = "" Then
            MsgBox("A BarTender label does not appear to have been selected.  Select a label to display preview.")
            Exit Sub
        End If
        'Check if the LabelDataTable to print labels exists, if not check the OrderItems DataGridView to see if this is
        'a Drag Drop operation.  If neither, the exit the sub.  
        If ExcelDataSet.LabelDataTable Is Nothing Then
            If Me.dgvOrderItemsSelected.Rows.Count = 0 Then
                Exit Sub
            Else
                Dim rws As Integer = 0
                For Each rw As DataGridViewRow In Me.dgvOrderItemsSelected.Rows
                    For Each cl As DataGridViewColumn In Me.dgvOrderItemsSelected.Columns
                        If cl.Name = "QtyOrd" Then
                            rws = rws + Me.dgvOrderItemsSelected(cl.Name, rw.Index).Value
                        End If
                    Next
                Next
                If rws = 0 Then
                    MsgBox("Label quantity is 0.  Enter label quantity to continue.", MsgBoxStyle.OkOnly, "Missing Label Quantity")
                    Exit Sub
                End If
            End If
        End If

        'Proceed to Label Preview
        PreviewLabel(ItemsOrOrders)

    End Sub

    Private Sub PrintLabel(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        If format.PrintJobCounter = 0 And totalPages = 0 Then
            MsgBox("Labels to Print is 0.  This usually means the Preview Button has not been pressed." & vbCrLf & vbCrLf & "Be sure to press the Preview button before printing.", MsgBoxStyle.OkOnly, "Nothing to Print")

            Exit Sub
        End If
        format.Print()
        If ItemsOrOrders = "Orders" And PrintColumnVisible = False Then
            InsertRecord_LINQ()
        End If

        TableHasBeenCreated = False
        ItemLabelsDataTable = Nothing

    End Sub

    Private Sub btnShowAll_Click(sender As System.Object, e As System.EventArgs) Handles btnShowAll.Click
        IsLoading = True
        GetOrderList_LNQ()
        IsLoading = False
        ClearSearchTextBoxes()
    End Sub
    Private Function LoadLabelData(dt As DataTable) As Boolean
        Dim RetMethod As String = "PrintLabels"

        Dim tmpItems As String = ""
        If dt Is Nothing Then
            MsgBox("An Order has not been selected.  Choose an Order and try again.")
            Return False
            Exit Function
        End If

        Dim rws As Integer = 0
        Dim cls As Integer = dt.Columns.Count - 1

        Dim rw As DataRow
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim qty As Integer = 0

        If PrintColumnVisible = False Then

            For Each rw In dt.Rows
                rws = rws + rw("QtyOrd")
            Next

            If rws = 0 Then
                MsgBox("Label quantity is 0.  Enter the quantity of labels to print and try again", MsgBoxStyle.OkOnly, "Missing Label Quantity")
                Return False
            End If

            Dim arrItems(rws, cls - 1) As String
            Try
                'arrItems(0, 0) = ""
                'arrItems(0, 1) = ""
                'arrItems(0, 2) = ""
                'arrItems(0, 3) = ""
                'arrItems(0, 4) = ""
                'arrItems(0, 5) = ""
                'If ExcelDataSet.ImportType = "UPC" Then
                '    arrItems(0, 6) = ""
                'End If
                For Each rw In dt.Rows

                    qty = rw("QtyOrd")

                    For j = 0 To qty - 1
                        arrItems(i, 0) = rw("SKU").ToString.Trim
                        arrItems(i, 1) = rw("Description").ToString.Trim
                        arrItems(i, 2) = rw("Retail").ToString.Trim
                        arrItems(i, 3) = rw("MfgPart").ToString.Trim
                        arrItems(i, 4) = rw("MfgFinish").ToString.Trim
                        arrItems(i, 5) = rw("QtyOrd").ToString.Trim
                        If ExcelDataSet.ImportType = "UPC" Then
                            arrItems(i, 6) = rw("UPC").ToString.Trim
                        End If
                        i = i + 1
                    Next j
                Next

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            'Create the temporary Text File for the Label Data Source
            Try

                retcall = "tmpItems = Me.WriteTextFile(arrItems), Array UBound: " & arrItems.Length.ToString
                ExcelDataSet.LabelDataSourcePathFile = Me.WriteTextFile(arrItems)

            Catch ex As Exception
                MsgBox("Method: " & RetMethod & ", Call: " & retcall)
            End Try


        Else

            For Each rw In dt.Rows
                If rw("x") = True Then
                    If ExcelDataSet.ImportType = "SKU" Then
                        rws = rws + CInt(rw(6))
                    Else
                        rws = rws + CInt(rw(7))
                    End If
                End If

            Next

            Dim arrItems(rws - 1, cls - 1) As String
            For Each rw In dt.Rows
                If rw("x") = True Then
                    If ExcelDataSet.ImportType = "SKU" Then
                        qty = CInt(rw(6))
                    Else
                        qty = CInt(rw(7))
                    End If

                    For j = 0 To qty - 1
                        arrItems(i, 0) = rw(1).ToString
                        arrItems(i, 1) = rw(2).ToString
                        arrItems(i, 2) = rw(3).ToString
                        arrItems(i, 3) = rw(4).ToString
                        arrItems(i, 4) = rw(5).ToString
                        arrItems(i, 5) = rw(6).ToString
                        i = i + 1
                    Next j
                End If
            Next

            'Create the temporary Text File for the Label Data Source
            Try

                retcall = "tmpItems = Me.WriteTextFile(arrItems), Array UBound: " & arrItems.Length.ToString
                ExcelDataSet.LabelDataSourcePathFile = Me.WriteTextFile(arrItems)

            Catch ex As Exception
                MsgBox("Method: " & RetMethod & ", Call: " & retcall)
            End Try

        End If
        Return True
    End Function

    Private Sub PrintBartender(ByVal tmpItems As String)
        Dim RetMethod As String = "PrintBartender"
        Dim RetCall As String = ""
        Try

            Try
                RetCall = "btEng.OpenLabelFormatByDataSource(" & ExcelDataSet.LabelDataSourcePathFile & ", LabelData" & ", " & tmpItems & ", " & _
                                                                 ExcelDataSet.PrinterName & ", " & ExcelDataSet.PrintType & ")"
                'btEng.OpenLabelFormatByDataSource(ExcelDataSet.BTLabelPathFileName, "LabelData", ExcelDataSet.LabelDataSourcePathFile, ExcelDataSet.PrinterName)
            Catch ex As Exception
                MsgBox("Method: " & RetMethod & ", Call: " & RetCall)
                MsgBox(ex.Message)
                Exit Sub
            End Try

        Catch ex As Exception
            MsgBox("Bartender Failed to Print.  Be sure Bartender is installed on this computer.", MsgBoxStyle.OkCancel, "Bartender Failed to Print")
            MsgBox("Error Message: " & ex.Message)
            Exit Sub
        End Try

    End Sub

    Public Function WriteTextFile(ByVal arrItems(,) As String) As String
        Dim RetMethod As String = "WriteTextFile"
        Dim RetCall As String = ""
        Dim i As Integer
        Dim tmpFileName As String = "OrderData" & Now.ToString("MMddyyyyhhmmss")

        tmpFileName = datapath & "\" & tmpFileName & ".txt"

        'Delete the temporary text file if it exists 
        Try
            Kill(tmpFileName)
        Catch ex As Exception

        End Try
        ExcelDataSet.LabelDataSourcePathFile = tmpFileName
        Using objWriter As New StreamWriter(tmpFileName, True)

            Try
                For i = 0 To arrItems.GetUpperBound(0) - 1
                    'If i = 99 Then
                    '    MsgBox("STOP")
                    'End If
                    If ExcelDataSet.ImportType = "SKU" Then
                        RetCall = "objWriter.WriteLine" & arrItems(i, 0).ToString & "," & arrItems(i, 1).ToString & "," & arrItems(i, 2).ToString & "," & arrItems(i, 3).ToString & "," & arrItems(i, 4).ToString & "," & arrItems(i, 5).ToString
                        objWriter.WriteLine(arrItems(i, 0).ToString & "," & arrItems(i, 1).ToString & "," & arrItems(i, 2).ToString & "," & arrItems(i, 3).ToString & "," & arrItems(i, 4).ToString & "," & arrItems(i, 5).ToString)
                    ElseIf ExcelDataSet.ImportType = "UPC" Then
                        RetCall = "objWriter.WriteLine" & arrItems(i, 0).ToString & "," & arrItems(i, 1).ToString & "," & arrItems(i, 2).ToString & "," & arrItems(i, 3).ToString & "," & arrItems(i, 4).ToString & "," & arrItems(i, 5).ToString & "," & arrItems(i, 6).ToString
                        objWriter.WriteLine(arrItems(i, 0).ToString & "," & arrItems(i, 1).ToString & "," & arrItems(i, 2).ToString & "," & arrItems(i, 3).ToString & "," & arrItems(i, 4).ToString & "," & arrItems(i, 5).ToString & "," & arrItems(i, 6).ToString)
                    End If
                Next
            Catch ex As Exception
                MsgBox("Method: " & RetMethod & ", Call: " & RetCall, MsgBoxStyle.OkOnly, "Error")
                MsgBox(ex.Message)
            End Try

            objWriter.Close()
        End Using
        Return tmpFileName
    End Function

#End Region

#Region "   Load   "

    Private Sub MassarelliLabelPrinter_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        MacolaStartup.MacStartup()
        SetupControls()
    End Sub

    Private Sub SetupControls()

        ''BARTENDER SECTION ----
        ' Create and start a new BarTender Print Engine.
        Try
            engine = New Engine(True)
        Catch exception As PrintEngineException
            ' If the engine is unable to start, a PrintEngineException will be thrown.
            MessageBox.Show(Me, exception.Message, appName)
            Me.Close() ' Close this app. We cannot run without connection to an engine.
            Return
        End Try

        Try
            'btEng = New BartenderEngineWrapper
        Catch ex As Exception
            MsgBox("Bartender Print Engine Failed to Open.  Check if Bartender is installed on this computer.", MsgBoxStyle.OkCancel, "Bartender Print Engine Did Not Load")
        End Try

        Dim dgv As DataGridView = DirectCast(Me.dgvOrderList, DataGridView)
        CreateOrdersDataGridView(dgv)
        ExcelDataSet.ShowHide = "Show"

        'List the Local Printers
        Dim printers As New Printers()
        For Each printer As Printer In printers
            cboPrinters.Items.Add(printer.PrinterName)
        Next printer

        If printers.Count > 0 Then
            ' Automatically select the default printer.
            cboPrinters.SelectedItem = printers.Default.PrinterName
            ExcelDataSet.PrinterName = cboPrinters.SelectedItem
        End If

        ' Hide/Disable preview controls.
        DisablePreview()

        ' Create a temporary folder to hold the bartender label images.
        Dim tempPath As String = Path.GetTempPath() ' Something like "C:\Documents and Settings\<username>\Local Settings\Temp""
        Dim newFolder As String
        Do
            newFolder = Path.GetRandomFileName()
            previewPath = tempPath & newFolder ' newFolder is something crazy like "gulvwdmt.3r4"
        Loop While Directory.Exists(previewPath)
        Directory.CreateDirectory(previewPath)

        Do
            newFolder = Path.GetRandomFileName()
            datapath = tempPath & newFolder
        Loop While Directory.Exists(datapath)
        Directory.CreateDirectory(datapath)
        IsLoading = False

        'Load Sort Order
        colArr.Add(New LabelSortOrder("SKU"), "SKU")
        colArr.Add(New LabelSortOrder("Description"), "Description")
        colArr.Add(New LabelSortOrder("Retail"), "Retail")
        colArr.Add(New LabelSortOrder("MfgPart"), "MfgPart")
        colArr.Add(New LabelSortOrder("MfgFinish"), "MfgFinish")
        colArr.Add(New LabelSortOrder("QtyOrd"), "QtyOrd")
        dgvSortableColumns.DataSource = colArr


        colSort.Add(New LabelSortOrder("MfgFinish"))
        colSort.Add(New LabelSortOrder("MfgPart"))
        bsrcSortable.DataSource = colSort

        dgvSortOrder.DataSource = bsrcSortable
        UnselectCells()

        PrintColumnVisible = False

        ItemsOrOrders = "Orders"
        pnlOrderList.Dock = DockStyle.Fill
        With pnlItemList
            .Visible = False
            .Dock = DockStyle.Fill
        End With

        CreateOrderItemsSelectedDataGridView(dgvOrderItemsSelected)
        CreateMissingDataGridView(dgvSpecialOrder)



    End Sub

#End Region

#Region "   LINQ   "

    ''' <summary>
    ''' 
    ''' Retrieves List of All Orders (Not currently used)
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetOrderList_LNQ()

        Dim dc As New LNQ_OrderListDataContext(cn)

        Dim ordlst = From orderList In dc.voeGetOEOrdHdrLists _
        Order By orderList.ord_no _
        Select orderList.ord_no, orderList.ord_dt, _
        orderList.cus_no, orderList.cus_alt_adr_cd, _
        orderList.bill_to_name, orderList.ship_to_name, _
        orderList.status()

        Me.bsrcOrderList.DataSource = ordlst
        'CreateOrderItemsSelectedDataGridView(Me.dgvOrderList)
        With Me.dgvOrderList
            '.AutoGenerateColumns = True
            .DataSource = bsrcOrderList
        End With

    End Sub

    ''' <summary>
    ''' 1 - Retrieves Order List Based on Criteria
    ''' </summary>
    ''' <param name="fltr"></param>
    ''' <param name="txt"></param>
    ''' <remarks></remarks>
    Private Sub FilterOrderList_LNQ_ByBillTo(fltr As String, txt As TextBox, PendOrHist As Integer)
        Select Case PendOrHist


            Case PendingOrHistory.pending
                Try

                    Dim dc As New LNQ_OrderListDataContext(cn)

                    Select Case txt.Name
                        Case "txtBillToName"
                            Dim ordlst = From orderList In dc.voeGetOEOrdHdrLists _
                                   Order By orderList.ord_no _
                                   Select orderList.printed, orderList.ord_no, orderList.ord_dt, _
                                   orderList.cus_no, orderList.cus_alt_adr_cd, _
                                   orderList.bill_to_name, orderList.ship_to_name, _
                                   orderList.status() _
                                   Where bill_to_name.ToLower.Contains(fltr.ToLower)
                            Me.bsrcOrderList.DataSource = ordlst
                        Case "txtOrderNo"
                            If txt.Text.Length < 6 Then Exit Sub
                            Cursor = Cursors.WaitCursor
                            Dim ordlst = From orderList In dc.voeGetOEOrdHdrLists _
                                                   Order By orderList.ord_no _
                                                   Select orderList.printed, orderList.ord_no, orderList.ord_dt, _
                                                   orderList.cus_no, orderList.cus_alt_adr_cd, _
                                                   orderList.bill_to_name, orderList.ship_to_name, _
                                                   orderList.status() _
                                                   Where ord_no.Contains(fltr.ToLower)
                            Me.bsrcOrderList.DataSource = ordlst
                            Cursor = Cursors.Default
                        Case "txtOrderDate"
                            Dim ordlst = From orderList In dc.voeGetOEOrdHdrLists _
                                                   Order By orderList.ord_no _
                                                   Select orderList.printed, orderList.ord_no, orderList.ord_dt, _
                                                   orderList.cus_no, orderList.cus_alt_adr_cd, _
                                                   orderList.bill_to_name, orderList.ship_to_name, _
                                                   orderList.status() _
                                                   Where ord_dt.ToString.Contains(fltr.ToLower)
                            Me.bsrcOrderList.DataSource = ordlst
                        Case "txtCustNo"
                            Dim ordlst = From orderList In dc.voeGetOEOrdHdrLists _
                                                   Order By orderList.ord_no _
                                                   Select orderList.printed, orderList.ord_no, orderList.ord_dt, _
                                                   orderList.cus_no, orderList.cus_alt_adr_cd, _
                                                   orderList.bill_to_name, orderList.ship_to_name, _
                                                   orderList.status() _
                                                   Where cus_no.ToLower.Contains(fltr.ToLower)
                            Me.bsrcOrderList.DataSource = ordlst
                        Case "txtCustAltAdrCode"
                            Dim ordlst = From orderList In dc.voeGetOEOrdHdrLists _
                                                   Order By orderList.ord_no _
                                                   Select orderList.printed, orderList.ord_no, orderList.ord_dt, _
                                                   orderList.cus_no, orderList.cus_alt_adr_cd, _
                                                   orderList.bill_to_name, orderList.ship_to_name, _
                                                   orderList.status() _
                                                   Where cus_alt_adr_cd.ToLower.Contains(fltr.ToLower)
                            Me.bsrcOrderList.DataSource = ordlst
                        Case "txtShipToName"
                            Dim ordlst = From orderList In dc.voeGetOEOrdHdrLists _
                                                   Order By orderList.ord_no _
                                                   Select orderList.printed, orderList.ord_no, orderList.ord_dt, _
                                                   orderList.cus_no, orderList.cus_alt_adr_cd, _
                                                   orderList.bill_to_name, orderList.ship_to_name, _
                                                   orderList.status() _
                                                   Where ship_to_name.ToLower.Contains(fltr.ToLower)
                            Me.bsrcOrderList.DataSource = ordlst
                        Case "txtStatus"
                            Dim ordlst = From orderList In dc.voeGetOEOrdHdrLists _
                                                   Order By orderList.ord_no _
                                                   Select orderList.printed, orderList.ord_no, orderList.ord_dt, _
                                                   orderList.cus_no, orderList.cus_alt_adr_cd, _
                                                   orderList.bill_to_name, orderList.ship_to_name, _
                                                   orderList.status() _
                                                   Where status = fltr
                            Me.bsrcOrderList.DataSource = ordlst

                    End Select

                    Me.dgvOrderList.DataSource = bsrcOrderList
                    'If Me.dgvOrderItemsSelected.Rows.Count = 0 Then
                    '    pnlDragOffToRemove.Visible = False
                    'Else
                    '    pnlDragOffToRemove.Visible = True
                    'End If
                Catch ex As Exception

                End Try
            Case PendingOrHistory.history

                Try

                    Dim dc As New LNQ_OrderHistoryListDataContext(cn)

                    Select Case txt.Name
                        Case "txtBillToName"
                            Dim hstlst = From historyList In dc.voeGetOEHdrHstLists
                                   Order By historyList.ord_no _
                                   Select historyList.printed, historyList.ord_no, historyList.ord_dt, _
                                   historyList.cus_no, historyList.cus_alt_adr_cd, _
                                   historyList.bill_to_name, historyList.ship_to_name, _
                                   historyList.status() _
                                   Where bill_to_name.ToLower.Contains(fltr.ToLower)
                            'Me.bsrchistoryList.DataSource = ordlst
                            Me.bsrcOrderList.DataSource = hstlst


                        Case "txtOrderNo"
                            Dim hstlst = From historyList In dc.voeGetOEHdrHstLists _
                                                   Order By historyList.ord_no _
                                                   Select historyList.printed, historyList.ord_no, historyList.ord_dt, _
                                                   historyList.cus_no, historyList.cus_alt_adr_cd, _
                                                   historyList.bill_to_name, historyList.ship_to_name, _
                                                   historyList.status() _
                                                   Where ord_no.Contains(fltr.ToLower)
                            Me.bsrcOrderList.DataSource = hstlst
                        Case "txtOrderDate"
                            Dim hstlst = From historyList In dc.voeGetOEHdrHstLists _
                                                   Order By historyList.ord_no _
                                                   Select historyList.printed, historyList.ord_no, historyList.ord_dt, _
                                                   historyList.cus_no, historyList.cus_alt_adr_cd, _
                                                   historyList.bill_to_name, historyList.ship_to_name, _
                                                   historyList.status() _
                                                   Where ord_dt.ToString.Contains(fltr.ToLower)
                            Me.bsrcOrderList.DataSource = hstlst
                        Case "txtCustNo"
                            Dim hstlst = From historyList In dc.voeGetOEHdrHstLists _
                                                   Order By historyList.ord_no _
                                                   Select historyList.printed, historyList.ord_no, historyList.ord_dt, _
                                                   historyList.cus_no, historyList.cus_alt_adr_cd, _
                                                   historyList.bill_to_name, historyList.ship_to_name, _
                                                   historyList.status() _
                                                   Where cus_no.ToLower.Contains(fltr.ToLower)
                            Me.bsrcOrderList.DataSource = hstlst
                        Case "txtCustAltAdrCode"
                            Dim hstlst = From historyList In dc.voeGetOEHdrHstLists _
                                                   Order By historyList.ord_no _
                                                   Select historyList.printed, historyList.ord_no, historyList.ord_dt, _
                                                   historyList.cus_no, historyList.cus_alt_adr_cd, _
                                                   historyList.bill_to_name, historyList.ship_to_name, _
                                                   historyList.status() _
                                                   Where cus_alt_adr_cd.ToLower.Contains(fltr.ToLower)
                            Me.bsrcOrderList.DataSource = hstlst
                        Case "txtShipToName"
                            Dim hstlst = From historyList In dc.voeGetOEHdrHstLists _
                                                   Order By historyList.ord_no _
                                                   Select historyList.printed, historyList.ord_no, historyList.ord_dt, _
                                                   historyList.cus_no, historyList.cus_alt_adr_cd, _
                                                   historyList.bill_to_name, historyList.ship_to_name, _
                                                   historyList.status() _
                                                   Where ship_to_name.ToLower.Contains(fltr.ToLower)
                            Me.bsrcOrderList.DataSource = hstlst
                        Case "txtStatus"
                            Dim hstlst = From historyList In dc.voeGetOEHdrHstLists _
                                                   Order By historyList.ord_no _
                                                   Select historyList.printed, historyList.ord_no, historyList.ord_dt, _
                                                   historyList.cus_no, historyList.cus_alt_adr_cd, _
                                                   historyList.bill_to_name, historyList.ship_to_name, _
                                                   historyList.status() _
                                                   Where status = fltr
                            Me.bsrcOrderList.DataSource = hstlst

                    End Select

                    Me.dgvOrderList.DataSource = bsrcOrderList
                    'If Me.dgvOrderItemsSelected.Rows.Count = 0 Then
                    '    pnlDragOffToRemove.Visible = False
                    'Else
                    '    pnlDragOffToRemove.Visible = True
                    'End If
                Catch ex As Exception

                End Try
        End Select

    End Sub

    ''' <summary>
    ''' 
    ''' 2 - LINQ Retrieves Items from Order Selected in the List
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetOrderItem_LNQ(PendOrHist As Integer)

        Select Case PendOrHist
            Case PendingOrHistory.pending

                Try
                    Dim dc As New LNQ_OrderItemsDataContext(cn)
                    Dim oDS As New DataSet
                    Dim oDT As New DataTable("OrderItems")
                    oDT.Columns.Add("ord_no", GetType(String))
                    oDT.Columns.Add("item_no", GetType(String))
                    oDT.Columns.Add("qty_ordered", GetType(Decimal))
                    oDT.Columns.Add("pick_seq", GetType(String))
                    oDT.Columns.Add("item_desc_1", GetType(String))
                    oDT.Columns.Add("cmt", GetType(String))

                    Dim orditm = (From orderitems In dc.voeOrderItems _
                                 Where orderitems.ord_no.Contains(ExcelDataSet.OrderNo) _
                                 Select orderitems.ord_no, orderitems.item_no, orderitems.qty_ordered, orderitems.pick_seq, orderitems.item_desc_1, orderitems.cmt).Distinct

                    For Each ord In orditm
                        oDT.Rows.Add(New Object() {ord.ord_no.Trim, ord.item_no.Trim, ord.qty_ordered, ord.pick_seq.Trim, ord.item_desc_1.Trim, ord.cmt.Trim})
                    Next
                    'For i As Integer = 0 To oDT.Rows.Count - 1
                    '    System.Diagnostics.Debug.Print(oDT(i)(1))
                    'Next

                    oDS.Tables.Add(oDT)
                    ExcelDataSet.OrderItemDataset = oDS

                Catch ex As Exception

                End Try

            Case PendingOrHistory.history

                Try
                    Dim dc As New LNQ_OrderHistoryItemsDataContext(cn)
                    Dim oDS As New DataSet
                    Dim oDT As New DataTable("OrderItems")
                    oDT.Columns.Add("ord_no", GetType(String))
                    oDT.Columns.Add("item_no", GetType(String))
                    oDT.Columns.Add("qty_ordered", GetType(Decimal))
                    oDT.Columns.Add("pick_seq", GetType(String))
                    oDT.Columns.Add("item_desc_1", GetType(String))
                    oDT.Columns.Add("cmt", GetType(String))


                    Dim hstitm = From historyitems In dc.voeOrderHistoryItems _
                                 Where historyitems.ord_no.Equals(ExcelDataSet.OrderNo) _
                                 Select historyitems.ord_no, historyitems.item_no, historyitems.qty_ordered, historyitems.pick_seq, historyitems.item_desc_1, historyitems.cmt


                    'skip if too many records ....
                    'If hstitm.Count > 1000 Then
                    '    bEndProcessing = True
                    '    Exit Sub
                    'End If

                    For Each ord In hstitm
                        oDT.Rows.Add(New Object() {ord.ord_no.Trim, ord.item_no.Trim, ord.qty_ordered, ord.pick_seq.Trim, ord.item_desc_1.Trim, ord.cmt.Trim})
                        'If oDT.Rows.Count > 1000 Then Exit Sub
                    Next

                    oDS.Tables.Add(oDT)
                    ExcelDataSet.OrderItemDataset = oDS

                Catch ex As Exception

                End Try

        End Select

    End Sub

    ''' <summary>
    ''' 3 - LINQ Return the XL Prices Linked to the Order
    ''' </summary>
    ''' <remarks></remarks>

    Public Sub GetOrderForLabel_LINQ()

        Dim ImportType As String = ExcelDataSet.ImportType

        Dim dvxlCOLOR As New DataView
        Dim dvxlDS As New DataView
        Dim dvoeCOLOR As New DataView
        Dim dvoeDS As New DataView

        Dim dtxlCOLOR As New DataTable
        Dim dtxlDS As New DataTable
        Dim dtoeCOLOR As New DataTable
        Dim dtoeDS As New DataTable

        Dim dtxl As New DataTable
        dtxl = ExcelDataSet.XLDataset.Tables(0).Copy
        dvxlCOLOR = dtxl.DefaultView
        dvxlDS = dtxl.DefaultView

        dvxlCOLOR.RowFilter = "MfgFinishNo is null or  MfgFinishNo = '' "
        dtxlCOLOR = dvxlCOLOR.ToTable

        dvxlDS.RowFilter = "MfgFinishNo like '%DS%' OR MfgFinishNo like '%XX%'"
        dtxlDS = dvxlDS.ToTable

        Dim dtoe As New DataTable
        dtoe = ExcelDataSet.OrderItemDataset.Tables(0).Copy
        dvoeCOLOR = dtoe.DefaultView
        dvoeDS = dtoe.DefaultView

        dvoeCOLOR.RowFilter = "pick_seq not like '%DS%' AND pick_seq not like '%XX%'"
        dtoeCOLOR = dvoeCOLOR.ToTable

        dvoeDS.RowFilter = "pick_seq like '%DS%' OR pick_seq like '%XX%'"
        dtoeDS = dvoeDS.ToTable

        Select Case ImportType
            Case "SKU"
                Try

                    'Create datatable
                    Dim oLabelData As New DataTable("LabelData")
                    oLabelData.Columns.Add("x", GetType(Boolean))
                    oLabelData.Columns.Add("SKU", GetType(String))
                    oLabelData.Columns.Add("Description", GetType(String))
                    oLabelData.Columns.Add("Retail", GetType(Decimal))
                    oLabelData.Columns.Add("MfgPart", GetType(String))
                    oLabelData.Columns.Add("MfgFinish", GetType(String))
                    oLabelData.Columns.Add("QtyOrd", GetType(Decimal))


                    Dim orderItems = From p In dtxlCOLOR, o In dtoeCOLOR _
                                          Where (p.Field(Of String)("MfgItemNo").Trim = o.Field(Of String)("item_no").Trim) _
                                          Select p!SKU, p!Description, p!Retail, p!MfgItemNo, o!pick_seq, p!UPC, o!qty_ordered ').ToList

                    'Dim orderItems = From p In xlprices, o In oeorder _
                    '                       Where p!MfgItemNo.ToString.Trim = o!item_no.ToString.Trim And _
                    '                       p!MfgFinishNo.ToString.Trim = o!pick_seq.ToString.Trim _
                    '                       Select p!SKU, p!Description, p!Retail, p!MfgItemNo, p!MfgFinishNo, p!UPC, o!qty_ordered ').ToList
                    'Add items that are natural or stain (pick_seq = "")

                    'Dim orderItems = From p In xlprices, o In oeorder _
                    '                       Where (p!MfgItemNo.ToString.Trim = o!item_no.ToString.Trim And o!pick_seq = "")
                    '                       Select p!SKU, p!Description, p!Retail, p!MfgItemNo, o!pick_seq, p!UPC, o!qty_ordered ').ToList

                    'add data to datatable
                    For Each o In orderItems
                        oLabelData.Rows.Add(New Object() {False, o.SKU, o.Description, o.Retail, o.MfgItemNo, o.pick_seq, o.UPC, o.qty_ordered})
                    Next

                    'Add items that are DS, detail stain (pick_seq.contains("DS")
                    orderItems = From p In dtxlDS, o In dtoeDS _
                                           Where (p.Field(Of String)("MfgItemNo").Trim = o.Field(Of String)("item_no").Trim) _
                                           Select p!SKU, p!Description, p!Retail, p!MfgItemNo, o!pick_seq, p!UPC, o!qty_ordered ').ToList
                    'orderItems = From p In xlprices, o In oeorder _
                    '                                           Where (p!MfgItemNo.ToString.Trim = o!item_no.ToString.Trim And o!pick_seq.Contains("DS"))
                    '                                           Select p!SKU, p!Description, p!Retail, p!MfgItemNo, o!pick_seq, p!UPC, o!qty_ordered ').ToList

                    For Each o In orderItems
                        oLabelData.Rows.Add(New Object() {False, o.SKU, o.Description, o.Retail, o.MfgItemNo, o.pick_seq, o.UPC, o.qty_ordered})
                    Next





                    'Dim orderItems = (From p In xlprices, o In oeorder _
                    '                       Where (p!MfgItemNo.ToString.Trim = o!item_no.ToString.Trim And o!pick_seq = "") _
                    '                       Select p!SKU, p!Description, p!Retail, p!MfgItemNo, o!pick_seq, o!qty_ordered).Distinct  ').ToList
                    ''Dim orderItems = From p In xlprices, o In oeorder _
                    ''                                          Where p!MfgItemNo.ToString.Trim = o!item_no.ToString.Trim And _
                    ''                                          p!MfgFinishNo.ToString.Trim = o!pick_seq.ToString.Trim _
                    ''                                          Select p!SKU, p!Description, p!Retail, p!MfgItemNo, p!MfgFinishNo, o!qty_ordered ').ToList

                    ' ''add data to datatable
                    'For Each o In orderItems
                    '    oLabelData.Rows.Add(New Object() {False, o.SKU, o.Description, o.Retail, o.MfgItemNo, o.pick_seq, o.qty_ordered})
                    'Next

                    Dim sort As New StringBuilder
                    Dim i As Integer = 1
                    For Each o As Object In colSort
                        With sort
                            '.Append(Chr(34))
                            .Append(o.Column.ToString)
                            '.Append(Chr(34))
                            If colSort.Count > i Then .Append(",")
                        End With
                        i = i + 1
                    Next

                    Dim sortorder As String = sort.ToString
                    Dim oLabelView As DataView = oLabelData.DefaultView
                    oLabelView.Sort = sortorder
                    Dim labeldata As DataTable = oLabelView.ToTable

                    ExcelDataSet.LabelDataTable = labeldata
                Catch ex As Exception

                End Try

            Case "UPC"

                Try
                    'Create datatable
                    Dim oLabelData As New DataTable("LabelData")
                    oLabelData.Columns.Add("x", GetType(Boolean))
                    oLabelData.Columns.Add("SKU", GetType(String))
                    oLabelData.Columns.Add("Description", GetType(String))
                    oLabelData.Columns.Add("Retail", GetType(Decimal))
                    oLabelData.Columns.Add("MfgPart", GetType(String))
                    oLabelData.Columns.Add("MfgFinish", GetType(String))
                    oLabelData.Columns.Add("UPC", GetType(String))
                    oLabelData.Columns.Add("QtyOrd", GetType(Decimal))

                    Dim orderItems = From p In dtxlCOLOR, o In dtoeCOLOR _
                                           Where (p.Field(Of String)("MfgItemNo").Trim = o.Field(Of String)("item_no").Trim) _
                                           Select p!SKU, p!Description, p!Retail, p!MfgItemNo, o!pick_seq, p!UPC, o!qty_ordered ').ToList

                    'Dim orderItems = From p In xlprices, o In oeorder _
                    '                       Where p!MfgItemNo.ToString.Trim = o!item_no.ToString.Trim And _
                    '                       p!MfgFinishNo.ToString.Trim = o!pick_seq.ToString.Trim _
                    '                       Select p!SKU, p!Description, p!Retail, p!MfgItemNo, p!MfgFinishNo, p!UPC, o!qty_ordered ').ToList
                    'Add items that are natural or stain (pick_seq = "")

                    'Dim orderItems = From p In xlprices, o In oeorder _
                    '                       Where (p!MfgItemNo.ToString.Trim = o!item_no.ToString.Trim And o!pick_seq = "")
                    '                       Select p!SKU, p!Description, p!Retail, p!MfgItemNo, o!pick_seq, p!UPC, o!qty_ordered ').ToList

                    'add data to datatable
                    For Each o In orderItems
                        oLabelData.Rows.Add(New Object() {False, o.SKU, o.Description, o.Retail, o.MfgItemNo, o.pick_seq, o.UPC, o.qty_ordered})
                    Next

                    'Add items that are DS, detail stain (pick_seq.contains("DS")
                    Dim orderItemsDS = From p In dtxlDS, o In dtoeDS _
                                           Where (p.Field(Of String)("MfgItemNo").Trim = o.Field(Of String)("item_no").Trim) _
                                           Select p!SKU, p!Description, p!Retail, p!MfgItemNo, o!pick_seq, p!UPC, o!qty_ordered ').ToList
                    'orderItems = From p In xlprices, o In oeorder _
                    '                                           Where (p!MfgItemNo.ToString.Trim = o!item_no.ToString.Trim And o!pick_seq.Contains("DS"))
                    '                                           Select p!SKU, p!Description, p!Retail, p!MfgItemNo, o!pick_seq, p!UPC, o!qty_ordered ').ToList

                    For Each o In orderItemsDS
                        oLabelData.Rows.Add(New Object() {False, o.SKU, o.Description, o.Retail, o.MfgItemNo, o.pick_seq, o.UPC, o.qty_ordered})
                    Next


                    'Dim frmviewdt = New frmViewDataTable(oLabelData)
                    'frmviewdt.Show()
                    'Exit Sub




                    Dim sort As New StringBuilder
                    Dim i As Integer = 1
                    For Each o As Object In colSort
                        With sort
                            '.Append(Chr(34))
                            .Append(o.Column.ToString)
                            '.Append(Chr(34))
                            If colSort.Count > i Then .Append(",")
                        End With
                        i = i + 1
                    Next

                    Dim sortorder As String = sort.ToString
                    Dim oLabelView As DataView = oLabelData.DefaultView
                    oLabelView.Sort = sortorder
                    Dim labeldata As DataTable = oLabelView.ToTable

                    ExcelDataSet.LabelDataTable = labeldata
                Catch ex As Exception

                Finally


                End Try


        End Select




    End Sub

    Private Sub GetOrderForLabel_LINQ(sortorder() As String)

        Dim xlprices = ExcelDataSet.XLDataset.Tables(0).AsEnumerable()
        Dim oeorder = ExcelDataSet.OrderItemDataset.Tables(0).AsEnumerable

        Dim oLabelData As New DataTable("LabelDate")
        oLabelData.Columns.Add("SKU", GetType(String))
        oLabelData.Columns.Add("Description", GetType(String))
        oLabelData.Columns.Add("Retail", GetType(Decimal))
        oLabelData.Columns.Add("MfgPart", GetType(String))
        oLabelData.Columns.Add("MfgFinish", GetType(String))
        oLabelData.Columns.Add("QtyOrd", GetType(Decimal))



        Dim orderItems = From p In xlprices, o In oeorder _
                         Where p!MfgItemNo.ToString.Trim = o!item_no.ToString.Trim And _
                         p!MfgFinishNo.ToString.Trim = o!pick_seq.ToString.Trim _
                         Order By p!MfgFinishNo, p!MfgItemNo _
                         Select p!SKU, p!Description, p!Retail, p!MfgItemNo, p!MfgFinishNo, o!qty_ordered _
                         Order By MfgFinishNo, MfgItemNo


        For Each o In orderItems
            oLabelData.Rows.Add(New Object() {o.SKU, o.Description, o.Retail, o.MfgItemNo, o.MfgFinishNo, o.qty_ordered})
        Next

        ExcelDataSet.LabelDataTable = oLabelData

        'Dim sortexp As String = "Retail"
        'ExcelDataSet.LabelDataTable = ExcelDataSet.LabelDataTable.Select(Nothing, sortexp)

    End Sub

    ''' <summary>
    ''' 4 - LINQ to DataSet: Return Items in Order datatable but NOT found in Excel datatable.  
    '''     These are items that wound up on the order as Special Orders or Missing from the Excel Price Sheet
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetMissingItems_LINQ()
        'Populate NULL values in Excel created Datatable with "" values.  This is needed 
        'for the LINQ query below that searches for Missing Values ...
        Dim dt As DataTable = ExcelDataSet.XLDataset.Tables(0)

        Dim dvxlCOLOR As New DataView
        Dim dvxlDS As New DataView
        Dim dvoeCOLOR As New DataView
        Dim dvoeDS As New DataView

        Dim dtxlCOLOR As New DataTable
        Dim dtxlDS As New DataTable
        Dim dtoeCOLOR As New DataTable
        Dim dtoeDS As New DataTable


        For Each rw As DataRow In dt.Rows
            If rw("MfgFinishNo").Equals(DBNull.Value) Then
                rw("MfgFinishNo") = ""
            End If
        Next
        

        Dim oMissingData As New DataTable("LabelDate")
        oMissingData.Columns.Add("qty_ordered", GetType(Decimal))
        oMissingData.Columns.Add("item_no", GetType(String))
        oMissingData.Columns.Add("item_desc_1", GetType(String))
        oMissingData.Columns.Add("pick_seq", GetType(String))
        oMissingData.Columns.Add("cmt", GetType(String))


        Dim dtxl As New DataTable
        dtxl = ExcelDataSet.XLDataset.Tables(0).Copy
        dvxlCOLOR = dtxl.DefaultView
        dvxlDS = dtxl.DefaultView

        dvxlCOLOR.RowFilter = "MfgFinishNo is null or  MfgFinishNo = '' "
        dtxlCOLOR = dvxlCOLOR.ToTable

        dvxlDS.RowFilter = "MfgFinishNo like '%DS%' OR MfgFinishNo like '%XX%'"
        dtxlDS = dvxlDS.ToTable

        Dim dtoe As New DataTable
        dtoe = ExcelDataSet.OrderItemDataset.Tables(0).Copy
        dvoeCOLOR = dtoe.DefaultView
        dvoeDS = dtoe.DefaultView

        dvoeCOLOR.RowFilter = "pick_seq not like '%DS%' AND pick_seq not like '%XX%'"
        dtoeCOLOR = dvoeCOLOR.ToTable

        dvoeDS.RowFilter = "pick_seq like '%DS%' OR pick_seq like '%XX%'"
        dtoeDS = dvoeDS.ToTable

        Dim missingitem As Boolean = True

        For Each r As DataRow In dtoeCOLOR.Rows
            Dim itm As String = r("item_no").ToString.Trim
            For Each rw As DataRow In dtxlCOLOR.Rows
                If itm = rw("MfgItemNo").ToString.Trim Then
                    missingitem = False
                    Exit For
                End If
            Next
            If missingitem = True Then
                oMissingData.Rows.Add(New Object() {r("qty_ordered"), r("item_no"), r("item_desc_1"), r("pick_seq"), r("cmt")})
            Else
                missingitem = True
            End If
        Next

        missingitem = True

        For Each r As DataRow In dtoeDS.Rows
            Dim itm As String = r("item_no").ToString.Trim
            Dim ds As String = IIf(r("pick_seq").ToString.Trim.Length > 2, r("pick_seq").ToString.Trim.Substring(0, 2), r("pick_seq").ToString.Trim)
            For Each rw As DataRow In dtxlDS.Rows
                If itm = rw("MfgItemNo").ToString.Trim And ds = rw("MfgFinishNo") Then
                    missingitem = False
                    Exit For
                End If
            Next
            If missingitem = True Then
                oMissingData.Rows.Add(New Object() {r("qty_ordered"), r("item_no"), r("item_desc_1"), r("pick_seq"), r("cmt")})
            Else
                missingitem = True
            End If
        Next

        Dim cols() As String = {"qty_ordered", "item_no", "item_desc_1", "pick_seq", "cmt"}
        Dim dtmissing As DataTable = oMissingData.DefaultView.ToTable(True, cols)

        ExcelDataSet.MissingDataTable = dtmissing

        Dim dtTVP As New DataTable
        With dtTVP
            .Columns.Add("item_no", GetType(String))
            .Columns.Add("pick_seq", GetType(String))

            For Each row In ExcelDataSet.MissingDataTable.Rows
                Dim ar() As String = {"", ""}
                ar(0) = row(1).ToString.Trim
                ar(1) = row(3).ToString.Trim
                .Rows.Add(ar)
            Next
        End With

        Dim dtMissingRows As DataTable = BusObj.Execute_SP_GetMissingItemsfromOE(ExcelDataSet.OrderNo, dtTVP, cn)
        ExcelDataSet.MissingDataTable = dtMissingRows
    End Sub
    ''' <summary>
    ''' InsertRecord_LINQ - This section inserts the ord_no and the value 1 to show that this order has been printed when retrieved on the list of orders
    ''' The purpose is informational only, it does not prevent reprinting.  The checkbox on the application displays to help the one printing labels keep
    ''' track of what has been printed.  
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InsertRecord_LINQ()

        If ExcelDataSet.OrderNo Is Nothing Then
            Exit Sub
        Else

            Try
                Dim dc As New LNQ_OEORDEXTDataContext(cn)

                Dim ret = From ord In dc.OEORDEXT_MAs _
                          Where ord.ord_no = ExcelDataSet.OrderNo.Trim _
                          Select ord

                If ret.Count <= 0 Then
                    Dim oext As New OEORDEXT_MA With {.ord_no = ExcelDataSet.OrderNo, .printed = 1}
                    dc.OEORDEXT_MAs.InsertOnSubmit(oext)
                    dc.SubmitChanges()
                End If
            Catch ex As Exception

            End Try

        End If

    End Sub


    Private Sub FilterItemList_LNQ(fltr As String, txt As TextBox)

        Dim dc As New LINQ_ItemListDataContext(cn)

        Select Case txt.Name
            Case "txtItemNo"
                Dim itmlst = From itemList In dc.vimItemLists _
                       Order By itemList.item_no _
                       Select itemList.item_no, itemList.item_desc_1, itemList.prod_cat _
                       Where item_no.ToLower.Contains(fltr.ToLower)
                Me.bsrcItemList.DataSource = itmlst
            Case "txtItemDesc"
                Dim itmlst = From itemList In dc.vimItemLists _
                        Order By itemList.item_no _
                        Select itemList.item_no, itemList.item_desc_1, itemList.prod_cat _
                        Where item_desc_1.ToLower.Contains(fltr.ToLower)
                Me.bsrcItemList.DataSource = itmlst
            Case "txtProdCat"
                Dim itmlst = From itemList In dc.vimItemLists _
                         Order By itemList.item_no _
                         Select itemList.item_no, itemList.item_desc_1, itemList.prod_cat _
                         Where prod_cat.ToLower.Contains(fltr.ToLower)
                Me.bsrcItemList.DataSource = itmlst
        End Select
        dgvItemList.DataSource = Me.bsrcItemList

    End Sub


#End Region

#Region "   Excel Price Sheet   "

    Private Sub LoadPriceSheet(sender As System.Object, e As System.EventArgs) Handles btnPriceList.Click

        Try
            ClearPriceSheetValues()
            frmImportExcel.ShowDialog()
            Me.bsrcExcelPriceList.DataSource = ExcelDataSet.XLDataset.Tables(0)
            CreateXLListDataGridView(Me.dgvExcelPriceList)
            With Me.dgvExcelPriceList
                .DataSource = Me.bsrcExcelPriceList
                .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            End With
            lblPriceSheet.Text = ExcelDataSet.XLFileName
            picExcel.Visible = True
            pnlExcelSpreadsheetNotLoaded.Visible = False
            'enable controls
            Me.btnPreview.Enabled = True
            dgvExcelPriceList.Visible = True
            picPreview.Visible = False
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ClearPriceSheetValues()
        Try
            'picExcel.Visible = False
            lblPriceSheet.Text = ""
            Me.bsrcExcelPriceList.DataSource = Nothing
            ExcelDataSet.XLDataset.Clear()
            ExcelDataSet.XLDataset = Nothing
            Me.dgvExcelPriceList.DataSource = Nothing
            Me.dgvExcelPriceList.DataSource = Me.bsrcExcelPriceList
            System.Threading.Thread.Sleep(100)
            dgvExcelPriceList.Columns.Clear()
            Me.dgvExcelPriceList.Refresh()
        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "  Controls   "

    Private Sub FilterOrderTextBoxes(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtBillToName.KeyUp, txtOrderNo.KeyUp, txtStatus.KeyUp, txtShipToName.KeyUp, txtOrderDate.KeyUp, txtCustNo.KeyUp, txtCustAltAdrCode.KeyUp
        Dim txt As TextBox = DirectCast(sender, TextBox)
        Dim PendOrHist As Integer = IIf(rdHistory.Checked, PendingOrHistory.history, PendingOrHistory.pending)
        FilterOrderList_LNQ_ByBillTo(txt.Text, txt, PendOrHist)
        ClearSearchTextBoxes(txt.Parent, txt)
        bEndProcessing = False
    End Sub

    Private Sub btnLoadBartenderLabel_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadBartenderLabel.Click
        Dim op As OpenFileDialog = DirectCast(Me.OpenFileDialogBartender, OpenFileDialog)

        If op.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            OpenBartenderFormat(op)
            op.Dispose()
        End If

        If ItemsOrOrders = "Items" Then btnPreview.Enabled = True

    End Sub

    Private Sub ClearAll_Click(sender As System.Object, e As System.EventArgs) Handles btnClearAll.Click
        bsrcOrderList.DataSource = Nothing
        bsrcHistoryList.DataSource = Nothing
        bsrcOrderItemsSelected.DataSource = Nothing
        bsrcMissingData.DataSource = Nothing
        picPreview.Image = Nothing
        TableHasBeenCreated = False
        ItemLabelsDataTable = Nothing
        bsrcItemList.DataSource = Nothing
        bsrcItemsToPrint.DataSource = Nothing
        'pnlDragOffToRemove.Visible = False
        dgvExcelPriceList.Visible = True
        picPreview.Visible = False
        With dgvSpecialOrder
            .Rows.Clear()
            .Columns.Clear()
        End With

        'clear search textboxes for Orders, then Items Search
        For Each c In Me.pnlOrders.Controls
            If TypeOf (c) Is TextBox Then
                CType(c, TextBox).Clear()
            End If
        Next

        For Each c In Me.pnlItems.Controls
            If TypeOf (c) Is TextBox Then
                CType(c, TextBox).Clear()
            End If
        Next

        CreateOrdersDataGridView(Me.dgvOrderList)
    End Sub

#End Region

#Region "   Methods   "

    Private Sub ClearSearchTextBoxes(pnl As Panel, txt As TextBox)

        For Each c In pnl.Controls
            If TypeOf (c) Is TextBox Then
                If CType(c, TextBox).Name <> txt.Name Then
                    CType(c, TextBox).Clear()
                End If
            End If
        Next

    End Sub

    Private Sub ClearSearchTextBoxes()

        For Each c In Me.pnlOrders.Controls
            If TypeOf (c) Is TextBox Then
                CType(c, TextBox).Clear()
            End If
        Next

    End Sub

    Private Sub OrderItemSelection()
        'If ExcelDataSet.OrderItemDataset Is Nothing Then Exit Sub
        Try
            If ExcelDataSet.XLDataset Is Nothing Then
                pnlExcelSpreadsheetNotLoaded.Visible = True
                Exit Sub
            Else
                If bEndProcessing = True Then
                    bEndProcessing = False
                    Exit Sub
                End If
                pnlExcelSpreadsheetNotLoaded.Visible = False
                GetOrderItem_LNQ(IIf(rdHistory.Checked, PendingOrHistory.history, PendingOrHistory.pending))


                GetOrderForLabel_LINQ()
                GetMissingItems_LINQ()
                PopulateOrderItemDataGridView()
                PopulateOrderMissingDataGridView()
                'bEndProcessing = True
            End If

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "   DataGridView   "

#Region "   DGV Layout   "

    Private Sub CreateOrdersDataGridView(dgv As DataGridView)
        Dim colPrinted As New DataGridViewTextBoxColumn  'DataGridViewCheckBoxColumn
        Dim colOrderNo As New DataGridViewTextBoxColumn
        Dim colOrderDt As New DataGridViewTextBoxColumn
        Dim colCustNo As New DataGridViewTextBoxColumn
        Dim colAltAddr As New DataGridViewTextBoxColumn
        Dim colBillTo As New DataGridViewTextBoxColumn
        Dim colShipTo As New DataGridViewTextBoxColumn
        Dim colStatus As New DataGridViewTextBoxColumn

        With colPrinted
            .Name = "printed"
            .Width = 45
            '.HeaderText = "Prntd"
            .HeaderText = " "
            .DataPropertyName = "printed"
            '.FlatStyle = FlatStyle.Flat
            .ReadOnly = True
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End With
        With colOrderNo
            .Name = "ord_no"
            .Width = 75
            .HeaderText = " "
            '.HeaderText = "Order #"
            .DataPropertyName = "ord_no"
        End With
        With colOrderDt
            .Name = "ord_dt"
            .Width = 75
            .HeaderText = ""
            '.HeaderText = "Order Dt"
            .DataPropertyName = "ord_dt"
        End With
        With colCustNo
            .Name = "cus_no"
            .Width = 90
            .HeaderText = ""
            '.HeaderText = "Cust #"
            .DataPropertyName = "cus_no"
        End With
        With colAltAddr
            .Name = "cus_alt_adr_cd"
            .Width = 90
            .HeaderText = ""
            '.HeaderText = "Alt Addr"
            .DataPropertyName = "cus_alt_adr_cd"
        End With
        With colBillTo
            .Name = "bill_to_name"
            .Width = 250
            .HeaderText = ""
            '.HeaderText = "Bill To Name"
            .DataPropertyName = "bill_to_name"
        End With
        With colShipTo
            .Name = "ship_to_name"
            .Width = 250
            .HeaderText = ""
            '.HeaderText = "Ship To Name"
            .DataPropertyName = "ship_to_name"
        End With
        With colStatus
            .Name = "status"
            .Width = 150
            .HeaderText = ""
            '.HeaderText = "Status"
            .DataPropertyName = "status"
        End With

        dgv.Columns.Add(colPrinted)
        dgv.Columns.Add(colOrderNo)
        dgv.Columns.Add(colOrderDt)
        dgv.Columns.Add(colCustNo)
        dgv.Columns.Add(colAltAddr)
        dgv.Columns.Add(colBillTo)
        dgv.Columns.Add(colShipTo)
        dgv.Columns.Add(colStatus)
        dgv.ColumnHeadersVisible = True
        dgv.ColumnHeadersHeight = 28
        dgv.ScrollBars = ScrollBars.Vertical

    End Sub

    Private Sub CreateItemListDataGridView(dgv As DataGridView)

        bsrcItemList.DataSource = Nothing
        dgv.DataSource = Nothing
        dgv.RowCount = 0
        dgv.ColumnCount = 0

        Dim colItemNo As New DataGridViewTextBoxColumn
        Dim colItemDesc As New DataGridViewTextBoxColumn
        Dim colProdCat As New DataGridViewTextBoxColumn

        With colItemNo
            .Name = "item_no"
            .Width = 96

            .HeaderText = " "
            .DataPropertyName = "item_no"
        End With
        With colItemDesc
            .Name = "item_desc_1"
            .Width = 361
            .HeaderText = " "
            '.HeaderText = "Order #"
            .DataPropertyName = "item_desc_1"
        End With
        With colProdCat
            .Name = "prod_cat"
            .Width = 73
            .HeaderText = ""
            '.HeaderText = "Order Dt"
            .DataPropertyName = "prod_cat"
        End With

        dgv.Columns.Add(colItemNo)
        dgv.Columns.Add(colItemDesc)
        dgv.Columns.Add(colProdCat)
        dgv.ColumnHeadersVisible = True
        dgv.ColumnHeadersHeight = 28
        dgv.ScrollBars = ScrollBars.Vertical

    End Sub



    Private Sub CreateOrderItemsSelectedDataGridView(dgv As DataGridView)
        Dim colPrnt As New DataGridViewCheckBoxColumn
        Dim colSKU As New DataGridViewTextBoxColumn
        Dim colDescription As New DataGridViewTextBoxColumn
        Dim colRetail As New DataGridViewTextBoxColumn
        Dim colMfgPart As New DataGridViewTextBoxColumn
        Dim colMfgFinish As New DataGridViewTextBoxColumn
        Dim colQtyOrd As New DataGridViewTextBoxColumn
        Dim colUPC As New DataGridViewTextBoxColumn

        With colPrnt
            .Name = "x"
            .Width = 30
            .HeaderText = ""
            '.HeaderText = "Order #"
            .DataPropertyName = "x"
            .Visible = PrintColumnVisible
            .DefaultCellStyle.BackColor = Color.LightSteelBlue
            .DefaultCellStyle.ForeColor = Color.LightSteelBlue
            .DisplayIndex = 0
        End With
        With colSKU
            .Name = "SKU"
            .Width = 80
            .HeaderText = "SKU"
            '.HeaderText = "Order #"
            .DataPropertyName = "SKU"
        End With
        With colDescription
            .Name = "Description"
            .Width = 200
            .HeaderText = "Description"
            '.HeaderText = "Order Dt"
            .DataPropertyName = "Description"
        End With
        With colRetail
            .Name = "Retail"
            .Width = 75
            .HeaderText = "Retail"
            '.HeaderText = "Cust #"
            .DataPropertyName = "Retail"
            .DefaultCellStyle.Format = "C2"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        With colMfgPart
            .Name = "MfgPart"
            .Width = 70
            .HeaderText = "Item"
            '.HeaderText = "Alt Addr"
            .DataPropertyName = "MfgPart"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        With colMfgFinish
            .Name = "MfgFinish"
            .Width = 50
            .HeaderText = "Finish"
            '.HeaderText = "Bill To Name"
            .DataPropertyName = "MfgFinish"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        With colQtyOrd
            .Name = "QtyOrd"
            .Width = 45
            .HeaderText = "QtyOrd"
            '.HeaderText = "Bill To Name"
            .DataPropertyName = "QtyOrd"
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        dgv.Font = New Font("Arial", 8, FontStyle.Regular)
        dgv.Columns.Add(colSKU)
        dgv.Columns.Add(colDescription)
        dgv.Columns.Add(colRetail)
        dgv.Columns.Add(colMfgPart)
        dgv.Columns.Add(colMfgFinish)
        dgv.Columns.Add(colQtyOrd)
        dgv.Columns.Add(colPrnt)
        'For UPC with SKU added Datasets, add the UPC Column
        If ExcelDataSet.ImportType = "UPC" Then
            With colUPC
                .Name = "UPC"
                .Width = 45
                .HeaderText = "UPC"
                '.HeaderText = "Bill To Name"
                .DataPropertyName = "UPC"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With
            dgv.Columns.Add(colUPC)
        End If
        dgv.ColumnHeadersVisible = True
        dgv.ColumnHeadersHeight = 16
        dgv.ScrollBars = ScrollBars.Both
        dgv.AllowUserToAddRows = False
    End Sub
    Private Sub FormatOrderItemsSelectedDataGridView()
        Try
            With dgvOrderItemsSelected
                'column widths
                .Columns("x").Width = 30
                .Columns("SKU").Width = 80
                .Columns("Description").Width = 200
                .Columns("Retail").Width = 75
                .Columns("MfgPart").Width = 70
                .Columns("MfgFinish").Width = 50
                .Columns("QtyOrd").Width = 45
                'column visibility
                .Columns("x").Visible = True
                'column header text
                .Columns("MfgPart").HeaderText = "Item"
                .Columns("MfgFinish").HeaderText = "Finish"
                'column format
                .Columns("Retail").DefaultCellStyle.Format = "C2"
                .Columns("QtyOrd").DefaultCellStyle.Format = "N0"
                'forecolor
                .Columns("x").DefaultCellStyle.ForeColor = Color.LightSteelBlue
                Try
                    If ExcelDataSet.ImportType = "UPC" Then
                        .Columns("UPC").Width = 45
                    End If

                Catch ex As Exception

                End Try

                .RowHeadersVisible = False
                .Columns("x").HeaderText = ""
            End With

        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub CreateMissingDataGridView(dgv As DataGridView)
        Dim colSKU As New DataGridViewTextBoxColumn
        Dim colDescription As New DataGridViewTextBoxColumn
        Dim colRetail As New DataGridViewTextBoxColumn
        Dim colMfgPart As New DataGridViewTextBoxColumn
        Dim colMfgFinish As New DataGridViewTextBoxColumn
        'Dim colQtyOrd As New DataGridViewTextBoxColumn
        Dim colUPC As New DataGridViewTextBoxColumn
        Dim colComment As New DataGridViewTextBoxColumn

        With colSKU
            .Name = "SKU"
            .Width = 80
            .HeaderText = "SKU"
            '.HeaderText = "Order #"
            .DataPropertyName = "sku"
        End With
        With colDescription
            .Name = "Description"
            .Width = 200
            .HeaderText = "Description"
            '.HeaderText = "Order Dt"
            .DataPropertyName = "item_desc_1"
        End With
        With colRetail
            .Name = "Retail"
            .Width = 75
            .HeaderText = "Retail"
            '.HeaderText = "Cust #"
            .DataPropertyName = "retail"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        With colMfgPart
            .Name = "MfgPart"
            .Width = 70
            .HeaderText = "Item"
            '.HeaderText = "Alt Addr"
            .DataPropertyName = "item_no"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        With colMfgFinish
            .Name = "MfgFinish"
            .Width = 50
            .HeaderText = "Finish"
            '.HeaderText = "Bill To Name"
            .DataPropertyName = "pick_seq"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        'With colQtyOrd
        '    .Name = "QtyOrd"
        '    .Width = 45
        '    .HeaderText = "Qty"
        '    '.HeaderText = "Bill To Name"
        '    .DataPropertyName = "qty_ordered"
        '    .DefaultCellStyle.Format = "N0"
        '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'End With

        'If ExcelDataSet.ImportType = "UPC" Then
        With colUPC
            .Name = "UPC"
            .Width = 45
            .HeaderText = "UPC"
            '.HeaderText = "Bill To Name"
            .DataPropertyName = "upc"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

        With colComment
            .Name = "Comment"
            .Width = 150
            .HeaderText = "Comment"
            '.HeaderText = "Bill To Name"
            .DataPropertyName = "cmt"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        With dgv.Columns
            .Add(colSKU)
            .Add(colDescription)
            .Add(colRetail)
            .Add(colMfgPart)
            .Add(colMfgFinish)
            '.Add(colQtyOrd)
            .Add(colUPC)
            .Add(colComment)
        End With
        dgv.ColumnHeadersVisible = True
        dgv.ColumnHeadersHeight = 16
        dgv.ScrollBars = ScrollBars.Both
        dgv.AllowUserToAddRows = False


    End Sub








    Private Sub CreateXLListDataGridView(dgv As DataGridView)
        Dim colSKU As New DataGridViewTextBoxColumn
        Dim colDescription As New DataGridViewTextBoxColumn
        Dim colRetail As New DataGridViewTextBoxColumn
        Dim colMfgItemNo As New DataGridViewTextBoxColumn
        Dim colMfgFinishNo As New DataGridViewTextBoxColumn
        Dim colUPC As New DataGridViewTextBoxColumn


        With colSKU
            .Name = "SKU"
            .Width = 80
            .HeaderText = "SKU"
            '.HeaderText = "Order #"
            .DataPropertyName = "SKU"
        End With
        With colDescription
            .Name = "Description"
            .Width = 200
            .HeaderText = "Description"
            '.HeaderText = "Order Dt"
            .DataPropertyName = "Description"
        End With
        With colRetail
            .Name = "Retail"
            .Width = 75
            .HeaderText = "Retail"
            '.HeaderText = "Cust #"
            .DataPropertyName = "Retail"
            .DefaultCellStyle.Format = "C2"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        With colMfgItemNo
            .Name = "MfgPart"
            .Width = 70
            .HeaderText = "Item"
            '.HeaderText = "Alt Addr"
            .DataPropertyName = "MfgItemNo"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        With colMfgFinishNo
            .Name = "MfgFinish"
            .Width = 50
            .HeaderText = "Finish"
            '.HeaderText = "Bill To Name"
            .DataPropertyName = "MfgFinishNo"
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        With colUPC
            .Name = "UPC"
            .Width = 80
            .HeaderText = "UPC"
            '.HeaderText = "Order #"
            .DataPropertyName = "UPC"
        End With

        dgv.Font = New Font("Arial", 8, FontStyle.Regular)
        dgv.Columns.Add(colSKU)
        dgv.Columns.Add(colDescription)
        dgv.Columns.Add(colRetail)
        dgv.Columns.Add(colMfgItemNo)
        dgv.Columns.Add(colMfgFinishNo)
        dgv.Columns.Add(colUPC)
        dgv.ColumnHeadersVisible = True
        dgv.ColumnHeadersHeight = 16
        dgv.ScrollBars = ScrollBars.Both

    End Sub

#End Region

#Region "   Events   "
    Private Sub dgvOrderList_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOrderList.CellEnter
        If IsLoading = True Then Exit Sub
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        'dgv.EndEdit()
        ExcelDataSet.OrderNo = dgv(1, e.RowIndex).Value
        If ExcelDataSet.OrderNo = "1" Then
            bEndProcessing = True
            Exit Sub
        End If
        If Me.rdHistory.Checked Then
            If dgvOrderList.Rows.Count > 100 Then
                Exit Sub
            End If
        End If
        OrderItemSelection()
    End Sub

#End Region

#Region "   Methods   "

    Private Sub PopulateOrderItemDataGridView()
        Dim dgv As DataGridView = DirectCast(Me.dgvOrderItemsSelected, DataGridView)

        With dgv
            '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .RowHeadersVisible = False
            Me.bsrcOrderItemsSelected.DataSource = Nothing
            CreateOrderItemsSelectedDataGridView(dgv)
            Me.bsrcOrderItemsSelected.DataSource = ExcelDataSet.LabelDataTable
            .DataSource = Me.bsrcOrderItemsSelected
        End With
    End Sub

    Private Sub PopulateOrderMissingDataGridView()
        Dim dgv As DataGridView = DirectCast(Me.dgvSpecialOrder, DataGridView)

        With dgv
            .RowHeadersVisible = False
            Me.bsrcMissingData.DataSource = Nothing
            CreateMissingDataGridView(dgv)
            Me.bsrcMissingData.DataSource = ExcelDataSet.MissingDataTable
            .DataSource = Me.bsrcMissingData
        End With
    End Sub

    Private Sub DisposeOfTable()
        ExcelDataSet.LabelDataTable.Dispose()
        ExcelDataSet.LabelDataTable = Nothing
        TableHasBeenCreated = False
    End Sub

#End Region

#End Region

#Region "   BarTender   "

#Region "   Controls   "

    ''' <summary>
    ''' Show the preview of the first label.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnFirst_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFirst.Click
        currentPage = 1
        ShowPreview()
    End Sub

    ''' <summary>
    ''' Show the preview of the previous label.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnPrev_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPrev.Click
        currentPage -= 1
        ShowPreview()
    End Sub

    ''' <summary>
    ''' Show the preview of the next label.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnNext_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNext.Click
        currentPage += 1
        ShowPreview()
    End Sub

    ''' <summary>
    ''' Show the preview of the last label.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnLast_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLast.Click
        currentPage = totalPages
        ShowPreview()
    End Sub

    Private Sub cboPrinters_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPrinters.SelectedIndexChanged
        Dim cbo As ComboBox = DirectCast(sender, ComboBox)
        ExcelDataSet.PrinterName = cbo.SelectedItem
        Try
            format.PrintSetup.PrinterName = ExcelDataSet.PrinterName
            'Select Case ItemsOrOrders
            '    Case "Orders"
            '        If dgvOrderItemsSelected.RowCount > 0 Then
            '            PreviewLabel(ItemsOrOrders)
            '        End If
            '    Case "Items"


            'End Select


        Catch ex As Exception

        End Try
    End Sub

    Private Sub picExcel_Click(sender As System.Object, e As System.EventArgs) Handles picExcel.Click, lblPriceSheet.Click, lblLoadExcelPriceList.Click
        dgvExcelPriceList.Visible = True
        picPreview.Visible = False

    End Sub

    Private Sub picBartender_Click(sender As System.Object, e As System.EventArgs) Handles picBartender.Click, lblBartender.Click, lblLoadBarTenderLabel.Click
        dgvExcelPriceList.Visible = False
        picPreview.Visible = True
        'pnlSelectItemsToPrint.Visible = False
    End Sub


#End Region

#Region "   Methods   "

    Private Sub OpenBartenderFormat(op As OpenFileDialog)

        ' Close the previous format.
        Try
            If format IsNot Nothing Then
                format.Close(SaveOptions.DoNotSaveChanges)
            End If
        Catch ex As Exception

        End Try

        ' We need to delete the files associated with the last format.
        Dim files() As String = Directory.GetFiles(previewPath)
        For Each filename As String In files
            File.Delete(filename)
        Next filename

        ' Put the UI back into a non-preview state.
        DisablePreview()

        ' Open the format.
        ExcelDataSet.BTLabelPathFileName = op.FileName
        lblBartender.Text = Path.GetFileName(op.FileName)
        picBartender.Visible = True
        picPreview.Visible = True
        Try
            'format = btEng.OpenLabelFormat(op.FileName, )
            format = engine.Documents.Open(op.FileName)
        Catch comException As System.Runtime.InteropServices.COMException
            MessageBox.Show(Me, String.Format("Unable to open format: {0}" & Constants.vbLf & "Reason: {1}", op.FileName, comException.Message), appName)
            format = Nothing
        End Try

        ' Only allow preview button if we successfully loaded the format.
        'btnPreview.Enabled = (format IsNot Nothing)

        If format IsNot Nothing Then
            ' Select the printer in use by the format.
            cboPrinters.SelectedItem = format.PrintSetup.PrinterName
        End If

        Cursor.Current = Cursors.Default

        ' Restore some controls.
        'btnOpen.Enabled = True
        cboPrinters.Enabled = True

    End Sub
    Private Sub CloseBartenderLabelFormat()
        ' Close the previous format.

        Try
            If format IsNot Nothing Then
                format.Close(SaveOptions.DoNotSaveChanges)
            End If

        Catch ex As Exception

        End Try

        ' We need to delete the files associated with the last format.
        Dim files() As String = Directory.GetFiles(previewPath)
        For Each filename As String In files
            File.Delete(filename)
        Next filename

        ' Put the UI back into a non-preview state.
        DisablePreview()
        picPreview.Visible = True
    End Sub
    Private Sub DisablePreview()
        picPreview.ImageLocation = ""
        'picPreview.Visible = False

        btnPrev.Enabled = False
        btnFirst.Enabled = False
        lblNumPreviews.Visible = False
        btnNext.Enabled = False
        btnLast.Enabled = False
    End Sub

    Private Sub PreviewLabel(ItemsOrOrders As String)

        Select Case ItemsOrOrders
            Case "Orders"
                ''Check for problems first, No data, No orderNo, No Label selected etc...
                'If ExcelDataSet.BTLabelPathFileName = "" Then
                '    MsgBox("A BarTender label does not appear to have been selected.  Select a label format to preview.")
                '    Exit Sub
                'End If
                If ExcelDataSet.LabelDataTable Is Nothing Then
                    'If No Data, then check to see if this is Drag And Drop, and data DOES exist in the OrderItemList DataGridView
                    Dim dgv As DataGridView = Me.dgvOrderItemsSelected
                    If dgv.Rows.Count > 0 Then
                        ExcelDataSet.LabelDataTable = CreateItemLabelsToPrintDataTable()

                        For Each r As DataGridViewRow In dgv.Rows
                            If ExcelDataSet.ImportType = "SKU" Then
                                ExcelDataSet.LabelDataTable.Rows.Add(New Object() {r.Cells(0).Value, r.Cells(1).Value, r.Cells(2).Value, r.Cells(3).Value, r.Cells(4).Value, _
                                                                                   r.Cells(5).Value, r.Cells(6).Value})

                            ElseIf ExcelDataSet.ImportType = "UPC" Then
                                ExcelDataSet.LabelDataTable.Rows.Add(New Object() {r.Cells(0).Value, r.Cells(1).Value, r.Cells(2).Value, r.Cells(3).Value, r.Cells(4).Value, _
                                                                                   r.Cells(5).Value, r.Cells(6).Value, r.Cells(7).Value})

                            End If
                        Next
                    Else
                        Exit Sub
                    End If
                ElseIf ExcelDataSet.LabelDataTable.Rows.Count = 0 Then

                    If ExcelDataSet.OrderNo = "" And CType(dgvOrderItemsSelected, DataGridView).RowCount > 0 Then
                        PreviewLabel("Items")
                    Else
                        MsgBox("An Order from the Order List does not appear to have been selected.  Select an Order to preview.")

                        Exit Sub
                    End If

                End If
            Case "Items"
                Dim dgv As DataGridView = Me.dgvOrderItemsSelected
                ExcelDataSet.LabelDataTable = CreateItemLabelsToPrintDataTable()

                For Each r As DataGridViewRow In dgv.Rows
                    ExcelDataSet.LabelDataTable.Rows.Add(New Object() {r.Cells(0).Value, r.Cells(1).Value, r.Cells(2).Value, r.Cells(3).Value, r.Cells(4).Value, _
                                                                       r.Cells(5).Value, r.Cells(6).Value})
                Next

        End Select





        'btnOpen.Enabled = False
        cboPrinters.Enabled = False
        'btnPreview.Enabled = False
        Try
            If format IsNot Nothing Then
                format.Close(SaveOptions.DoNotSaveChanges)
            End If
        Catch ex As Exception
            'If DirectCast(ex, Seagull.BarTender.Print.PrintEngineException).ErrorId = 2 Then
            '    MsgBox("You must load a Bartener Label before labels can be Previewed or Printed.", MsgBoxStyle.OkOnly, "Bartender Label not loaded.")
            '    Exit Sub
            'End If

        End Try


        ' We need to delete the files associated with the last format.
        Dim files() As String = Directory.GetFiles(previewPath)
        For Each filename As String In files
            File.Delete(filename)
        Next filename

        ' Put the UI back into a non-preview state.
        DisablePreview()

        If LoadLabelData(ExcelDataSet.LabelDataTable) = False Then
            ExcelDataSet.LabelDataTable.Dispose()
            ExcelDataSet.LabelDataTable = Nothing
            TableHasBeenCreated = False
            Exit Sub
        End If
        Try
            format = engine.Documents.Open(ExcelDataSet.BTLabelPathFileName)

            CType(format.DatabaseConnections(DatabaseConnectionNameInLabel), TextFile).FileName = ExcelDataSet.LabelDataSourcePathFile
            format.PrintSetup.PrinterName = ExcelDataSet.PrinterName


            ' Set control states to show working. These will be reset when the work completes.
            picUpdating.Visible = True
            dgvExcelPriceList.Visible = False
            picPreview.Visible = True
            'Me.btnPrint.Enabled = True

            ' Have the background worker export the BarTender format.
            Try
                backgroundWorker.RunWorkerAsync(format)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try

    End Sub

    Private Function SelectedLableData(dt As DataTable) As DataTable
        'Added back in....

        Dim rws As Integer = 0

        Dim cls As Integer = dt.Columns.Count - 1

        Dim rw As DataRow
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim qty As Integer = 0

        If dt Is Nothing Then
            MsgBox("An Order has not been selected.  Choose an Order and try again.")
            Return Nothing

        End If

        For Each rw In dt.Rows
            If rw("x") = True Then
                rws = rws + CInt(rw(6))
            End If
        Next



        Dim tmpItems As String = ""


        Dim arrItems(rws - 1, cls - 1) As String
        For Each rw In dt.Rows
            qty = CInt(rw(6))
            For j = 0 To qty - 1
                arrItems(i, 0) = rw(1).ToString
                arrItems(i, 1) = rw(2).ToString
                arrItems(i, 2) = rw(3).ToString
                arrItems(i, 3) = rw(4).ToString
                arrItems(i, 4) = rw(5).ToString
                arrItems(i, 5) = rw(6).ToString
                i = i + 1
            Next j
        Next

        'Create the temporary Text File for the Label Data Source
        Try

            retcall = "tmpItems = Me.WriteTextFile(arrItems), Array UBound: " & arrItems.Length.ToString
            ExcelDataSet.LabelDataSourcePathFile = Me.WriteTextFile(arrItems)

        Catch ex As Exception
            'MsgBox("Method: " & RetMethod & ", Call: " & retcall)
        End Try

        Return dt
    End Function

    Private Sub PreviewEmptyLabel()

        ' Delete any existing files.
        Dim oldFiles() As String = Directory.GetFiles(previewPath, "*.*")
        For index As Integer = 0 To oldFiles.Length - 1
            File.Delete(oldFiles(index))
        Next index

        ' Export the format's print previews.
        format.ExportPrintPreviewToFile(previewPath, "PrintPreview%PageNumber%.jpg", ImageType.JPEG, Seagull.BarTender.Print.ColorDepth.ColorDepth24bit, New Resolution(picPreview.Width, picPreview.Height), System.Drawing.Color.White, OverwriteOptions.Overwrite, True, True, messages)
        Dim files() As String = Directory.GetFiles(previewPath, "*.*")
        totalPages = files.Length
        ShowPreview()
    End Sub

    ''' <summary>
    ''' Show the preview of the current page.
    ''' </summary>
    Private Sub ShowPreview()
        ' Our current preview number shouldn't be out of range,
        ' but we'll practice good programming by checking it.
        If (currentPage < 1) OrElse (currentPage > totalPages) Then
            currentPage = 1
        End If

        ' Update the page label and the preview Image.
        lblNumPreviews.Text = String.Format("Page {0} of {1}", currentPage, totalPages)
        Dim filename As String = String.Format("{0}\PrintPreview{1}.jpg", previewPath, currentPage)

        picPreview.ImageLocation = filename
        picPreview.Visible = True

        ' Enable or Disable controls as needed.
        If currentPage = 1 Then
            btnPrev.Enabled = False
            btnFirst.Enabled = False
        Else
            btnPrev.Enabled = True
            btnFirst.Enabled = True
        End If

        If currentPage = totalPages Then
            btnNext.Enabled = False
            btnLast.Enabled = False
        Else
            btnNext.Enabled = True
            btnLast.Enabled = True
        End If
    End Sub

#End Region

#Region "   Background Worker   "

    Private Sub backgroundWorker_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles backgroundWorker.DoWork
        Dim format As LabelFormatDocument = CType(e.Argument, LabelFormatDocument)

        ' Delete any existing files.
        Dim oldFiles() As String = Directory.GetFiles(previewPath, "*.*")
        For index As Integer = 0 To oldFiles.Length - 1
            File.Delete(oldFiles(index))
        Next index

        ' Export the format's print previews.
        format.ExportPrintPreviewToFile(previewPath, "PrintPreview%PageNumber%.jpg", ImageType.JPEG, Seagull.BarTender.Print.ColorDepth.ColorDepth24bit, New Resolution(picPreview.Width, picPreview.Height), System.Drawing.Color.White, OverwriteOptions.Overwrite, True, True, messages)
        Dim files() As String = Directory.GetFiles(previewPath, "*.*")
        totalPages = 0
        totalPages = files.Length
    End Sub

    Private Sub backgroundWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles backgroundWorker.RunWorkerCompleted
        ' Report any messages.
        If messages IsNot Nothing Then
            If messages.Count > 5 Then
                MessageBox.Show(Me, "There are more than 5 messages from the print preview. Only the first 5 will be displayed.", appName)
            End If
            Dim count As Integer = 0
            For Each message As Seagull.BarTender.Print.Message In messages
                MessageBox.Show(Me, message.Text, appName)
                ' if (++count >= 5)
                count += 1
                If count >= 5 Then
                    Exit For
                End If
            Next message
        End If

        picUpdating.Visible = False

        'btnOpen.Enabled = True
        'btnPreview.Enabled = True
        cboPrinters.Enabled = True

        ' Only enable the preview if we actual got some pages.
        If totalPages <> 0 Then
            lblNumPreviews.Visible = True

            currentPage = 1
            ShowPreview()
        End If
    End Sub

#End Region

#End Region


#Region "   Drag and Drop   "

#Region "   Drag Drop for Advanced Sort DataGridView  "

    Private Sub dgvSortableColumns_DragLeave(sender As Object, e As System.EventArgs) Handles dgvSortOrder.DragLeave
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)

        For Each r As DataGridViewRow In dgv.Rows
            If r.Cells(0).Value = CellValue Then
                dgv.Rows.Remove(r)
                CellValue = ""
            End If
        Next

        'UnselectCells()
    End Sub

    Private Sub dgvSortOrder_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvSortOrder.MouseDown
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)

        If dgv.Name = "dgvSortableColumns" Then

            If e.Button = MouseButtons.Left Then
                Dim info As DataGridView.HitTestInfo = dgv.HitTest(e.X, e.Y)
                If info.RowIndex >= 0 Then

                    Dim view As String = dgv(info.ColumnIndex, info.RowIndex).Value.ToString
                    If view IsNot Nothing Then
                        dgv.DoDragDrop(view, DragDropEffects.Copy)
                    End If

                    DragFromDGV = dgv.Name

                End If
            End If

        Else

            If e.Button = MouseButtons.Left Then
                Dim info As DataGridView.HitTestInfo = dgv.HitTest(e.X, e.Y)
                If info.RowIndex >= 0 Then
                    Dim view As String = dgv(info.ColumnIndex, info.RowIndex).Value.ToString
                    If view IsNot Nothing Then
                        CellValue = view
                        dgv.DoDragDrop(view, DragDropEffects.Copy)

                        DragFromDGV = dgv.Name

                    End If

                End If
            End If

        End If
        ' UnselectCells()
    End Sub
    Private Sub pnlSortOrder_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles pnlSortOrder.DragEnter
        Dim dgv As DataGridView = Me.dgvSortOrder
        DragToDGV = dgv.Name
        Try
            For Each r As DataGridViewRow In dgv.Rows
                If r.Cells(0).Value = CellValue Then
                    dgv.Rows.Remove(r)
                    CellValue = ""
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub
    Private Sub dgv_DragEnter(sender As Object, e As DragEventArgs) Handles dgvSortableColumns.DragEnter, dgvSortOrder.DragEnter
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)

        DragToDGV = dgv.Name

        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
        UnselectCells()
    End Sub

    Private Sub dgv_DragDrop(sender As Object, e As DragEventArgs) Handles dgvSortOrder.DragDrop
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        Dim str As String = e.Data.GetData(DataFormats.Text).ToString
        Dim strlst As String
        For Each o As Object In colSort
            strlst = DirectCast(o, MassasrelliLabelPrinterLNQ.LabelSortOrder).Column.ToString.Trim
            If strlst = str Then
                MsgBox("Item " & str & " already exists on Sort List")
                Exit Sub
            End If
        Next

        Dim clientpoint As Point = dgv.PointToClient(New Point(e.X, e.Y))
        Dim hit As DataGridView.HitTestInfo = dgv.HitTest(clientpoint.X, clientpoint.Y)


        If hit.ColumnIndex <> -1 Then
            dgv(hit.ColumnIndex, hit.RowIndex).Value = str
        Else
            colSort.Add(New LabelSortOrder(str))
            bsrcSortable.DataSource = Nothing
            bsrcSortable.DataSource = colSort
            dgvSortOrder.DataSource = bsrcSortable
        End If
        UnselectCells()
    End Sub

    Private Sub UnselectCells()
        Dim dgv As DataGridView = DirectCast(dgvSortableColumns, DataGridView)
        For Each r As DataGridViewRow In dgv.Rows
            r.Cells(0).Selected = False
        Next

        dgv = DirectCast(dgvSortOrder, DataGridView)
        For Each r As DataGridViewRow In dgv.Rows
            r.Cells(0).Selected = False
        Next

        dgv = DirectCast(dgvItemList, DataGridView)
        For Each r As DataGridViewRow In dgv.Rows
            r.Cells(0).Selected = False
        Next

        'dgv = DirectCast(dgvItemsToPrint, DataGridView)
        'For Each r As DataGridViewRow In dgv.Rows
        '    r.Cells(0).Selected = False
        'Next


    End Sub

    Private Sub btnSetSortOrder_Click(sender As System.Object, e As System.EventArgs) Handles btnSetSortOrder.Click
        If pnlSortOrder.Visible = False Then
            pnlSortOrder.Visible = True
            btnSetSortOrder.ImageKey = "BTRemove_02.ico"
            pnlSortOrder.BringToFront()

        Else
            pnlSortOrder.Visible = False
            btnSetSortOrder.ImageKey = "BTAdd_02.ico"
        End If

    End Sub
#End Region

#Region "   DragDrop for Item Master DataGridView  "

    ''' <summary>
    ''' Drag Items from Item Search List always retrieves the ItenNo where Column Number is 0 in this code: Dim view As String = dgv(0, info.RowIndex).Value.ToString.Trim
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks> 'DragEnter below is to remove an item from dgvItemList when selecting single items to be printed.  </remarks>

    Private Sub MassarelliLabelPrinter_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If (ItemsOrOrders = "Items" Or ItemsOrOrders = "Orders") Then
            Dim dgv As DataGridView = Me.dgvOrderItemsSelected
            Try
                'dgv.Rows.RemoveAt(RowIndex)
                'For Each r As DataGridViewRow In dgv.Rows
                '    If r.Cells(0).Value.ToString = CellValue Then
                '        dgv.Rows.Remove(r)
                '        CellValue = ""
                '    End If
                'Next

            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try
            'If dgv.Rows.Count = 0 Then pnlDragOffToRemove.Visible = False
        End If

        If (ItemsOrOrders = "Items" Or ItemsOrOrders = "Orders") Then
            dgvOrderItemsSelected.AllowDrop = True
            If TableHasBeenCreated = False Then
                tblLabelData = CreateItemLabelsToPrintDataTable()
                ItemLabelsDataTable = tblLabelData
                TableHasBeenCreated = True
            End If
        End If

    End Sub

    Private Sub dgvItemMaster_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvExcelPriceList.MouseDown
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        Try
            If dgv.Name = "dgvItemList" Then

                If e.Button = MouseButtons.Left Then
                    Dim info As DataGridView.HitTestInfo = dgv.HitTest(e.X, e.Y)
                    If info.RowIndex >= 0 Then
                        Dim view(1) As String
                        view(0) = dgv(0, info.RowIndex).Value.ToString.Trim
                        view(1) = dgv(1, info.RowIndex).Value.ToString.Trim

                        CellValue = view(0).ToString.Trim

                        Dim str As String = String.Join(",", view)
                        If str IsNot Nothing Then
                            dgv.DoDragDrop(str, DragDropEffects.Copy)
                        End If

                        DragFromDGV = dgv.Name
                    End If
                End If
            ElseIf dgv.Name = "dgvExcelPriceList" Then

                ' Get the index of the item the mouse is below.
                rowIndexFromMouseDown = dgv.HitTest(e.X, e.Y).RowIndex

                If rowIndexFromMouseDown <> -1 Then

                    ' Remember the point where the mouse down occurred. 
                    ' The DragSize indicates the size that the mouse can move 
                    ' before a drag event should be started.                
                    Dim dragSize As Size = SystemInformation.DragSize

                    ' Create a rectangle using the DragSize, with the mouse position being
                    ' at the center of the rectangle.

                    'dragBoxFromMouseDown = New Rectangle(New Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize)
                    Dim dropEffect As DragDropEffects = dgv.DoDragDrop(dgv.SelectedRows, DragDropEffects.Move) 'This for Multi Select Rows
                    'Dim dropEffect As DragDropEffects = dgvLoc002Warehouse.DoDragDrop(dgvLoc002Warehouse.Rows(rowIndexFromMouseDown), DragDropEffects.Move) ' This for a Single Row

                Else

                    ' Reset the rectangle if the mouse is not over an item in the ListBox.
                    dragBoxFromMouseDown = Rectangle.Empty
                End If

            Else
                If dgv.Name = "dgvOrderItemsSelected" Then
                    'If ItemsOrOrders = "Items" Then
                    If e.Button = MouseButtons.Left Then

                        Dim info As DataGridView.HitTestInfo = dgv.HitTest(e.X, e.Y)
                        'If info.ColumnIndex = 0 Then 'This is the Print Checkbox Column
                        '    If dgv(info.ColumnIndex, info.RowIndex).Value = True Then
                        '        dgv(info.ColumnIndex, info.RowIndex).Value = False
                        '    Else
                        '        dgv(info.ColumnIndex, info.RowIndex).Value = 1
                        '    End If
                        '    Exit Sub
                        'End If
                        If info.RowIndex >= 0 Then
                            'Dim view As String = dgv(4, info.RowIndex).Value.ToString
                            Dim view As String = dgv(1, info.RowIndex).Value.ToString.Trim
                            If view IsNot Nothing Then
                                CellValue = view
                                RowIndex = info.RowIndex
                                dgv.DoDragDrop(view, DragDropEffects.Copy)

                                DragFromDGV = dgv.Name
                            End If

                        End If
                    End If
                    'end If

                End If


            End If
            'UnselectCells()
            'dgv(0, 1).Value = True
            FormatOrderItemsSelectedDataGridView()
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub dgvOrderItemsSelected_DragEnter(sender As Object, e As DragEventArgs) Handles dgvOrderItemsSelected.DragEnter

        'If ItemsOrOrders = "Items" Then
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Copy
        ElseIf e.Data.GetDataPresent(DataFormats.CommaSeparatedValue) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.Move
            'e.Effect = DragDropEffects.None
        End If
        'End If

        UnselectCells()
    End Sub

    Private Sub dgv_ItemsToPrintDragDrop(sender As Object, e As DragEventArgs) Handles dgvOrderItemsSelected.DragDrop
        'Test if Item is already on the list.
        'If Me.DragFromDGV = "dgvExcelPriceList" Then

        'ElseIf Me.DragFromDGV = "dgvItemList" Then
        Try
            For Each format As String In e.Data.GetFormats()

                For Each oRow As DataGridViewRow In e.Data.GetData(format)

                    Dim arr() As String = {False, "", "", "", "", "", 0, ""}
                    arr(0) = False
                    arr(1) = oRow.Cells(0).Value
                    arr(2) = oRow.Cells(1).Value
                    arr(3) = oRow.Cells(2).Value
                    arr(4) = oRow.Cells(3).Value
                    arr(5) = oRow.Cells(4).Value
                    arr(6) = 0
                    arr(7) = oRow.Cells(5).Value

                 
                    Try
                        For Each r As DataRow In ItemLabelsDataTable.Rows
                            If r.Item("MfgPart").ToString = arr(4) Then
                                Dim ret = MsgBox("Item " & arr(4) & " " & arr(2) & " Finish " & arr(5) & " already exists on Printing List" & _
                                          vbCrLf & "Add it anyway?", MsgBoxStyle.YesNo, "Item Already on the Print List")
                                If ret = MsgBoxResult.No Then
                                    Exit Sub
                                Else
                                    Exit For
                                End If
                            End If
                        Next

                    Catch ex As Exception

                    End Try
                    
                    'CellValue = ""

            Dim dgv As DataGridView = DirectCast(sender, DataGridView)
            ' Dim rw As DataRow
            Dim tblLabelData As DataTable

                    'Dim clientpoint As Point = dgv.PointToClient(New Point(e.X, e.Y))
                    'Dim hit As DataGridView.HitTestInfo = dgv.HitTest(clientpoint.X, clientpoint.Y)

                    If TableHasBeenCreated = False Then
                        tblLabelData = CreateItemLabelsToPrintDataTable()
                        ItemLabelsDataTable = tblLabelData
                        TableHasBeenCreated = True
                    End If

                    'Dim str As String = e.Data.GetData(DataFormats.Text)
                    'Dim view() As String = str.Split(",")

            'If hit.ColumnIndex <> -1 Then
            'dgv(hit.ColumnIndex, hit.RowIndex).Value = str
            'Else
            If ExcelDataSet.ImportType = "SKU" Then
                        'Dim objLabelData(6) As Object
                        'itmToPrint = New ItemsToPrintFromItemMaster(False, view(0).ToString, view(1).ToString, view(2).ToString, view(3).ToString, view(4).ToString, 0)
                        'objLabelData(0) = itmToPrint.x
                        'objLabelData(1) = itmToPrint.SKU
                        'objLabelData(2) = itmToPrint.Description
                        'objLabelData(3) = itmToPrint.Retail
                        'objLabelData(4) = itmToPrint.MfgPart
                        'objLabelData(5) = itmToPrint.MfgFinish
                        'objLabelData(6) = CDec(itmToPrint.QtyOrd)

                        'ItemLabelsDataTable.Rows.Add(objLabelData)
                        ItemLabelsDataTable.Rows.Add(arr)
                        bsrcItemsToPrint.DataSource = Nothing
                dgvOrderItemsSelected.DataSource = Nothing
                bsrcItemsToPrint.DataSource = ItemLabelsDataTable
                dgvOrderItemsSelected.DataSource = bsrcItemsToPrint
                'UnselectCells()
                'If dgv.Rows.Count > 0 Then pnlDragOffToRemove.Visible = True
                'DisposeOfTable()
            ElseIf ExcelDataSet.ImportType = "UPC" Then
                        'Dim objLabelData(7) As Object
                        'itmToPrint = New ItemsToPrintFromItemMaster(False, view(0).ToString, view(1).ToString, view(2).ToString, view(3).ToString, view(4).ToString, 0, view(5).ToString)
                        'objLabelData(0) = itmToPrint.x
                        'objLabelData(1) = itmToPrint.SKU
                        'objLabelData(2) = itmToPrint.Description
                        'objLabelData(3) = itmToPrint.Retail
                        'objLabelData(4) = itmToPrint.MfgPart
                        'objLabelData(5) = itmToPrint.MfgFinish
                        'objLabelData(6) = CDec(itmToPrint.QtyOrd)
                        'objLabelData(7) = CDec(itmToPrint.UPC)
                        
                        ItemLabelsDataTable.Rows.Add(arr)

                        'ItemLabelsDataTable.Rows.Add(objLabelData)
              

                    End If

                    'If dgv.Rows.Count > 0 Then pnlDragOffToRemove.Visible = True
                Next

            Next
            'Required to reset the format of the DataGridView after resetting the DataSource
            bsrcItemsToPrint.DataSource = Nothing
            dgvOrderItemsSelected.DataSource = Nothing
            bsrcItemsToPrint.DataSource = ItemLabelsDataTable
            dgvOrderItemsSelected.DataSource = bsrcItemsToPrint
            FormatOrderItemsSelectedDataGridView()
            'End If
            UnselectCells()
            ' DisposeOfTable()
        Catch ex As Exception
        Finally

        End Try


        'End If

    End Sub


    Private Sub RemoveRow()
        Dim dgv As DataGridView = Me.dgvOrderItemsSelected
        Try
            'dgv.Rows.RemoveAt(RowIndex)
            For Each r As DataGridViewRow In dgv.Rows
                If r.Cells(0).Value.ToString = True Then
                    dgv.Rows.Remove(r)
                End If
            Next
            For Each r As DataGridViewRow In dgv.Rows
                If r.Cells(0).Value.ToString = True Then
                    dgv.Rows.Remove(r)
                End If
            Next
            bsrcItemsToPrint.DataSource = Nothing
            dgvOrderItemsSelected.DataSource = Nothing
            bsrcItemsToPrint.DataSource = ItemLabelsDataTable
            dgvOrderItemsSelected.DataSource = bsrcItemsToPrint
            FormatOrderItemsSelectedDataGridView()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#End Region



    Private Function CreateItemLabelsToPrintDataTable() As DataTable
        'Create datatable
        Dim oLabelData As New DataTable("LabelData")

        If ExcelDataSet.ImportType = "SKU" Then
            oLabelData.Columns.Add("x", GetType(Boolean))
            oLabelData.Columns.Add("SKU", GetType(String))
            oLabelData.Columns.Add("Description", GetType(String))
            oLabelData.Columns.Add("Retail", GetType(Decimal))
            oLabelData.Columns.Add("MfgPart", GetType(String))
            oLabelData.Columns.Add("MfgFinish", GetType(String))
            oLabelData.Columns.Add("QtyOrd", GetType(Decimal))
        ElseIf ExcelDataSet.ImportType = "UPC" Then
            oLabelData.Columns.Add("x", GetType(Boolean))
            oLabelData.Columns.Add("SKU", GetType(String))
            oLabelData.Columns.Add("Description", GetType(String))
            oLabelData.Columns.Add("Retail", GetType(Decimal))
            oLabelData.Columns.Add("MfgPart", GetType(String))
            oLabelData.Columns.Add("MfgFinish", GetType(String))
            oLabelData.Columns.Add("QtyOrd", GetType(Decimal))
            oLabelData.Columns.Add("UPC", GetType(String))
        End If

        Return oLabelData

    End Function

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        OrderItemSelection()
        PreviewLabel(ItemsOrOrders)
    End Sub

    Private Sub dgvOrderItemsSelected_ColumnHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvOrderItemsSelected.ColumnHeaderMouseClick
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        Dim Str As String = dgv.Columns(e.ColumnIndex).DataPropertyName
        If Me.PrintColumnVisible = False Then
            With colSort
                .Clear()
                colSort.Add(New LabelSortOrder(Str))
                bsrcSortable.DataSource = Nothing
                bsrcSortable.DataSource = colSort
                dgvSortOrder.DataSource = bsrcSortable
            End With
            OrderItemSelection()
            PreviewLabel(ItemsOrOrders)
        End If
    End Sub

    Private Sub btnSelectItemsToPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectItemsToPrint.Click
        Dim dgv As DataGridView = Me.dgvOrderItemsSelected
        If dgv.ColumnCount <= 0 Then Exit Sub

        Try

            If PrintColumnVisible = True Then
                PrintColumnVisible = False
                SKUColumnWidth = 80
                btnSelectItemsToPrint.ImageKey = "BTAdd_02.ico"
                btnSetSortOrder.Enabled = True
                lblAdvancedSort.ForeColor = SystemColors.ControlText
            Else
                PrintColumnVisible = True
                SKUColumnWidth = 50
                btnSelectItemsToPrint.ImageKey = "BTRemove_02.ico"
                btnSetSortOrder.Enabled = False
                lblAdvancedSort.ForeColor = SystemColors.ControlDarkDark
            End If
            dgv.Columns("x").Visible = PrintColumnVisible
            dgv.Columns("SKU").Width = SKUColumnWidth
        Catch ex As Exception

        End Try

    End Sub


    Private Sub lblPriceSheet_MouseHover(sender As Object, e As System.EventArgs) Handles lblPriceSheet.MouseHover, lblBartender.MouseHover
        Dim lbl As Label = DirectCast(sender, Label)

        Me.ToolTipLabelPrinter.SetToolTip(lbl, lbl.Text)
    End Sub

    Private Sub FilterItemTextBoxes(sender As System.Object, e As System.EventArgs) Handles txtItemDesc.KeyUp, txtItemNo.KeyUp, txtProdCat.KeyUp
        Dim txt As TextBox = DirectCast(sender, TextBox)
        FilterItemList_LNQ(txt.Text, txt)
        ClearSearchTextBoxes(txt.Parent, txt)
    End Sub

    Private Sub btnOrders_Click(sender As System.Object, e As System.EventArgs) Handles btnOrders.Click, btnItems.Click
        Dim btn As Button = DirectCast(sender, Button)


        If btn.Name = "btnItems" Then

            'Release Orders data
            bsrcOrderList.DataSource = Nothing
            bsrcOrderItemsSelected.DataSource = Nothing
            pnlExcelSpreadsheetNotLoaded.Visible = False
            ClearSearchTextBoxes()
            ExcelDataSet.LabelDataTable = Nothing
            ExcelDataSet.OrderNo = ""
            ExcelDataSet.OrderItemDataset = Nothing
            ExcelDataSet.MissingDataTable = Nothing
            With dgvSpecialOrder
                .Rows.Clear()
                .Columns.Clear()
            End With


            ItemsOrOrders = "Items"
            'pnlDragAndDropItems.Visible = True
            'pnlDragOffToRemove.Visible = True
            Dim dgv As DataGridView = Me.dgvItemList
            CreateItemListDataGridView(dgv)

            'With pnlItems
            '    .Left = pnlOrders.Left
            '    .Top = pnlOrders.Top
            '    .Width = pnlOrders.Width
            '    .Height = pnlOrders.Height
            '    .Visible = True
            '    .BringToFront()
            'End With
            pnlOrderList.Visible = False
            pnlItemList.Visible = True

            'With dgvItemList
            '    .Left = dgvOrderList.Left
            '    .Top = dgvOrderList.Top
            '    .Width = dgvOrderList.Width
            '    .Height = dgvOrderList.Height
            '    .Visible = True
            'End With

            dgv = Me.dgvOrderItemsSelected
            CreateOrderItemsSelectedDataGridView(dgv)

            ItemLabelsDataTable = CreateItemLabelsToPrintDataTable()
            bsrcOrderItemsSelected.DataSource = ItemLabelsDataTable
            dgv.DataSource = bsrcOrderItemsSelected
            Me.bsrcMissingData.DataSource = Nothing
            'pnlOrders.Visible = False
            'dgvOrderList.Visible = False
            dgvOrderItemsSelected.AllowDrop = True
        Else
            ItemsOrOrders = "Orders"
            'pnlDragAndDropItems.Visible = False
            'pnlDragOffToRemove.Visible = False
            pnlOrderList.Visible = True
            pnlItemList.Visible = False

            'pnlItems.Visible = False
            'dgvItemList.Visible = False
            'pnlOrders.Visible = True
            'dgvOrderList.Visible = True
            dgvOrderItemsSelected.AllowDrop = False
        End If
    End Sub

    Private Sub btnClearExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnClearExcel.Click
        ClearExcelList()
    End Sub

    Private Sub ClearExcelList()
        Me.bsrcExcelPriceList.DataSource = Nothing
        Me.dgvExcelPriceList.AllowUserToAddRows = False
        Me.dgvExcelPriceList.Rows.Clear()
        Me.dgvExcelPriceList.Columns.Clear()
        Me.lblPriceSheet.Text = ""
    End Sub

    Private Sub btnClearBartender_Click(sender As System.Object, e As System.EventArgs) Handles btnClearBartender.Click
        CloseBartenderLabelFormat()
        Me.lblBartender.Text = ""
        picPreview.Visible = True
    End Sub

#Region "   Properties   "

    Private mCellValue As String
    Public Property CellValue() As String
        Get
            Return mCellValue
        End Get
        Set(ByVal value As String)
            mCellValue = value
        End Set
    End Property

    Private mRowIndex As Integer
    Public Property RowIndex() As Integer
        Get
            Return mRowIndex
        End Get
        Set(ByVal value As Integer)
            mRowIndex = value
        End Set
    End Property

    Private mDragFromDGV As String
    Public Property DragFromDGV() As String
        Get
            Return mDragFromDGV
        End Get
        Set(ByVal value As String)
            mDragFromDGV = value
        End Set
    End Property

    Private mDragToDGV As String
    Public Property DragToDGV() As String
        Get
            Return mDragToDGV
        End Get
        Set(ByVal value As String)
            mDragToDGV = value
        End Set
    End Property

    Private mPrintColumnVisible As Boolean
    Public Property PrintColumnVisible() As Boolean
        Get
            Return mPrintColumnVisible
        End Get
        Set(ByVal value As Boolean)
            mPrintColumnVisible = value
        End Set
    End Property

    Private mSKUColumnWidth As Integer
    Public Property SKUColumnWidth() As Integer
        Get
            Return mSKUColumnWidth
        End Get
        Set(ByVal value As Integer)
            mSKUColumnWidth = value
        End Set
    End Property

    Private mTableHasBeenCreated As Boolean
    Public Property TableHasBeenCreated() As Boolean
        Get
            Return mTableHasBeenCreated
        End Get
        Set(ByVal value As Boolean)
            mTableHasBeenCreated = value
        End Set
    End Property

    Private mItemLabelsDataTable As DataTable
    Public Property ItemLabelsDataTable() As DataTable
        Get
            Return mItemLabelsDataTable
        End Get
        Set(ByVal value As DataTable)
            mItemLabelsDataTable = value
        End Set
    End Property

    Private mItemsOrOrders As String
    Public Property ItemsOrOrders() As String
        Get
            Return mItemsOrOrders
        End Get
        Set(ByVal value As String)
            mItemsOrOrders = value
        End Set
    End Property


#End Region

    Private Sub dgvOrderItemsSelected_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOrderItemsSelected.CellContentClick

        Dim dgv As DataGridView = DirectCast(sender, DataGridView)

        If e.ColumnIndex = 0 Then 'This is the Print Checkbox Column
            If dgv(e.ColumnIndex, e.RowIndex).Value = True Then
                dgv(e.ColumnIndex, e.RowIndex).Value = False
            Else
                dgv(e.ColumnIndex, e.RowIndex).Value = True
            End If
            Exit Sub
        End If
    End Sub



    Private Sub FilterItemTextBoxes(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtProdCat.KeyUp, txtItemNo.KeyUp, txtItemDesc.KeyUp

    End Sub

    Private Sub btnNewExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnNewExcel.Click
        'exportCurrentGridToExcel()
        Try

            Dim FieldNames As String = "SKU,Description,Retail,MfgItemNo,MfgFinishNo,UPC"
            Dim FldNames() As String = FieldNames.Split(",")
            Dim colsCounter As Int32 = 0
            Dim colsVisible As Int32 = 0
            Dim rows As Int32 = 0
            Dim cols As Int32 = UBound(FldNames)
            Dim rng As Excel.Range

            Dim btn As Button = CType(sender, Button)

            'Excel Variables
            Dim xlapp As New Excel.Application
            Dim xlwbook As Excel.Workbook = xlapp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet)
            Dim xlwsheet As Excel.Worksheet = CType(xlwbook.Worksheets(1), Excel.Worksheet)
            Dim xlcalc As Excel.XlCalculation

            With xlapp
                xlcalc = .Calculation
                .Calculation = Excel.XlCalculation.xlCalculationManual
                .Width = 1000
                .Left = 40
            End With

            With xlwsheet
                .Range(.Cells(1, 1), .Cells(1, cols + 1)).Value = FldNames
                '.Range(.Cells(2, 1), .Cells(rows + 2, cols + 1)).Value = DataArr
                .UsedRange.Columns.AutoFit()
                rng = .Range(.Cells(1, 1), .Cells(rows + 2, cols + 1))
                With rng
                    .HorizontalAlignment = Excel.Constants.xlLeft
                End With

                .Columns("A").ColumnWidth = 10
                .Columns("B").ColumnWidth = 37
                .Columns("C").ColumnWidth = 10
                .Columns("D").ColumnWidth = 16
                .Columns("E").ColumnWidth = 12
                .Columns("F").ColumnWidth = 14
                .Columns("G").columnWidth = 70

                rng = .Range("A1", Reflection.Missing.Value)
                rng.EntireRow.Font.Bold = True
                rng = .Range("C1", Reflection.Missing.Value)
                rng.EntireColumn.NumberFormat = "0.00"
                rng.Font.Color = Color.Blue
                rng = .Range("A1:B1", Reflection.Missing.Value)
                rng.EntireColumn.NumberFormat = "@"
                rng = .Range("D1:F1", Reflection.Missing.Value)
                rng.EntireColumn.NumberFormat = "@"
                .Name = "Master Price List"

                rng = .Range("G1")
                rng.Value2 = "Instructions:"
                rng = .Range("G2")
                rng.Value2 = "1.  HEADER ROW: Do Not Change Header Row.  Values must be exact."
                rng = .Range("G3")
                rng.Value2 = "2.  PRE-FORMATTED:"
                rng = .Range("G4")
                rng.Value2 = "   a. RETAIL: (Blue) pre-formatted to Number 2 Decimal Places."
                rng = .Range("G5")
                rng.Value2 = "   b.  ALL OTHER COLUMNS: (Black) pre-formatted to Text."
                rng = .Range("G6")
                rng.Value2 = "3.  SKU & UPC: can be left empty."
                rng = .Range("G7")
                rng.Value2 = "4.  UPC:  for barcode must be 12 Characters Long.  'GTIN Error' means UPC is incorrect length"
                rng = .Range("G8")
                rng.Value2 = "(Instruction Column can be deleted)"

            End With

            With xlapp
                .Visible = True
                .UserControl = True
                .Calculation = xlcalc
            End With

            xlwsheet = Nothing
            xlwbook = Nothing
            xlapp = Nothing
            GC.Collect()

        Catch ex As Exception
            MsgBox("Export Failed")
            MsgBox(ex.Message)

        End Try


    End Sub

    Private Sub btnSelectAllCopy_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectAllCopy.Click
        Dim dgv As DataGridView = CType(dgvSpecialOrder, DataGridView)
        With dgv
            .SelectAll()
            .ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
            Clipboard.SetDataObject(.GetClipboardContent())

        End With
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        Try
            Dim txt As TextBox = CType(txtOrderNo, TextBox)
            Dim PendOrHist As Integer = IIf(rdHistory.Checked, PendingOrHistory.history, PendingOrHistory.pending)
            FilterOrderList_LNQ_ByBillTo(txt.Text, txt, PendOrHist)

        Catch ex As Exception

        End Try

    End Sub


    Private Sub btnRemoveRows_Click(sender As System.Object, e As System.EventArgs) Handles btnRemoveRows.Click
        RemoveRow()
    End Sub

    Private Sub txtOrderNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOrderNo.TextChanged

    End Sub
End Class
