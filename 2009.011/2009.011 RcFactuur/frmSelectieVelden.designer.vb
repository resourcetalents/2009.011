<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectieVelden
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectieVelden))
        Me.lstVelden = New System.Windows.Forms.CheckedListBox
        Me.btnUp = New VbPowerPack.ImageButton
        Me.btnDn = New VbPowerPack.ImageButton
        Me.SuspendLayout()
        '
        'lstVelden
        '
        Me.lstVelden.AllowDrop = True
        Me.lstVelden.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstVelden.CheckOnClick = True
        Me.lstVelden.Location = New System.Drawing.Point(5, 4)
        Me.lstVelden.Name = "lstVelden"
        Me.lstVelden.Size = New System.Drawing.Size(206, 349)
        Me.lstVelden.TabIndex = 0
        Me.lstVelden.ThreeDCheckBoxes = True
        '
        'btnUp
        '
        Me.btnUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUp.BackColor = System.Drawing.Color.Transparent
        Me.btnUp.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnUp.Location = New System.Drawing.Point(213, 6)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.NormalImage = CType(resources.GetObject("btnUp.NormalImage"), System.Drawing.Image)
        Me.btnUp.Size = New System.Drawing.Size(24, 24)
        Me.btnUp.SizeMode = VbPowerPack.ImageButtonSizeMode.AutoSize
        Me.btnUp.TabIndex = 1
        Me.btnUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnDn
        '
        Me.btnDn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDn.BackColor = System.Drawing.Color.Transparent
        Me.btnDn.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnDn.Location = New System.Drawing.Point(213, 36)
        Me.btnDn.Name = "btnDn"
        Me.btnDn.NormalImage = CType(resources.GetObject("btnDn.NormalImage"), System.Drawing.Image)
        Me.btnDn.Size = New System.Drawing.Size(24, 24)
        Me.btnDn.SizeMode = VbPowerPack.ImageButtonSizeMode.AutoSize
        Me.btnDn.TabIndex = 2
        Me.btnDn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'frmSelectieVelden
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(241, 361)
        Me.Controls.Add(Me.btnDn)
        Me.Controls.Add(Me.btnUp)
        Me.Controls.Add(Me.lstVelden)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSelectieVelden"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Selectie kolommen"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstVelden As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnUp As VbPowerPack.ImageButton
    Friend WithEvents btnDn As VbPowerPack.ImageButton
End Class
