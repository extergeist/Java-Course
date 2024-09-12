'String Manipulation and Arrays assignment
'Jordan Romano - CSIS 208 - Professor Dyer
'The purpose is to build familiarity with 1 dimensional arrays and reinforce concepts learned over the past few weeks'
Public Class FrmAssignment4

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        'this button closes the form
        Me.Close()
    End Sub

    Private Sub lstMissions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMissions.SelectedIndexChanged
        'Fills the listbox with values and starts on the first value'

    End Sub

    Private Sub txtHoursDonated_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHoursDonated.KeyPress
        ' Accept only numbers and the backspace key.
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> "-" AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub FrmAssignment4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'this is my form
        lstTotals.Items.Add("Hour recording for 04/13/2022")
        lstTotals.Items.Add("Hours recorded by Jordan Romano")
        lstTotals.Items.Add("--------------------------------------------------------------")
        lstMissions.Items.Add("Farming")
        lstMissions.Items.Add("Organizing")
        lstMissions.Items.Add("Teaching")
        lstMissions.Items.Add("Cooking")
        lstMissions.SelectedIndex = 0
    End Sub

    Private Sub btnAddHours_Click(sender As Object, e As EventArgs) Handles btnAddHours.Click
        'this is my button
        'this is my 1 dimensional array
        Dim intHoursDonated As Integer
        Dim strMission As String
        Static inttotals(3) As Integer
        'this is what retrieves the user's last name - i did not know how to put this into a function after multiple attempts or
        'how to even make it seperate the names. I attempted the Rearrange Names example.
        ' Dim strName As String
        'Dim strLastName As String
        'Dim intIndex As Integer '

        'searches for comma in name
        'intIndex = strName.IndexOf(" ")'

        'error checking
        strMission = lstMissions.SelectedItem
        Integer.TryParse(txtHoursDonated.Text, intHoursDonated)
        inttotals(lstMissions.SelectedIndex) = inttotals(lstMissions.SelectedIndex) + intHoursDonated
        'Display
        lblMission1.Text = inttotals(0).ToString
        lblMission2.Text = inttotals(1).ToString
        lblMission3.Text = inttotals(2).ToString
        lblMission4.Text = inttotals(3).ToString
        'error messages
        If txtHoursDonated.Text = "" Then
            MessageBox.Show("Please enter the number of hours")
            txtHoursDonated.Focus()
            Return
        End If
        If lstMissions.SelectedIndex = -1 Then
            MessageBox.Show("Please select a mission")
            txtHoursDonated.Focus()
            Return
        End If
        lstTotals.Items.Add(InputBox("Please enter names here"))
        'name display and hours
        lstTotals.Items.Add("served " & intHoursDonated & " hours.")
    End Sub
    Private Sub ClearOutput(sender As Object, e As EventArgs) Handles txtHoursDonated.TextChanged, lstMissions.SelectedIndexChanged
        'clears the form for each user inputting hours'
        lblMission1.Text = String.Empty
        lblMission2.Text = String.Empty
        lblMission3.Text = String.Empty
        lblMission4.Text = String.Empty
    End Sub
End Class