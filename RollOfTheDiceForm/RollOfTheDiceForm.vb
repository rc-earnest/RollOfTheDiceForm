'Rudy Earnest
'RCET 2265
'Spring 2025
'Roll of the Dice Form
'git link
Public Class RollOfTheDiceForm
    Private Sub RollOfTheDiceForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Roll of the Dice"
        ToolTip1.SetToolTip(RollButton, "Rolls 2 dice 1,000 times and displays how many times each number was rolled.")
        ToolTip1.SetToolTip(ClearButton, "Clears the Display of all numbers rolled.")
        ToolTip1.SetToolTip(ExitButton, "Exits the Program.")
        SetDefaults()
    End Sub
    Sub SetDefaults()
        RollButton.Focus()
        DisplayListBox.Items.Clear()
        DisplayListBox.Items.Add("Roll of the Dice".PadLeft(10))
    End Sub

    Private Sub RollButton_Click(sender As Object, e As EventArgs) Handles RollButton.Click
        Dim counts(10) As Integer
        Dim firstDie As Integer
        Dim secondDie As Integer
        Dim sum As Integer
        Dim header As String
        Dim data As String
        For i = 0 To 999
            firstDie = randomNumberBetween(1, 6)
            secondDie = randomNumberBetween(1, 6)
            sum = firstDie + secondDie
            counts(sum - 2) += 1
        Next
        DisplayListBox.Items.Add(StrDup(68, "-"))
        For i = 2 To 12
            header += (CStr(i).PadLeft(5) & "|")
        Next
        DisplayListBox.Items.Add(header)
        For i = 0 To 10
            data += (CStr(counts(i)).PadLeft(5) & "|")
        Next
        DisplayListBox.Items.Add(data)
        DisplayListBox.Items.Add(StrDup(68, "-"))
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        SetDefaults()
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Function randomNumberBetween(min As Integer, max As Integer) As Integer
        Randomize()
        Dim randomNumber As Single
        randomNumber = Rnd()
        randomNumber *= max - min + 1
        randomNumber += min - 1
        Return CInt(Math.Ceiling(randomNumber))
    End Function
End Class
