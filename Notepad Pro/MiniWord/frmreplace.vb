Public Class frmreplace


    Private Sub frmreplace_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnFind.Enabled = True
        btnFind_next.Enabled = True
        btnReplace.Enabled = False

    End Sub

    Private Sub txtfind_TextChanged(sender As Object, e As EventArgs) Handles txtfind.TextChanged
        If txtfind.Text <> "" Then
            btnFind.Enabled = True
            btnFind_next.Enabled = False
        Else
            btnFind.Enabled = False
            btnFind_next.Enabled = True
        End If
    End Sub

  

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        If txtfind.Text = "" Then
            MsgBox("Please enter search criteria", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Search")
        Else
            Try

                Dim StartPosition As Integer
                Dim SearchType As CompareMethod

                If match_case.Checked = True Then
                    SearchType = CompareMethod.Binary
                Else
                    SearchType = CompareMethod.Text
                End If

                StartPosition = InStr(1, frmmain.AdvRichTextBox1.Text, txtfind.Text, SearchType)

                If StartPosition = 0 Then
                    MessageBox.Show("String: " & txtfind.Text.ToString() & " not found", "No Matches", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

                    Exit Sub
                End If

                frmmain.AdvRichTextBox1.Select(StartPosition - 1, txtfind.Text.Length.ToString)


                frmmain.AdvRichTextBox1.ScrollToCaret()
                frmmain.Focus()
            Catch ex As Exception
                MessageBox.Show("String: " & txtfind.Text.ToString() & " not found", "No Matches", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
              
            End Try
            btnFind.Enabled = False
            btnFind_next.Enabled = True
            btnReplace.Enabled = True

        End If

    End Sub

    Private Sub btnFind_next_Click(sender As Object, e As EventArgs) Handles btnFind_next.Click
        If txtfind.Text = "" Then
            MsgBox("Please enter search criteria", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Search")
        Else

            Try
                Dim StartPosition As Integer = frmmain.AdvRichTextBox1.SelectionStart + 2
                Dim SearchType As CompareMethod

                If match_case.Checked = True Then
                    SearchType = CompareMethod.Binary
                Else
                    SearchType = CompareMethod.Text
                End If

                StartPosition = InStr(StartPosition, frmmain.AdvRichTextBox1.Text, txtfind.Text, SearchType)

                If StartPosition = 0 Then
                    Dim x As Integer = MessageBox.Show("String: " & txtfind.Text.ToString() & " not found", "No Matches", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    If x = vbOK Then
                        btnFind.Enabled = True
                        btnFind_next.Enabled = False
                    End If
                    Exit Sub
                End If

                frmmain.AdvRichTextBox1.Select(StartPosition - 1, txtfind.Text.Length)

                frmmain.AdvRichTextBox1.ScrollToCaret()
                frmmain.Focus()

            Catch ex As Exception
                Dim x As Integer = MessageBox.Show("String: " & txtfind.Text.ToString() & " not found", "No Matches", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                If x = vbOK Then
                    btnFind.Enabled = True
                End If
            End Try
        End If
    End Sub

    Private Sub btnReplace_Click(sender As Object, e As EventArgs) Handles btnReplace.Click
        If txtReplace.Text = "" Then
            MsgBox("Please enter replace criteria", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Replace")
        ElseIf txtfind.Text = "" Then
            MsgBox("Please enter search criteria", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Search")
        Else
            Try
                If frmmain.AdvRichTextBox1.SelectedText.Length <> 0 Then
                    frmmain.AdvRichTextBox1.SelectedText = txtReplace.Text
                End If

                Dim StartPosition As Integer = frmmain.AdvRichTextBox1.SelectionStart + 1

                Dim SearchType As CompareMethod

                If match_case.Checked = True Then
                    SearchType = CompareMethod.Binary
                Else
                    SearchType = CompareMethod.Text
                End If

                StartPosition = InStr(StartPosition, frmmain.AdvRichTextBox1.Text, txtfind.Text, SearchType)

                If StartPosition = 0 Then
                    Dim x As Integer = MessageBox.Show("String: '" & txtfind.Text.ToString() & "' have no matches", "No Matches", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    If x = vbOK Then
                        btnReplace.Enabled = False
                    End If
                    Exit Sub
                End If

                frmmain.AdvRichTextBox1.Select(StartPosition - 1, txtfind.Text.Length)

                frmmain.AdvRichTextBox1.ScrollToCaret()
                frmmain.Focus()
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub btnReplace_all_Click(sender As Object, e As EventArgs) Handles btnReplace_all.Click
        If txtReplace.Text = "" Then
            MsgBox("Please enter replace criteria", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Replace")
        ElseIf txtfind.Text = "" Then
            MsgBox("Please enter search criteria", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Search")
        ElseIf frmmain.AdvRichTextBox1.Text = Replace(Trim(frmmain.AdvRichTextBox1.Text), Trim(txtfind.Text), Trim(txtReplace.Text)) Then

            MsgBox("Nothing have to replace", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Replace")
        Else
            Try

                Dim currentPosition As Integer = frmmain.AdvRichTextBox1.SelectionStart
                Dim currentSelect As Integer = frmmain.AdvRichTextBox1.SelectionLength

                frmmain.AdvRichTextBox1.Text = Replace(Trim(frmmain.AdvRichTextBox1.Text), Trim(txtfind.Text), Trim(txtReplace.Text))

                frmmain.AdvRichTextBox1.SelectionStart = currentPosition
                frmmain.AdvRichTextBox1.SelectionLength = currentSelect
                frmmain.AdvRichTextBox1.ScrollToCaret()
                frmmain.Focus()

                MsgBox("Replace completed", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Replace")

            Catch ex As Exception
                MsgBox("Unable to replace", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Replace")
            End Try


        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        txtfind.Text = ""

        txtReplace.Text = ""

    End Sub

  
End Class