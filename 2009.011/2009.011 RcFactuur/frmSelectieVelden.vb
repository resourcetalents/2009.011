Public Class frmSelectieVelden

    Private Sub btnUp_Click() Handles btnUp.Click

        Dim index As Integer
        Dim item As String
        Dim chck As Boolean

        If Me.lstVelden.SelectedIndex > 0 Then
            index = Me.lstVelden.SelectedIndex
            item = Me.lstVelden.SelectedItem
            chck = Me.lstVelden.GetItemChecked(Me.lstVelden.SelectedIndex)

            Me.lstVelden.Items(index) = Me.lstVelden.Items(index - 1)
            Me.lstVelden.SetItemChecked(index, Me.lstVelden.GetItemChecked(index - 1))

            Me.lstVelden.Items(index - 1) = item
            Me.lstVelden.SetItemChecked(index - 1, chck)
            Me.lstVelden.SelectedIndex -= 1
        End If
    End Sub

    Private Sub btnDn_Click() Handles btnDn.Click

        Dim index As Integer
        Dim item As String
        Dim chck As Boolean

        If Me.lstVelden.SelectedIndex < Me.lstVelden.Items.Count - 1 Then
            index = Me.lstVelden.SelectedIndex
            item = Me.lstVelden.SelectedItem
            chck = Me.lstVelden.GetItemChecked(Me.lstVelden.SelectedIndex)

            Me.lstVelden.Items(index) = Me.lstVelden.Items(index + 1)
            Me.lstVelden.SetItemChecked(index, Me.lstVelden.GetItemChecked(index + 1))

            Me.lstVelden.Items(index + 1) = item
            Me.lstVelden.SetItemChecked(index + 1, chck)
            Me.lstVelden.SelectedIndex += 1
        End If
    End Sub
End Class