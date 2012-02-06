Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data
Imports System.Data.Odbc

<WebService(Namespace:="http://www.info-domain.nl/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class Rapport
    Inherits System.Web.Services.WebService

    Dim dbMultivers As Odbc.OdbcConnection

    <WebMethod(Description:="Leg een nieuw rapport vast")> _
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
     , byval cdArtikel as string ) As String

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
                    , sql.String(cdDebiteur)), dbMultivers)
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
                    "INSERT INTO VT_RAPPORTAGE ( CDDEBITEUR, VOLGNUMMER, GUID_ITEM, SYS_CREATE, SYS_UPDATE, VVCDSURVEILLANT, VVDTMELDING, VVTDMELDING, VVAVGEMAAKT, VVCDOPERATOR, VVMELDING, VVEURBEDRAG, VVISFACTURABEL, VVCDADRES, VVISVERWIJDERD, VVCDARTIKEL ) " & _
                    "VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},'N',{14})" _
                    , sql.String(cdDebiteur) _
                    , sql.Number(volgnr, 0) _
                    , sql.String(myId) _
                    , sql.Date(Now, "yy-MM-dd") _
                    , sql.Date(Now, "yy-MM-dd") _
                    , sql.String(cdSurveillant) _
                    , sql.Date(DatumTijd) _
                    , sql.Time(DatumTijd) _
                    , sql.JaNee(avGemaakt) _
                    , sql.String(cdOperator) _
                    , sql.String(melding) _
                    , sql.Number(eurBedrag, 2) _
                    , sql.JaNee(isFacturabel) _
                    , Adres(cdAdres) _
                    , sql.string(cdArtikel)), dbMultivers)
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

    <WebMethod(Description:="Wijzig een vastgelegd rapport")> _
    Public Function WijzigRapport _
     (ByVal id As String _
     , ByVal cdSurveillant As String _
     , ByVal cdOperator As String _
     , ByVal DatumTijd As DateTime _
     , ByVal avGemaakt As Boolean _
     , ByVal melding As String _
     , ByVal eurBedrag As Double _
     , ByVal cdAdres As String _
     , byval cdArtikel as string _
     , ByVal isFacturabel As Boolean) As String

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
                    "WHERE GUID_ITEM = {0} " _
                    , sql.String(id) _
                    , sql.String(cdSurveillant) _
                    , sql.Date(DatumTijd) _
                    , sql.Time(DatumTijd) _
                    , sql.JaNee(avGemaakt) _
                    , sql.String(cdOperator) _
                    , sql.String(melding) _
                    , sql.Number(eurBedrag, 2) _
                    , sql.JaNee(isFacturabel) _
                    , Adres(cdAdres) _
                    , sql.Date(Now, "yy-MM-dd") _
                    , SQL.string(cdArtikel)), dbMultivers)
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

    <WebMethod(Description:="Verwijder een vastgelegd rapport")> _
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
                    , sql.String(id) _
                    , sql.Date(Now, "yy-MM-dd")), dbMultivers)
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

    <WebMethod(Description:="Wijzig de inschakelcode")> _
    Public Function schrijfInschakelCode  _
     (ByVal cdDebiteur As String _
     , byval cdCode as string ) As String

        IF CONNECT then
            Try
                'Maak van verwijderd niet-verwijderd en andersom
                Dim odbcCommand As odbc.OdbcCommand = New Odbc.OdbcCommand(String.Format( _
                    "UPDATE REL_DEB " & _
                    "SET VVCDINSCHAKELEN = {1} " & _
                    "WHERE CDDEBITEUR = {0} " _
                    , sql.String(cddebiteur) _
                    , sql.String(cdCode)), dbMultivers)
                schrijfInschakelcode = odbcCommand.ExecuteNonQuery()

            Catch ex As Exception
                'Laat weten dat de actie mislukt is
                Throw New Exception(ex.Message)
                schrijfInschakelcode = 0
            End Try
        Else
            schrijfInschakelcode = 0
        End If
        closeconnection
    end function

    <WebMethod(Description:="Wijzig de uitschakelcode")> _
    Public Function schrijfUitschakelCode  _
     (ByVal cdDebiteur As String _
     , byval cdCode as string ) As String

        IF CONNECT then
            Try
                'Maak van verwijderd niet-verwijderd en andersom
                Dim odbcCommand As odbc.OdbcCommand = New Odbc.OdbcCommand(String.Format( _
                    "UPDATE REL_DEB " & _
                    "SET VVCDUITSCHAKELEN = {1} " & _
                    "WHERE CDDEBITEUR = {0} " _
                    , sql.String(cddebiteur) _
                    , sql.String(cdCode)), dbMultivers)
                schrijfUitschakelcode = odbcCommand.ExecuteNonQuery()

            Catch ex As Exception
                'Laat weten dat de actie mislukt is
                Throw New Exception(ex.Message)
                schrijfUitschakelcode = 0
            End Try
        Else
            schrijfUitschakelcode = 0
        End If
        closeconnection
    end function

    <WebMethod(Description:="Wijzig de resetcode")> _
    Public Function schrijfResetCode  _
     (ByVal cdDebiteur As String _
     , byval cdCode as string ) As String

        IF CONNECT then
            Try
                'Maak van verwijderd niet-verwijderd en andersom
                Dim odbcCommand As odbc.OdbcCommand = New Odbc.OdbcCommand(String.Format( _
                    "UPDATE REL_DEB " & _
                    "SET VVCDRESET = {1} " & _
                    "WHERE CDDEBITEUR = {0} " _
                    , sql.String(cddebiteur) _
                    , sql.String(cdCode)), dbMultivers)
                schrijfResetcode = odbcCommand.ExecuteNonQuery()

            Catch ex As Exception
                'Laat weten dat de actie mislukt is
                Throw New Exception(ex.Message)
                schrijfResetcode = 0
            End Try
        Else
            schrijfResetcode = 0
        End If
        closeconnection
    end function

    Private Function Connect() As Boolean

        Try
            'Open de verbinding met Unit 4 Multivers
            dbMultivers = New Odbc.OdbcConnection
            dbMultivers.ConnectionString = String.Format("DSN=Unit 4 Multivers;DB={0};UID=SYSADM;PWD=U4", System.Configuration.ConfigurationManager.AppSettings.Get("Administratie") & "")
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

    Function Adres(ByVal cdadres As String) As String

        If cdadres.Substring(0, 1).ToUpper = "F" Then
            Adres = sql.String("Factuuradres")
        Else
            Adres = sql.String("Risicoadres")
        End If
    End Function
End Class

Module sql

    Function [String](ByVal tekst As String) As String
        If tekst = "" Then
            [String] = "NULL"
        Else
            [String] = "'" & Replace(tekst, "'", "''") & "'"
        End If
    End Function

    Function [Number](ByVal nummer As Double, Optional ByVal dec As Short = 2) As String
        If Trim(nummer & "") = "" Then
            [Number] = "NULL"
        Else
            If dec > 0 Then
                [Number] = Format(nummer, "0." & "".PadRight(dec, "0")).Replace(",", ".")

            Else
                [Number] = Format(nummer, "0")
            End If
        End If
    End Function

    Function [Date](ByVal datum As Object, Optional ByVal fmt As String = "yyyy-MM-dd") As String
        If Trim(datum & "") = "" Then
            [Date] = "NULL"
        Else
            [Date] = "'" & format(datum, fmt) & "' "
        End If
    End Function

    Function [Time](ByVal tijd As Object, Optional ByVal fmt As String = "HH:mm") As String
        If Trim(tijd & "") = "" Then
            [Time] = "NULL"
        Else
            [Time] = "'" & Format(tijd, fmt) & "'"
        End If
    End Function

    Function [JaNee](ByVal Bitwaarde As Boolean) As String
        If Bitwaarde Then
            JaNee = "'J'"
        Else
            JaNee = "'N'"
        End If
    End Function
End Module