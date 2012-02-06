' [REV.HIST]---------------------------------------------------------------------------------------
'  Wanneer  Revisie Wie Wat 
' -------------------------------------------------------------------------------------------------
' 11-09-08  1.0.0.0 kv  Initiele versie
' -------------------------------------------------------------------------------------------------
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data

Partial Class DefaultPage
    Inherits System.Web.UI.Page

    Const MOD_CODE As String = "2009.011"
    Const MOD_NAME As String = "Regio Control Service"
    Const MOD_BUILD As Integer = 1

    Dim odbcMultivers As System.Data.Odbc.OdbcConnection
    Dim queueUpdate As Queue = New Queue

    Dim nmApplicatie As String = ""
    Dim verApplicatie As String = ""
    Dim mvlVersie As String = "<geen verbinding>"
    Dim cdAdmin As String = ""

    Dim nmAdmin As String = "<onbekend>"

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub


    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            'Haal de applicatieinstellingen op
            nmApplicatie = System.Configuration.ConfigurationManager.AppSettings.Get("ApplicatieNaam") & ""
            cdAdmin = System.Configuration.ConfigurationManager.AppSettings.Get("Administratie") & ""

            'Haal de naam van de administratie op
            nmAdmin = nmAdministratie(cdAdmin)
            If nmAdmin <> "" Then
                'Controleer of de vrije tabellen aangemaakt zijn
                If chkBuild() Then
                    Me.btnInstalleer.Enabled = False
                Else
                    Me.btnInstalleer.Enabled = True
                End If
            End If

            'Haal het versienummer van Multivers op
            mvlVersie = VersieMultivers()
            verApplicatie = VersieApplicatie()

        Catch ex As Exception
            Throw New HttpException(ex.Message)

        Finally
            If Not (odbcMultivers Is Nothing) AndAlso (odbcMultivers.State <> ConnectionState.Closed) Then
                odbcDisconnect()
            End If
        End Try

        'Vul de gevonden gegevens op het scherm in
        Me.lblApplication.Text = nmApplicatie
        Me.txtVersie.Text = String.Format("&nbsp;Versie {0}", verApplicatie)
        Me.txtMultivers.Text = String.Format("&nbsp;Versie {0}", mvlVersie)
        Me.txtApplicatieNaam.Text = String.Format("&nbsp;{0}", nmApplicatie)
        Me.txtCdAdmin.Text = String.Format("&nbsp;{0}", cdAdmin)
        Me.txtNmAdmin.Text = String.Format("&nbsp;{0}", nmAdmin)
    End Sub

    Private Sub btnInstalleer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInstalleer.Click

        Dim odbcCommand As Odbc.OdbcCommand

        If odbcConnect(cdAdmin) Then
            Try
                leesUpdate()
                While queueUpdate.Count > 0
                    odbcCommand = New Odbc.OdbcCommand(queueUpdate.Dequeue, odbcMultivers)
                    odbcCommand.ExecuteNonQuery()
                End While

            Catch ex As Exception
                Throw New Web.HttpException(ex.Message)

            Finally
                odbcDisconnect()
            End Try
            Me.Page.Validate()
        End If
    End Sub

    Private Function chkBuild() As Boolean

        Dim odbcSelect As Odbc.OdbcDataAdapter
        Dim tblModule As DataTable = New DataTable
        Dim recModule As DataRow

        If odbcConnect(cdAdmin) Then

            'Zorg dat de tabel met modules aanwezig is
            maakTabelModule()
            chkBuild = True

            'Controleer of de codetabel aangemaakt is
            odbcSelect = New Odbc.OdbcDataAdapter(String.Format( _
                "SELECT CDMODULE        AS CDMODULE " & _
                "   , NMMODULE          AS NMMODULE " & _
                "   , BUILD             AS BUILD " & _
                "FROM P4_MODULE "), odbcMultivers)
            odbcSelect.Fill(tblModule)
            For Each recModule In tblModule.Rows

                Select Case (recModule("CDMODULE") & "").ToString()
                    Case "P40000"   'ALGEMEEN
                        If recModule!Build < 1 Then
                            chkBuild = False
                        End If

                    Case "P4AA02"   'UREN ON-LINE 
                        If recModule!BUILD < 1 Then
                            chkBuild = False
                        End If

                    Case "P4AA03"   'RC SERVICE
                        If recModule!BUILD < 1 Then
                            chkBuild = False
                        End If
                End Select
            Next recModule
            odbcDisconnect()
        End If
    End Function

    Private Sub leesUpdate()

        Dim odbcSelect As Odbc.OdbcDataAdapter
        Dim tblModule As DataTable = New DataTable
        Dim recModule As DataRow

        If (odbcMultivers.State = ConnectionState.Open) OrElse (odbcConnect(cdAdmin)) Then

            'Zorg dat de tabel met modules aanwezig is
            maakTabelModule()

            'Controleer of de codetabel aangemaakt is
            odbcSelect = New Odbc.OdbcDataAdapter(String.Format( _
                "SELECT CDMODULE        AS CDMODULE " & _
                "   , NMMODULE          AS NMMODULE " & _
                "   , BUILD             AS BUILD " & _
                "FROM P4_MODULE "), odbcMultivers)
            odbcSelect.Fill(tblModule)
            For Each recModule In tblModule.Rows

                Select Case (recModule!CDMODULE & "").ToString()
                    Case "P40000"   'ALGEMEEN
                        If recModule!Build < 1 Then
                            Me.leesUpdateAlgemeen(recModule!BUILD)
                        End If

                    Case "P4AA02"   'UREN ON-LINE 
                        If recModule!BUILD < 1 Then
                            Me.leesUpdateUrenOnline(recModule!BUILD)
                        End If

                    Case "P4AA03"   'RC Control
                        If recModule!BUILD < 1 Then
                            Me.leesUpdateUrenOnline(recModule!BUILD)
                        End If
                End Select
            Next recModule
        End If
    End Sub

    Private Sub maakTabelModule()

        Dim odbccommand As Odbc.OdbcCommand
        Dim queueCmd As Queue = New Queue

        'Voeg alle commando's toe voor de initialisatie van het maatwerk
        queueCmd.Enqueue("CREATE TABLE SYSADM.P4_MODULE (CDMODULE VARCHAR(40) NOT NULL, PRIMARY KEY (CDMODULE)) ")
        queueCmd.Enqueue("CREATE PUBLIC SYNONYM P4_MODULE FOR SYSADM.P4_MODULE ")
        queueCmd.Enqueue("CREATE UNIQUE INDEX SYSADM.PK_P4MODULE ON SYSADM.P4_MODULE (CDMODULE) ")
        queueCmd.Enqueue("ALTER TABLE P4_MODULE ADD NMMODULE       VARCHAR(50) ")
        queueCmd.Enqueue("ALTER TABLE P4_MODULE ADD LICENCEE       VARCHAR(50) ")
        queueCmd.Enqueue("ALTER TABLE P4_MODULE ADD DTLICENTIE     DATE ")
        queueCmd.Enqueue("ALTER TABLE P4_MODULE ADD SLEUTEL        VARCHAR(32) ")
        queueCmd.Enqueue("ALTER TABLE P4_MODULE ADD VERSIE         VARCHAR(10) ")
        queueCmd.Enqueue("ALTER TABLE P4_MODULE ADD BUILD          INTEGER NOT NULL WITH DEFAULT ")
        queueCmd.Enqueue("GRANT SELECT ON SYSADM.P4_MODULE TO PUBLIC ")
        queueCmd.Enqueue("INSERT INTO P4_MODULE ( CDMODULE , NMMODULE ) VALUES ('P40000', 'Algemeen') ")
        queueCmd.Enqueue("INSERT INTO P4_MODULE ( CDMODULE , NMMODULE ) VALUES ('{0}','{1}') ")

        If odbcMultivers.State = ConnectionState.Open Then
            'Controleer of de codetabel aangemaakt is
            odbccommand = New Odbc.OdbcCommand(String.Format( _
                "SELECT NAME " & _
                "FROM SYSTABLES " & _
                "WHERE NAME ='P4_MODULE'"), odbcMultivers)
            Dim nmTabel As String = odbccommand.ExecuteScalar
            If Trim(nmTabel & "") = "" Then
                While queueCmd.Count > 0
                    odbccommand.CommandText = String.Format(queueCmd.Dequeue, MOD_CODE, MOD_NAME)
                    odbccommand.ExecuteNonQuery()
                End While
            End If
        End If
    End Sub

    Private Sub leesUpdateAlgemeen(ByVal buildHuidig As Integer)

        If buildHuidig < 1 Then
            ' Module: Algemeen  Build: 1 
            queueUpdate.Enqueue("CREATE TABLE SYSADM.P4_CODETABEL (CODE VARCHAR(16) NOT NULL, PRIMARY KEY (CODE)) ")
            queueUpdate.Enqueue("CREATE PUBLIC SYNONYM P4_CODETABEL FOR SYSADM.P4_CODETABEL ")
            queueUpdate.Enqueue("CREATE UNIQUE INDEX SYSADM.PK_P4CODETABEL ON SYSADM.P4_CODETABEL(CODE) ")
            queueUpdate.Enqueue("ALTER TABLE P4_CODETABEL ADD WAARDE      VARCHAR(250) ")
            queueUpdate.Enqueue("GRANT SELECT ON SYSADM.P4_CODETABEL TO PUBLIC ")
            queueUpdate.Enqueue("UPDATE P4_MODULE SET BUILD=1, VERSIE='1.0.0' WHERE CDMODULE='P40000' ")
        End If
    End Sub

    Private Sub leesUpdateUrenOnline(ByVal buildHuidig As Integer)

        If buildHuidig < 1 Then
            'Registreer deze versie
            queueUpdate.Enqueue(String.Format("UPDATE P4_MODULE SET BUILD=1, VERSIE='1.0.0' WHERE CDMODULE='{0}' ", MOD_CODE))
        End If
    End Sub

    Private Function VersieMultivers() As String

        Dim odbcInfo As Odbc.OdbcCommand
        Dim mvlVersie As String

        If odbcConnect("MVLSYST") Then
            'Haal het versienummer van Multivers op
            odbcInfo = New Odbc.OdbcCommand( _
                "SELECT MVLSYSTVERSIE " & _
                "FROM UPGRADESTATISTICS ", odbcMultivers)
            mvlVersie = odbcInfo.ExecuteScalar & ""
            If mvlVersie <> "" Then
                VersieMultivers = String.Format("{0}.{1}.{2}.{3}" _
                        , mvlVersie.Substring(0, 1) _
                        , mvlVersie.Substring(1, 1) _
                        , mvlVersie _
                        , mvlVersie.Substring(3, 1))
            Else
                VersieMultivers = ""
            End If
            odbcDisconnect()
        Else
            VersieMultivers = ""
        End If
    End Function

    Private Function VersieApplicatie() As String

        Dim odbcInfo As Odbc.OdbcCommand
        Dim applVersie As Object

        If odbcConnect(cdAdmin) Then
            odbcInfo = New Odbc.OdbcCommand(String.Format( _
                "SELECT VERSIE " & _
                "FROM P4_MODULE " & _
                "WHERE CDMODULE = '{0}'", MOD_CODE), odbcMultivers)
            applVersie = odbcInfo.ExecuteScalar
            If applVersie & "" <> "" Then
                VersieApplicatie = applVersie & ""
            Else
                VersieApplicatie = "onbekend"
            End If
            odbcDisconnect()
        Else
            VersieApplicatie = "onbekend"
        End If
    End Function

    Private Function nmAdministratie(ByVal cdadmin As String) As String

        Dim odbcInfo As Odbc.OdbcCommand

        If odbcConnect("MVLMAIN") Then
            'Haal het versienummer van Multivers op
            odbcInfo = New Odbc.OdbcCommand(String.Format( _
                "SELECT OMSCHRIJVING " & _
                "FROM ADMINISTRATIES " & _
                "WHERE ADMINNR = '{0}'", cdadmin), odbcMultivers)
            nmAdministratie = odbcInfo.ExecuteScalar & ""
            odbcDisconnect()
        Else
            nmAdministratie = ""
        End If
    End Function

    Private Function odbcConnect(ByVal cdadmin As String) As Boolean

        Try
            'Maak verbinding met de Administratie 
            odbcMultivers = New Odbc.OdbcConnection(String.Format( _
                "DSN=Unit 4 Multivers;DB={0};UID=SYSADM;PWD=U4", cdadmin))
            odbcMultivers.Open()
            odbcConnect = (odbcMultivers.State = ConnectionState.Open)

        Catch ex As Exception
            odbcConnect = False
        End Try
    End Function

    Private Function odbcDisconnect() As Boolean

        If (Not odbcMultivers Is Nothing) Then
            If odbcMultivers.State = ConnectionState.Open Then
                odbcMultivers.Close()
            End If
            odbcMultivers = Nothing
        End If
    End Function

    Protected Sub btnStart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStart.Click

    End Sub
End Class
