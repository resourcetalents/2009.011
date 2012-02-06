<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
    Friend WithEvents lblGebruiker As System.Windows.Forms.Label
    Friend WithEvents lblWachtwoord As System.Windows.Forms.Label
    Friend WithEvents txtGebruiker As System.Windows.Forms.TextBox
    Friend WithEvents txtWachtwoord As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.lblGebruiker = New System.Windows.Forms.Label
        Me.lblWachtwoord = New System.Windows.Forms.Label
        Me.txtGebruiker = New System.Windows.Forms.TextBox
        Me.txtWachtwoord = New System.Windows.Forms.TextBox
        Me.OK = New System.Windows.Forms.Button
        Me.Cancel = New System.Windows.Forms.Button
        Me.loginPanel = New System.Windows.Forms.TableLayoutPanel
        Me.lblAdmin = New System.Windows.Forms.Label
        Me.cmbAdmin = New System.Windows.Forms.ComboBox
        Me.loginPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblGebruiker
        '
        Me.lblGebruiker.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGebruiker.Location = New System.Drawing.Point(3, 34)
        Me.lblGebruiker.Name = "lblGebruiker"
        Me.lblGebruiker.Size = New System.Drawing.Size(104, 23)
        Me.lblGebruiker.TabIndex = 2
        Me.lblGebruiker.Text = "&Gebruikersnaam"
        Me.lblGebruiker.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWachtwoord
        '
        Me.lblWachtwoord.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWachtwoord.Location = New System.Drawing.Point(3, 65)
        Me.lblWachtwoord.Name = "lblWachtwoord"
        Me.lblWachtwoord.Size = New System.Drawing.Size(104, 23)
        Me.lblWachtwoord.TabIndex = 4
        Me.lblWachtwoord.Text = "&Wachtwoord"
        Me.lblWachtwoord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGebruiker
        '
        Me.txtGebruiker.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGebruiker.Location = New System.Drawing.Point(113, 34)
        Me.txtGebruiker.MaxLength = 16
        Me.txtGebruiker.Name = "txtGebruiker"
        Me.txtGebruiker.Size = New System.Drawing.Size(133, 20)
        Me.txtGebruiker.TabIndex = 3
        '
        'txtWachtwoord
        '
        Me.txtWachtwoord.Location = New System.Drawing.Point(113, 65)
        Me.txtWachtwoord.MaxLength = 8
        Me.txtWachtwoord.Name = "txtWachtwoord"
        Me.txtWachtwoord.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtWachtwoord.Size = New System.Drawing.Size(133, 20)
        Me.txtWachtwoord.TabIndex = 5
        '
        'OK
        '
        Me.OK.Location = New System.Drawing.Point(56, 124)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(94, 23)
        Me.OK.TabIndex = 1
        Me.OK.Text = "&OK"
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(156, 124)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(94, 23)
        Me.Cancel.TabIndex = 2
        Me.Cancel.Text = "&Cancel"
        '
        'loginPanel
        '
        Me.loginPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.loginPanel.ColumnCount = 2
        Me.loginPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.loginPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.loginPanel.Controls.Add(Me.lblAdmin, 0, 0)
        Me.loginPanel.Controls.Add(Me.cmbAdmin, 1, 0)
        Me.loginPanel.Controls.Add(Me.lblGebruiker, 0, 2)
        Me.loginPanel.Controls.Add(Me.txtGebruiker, 1, 2)
        Me.loginPanel.Controls.Add(Me.lblWachtwoord, 0, 4)
        Me.loginPanel.Controls.Add(Me.txtWachtwoord, 1, 4)
        Me.loginPanel.Location = New System.Drawing.Point(4, 12)
        Me.loginPanel.Name = "loginPanel"
        Me.loginPanel.RowCount = 6
        Me.loginPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.loginPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.loginPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.loginPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.loginPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.loginPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.loginPanel.Size = New System.Drawing.Size(270, 95)
        Me.loginPanel.TabIndex = 0
        '
        'lblAdmin
        '
        Me.lblAdmin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAdmin.Location = New System.Drawing.Point(3, 3)
        Me.lblAdmin.Name = "lblAdmin"
        Me.lblAdmin.Size = New System.Drawing.Size(104, 23)
        Me.lblAdmin.TabIndex = 0
        Me.lblAdmin.Text = "&Administratie"
        Me.lblAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbAdmin
        '
        Me.cmbAdmin.FormattingEnabled = True
        Me.cmbAdmin.Location = New System.Drawing.Point(113, 3)
        Me.cmbAdmin.Name = "cmbAdmin"
        Me.cmbAdmin.Size = New System.Drawing.Size(121, 21)
        Me.cmbAdmin.TabIndex = 1
        '
        'frmLogin
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(277, 159)
        Me.ControlBox = False
        Me.Controls.Add(Me.loginPanel)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.OK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.loginPanel.ResumeLayout(False)
        Me.loginPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents loginPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblAdmin As System.Windows.Forms.Label
    Friend WithEvents cmbAdmin As System.Windows.Forms.ComboBox

End Class
