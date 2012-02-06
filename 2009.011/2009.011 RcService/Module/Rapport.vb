' [REV.HIST]---------------------------------------------------------------------------------------
'  Wanneer  Revisie Wie Wat 
' -------------------------------------------------------------------------------------------------
' 11-09-08  1.0.0.0 kv  Initiele versie
' 29-09-11  1.0.0.1 kv  Overgenomen uit RcService Webservice
' -------------------------------------------------------------------------------------------------
Imports System.Web
Imports System.Data
Imports System.Data.Odbc

Public Class Rapport

    Dim dbMultivers As Odbc.OdbcConnection

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function NieuwRapport _
     (ByVal cdDebiteur As String _
     , ByVal cdSurveillant As String _
     , ByVal cdOperator As String _
     , ByVal DatumTijd As DateTime _
     , ByVal avGemaakt As Boolean _
     , ByVal melding As String _
     , ByVal eurBedrag As Double _
     , ByVal isFacturabel As Boolean _
     , ByVal cdAdres As String _
     , ByVal cdArtikel As String _
     , Optional ByVal isEindeMelding As Boolean = False) As String

        Static base As Random = New Random()

        Dim odbcCommand As Odbc.OdbcCommand
        Dim volgnr As Integer
        Dim myId As String

        If Connect() Then
            Try
                'Zoek het eerstvolgende nummer op
                odbcCommand = New Odbc.OdbcCommand(String.Format( _
                    "SELECT MAX(VOLGNUMMER) " & _
                    "FROM VT_RAPPORTAGE " & _
                    "WHERE CDDEBITEUR = {0} " _
                    , SQL.String(cdDebiteur)), dbMultivers)
                Dim laatste As Object = odbcCommand.ExecuteScalar
                If Trim(laatste & "") = "" Then
                    volgnr = 1
                Else
                    volgnr = laatste + 1
                End If

                'Maak een nieuw id aan
                Dim id() As Byte = Array.CreateInstance(System.Type.GetType("System.Byte", False, True), 16)
                base.NextBytes(id)
                myId = (New Guid(id)).ToString("N").ToUpper()

                'Leg het item vast
                odbcCommand = New Odbc.OdbcCommand(String.Format( _
                    "INSERT INTO VT_RAPPORTAGE ( CDDEBITEUR, VOLGNUMMER, GUID_ITEM, SYS_CREATE, SYS_UPDATE, VVCDSURVEILLANT, VVDTMELDING, VVTDMELDING, VVAVGEMAAKT, VVCDOPERATOR, VVMELDING, VVEURBEDRAG, VVISFACTURABEL, VVCDADRES, VVISVERWIJDERD, VVCDARTIKEL, VVISEINDEMELDING ) " & _
                    "VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},'N',{14},{15})" _
                    , SQL.String(cdDebiteur) _
                    , SQL.Number(volgnr, 0) _
                    , SQL.String(myId) _
                    , SQL.Date(Now, "yy-MM-dd") _
                    , SQL.Date(Now, "yy-MM-dd") _
                    , SQL.String(cdSurveillant) _
                    , SQL.Date(DatumTijd) _
                    , SQL.Time(DatumTijd) _
                    , SQL.JaNee(avGemaakt) _
                    , SQL.String(cdOperator) _
                    , SQL.String(melding) _
                    , SQL.Number(eurBedrag, 2) _
                    , SQL.JaNee(isFacturabel) _
                    , Adres(cdAdres) _
                    , SQL.String(cdArtikel) _
                    , SQL.JaNee(isEindeMelding)) _
                    , dbMultivers)
                odbcCommand.ExecuteNonQuery()

                'Geef de code voor het id terug
                NieuwRapport = myId

            Catch ex As Exception
                'Laat weten dat de actie mislukt is
                Throw New Exception(ex.Message)
                NieuwRapport = ""
            End Try
        Else
            NieuwRapport = ""
        End If
        CloseConnection()
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function WijzigRapport _
     (ByVal id As String _
     , ByVal cdSurveillant As String _
     , ByVal cdOperator As String _
     , ByVal DatumTijd As DateTime _
     , ByVal avGemaakt As Boolean _
     , ByVal melding As String _
     , ByVal eurBedrag As Double _
     , ByVal cdAdres As String _
     , ByVal cdArtikel As String _
     , ByVal isFacturabel As Boolean _
     , Optional ByVal isEindeMelding As Boolean = False) As String

        Dim odbcCommand As Odbc.OdbcCommand

        If Connect() Then
            Try
                'Wijzig het item
                odbcCommand = New Odbc.OdbcCommand(String.Format( _
                    "UPDATE VT_RAPPORTAGE " & _
                    "SET VVCDSURVEILLANT= {1} " & _
                    "   , VVDTMELDING   = {2} " & _
                    "   , VVTDMELDING   = {3} " & _
                    "   , VVAVGEMAAKT   = {4} " & _
                    "   , VVCDOPERATOR  = {5} " & _
                    "   , VVMELDING     = {6} " & _
                    "   , VVEURBEDRAG   = {7} " & _
                    "   , VVISFACTURABEL= {8} " & _
                    "   , VVCDADRES     = {9} " & _
                    "   , SYS_UPDATE    = {10} " & _
                    "   , VVCDARTIKEL   = {11} " & _
                    "   , VVISEINDEMELDING = {12} " & _
                    "WHERE GUID_ITEM = {0} " _
                    , SQL.String(id) _
                    , SQL.String(cdSurveillant) _
                    , SQL.Date(DatumTijd) _
                    , SQL.Time(DatumTijd) _
                    , SQL.JaNee(avGemaakt) _
                    , SQL.String(cdOperator) _
                    , SQL.String(melding) _
                    , SQL.Number(eurBedrag, 2) _
                    , SQL.JaNee(isFacturabel) _
                    , Adres(cdAdres) _
                    , SQL.Date(Now, "yy-MM-dd") _
                    , SQL.String(cdArtikel) _
                    , SQL.JaNee(isEindeMelding)) _
                    , dbMultivers)
                WijzigRapport = odbcCommand.ExecuteNonQuery()

            Catch ex As Exception
                'Laat weten dat de actie mislukt is
                Throw New Exception(ex.Message)
                WijzigRapport = 0
            End Try
        Else
            WijzigRapport = 0
        End If
        CloseConnection()
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function VerwijderRapport _
     (ByVal id As String) As String

        Dim odbcCommand As Odbc.OdbcCommand

        If Connect() Then
            Try
                'Maak van verwijderd niet-verwijderd en andersom
                odbcCommand = New Odbc.OdbcCommand(String.Format( _
                    "UPDATE VT_RAPPORTAGE " & _
                    "SET VVISVERWIJDERD = @DECODE(VVISVERWIJDERD,'J','N','J') " & _
                    "   , SYS_UPDATE = {1} " & _
                    "WHERE GUID_ITEM = {0} " _
                    , SQL.String(id) _
                    , SQL.Date(Now, "yy-MM-dd")), dbMultivers)
                VerwijderRapport = odbcCommand.ExecuteNonQuery()

            Catch ex As Exception
                'Laat weten dat de actie mislukt is
                Throw New Exception(ex.Message)
                VerwijderRapport = 0
            End Try
        Else
            VerwijderRapport = 0
        End If
        CloseConnection()
    End Function

    Private Function Connect() As Boolean
        Try
            'Open de verbinding met Unit 4 Multivers
            dbMultivers = New Odbc.OdbcConnection
            dbMultivers.ConnectionString = String.Format("DSN=Unit 4 Multivers;DB={0};UID={1};PWD={2}", My.Settings.cdAdministratie & "", "SYSADM", "U4")
            dbMultivers.Open()
            Connect = (dbMultivers.State = ConnectionState.Open)

        Catch ex As Exception
            'Laat weten dat de actie mislukt is
            Throw New Exception(ex.Message)
            Connect = False
        End Try
    End Function

    Private Sub CloseConnection()

        If Not dbMultivers Is Nothing Then
            If dbMultivers.State = ConnectionState.Open Then
                dbMultivers.Close()
            End If
            dbMultivers = Nothing
        End If
    End Sub

    Private Function Adres(ByVal cdadres As String) As String

        If cdadres.Substring(0, 1).ToUpper = "F" Then
            Adres = SQL.String("Factuuradres")
        Else
            Adres = SQL.String("Risicoadres")
        End If
    End Function

End Class
