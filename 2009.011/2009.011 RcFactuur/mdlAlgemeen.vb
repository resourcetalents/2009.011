Module mdlAlgemeen

    Friend odbcMultivers As Odbc.OdbcConnection
    Friend ubcMultivers As MBO.Administration

    Friend Function ConnectMultivers(ByVal administratie As String, ByVal gebruiker As String, ByVal wachtwoord As String) As Boolean

        Try
            'Maak verbinding via UBC
            ubcMultivers = New MBO.Administration
            ubcMultivers.Connect(administratie, gebruiker, wachtwoord)

            'Maak verbinding via ODBC
            odbcMultivers = New Odbc.OdbcConnection
            odbcMultivers.ConnectionString = String.Format( _
                "DSN=Unit 4 Multivers;DB={0};UID=SYSADM;PWD=U4" _
                , My.Settings.mvlAdministratie)
            odbcMultivers.Open()
            ConnectMultivers = (odbcMultivers.State = ConnectionState.Open)

        Catch ex As Exception
            MsgBox(ex.Message)
            ConnectMultivers = False
        End Try
    End Function
End Module
