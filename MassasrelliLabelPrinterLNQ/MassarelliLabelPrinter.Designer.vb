<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MassarelliLabelPrinter
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MassarelliLabelPrinter))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tslblDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblCompany = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslbMaxProductionID = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblLabelStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlPricesLabelsSelection = New System.Windows.Forms.Panel()
        Me.btnNewExcel = New System.Windows.Forms.Button()
        Me.btnClearBartender = New System.Windows.Forms.Button()
        Me.btnClearExcel = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblBartender = New System.Windows.Forms.Label()
        Me.picBartender = New System.Windows.Forms.PictureBox()
        Me.btnLoadBartenderLabel = New System.Windows.Forms.Button()
        Me.lblLoadBarTenderLabel = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblPriceSheet = New System.Windows.Forms.Label()
        Me.picExcel = New System.Windows.Forms.PictureBox()
        Me.btnPriceList = New System.Windows.Forms.Button()
        Me.lblLoadExcelPriceList = New System.Windows.Forms.Label()
        Me.imgListUpDown = New System.Windows.Forms.ImageList(Me.components)
        Me.dgvExcelPriceList = New System.Windows.Forms.DataGridView()
        Me.bsrcExcelPriceList = New System.Windows.Forms.BindingSource(Me.components)
        Me.OpenFileDialogBartender = New System.Windows.Forms.OpenFileDialog()
        Me.lblNumPreviews = New System.Windows.Forms.Label()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnLast = New System.Windows.Forms.Button()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.cboPrinters = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.backgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.ToolTipLabelPrinter = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnItems = New System.Windows.Forms.Button()
        Me.btnOrders = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.rdPending = New System.Windows.Forms.RadioButton()
        Me.rdHistory = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnShowAll = New System.Windows.Forms.Button()
        Me.btnClearAll = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.picUpdating = New System.Windows.Forms.PictureBox()
        Me.picPreview = New System.Windows.Forms.PictureBox()
        Me.ToolStripButtonExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonBLANK = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonClear = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonSerialNumber = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonMACAddress = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonSettings = New System.Windows.Forms.ToolStripButton()
        Me.bsrcOrderList = New System.Windows.Forms.BindingSource(Me.components)
        Me.bsrcOrderItemsSelected = New System.Windows.Forms.BindingSource(Me.components)
        Me.bsrcMissingData = New System.Windows.Forms.BindingSource(Me.components)
        Me.bsrcSortable = New System.Windows.Forms.BindingSource(Me.components)
        Me.bsrcItemList = New System.Windows.Forms.BindingSource(Me.components)
        Me.bsrcItemsToPrint = New System.Windows.Forms.BindingSource(Me.components)
        Me.bsrcHistoryList = New System.Windows.Forms.BindingSource(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dgvOrderItemsSelected = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnRemoveRows = New System.Windows.Forms.Button()
        Me.pnlExcelSpreadsheetNotLoaded = New System.Windows.Forms.Panel()
        Me.picExcelNotLoaded = New System.Windows.Forms.PictureBox()
        Me.txtExcelNotLoaded = New System.Windows.Forms.TextBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.btnSelectItemsToPrint = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnSetSortOrder = New System.Windows.Forms.Button()
        Me.lblAdvancedSort = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvSpecialOrder = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnSelectAllCopy = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlSortOrder = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.dgvSortOrder = New System.Windows.Forms.DataGridView()
        Me.dgvSortableColumns = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlItemList = New System.Windows.Forms.Panel()
        Me.dgvItemList = New System.Windows.Forms.DataGridView()
        Me.pnlItems = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtProdCat = New System.Windows.Forms.TextBox()
        Me.txtItemDesc = New System.Windows.Forms.TextBox()
        Me.txtItemNo = New System.Windows.Forms.TextBox()
        Me.pnlOrderList = New System.Windows.Forms.Panel()
        Me.dgvOrderList = New System.Windows.Forms.DataGridView()
        Me.pnlOrders = New System.Windows.Forms.Panel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.lblAltAddr = New System.Windows.Forms.Label()
        Me.txtCustAltAdrCode = New System.Windows.Forms.TextBox()
        Me.lblCusNo = New System.Windows.Forms.Label()
        Me.txtCustNo = New System.Windows.Forms.TextBox()
        Me.lblOrderDate = New System.Windows.Forms.Label()
        Me.txtOrderDate = New System.Windows.Forms.TextBox()
        Me.lblOrderNo = New System.Windows.Forms.Label()
        Me.txtOrderNo = New System.Windows.Forms.TextBox()
        Me.lblShipTo = New System.Windows.Forms.Label()
        Me.txtShipToName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBillToName = New System.Windows.Forms.TextBox()
        Me.pnlPricesLabelsSelection.SuspendLayout()
        CType(Me.picBartender, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvExcelPriceList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsrcExcelPriceList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picUpdating, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsrcOrderList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsrcOrderItemsSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsrcMissingData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsrcSortable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsrcItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsrcItemsToPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsrcHistoryList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvOrderItemsSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.pnlExcelSpreadsheetNotLoaded.SuspendLayout()
        CType(Me.picExcelNotLoaded, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSpecialOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.pnlSortOrder.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.dgvSortOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSortableColumns, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlItemList.SuspendLayout()
        CType(Me.dgvItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlItems.SuspendLayout()
        Me.pnlOrderList.SuspendLayout()
        CType(Me.dgvOrderList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOrders.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tslblDate
        '
        Me.tslblDate.AutoSize = False
        Me.tslblDate.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslblDate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.tslblDate.Name = "tslblDate"
        Me.tslblDate.Size = New System.Drawing.Size(75, 17)
        Me.tslblDate.Text = "ToolStripStatusLabel1"
        '
        'tslblCompany
        '
        Me.tslblCompany.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslblCompany.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.tslblCompany.Name = "tslblCompany"
        Me.tslblCompany.Size = New System.Drawing.Size(125, 17)
        Me.tslblCompany.Text = "ToolStripStatusLabel1"
        '
        'tslblUser
        '
        Me.tslblUser.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslblUser.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.tslblUser.Name = "tslblUser"
        Me.tslblUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tslblUser.Size = New System.Drawing.Size(125, 17)
        Me.tslblUser.Text = "ToolStripStatusLabel1"
        '
        'tslbMaxProductionID
        '
        Me.tslbMaxProductionID.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslbMaxProductionID.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.tslbMaxProductionID.Name = "tslbMaxProductionID"
        Me.tslbMaxProductionID.Size = New System.Drawing.Size(4, 17)
        Me.tslbMaxProductionID.Visible = False
        '
        'tslblLabelStatus
        '
        Me.tslblLabelStatus.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslblLabelStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.tslblLabelStatus.Name = "tslblLabelStatus"
        Me.tslblLabelStatus.Size = New System.Drawing.Size(125, 17)
        Me.tslblLabelStatus.Text = "ToolStripStatusLabel1"
        '
        'pnlPricesLabelsSelection
        '
        Me.pnlPricesLabelsSelection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPricesLabelsSelection.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.pnlPricesLabelsSelection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPricesLabelsSelection.Controls.Add(Me.btnNewExcel)
        Me.pnlPricesLabelsSelection.Controls.Add(Me.btnClearBartender)
        Me.pnlPricesLabelsSelection.Controls.Add(Me.btnClearExcel)
        Me.pnlPricesLabelsSelection.Controls.Add(Me.GroupBox4)
        Me.pnlPricesLabelsSelection.Controls.Add(Me.GroupBox3)
        Me.pnlPricesLabelsSelection.Controls.Add(Me.lblBartender)
        Me.pnlPricesLabelsSelection.Controls.Add(Me.picBartender)
        Me.pnlPricesLabelsSelection.Controls.Add(Me.btnLoadBartenderLabel)
        Me.pnlPricesLabelsSelection.Controls.Add(Me.lblLoadBarTenderLabel)
        Me.pnlPricesLabelsSelection.Controls.Add(Me.GroupBox1)
        Me.pnlPricesLabelsSelection.Controls.Add(Me.lblPriceSheet)
        Me.pnlPricesLabelsSelection.Controls.Add(Me.picExcel)
        Me.pnlPricesLabelsSelection.Controls.Add(Me.btnPriceList)
        Me.pnlPricesLabelsSelection.Controls.Add(Me.lblLoadExcelPriceList)
        Me.pnlPricesLabelsSelection.Location = New System.Drawing.Point(578, 188)
        Me.pnlPricesLabelsSelection.Name = "pnlPricesLabelsSelection"
        Me.pnlPricesLabelsSelection.Size = New System.Drawing.Size(459, 59)
        Me.pnlPricesLabelsSelection.TabIndex = 129
        '
        'btnNewExcel
        '
        Me.btnNewExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewExcel.Image = Global.MassasrelliLabelPrinterLNQ.My.Resources.Resources.Excel
        Me.btnNewExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNewExcel.Location = New System.Drawing.Point(146, 2)
        Me.btnNewExcel.Name = "btnNewExcel"
        Me.btnNewExcel.Size = New System.Drawing.Size(58, 23)
        Me.btnNewExcel.TabIndex = 168
        Me.btnNewExcel.Text = "New"
        Me.btnNewExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNewExcel.UseVisualStyleBackColor = True
        '
        'btnClearBartender
        '
        Me.btnClearBartender.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearBartender.Image = Global.MassasrelliLabelPrinterLNQ.My.Resources.Resources.Clear_Plain1616_E
        Me.btnClearBartender.Location = New System.Drawing.Point(341, 2)
        Me.btnClearBartender.Name = "btnClearBartender"
        Me.btnClearBartender.Size = New System.Drawing.Size(23, 23)
        Me.btnClearBartender.TabIndex = 167
        Me.btnClearBartender.UseVisualStyleBackColor = True
        '
        'btnClearExcel
        '
        Me.btnClearExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearExcel.Image = Global.MassasrelliLabelPrinterLNQ.My.Resources.Resources.Clear_Plain1616_E
        Me.btnClearExcel.Location = New System.Drawing.Point(117, 2)
        Me.btnClearExcel.Name = "btnClearExcel"
        Me.btnClearExcel.Size = New System.Drawing.Size(23, 23)
        Me.btnClearExcel.TabIndex = 166
        Me.btnClearExcel.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Location = New System.Drawing.Point(210, 27)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(2, 29)
        Me.GroupBox4.TabIndex = 153
        Me.GroupBox4.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(210, -1)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(2, 29)
        Me.GroupBox3.TabIndex = 152
        Me.GroupBox3.TabStop = False
        '
        'lblBartender
        '
        Me.lblBartender.AutoSize = True
        Me.lblBartender.Location = New System.Drawing.Point(290, 36)
        Me.lblBartender.MaximumSize = New System.Drawing.Size(212, 13)
        Me.lblBartender.Name = "lblBartender"
        Me.lblBartender.Size = New System.Drawing.Size(0, 13)
        Me.lblBartender.TabIndex = 151
        '
        'picBartender
        '
        Me.picBartender.Image = CType(resources.GetObject("picBartender.Image"), System.Drawing.Image)
        Me.picBartender.Location = New System.Drawing.Point(218, 36)
        Me.picBartender.Name = "picBartender"
        Me.picBartender.Size = New System.Drawing.Size(17, 16)
        Me.picBartender.TabIndex = 150
        Me.picBartender.TabStop = False
        '
        'btnLoadBartenderLabel
        '
        Me.btnLoadBartenderLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadBartenderLabel.Location = New System.Drawing.Point(316, 2)
        Me.btnLoadBartenderLabel.Name = "btnLoadBartenderLabel"
        Me.btnLoadBartenderLabel.Size = New System.Drawing.Size(23, 23)
        Me.btnLoadBartenderLabel.TabIndex = 149
        Me.btnLoadBartenderLabel.Text = "..."
        Me.btnLoadBartenderLabel.UseVisualStyleBackColor = True
        '
        'lblLoadBarTenderLabel
        '
        Me.lblLoadBarTenderLabel.AutoSize = True
        Me.lblLoadBarTenderLabel.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadBarTenderLabel.Location = New System.Drawing.Point(215, 5)
        Me.lblLoadBarTenderLabel.Name = "lblLoadBarTenderLabel"
        Me.lblLoadBarTenderLabel.Size = New System.Drawing.Size(92, 16)
        Me.lblLoadBarTenderLabel.TabIndex = 148
        Me.lblLoadBarTenderLabel.Text = "Load BarTender"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(457, 2)
        Me.GroupBox1.TabIndex = 146
        Me.GroupBox1.TabStop = False
        '
        'lblPriceSheet
        '
        Me.lblPriceSheet.AutoSize = True
        Me.lblPriceSheet.Location = New System.Drawing.Point(33, 36)
        Me.lblPriceSheet.MaximumSize = New System.Drawing.Size(212, 13)
        Me.lblPriceSheet.Name = "lblPriceSheet"
        Me.lblPriceSheet.Size = New System.Drawing.Size(0, 13)
        Me.lblPriceSheet.TabIndex = 145
        '
        'picExcel
        '
        Me.picExcel.Image = CType(resources.GetObject("picExcel.Image"), System.Drawing.Image)
        Me.picExcel.Location = New System.Drawing.Point(10, 36)
        Me.picExcel.Name = "picExcel"
        Me.picExcel.Size = New System.Drawing.Size(17, 16)
        Me.picExcel.TabIndex = 144
        Me.picExcel.TabStop = False
        '
        'btnPriceList
        '
        Me.btnPriceList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPriceList.Location = New System.Drawing.Point(92, 2)
        Me.btnPriceList.Name = "btnPriceList"
        Me.btnPriceList.Size = New System.Drawing.Size(23, 23)
        Me.btnPriceList.TabIndex = 143
        Me.btnPriceList.Text = "..."
        Me.btnPriceList.UseVisualStyleBackColor = True
        '
        'lblLoadExcelPriceList
        '
        Me.lblLoadExcelPriceList.AutoSize = True
        Me.lblLoadExcelPriceList.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadExcelPriceList.Location = New System.Drawing.Point(7, 5)
        Me.lblLoadExcelPriceList.Name = "lblLoadExcelPriceList"
        Me.lblLoadExcelPriceList.Size = New System.Drawing.Size(66, 16)
        Me.lblLoadExcelPriceList.TabIndex = 142
        Me.lblLoadExcelPriceList.Text = "Load Excel"
        '
        'imgListUpDown
        '
        Me.imgListUpDown.ImageStream = CType(resources.GetObject("imgListUpDown.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgListUpDown.TransparentColor = System.Drawing.Color.Transparent
        Me.imgListUpDown.Images.SetKeyName(0, "CloseUp_07.ico")
        Me.imgListUpDown.Images.SetKeyName(1, "OpenUp_07.ico")
        Me.imgListUpDown.Images.SetKeyName(2, "Check1616Disabled.ico")
        Me.imgListUpDown.Images.SetKeyName(3, "Check1616.ico")
        Me.imgListUpDown.Images.SetKeyName(4, "BTAdd_02.ico")
        Me.imgListUpDown.Images.SetKeyName(5, "BTRemove_02.ico")
        Me.imgListUpDown.Images.SetKeyName(6, "Refresh1616.ico")
        '
        'dgvExcelPriceList
        '
        Me.dgvExcelPriceList.AllowDrop = True
        Me.dgvExcelPriceList.AllowUserToAddRows = False
        Me.dgvExcelPriceList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvExcelPriceList.AutoGenerateColumns = False
        Me.dgvExcelPriceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvExcelPriceList.DataSource = Me.bsrcExcelPriceList
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvExcelPriceList.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvExcelPriceList.Location = New System.Drawing.Point(578, 245)
        Me.dgvExcelPriceList.Name = "dgvExcelPriceList"
        Me.dgvExcelPriceList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExcelPriceList.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvExcelPriceList.RowHeadersVisible = False
        Me.dgvExcelPriceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvExcelPriceList.Size = New System.Drawing.Size(459, 390)
        Me.dgvExcelPriceList.TabIndex = 129
        '
        'OpenFileDialogBartender
        '
        Me.OpenFileDialogBartender.DefaultExt = "btw"
        Me.OpenFileDialogBartender.Filter = "BarTender Label Formats (*.btw)|*.btw"
        Me.OpenFileDialogBartender.Title = "Open BarTender Label Format"
        '
        'lblNumPreviews
        '
        Me.lblNumPreviews.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNumPreviews.AutoSize = True
        Me.lblNumPreviews.Location = New System.Drawing.Point(783, 648)
        Me.lblNumPreviews.Name = "lblNumPreviews"
        Me.lblNumPreviews.Size = New System.Drawing.Size(62, 13)
        Me.lblNumPreviews.TabIndex = 153
        Me.lblNumPreviews.Text = "Page 0 of 0"
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNext.Location = New System.Drawing.Point(957, 643)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(37, 23)
        Me.btnNext.TabIndex = 154
        Me.btnNext.Text = ">"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnLast
        '
        Me.btnLast.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLast.Location = New System.Drawing.Point(1000, 643)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(37, 23)
        Me.btnLast.TabIndex = 155
        Me.btnLast.Text = ">>"
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'btnPrev
        '
        Me.btnPrev.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrev.Location = New System.Drawing.Point(622, 643)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(37, 23)
        Me.btnPrev.TabIndex = 152
        Me.btnPrev.Text = "<"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'btnFirst
        '
        Me.btnFirst.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFirst.Location = New System.Drawing.Point(578, 643)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(37, 23)
        Me.btnFirst.TabIndex = 151
        Me.btnFirst.Text = "<<"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'cboPrinters
        '
        Me.cboPrinters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrinters.FormattingEnabled = True
        Me.cboPrinters.Location = New System.Drawing.Point(770, 4)
        Me.cboPrinters.Name = "cboPrinters"
        Me.cboPrinters.Size = New System.Drawing.Size(258, 21)
        Me.cboPrinters.Sorted = True
        Me.cboPrinters.TabIndex = 157
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(724, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 156
        Me.Label7.Text = "&Printer:"
        '
        'backgroundWorker
        '
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Menu
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.btnItems)
        Me.Panel1.Controls.Add(Me.btnOrders)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Location = New System.Drawing.Point(349, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(199, 23)
        Me.Panel1.TabIndex = 168
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(25, 4)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 13)
        Me.Label13.TabIndex = 170
        Me.Label13.Text = "Search For:"
        '
        'btnItems
        '
        Me.btnItems.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnItems.Location = New System.Drawing.Point(144, 1)
        Me.btnItems.Name = "btnItems"
        Me.btnItems.Size = New System.Drawing.Size(48, 19)
        Me.btnItems.TabIndex = 169
        Me.btnItems.Text = "Items"
        Me.btnItems.UseVisualStyleBackColor = True
        '
        'btnOrders
        '
        Me.btnOrders.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOrders.Location = New System.Drawing.Point(90, 1)
        Me.btnOrders.Name = "btnOrders"
        Me.btnOrders.Size = New System.Drawing.Size(48, 19)
        Me.btnOrders.TabIndex = 168
        Me.btnOrders.Text = "Orders"
        Me.btnOrders.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(3, 2)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(17, 16)
        Me.PictureBox3.TabIndex = 163
        Me.PictureBox3.TabStop = False
        '
        'rdPending
        '
        Me.rdPending.AutoSize = True
        Me.rdPending.Checked = True
        Me.rdPending.Location = New System.Drawing.Point(218, 5)
        Me.rdPending.Name = "rdPending"
        Me.rdPending.Size = New System.Drawing.Size(64, 17)
        Me.rdPending.TabIndex = 169
        Me.rdPending.TabStop = True
        Me.rdPending.Text = "Pending"
        Me.rdPending.UseVisualStyleBackColor = True
        '
        'rdHistory
        '
        Me.rdHistory.AutoSize = True
        Me.rdHistory.Location = New System.Drawing.Point(285, 5)
        Me.rdHistory.Name = "rdHistory"
        Me.rdHistory.Size = New System.Drawing.Size(57, 17)
        Me.rdHistory.TabIndex = 170
        Me.rdHistory.Text = "History"
        Me.rdHistory.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(168, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 171
        Me.Label5.Text = "Orders:"
        '
        'btnShowAll
        '
        Me.btnShowAll.Image = Global.MassasrelliLabelPrinterLNQ.My.Resources.Resources.ShowAll_PLAIN
        Me.btnShowAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnShowAll.Location = New System.Drawing.Point(551, 3)
        Me.btnShowAll.Name = "btnShowAll"
        Me.btnShowAll.Size = New System.Drawing.Size(74, 21)
        Me.btnShowAll.TabIndex = 162
        Me.btnShowAll.Text = "     Show All"
        Me.btnShowAll.UseVisualStyleBackColor = True
        '
        'btnClearAll
        '
        Me.btnClearAll.Image = Global.MassasrelliLabelPrinterLNQ.My.Resources.Resources.Clear_Plain1616_c
        Me.btnClearAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClearAll.Location = New System.Drawing.Point(631, 3)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.Size = New System.Drawing.Size(68, 21)
        Me.btnClearAll.TabIndex = 161
        Me.btnClearAll.Text = "     Clear All"
        Me.btnClearAll.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Image = Global.MassasrelliLabelPrinterLNQ.My.Resources.Resources.Printer1616_PLAIN
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(86, 3)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(70, 21)
        Me.btnPrint.TabIndex = 160
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(706, 5)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(17, 16)
        Me.PictureBox2.TabIndex = 159
        Me.PictureBox2.TabStop = False
        '
        'btnPreview
        '
        Me.btnPreview.Enabled = False
        Me.btnPreview.Image = Global.MassasrelliLabelPrinterLNQ.My.Resources.Resources.Printer1616_PLAIN2
        Me.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPreview.Location = New System.Drawing.Point(12, 3)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(70, 21)
        Me.btnPreview.TabIndex = 158
        Me.btnPreview.Text = "Preview"
        Me.btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'picUpdating
        '
        Me.picUpdating.BackColor = System.Drawing.Color.White
        Me.picUpdating.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.picUpdating.Location = New System.Drawing.Point(799, 460)
        Me.picUpdating.Name = "picUpdating"
        Me.picUpdating.Size = New System.Drawing.Size(24, 24)
        Me.picUpdating.TabIndex = 150
        Me.picUpdating.TabStop = False
        Me.picUpdating.Visible = False
        '
        'picPreview
        '
        Me.picPreview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picPreview.BackColor = System.Drawing.Color.Gray
        Me.picPreview.Location = New System.Drawing.Point(579, 246)
        Me.picPreview.Margin = New System.Windows.Forms.Padding(0)
        Me.picPreview.Name = "picPreview"
        Me.picPreview.Size = New System.Drawing.Size(458, 351)
        Me.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picPreview.TabIndex = 149
        Me.picPreview.TabStop = False
        '
        'ToolStripButtonExit
        '
        Me.ToolStripButtonExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonExit.Image = CType(resources.GetObject("ToolStripButtonExit.Image"), System.Drawing.Image)
        Me.ToolStripButtonExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonExit.Name = "ToolStripButtonExit"
        Me.ToolStripButtonExit.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonExit.Text = "Exit"
        '
        'ToolStripButtonPrint
        '
        Me.ToolStripButtonPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonPrint.Image = CType(resources.GetObject("ToolStripButtonPrint.Image"), System.Drawing.Image)
        Me.ToolStripButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonPrint.Name = "ToolStripButtonPrint"
        Me.ToolStripButtonPrint.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonPrint.Text = "Print"
        '
        'ToolStripButtonSave
        '
        Me.ToolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonSave.Image = CType(resources.GetObject("ToolStripButtonSave.Image"), System.Drawing.Image)
        Me.ToolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSave.Name = "ToolStripButtonSave"
        Me.ToolStripButtonSave.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonSave.Text = "Save"
        '
        'ToolStripButtonBLANK
        '
        Me.ToolStripButtonBLANK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripButtonBLANK.Image = CType(resources.GetObject("ToolStripButtonBLANK.Image"), System.Drawing.Image)
        Me.ToolStripButtonBLANK.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonBLANK.Name = "ToolStripButtonBLANK"
        Me.ToolStripButtonBLANK.Size = New System.Drawing.Size(23, 22)
        '
        'ToolStripButtonClear
        '
        Me.ToolStripButtonClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonClear.Image = CType(resources.GetObject("ToolStripButtonClear.Image"), System.Drawing.Image)
        Me.ToolStripButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonClear.Name = "ToolStripButtonClear"
        Me.ToolStripButtonClear.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonClear.Text = "Clear Grid"
        '
        'ToolStripButtonSerialNumber
        '
        Me.ToolStripButtonSerialNumber.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonSerialNumber.Image = CType(resources.GetObject("ToolStripButtonSerialNumber.Image"), System.Drawing.Image)
        Me.ToolStripButtonSerialNumber.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSerialNumber.Name = "ToolStripButtonSerialNumber"
        Me.ToolStripButtonSerialNumber.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonSerialNumber.Text = "Generate Serial Number"
        '
        'ToolStripButtonMACAddress
        '
        Me.ToolStripButtonMACAddress.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonMACAddress.Image = CType(resources.GetObject("ToolStripButtonMACAddress.Image"), System.Drawing.Image)
        Me.ToolStripButtonMACAddress.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonMACAddress.Name = "ToolStripButtonMACAddress"
        Me.ToolStripButtonMACAddress.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonMACAddress.Text = "Generate MAC Address"
        '
        'ToolStripButtonSettings
        '
        Me.ToolStripButtonSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonSettings.Image = CType(resources.GetObject("ToolStripButtonSettings.Image"), System.Drawing.Image)
        Me.ToolStripButtonSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSettings.Name = "ToolStripButtonSettings"
        Me.ToolStripButtonSettings.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonSettings.Text = "Settings"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 188)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvOrderItemsSelected)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvSpecialOrder)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel4)
        Me.SplitContainer1.Size = New System.Drawing.Size(560, 477)
        Me.SplitContainer1.SplitterDistance = 307
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 172
        '
        'dgvOrderItemsSelected
        '
        Me.dgvOrderItemsSelected.AllowUserToAddRows = False
        Me.dgvOrderItemsSelected.AllowUserToDeleteRows = False
        Me.dgvOrderItemsSelected.AllowUserToResizeColumns = False
        Me.dgvOrderItemsSelected.AllowUserToResizeRows = False
        Me.dgvOrderItemsSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrderItemsSelected.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOrderItemsSelected.Location = New System.Drawing.Point(0, 59)
        Me.dgvOrderItemsSelected.Name = "dgvOrderItemsSelected"
        Me.dgvOrderItemsSelected.Size = New System.Drawing.Size(560, 248)
        Me.dgvOrderItemsSelected.TabIndex = 150
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.btnRemoveRows)
        Me.Panel3.Controls.Add(Me.pnlExcelSpreadsheetNotLoaded)
        Me.Panel3.Controls.Add(Me.GroupBox9)
        Me.Panel3.Controls.Add(Me.GroupBox8)
        Me.Panel3.Controls.Add(Me.GroupBox7)
        Me.Panel3.Controls.Add(Me.btnSelectItemsToPrint)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.btnSetSortOrder)
        Me.Panel3.Controls.Add(Me.lblAdvancedSort)
        Me.Panel3.Controls.Add(Me.GroupBox2)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(560, 59)
        Me.Panel3.TabIndex = 149
        '
        'btnRemoveRows
        '
        Me.btnRemoveRows.Image = Global.MassasrelliLabelPrinterLNQ.My.Resources.Resources.Clear_Plain1616_c
        Me.btnRemoveRows.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemoveRows.Location = New System.Drawing.Point(2, 33)
        Me.btnRemoveRows.Name = "btnRemoveRows"
        Me.btnRemoveRows.Size = New System.Drawing.Size(109, 21)
        Me.btnRemoveRows.TabIndex = 167
        Me.btnRemoveRows.Text = "     Remove Row(s)"
        Me.btnRemoveRows.UseVisualStyleBackColor = True
        '
        'pnlExcelSpreadsheetNotLoaded
        '
        Me.pnlExcelSpreadsheetNotLoaded.BackColor = System.Drawing.SystemColors.Info
        Me.pnlExcelSpreadsheetNotLoaded.Controls.Add(Me.picExcelNotLoaded)
        Me.pnlExcelSpreadsheetNotLoaded.Controls.Add(Me.txtExcelNotLoaded)
        Me.pnlExcelSpreadsheetNotLoaded.Location = New System.Drawing.Point(111, 5)
        Me.pnlExcelSpreadsheetNotLoaded.Name = "pnlExcelSpreadsheetNotLoaded"
        Me.pnlExcelSpreadsheetNotLoaded.Size = New System.Drawing.Size(200, 18)
        Me.pnlExcelSpreadsheetNotLoaded.TabIndex = 166
        Me.pnlExcelSpreadsheetNotLoaded.Visible = False
        '
        'picExcelNotLoaded
        '
        Me.picExcelNotLoaded.Image = CType(resources.GetObject("picExcelNotLoaded.Image"), System.Drawing.Image)
        Me.picExcelNotLoaded.Location = New System.Drawing.Point(181, 2)
        Me.picExcelNotLoaded.Name = "picExcelNotLoaded"
        Me.picExcelNotLoaded.Size = New System.Drawing.Size(17, 16)
        Me.picExcelNotLoaded.TabIndex = 165
        Me.picExcelNotLoaded.TabStop = False
        '
        'txtExcelNotLoaded
        '
        Me.txtExcelNotLoaded.BackColor = System.Drawing.SystemColors.Info
        Me.txtExcelNotLoaded.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtExcelNotLoaded.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExcelNotLoaded.Location = New System.Drawing.Point(4, 1)
        Me.txtExcelNotLoaded.Name = "txtExcelNotLoaded"
        Me.txtExcelNotLoaded.ReadOnly = True
        Me.txtExcelNotLoaded.Size = New System.Drawing.Size(172, 14)
        Me.txtExcelNotLoaded.TabIndex = 166
        Me.txtExcelNotLoaded.Text = "Excel Spreadsheet Not Loaded"
        '
        'GroupBox9
        '
        Me.GroupBox9.Location = New System.Drawing.Point(96, -1)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(2, 29)
        Me.GroupBox9.TabIndex = 155
        Me.GroupBox9.TabStop = False
        '
        'GroupBox8
        '
        Me.GroupBox8.Location = New System.Drawing.Point(327, 27)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(2, 29)
        Me.GroupBox8.TabIndex = 154
        Me.GroupBox8.TabStop = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Location = New System.Drawing.Point(327, -1)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(2, 29)
        Me.GroupBox7.TabIndex = 153
        Me.GroupBox7.TabStop = False
        '
        'btnSelectItemsToPrint
        '
        Me.btnSelectItemsToPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectItemsToPrint.ImageKey = "BTAdd_02.ico"
        Me.btnSelectItemsToPrint.ImageList = Me.imgListUpDown
        Me.btnSelectItemsToPrint.Location = New System.Drawing.Point(525, 2)
        Me.btnSelectItemsToPrint.Name = "btnSelectItemsToPrint"
        Me.btnSelectItemsToPrint.Size = New System.Drawing.Size(23, 23)
        Me.btnSelectItemsToPrint.TabIndex = 150
        Me.btnSelectItemsToPrint.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(371, 5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(151, 16)
        Me.Label12.TabIndex = 149
        Me.Label12.Text = "Show / Hide Check Column"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSetSortOrder
        '
        Me.btnSetSortOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetSortOrder.ImageKey = "BTAdd_02.ico"
        Me.btnSetSortOrder.ImageList = Me.imgListUpDown
        Me.btnSetSortOrder.Location = New System.Drawing.Point(525, 32)
        Me.btnSetSortOrder.Name = "btnSetSortOrder"
        Me.btnSetSortOrder.Size = New System.Drawing.Size(23, 23)
        Me.btnSetSortOrder.TabIndex = 148
        Me.btnSetSortOrder.UseVisualStyleBackColor = True
        '
        'lblAdvancedSort
        '
        Me.lblAdvancedSort.AutoSize = True
        Me.lblAdvancedSort.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdvancedSort.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAdvancedSort.Location = New System.Drawing.Point(404, 36)
        Me.lblAdvancedSort.Name = "lblAdvancedSort"
        Me.lblAdvancedSort.Size = New System.Drawing.Size(118, 16)
        Me.lblAdvancedSort.TabIndex = 147
        Me.lblAdvancedSort.Text = "Advanced Sort Order"
        Me.lblAdvancedSort.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(6, 29)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(541, 2)
        Me.GroupBox2.TabIndex = 146
        Me.GroupBox2.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 16)
        Me.Label6.TabIndex = 142
        Me.Label6.Text = "Labels to Print"
        '
        'dgvSpecialOrder
        '
        Me.dgvSpecialOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSpecialOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSpecialOrder.Location = New System.Drawing.Point(0, 31)
        Me.dgvSpecialOrder.Name = "dgvSpecialOrder"
        Me.dgvSpecialOrder.Size = New System.Drawing.Size(560, 136)
        Me.dgvSpecialOrder.TabIndex = 165
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.btnSelectAllCopy)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(560, 31)
        Me.Panel4.TabIndex = 166
        '
        'btnSelectAllCopy
        '
        Me.btnSelectAllCopy.Location = New System.Drawing.Point(406, 2)
        Me.btnSelectAllCopy.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSelectAllCopy.Name = "btnSelectAllCopy"
        Me.btnSelectAllCopy.Size = New System.Drawing.Size(112, 25)
        Me.btnSelectAllCopy.TabIndex = 143
        Me.btnSelectAllCopy.Text = "SelectAll && Copy"
        Me.btnSelectAllCopy.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(317, 16)
        Me.Label9.TabIndex = 142
        Me.Label9.Text = "Special Order - OR - Items or Finish Missing from Price List"
        '
        'pnlSortOrder
        '
        Me.pnlSortOrder.AllowDrop = True
        Me.pnlSortOrder.Controls.Add(Me.Panel6)
        Me.pnlSortOrder.Controls.Add(Me.TextBox2)
        Me.pnlSortOrder.Controls.Add(Me.TextBox1)
        Me.pnlSortOrder.Controls.Add(Me.dgvSortOrder)
        Me.pnlSortOrder.Controls.Add(Me.dgvSortableColumns)
        Me.pnlSortOrder.Location = New System.Drawing.Point(577, 247)
        Me.pnlSortOrder.Name = "pnlSortOrder"
        Me.pnlSortOrder.Size = New System.Drawing.Size(206, 233)
        Me.pnlSortOrder.TabIndex = 152
        Me.pnlSortOrder.Visible = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel6.Controls.Add(Me.GroupBox5)
        Me.Panel6.Controls.Add(Me.Button1)
        Me.Panel6.Controls.Add(Me.Label10)
        Me.Panel6.Controls.Add(Me.TextBox3)
        Me.Panel6.Location = New System.Drawing.Point(3, 181)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(197, 50)
        Me.Panel6.TabIndex = 5
        '
        'GroupBox5
        '
        Me.GroupBox5.Location = New System.Drawing.Point(9, 23)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(148, 2)
        Me.GroupBox5.TabIndex = 156
        Me.GroupBox5.TabStop = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.MassasrelliLabelPrinterLNQ.My.Resources.Resources.Apply
        Me.Button1.Location = New System.Drawing.Point(127, 27)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(23, 20)
        Me.Button1.TabIndex = 155
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(58, 29)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 16)
        Me.Label10.TabIndex = 154
        Me.Label10.Text = "Apply Sort"
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.Location = New System.Drawing.Point(0, 3)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(197, 19)
        Me.TextBox3.TabIndex = 153
        Me.TextBox3.Text = "Drag On ->    or    <- Drag Off"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Location = New System.Drawing.Point(105, 3)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(95, 32)
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.Text = "Sort" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Order"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(5, 3)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(95, 32)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = "Available" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sort Fields"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgvSortOrder
        '
        Me.dgvSortOrder.AllowDrop = True
        Me.dgvSortOrder.AllowUserToAddRows = False
        Me.dgvSortOrder.AllowUserToDeleteRows = False
        Me.dgvSortOrder.AllowUserToResizeColumns = False
        Me.dgvSortOrder.AllowUserToResizeRows = False
        Me.dgvSortOrder.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSortOrder.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvSortOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSortOrder.ColumnHeadersVisible = False
        Me.dgvSortOrder.Location = New System.Drawing.Point(105, 40)
        Me.dgvSortOrder.Name = "dgvSortOrder"
        Me.dgvSortOrder.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvSortOrder.RowHeadersVisible = False
        Me.dgvSortOrder.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgvSortOrder.Size = New System.Drawing.Size(95, 135)
        Me.dgvSortOrder.TabIndex = 1
        '
        'dgvSortableColumns
        '
        Me.dgvSortableColumns.AllowDrop = True
        Me.dgvSortableColumns.AllowUserToAddRows = False
        Me.dgvSortableColumns.AllowUserToDeleteRows = False
        Me.dgvSortableColumns.AllowUserToResizeColumns = False
        Me.dgvSortableColumns.AllowUserToResizeRows = False
        Me.dgvSortableColumns.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSortableColumns.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvSortableColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSortableColumns.ColumnHeadersVisible = False
        Me.dgvSortableColumns.Location = New System.Drawing.Point(4, 40)
        Me.dgvSortableColumns.Name = "dgvSortableColumns"
        Me.dgvSortableColumns.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvSortableColumns.RowHeadersVisible = False
        Me.dgvSortableColumns.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgvSortableColumns.Size = New System.Drawing.Size(95, 135)
        Me.dgvSortableColumns.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.pnlItemList)
        Me.Panel2.Controls.Add(Me.pnlOrderList)
        Me.Panel2.Location = New System.Drawing.Point(12, 30)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1015, 150)
        Me.Panel2.TabIndex = 175
        '
        'pnlItemList
        '
        Me.pnlItemList.Controls.Add(Me.dgvItemList)
        Me.pnlItemList.Controls.Add(Me.pnlItems)
        Me.pnlItemList.Location = New System.Drawing.Point(560, 0)
        Me.pnlItemList.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlItemList.Name = "pnlItemList"
        Me.pnlItemList.Size = New System.Drawing.Size(508, 143)
        Me.pnlItemList.TabIndex = 178
        '
        'dgvItemList
        '
        Me.dgvItemList.AllowDrop = True
        Me.dgvItemList.AllowUserToAddRows = False
        Me.dgvItemList.AllowUserToDeleteRows = False
        Me.dgvItemList.AllowUserToResizeRows = False
        Me.dgvItemList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItemList.ColumnHeadersVisible = False
        Me.dgvItemList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvItemList.Location = New System.Drawing.Point(0, 46)
        Me.dgvItemList.Name = "dgvItemList"
        Me.dgvItemList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvItemList.RowHeadersVisible = False
        Me.dgvItemList.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgvItemList.Size = New System.Drawing.Size(508, 97)
        Me.dgvItemList.TabIndex = 9
        '
        'pnlItems
        '
        Me.pnlItems.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pnlItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlItems.Controls.Add(Me.Label16)
        Me.pnlItems.Controls.Add(Me.Label15)
        Me.pnlItems.Controls.Add(Me.Label14)
        Me.pnlItems.Controls.Add(Me.txtProdCat)
        Me.pnlItems.Controls.Add(Me.txtItemDesc)
        Me.pnlItems.Controls.Add(Me.txtItemNo)
        Me.pnlItems.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlItems.Location = New System.Drawing.Point(0, 0)
        Me.pnlItems.Name = "pnlItems"
        Me.pnlItems.Size = New System.Drawing.Size(508, 46)
        Me.pnlItems.TabIndex = 8
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(459, 7)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 13)
        Me.Label16.TabIndex = 11
        Me.Label16.Text = "Prod Cat"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(101, 7)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(83, 13)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "Item Description"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 7)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(37, 13)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "Item #"
        '
        'txtProdCat
        '
        Me.txtProdCat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProdCat.Location = New System.Drawing.Point(458, 24)
        Me.txtProdCat.Name = "txtProdCat"
        Me.txtProdCat.Size = New System.Drawing.Size(73, 20)
        Me.txtProdCat.TabIndex = 7
        '
        'txtItemDesc
        '
        Me.txtItemDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemDesc.Location = New System.Drawing.Point(96, 24)
        Me.txtItemDesc.Name = "txtItemDesc"
        Me.txtItemDesc.Size = New System.Drawing.Size(361, 20)
        Me.txtItemDesc.TabIndex = 5
        '
        'txtItemNo
        '
        Me.txtItemNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemNo.Location = New System.Drawing.Point(0, 24)
        Me.txtItemNo.Name = "txtItemNo"
        Me.txtItemNo.Size = New System.Drawing.Size(96, 20)
        Me.txtItemNo.TabIndex = 4
        '
        'pnlOrderList
        '
        Me.pnlOrderList.Controls.Add(Me.dgvOrderList)
        Me.pnlOrderList.Controls.Add(Me.pnlOrders)
        Me.pnlOrderList.Location = New System.Drawing.Point(2, 0)
        Me.pnlOrderList.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlOrderList.Name = "pnlOrderList"
        Me.pnlOrderList.Size = New System.Drawing.Size(533, 143)
        Me.pnlOrderList.TabIndex = 177
        '
        'dgvOrderList
        '
        Me.dgvOrderList.AllowUserToAddRows = False
        Me.dgvOrderList.AllowUserToDeleteRows = False
        Me.dgvOrderList.AllowUserToOrderColumns = True
        Me.dgvOrderList.AllowUserToResizeColumns = False
        Me.dgvOrderList.AllowUserToResizeRows = False
        Me.dgvOrderList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrderList.ColumnHeadersVisible = False
        Me.dgvOrderList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOrderList.Location = New System.Drawing.Point(0, 46)
        Me.dgvOrderList.Name = "dgvOrderList"
        Me.dgvOrderList.RowHeadersVisible = False
        Me.dgvOrderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOrderList.Size = New System.Drawing.Size(533, 97)
        Me.dgvOrderList.TabIndex = 130
        '
        'pnlOrders
        '
        Me.pnlOrders.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.pnlOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlOrders.Controls.Add(Me.btnRefresh)
        Me.pnlOrders.Controls.Add(Me.Label3)
        Me.pnlOrders.Controls.Add(Me.lblStatus)
        Me.pnlOrders.Controls.Add(Me.txtStatus)
        Me.pnlOrders.Controls.Add(Me.lblAltAddr)
        Me.pnlOrders.Controls.Add(Me.txtCustAltAdrCode)
        Me.pnlOrders.Controls.Add(Me.lblCusNo)
        Me.pnlOrders.Controls.Add(Me.txtCustNo)
        Me.pnlOrders.Controls.Add(Me.lblOrderDate)
        Me.pnlOrders.Controls.Add(Me.txtOrderDate)
        Me.pnlOrders.Controls.Add(Me.lblOrderNo)
        Me.pnlOrders.Controls.Add(Me.txtOrderNo)
        Me.pnlOrders.Controls.Add(Me.lblShipTo)
        Me.pnlOrders.Controls.Add(Me.txtShipToName)
        Me.pnlOrders.Controls.Add(Me.Label2)
        Me.pnlOrders.Controls.Add(Me.txtBillToName)
        Me.pnlOrders.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlOrders.Location = New System.Drawing.Point(0, 0)
        Me.pnlOrders.Name = "pnlOrders"
        Me.pnlOrders.Size = New System.Drawing.Size(533, 46)
        Me.pnlOrders.TabIndex = 129
        '
        'btnRefresh
        '
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ImageKey = "Refresh1616.ico"
        Me.btnRefresh.ImageList = Me.imgListUpDown
        Me.btnRefresh.Location = New System.Drawing.Point(14, 20)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(23, 23)
        Me.btnRefresh.TabIndex = 149
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(2, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 16)
        Me.Label3.TabIndex = 141
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(873, 3)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(41, 15)
        Me.lblStatus.TabIndex = 140
        Me.lblStatus.Text = "Status"
        '
        'txtStatus
        '
        Me.txtStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStatus.Location = New System.Drawing.Point(876, 24)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(335, 20)
        Me.txtStatus.TabIndex = 139
        '
        'lblAltAddr
        '
        Me.lblAltAddr.AutoSize = True
        Me.lblAltAddr.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltAddr.Location = New System.Drawing.Point(283, 3)
        Me.lblAltAddr.Name = "lblAltAddr"
        Me.lblAltAddr.Size = New System.Drawing.Size(51, 15)
        Me.lblAltAddr.TabIndex = 138
        Me.lblAltAddr.Text = "Alt Addr"
        '
        'txtCustAltAdrCode
        '
        Me.txtCustAltAdrCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustAltAdrCode.Location = New System.Drawing.Point(286, 24)
        Me.txtCustAltAdrCode.Name = "txtCustAltAdrCode"
        Me.txtCustAltAdrCode.Size = New System.Drawing.Size(90, 20)
        Me.txtCustAltAdrCode.TabIndex = 137
        '
        'lblCusNo
        '
        Me.lblCusNo.AutoSize = True
        Me.lblCusNo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCusNo.Location = New System.Drawing.Point(193, 3)
        Me.lblCusNo.Name = "lblCusNo"
        Me.lblCusNo.Size = New System.Drawing.Size(40, 15)
        Me.lblCusNo.TabIndex = 136
        Me.lblCusNo.Text = "Cust #"
        '
        'txtCustNo
        '
        Me.txtCustNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustNo.Location = New System.Drawing.Point(196, 24)
        Me.txtCustNo.Name = "txtCustNo"
        Me.txtCustNo.Size = New System.Drawing.Size(90, 20)
        Me.txtCustNo.TabIndex = 135
        '
        'lblOrderDate
        '
        Me.lblOrderDate.AutoSize = True
        Me.lblOrderDate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrderDate.Location = New System.Drawing.Point(118, 3)
        Me.lblOrderDate.Name = "lblOrderDate"
        Me.lblOrderDate.Size = New System.Drawing.Size(54, 15)
        Me.lblOrderDate.TabIndex = 134
        Me.lblOrderDate.Text = "Order Dt"
        '
        'txtOrderDate
        '
        Me.txtOrderDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrderDate.Location = New System.Drawing.Point(121, 24)
        Me.txtOrderDate.Name = "txtOrderDate"
        Me.txtOrderDate.Size = New System.Drawing.Size(75, 20)
        Me.txtOrderDate.TabIndex = 133
        '
        'lblOrderNo
        '
        Me.lblOrderNo.AutoSize = True
        Me.lblOrderNo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrderNo.Location = New System.Drawing.Point(43, 3)
        Me.lblOrderNo.Name = "lblOrderNo"
        Me.lblOrderNo.Size = New System.Drawing.Size(48, 15)
        Me.lblOrderNo.TabIndex = 132
        Me.lblOrderNo.Text = "Order #"
        '
        'txtOrderNo
        '
        Me.txtOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrderNo.Location = New System.Drawing.Point(46, 24)
        Me.txtOrderNo.Name = "txtOrderNo"
        Me.txtOrderNo.Size = New System.Drawing.Size(75, 20)
        Me.txtOrderNo.TabIndex = 131
        '
        'lblShipTo
        '
        Me.lblShipTo.AutoSize = True
        Me.lblShipTo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShipTo.Location = New System.Drawing.Point(623, 3)
        Me.lblShipTo.Name = "lblShipTo"
        Me.lblShipTo.Size = New System.Drawing.Size(80, 15)
        Me.lblShipTo.TabIndex = 130
        Me.lblShipTo.Text = "Ship To Name"
        '
        'txtShipToName
        '
        Me.txtShipToName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipToName.Location = New System.Drawing.Point(626, 24)
        Me.txtShipToName.Name = "txtShipToName"
        Me.txtShipToName.Size = New System.Drawing.Size(250, 20)
        Me.txtShipToName.TabIndex = 129
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(373, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 15)
        Me.Label2.TabIndex = 128
        Me.Label2.Text = "Bill To Name"
        '
        'txtBillToName
        '
        Me.txtBillToName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBillToName.Location = New System.Drawing.Point(376, 24)
        Me.txtBillToName.Name = "txtBillToName"
        Me.txtBillToName.Size = New System.Drawing.Size(250, 20)
        Me.txtBillToName.TabIndex = 127
        '
        'MassarelliLabelPrinter
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1045, 669)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.pnlSortOrder)
        Me.Controls.Add(Me.rdHistory)
        Me.Controls.Add(Me.rdPending)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnShowAll)
        Me.Controls.Add(Me.btnClearAll)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.cboPrinters)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblNumPreviews)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnLast)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.btnFirst)
        Me.Controls.Add(Me.picUpdating)
        Me.Controls.Add(Me.dgvExcelPriceList)
        Me.Controls.Add(Me.pnlPricesLabelsSelection)
        Me.Controls.Add(Me.picPreview)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MassarelliLabelPrinter"
        Me.Text = "Label Printer"
        Me.pnlPricesLabelsSelection.ResumeLayout(False)
        Me.pnlPricesLabelsSelection.PerformLayout()
        CType(Me.picBartender, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picExcel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvExcelPriceList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsrcExcelPriceList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picUpdating, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsrcOrderList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsrcOrderItemsSelected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsrcMissingData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsrcSortable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsrcItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsrcItemsToPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsrcHistoryList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvOrderItemsSelected, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlExcelSpreadsheetNotLoaded.ResumeLayout(False)
        Me.pnlExcelSpreadsheetNotLoaded.PerformLayout()
        CType(Me.picExcelNotLoaded, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSpecialOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlSortOrder.ResumeLayout(False)
        Me.pnlSortOrder.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.dgvSortOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSortableColumns, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.pnlItemList.ResumeLayout(False)
        CType(Me.dgvItemList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlItems.ResumeLayout(False)
        Me.pnlItems.PerformLayout()
        Me.pnlOrderList.ResumeLayout(False)
        CType(Me.dgvOrderList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOrders.ResumeLayout(False)
        Me.pnlOrders.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripButtonExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonBLANK As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonSerialNumber As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonMACAddress As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonSettings As System.Windows.Forms.ToolStripButton
    Friend WithEvents tslblDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslblCompany As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslblUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslbMaxProductionID As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslblLabelStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents bsrcOrderList As System.Windows.Forms.BindingSource
    Friend WithEvents pnlPricesLabelsSelection As System.Windows.Forms.Panel
    Friend WithEvents lblLoadExcelPriceList As System.Windows.Forms.Label
    Friend WithEvents dgvExcelPriceList As System.Windows.Forms.DataGridView
    Friend WithEvents btnPriceList As System.Windows.Forms.Button
    Friend WithEvents picExcel As System.Windows.Forms.PictureBox
    Friend WithEvents bsrcExcelPriceList As System.Windows.Forms.BindingSource
    Friend WithEvents lblPriceSheet As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents imgListUpDown As System.Windows.Forms.ImageList
    Friend WithEvents bsrcOrderItemsSelected As System.Windows.Forms.BindingSource
    Private WithEvents picPreview As System.Windows.Forms.PictureBox
    Private WithEvents picUpdating As System.Windows.Forms.PictureBox
    Friend WithEvents btnLoadBartenderLabel As System.Windows.Forms.Button
    Friend WithEvents lblLoadBarTenderLabel As System.Windows.Forms.Label
    Friend WithEvents lblBartender As System.Windows.Forms.Label
    Friend WithEvents picBartender As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents lblNumPreviews As System.Windows.Forms.Label
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents btnLast As System.Windows.Forms.Button
    Private WithEvents btnPrev As System.Windows.Forms.Button
    Private WithEvents btnFirst As System.Windows.Forms.Button
    Private WithEvents cboPrinters As System.Windows.Forms.ComboBox
    Private WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents backgroundWorker As System.ComponentModel.BackgroundWorker
    Private WithEvents OpenFileDialogBartender As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnClearAll As System.Windows.Forms.Button
    Friend WithEvents btnShowAll As System.Windows.Forms.Button
    Friend WithEvents bsrcMissingData As System.Windows.Forms.BindingSource
    Friend WithEvents bsrcSortable As System.Windows.Forms.BindingSource
    Friend WithEvents ToolTipLabelPrinter As System.Windows.Forms.ToolTip
    Friend WithEvents bsrcItemList As System.Windows.Forms.BindingSource
    Friend WithEvents bsrcItemsToPrint As System.Windows.Forms.BindingSource
    Friend WithEvents btnItems As System.Windows.Forms.Button
    Friend WithEvents btnOrders As System.Windows.Forms.Button
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnClearBartender As System.Windows.Forms.Button
    Friend WithEvents btnClearExcel As System.Windows.Forms.Button
    Friend WithEvents rdPending As System.Windows.Forms.RadioButton
    Friend WithEvents rdHistory As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents bsrcHistoryList As System.Windows.Forms.BindingSource
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pnlExcelSpreadsheetNotLoaded As System.Windows.Forms.Panel
    Friend WithEvents picExcelNotLoaded As System.Windows.Forms.PictureBox
    Friend WithEvents txtExcelNotLoaded As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSelectItemsToPrint As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnSetSortOrder As System.Windows.Forms.Button
    Friend WithEvents lblAdvancedSort As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgvOrderItemsSelected As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dgvSpecialOrder As System.Windows.Forms.DataGridView
    Friend WithEvents pnlSortOrder As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents dgvSortOrder As System.Windows.Forms.DataGridView
    Friend WithEvents dgvSortableColumns As System.Windows.Forms.DataGridView
    Friend WithEvents pnlOrderList As System.Windows.Forms.Panel
    Friend WithEvents dgvOrderList As System.Windows.Forms.DataGridView
    Friend WithEvents pnlOrders As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents lblAltAddr As System.Windows.Forms.Label
    Friend WithEvents txtCustAltAdrCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCusNo As System.Windows.Forms.Label
    Friend WithEvents txtCustNo As System.Windows.Forms.TextBox
    Friend WithEvents lblOrderDate As System.Windows.Forms.Label
    Friend WithEvents txtOrderDate As System.Windows.Forms.TextBox
    Friend WithEvents lblOrderNo As System.Windows.Forms.Label
    Friend WithEvents txtOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents lblShipTo As System.Windows.Forms.Label
    Friend WithEvents txtShipToName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBillToName As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlItemList As System.Windows.Forms.Panel
    Friend WithEvents dgvItemList As System.Windows.Forms.DataGridView
    Friend WithEvents pnlItems As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtProdCat As System.Windows.Forms.TextBox
    Friend WithEvents txtItemDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtItemNo As System.Windows.Forms.TextBox
    Friend WithEvents btnNewExcel As System.Windows.Forms.Button
    Friend WithEvents btnSelectAllCopy As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnRemoveRows As System.Windows.Forms.Button

End Class
