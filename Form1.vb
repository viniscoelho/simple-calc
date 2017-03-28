Public Class Form1
    Private isFirstNum As Boolean
    Private numDec1 As Decimal
    Private numDec2 As Decimal
    Private operatorType As String

    Private Sub Button0_Click() Handles Button0.Click
        RemoveLeadingZero(0)
        DisableButtons()
    End Sub

    Private Sub Button1_Click() Handles Button1.Click
        RemoveLeadingZero(1)
        DisableButtons()
    End Sub

    Private Sub Button2_Click() Handles Button2.Click
        RemoveLeadingZero(2)
        DisableButtons()
    End Sub

    Private Sub Button3_Click() Handles Button3.Click
        RemoveLeadingZero(3)
        DisableButtons()
    End Sub

    Private Sub Button4_Click() Handles Button4.Click
        RemoveLeadingZero(4)
        DisableButtons()
    End Sub

    Private Sub Button5_Click() Handles Button5.Click
        RemoveLeadingZero(5)
        DisableButtons()
    End Sub

    Private Sub Button6_Click() Handles Button6.Click
        RemoveLeadingZero(6)
        DisableButtons()
    End Sub

    Private Sub Button7_Click() Handles Button7.Click
        RemoveLeadingZero(7)
        DisableButtons()
    End Sub

    Private Sub Button8_Click() Handles Button8.Click
        RemoveLeadingZero(8)
        DisableButtons()
    End Sub

    Private Sub Button9_Click() Handles Button9.Click
        RemoveLeadingZero(9)
        DisableButtons()
    End Sub

    Private Sub DotButton_Click() Handles DotButton.Click
        If Not TextBox.Text.Contains(".") Then
            TextBox.Text &= "."
        End If
        DisableButtons()
    End Sub

    Private Sub ClearButton_Click() Handles ClearButton.Click
        TextBox.Text = 0
        DisableButtons()
    End Sub

    'When the program initializes, call this
    Private Sub SimpleCalc(sender As Object, e As EventArgs) Handles MyBase.Load
        isFirstNum = False
        Me.KeyPreview = True
    End Sub

    Public Sub RemoveLeadingZero(ByVal opt As Integer)
        CheckError()
        If TextBox.Text = 0 Then
            TextBox.Text = opt
        Else : TextBox.Text &= opt
        End If
    End Sub

    Private Sub PlusButton_Click() Handles PlusButton.Click
        CheckError()
        operatorType = "+"
        isFirstAvailable()
        DisableButtons()
    End Sub

    Private Sub MinusButton_Click() Handles MinusButton.Click
        CheckError()
        operatorType = "-"
        isFirstAvailable()
        DisableButtons()
    End Sub

    Private Sub MultButton_Click() Handles MultButton.Click
        CheckError()
        operatorType = "*"
        isFirstAvailable()
        DisableButtons()
    End Sub

    Private Sub DivButton_Click() Handles DivButton.Click
        CheckError()
        operatorType = "/"
        isFirstAvailable()
        DisableButtons()
    End Sub

    Private Sub EqualButton_Click() Handles EqualButton.Click
        CheckError()
        If isFirstNum And IsNumeric(TextBox.Text) Then
            numDec2 = CType(TextBox.Text, Decimal)
            Dim respBox As String = ""
            CalcResp(numDec1, numDec2, operatorType, respBox)
            TextBox.Text = respBox
        End If
    End Sub

    Private Sub CalcResp(ByVal num1 As Decimal,
                         ByVal num2 As Decimal,
                         ByVal operatorType As String,
                         ByRef respBox As String)

        Dim resp As Decimal

        If operatorType = "+" Then
            Try
                resp = num1 + num2
                respBox = resp.ToString()
            Catch ex As Exception
                respBox = "cannot computate"
            End Try
        End If

        If operatorType = "-" Then
            Try
                resp = num1 - num2
                respBox = resp.ToString()
            Catch ex As Exception
                respBox = "cannot computate"
            End Try
        End If

        If operatorType = "*" Then
            Try
                resp = num1 * num2
                respBox = resp.ToString()
            Catch ex As Exception
                respBox = "cannot computate"
            End Try
        End If

        If operatorType = "/" Then
            If (num2 = 0) Then
                respBox = "cannot divide by zero"
            Else
                Try
                    resp = num1 / num2
                    respBox = resp.ToString()
                Catch ex As Exception
                    respBox = "cannot computate"
                End Try
            End If
        End If
        'This way I can use operations again
        isFirstNum = False
    End Sub

    'Check if there is a number to add
    Public Sub isFirstAvailable()
        If isFirstNum = False Then
            numDec1 = CType(TextBox.Text, Decimal)
            isFirstNum = True
            TextBox.Text = "0"
        End If
    End Sub

    Private Sub NegButton_Click() Handles NegButton.Click
        If Not TextBox.Text.Contains("-") Then
            'Adds - at the beginning
            TextBox.Text = "-" & TextBox.Text
        Else
            'Removes - from the beginning
            TextBox.Text = TextBox.Text.Trim("-")
        End If
        DisableButtons()
    End Sub

    Private Sub DelButton_Click() Handles DelButton.Click
        If (TextBox.Text.Length - 1 > 0) Then
            TextBox.Text = TextBox.Text.Substring(0, TextBox.Text.Length - 1)
        Else
            TextBox.Text = "0"
        End If
        DisableButtons()
    End Sub

    Private Sub PressedKey(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        'For esc press
        If e.KeyCode = Keys.Escape Then
            ClearButton_Click()
        End If

        'For backscpace press
        If e.KeyCode = Keys.Back Then
            DelButton_Click()
        End If
    End Sub

    Public Sub DisableButtons()
        'To use the enter as the = button
        EqualButton.Focus()
    End Sub

    Public Sub CheckError()
        'For overflow and non-digit error checking
        If Not IsNumeric(TextBox.Text) Then
            TextBox.Text = 0
        End If
    End Sub
End Class
