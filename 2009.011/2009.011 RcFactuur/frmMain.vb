Public Class frmMain

    Dim ubcProduct As MBO.Product

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim frmLogin As frmLogin = New frmLogin

        If frmLogin.ShowDialog = Windows.Forms.DialogResult.OK Then
            mdlAlgemeen.ConnectMultivers(My.Settings.mvlAdministratie, My.Settings.mvlGebruiker, frmLogin.txtWachtwoord.Text)

            'Maak een nieuw artikel aan voor de ubc
            ubcProduct = New MBO.Product
            ubcProduct.Connect(ubcMultivers)

            LeesRapport()

            AddHandler tblRapport.Table.ColumnChanging, AddressOf TabelkolomGewijzigd
        Else
            Me.Close()
        End If
    End Sub

    Private Sub LeesRapport()

        Dim adoRapport As Odbc.OdbcDataAdapter

        Dim cdFacturabel As String
        Dim cdVerwijderd As String

        Dim frmProgress As frmProgress = New frmProgress()

        Me.gridRapport.EndEdit()
        If Me.tblRapport.Table Is Nothing Then
            Me.tblRapport.Table = New DataTable("Rapport")
        Else
            Me.tblRapport.Table.Rows.Clear()
        End If

        If Me.ToolStripFacturabel.Checked Then cdFacturabel = "'J'" Else cdFacturabel = "'J','N'"
        If Me.ToolStripVerwijderd.Checked Then cdVerwijderd = "'J','N'" Else cdVerwijderd = "'N'"

        'Vul het rapport met de nieuwe waarden
        frmProgress.Value = 0
        frmProgress.Info = "Ophalen rapporten ... "
        frmProgress.show()
        adoRapport = New Odbc.OdbcDataAdapter(String.Format( _
            "SELECT R.VVISFACTURABEL AS MAGFACTUREREN " & _
            "   , R.GUID_ITEM       AS IDRAPPORT " & _
            "   , R.CDDEBITEUR      AS CDADRES " & _
            "   , D.NAAM            AS NMADRES " & _
            "   , @NULLVALUE(D.CDDEBITEUR_INKORG,R.CDDEBITEUR) AS CDKLANT " & _
            "   , K.NAAM            AS NMKLANT " & _
            "   , R.VVCDSURVEILLANT AS CDSURVEILLANT " & _
            "   , R.VVCDOPERATOR    AS CDOPERATOR " & _
            "   , R.VVCDADRES       AS CDFACTUUR " & _
            "   , R.VVCDARTIKEL     AS CDARTIKEL " & _
            "   , R.VVCDSURVEILLANT AS CDSURVEILLANT " & _
            "   , R.VVDTMELDING     AS DTMELDING " & _
            "   , R.VVTDMELDING     AS TDMELDING " & _
            "   , R.VVMELDING       AS MELDING " & _
            "   , @NULLVALUE(R.VVFACTUURTEKST,R.VVMELDING) AS FACTUURTEKST " & _
            "   , R.VVEURBEDRAG     AS EURBEDRAG " & _
            "   , R.VVISVERWIJDERD  AS ISVERWIJDERD " & _
            "   , R.VVISFACTURABEL  AS ISFACTURABEL " & _
            "   , R.VVISEINDEMELDING AS ISEINDEMELDING " & _
            "   , @NULLVALUE(R.VVCDARTIKEL,{2}) AS CDARTIKEL " & _
            "   , 'N'               AS ISVERWERKT " & _
            "FROM VT_RAPPORTAGE R " & _
            "INNER JOIN DEBITEUR D " & _
            "  ON  D.CDDEBITEUR = R.CDDEBITEUR " & _
            "INNER JOIN DEBITEUR K " & _
            "  ON  K.CDDEBITEUR = @NULLVALUE(D.CDDEBITEUR_INKORG,D.CDDEBITEUR) " & _
            "WHERE R.VVISFACTURABEL IN ({0}) " & _
            "  AND R.VVISVERWIJDERD IN ({1}) " & _
            "  AND R.VVCDFACTUUR IS NULL " _
            , cdFacturabel _
            , cdVerwijderd _
            , Sql.String(My.Settings.cdArtikel)) _
            , odbcMultivers)
        adoRapport.Fill(Me.tblRapport.Table)
        tblRapport.Sort = "CDADRES, DTMELDING, TDMELDING"

        'Controleer op nul-prijzen en vervang die door werkelijke prijzen
        tblRapport.RowFilter = String.Format("[EURBEDRAG] = 0 and [CDARTIKEL] <> '{0}'", My.Settings.cdArtikel)
        If (tblRapport.Count > 0) Then
            frmProgress.Max = tblRapport.Count
            frmProgress.Info = "Ophalen standaardprijzen ..."
            For Each row As DataRow In Me.tblRapport.Table.Rows
                frmProgress.Value += 1
                If Not (ubcProduct.Exists(row!cdartikel & "")) Then
                    row!CDARTIKEL = My.Settings.cdArtikel
                End If
                ubcProduct.Load(row!CDARTIKEL & "", row!CDKLANT & "")
                row!EURBEDRAG = ubcProduct.PriceVatExcl
            Next
            frmProgress.Hide()
        End If
        tblRapport.RowFilter = ""
        frmProgress.Hide()

        'Toon het rapport
        Me.gridRapport.Refresh()
    End Sub

    Private Sub ToolStripVernieuw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripVernieuw.Click

        LeesRapport()
    End Sub

    Private Sub ToolStripFacturabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripFacturabel.Click

        Me.gridRapport.EndEdit()
        If Me.ToolStripFacturabel.Checked Then
            Me.ToolStripFacturabel.Image = Global.RT2009.P011.RcFactuur.My.Resources.option___selected
        Else
            Me.ToolStripFacturabel.Image = Global.RT2009.P011.RcFactuur.My.Resources.option___unselected
        End If
        'Application.DoEvents()
        LeesRapport()
    End Sub

    Private Sub ToolStripVerwijderd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripVerwijderd.Click

        Me.gridRapport.EndEdit()
        If Me.ToolStripVerwijderd.Checked Then
            Me.ToolStripVerwijderd.Image = Global.RT2009.P011.RcFactuur.My.Resources.option___selected
        Else
            Me.ToolStripVerwijderd.Image = Global.RT2009.P011.RcFactuur.My.Resources.option___unselected
        End If
        'DoEvents()
        LeesRapport()
    End Sub

    Private Sub TabelkolomGewijzigd(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs)

        Dim cmdUpdate As Odbc.OdbcCommand

        Select Case e.Column.ColumnName

            Case "CDFACTUUR"
                cmdUpdate = New Odbc.OdbcCommand(String.Format( _
                    "UPDATE VT_RAPPORTAGE " & _
                    "SET    VVCDADRES = {1} " & _
                    "WHERE  GUID_ITEM = '{0}' " _
                    , e.Row!IDRAPPORT _
                    , Sql.String(e.ProposedValue)) _
                    , odbcMultivers)
                cmdUpdate.ExecuteNonQuery()

            Case "MELDING"
                cmdUpdate = New Odbc.OdbcCommand(String.Format( _
                    "UPDATE VT_RAPPORTAGE " & _
                    "SET    VVMELDING  = {1} " & _
                    "WHERE  GUID_ITEM = '{0}' " _
                    , e.Row!IDRAPPORT _
                    , Sql.String(e.ProposedValue)) _
                    , odbcMultivers)
                cmdUpdate.ExecuteNonQuery()

            Case "FACTUURTEKST"
                cmdUpdate = New Odbc.OdbcCommand(String.Format( _
                    "UPDATE VT_RAPPORTAGE " & _
                    "SET VVFACTUURTEKST = {1} " & _
                    "WHERE  GUID_ITEM = '{0}' " _
                    , e.Row!IDRAPPORT _
                    , Sql.String(e.ProposedValue)) _
                    , odbcMultivers)
                cmdUpdate.ExecuteNonQuery()

            Case "ISFACTURABEL"
                cmdUpdate = New Odbc.OdbcCommand(String.Format( _
                    "UPDATE VT_RAPPORTAGE " & _
                    "SET    VVISFACTURABEL = {1} " & _
                    "WHERE  GUID_ITEM = '{0}' " _
                    , e.Row!IDRAPPORT _
                    , Sql.String(e.ProposedValue)) _
                    , odbcMultivers)
                cmdUpdate.ExecuteNonQuery()

            Case "ISVERWIJDERD"
                cmdUpdate = New Odbc.OdbcCommand(String.Format( _
                    "UPDATE VT_RAPPORTAGE " & _
                    "SET    VVISVERWIJDERD = {1} " & _
                    "WHERE  GUID_ITEM = '{0}' " _
                    , e.Row!IDRAPPORT _
                    , Sql.String(e.ProposedValue)) _
                    , odbcMultivers)
                cmdUpdate.ExecuteNonQuery()

            Case "ISEINDEMELDING"
                cmdUpdate = New Odbc.OdbcCommand(String.Format( _
                    "UPDATE VT_RAPPORTAGE " & _
                    "SET    VVISEINDEMELDING = {1} " & _
                    "WHERE  GUID_ITEM = '{0}' " _
                    , e.Row!IDRAPPORT _
                    , Sql.String(e.ProposedValue)) _
                    , odbcMultivers)
                cmdUpdate.ExecuteNonQuery()

            Case "CDARTIKEL"
                If (ubcProduct.Exists(e.ProposedValue)) Then
                    ubcProduct.Load(e.ProposedValue, e.Row.Item("CDKLANT"))
                    cmdUpdate = New Odbc.OdbcCommand(String.Format( _
                        "UPDATE VT_RAPPORTAGE " & _
                        "SET VVCDARTIKEL = {1} " & _
                        "WHERE  GUID_ITEM = '{0}' " _
                        , e.Row!IDRAPPORT _
                        , Sql.String(e.ProposedValue)) _
                        , odbcMultivers)
                    cmdUpdate.ExecuteNonQuery()
                    e.Row.Item("EURBEDRAG") = ubcProduct.PriceVatExcl.ToString()
                End If

            Case "EURBEDRAG"
                cmdUpdate = New Odbc.OdbcCommand(String.Format( _
                    "UPDATE VT_RAPPORTAGE " & _
                    "SET VVEURBEDRAG = {1} " & _
                    "WHERE GUID_ITEM = '{0}' " _
                    , e.Row!IDRAPPORT _
                    , Sql.Number(e.ProposedValue)) _
                    , odbcMultivers)
                cmdUpdate.ExecuteNonQuery()
        End Select
    End Sub

    Private Sub btnAlles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlles.Click
        Dim nteller As Integer
        Me.gridRapport.EndEdit()
        For nteller = 0 To Me.tblRapport.Count - 1
            Me.tblRapport.Item(nteller)!MAGFACTUREREN = "J"
        Next
        Me.gridRapport.Refresh()
    End Sub

    Private Sub btnNiets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNiets.Click
        Dim nteller As Integer
        Me.gridRapport.EndEdit()
        For nteller = 0 To Me.tblRapport.Count - 1
            Me.tblRapport.Item(nteller)!MAGFACTUREREN = "N"
        Next
        Me.gridRapport.Refresh()
    End Sub

    Private Sub ToolStripVerwerk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripVerwerk.Click

        Dim ubcOrder As MBO.Order
        Dim cmdUpdate As Odbc.OdbcCommand

        Dim nTeller As Integer
        Dim idOrder As String

        Dim cdAdres As String
        Dim isGereed As Boolean
        Dim lstOpdracht As List(Of DataRow)

        Me.gridRapport.EndEdit()

        nTeller = 0
        lstOpdracht = New List(Of DataRow)
        tblRapport.Sort = "CDADRES, DTMELDING, TDMELDING"
        While (nTeller < tblRapport.Count)
            Try
                ' Haal de eerstvolgende groep regels op
                isGereed = False
                cdAdres = tblRapport(nTeller)!CDADRES
                While (Not isGereed) _
                AndAlso (nTeller < tblRapport.Count) _
                AndAlso (cdAdres = tblRapport(nTeller)!CDADRES)
                    If (tblRapport(nTeller)!MAGFACTUREREN = "J") Then
                        lstOpdracht.Add(tblRapport(nTeller).Row)
                    End If
                    If (tblRapport(nTeller)!ISEINDEMELDING = "J") Then
                        isGereed = True
                    End If
                    nTeller = nTeller + 1
                End While

                If (isGereed) AndAlso (lstOpdracht.Count > 0) Then
                    'Maak de order aan
                    ubcOrder = New MBO.Order
                    ubcOrder.Connect(ubcMultivers)
                    ubcOrder.OrderType = MBO.OrderTypes.otOnlyInvoiceOrder
                    ubcOrder.OrderDate = lstOpdracht(0)!DTMELDING
                    ubcOrder.Customer.Load(lstOpdracht(0)!CDADRES)
                    If (lstOpdracht(0)!CDFACTUUR = "Risicoadres") Then
                        ubcOrder.InvoiceAddress = ubcOrder.DeliveryAddress
                    End If
                    For Each rowRapport As DataRow In lstOpdracht
                        'Maak de orderregel aan
                        With ubcOrder.OrderLines.Add
                            .AutoCalcAmount = False
                            .AutoCalcDiscount = False
                            .AutoCalcPrice = False
                            .Product.Load(rowRapport!CDARTIKEL)
                            .Description = String.Format("{0:dd-MM-yyyy} {1} {2}", rowRapport!DTMELDING, rowRapport!TDMELDING, rowRapport!FACTUURTEKST)
                            Select Case .LineType
                                Case MBO.OrderLineTypes.oltStockProduct, MBO.OrderLineTypes.oltConstellation, MBO.OrderLineTypes.oltNonStockProduct
                                    .Price = rowRapport!EURBEDRAG
                                    .QuantityOrdered = 1
                                Case Else
                                    .OrderLineAmount = rowRapport!EURBEDRAG
                            End Select
                        End With
                        rowRapport!ISVERWERKT = "J"
                    Next rowRapport

                    'Sla de opdracht op
                    If ubcOrder.IsValid Then
                        idOrder = ubcOrder.SaveAndReturnKey
                        For Each rowRapport As DataRow In lstOpdracht
                            cmdUpdate = New Odbc.OdbcCommand(String.Format( _
                                "UPDATE VT_RAPPORTAGE " & _
                                "SET    VVCDFACTUUR = {1} " & _
                                "WHERE  GUID_ITEM ='{0}' " _
                                , rowRapport!IDRAPPORT _
                                , idOrder) _
                                , odbcMultivers)
                            cmdUpdate.ExecuteNonQuery()
                        Next rowRapport
                    End If
                End If
                'Gegevens zijn verwerkt of nog niet te verwerken
                lstOpdracht.Clear()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End While

        'Zet het filter weer uit
        LeesRapport()
    End Sub

    Private Sub gridRapport_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridRapport.KeyUp
        If (e.Modifiers = 0) Then
            Select Case e.KeyCode
                Case Windows.Forms.Keys.Space
                    If (gridRapport.SelectedRows.Count = 1) Then
                        Select Case gridRapport.SelectedRows(0).Cells(colMagFactureren.Name).Value
                            Case "J"
                                gridRapport.SelectedRows(0).Cells(colMagFactureren.Name).Value = "N"
                            Case "N"
                                gridRapport.SelectedRows(0).Cells(colMagFactureren.Name).Value = "J"
                        End Select
                        e.Handled = True
                        'forceer update van de regel door het verleggen van de selectie
                        gridRapport.CurrentCell = gridRapport.SelectedRows(0).Cells(colDtMelding.Name)
                        gridRapport.UpdateCellValue(gridRapport.CurrentCell.RowIndex, gridRapport.CurrentCell.ColumnIndex)
                    End If
            End Select
        End If
    End Sub
End Class
