'Variables and Decisions programming assignment
'Jordan Romano - CSIS 208 - Professor Dyer
'The purpose is to utilize and build familiarity with variables, declarations, if statements, case statements and radio buttons.'
Public Class frmAssignment2
    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles radfarm.CheckedChanged
        'this is my radio button'
    End Sub

    Private Sub grpMission_Enter(sender As Object, e As EventArgs) Handles grpMission.Enter
        'this is my enter button'
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        radcooking.Checked = False
        radsupply.Checked = False
        radfarm.Checked = False
        'this button clears the form'
        txtnumofpeople.Text = ""
        txthours.Text = ""
        txtTotal.Text = ""
        txtRemaining.Text = ""
    End Sub

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        'Declare variables
        Dim intnumpeople As Integer
        Dim dblhours As Double
        Dim dbltotalhours As Double
        Dim dblremaining As Double

        'error checking
        If txtnumofpeople.Text = "" Then MessageBox.Show("Please enter the number of people")
        If txthours.Text = "" Then MessageBox.Show("Please enter the number of hours")
        txtnumofpeople.Focus()
        txthours.Focus()

        'define variables
        'converts to integers
        Integer.TryParse(txtnumofpeople.Text, intnumpeople)
        Integer.TryParse(txtRemaining.Text, dblremaining)
        Integer.TryParse(txthours.Text, dblhours)
        Select Case True
            Case radcooking.Checked
                dblhours = 2.3
            Case radfarm.Checked
                dblhours = 4.5
            Case radsupply.Checked
                dblhours = 2.2
            Case Else
                Return
        End Select

        'calculations
        'total hours is = to hours times number of people
        dbltotalhours = dblhours * intnumpeople
        dblremaining = "20" - dbltotalhours
        'display
        'displays total hours in total
        txtTotal.Text = dbltotalhours
        'displays remaining hours in remaining 
        txtRemaining.Text = dblremaining
        'the following warn the user of invalid entries
        If dblremaining <= 0 Then MessageBox.Show("Please enter a valid number of hours")
        If dbltotalhours >= 20 Then MessageBox.Show("The value exceeds the max amount of hours")
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        'this button closes the form
        Me.Close()
    End Sub
End Class
