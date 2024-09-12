'Classes and Objects Programming Assignment
'Jordan Romano - CSIS 208 - Professor Dyer
'The purpose is to build familiarity with building a class and the aspects that make Visual Basic an object oriented language'
Public Class frmAssignment6
    'calls on class
    Dim scalc As New IncomeCalc
    Private Sub frmAssignment6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'display user input box
        'error checking for starting inputbox
        Dim value As String
        While value = ""
            value = InputBox("Please enter the starting amount for your account")
        End While
        Dim dblamount As Double = InputBox("Please confirm the starting amount for your account")
        Double.TryParse(value, dblamount)

        'variable
        scalc.Income(dblamount)
        'display
        lstIncome.Items.Add("Current month income")
        lstIncome.Items.Add("---------------------------------------------------------")
        lstExpense.Items.Add("Current month expenses")
        lstExpense.Items.Add("---------------------------------------------------------")
        lstIncome.Items.Add("Starting balance - " & FormatCurrency(scalc.totalcost()))
        'displays in textbox
        txtIncome.Text = FormatCurrency(scalc.totalcost())

    End Sub

    Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmount.KeyPress
        'error checking for txtAmount box
        ' Accept only numbers, decimal points, currency sign and the backspace key.
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> "." AndAlso e.KeyChar <> "$" AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnIncome_Click(sender As Object, e As EventArgs) Handles btnIncome.Click
        'calculates and displays results in textbox and lstincome
        Dim intotheramount As String = txtAmount.Text
        Dim strincome As String = InputBox("Please name the type of income")
        'error checking
        'if they don't enter an amount for income
        If txtAmount.Text = "" Then
            MessageBox.Show("Please enter the income")
            txtAmount.Focus()
            Return
        End If
        'if the user doesn't enter a name for the income this loops until they do
        While strincome = ""
            strincome = InputBox("Please name the type of income")
        End While
        String.Format(strincome)
        'refreshes textbox for each new input
        txtAmount.Clear()
        'calling the class
        scalc.Income(intotheramount)
        lstIncome.Items.Add(strincome & " - " & FormatCurrency(intotheramount))
        txtIncome.Text = FormatCurrency(scalc.totalcost())

    End Sub

    Private Sub btnExpense_Click(sender As Object, e As EventArgs) Handles btnExpense.Click
        'calculates and displays results in textbox and lstexpense
        'variables
        Dim intexpenseamount As String = txtAmount.Text
        Dim strexpense As String = InputBox("Please name the expense")
        'error checking
        'if they don't enter an amount for the expense
        If txtAmount.Text = "" Then
            MessageBox.Show("Please enter an expense")
            txtAmount.Focus()
            Return
        End If
        'if the user doesn't enter a name for the expense this loops until they do
        While strexpense = ""
            strexpense = InputBox("Please name the expense")
        End While
        String.Format(strexpense)
        'refreshes textbox for each new input
        txtAmount.Clear()
        'calling the class
        scalc.Expense(intexpenseamount)
        lstExpense.Items.Add(strexpense & " - " & FormatCurrency(intexpenseamount))
        txtIncome.Text = FormatCurrency(scalc.totalcost())
    End Sub
End Class
