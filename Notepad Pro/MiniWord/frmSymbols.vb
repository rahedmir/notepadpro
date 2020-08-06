Public Class frmSymbols


    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        txtSymbols.Text = txtSymbols.Text + btn1.Text
        txtSymbols.SelectionStart = txtSymbols.Text.Length
        txtSymbols.SelectionLength = 0
        txtSymbols.Refresh()
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        txtSymbols.Text = txtSymbols.Text + btn2.Text
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        txtSymbols.Text = txtSymbols.Text + btn3.Text
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        txtSymbols.Text = txtSymbols.Text + btn4.Text
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        txtSymbols.Text = txtSymbols.Text + btn5.Text
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        txtSymbols.Text = txtSymbols.Text + btn6.Text
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        txtSymbols.Text = txtSymbols.Text + btn7.Text
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        txtSymbols.Text = txtSymbols.Text + btn8.Text
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        txtSymbols.Text = txtSymbols.Text + btn9.Text
    End Sub

    Private Sub btn10_Click(sender As Object, e As EventArgs) Handles btn10.Click
        txtSymbols.Text = txtSymbols.Text + btn10.Text
    End Sub

    Private Sub btn11_Click(sender As Object, e As EventArgs) Handles btn11.Click
        txtSymbols.Text = txtSymbols.Text + btn11.Text
    End Sub

    Private Sub btn12_Click(sender As Object, e As EventArgs) Handles btn12.Click
        txtSymbols.Text = txtSymbols.Text + btn12.Text
    End Sub

    Private Sub btn13_Click(sender As Object, e As EventArgs) Handles btn13.Click
        txtSymbols.Text = txtSymbols.Text + btn13.Text
    End Sub

    Private Sub btn14_Click(sender As Object, e As EventArgs) Handles btn14.Click
        txtSymbols.Text = txtSymbols.Text + btn14.Text
    End Sub

    Private Sub btn15_Click(sender As Object, e As EventArgs) Handles btn15.Click
        txtSymbols.Text = txtSymbols.Text + btn15.Text
    End Sub

    Private Sub btn16_Click(sender As Object, e As EventArgs) Handles btn16.Click
        txtSymbols.Text = txtSymbols.Text + btn16.Text
    End Sub

    Private Sub btn17_Click(sender As Object, e As EventArgs) Handles btn17.Click
        txtSymbols.Text = txtSymbols.Text + btn17.Text
    End Sub

    Private Sub btn18_Click(sender As Object, e As EventArgs) Handles btn18.Click
        txtSymbols.Text = txtSymbols.Text + btn18.Text
    End Sub

    Private Sub btn19_Click(sender As Object, e As EventArgs) Handles btn19.Click
        txtSymbols.Text = txtSymbols.Text + btn19.Text
    End Sub

    Private Sub btn20_Click(sender As Object, e As EventArgs) Handles btn20.Click
        txtSymbols.Text = txtSymbols.Text + btn20.Text
    End Sub

    Private Sub btn21_Click(sender As Object, e As EventArgs) Handles btn21.Click
        txtSymbols.Text = txtSymbols.Text + btn21.Text
    End Sub

    Private Sub btn22_Click(sender As Object, e As EventArgs) Handles btn22.Click
        txtSymbols.Text = txtSymbols.Text + btn22.Text
    End Sub

    Private Sub btn23_Click(sender As Object, e As EventArgs) Handles btn23.Click
        txtSymbols.Text = txtSymbols.Text + btn23.Text
    End Sub

    Private Sub btn24_Click(sender As Object, e As EventArgs) Handles btn24.Click
        txtSymbols.Text = txtSymbols.Text + btn24.Text
    End Sub

    Private Sub btn25_Click(sender As Object, e As EventArgs) Handles btn25.Click
        txtSymbols.Text = txtSymbols.Text + btn25.Text
    End Sub

    Private Sub btn26_Click(sender As Object, e As EventArgs) Handles btn26.Click
        txtSymbols.Text = txtSymbols.Text + btn26.Text
    End Sub

    Private Sub btn27_Click(sender As Object, e As EventArgs) Handles btn27.Click
        txtSymbols.Text = txtSymbols.Text + btn27.Text
    End Sub

    Private Sub btn28_Click(sender As Object, e As EventArgs) Handles btn28.Click
        txtSymbols.Text = txtSymbols.Text + btn28.Text
    End Sub

    Private Sub btn29_Click(sender As Object, e As EventArgs) Handles btn29.Click
        txtSymbols.Text = txtSymbols.Text + btn29.Text
    End Sub

    Private Sub btn30_Click(sender As Object, e As EventArgs) Handles btn30.Click
        txtSymbols.Text = txtSymbols.Text + btn30.Text
    End Sub

    Private Sub btn31_Click(sender As Object, e As EventArgs) Handles btn31.Click
        txtSymbols.Text = txtSymbols.Text + btn31.Text
    End Sub

    Private Sub btn32_Click(sender As Object, e As EventArgs) Handles btn32.Click
        txtSymbols.Text = txtSymbols.Text + btn32.Text
    End Sub

    Private Sub btn33_Click(sender As Object, e As EventArgs) Handles btn33.Click
        txtSymbols.Text = txtSymbols.Text + btn33.Text
    End Sub

    Private Sub btn34_Click(sender As Object, e As EventArgs) Handles btn34.Click
        txtSymbols.Text = txtSymbols.Text + btn34.Text
    End Sub

    Private Sub btn35_Click(sender As Object, e As EventArgs) Handles btn35.Click
        txtSymbols.Text = txtSymbols.Text + btn35.Text
    End Sub

    Private Sub btn36_Click(sender As Object, e As EventArgs) Handles btn36.Click
        txtSymbols.Text = txtSymbols.Text + btn36.Text
    End Sub

    Private Sub btn37_Click(sender As Object, e As EventArgs) Handles btn37.Click
        txtSymbols.Text = txtSymbols.Text + btn37.Text
    End Sub

    Private Sub btn38_Click(sender As Object, e As EventArgs) Handles btn38.Click
        txtSymbols.Text = txtSymbols.Text + btn38.Text
    End Sub

    Private Sub btn39_Click(sender As Object, e As EventArgs) Handles btn39.Click
        txtSymbols.Text = txtSymbols.Text + btn39.Text
    End Sub

    Private Sub btn40_Click(sender As Object, e As EventArgs) Handles btn40.Click
        txtSymbols.Text = txtSymbols.Text + btn40.Text
    End Sub

    Private Sub txtSymbols_TextChanged(sender As Object, e As EventArgs) Handles txtSymbols.TextChanged
        If Len(txtSymbols.Text) > 25 Then

            txtSymbols.Text = txtSymbols.Text.Substring(0, txtSymbols.Text.Length - 1)


            MsgBox(" Please insert only 25 character", MsgBoxStyle.Information, "Insert")
        End If

    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        frmmain.AdvRichTextBox1.SelectedText = frmmain.AdvRichTextBox1.SelectedText + txtSymbols.Text
        frmmain.AdvRichTextBox1.SelectionStart = frmmain.AdvRichTextBox1.Text.Length
        frmmain.AdvRichTextBox1.SelectionLength = 0
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If txtSymbols.Text > "" Then

            txtSymbols.Text = txtSymbols.Text.Substring(0, txtSymbols.Text.Length - 1)



        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class