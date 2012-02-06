<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectie
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectie))
        Me.gridData = New System.Windows.Forms.DataGridView()
        Me.tblData = New System.Data.DataView()
        Me.ToolStripZoeken = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabelVeld = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripZoekText = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripVeldLabel = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripComboVeldnaam = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripKolommen = New System.Windows.Forms.ToolStripButton()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripZoeken.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridData
        '
        Me.gridData.AllowUserToAddRows = False
        Me.gridData.AllowUserToDeleteRows = False
        Me.gridData.AllowUserToOrderColumns = True
        Me.gridData.AllowUserToResizeRows = False
        Me.gridData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridData.AutoGenerateColumns = False
        Me.gridData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.gridData.BackgroundColor = System.Drawing.SystemColors.Window
        Me.gridData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridData.DataSource = Me.tblData
        Me.gridData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.gridData.Location = New System.Drawing.Point(3, 28)
        Me.gridData.MultiSelect = False
        Me.gridData.Name = "gridData"
        Me.gridData.ReadOnly = True
        Me.gridData.RowHeadersVisible = False
        Me.gridData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.gridData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridData.ShowCellErrors = False
        Me.gridData.ShowCellToolTips = False
        Me.gridData.ShowEditingIcon = False
        Me.gridData.ShowRowErrors = False
        Me.gridData.Size = New System.Drawing.Size(710, 234)
        Me.gridData.StandardTab = True
        Me.gridData.TabIndex = 0
        '
        'ToolStripZoeken
        '
        Me.ToolStripZoeken.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabelVeld, Me.ToolStripZoekText, Me.ToolStripVeldLabel, Me.ToolStripComboVeldnaam, Me.ToolStripSeparator1, Me.ToolStripKolommen})
        Me.ToolStripZoeken.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripZoeken.Name = "ToolStripZoeken"
        Me.ToolStripZoeken.Size = New System.Drawing.Size(716, 25)
        Me.ToolStripZoeken.TabIndex = 1
        Me.ToolStripZoeken.TabStop = True
        Me.ToolStripZoeken.Text = "ToolStrip1"
        '
        'ToolStripLabelVeld
        '
        Me.ToolStripLabelVeld.Name = "ToolStripLabelVeld"
        Me.ToolStripLabelVeld.Size = New System.Drawing.Size(33, 22)
        Me.ToolStripLabelVeld.Text = "&Zoek"
        '
        'ToolStripZoekText
        '
        Me.ToolStripZoekText.Name = "ToolStripZoekText"
        Me.ToolStripZoekText.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripVeldLabel
        '
        Me.ToolStripVeldLabel.Margin = New System.Windows.Forms.Padding(8, 1, 8, 2)
        Me.ToolStripVeldLabel.Name = "ToolStripVeldLabel"
        Me.ToolStripVeldLabel.Size = New System.Drawing.Size(42, 22)
        Me.ToolStripVeldLabel.Text = "in &veld"
        '
        'ToolStripComboVeldnaam
        '
        Me.ToolStripComboVeldnaam.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ToolStripComboVeldnaam.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ToolStripComboVeldnaam.Name = "ToolStripComboVeldnaam"
        Me.ToolStripComboVeldnaam.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripKolommen
        '
        Me.ToolStripKolommen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripKolommen.Image = CType(resources.GetObject("ToolStripKolommen.Image"), System.Drawing.Image)
        Me.ToolStripKolommen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripKolommen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripKolommen.Name = "ToolStripKolommen"
        Me.ToolStripKolommen.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripKolommen.Text = "Kolommen"
        '
        'frmSelectie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 266)
        Me.Controls.Add(Me.ToolStripZoeken)
        Me.Controls.Add(Me.gridData)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSelectie"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Selecteer"
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripZoeken.ResumeLayout(False)
        Me.ToolStripZoeken.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gridData As System.Windows.Forms.DataGridView
    Friend WithEvents tblData As System.Data.DataView
    Friend WithEvents ToolStripZoeken As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabelVeld As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripZoekText As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripVeldLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripComboVeldnaam As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripKolommen As System.Windows.Forms.ToolStripButton
End Class
