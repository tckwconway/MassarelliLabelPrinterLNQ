Imports Seagull.BarTender.Print
Imports Seagull.BarTender.Print.Database
Imports Seagull.BarTender.Print.Message
Imports System.Data
Imports System.Text
Imports System.Data.Common
Imports System.IO

Public Class BartenderEngineWrapper

    Implements IDisposable
    ' Engine Field 

    Private m_engine As Engine = Nothing

    ' This property will create and start the engine the first time it is 
    ' called. Most methods in this class (and methods in child classes) 
    ' should utilize this property instead of the m_engine field. 

    Protected ReadOnly Property BtEngine() As Engine

        Get
            ' If the engine has not been created yet, create and start it. 
            If m_engine Is Nothing Then
                m_engine = New Engine(True)
            End If
            Return m_engine
        End Get

    End Property

    ' Implement IDisposable 

    Public Sub Dispose() Implements IDisposable.Dispose
        ' The engine only needs to be stopped and disposed if it was 
        ' created. Use the field here, not the property. Otherwise, 
        ' you might create a new instance in the Dispose method! 
        If m_engine IsNot Nothing Then
            ' Stop the process and release Engine field resources. 
            m_engine.Stop()
            m_engine.Dispose()
        End If

    End Sub

    Public Sub OpenLabelFormat(ByVal FileName As String, ByVal arrItems As String(), ByVal labelPrinter As String)
        Dim RetMethod As String = "BartenderEngineWrapper.OpenLabelFormat"
        Dim RetCall As String = ""
        Dim appName As String = "Label Print"
        Dim messages As Messages = Nothing
        Dim btmsg As Seagull.BarTender.Print.Message = Nothing

        Dim waitForCompletionTimeout As Integer = 100 ' 10 seconds
        Dim btFormat As LabelFormatDocument = Nothing

        ' Start Print Engine
        Try
            RetCall = "BtEngine.Start()"
            BtEngine.Start()
        Catch ex As Exception
            MsgBox("Method: " & RetMethod & ", Call: " & RetCall & "Bartender.IsAlive: " & BtEngine.IsAlive.ToString & "Bartender.Documents: " & BtEngine.Documents.Item(0).Title _
                    & "Bartender.ActiveDocument: " & BtEngine.ActiveDocument.Title & "Bartender.ActiveDocument.DataBaseConnection: " & BtEngine.ActiveDocument.DatabaseConnections.Item(0).Name _
                    & "Bartender.ActiveDocument.PrinterName: " & BtEngine.ActiveDocument.PrintSetup.PrinterName.ToString _
                    & "Bartender.ActiveDocument.FileName: " & BtEngine.ActiveDocument.FileName.ToString _
                    & "Bartender.ActiveDocument.Directory: " & BtEngine.ActiveDocument.Directory.ToString)
            MsgBox(ex.Message)
            Exit Sub

        End Try

        ' Open the Label Document
        Try
            RetCall = "Dim btFormat As LabelFormatDocument = BtEngine.Documents.Open(FileName)"
            btFormat = BtEngine.Documents.Open(FileName)

        Catch ex As Exception
            MsgBox("Method: " & RetMethod & ", Call: " & RetCall & "btFormat.Status: " & btFormat.Status.ToString & "btFormat.DatabaseConnections.Item(0).Name.ToString: " & btFormat.DatabaseConnections.Item(0).Name.ToString _
                   & "btFormat.Directory.ToString: " & btFormat.Directory.ToString & "btFormat.FileName.ToString: " & btFormat.FileName.ToString _
                   & "btFormat.Title.ToString: " & btFormat.Title.ToString _
                   & "BtEngine.IsAlive.ToString: " & BtEngine.IsAlive.ToString & "Bartender.Documents.Item(0).Title: " & BtEngine.Documents.Item(0).Title.ToString _
                   & "Bartender.ActiveDocument: " & BtEngine.ActiveDocument.Title & "Bartender.ActiveDocument.DataBaseConnection: " & BtEngine.ActiveDocument.DatabaseConnections.Item(0).Name _
                   & "Bartender.ActiveDocument.PrinterName: " & BtEngine.ActiveDocument.PrintSetup.PrinterName.ToString _
                   & "Bartender.ActiveDocument.FileName: " & BtEngine.ActiveDocument.FileName.ToString _
                   & "Bartender.ActiveDocument.Directory: " & BtEngine.ActiveDocument.Directory.ToString)
            MsgBox(ex.Message)
            Exit Sub
        End Try

        ' Setup The Printer for the Label
        With btFormat
            'MsgBox("4 Setup Printer")
            Try
                RetCall = "btFormat.PrintSetup.PrinterName = labelPrinter; LabelPrinter: " & labelPrinter
                .PrintSetup.PrinterName = labelPrinter
            Catch ex As Exception
                MsgBox("Method: " & RetMethod & ", Call: " & RetCall & "btFormat.Status: " & btFormat.Status.ToString & "btFormat.DatabaseConnections.Item(0).Name.ToString: " & btFormat.DatabaseConnections.Item(0).Name.ToString _
                   & "btFormat.Directory.ToString: " & btFormat.Directory.ToString & "btFormat.FileName.ToString: " & btFormat.FileName.ToString _
                   & "btFormat.Title.ToString: " & btFormat.Title.ToString _
                   & "BtEngine.IsAlive.ToString: " & BtEngine.IsAlive.ToString & "Bartender.Documents.Item(0).Title: " & BtEngine.Documents.Item(0).Title.ToString _
                   & "Bartender.ActiveDocument: " & BtEngine.ActiveDocument.Title & "Bartender.ActiveDocument.DataBaseConnection: " & BtEngine.ActiveDocument.DatabaseConnections.Item(0).Name _
                   & "Bartender.ActiveDocument.PrinterName: " & BtEngine.ActiveDocument.PrintSetup.PrinterName.ToString _
                   & "Bartender.ActiveDocument.FileName: " & BtEngine.ActiveDocument.FileName.ToString _
                   & "Bartender.ActiveDocument.Directory: " & BtEngine.ActiveDocument.Directory.ToString)
                MsgBox(ex.Message)
                Exit Sub
            End Try

            ' Set each SubString on the Label and Print
            For Each o As Object In arrItems
                '' '' '' ''MsgBox("6 Data to Label")
                ' '' '' ''Try
                ' '' '' ''    RetCall = "PrintType: " & PrintType & "lbl.SerialNo: " & lbl.SerialNo.ToString
                ' '' '' ''    '.SubStrings("SerialNo").Value = "*" & lbl.SerialNo & "*"
                ' '' '' ''    .SubStrings("SerialNo").Value = lbl.SerialNo
                ' '' '' ''    btFormat.Print("Label Print", waitForCompletionTimeout, messages)
                ' '' '' ''Catch ex As Exception
                ' '' '' ''    Dim str As String
                ' '' '' ''    For Each btmsg In messages
                ' '' '' ''        str = str & ", " & btmsg.Text
                ' '' '' ''    Next
                ' '' '' ''    MsgBox("Method: " & RetMethod & ", Call: " & RetCall & "Bartender Error Messages: " & str)
                ' '' '' ''    MsgBox(ex.Message)
                ' '' '' ''End Try
                '' '' '' ''.SubStrings("SerialNo").Value = "*" & lbl.SerialNo & "*"
                '' '' '' ''.SubStrings("SerialNo").Value = lbl.SerialNo
                '' '' '' ''.Print("Label Print", waitForCompletionTimeout, messages)

            Next


        End With

        btFormat.Close(SaveOptions.DoNotSaveChanges)

    End Sub
    Public Sub OpenLabelFormatByDataSource(ByVal BTLabelFormatFileName As String, ByVal DatabaseConnectionNameInLabel As String, _
                                           ByVal LabelDataSourceFileName As String, ByVal LabelPrinterName As String)

        Dim RetMethod As String = "OpenLabelFormatByDataSource"
        Dim RetCall As String = ""
        Dim appName As String = "Label Print"
        Dim messages As Messages = Nothing
        Dim waitForCompletionTimeout As Integer = 100 ' 10 seconds
        Dim btFormat As LabelFormatDocument = Nothing

        'MsgBox("2 Start BTEngine")
        Try
            RetCall = "BtEngine.Start()"
            BtEngine.Start()
        Catch ex As Exception
            MsgBox("Method: " & RetMethod & ", Call: " & RetCall, MsgBoxStyle.OkOnly, "Error")
            Exit Sub
        End Try

        'MsgBox("3 Load Format")

        'Dim textFile As New Text
        Try
            RetCall = "btFormat = BtEngine.Documents.Open(FileName)" & ", FileName: " & BTLabelFormatFileName
            btFormat = BtEngine.Documents.Open(BTLabelFormatFileName)
        Catch ex As Exception
            MsgBox("Method: " & RetMethod & ", Call: " & RetCall, MsgBoxStyle.OkOnly, "Error")
            MsgBox(ex.Message)
        End Try

        'Dim performance As Performance = btFormat.PrintSetup.Performance
        'performance.AllowFormatCaching = True
        'performance.AllowGraphicsCaching = False
        'performance.AllowSerialization = False
        'performance.AllowStaticGraphics = False
        'performance.AllowStaticObjects = True
        'performance.AllowVariableDataOptimization = True
        'performance.WarnWhenUsingTrueTypeFonts = False

        Try
            RetCall = "CType(btFormat.DatabaseConnections(DatabaseConnection), TextFile).FileName = datasource" & ", datasource: " & LabelDataSourceFileName & ", btFormat.DatabaseConnections.Item(0).Name "
            CType(btFormat.DatabaseConnections(DatabaseConnectionNameInLabel), TextFile).FileName = LabelDataSourceFileName

        Catch ex As Exception
            MsgBox("Method: " & RetMethod & " Call: " & RetCall)
            MsgBox(ex.Message)

        End Try
        Try
            RetCall = " With btFormat_ .PrintSetup.PrinterName = labelPrinter _ .Print() _ End With" & ", labelPrinter: " & LabelPrinterName
            With btFormat
                .PrintSetup.PrinterName = LabelPrinterName


               


                .Print()
            End With

        Catch ex As Exception
            MsgBox("Method: " & RetMethod & ", Call: " & RetCall & ", btformat.Status: " & btFormat.Status.ToString & ", btFormat.Title: " & btFormat.Title.ToString)
            MsgBox(ex.Message)
            Exit Sub
        End Try

        Kill(LabelDataSourceFileName)


        Try
            btFormat.Close(SaveOptions.DoNotSaveChanges)
        Catch ex As Exception

        End Try


    End Sub
End Class
