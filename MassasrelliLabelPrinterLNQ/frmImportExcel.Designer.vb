<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportExcel
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportExcel))
        Me.btnOpenFolderBrowsingDialog = New System.Windows.Forms.Button()
        Me.txtFilePath = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chklstExcelSheetNames = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEndCell = New System.Windows.Forms.TextBox()
        Me.txtStartCell = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtExcelHeader = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.btnCopyHeaderRow = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOpenFolderBrowsingDialog
        '
        Me.btnOpenFolderBrowsingDialog.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenFolderBrowsingDialog.Location = New System.Drawing.Point(648, 10)
        Me.btnOpenFolderBrowsingDialog.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOpenFolderBrowsingDialog.Name = "btnOpenFolderBrowsingDialog"
        Me.btnOpenFolderBrowsingDialog.Size = New System.Drawing.Size(36, 27)
        Me.btnOpenFolderBrowsingDialog.TabIndex = 79
        Me.btnOpenFolderBrowsingDialog.Text = "..."
        Me.btnOpenFolderBrowsingDialog.UseVisualStyleBackColor = True
        '
        'txtFilePath
        '
        Me.txtFilePath.Location = New System.Drawing.Point(165, 12)
        Me.txtFilePath.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(473, 22)
        Me.txtFilePath.TabIndex = 78
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(58, 71)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 17)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "(select sheet)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 47)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 17)
        Me.Label2.TabIndex = 85
        Me.Label2.Text = "Excel Worksheets"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chklstExcelSheetNames
        '
        Me.chklstExcelSheetNames.CheckOnClick = True
        Me.chklstExcelSheetNames.FormattingEnabled = True
        Me.chklstExcelSheetNames.Location = New System.Drawing.Point(165, 47)
        Me.chklstExcelSheetNames.Margin = New System.Windows.Forms.Padding(4)
        Me.chklstExcelSheetNames.Name = "chklstExcelSheetNames"
        Me.chklstExcelSheetNames.Size = New System.Drawing.Size(473, 72)
        Me.chklstExcelSheetNames.TabIndex = 87
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtEndCell)
        Me.GroupBox1.Controls.Add(Me.txtStartCell)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(35, 238)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(102, 80)
        Me.GroupBox1.TabIndex = 88
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(125, 53)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 17)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "End"
        '
        'txtEndCell
        '
        Me.txtEndCell.Location = New System.Drawing.Point(176, 49)
        Me.txtEndCell.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEndCell.Name = "txtEndCell"
        Me.txtEndCell.ReadOnly = True
        Me.txtEndCell.Size = New System.Drawing.Size(49, 22)
        Me.txtEndCell.TabIndex = 89
        Me.txtEndCell.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtStartCell
        '
        Me.txtStartCell.Location = New System.Drawing.Point(176, 12)
        Me.txtStartCell.Margin = New System.Windows.Forms.Padding(4)
        Me.txtStartCell.Name = "txtStartCell"
        Me.txtStartCell.Size = New System.Drawing.Size(49, 22)
        Me.txtStartCell.TabIndex = 88
        Me.txtStartCell.Text = "A1"
        Me.txtStartCell.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 16)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 17)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "Excel: Range >"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(125, 16)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 17)
        Me.Label6.TabIndex = 86
        Me.Label6.Text = "Start"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(79, 16)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 17)
        Me.Label16.TabIndex = 89
        Me.Label16.Text = "Import File"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtExcelHeader
        '
        Me.txtExcelHeader.BackColor = System.Drawing.SystemColors.Window
        Me.txtExcelHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExcelHeader.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtExcelHeader.Location = New System.Drawing.Point(200, 193)
        Me.txtExcelHeader.Margin = New System.Windows.Forms.Padding(4)
        Me.txtExcelHeader.Name = "txtExcelHeader"
        Me.txtExcelHeader.Size = New System.Drawing.Size(479, 22)
        Me.txtExcelHeader.TabIndex = 97
        Me.txtExcelHeader.Text = "SKU" & Global.Microsoft.VisualBasic.ChrW(9) & "Description" & Global.Microsoft.VisualBasic.ChrW(9) & "Retail" & Global.Microsoft.VisualBasic.ChrW(9) & "MfgItemNo" & Global.Microsoft.VisualBasic.ChrW(9) & "MfgFinishNo"
        Me.txtExcelHeader.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(23, 162)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(441, 16)
        Me.TextBox2.TabIndex = 99
        Me.TextBox2.Text = "NOTE: Excel Header Row Must Match example below.   "
        Me.TextBox2.Visible = False
        '
        'btnCopyHeaderRow
        '
        Me.btnCopyHeaderRow.Image = Global.MassasrelliLabelPrinterLNQ.My.Resources.Resources.Copy_Plain
        Me.btnCopyHeaderRow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCopyHeaderRow.Location = New System.Drawing.Point(23, 191)
        Me.btnCopyHeaderRow.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCopyHeaderRow.Name = "btnCopyHeaderRow"
        Me.btnCopyHeaderRow.Size = New System.Drawing.Size(169, 30)
        Me.btnCopyHeaderRow.TabIndex = 100
        Me.btnCopyHeaderRow.Text = "   Copy Header Row"
        Me.btnCopyHeaderRow.UseVisualStyleBackColor = True
        Me.btnCopyHeaderRow.Visible = False
        '
        'frmImportExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 130)
        Me.Controls.Add(Me.btnCopyHeaderRow)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.txtExcelHeader)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chklstExcelSheetNames)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnOpenFolderBrowsingDialog)
        Me.Controls.Add(Me.txtFilePath)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmImportExcel"
        Me.Text = "Import Excel File"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOpenFolderBrowsingDialog As System.Windows.Forms.Button
    Friend WithEvents txtFilePath As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chklstExcelSheetNames As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEndCell As System.Windows.Forms.TextBox
    Friend WithEvents txtStartCell As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtExcelHeader As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents btnCopyHeaderRow As System.Windows.Forms.Button
End Class
