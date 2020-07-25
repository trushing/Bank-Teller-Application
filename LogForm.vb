Public Class LogForm
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles Button_Close.Click
        listLog.Items.Clear()
        Me.Close()
    End Sub
End Class