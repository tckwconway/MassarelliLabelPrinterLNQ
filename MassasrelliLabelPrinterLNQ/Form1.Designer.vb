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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MassarelliLabelPrinter))
        Me.ButtonGetWorkOrder = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxWorkOrder = New System.Windows.Forms.TextBox()
        Me.dgvOrderList = New System.Windows.Forms.DataGridView()
        Me.ToolStripMAS500 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonBLANK = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonClear = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonSerialNumber = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonMACAddress = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonSettings = New System.Windows.Forms.ToolStripButton()
        Me.Mas500StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.tslblDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblCompany = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslbMaxProductionID = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblLabelStatus = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.dgvOrderList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripMAS500.SuspendLayout()
        Me.Mas500StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonGetWorkOrder
        '
        Me.ButtonGetWorkOrder.Location = New System.Drawing.Point(241, 35)
        Me.ButtonGetWorkOrder.Name = "ButtonGetWorkOrder"
        Me.ButtonGetWorkOrder.Size = New System.Drawing.Size(97, 26)
        Me.ButtonGetWorkOrder.TabIndex = 121
        Me.ButtonGetWorkOrder.Text = "Get Work Order"
        Me.ButtonGetWorkOrder.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 18)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "Order #:"
        '
        'TextBoxWorkOrder
        '
        Me.TextBoxWorkOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxWorkOrder.Location = New System.Drawing.Point(84, 37)
        Me.TextBoxWorkOrder.Name = "TextBoxWorkOrder"
        Me.TextBoxWorkOrder.Size = New System.Drawing.Size(151, 24)
        Me.TextBoxWorkOrder.TabIndex = 119
        '
        'dgvOrderList
        '
        Me.dgvOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrderList.Location = New System.Drawing.Point(15, 67)
        Me.dgvOrderList.Name = "dgvOrderList"
        Me.dgvOrderList.Size = New System.Drawing.Size(761, 403)
        Me.dgvOrderList.TabIndex = 122
        '
        'ToolStripMAS500
        '
        Me.ToolStripMAS500.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripMAS500.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonExit, Me.ToolStripSeparator1, Me.ToolStripButtonPrint, Me.ToolStripButtonSave, Me.ToolStripButtonBLANK, Me.ToolStripButtonClear, Me.ToolStripSeparator2, Me.ToolStripButtonSerialNumber, Me.ToolStripButtonMACAddress, Me.ToolStripSeparator3, Me.ToolStripButtonSettings})
        Me.ToolStripMAS500.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMAS500.Name = "ToolStripMAS500"
        Me.ToolStripMAS500.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStripMAS500.Size = New System.Drawing.Size(789, 25)
        Me.ToolStripMAS500.TabIndex = 123
        Me.ToolStripMAS500.Text = "ToolStrip1"
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'Mas500StatusStrip
        '
        Me.Mas500StatusStrip.AutoSize = False
        Me.Mas500StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblDate, Me.tslblCompany, Me.tslblUser, Me.tslbMaxProductionID, Me.tslblLabelStatus})
        Me.Mas500StatusStrip.Location = New System.Drawing.Point(0, 479)
        Me.Mas500StatusStrip.Name = "Mas500StatusStrip"
        Me.Mas500StatusStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Mas500StatusStrip.Size = New System.Drawing.Size(789, 22)
        Me.Mas500StatusStrip.SizingGrip = False
        Me.Mas500StatusStrip.TabIndex = 124
        Me.Mas500StatusStrip.Text = "MAS500 Statusbar"
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
        'MassarelliLabelPrinter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 501)
        Me.Controls.Add(Me.Mas500StatusStrip)
        Me.Controls.Add(Me.ToolStripMAS500)
        Me.Controls.Add(Me.dgvOrderList)
        Me.Controls.Add(Me.ButtonGetWorkOrder)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxWorkOrder)
        Me.Name = "MassarelliLabelPrinter"
        Me.Text = "Form1"
        CType(Me.dgvOrderList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripMAS500.ResumeLayout(False)
        Me.ToolStripMAS500.PerformLayout()
        Me.Mas500StatusStrip.ResumeLayout(False)
        Me.Mas500StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonGetWorkOrder As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxWorkOrder As System.Windows.Forms.TextBox
    Friend WithEvents dgvOrderList As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripMAS500 As System.Windows.Forms.ToolStrip
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
    Friend WithEvents Mas500StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents tslblDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslblCompany As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslblUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslbMaxProductionID As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslblLabelStatus As System.Windows.Forms.ToolStripStatusLabel

End Class
