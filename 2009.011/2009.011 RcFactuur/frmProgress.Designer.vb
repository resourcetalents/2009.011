<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgress
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProgress))
        Me.pboxUpdate = New System.Windows.Forms.PictureBox()
        Me.pbarAlgemeen = New System.Windows.Forms.ProgressBar()
        Me.txtInfoBox = New System.Windows.Forms.TextBox()
        Me.panelUpgrade = New System.Windows.Forms.TableLayoutPanel()
        Me.btnAnnuleer = New System.Windows.Forms.Button()
        CType(Me.pboxUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelUpgrade.SuspendLayout()
        Me.SuspendLayout()
        '
        'pboxUpdate
        '
        Me.pboxUpdate.Image = CType(resources.GetObject("pboxUpdate.Image"), System.Drawing.Image)
        Me.pboxUpdate.Location = New System.Drawing.Point(10, 20)
        Me.pboxUpdate.Margin = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.pboxUpdate.Name = "pboxUpdate"
        Me.panelUpgrade.SetRowSpan(Me.pboxUpdate, 4)
        Me.pboxUpdate.Size = New System.Drawing.Size(48, 48)
        Me.pboxUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pboxUpdate.TabIndex = 0
        Me.pboxUpdate.TabStop = False
        '
        'pbarAlgemeen
        '
        Me.pbarAlgemeen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbarAlgemeen.Location = New System.Drawing.Point(78, 43)
        Me.pbarAlgemeen.Margin = New System.Windows.Forms.Padding(8, 3, 15, 3)
        Me.pbarAlgemeen.Name = "pbarAlgemeen"
        Me.pbarAlgemeen.Size = New System.Drawing.Size(352, 16)
        Me.pbarAlgemeen.TabIndex = 1
        '
        'txtInfoBox
        '
        Me.txtInfoBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInfoBox.BackColor = System.Drawing.SystemColors.Control
        Me.txtInfoBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtInfoBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfoBox.Location = New System.Drawing.Point(80, 18)
        Me.txtInfoBox.Margin = New System.Windows.Forms.Padding(10, 3, 10, 0)
        Me.txtInfoBox.Name = "txtInfoBox"
        Me.txtInfoBox.Size = New System.Drawing.Size(355, 13)
        Me.txtInfoBox.TabIndex = 2
        '
        'panelUpgrade
        '
        Me.panelUpgrade.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelUpgrade.BackColor = System.Drawing.SystemColors.Control
        Me.panelUpgrade.ColumnCount = 2
        Me.panelUpgrade.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.panelUpgrade.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.panelUpgrade.Controls.Add(Me.pboxUpdate, 0, 0)
        Me.panelUpgrade.Controls.Add(Me.pbarAlgemeen, 1, 2)
        Me.panelUpgrade.Controls.Add(Me.txtInfoBox, 1, 1)
        Me.panelUpgrade.Controls.Add(Me.btnAnnuleer, 1, 3)
        Me.panelUpgrade.Location = New System.Drawing.Point(1, 1)
        Me.panelUpgrade.Name = "panelUpgrade"
        Me.panelUpgrade.RowCount = 4
        Me.panelUpgrade.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.panelUpgrade.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.panelUpgrade.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.panelUpgrade.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.panelUpgrade.Size = New System.Drawing.Size(445, 98)
        Me.panelUpgrade.TabIndex = 2
        '
        'btnAnnuleer
        '
        Me.btnAnnuleer.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnAnnuleer.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAnnuleer.Location = New System.Drawing.Point(212, 66)
        Me.btnAnnuleer.Margin = New System.Windows.Forms.Padding(3, 3, 3, 6)
        Me.btnAnnuleer.Name = "btnAnnuleer"
        Me.btnAnnuleer.Size = New System.Drawing.Size(90, 26)
        Me.btnAnnuleer.TabIndex = 3
        Me.btnAnnuleer.Text = "Annuleer"
        Me.btnAnnuleer.UseVisualStyleBackColor = True
        '
        'frmProgress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.CancelButton = Me.btnAnnuleer
        Me.ClientSize = New System.Drawing.Size(447, 100)
        Me.Controls.Add(Me.panelUpgrade)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProgress"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmProgress"
        CType(Me.pboxUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelUpgrade.ResumeLayout(False)
        Me.panelUpgrade.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pboxUpdate As System.Windows.Forms.PictureBox
    Friend WithEvents panelUpgrade As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pbarAlgemeen As System.Windows.Forms.ProgressBar
    Friend WithEvents txtInfoBox As System.Windows.Forms.TextBox
    Friend WithEvents btnAnnuleer As System.Windows.Forms.Button
End Class
