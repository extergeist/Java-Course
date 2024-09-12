'Sequential Access and Files Programming Assignment
'Jordan Romano - CSIS 208 - Professor Dyer
'The purpose is to build familiarity with the design of applications that can retrieve and display file information and properly assort them'
Public Class frmAssignment5
    'this is my array
    Dim strYouth As String
    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        'this menu option closes the application
        Me.Close()
    End Sub
    Private Sub frmAssignment5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'this variable pulls text data from my file in bin/debug and displays it
        strYouth = "Youth.txt"
        lstDisplay.DataSource = IO.File.ReadAllLines(strYouth)
        lstDisplay.SelectedItem = Nothing
        'displays in textbox
        txtCount.Text = lstDisplay.Items.Count
    End Sub

    Private Sub mnuAscend_Click(sender As Object, e As EventArgs) Handles mnuAscend.Click
        'this query sorts my text data in ascending order
        Dim ascendquery = From Youth In IO.File.ReadAllLines(strYouth)
                          Order By Youth Ascending
                          Select Youth
        lstDisplay.DataSource = ascendquery.ToList()

    End Sub

    Private Sub mnuDescend_Click(sender As Object, e As EventArgs) Handles mnuDescend.Click
        'this query sorts my text data in descending order
        Dim descendquery = From Youth In IO.File.ReadAllLines(strYouth)
                           Order By Youth Descending
                           Select Youth
        lstDisplay.DataSource = descendquery.ToList()
    End Sub

    Private Sub mnuAdd_Click(sender As Object, e As EventArgs) Handles mnuAdd.Click
        'my add member command
        Dim newYouth As String = InputBox("Please enter a name")
        'error checking
        If newYouth = "" Then
            MessageBox.Show("You have not entered a name")
            Return
        End If
        'changes the list of names
        Dim sw As IO.StreamWriter
        sw = IO.File.AppendText(strYouth)
        sw.WriteLine(newYouth)
        sw.Close()
        'refreshes the list of names
        lstDisplay.DataSource = IO.File.ReadAllLines(strYouth)
        lstDisplay.SelectedItem = Nothing
        'displays new number in textbox
        txtCount.Text = lstDisplay.Items.Count
    End Sub

    Private Sub mnuDelete_Click(sender As Object, e As EventArgs) Handles mnuDelete.Click
        'my delete item command
        Dim deletename As String
        'error checking
        deletename = lstDisplay.SelectedItem
        If deletename = "" Then
            MessageBox.Show("You have not selected a name")
            Return
        End If
        Dim deletequery = From item In IO.File.ReadAllLines(strYouth)
                          Where item <> deletename
                          Select item
        IO.File.WriteAllLines(strYouth, deletequery)
        'refreshes the list of names
        lstDisplay.DataSource = IO.File.ReadAllLines(strYouth)
        lstDisplay.SelectedItem = Nothing
        'displays new number in textbox
        txtCount.Text = lstDisplay.Items.Count
    End Sub

    Private Sub mnuCreate_Click(sender As Object, e As EventArgs) Handles mnuCreate.Click
        Dim newfile = InputBox("Please enter the name of the file")
        'error check
        strYouth = newfile & ".txt"
        If newfile = "" Then
            MessageBox.Show("You have not entered a file name")
            Return
        End If
        'if file does not exist
        Dim sw As IO.StreamWriter = IO.File.CreateText(strYouth)
        sw.Close()
        'refreshes the list of names
        lstDisplay.DataSource = IO.File.ReadAllLines(strYouth)
        lstDisplay.SelectedItem = Nothing
        'displays new number in textbox
        txtCount.Text = lstDisplay.Items.Count
    End Sub
End Class
