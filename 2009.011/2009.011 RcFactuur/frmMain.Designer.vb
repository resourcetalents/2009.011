<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripVernieuw = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabelTonen = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripFacturabel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripVerwijderd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripVerwerk = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.gridRapport = New System.Windows.Forms.DataGridView()
        Me.colMagFactureren = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colDtMelding = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTdMelding = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCdSurveillant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCdOperator = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCdDebiteur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNmAdres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCdKlant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNmKlant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAdres = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colIsVerwijderd = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colIsFacturabel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colCdArtikel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFactuurTekst = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBedrag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIsEindeMelding = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tblRapport = New System.Data.DataView()
        Me.btnAlles = New System.Windows.Forms.Button()
        Me.btnNiets = New System.Windows.Forms.Button()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gridRapport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblRapport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripVernieuw, Me.ToolStripSeparator1, Me.ToolStripLabelTonen, Me.ToolStripFacturabel, Me.ToolStripVerwijderd, Me.ToolStripSeparator2, Me.ToolStripVerwerk})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1156, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripVernieuw
        '
        Me.ToolStripVernieuw.Image = CType(resources.GetObject("ToolStripVernieuw.Image"), System.Drawing.Image)
        Me.ToolStripVernieuw.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripVernieuw.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripVernieuw.Name = "ToolStripVernieuw"
        Me.ToolStripVernieuw.Size = New System.Drawing.Size(72, 22)
        Me.ToolStripVernieuw.Text = "Ophalen"
        Me.ToolStripVernieuw.ToolTipText = "Haal de meldingen op"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabelTonen
        '
        Me.ToolStripLabelTonen.Name = "ToolStripLabelTonen"
        Me.ToolStripLabelTonen.Size = New System.Drawing.Size(54, 22)
        Me.ToolStripLabelTonen.Text = "Selecteer"
        '
        'ToolStripFacturabel
        '
        Me.ToolStripFacturabel.Checked = True
        Me.ToolStripFacturabel.CheckOnClick = True
        Me.ToolStripFacturabel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripFacturabel.Image = Global.RT2009.P011.RcFactuur.My.Resources.Resources.option___selected
        Me.ToolStripFacturabel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripFacturabel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripFacturabel.Name = "ToolStripFacturabel"
        Me.ToolStripFacturabel.Size = New System.Drawing.Size(82, 22)
        Me.ToolStripFacturabel.Text = "Facturabel"
        '
        'ToolStripVerwijderd
        '
        Me.ToolStripVerwijderd.CheckOnClick = True
        Me.ToolStripVerwijderd.Image = Global.RT2009.P011.RcFactuur.My.Resources.Resources.option___unselected
        Me.ToolStripVerwijderd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripVerwijderd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripVerwijderd.Name = "ToolStripVerwijderd"
        Me.ToolStripVerwijderd.Size = New System.Drawing.Size(83, 22)
        Me.ToolStripVerwijderd.Text = "Verwijderd"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripVerwerk
        '
        Me.ToolStripVerwerk.Image = CType(resources.GetObject("ToolStripVerwerk.Image"), System.Drawing.Image)
        Me.ToolStripVerwerk.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripVerwerk.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripVerwerk.Name = "ToolStripVerwerk"
        Me.ToolStripVerwerk.Size = New System.Drawing.Size(107, 22)
        Me.ToolStripVerwerk.Text = "Maak opdracht"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 413)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1156, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'gridRapport
        '
        Me.gridRapport.AllowUserToAddRows = False
        Me.gridRapport.AllowUserToDeleteRows = False
        Me.gridRapport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridRapport.AutoGenerateColumns = False
        Me.gridRapport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.gridRapport.BackgroundColor = System.Drawing.SystemColors.Window
        Me.gridRapport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridRapport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridRapport.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colMagFactureren, Me.colDtMelding, Me.colTdMelding, Me.colCdSurveillant, Me.colCdOperator, Me.colCdDebiteur, Me.colNmAdres, Me.colCdKlant, Me.colNmKlant, Me.colAdres, Me.colIsVerwijderd, Me.colIsFacturabel, Me.colCdArtikel, Me.colFactuurTekst, Me.colBedrag, Me.colIsEindeMelding})
        Me.gridRapport.DataSource = Me.tblRapport
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridRapport.DefaultCellStyle = DataGridViewCellStyle18
        Me.gridRapport.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridRapport.Location = New System.Drawing.Point(3, 28)
        Me.gridRapport.Name = "gridRapport"
        Me.gridRapport.RowHeadersVisible = False
        Me.gridRapport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridRapport.Size = New System.Drawing.Size(1150, 349)
        Me.gridRapport.TabIndex = 2
        '
        'colMagFactureren
        '
        Me.colMagFactureren.DataPropertyName = "MAGFACTUREREN"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle10.NullValue = False
        Me.colMagFactureren.DefaultCellStyle = DataGridViewCellStyle10
        Me.colMagFactureren.FalseValue = "N"
        Me.colMagFactureren.HeaderText = "Sel"
        Me.colMagFactureren.Name = "colMagFactureren"
        Me.colMagFactureren.TrueValue = "J"
        Me.colMagFactureren.Width = 35
        '
        'colDtMelding
        '
        Me.colDtMelding.DataPropertyName = "DTMELDING"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle11.Format = "d"
        DataGridViewCellStyle11.NullValue = "dd-MM-yyyy"
        Me.colDtMelding.DefaultCellStyle = DataGridViewCellStyle11
        Me.colDtMelding.HeaderText = "Datum"
        Me.colDtMelding.Name = "colDtMelding"
        Me.colDtMelding.ReadOnly = True
        Me.colDtMelding.Width = 60
        '
        'colTdMelding
        '
        Me.colTdMelding.DataPropertyName = "TDMELDING"
        Me.colTdMelding.HeaderText = "Tijd"
        Me.colTdMelding.Name = "colTdMelding"
        Me.colTdMelding.ReadOnly = True
        Me.colTdMelding.Width = 40
        '
        'colCdSurveillant
        '
        Me.colCdSurveillant.DataPropertyName = "CDSURVEILLANT"
        Me.colCdSurveillant.HeaderText = "Surveillant"
        Me.colCdSurveillant.Name = "colCdSurveillant"
        Me.colCdSurveillant.ReadOnly = True
        Me.colCdSurveillant.Width = 60
        '
        'colCdOperator
        '
        Me.colCdOperator.DataPropertyName = "CDOPERATOR"
        Me.colCdOperator.HeaderText = "Operator"
        Me.colCdOperator.Name = "colCdOperator"
        Me.colCdOperator.ReadOnly = True
        Me.colCdOperator.Width = 55
        '
        'colCdDebiteur
        '
        Me.colCdDebiteur.DataPropertyName = "CDADRES"
        Me.colCdDebiteur.HeaderText = "Locatie"
        Me.colCdDebiteur.Name = "colCdDebiteur"
        Me.colCdDebiteur.ReadOnly = True
        Me.colCdDebiteur.Width = 45
        '
        'colNmAdres
        '
        Me.colNmAdres.DataPropertyName = "NMADRES"
        Me.colNmAdres.HeaderText = "Naam locatie"
        Me.colNmAdres.Name = "colNmAdres"
        Me.colNmAdres.ReadOnly = True
        Me.colNmAdres.Width = 150
        '
        'colCdKlant
        '
        Me.colCdKlant.DataPropertyName = "CDKLANT"
        Me.colCdKlant.HeaderText = "Klant"
        Me.colCdKlant.Name = "colCdKlant"
        Me.colCdKlant.ReadOnly = True
        Me.colCdKlant.Width = 45
        '
        'colNmKlant
        '
        Me.colNmKlant.DataPropertyName = "NMKLANT"
        Me.colNmKlant.HeaderText = "Naam klant"
        Me.colNmKlant.Name = "colNmKlant"
        Me.colNmKlant.ReadOnly = True
        Me.colNmKlant.Width = 150
        '
        'colAdres
        '
        Me.colAdres.DataPropertyName = "CDFACTUUR"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.colAdres.DefaultCellStyle = DataGridViewCellStyle12
        Me.colAdres.HeaderText = "Factuuradres"
        Me.colAdres.Items.AddRange(New Object() {"Factuuradres", "Risicoadres"})
        Me.colAdres.Name = "colAdres"
        '
        'colIsVerwijderd
        '
        Me.colIsVerwijderd.DataPropertyName = "ISVERWIJDERD"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle13.NullValue = False
        Me.colIsVerwijderd.DefaultCellStyle = DataGridViewCellStyle13
        Me.colIsVerwijderd.FalseValue = "N"
        Me.colIsVerwijderd.HeaderText = "Verw"
        Me.colIsVerwijderd.Name = "colIsVerwijderd"
        Me.colIsVerwijderd.ToolTipText = "Verwijderd"
        Me.colIsVerwijderd.TrueValue = "J"
        Me.colIsVerwijderd.Width = 35
        '
        'colIsFacturabel
        '
        Me.colIsFacturabel.DataPropertyName = "ISFACTURABEL"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle14.NullValue = False
        Me.colIsFacturabel.DefaultCellStyle = DataGridViewCellStyle14
        Me.colIsFacturabel.FalseValue = "N"
        Me.colIsFacturabel.HeaderText = "Fact"
        Me.colIsFacturabel.Name = "colIsFacturabel"
        Me.colIsFacturabel.ToolTipText = "Facturabel"
        Me.colIsFacturabel.TrueValue = "J"
        Me.colIsFacturabel.Width = 35
        '
        'colCdArtikel
        '
        Me.colCdArtikel.DataPropertyName = "CDARTIKEL"
        Me.colCdArtikel.HeaderText = "Artikel"
        Me.colCdArtikel.Name = "colCdArtikel"
        Me.colCdArtikel.Width = 60
        '
        'colFactuurTekst
        '
        Me.colFactuurTekst.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colFactuurTekst.DataPropertyName = "FACTUURTEKST"
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colFactuurTekst.DefaultCellStyle = DataGridViewCellStyle15
        Me.colFactuurTekst.HeaderText = "Factuur tekst"
        Me.colFactuurTekst.Name = "colFactuurTekst"
        '
        'colBedrag
        '
        Me.colBedrag.DataPropertyName = "EURBEDRAG"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle16.Format = "C2"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.colBedrag.DefaultCellStyle = DataGridViewCellStyle16
        Me.colBedrag.HeaderText = "Bedrag"
        Me.colBedrag.Name = "colBedrag"
        Me.colBedrag.Width = 60
        '
        'colIsEindeMelding
        '
        Me.colIsEindeMelding.DataPropertyName = "ISEINDEMELDING"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle17.NullValue = False
        Me.colIsEindeMelding.DefaultCellStyle = DataGridViewCellStyle17
        Me.colIsEindeMelding.FalseValue = "N"
        Me.colIsEindeMelding.HeaderText = "Einde"
        Me.colIsEindeMelding.Name = "colIsEindeMelding"
        Me.colIsEindeMelding.TrueValue = "J"
        Me.colIsEindeMelding.Width = 35
        '
        'tblRapport
        '
        Me.tblRapport.AllowDelete = False
        Me.tblRapport.AllowNew = False
        '
        'btnAlles
        '
        Me.btnAlles.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAlles.Location = New System.Drawing.Point(3, 383)
        Me.btnAlles.Name = "btnAlles"
        Me.btnAlles.Size = New System.Drawing.Size(132, 24)
        Me.btnAlles.TabIndex = 3
        Me.btnAlles.Text = "&Alles selecteren"
        Me.btnAlles.UseVisualStyleBackColor = True
        '
        'btnNiets
        '
        Me.btnNiets.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNiets.Location = New System.Drawing.Point(141, 383)
        Me.btnNiets.Name = "btnNiets"
        Me.btnNiets.Size = New System.Drawing.Size(132, 24)
        Me.btnNiets.TabIndex = 4
        Me.btnNiets.Text = "&Niets selecteren"
        Me.btnNiets.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1156, 435)
        Me.Controls.Add(Me.btnNiets)
        Me.Controls.Add(Me.btnAlles)
        Me.Controls.Add(Me.gridRapport)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "RC Factuur"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gridRapport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblRapport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents gridRapport As System.Windows.Forms.DataGridView
    Friend WithEvents tblRapport As System.Data.DataView
    Friend WithEvents ToolStripVerwerk As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripVernieuw As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripFacturabel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripVerwijderd As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAlles As System.Windows.Forms.Button
    Friend WithEvents btnNiets As System.Windows.Forms.Button
    Friend WithEvents ToolStripLabelTonen As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents colMagFactureren As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colDtMelding As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTdMelding As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCdSurveillant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCdOperator As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCdDebiteur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNmAdres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCdKlant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNmKlant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAdres As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colIsVerwijderd As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colIsFacturabel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colCdArtikel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFactuurTekst As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBedrag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIsEindeMelding As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
