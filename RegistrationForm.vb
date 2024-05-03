Public Class RegistrationForm

    Public Shared RegisteredUsers As New List(Of User)
    Public Property UserEmail As String
    Public Property UserName As String
    Public Property UserPassword As String
    Public Property SecurityAnswer1 As String
    Public Property SecurityAnswer2 As String

    Private Sub RegistrationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_Register_Click(sender As Object, e As EventArgs) Handles btn_Register.Click
        If String.IsNullOrWhiteSpace(txtEmail.Text) OrElse
                Not txtEmail.Text.Contains("@") Then
            MessageBox.Show("Please enter a valid email address.")
            Return
        End If

        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Please enter a userame.")
            Return
        End If

        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Please enter a password.")
            Return
        End If

        If String.IsNullOrWhiteSpace(txtSecurityAnswer1.Text) Then
            MessageBox.Show("Please enter an answer for security question 1.")
            Return
        End If

        If String.IsNullOrWhiteSpace(txtSecurityAnswer2.Text) Then
            MessageBox.Show("Please enter an answer for security question 2.")
            Return
        End If
        UserEmail = txtEmail.Text
        UserName = txtUsername.Text
        UserPassword = txtPassword.Text
        SecurityAnswer1 = txtSecurityAnswer1.Text
        SecurityAnswer2 = txtSecurityAnswer2.Text

        Dim newUser As New User()
        newUser.UserEmail = txtEmail.Text
        newUser.UserName = txtUsername.Text
        newUser.UserPassword = txtPassword.Text
        newUser.SecurityAnswer1 = txtSecurityAnswer1.Text
        newUser.SecurityAnswer2 = txtSecurityAnswer2.Text

        RegistrationForm.RegisteredUsers.Add(newUser)

        pnlRegistrationSuccess.Visible = True

    End Sub

    Private Sub btnGoBackToRegistration_Click_1(sender As Object, e As EventArgs) Handles btnGoBackToRegistration.Click
        pnlRegistrationSuccess.Visible = False

        Me.Show()
    End Sub

    Private Sub btnProceedToLogin_Click_1(sender As Object, e As EventArgs) Handles btnProceedToLogin.Click

        Me.Hide()
        Dim loginForm As New LoginForm()
        loginForm.txtUsername.Clear()

        loginForm.Show()


    End Sub

    Private Sub btnGoToLogin_Click(sender As Object, e As EventArgs) Handles btnGoToLogin.Click
        Dim loginForm As New LoginForm()
        loginForm.txtUsername.Clear()
        loginForm.Show()
        Me.Hide()
    End Sub

    Private Sub pic_close_Click(sender As Object, e As EventArgs) Handles pic_close.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close the form?", "Confirmation", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            Me.Close()
            Application.Exit()
        Else

        End If
    End Sub
End Class