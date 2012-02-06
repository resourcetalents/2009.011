Imports Microsoft.VisualBasic

Module Sql

    Public Function [String](ByVal data) As String
        If IsDBNull(data) Then
            [String] = "NULL"
        Else
            [String] = String.Format("'{0}'", Replace(data.ToString, "'", "''"))
        End If
    End Function

    Public Function Number(ByVal data As Double, Optional ByVal dec As Integer = 2) As String

        Dim fmt As String = "###0"

        If IsDBNull(data) Then
            Number = "NULL"
        Else
            If dec > 0 Then fmt = fmt & ".".PadRight(dec + 1, "0")
            Number = Replace(Format(data, fmt), ",", ".")
        End If
    End Function

    Public Function [Date](ByVal data) As String
        If IsDBNull(data) Then
            [Date] = "NULL"
        Else
            [Date] = String.Format("'{0}'", Format(data, "yyyy-MM-dd"))
        End If
    End Function

    Public Function JaNee(ByVal data As Boolean) As String
        If (Not IsDBNull(data)) AndAlso (data) Then
            JaNee = "TRUE"
        Else
            JaNee = "FALSE"
        End If
    End Function
End Module

Module VBA

    Public Function Left(ByVal text As String, ByVal length As String) As String
        Left = Microsoft.VisualBasic.Left(text, length)
    End Function

    Public Function Right(ByVal text As String, ByVal length As String) As String
        Right = Microsoft.VisualBasic.Right(text, length)
    End Function
End Module

Module ubcPlus


End Module