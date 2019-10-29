Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
'Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices.Marshal
Imports System.Runtime.InteropServices

Public Class frmImportExcel
    Private xlobj As New ImportSettingsObj
    Private getxl As New GetExcelData
    Private xlwbook As Excel.Workbook
    Private xlwsheet As Excel.Worksheet = Nothing
    Private xlapp As Excel.Application = New Excel.Application

    Private Sub btnOpenFolderBrowsingDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenFolderBrowsingDialog.Click
        OpenFileDialogXL()
        'Dim res As Integer
        ''Dim _maxcell As String
        'With Me.OpenFileDialog1
        '    .FileName = ""
        '    .Filter = "Excel Files (*.xls)|*.xls|All Files (*.*)|*.*"
        '    .FilterIndex = 1
        'End With
        'If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
        '    Exit Sub
        'Else
        '    Me.txtFilePath.Text = OpenFileDialog1.FileName
        '    getxl.FilePath = OpenFileDialog1.FileName
        '    ExcelDataSet.XLFileName = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
        '    Me.txtEndCell.Text = ""
        '    GetExcel()
        'End If

    End Sub
    Private Sub OpenFileDialogXL()
        ' Dim res As Integer
        'Dim _maxcell As String
        With Me.OpenFileDialog1
            '.FileName = ""
            '.Filter = "Excel Files (*.xls)|*.xls|All Files (*.*)|*.*"
            '.FilterIndex = 1
            .FileName = ""
            .Filter = "Excel 97-2003 Workbook(*.xls)|*.xls|Excel 2007-2010 Workbook(*.xlsx)|*.xlsx|All files (*.*)|*.*"
            .FilterIndex = 1
        End With
        If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            Me.txtFilePath.Text = OpenFileDialog1.FileName
            getxl.FilePath = OpenFileDialog1.FileName
            ExcelDataSet.XLFileName = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
            Me.txtEndCell.Text = ""
            GetExcel()
        End If

       




    End Sub

    Private Sub GetExcel()
        'If Me.cboImportType.Text = "" Then
        '    Exit Sub
        'ElseIf Me.txtFilePath.Text = "" Then
        '    Exit Sub
        'End If

        Dim _ws As Excel.Worksheet
        xlwbook = GetExcelWorkbook(Me.xlapp, getxl.FilePath)

        chklstExcelSheetNames.Items.Clear()
        Try
            For Each _ws In xlwbook.Worksheets
                chklstExcelSheetNames.Items.Add(_ws.Name)
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Function GetExcelWorkbook(ByVal xl As Excel.Application, ByVal filename As String) As Excel.Workbook
        'Dim ws As Excel.Worksheet = New Excel.Worksheet
        'Dim wb As Excel.Workbook

        Try
            'xl = New Excel.Application
            xlwbook = Me.xlapp.Workbooks.Open(filename, , , , , , , , , , False)

            xlapp.Visible = False
            xlwbook.Activate()
            Return xlwbook

        Catch ex As Exception
            Return Nothing

        End Try

        Return Nothing

    End Function

    Private Sub chklstExcelSheetNames_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chklstExcelSheetNames.MouseClick
        Dim chk As CheckedListBox = DirectCast(Me.chklstExcelSheetNames, CheckedListBox)
        Try
            For i As Integer = 0 To chk.Items.Count - 1
                chk.SetItemChecked(i, False)
            Next
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub chklstExcelSheetNames_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chklstExcelSheetNames.ItemCheck
        Dim chk As CheckedListBox = DirectCast(sender, CheckedListBox)
        Try
            xlobj.ExcelSheetName = chk.SelectedItem().ToString
            Try
                Me.GetExcelCellRange()
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try

            Try
                Me.GetExcelSheet()
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try


            'MassarelliLabelPrinter.tbl = getxl.DSExcel.Tables(0).Copy
            ExcelDataSet.XLDataset = getxl.DSExcel.Copy
            'MassarelliLabelPrinter.dgvExcelPriceList.DataSource = MassarelliLabelPrinter.bsrcExcelPriceList
            'MassarelliLabelPrinter.dgvExcelPriceList.AutoGenerateColumns = True

            Me.Cursor = Cursors.Default
            Me.Close()

            '=======================================================================
            'this part goes back in


            'Dim itmprclst As New ItemPricingList
            ''rd = BusObj.GetSearchItemsAdvanced(items, Type, prclevel, cn)
            'TerrPricing.itmPricinglist = BusObj.PopulateSearchItems(getxl.DSExcel)
            'TerrPricing.ItemPricingObjBindingSource.DataSource = TerrPricing.itmPricinglist
            ReleaseExcelSpreadsheet()
            ReleaseXLApplication()
            'Me.Close()

        Catch ex As Exception
            'MsgBox(ex.Message)

        End Try
        
        'If dgImport.Rows.Count > 0 And ErrorExists = False Then
        '    btnGetKeys.Enabled = True
        'Else
        '    btnGetKeys.Enabled = False
        '    ErrorExists = False
        'End If

    End Sub

    Private Sub GetExcelCellRange()
        'Dim _ws As Excel.Worksheet
        'Try
        '    _ws = New Excel.Worksheet
        'Catch ex As Exception
        '    'ReleaseExcelSpreadsheet()
        '    'ReleaseXLApplication()
        '    'xlapp = New Excel.Application
        '    xlapp.DisplayAlerts = False
        '    _ws = New Excel.Worksheet
        'End Try
        ''Dim _ws As Excel.Worksheet = New Excel.Worksheet

        For Each Me.xlwsheet In xlwbook.Worksheets
            If xlwsheet.Name = xlobj.ExcelSheetName Then Exit For
        Next
        Try
            xlobj.ExecelRangeEnd = GetXLRange(xlwsheet)
            If xlobj.ExecelRangeEnd = "" Then Exit Sub
            'TODO PUT THE CODE TO DETERMINE IS upc IS INCLUDED HERE....
            '' Add a UPC Yes/No property which finds column F or UPC Header. 

            Dim rw As Object = 1
            Dim cl As Object = 0
            Dim hdr As String = ""
            For i As Integer = 1 To 10
                'rng = rng & i.ToString
                hdr = xlwsheet.Cells(1, i).value
                'xlwsheet.Range(rng).Value.ToString

                If hdr = "SKU" And xlobj.ImportType = "" Then
                    ExcelDataSet.ImportType = hdr
                ElseIf hdr = "UPC" Then
                    ExcelDataSet.ImportType = hdr
                    Exit Sub
                End If
            Next


            xlobj.ExecelRangeStart = Me.txtStartCell.Text
            Me.txtEndCell.Text = xlobj.ExecelRangeEnd
            Me.txtStartCell.Text = xlobj.ExecelRangeStart

        Catch ex As Exception

        End Try
        
    End Sub
    Private Sub GetExcelSheet()
        Dim startrow As Integer = xlobj.ExcelRangeStartNumber
        
        If Me.txtFilePath.Text = "" Then
            Exit Sub
        End If


        Me.Cursor = Cursors.WaitCursor
        Dim strRange As String = xlobj.ExecelRangeStart & ":" & xlobj.ExecelRangeEnd
        Dim strSheetName As String = xlobj.ExcelSheetName & "$"
        Dim strImportType As String = xlobj.ImportType
        'Dim strImportWarehouseID As String = xlobj.ImportWarehouse
        'Dim strImportCompanyID As String = xlobj.ImportCompanyID
        'Dim i As Integer = 0

        getxl.IsImporting = True
        
        getxl.DSExcel = getxl.GetDataFromExcel(Me.txtFilePath.Text, strSheetName, strRange)
       
    End Sub

    Public Function GetXLRange(ByVal ws As Excel.Worksheet) As String
        Dim strRange As String = ""
        Try
            Dim maxCell As Microsoft.Office.Interop.Excel.Range
            maxCell = DirectCast(ws.Cells(ws.Cells.Find("*", _
            DirectCast(ws.Cells(1, 1), Excel.Range), _
            Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlWhole, _
            Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlPrevious, False, False).Row, _
            ws.Cells.Find("*", DirectCast(ws.Cells(1, 1), Excel.Range), _
            Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlWhole, Excel.XlSearchOrder.xlByColumns, _
            Excel.XlSearchDirection.xlPrevious, False, False).Column), Excel.Range)

            strRange = maxCell.Address.Replace("$", "")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return strRange

    End Function

    Private Sub txtStartCell_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStartCell.TextChanged
        Dim txt As TextBox = DirectCast(sender, TextBox)
        xlobj.ExecelRangeStart = txt.Text
    End Sub
    Private Sub ReleaseExcelSpreadsheet()
        Try
            xlwsheet = Nothing
            xlwbook.Close(False)
            While (ReleaseComObject(xlwbook)) <> 0
            End While
            xlwbook = Nothing
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ReleaseXLApplication()
        Try
            xlapp.Quit()
            While (ReleaseComObject(xlapp) <> 0)
            End While
        Catch ex As Exception
        Finally
            xlapp = Nothing
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
        End Try
    End Sub

    Private Sub frmImportExcel_ForeColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ForeColorChanged

    End Sub

    Private Sub frmImportExcel_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.txtFilePath.Clear()
        Me.txtEndCell.Clear()
        Me.chklstExcelSheetNames.Items.Clear()

        Try
            xlapp.Quit()
            While (ReleaseComObject(xlapp) <> 0)
            End While
        Catch ex As Exception
        Finally
            xlapp = Nothing
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
        End Try
        Me.Dispose()

    End Sub

    Private Sub frmImportExcel_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            'System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlwsheet)
            'System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlwbook)
            'System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlwbook)
            'System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlapp)

        Catch ex As Exception
            xlwsheet = Nothing
            xlwbook = Nothing
            xlapp = Nothing

        End Try


    End Sub

    Private Sub CopyExcelHeaderText(sender As System.Object, e As System.EventArgs) Handles btnCopyHeaderRow.Click
        Try
            txtExcelHeader.SelectAll()
            txtExcelHeader.BackColor = Color.DodgerBlue
            txtExcelHeader.Refresh()
            System.Threading.Thread.Sleep(500)
            Clipboard.SetText(txtExcelHeader.SelectedText)
            txtExcelHeader.BackColor = SystemColors.Window
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub chklstExcelSheetNames_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles chklstExcelSheetNames.SelectedIndexChanged

    End Sub

    Private Sub frmImportExcel_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        OpenFileDialogXL()
    End Sub
End Class