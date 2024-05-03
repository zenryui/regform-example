Public Class ChangePasswordForm

    Public Property CurrentUser As User

    Public Event ChangePasswordSuccess As EventHandler

    Private Sub btnChangePassword_Click(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        If String.IsNullOrWhiteSpace(txtNewPassword.Text) OrElse String.IsNullOrWhiteSpace(txtConfirmPassword.Text) Then
            MessageBox.Show("Please enter a new password and confirm it.")
            Return
        End If

        If txtNewPassword.Text <> txtConfirmPassword.Text Then
            MessageBox.Show("New password and confirm password do not match.")
            Return
        End If

        If txtNewPassword.Text = CurrentUser.UserPassword Then
            MessageBox.Show("New password cannot be the same as the current password.")
            Return
        End If

        Dim success As Boolean = UpdateUserPassword(CurrentUser, txtNewPassword.Text)

        If success Then
            MessageBox.Show("Password changed successfully!")
            RaiseEvent ChangePasswordSuccess(Me, EventArgs.Empty)
            Me.Close()
        Else
            MessageBox.Show("Failed to change password. Please try again later.")
        End If
    End Sub

    Private Function UpdateUserPassword(user As User, newPassword As String) As Boolean
        user.UserPassword = newPassword
        Return True
    End Function

    Private Sub btnCancelChangePass_Click(sender As Object, e As EventArgs) Handles btnCancelChangePass.Click

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to return to the login form?", "Confirmation", MessageBoxButtons.OKCancel)

        If result = DialogResult.OK Then

            Dim loginForm As New LoginForm()
            loginForm.Show()
            Me.Close()

        Else

        End If
    End Sub

    Private Sub pic_close_Click(sender As Object, e As EventArgs) Handles pic_close.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to close the form?", "Confirmation", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            Me.Close()
            Application.Exit()
        Else

        End If
    End Sub


    Private Sub ShowChangePasswordForm()

        Dim changePasswordForm As New ChangePasswordForm()


        changePasswordForm.CurrentUser = Me.CurrentUser


        changePasswordForm.Show()
    End Sub

End Class