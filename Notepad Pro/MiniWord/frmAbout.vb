Public Class frmAbout

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUserName.Text = Environment.UserName
        lblDeveloper.LinkColor = Color.DarkSlateBlue
    End Sub


    Private Sub lblDeveloper_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblDeveloper.LinkClicked
        Try
            Process.Start("https://rahedmir.github.io/")
        Catch ex As Exception
            MsgBox(" Url navigation is not possible", MsgBoxStyle.Critical, "Link")
        End Try
    End Sub
End Class