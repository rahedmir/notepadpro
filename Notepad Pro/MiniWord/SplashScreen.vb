Public NotInheritable Class SplashScreen

    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles Me.Load
        If My.Application.Info.Title <> "" Then
            ApplicationTitle.Text = "Notepad Pro"
        Else
            'If the application title is missing, use the application name, without the extension
            ApplicationTitle.Text = "Notepad Pro"
        End If
    End Sub
End Class
