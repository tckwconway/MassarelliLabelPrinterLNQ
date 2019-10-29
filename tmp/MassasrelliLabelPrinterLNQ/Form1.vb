Public Class MassarelliLabelPrinter

    Private Sub ButtonGetWorkOrder_Click(sender As System.Object, e As System.EventArgs) Handles ButtonGetWorkOrder.Click

    End Sub

#Region "   LINQ   "
    Dim dc As New LNQForecastVersionDataContext(cn)
        Me.BindingSourceLNQForecastVersion.DataSource = _
        From vebfcFcstVersHd_E2Bs In dc.vebfcFcstVersHd_E2Bs _
        Order By vebfcFcstVersHd_E2Bs.VersionDesc _
        Select vebfcFcstVersHd_E2Bs.VersionDesc, vebfcFcstVersHd_E2Bs.VersionID, _
        vebfcFcstVersHd_E2Bs.VersionKey _
        Order By VersionDesc, VersionID
        Me.ComboBoxForecastVersion.DataSource = Me.BindingSourceLNQForecastVersion
        Me.ComboBoxForecastVersion.DisplayMember = "VersionID"
        Me.ComboBoxForecastVersion.ValueMember = "VersionKey"


#End Region
End Class
