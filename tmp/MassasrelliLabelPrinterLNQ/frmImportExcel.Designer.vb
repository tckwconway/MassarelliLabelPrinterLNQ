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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtExcelHeader = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.btnCopyHeaderRow = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOpenFolderBrowsingDialog
        '
        Me.btnOpenFolderBrowsingDialog.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenFolderBrowsingDialog.Location = New System.Drawing.Point(486, 8)
        Me.btnOpenFolderBrowsingDialog.Name = "btnOpenFolderBrowsingDialog"
        Me.btnOpenFolderBrowsingDialog.Size = New System.Drawing.Size(27, 22)
        Me.btnOpenFolderBrowsingDialog.TabIndex = 79
        Me.btnOpenFolderBrowsingDialog.Text = "..."
        Me.btnOpenFolderBrowsingDialog.UseVisualStyleBackColor = True
        '
        'txtFilePath
        '
        Me.txtFilePath.Location = New System.Drawing.Point(124, 10)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(356, 20)
        Me.txtFilePath.TabIndex = 78
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(44, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "(select sheet)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 85
        Me.Label2.Text = "Excel Worksheets"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chklstExcelSheetNames
        '
        Me.chklstExcelSheetNames.CheckOnClick = True
        Me.chklstExcelSheetNames.FormattingEnabled = True
        Me.chklstExcelSheetNames.Location = New System.Drawing.Point(124, 38)
        Me.chklstExcelSheetNames.Name = "chklstExcelSheetNames"
        Me.chklstExcelSheetNames.Size = New System.Drawing.Size(202, 64)
        Me.chklstExcelSheetNames.TabIndex = 87
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtEndCell)
        Me.GroupBox1.Controls.Add(Me.txtStartCell)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(333, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(181, 70)
        Me.GroupBox1.TabIndex = 88
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(94, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 90
        Me.Label4.Text = "End"
        '
        'txtEndCell
        '
        Me.txtEndCell.Location = New System.Drawing.Point(132, 40)
        Me.txtEndCell.Name = "txtEndCell"
        Me.txtEndCell.ReadOnly = True
        Me.txtEndCell.Size = New System.Drawing.Size(38, 20)
        Me.txtEndCell.TabIndex = 89
        Me.txtEndCell.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtStartCell
        '
        Me.txtStartCell.Location = New System.Drawing.Point(132, 10)
        Me.txtStartCell.Name = "txtStartCell"
        Me.txtStartCell.Size = New System.Drawing.Size(38, 20)
        Me.txtStartCell.TabIndex = 88
        Me.txtStartCell.Text = "A1"
        Me.txtStartCell.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "Excel: Range >"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(94, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 86
        Me.Label6.Text = "Start"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(59, 13)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 13)
        Me.Label16.TabIndex = 89
        Me.Label16.Text = "Import File"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(12, 121)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(501, 2)
        Me.GroupBox3.TabIndex = 96
        Me.GroupBox3.TabStop = False
        '
        'txtExcelHeader
        '
        Me.txtExcelHeader.BackColor = System.Drawing.SystemColors.Window
        Me.txtExcelHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExcelHeader.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.txtExcelHeader.Location = New System.Drawing.Point(150, 157)
        Me.txtExcelHeader.Name = "txtExcelHeader"
        Me.txtExcelHeader.Size = New System.Drawing.Size(360, 20)
        Me.txtExcelHeader.TabIndex = 97
        Me.txtExcelHeader.Text = "SKU" & Global.Microsoft.VisualBasic.ChrW(9) & "Description" & Global.Microsoft.VisualBasic.ChrW(9) & "Retail" & Global.Microsoft.VisualBasic.ChrW(9) & "MfgItemNo" & Global.Microsoft.VisualBasic.ChrW(9) & "MfgFinishNo"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(17, 132)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(331, 13)
        Me.TextBox2.TabIndex = 99
        Me.TextBox2.Text = "NOTE: Excel Header Row Must Match example below.   "
        '
        'btnCopyHeaderRow
        '
        Me.btnCopyHeaderRow.Image = Global.MassasrelliLabelPrinterLNQ.My.Resources.Resources.Copy_Plain
        Me.btnCopyHeaderRow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCopyHeaderRow.Location = New System.Drawing.Point(17, 155)
        Me.btnCopyHeaderRow.Name = "btnCopyHeaderRow"
        Me.btnCopyHeaderRow.Size = New System.Drawing.Size(127, 24)
        Me.btnCopyHeaderRow.TabIndex = 100
        Me.btnCopyHeaderRow.Text = "   Copy Header Row"
        Me.btnCopyHeaderRow.UseVisualStyleBackColor = True
        '
        'frmImportExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 191)
        Me.Controls.Add(Me.btnCopyHeaderRow)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.txtExcelHeader)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chklstExcelSheetNames)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnOpenFolderBrowsingDialog)
        Me.Controls.Add(Me.txtFilePath)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
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
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtExcelHeader As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents btnCopyHeaderRow As System.Windows.Forms.Button
End Class
