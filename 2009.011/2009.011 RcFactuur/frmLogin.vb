Public Class frmLogin

    Dim ubcMultivers As Object 'MBO.Administration

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        'Probeer in te loggen als de gebruiker met het wachtwoord
        Try
            'Probeer in te loggen
            ubcMultivers.Connect(Me.cmbAdmin.Text, Me.txtGebruiker.Text, Me.txtWachtwoord.Text)
            Me.DialogResult = Windows.Forms.DialogResult.OK

            'Sla de gebruikte gegevens op
            My.Settings.mvlAdministratie = Me.cmbAdmin.Text
            My.Settings.mvlGebruiker = Me.txtGebruiker.Text
            My.Settings.Save()
            Me.Close()
            ubcMultivers = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Unit 4 Multivers")
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ubcAdmin As String

        'Verbind met Multivers en haal alle administraties op
        ubcMultivers = CreateObject("MBO.ADMINISTRATION")
        ubcMultivers.ErrorLogFolder = "c:\"
        ubcMultivers.KeepConnection = True

        For Each ubcAdmin In ubcMultivers.Databases
            cmbAdmin.Items.Add(ubcAdmin)
        Next

        'Neem de laatste gegevens uit de instellingen over
        Me.cmbAdmin.Text = UCase(My.Settings.mvlAdministratie & "")
        Me.txtGebruiker.Text = UCase(My.Settings.mvlGebruiker & "")

        'Standaard invoer op het wachtwoord
        Me.txtWachtwoord.Focus()
    End Sub
End Class
