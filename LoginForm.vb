Imports System.Web.UI.WebControls

Public Class LoginForm

    Public Property CurrentUser As User


    Private Sub LinkForgetPassword_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkForgetPassword.LinkClicked
        ForgetPasswordPanel.Visible = True
    End Sub



    Private Sub btn_Login_Click(sender As Object, e As EventArgs) Handles btn_Login.Click


        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text

        Dim matchedUser = RegistrationForm.RegisteredUsers.FirstOrDefault(Function(user) user.UserName = txtUsername.Text AndAlso user.UserPassword = txtPassword.Text)

        If matchedUser IsNot Nothing Then
            Me.CurrentUser = matchedUser

            MessageBox.Show("Login successful!")

            txtPassword.Clear()

        Else
            MessageBox.Show("Invalid username or password.")
            txtPassword.Clear()
        End If
    End Sub

    Private Sub btn_Register_Click(sender As Object, e As EventArgs) Handles btn_Register.Click
        Dim registrationForm As New RegistrationForm()
        registrationForm.ShowDialog()
        Me.Close()

    End Sub

    Private Sub btn_RecoverPassword_Click(sender As Object, e As EventArgs) Handles btn_RecoverPassword.Click
        Dim userEmail As String = txtRecoveryEmail.Text
        Dim securityAnswer1 As String = txtSecurityAnswer1.Text
        Dim securityAnswer2 As String = txtSecurityAnswer2.Text

        Dim matchedUser = RegistrationForm.RegisteredUsers.FirstOrDefault(Function(user) user.UserEmail = userEmail AndAlso user.SecurityAnswer1 = securityAnswer1 AndAlso user.SecurityAnswer2 = securityAnswer2)

        If matchedUser IsNot Nothing Then
            MessageBox.Show("Authentication successful!")

            Dim changePasswordForm As New ChangePasswordForm()
            changePasswordForm.CurrentUser = Me.CurrentUser

            AddHandler changePasswordForm.ChangePasswordSuccess, AddressOf ChangePasswordSuccessHandler

            Me.Close()
            changePasswordForm.ShowDialog()
            ForgetPasswordPanel.Visible = False

        Else
            MessageBox.Show("Invalid email or security answers.")
        End If
    End Sub

    Private Sub ChangePasswordSuccessHandler(sender As Object, e As EventArgs)
        ForgetPasswordPanel.Visible = False
        Dim LoginForm As New LoginForm()
        LoginForm.Show()
    End Sub

    Private Sub btn_ReturnToLogin_Click(sender As Object, e As EventArgs) Handles btn_ReturnToLogin.Click
        ForgetPasswordPanel.Visible = False
    End Sub

    Private Sub pic_closeloginform_Click(sender As Object, e As EventArgs) Handles pic_closeloginform.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close the form?", "Confirmation", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            Me.Close()
            Application.Exit()
        Else

        End If
    End Sub


End Class