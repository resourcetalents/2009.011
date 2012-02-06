'------------------------------------------------------------------------------------------------------------
' Wanneer   Wie Wat
'------------------------------------------------------------------------------------------------------------
' 08-01-08  kv  property volgordeKolommen toegevoegd
'               property breedtesKolommen toegevoegd 
' 15-01-08  kv  Selectie van kolommen toegevoegd
' 14-04-08  kv  Afhandeling selectiecombo aangepast
' 15-12-08  kv  Aanpassen "actieveKolom" selectie op titel en dataproperty mogelijk
'               Default alle velden tonen
'------------------------------------------------------------------------------------------------------------
Imports System
Imports System.Windows.Forms

Public Class frmSelectie

    WithEvents vwInhoud As DataView

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me._kolomBreedtes = ""
        Me._kolomVolgorde = ""

        vwInhoud = New DataView
        vwInhoud.Table = New DataTable("Kolom")
        With vwInhoud.Table
            .Columns.Add("Index", System.Type.GetType("System.Int32", False, True))
            .Columns.Add("Naam", System.Type.GetType("System.String", False, True))
            .Columns.Add("Kop", System.Type.GetType("System.String", False, True))
            .Columns.Add("Kolomid", System.Type.GetType("System.Int32", False, True))
            .Columns.Add("Breedte", System.Type.GetType("System.Int32", False, True))
            .Columns.Add("Getoond", System.Type.GetType("System.Boolean", False, True))
        End With
    End Sub

    Public Sub Bijwerken()

        Dim adoSelect As Odbc.OdbcDataAdapter
        Dim colTabel As DataColumn

        Dim kolVolgorde As String = ""
        Dim kolBreedte As String = ""

        adoSelect = New Odbc.OdbcDataAdapter(_query, odbcMultivers)
        tblData.Table = New DataTable("data")
        adoSelect.Fill(tblData.Table)

        Me.gridData.Columns.Clear()
        For Each colTabel In Me.tblData.Table.Columns
            Dim colData As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn
            If Not StandaardKolom(colTabel.ColumnName, colData) Then
                With colData
                    .DataPropertyName = colTabel.ColumnName
                    .HeaderText = colTabel.ColumnName
                    .Name = "col" & colTabel.ColumnName
                    .Width = 80
                End With
            End If
            Me.gridData.Columns.Add(colData)
            'Neem op in de standaard kolomregel
            kolVolgorde &= ";" & colData.Name
            kolBreedte &= ";" & colData.Width
        Next
        _Resultaat = Me.gridData.Columns(0).Name
        _kolomVolgorde = kolVolgorde.Remove(0, 1)
        _kolomBreedtes = kolBreedte.Remove(0, 1)

        Me.gridData.Update()
    End Sub

    Protected _query As String
    Public Event queryGewijzigd As EventHandler
    Public Property query() As String
        Get
            query = _query
        End Get
        Set(ByVal Value As String)
            If (_query <> Value) Then
                _query = Value
                RaiseEvent queryGewijzigd(Me, New EventArgs)
            End If
        End Set
    End Property

    Protected _Resultaat As String
    Public Event ResultaatGewijzigd As EventHandler
    Public Property Resultaat() As String
        Get
            Resultaat = _Resultaat
        End Get
        Set(ByVal Value As String)
            If (_Resultaat <> Value) Then
                Dim nwKolom As DataGridViewTextBoxColumn = Me.Column(Value)
                If (Not nwKolom Is Nothing) Then
                    _Resultaat = Value
                    RaiseEvent ResultaatGewijzigd(Me, New EventArgs)
                End If
            End If
        End Set
    End Property

    Protected _ActieveKolom As String
    Public Event ActieveKolomGewijzigd As EventHandler
    Public Property ActieveKolom() As String
        Get
            ActieveKolom = _ActieveKolom
        End Get
        Set(ByVal Value As String)
            If (_ActieveKolom & "" <> Value) Then
                Dim nwKolom As DataGridViewTextBoxColumn = Me.Column(Value)
                If (Not nwKolom Is Nothing) Then
                    If (Me.ToolStripComboVeldnaam.Text <> nwKolom.HeaderText) Then
                        Me.ToolStripComboVeldnaam.Text = nwKolom.HeaderText
                    End If
                    _ActieveKolom = Value
                    RaiseEvent ActieveKolomGewijzigd(Me, New EventArgs)
                End If
            End If
        End Set
    End Property

    Protected _Waarde As String
    Public Event WaardeGewijzigd As EventHandler
    Public Property Waarde() As String
        Get
            Waarde = _Waarde
        End Get
        Set(ByVal Value As String)
            If (_Waarde <> Value) Then
                _Waarde = Value
                RaiseEvent WaardeGewijzigd(Me, New EventArgs)
            End If
        End Set
    End Property

    Protected _kolomVolgorde As String
    Public Event KolomVolgordeGewijzigd As EventHandler
    Public Property KolomVolgorde() As String
        Get
            Dim arrPos() As String = Nothing
            Dim nTeller As Integer
            Dim kolom As DataGridViewColumn
            Dim volgorde As String = ""

            Array.Resize(arrPos, Me.gridData.Columns.Count)
            For Each kolom In Me.gridData.Columns
                If kolom.Visible Then arrPos(kolom.DisplayIndex) = kolom.Name
            Next
            For nTeller = 0 To arrPos.Length - 1
                If arrPos(nTeller) & "" <> "" Then volgorde &= ";" & arrPos(nTeller)
            Next
            KolomVolgorde = volgorde.Substring(1)
        End Get
        Set(ByVal value As String)
            If (_kolomVolgorde <> value) Then
                _kolomVolgorde = value
                Me.VolgordeBijwerken()
                RaiseEvent KolomBreedtesGewijzigd(Me, New EventArgs)
            End If
        End Set
    End Property

    Protected _kolomBreedtes As String
    Public Event KolomBreedtesGewijzigd As EventHandler
    Public Property KolomBreedtes() As String
        Get
            Dim arrKolPos() As String = Me.KolomVolgorde.Split(";")
            Dim kolom As DataGridViewColumn
            Dim nTeller As Integer
            Dim Breedtes As String = ""

            For nTeller = 0 To arrKolPos.Length - 1
                kolom = Me.gridData.Columns(arrKolPos(nTeller))
                If Not kolom Is Nothing Then
                    Breedtes &= ";" & kolom.Width
                End If
            Next
            KolomBreedtes = Breedtes.Substring(1)
        End Get
        Set(ByVal value As String)
            If (_kolomBreedtes <> value) Then
                _kolomBreedtes = value
                Me.BreedteBijwerken()
                RaiseEvent KolomBreedtesGewijzigd(Me, New EventArgs)
            End If
        End Set
    End Property

    Public Function Column(ByVal ColumnId As Integer) As DataGridViewTextBoxColumn
        Column = Me.gridData.Columns(ColumnId)
    End Function

    Public Function Column(ByVal ColumnId As String) As DataGridViewTextBoxColumn
        If Me.gridData.Columns(ColumnId) Is Nothing Then
            Dim nteller As Int16 = 0
            Dim bEinde As Boolean = False
            Column = Nothing
            While Not bEinde
                If Me.gridData.Columns(nteller).DataPropertyName = ColumnId Then
                    Column = Me.gridData.Columns(nteller)
                    bEinde = True
                Else
                    If nteller < Me.gridData.Columns.Count Then
                        nteller += 1
                    Else
                        bEinde = True
                    End If
                End If
            End While
        Else
            Column = Me.gridData.Columns(ColumnId)
        End If
    End Function

    Private Sub frmSelectie_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.VolgordeBijwerken()
    End Sub

    Private Sub gridData_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridData.CellDoubleClick

        'Neem de waarde over als resultaat
        If (e.RowIndex > -1) Then
            _Waarde = Me.gridData.Rows(e.RowIndex).Cells(Me._Resultaat).Value
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub gridData_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridData.KeyDown

        If e.Modifiers = 0 And e.KeyCode = Keys.Enter Then

            'Neem de waarde over als resultaat
            _Waarde = Me.gridData.CurrentRow.Cells(Me._Resultaat).Value
            e.Handled = True

            'Sluit het scherm
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub gridData_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridData.KeyUp

        If e.Modifiers = 0 And e.KeyCode = Keys.Escape Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        ElseIf e.KeyCode = Keys.Down And e.Modifiers = 0 Then
            Me.gridData.Focus()
            e.Handled = False
        End If
    End Sub

    Private Sub ToolStripComboVeldnaam_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripComboVeldnaam.SelectedIndexChanged

        If Me.ToolStripComboVeldnaam.SelectedIndex > -1 Then
            VulTabel()
            vwInhoud.RowFilter = String.Format("[Kop]='{0}'", Me.ToolStripComboVeldnaam.Text)
            If vwInhoud.Count > 0 Then
                Me.tblData.Sort = Me.gridData.Columns(vwInhoud.Item(0)!NAAM).datapropertyname & ""
                Me.ActieveKolom = Me.gridData.Columns(vwInhoud.Item(0)!NAAM).datapropertyname & ""
                Me.ToolStripZoekText.Text = ""
            End If
        End If
    End Sub

    Private Sub ToolStripZoekText_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ToolStripZoekText.KeyUp

        If e.KeyCode = Keys.Down And e.Modifiers = 0 Then
            Me.gridData.Focus()
            e.Handled = False
        ElseIf e.KeyCode = Keys.Escape And e.Modifiers = 0 Then
            Me.Close()
        End If
    End Sub

    Private Sub ToolStripZoekText_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripZoekText.TextChanged

        If Me.ToolStripComboVeldnaam.SelectedIndex > -1 Then
            Dim nwKolom As DataGridViewTextBoxColumn = Me.gridData.Columns(_ActieveKolom)

            Select Case tblData.Table.Columns(Me.ToolStripComboVeldnaam.SelectedIndex).DataType.FullName.ToLower

                Case "system.string"
                    Me.tblData.RowFilter = String.Format("[{0}] like '*{1}*'", nwKolom.DataPropertyName, Me.ToolStripZoekText.Text)

                Case "system.datetime"
                    Try
                        Dim datum As Date = DateValue(Me.ToolStripZoekText.Text)
                        Me.tblData.RowFilter = String.Format("[{0}] = '{1}'", Me.gridData.Columns(Me.ToolStripComboVeldnaam.SelectedIndex).DataPropertyName, datum.ToString("dd-MM-yyyy"))
                    Catch ex As Exception
                    End Try
            End Select
        End If
    End Sub

    Private Sub VolgordeBijwerken(Optional ByVal helemaal As Boolean = True)

        Dim arrKolPos() As String = Me._kolomVolgorde.ToUpper.Split(";")
        Dim curVeld As String = Me.ToolStripComboVeldnaam.Text
        Dim nPos As Integer
        Dim Column As DataGridViewTextBoxColumn

        With Me.ToolStripComboVeldnaam
            .Items.Clear()
            For Each Column In Me.gridData.Columns
                'Bepaal de positie van de kolom in de grid
                nPos = Array.IndexOf(arrKolPos, Column.Name.ToUpper)
                If nPos = -1 Then
                    Column.Visible = False
                Else
                    Column.Visible = True
                    Column.DisplayIndex = nPos
                    .Items.Add(Column.HeaderText)
                End If
            Next
        End With
        BreedteBijwerken()

        'Zet de instelling van de zoekcolom terug
        If Trim(curVeld & "") <> "" Then
            Me.ToolStripComboVeldnaam.Text = curVeld
        End If
    End Sub

    Private Sub BreedteBijwerken()

        Dim arrKolBrd() As String = Me._kolomBreedtes.Split(";")
        Dim arrKolPos() As String = Me._kolomVolgorde.ToUpper.Split(";")
        Dim kolom As DataGridViewTextBoxColumn

        Dim nPos As Integer
        Dim nTeller As Integer

        For nTeller = 0 To Me.gridData.Columns.Count - 1
            'maak een koppeling naar de kolom
            kolom = Me.gridData.Columns(nTeller)

            'Bepaal de positie van de kolom in de grid
            nPos = Array.IndexOf(arrKolPos, kolom.Name.ToUpper)
            If (nPos > -1) Then
                If (nPos <= arrKolBrd.Length - 1) AndAlso (IsNumeric(arrKolBrd(nPos))) Then
                    kolom.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    kolom.Width = CType(arrKolBrd(nPos), Integer)
                Else
                    'Stop
                End If
            Else
                kolom.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End If
        Next
        Me.gridData.Refresh()
    End Sub

    Private Function StandaardKolom(ByVal veldnaam As String, ByRef kolom As DataGridViewColumn) As Boolean

        With kolom
            'Ga uit van een standaardkolom
            StandaardKolom = True

            'Neem de veldnaam over naar het dataproperty van de kolom
            .DataPropertyName = veldnaam
            .Name = veldnaam

            Select Case UCase(Trim(veldnaam))

                Case "CDORDER", "CDOPDRACHT"
                    .HeaderText = "Opdracht"
                    .Width = 80

                Case "DTORDER", "DTOPDRACHT"
                    .HeaderText = "Opdr.datum"
                    .Width = 95

                Case "CDFACTUUR"
                    .HeaderText = "Factuur"
                    .Width = 80

                Case "DTFACTUUR"
                    .HeaderText = "Fact.datum"
                    .Width = 95

                Case "REFERENTIE"
                    .HeaderText = "Referentie"
                    .Width = 120

                Case "CDBETCOND"
                    .HeaderText = "Bet.cond"
                    .Width = 30

                Case "CDLEVCOND"
                    .HeaderText = "Lev.cond"
                    .Width = 50

                Case "BLOKKADE"
                    .HeaderText = "Blok"
                    .Width = 30

                Case "FIAT"
                    .HeaderText = "Fiat"
                    .Width = 30

                Case "CDDEBITEUR"
                    .HeaderText = "Debiteur"
                    .Width = 95

                Case "NMDEBITEUR"
                    .HeaderText = "Naam klant"
                    .Width = 120

                Case "ZOEKNAAM"
                    .HeaderText = "Zoeknaam"
                    .Width = 100

                Case "NAAMSTRAAT"
                    .HeaderText = "Naam/straat"
                    .Width = 120

                Case "STRAAT"
                    .HeaderText = "Straat"
                    .Width = 120

                Case "POSTCODE"
                    .HeaderText = "Postcode"
                    .Width = 80

                Case "PLAATS"
                    .HeaderText = "Plaats"
                    .Width = 120

                Case "CDLAND"
                    .HeaderText = "Landcode"
                    .Width = 40

                Case "NMLAND"
                    .HeaderText = "Naam land"
                    .Width = 100

                Case "KVK", "KVK1"
                    .HeaderText = "KVK-Nummer"
                    .Width = 70

                Case "BTW"
                    .HeaderText = "BTW-Nummer"
                    .Width = 70

                Case "HOMEPAGE"
                    .HeaderText = "Homepage"
                    .Width = 120

                Case "CDARTIKEL"
                    .HeaderText = "Artikel"
                    .Width = 100

                Case "NMARTIKEL"
                    .HeaderText = "Omschrijving"
                    .Width = 200

                Case "EENHEID"
                    .HeaderText = "Eenheid"
                    .Width = 50

                Case "CDARTGRP"
                    .HeaderText = "Art.Grp"
                    .Width = 40

                Case "CDKRTGRP"
                    .HeaderText = "Krt.Grp"
                    .Width = 40

                Case "CDSTATUS"
                    .HeaderText = "Status"
                    .Width = 30

                Case "NUMVOORRAAD"
                    .HeaderText = "Voorraad"
                    .Width = 60
                    .CellTemplate.Style.Alignment = DataGridViewContentAlignment.TopRight
                    .CellTemplate.Style.Format = "#,##0.00"

                Case "EURPRIJS"
                    .HeaderText = "Prijs"
                    .Width = 70
                    .CellTemplate.Style.Alignment = DataGridViewContentAlignment.TopRight
                    .CellTemplate.Style.Format = "#,##0.00"

                Case "SOORT"
                    .HeaderText = "Soort"
                    .Width = 50

                Case "CDMAGAZIJN"
                    .HeaderText = "Mag"
                    .Width = 50

                Case "NMMAGAZIJN"
                    .HeaderText = "Magazijn"
                    .Width = 120

                Case "NMBETCOND"
                    .HeaderText = "Betalingsconditie"
                    .Width = 150

                Case "DGNKORTING"
                    .HeaderText = "Kortingdagen"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                    .Width = 70

                Case "DGNNETTO"
                    .HeaderText = "Vervaldagen"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                    .Width = 70

                Case "BETKORT"
                    .HeaderText = "Krt%"
                    .DefaultCellStyle.Format = "##0.00%"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                    .Width = 40

                Case "CDINCASSO"
                    .HeaderText = "Incasso"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter
                    .Width = 30

                Case "BEHANDELDDOOR"
                    .HeaderText = "Behandeld door"
                    .Width = 120

                Case "VERTEGENWOORDIGER"
                    .HeaderText = "Vertegenwoordiger"
                    .Width = 120

                Case "NMLEVCOND"
                    .HeaderText = "Leveringsconditie"
                    .Width = 150

                Case "NKLEVCOND"
                    .HeaderText = "Zoeknaam"
                    .Width = 70

                Case "CDPERSOON"
                    .HeaderText = "Persoon"
                    .Width = 60

                Case "NMPERSOON", "CONTACTPERSOON"
                    .HeaderText = "Naam"
                    .Width = 150

                Case "VOORNAAM"
                    .HeaderText = "Voornaam"
                    .Width = 70

                Case "VOORLETTERS"
                    .HeaderText = "Voorletters"
                    .Width = 60

                Case "EMAIL"
                    .HeaderText = "E-mail"
                    .Width = 120

                Case "TELEFOON"
                    .HeaderText = "Telefoon"
                    .Width = 80

                Case "MOBIEL"
                    .HeaderText = "Mobiel"
                    .Width = 80

                Case "FUNCTIE"
                    .HeaderText = "Functie"
                    .Width = 120

                Case "GESLACHT"
                    .HeaderText = "Geslacht"
                    .Width = 70

                Case "GEBOREN"
                    .HeaderText = "Geboren"
                    .Width = 60

                Case "DTINVOER"
                    .HeaderText = "Ingevoerd"
                    .Width = 50

                Case "DTWIJZIGING"
                    .HeaderText = "Gewijzigd"
                    .Width = 50

                Case "EANARTIKEL"
                    .HeaderText = "EAN-code"
                    .Width = 70

                Case "AFDRUKTELLER"
                    .HeaderText = "Afdrukteller"
                    .Width = 60

                Case Else
                    StandaardKolom = False
            End Select
        End With
    End Function

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripKolommen.Click

        Dim frmKolommen As frmSelectieVelden = New frmSelectieVelden

        Dim nTeller As Integer

        'Maak een lijst met alle kolommen
        Dim arrPos() As String = Nothing

        'Maak de lijst met kolommen voldoende groot
        Array.Resize(arrPos, Me.gridData.Columns.Count)

        'Vul de tabel met de kolom
        VulTabel()

        'Begin met de zichtbare kolommen op volgorde
        Me.vwInhoud.RowFilter = "[getoond]=true"
        Me.vwInhoud.Sort = "kolomid"
        For nTeller = 0 To Me.vwInhoud.Count - 1
            frmKolommen.lstVelden.Items.Add(Me.vwInhoud.Item(nTeller)!KOP, True)
        Next nTeller

        'Gevolgd door alle niet-zichbare kolommen
        Me.vwInhoud.RowFilter = "[getoond]=false"
        Me.vwInhoud.Sort = "index"
        For nTeller = 0 To Me.vwInhoud.Count - 1
            frmKolommen.lstVelden.Items.Add(Me.vwInhoud.Item(nTeller)!KOP, False)
        Next nTeller

        'Laat het scherm zien
        frmKolommen.ShowDialog(Me)

        'Verwerk alle kolommen
        For nTeller = 0 To frmKolommen.lstVelden.Items.Count - 1

            'Zoek de kolom op
            Me.vwInhoud.RowFilter = String.Format("[kop]='{0}'", frmKolommen.lstVelden.Items(nTeller))
            If Me.vwInhoud.Count > 0 Then

                'Stel de kolom in
                With Me.gridData.Columns(Me.vwInhoud.Item(0)!index)
                    .Visible = frmKolommen.lstVelden.GetItemChecked(nTeller)
                    .DisplayIndex = nTeller
                End With
            End If
        Next
    End Sub

    Private Sub VulTabel()

        Dim rowKolom As DataRow
        Dim kolom As DataGridViewColumn

        Me.vwInhoud.Table.Rows.Clear()
        For Each kolom In Me.gridData.Columns
            rowKolom = vwInhoud.Table.NewRow
            With rowKolom
                !index = kolom.Index
                !naam = kolom.Name
                If Trim(kolom.HeaderText & "") = "" Then
                    !kop = String.Format("Kolom {0}", kolom.Index)
                Else
                    !kop = kolom.HeaderText
                End If
                !kolomid = kolom.DisplayIndex
                !breedte = kolom.Width
                !getoond = kolom.Visible
            End With
            vwInhoud.Table.Rows.Add(rowKolom)
        Next
    End Sub

    Private Sub gridData_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles gridData.ColumnHeaderMouseClick

        'Wijzig de actieve kolom
        Me.ActieveKolom = gridData.Columns(e.ColumnIndex).Name
        Me.ToolStripZoekText.Text = ""
    End Sub

    Private Sub frmSelectie_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        Me.ToolStripZoekText.Focus()
    End Sub
End Class
