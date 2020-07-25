Imports System
Imports System.IO
Imports System.Text

Public Class Form1

    Private currAccount As Account
    Private ReadOnly FILEPATH As String = "..\..\accounts.dat"
    Dim history As New ArrayList()
    Private transaction As TransactionLog

    Private Sub btnFind_Click() Handles btnFind.Click
        ' The user has clicked the Find button, to find
        ' an account.
        currAccount = New Account(txtAccountNum.Text)
        currAccount.FilePath = FILEPATH

        If currAccount.GetData() Then
            lblAccountName.Text = currAccount.AccountName
            lblBalance.Text = currAccount.Balance.ToString("c")
            btnDeposit.Enabled = True
            btnWithdraw.Enabled = True
        Else
            MessageBox.Show(currAccount.LastError, "Error")
            Clear()
        End If
    End Sub

    Private Sub Clear()
        lblAccountName.Text = String.Empty
        lblBalance.Text = String.Empty
        btnDeposit.Enabled = False
        btnWithdraw.Enabled = False
    End Sub


    Private Sub btnDeposit_Click() Handles btnDeposit.Click
        ' The user has clicked the Deposit button
        Try
            currAccount.Deposit(CDec(txtAmount.Text))
            lblBalance.Text = currAccount.Balance.ToString("c")
            Dim depositLog As TransactionLog = New TransactionLog(CStr(txtAccountNum.Text), DateTime.Now, Math.Round(CDec(txtAmount.Text), 2), Math.Round(currAccount.Balance, 2))
            history.Add(depositLog)
        Catch e As System.InvalidCastException
            MessageBox.Show("Please enter a numeric deposit amount", "Error")

        Catch e As System.ArgumentException
            MessageBox.Show(“Deposit must be a positive value.”, "Error")
        End Try
    End Sub

    Private Sub btnWithdraw_Click() Handles btnWithdraw.Click
        ' The user has clicked the Withdraw button
        Try
            If currAccount.Withdraw(CDec(txtAmount.Text)) Then
                lblBalance.Text = currAccount.Balance.ToString("c")
                Dim withdrawLog As TransactionLog = New TransactionLog(CStr(txtAccountNum.Text), DateTime.Now, Decimal.Negate(CDec(txtAmount.Text)), Math.Round(currAccount.Balance, 2))
                history.Add(withdrawLog)
            Else
                MessageBox.Show(currAccount.LastError, "Error")
            End If
        Catch e As System.InvalidCastException
            MessageBox.Show("Please enter a numeric withdrawal amount", "Error")

        Catch e As System.ArgumentOutOfRangeException
            MessageBox.Show(“Insufficient funds for withdrawal.”, "Error")

        Catch e As System.ArgumentException
            MessageBox.Show(“Withdrawal must be a positive value.”, "Error")
        End Try
    End Sub

    Private Sub btnClose_Click() Handles btnClose.Click
        ' The user has clicked the Close button
        Me.Close()
    End Sub

    Private Sub Button_History_Click(sender As Object, e As EventArgs) Handles Button_History.Click
        MessageBox.Show("Total deposits = " + (currAccount.deposits).ToString("C") + ", Total withdrawals = " + (currAccount.withdrawals).ToString("C"), "History")
    End Sub

    Private Sub Button_Log_Click(sender As Object, e As EventArgs) Handles Button_Log.Click
        Dim outputfile As New System.IO.StreamWriter("transactionlog.txt")

        For Each i As TransactionLog In history
            LogForm.listLog.Items.Add(i.ToString())
            outputfile.WriteLine(i.ToString())
        Next
        outputfile.Close()
        LogForm.Show()
    End Sub
End Class
