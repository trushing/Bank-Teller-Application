Imports System.IO				  ' StreamReader class
Imports System.IO.File          ' OpenText method

Public Class Account
    Public Property deposits As Decimal
    Public Property withdrawals As Decimal

    Private mBalance As Decimal

    Public Property AccountId As String
    Public Property AccountName As String
    Public Property FilePath As String
    Public Property LastError As String

    Public ReadOnly Property Balance As Decimal
        Get
            Return mBalance
        End Get
    End Property

    Public Sub New(ByVal pAccountId As String)
        ' Create a new account, using an account ID
        AccountId = pAccountId
        AccountName = String.Empty
        mBalance = 0D
        deposits = 0
        withdrawals = 0
    End Sub

    ' Read the data file, try to find the account ID.
    ' If found, read the account name and balance and
    ' return True. If not found, return false.
    Public Function GetData() As Boolean
        Dim infile As StreamReader = Nothing
        LastError = String.Empty
        Try
            infile = OpenText(FilePath)
            While Not infile.EndOfStream
                Dim entireLine As String = infile.ReadLine()
                Dim fields() As String = entireLine.Split(","c)
                If fields(0) = AccountId Then
                    AccountName = fields(1)
                    mBalance = CDec(fields(2))
                    Return True
                End If
            End While
            LastError = "Account " & AccountId & " not found"
            Return False
        Catch ex As Exception
            LastError = ex.Message
            Return False
        Finally
            If infile IsNot Nothing Then infile.Close()
        End Try
        Return False
    End Function

    Public Sub Deposit(ByVal amount As Decimal)
        ' Deposit the amount in the account by adding it 
        ' to the balance.
        If amount >= 0 Then
            deposits += amount
            mBalance += amount
        Else
            Throw New ArgumentException(“Deposit must be a positive value.”, “Deposit must be a positive value.”)
        End If
    End Sub

    Public Function Withdraw(ByVal amount As Decimal) As Boolean
        ' Withdraw <amount> from the account if the existing balance 
        ' is at least as large as the amount, and return True. Otherwise,
        ' return false if balance is less than <amount>.

        If amount < 0 Then
            Throw New ArgumentException("Withdrawal must be a positive value.")
            Return False
        ElseIf amount <= mBalance Then
            mBalance -= amount
            withdrawals += amount
            Return True
        Else
            Throw New ArgumentOutOfRangeException(“Insufficient funds for withdrawal.”)
            Return False
        End If
    End Function
End Class
