#Region "REVISION HISTORY"
'==========================================================================================================================================
' Wanneer   Versie  Wie Wat
'------------------------------------------------------------------------------------------------------------------------------------------
' 21-11-10  1.0.0   kv  Initiële versie
'==========================================================================================================================================
#End Region
Imports System
Imports System.Windows.Forms

Public Class frmProgress

    Dim _isAfgebroken As Boolean

    Public Overloads Sub show()
        _isAfgebroken = False
        MyBase.Show()
    End Sub

    Public Property Value() As ULong
        Get
            Value = pbarAlgemeen.Value
        End Get
        Set(ByVal value As ULong)
            pbarAlgemeen.Value = Math.Min(pbarAlgemeen.Maximum, value)
            pboxUpdate.Focus()
            Application.DoEvents()
        End Set
    End Property

    Public Property Max() As ULong
        Get
            Max = pbarAlgemeen.Maximum
        End Get
        Set(ByVal value As ULong)
            pbarAlgemeen.Maximum = value
            pboxUpdate.Focus()
            Application.DoEvents()
        End Set
    End Property

    Public Property Info() As String
        Get
            Info = txtInfoBox.Text
        End Get
        Set(ByVal value As String)
            If (txtInfoBox.Text <> value) Then
                txtInfoBox.Text = value
                pboxUpdate.Focus()
            End If
            Application.DoEvents()
        End Set
    End Property

    Public ReadOnly Property isAfgebroken
        Get
            isAfgebroken = _isAfgebroken
        End Get
    End Property

    Private Sub btnAnnuleer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnnuleer.Click
        _isAfgebroken = True
    End Sub
End Class