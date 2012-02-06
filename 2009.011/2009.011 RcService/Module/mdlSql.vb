' [REV.HIST]---------------------------------------------------------------------------------------
'  Wanneer  Revisie Wie Wat 
' -------------------------------------------------------------------------------------------------
' 11-09-08  1.0.0.0 kv  Initiele versie
' 29-09-11  1.0.0.1 kv  Overgenomen uit RcService Webservice
' -------------------------------------------------------------------------------------------------

Module SQL
    Friend Function [String](ByVal tekst As String) As String
        If tekst = "" Then
            [String] = "NULL"
        Else
            [String] = "'" & Replace(tekst, "'", "''") & "'"
        End If
    End Function

    Friend Function [Number](ByVal nummer As Double, Optional ByVal dec As Short = 2) As String
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

    Friend Function [Date](ByVal datum As Object, Optional ByVal fmt As String = "yyyy-MM-dd") As String
        If Trim(datum & "") = "" Then
            [Date] = "NULL"
        Else
            [Date] = "'" & Format(datum, fmt) & "' "
        End If
    End Function

    Friend Function [Time](ByVal tijd As Object, Optional ByVal fmt As String = "HH:mm") As String
        If Trim(tijd & "") = "" Then
            [Time] = "NULL"
        Else
            [Time] = "'" & Format(tijd, fmt) & "'"
        End If
    End Function

    Friend Function [JaNee](ByVal Bitwaarde As Boolean) As String
        If Bitwaarde Then
            JaNee = "'J'"
        Else
            JaNee = "'N'"
        End If
    End Function
End Module
