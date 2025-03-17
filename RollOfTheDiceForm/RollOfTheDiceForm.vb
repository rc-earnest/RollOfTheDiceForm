'Rudy Earnest
'RCET 2265
'Spring 2025
'Roll of the Dice Form
'https://github.com/rc-earnest/RollOfTheDiceForm.git
Public Class RollOfTheDiceForm
    ''' <summary>
    ''' Adds tool tips and sets defaults on startup of the form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub RollOfTheDiceForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Roll of the Dice"
        ToolTip1.SetToolTip(RollButton, "Rolls 2 dice 1,000 times and displays how many times each number was rolled.")
        ToolTip1.SetToolTip(ClearButton, "Clears the Display of all numbers rolled.")
        ToolTip1.SetToolTip(ExitButton, "Exits the Program.")
        SetDefaults()
    End Sub
    ''' <summary>
    ''' Sets the defaults, made a sub so it can be called and isn't repetitive code.
    ''' </summary>
    Sub SetDefaults()
        RollButton.Focus()
        DisplayListBox.Items.Clear()
        DisplayListBox.Items.Add(StrDup(27, " ") & "Roll of the Dice")
    End Sub
    ''' <summary>
    ''' "Rolls" two dice and adds them together then displays the analytics in a list box once the roll button is clicked.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub RollButton_Click(sender As Object, e As EventArgs) Handles RollButton.Click
        Dim counts(10) As Integer
        Dim firstDie As Integer
        Dim secondDie As Integer
        Dim sum As Integer
        Dim header As String
        Dim data As String
        For i = 0 To 999
            firstDie = RandomNumberBetween(1, 6)
            secondDie = RandomNumberBetween(1, 6)
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
    ''' <summary>
    ''' Returns to the defaults when the clear button is clicked.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        SetDefaults()
    End Sub
    ''' <summary>
    ''' Closes the program once the exit button is clicked.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' Returns a random number from your min to your max.
    ''' </summary>
    ''' <param name="min"></param> minimum prefered digit
    ''' <param name="max"></param> maximum prefered digit
    ''' <returns></returns>
    Function RandomNumberBetween(min As Integer, max As Integer) As Integer
        Randomize()
        Dim randomNumber As Single
        randomNumber = Rnd()
        randomNumber *= max - min + 1
        randomNumber += min - 1
        Return CInt(Math.Ceiling(randomNumber))
    End Function
End Class
