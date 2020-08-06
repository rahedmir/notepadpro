Public Class frmfind

    

    Private Sub txtfind_TextChanged(sender As Object, e As EventArgs) Handles txtfind.TextChanged
        If txtfind.Text <> "" Then
            btnFind.Enabled = True
            btnFind_next.Enabled = False
        Else
            btnFind.Enabled = False
            btnFind_next.Enabled = True
        End If
    End Sub



    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        Try
            If txtfind.Text <> "" Then
                Clipboard.SetData(DataFormats.Text, txtfind.Text)
                txtfind.SelectedText = ""
            Else
                MsgBox("No text is selected to cut", MsgBoxStyle.Information, "Cut")
            End If
        Catch ex As Exception
            MsgBox("Can't cut the text", MsgBoxStyle.Critical, "Cut")
        End Try
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Try
            If txtfind.Text <> "" Then
                Clipboard.SetData(DataFormats.Text, txtfind.Text)
            Else
                MsgBox("No text is selected to copy", MsgBoxStyle.Information, "Copy")
            End If
        Catch ex As Exception
            MsgBox("Can't copy the text", MsgBoxStyle.Critical, "Copy")
        End Try
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        Try
            If Clipboard.ContainsText(TextDataFormat.Text) Then
                txtfind.SelectedText = Clipboard.GetData(DataFormats.Text).ToString()
            Else
                MsgBox("Can't paste the text (clipboard is not contained with the Plain text format) Please type the text instead of paste. ", MsgBoxStyle.Information, "Paste")
            End If
        Catch ex As Exception
            MsgBox("Can't paste the text", MsgBoxStyle.Critical, "Paste")
        End Try
    End Sub

    Private Sub frmfind_Load(sender As Object, e As EventArgs) Handles Me.Load
        btnFind.Enabled = True
        btnFind_next.Enabled = True
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        btnFind.Enabled = True
        txtfind.Text = ""
        btnFind_next.Enabled = False
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
                MessageBox.Show("String: " & txtfind.Text.ToString() & " not found", "No Matches", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)



            End Try
        End If
    End Sub

 
End Class