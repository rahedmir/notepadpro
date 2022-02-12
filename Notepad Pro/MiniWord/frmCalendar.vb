Public Class frmCalendar



    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Try
            frmmain.AdvRichTextBox1.SelectedText = frmmain.AdvRichTextBox1.SelectedText + " " + MonthCalendar1.SelectionRange.Start.ToShortDateString()
            frmmain.AdvRichTextBox1.SelectionStart = frmmain.AdvRichTextBox1.Text.Length
            frmmain.AdvRichTextBox1.SelectionLength = 0
            Me.Close()
        Catch ex As Exception
            MsgBox(" Can't display calendar", MsgBoxStyle.Critical, "Calendar")
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

   
    
End Class