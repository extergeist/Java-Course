'General Procedures and Repetition assignment
'Jordan Romano - CSIS 208 - Professor Dyer
'The purpose is to build familiarity with combo boxes, functions, subs, listboxes and reinforce what was used over the previous weeks'
Public Class frmAssignment3
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMissions.SelectedIndexChanged
        'this is my combo box
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        'this button closes the form
        Me.Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'this button clears the form
        cboMissions.SelectedIndex = -1
        txtHours.Text = ""
        txtPeople.Text = ""
        lstDisplay.Items.Clear()
    End Sub
    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        'Declare variables
        Dim intpeople As Integer
        Dim dblhours As Double
        Dim dbltotalhours As Double
        Dim dblremaining As Double
        Dim strMission As String
        'error checking
        If cboMissions.SelectedIndex = -1 Then
            MessageBox.Show("Please select a mission")
            Return
        End If
        If txtPeople.Text = "" Then
            MessageBox.Show("Please enter the number of people")
            txtPeople.Focus()
            Return
        End If
        If txtHours.Text = "" Then
            MessageBox.Show("Please enter the number of hours")
            txtHours.Focus()
            Return
        End If
        'define variables
        'converts to integers
        Integer.TryParse(txtPeople.Text, intpeople)
        strMission = cboMissions.SelectedItem
        dblhours = getTotalHours(strMission)
        'calculations
        'total hours is = to hours times number of people
        dbltotalhours = dblhours * intpeople
        dblremaining = "20" - dbltotalhours
        'display
        lstDisplay.Items.Clear()
        lstDisplay.Items.Add("The mission chosen is: " & strMission)
        lstDisplay.Items.Add("You need a total of 20 hours")
        lstDisplay.Items.Add("Total hours = " & (dbltotalhours))
        lstDisplay.Items.Add("Remaining hours: " & (dblremaining))
        getRemaining(dblremaining)
        lstDisplay.Items.Add("---------------------------------------------------------")
        'this is my loop
        For Missionaries As Integer = 1 To intpeople
            lstDisplay.Items.Add(InputBox("Please enter their names here"))
        Next
    End Sub
    Sub getRemaining(ByVal dblremaining As Double)
        'this is my sub'
        If dblremaining > 20 Then
            'tells the user that the mission hours have been met'
            lstDisplay.Items.Add("The maximum number of hours have been satisfied")
        End If
    End Sub
    Private Function getTotalHours(ByVal strmission As String) As Double
        'this is my function'
        Dim dblhours As Double
        Select Case strmission
            Case "Cooking"
                dblhours = 3.3
            Case "Supply Storage"
                dblhours = 2.5
            Case "Farm Duties"
                dblhours = 4.2
        End Select
        Return dblhours
    End Function
End Class
