Public Class TransactionLog
    Public Property accNum As String
    Public Property amount As Decimal
    Public Property balance As Decimal
    Public Property timestamp As Date

    Public Overrides Function ToString() As String
        Return CStr(accNum & ", " & timestamp & ", " & amount & ", " & balance)
    End Function

    Public Sub New(ByVal id As String, ByVal time As Date, ByVal amt As Decimal, ByVal total As Decimal)
        accNum = id
        timestamp = time
        amount = amt
        balance = total
    End Sub
End Class
