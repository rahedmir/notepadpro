
Option Explicit On
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing
Imports System.Drawing.Image
Imports System.IO
Imports System.Drawing.Text


Public Class frmmain
    Private urc As New UndoRedoClass(Of String)() 'Connecting Undo-Redo class (Class1) by creating it's object
    Private NoAdd As Boolean = False
    Private currentFile As String
    Private checkPrint As Integer
    Dim fonts As New InstalledFontCollection
    Dim bbf() As Char
    Dim file As String = Command$()

    Public Sub open_file()
        'This function used to open a text file in the application when we double click on that file
        If Not file = "" Then
            file = Replace(file, Chr(34), "")
            Dim objreader As New System.IO.StreamReader(file.ToString)
            AdvRichTextBox1.Text = objreader.ReadToEnd
            objreader.Close()
            Me.Text = "Notepad Pro - " & file
        End If
    End Sub
    Private Sub cut()
        Try
            If AdvRichTextBox1.SelectedText <> "" Then
                Clipboard.SetData(DataFormats.Text, AdvRichTextBox1.SelectedText)
                AdvRichTextBox1.SelectedText = ""
            Else
                MsgBox("No item is selected to cut", MsgBoxStyle.Information, "Cut")
            End If
        Catch ex As Exception
            MsgBox("Can't cut the selected item", MsgBoxStyle.Critical, "Cut")
        End Try
    End Sub
    Private Sub copy()
        Try
            If AdvRichTextBox1.SelectedText <> "" Then
                Clipboard.SetData(DataFormats.Text, AdvRichTextBox1.SelectedText)
            Else
                MsgBox("No item is selected to copy", MsgBoxStyle.Information, "Copy")
            End If
        Catch ex As Exception
            MsgBox("Can't copy the selected item", MsgBoxStyle.Critical, "Copy")
        End Try
    End Sub
    Private Sub paste()
        Try
            If Clipboard.ContainsText(TextDataFormat.Text) Then
                AdvRichTextBox1.SelectedText = Clipboard.GetData(DataFormats.Text).ToString()
            Else
                MsgBox("Clipboard is not contained with the valid text format ", MsgBoxStyle.Information, "Paste")
            End If
        Catch ex As Exception
            MsgBox("Can't paste the item", MsgBoxStyle.Critical, "Paste")
        End Try
    End Sub

    Private Sub Undo_Redo()
        NoAdd = True
        AdvRichTextBox1.Rtf = urc.CurrentItem
        UndoToolStripMenuItem.Enabled = urc.CanUndo
        UndoContextMenuItem.Enabled = urc.CanUndo
        RedoToolStripMenuItem.Enabled = urc.CanRedo
        RedoContextMenuItem.Enabled = urc.CanRedo
        NoAdd = False
        AdvRichTextBox1.SelectionStart = AdvRichTextBox1.Text.Length
        AdvRichTextBox1.SelectionLength = 0
    End Sub
    Private Sub Undo()
        Try
            urc.Undo()
            Undo_Redo()
            
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Redo()
        Try
            urc.Redo()
            Undo_Redo()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Delete()
        Try
            If AdvRichTextBox1.SelectedText <> "" Then

                AdvRichTextBox1.SelectedText = ""
            Else
                MsgBox("No item is selected to delete", MsgBoxStyle.Information, "Delete")
            End If
        Catch ex As Exception
            MsgBox("Can't delete the text", MsgBoxStyle.Critical, "Delete")
        End Try
    End Sub

    Private Sub Date_Time_Now()
        AdvRichTextBox1.SelectionStart = AdvRichTextBox1.Text.Length
        AdvRichTextBox1.SelectionLength = 0
    End Sub
  
    Private Sub New_MenuItem()
        Me.Text = "Notepad Pro - Untitled"
        AdvRichTextBox1.Clear()
        UndoToolStripMenuItem.Enabled = False
        RedoToolStripMenuItem.Enabled = False
        UndoContextMenuItem.Enabled = False
        RedoContextMenuItem.Enabled = False
    End Sub

    Private Sub Open_MenuItem()
        Try
            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

                AdvRichTextBox1.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog.FileName)
                Me.Text = "Notepad Pro - " & OpenFileDialog.FileName
                AdvRichTextBox1.Modified = False
                UndoToolStripMenuItem.Enabled = False
                RedoToolStripMenuItem.Enabled = False
                UndoContextMenuItem.Enabled = False
                RedoContextMenuItem.Enabled = False

            End If
        Catch ex As Exception
            MsgBox("The file cannot be opened", MsgBoxStyle.Critical, "Open")
        End Try
    End Sub

    Private Sub Drag_Drop()
        Try
            If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

                AdvRichTextBox1.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog.FileName)
                Me.Text = "Notepad Pro - " & OpenFileDialog.FileName
                AdvRichTextBox1.Modified = False

            Else

            End If
        Catch ext As Exception
            MsgBox("The file cannot be opened", MsgBoxStyle.Critical, "Open")
        End Try
    End Sub

    Private Sub NewToolSripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolSripMenuItem.Click
        If AdvRichTextBox1.Modified = False Then           
            New_MenuItem()
        Else
            Dim x As Integer = MsgBox("The document has not saved, Do you want to create new document ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "New")
            If x = vbYes Then
                New_MenuItem()
            End If

        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        If AdvRichTextBox1.Modified = True Then
            Dim x As Integer = MsgBox(" The document has not saved, Do you want to open new document ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Open")
            If x = vbYes Then
                
                Open_MenuItem()
            End If
        Else
            Open_MenuItem()
        End If


    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click

        If Me.Text = "Notepad Pro - Untitled" Then
            Try
                SaveAsToolStripMenuItem.PerformClick()

            Catch ex As Exception
                SaveAsToolStripMenuItem.PerformClick()
            End Try

        ElseIf Me.Text = "Notepad Pro - " & OpenFileDialog.FileName Then
            Try
                My.Computer.FileSystem.WriteAllText(OpenFileDialog.FileName, AdvRichTextBox1.Text, False)
                AdvRichTextBox1.Modified = False
            Catch ex As Exception
                SaveAsToolStripMenuItem.PerformClick()
            End Try

        ElseIf Me.Text = "Notepad Pro - " & SaveFileDialog.FileName Then
            Try
                My.Computer.FileSystem.WriteAllText(SaveFileDialog.FileName, AdvRichTextBox1.Text, False)
                AdvRichTextBox1.Modified = False
            Catch ex As Exception
                SaveAsToolStripMenuItem.PerformClick()
            End Try

        ElseIf Me.Text = "Notepad Pro - " & file Then
            Try
                My.Computer.FileSystem.WriteAllText((file), AdvRichTextBox1.Text, False)
                AdvRichTextBox1.Modified = False
            Catch ex As Exception
                SaveAsToolStripMenuItem.PerformClick()
            End Try
        End If
    End Sub

    Private Sub AdvRichTextBox1_LinkClicked(sender As Object, e As LinkClickedEventArgs)
        System.Diagnostics.Process.Start(e.LinkText)
    End Sub

    Private Sub AdvRichTextBox1_TextChanged(sender As Object, e As EventArgs)
        AdvRichTextBox1.DetectUrls = True
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Try
            If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                My.Computer.FileSystem.WriteAllText(SaveFileDialog.FileName, AdvRichTextBox1.Text, False)
                Me.Text = "Notepad Pro - " & SaveFileDialog.FileName
                AdvRichTextBox1.Modified = False
            End If
        Catch ex As Exception
            MsgBox("The file cannot be saved", MsgBoxStyle.Critical, "Save")
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        If AdvRichTextBox1.Modified = True Then
            Dim x As Integer = MsgBox("The document has not saved, Do you want to exit ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Exit")
            If x = vbYes Then
                End
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub frmmain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If AdvRichTextBox1.Modified = True Then
            Dim x As Integer = MsgBox("The document has not saved, Do you want to exit ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Exit")

            If x = vbYes Then
                Exit Sub
            ElseIf x = vbNo Then

                e.Cancel = True
            End If
        Else
            Application.Exit()
        End If
    End Sub

    Private Sub frmmain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            open_file()
        Catch ex As Exception
            SplashScreen.Hide()

            MsgBox("Invalid file format", MsgBoxStyle.Exclamation, "Notepad Pro")
            Application.Exit()
        End Try


        PasteToolStripMenuItem.Enabled = True
        PasteContextMenuItem.Enabled = True
        AdvRichTextBox1.ZoomFactor = 1
        AdvRichTextBox1.Modified = False

        urc.AddItem(AdvRichTextBox1.Rtf)

    End Sub


    Private Sub PrintPreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        Try
            PrintPreviewDialog.Document = PrintDocument()
            PrintPreviewDialog.WindowState = FormWindowState.Maximized
            PrintPreviewDialog.ShowDialog()
        Catch ex As Exception
            MsgBox("Print Preview cannot possible", MsgBoxStyle.Critical, "Print Preview")
        End Try

    End Sub

    Private Sub PageSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PageSetupToolStripMenuItem.Click
        Try
            PageSetupDialog.Document = PrintDocument()
            PageSetupDialog.ShowDialog()
        Catch ex As Exception
            MsgBox("Page Setup cannot possible", MsgBoxStyle.Critical, "Page Setup")
        End Try
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        Try
            If PrintDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintDocument.Print()
            End If
        Catch ex As Exception
            MsgBox("Print cannot possible", MsgBoxStyle.Critical, "Print")
        End Try
    End Sub

    Private Sub PrintDocument_BeginPrint(sender As Object, e As PrintEventArgs) Handles PrintDocument.BeginPrint
        checkPrint = 0
    End Sub

    Private Sub PrintDocument_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument.PrintPage

        checkPrint = AdvRichTextBox1.Print(checkPrint, AdvRichTextBox1.TextLength, e)

        If checkPrint < AdvRichTextBox1.TextLength Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If

    End Sub
    Private Sub AdvRichTextBox1_DragDrop(sender As Object, e As DragEventArgs) Handles AdvRichTextBox1.DragDrop
        Try

            If AdvRichTextBox1.Modified = True Then
                Dim x As Integer = MsgBox("The document has not saved, Do you want to open new document ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Open")
                If x = vbYes Then
                    Drag_Drop()
                ElseIf x = vbNo Then
                    e.Effect = DragDropEffects.None
                End If
            Else
                Drag_Drop()
            End If

        Catch ex As Exception
           
        End Try

    End Sub

    Private Sub AdvRichTextBox1_DragEnter(sender As Object, e As DragEventArgs) Handles AdvRichTextBox1.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub AdvRichTextBox1_LinkClicked1(sender As Object, e As LinkClickedEventArgs) Handles AdvRichTextBox1.LinkClicked

        Dim x As Integer = MsgBox("  Do you want to open this link ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Link")
        If x = vbYes Then
            Try
                System.Diagnostics.Process.Start(e.LinkText)
            Catch ex As Exception
                MsgBox("Notepad Pro can't open this link", MsgBoxStyle.Critical, "Link")
            End Try
        ElseIf x = vbNo Then
            Exit Sub
        End If
    End Sub

    Private Sub AdvRichTextBox1_SelectionChanged(sender As Object, e As EventArgs) Handles AdvRichTextBox1.SelectionChanged
        If AdvRichTextBox1.SelectedText = "" Then

            CutToolStripMenuItem.Enabled = False
            CutContextMenuItem.Enabled = False

            CopyToolStripMenuItem.Enabled = False
            CopyContextMenuItem.Enabled = False

        Else

            CutToolStripMenuItem.Enabled = True
            CutContextMenuItem.Enabled = True

            CopyToolStripMenuItem.Enabled = True
            CopyContextMenuItem.Enabled = True
        End If

        If Clipboard.ContainsText(TextDataFormat.Text) Then

            PasteToolStripMenuItem.Enabled = True
            PasteContextMenuItem.Enabled = True
        Else

            PasteToolStripMenuItem.Enabled = False
            PasteContextMenuItem.Enabled = False
        End If

    End Sub


    Private Sub AdvRichTextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles AdvRichTextBox1.TextChanged

        If AdvRichTextBox1.Modified Then
            UndoToolStripMenuItem.Enabled = True
            UndoContextMenuItem.Enabled = True
        Else
            UndoToolStripMenuItem.Enabled = False
            UndoContextMenuItem.Enabled = False

        End If

        Try
            If Not NoAdd Then
                urc.AddItem(AdvRichTextBox1.Rtf)
                UndoToolStripMenuItem.Enabled = urc.CanUndo
                UndoContextMenuItem.Enabled = urc.CanUndo
                RedoToolStripMenuItem.Enabled = urc.CanRedo
                RedoContextMenuItem.Enabled = urc.CanRedo
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem.Click
        cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        paste()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        AdvRichTextBox1.SelectAll()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Delete()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        If AdvRichTextBox1.Modified Then
            Dim x As Integer = MsgBox("The document has not saved, Do you want to clear this document ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Clear")
            If x = vbYes Then
                AdvRichTextBox1.Text = ""
            End If
        Else
            AdvRichTextBox1.Text = ""
        End If
    End Sub

    Private Sub FindToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindToolStripMenuItem.Click
        frmfind.ShowDialog()
    End Sub

    Private Sub ReplaceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReplaceToolStripMenuItem.Click
        frmreplace.ShowDialog()
    End Sub

    Private Sub UPPERCASEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UPPERCASEToolStripMenuItem.Click
        Try
            If AdvRichTextBox1.SelectedText = "" Then
                MsgBox("Please select the text first", MsgBoxStyle.Information, "Select")
            Else
                AdvRichTextBox1.SelectedText = AdvRichTextBox1.SelectedText.ToUpper()
            End If
        Catch ex As Exception
            MsgBox("There is a problem to apply this format", MsgBoxStyle.Critical, "Upper Case")
        End Try

    End Sub

    Private Sub LowerCaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LowerCaseToolStripMenuItem.Click
        Try
            If AdvRichTextBox1.SelectedText = "" Then
                MsgBox(" Please select the text first", MsgBoxStyle.Information, "Select")
            Else
                AdvRichTextBox1.SelectedText = AdvRichTextBox1.SelectedText.ToLower()
            End If
        Catch ex As Exception
            MsgBox("There is a problem to apply this format", MsgBoxStyle.Critical, "Lower Case")
        End Try

    End Sub

    Private Sub DateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DateToolStripMenuItem.Click
        AdvRichTextBox1.SelectedText = AdvRichTextBox1.SelectedText + " " + Today()
        Date_Time_Now()

    End Sub

    Private Sub TimeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TimeToolStripMenuItem.Click
        AdvRichTextBox1.SelectedText = AdvRichTextBox1.SelectedText + " " + TimeOfDay()
        Date_Time_Now()

    End Sub

    Private Sub NowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NowToolStripMenuItem.Click
        AdvRichTextBox1.SelectedText = AdvRichTextBox1.SelectedText + " " + Now()
        Date_Time_Now()
    End Sub
    

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.ShowDialog()
    End Sub

    Private Sub DonateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DonateToolStripMenuItem.Click
        Try
            Process.Start("https://www.paypal.com/paypalme2/mirrahed?locale.x=en_GB")
        Catch ex As Exception
            MsgBox(" Url navigation is not possible", MsgBoxStyle.Critical, "Link")
        End Try

    End Sub


    Private Sub SymbolsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SymbolsToolStripMenuItem.Click
        frmSymbols.ShowDialog()
    End Sub
    Private Sub ResetZoomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetZoomToolStripMenuItem.Click
        Try
            AdvRichTextBox1.ZoomFactor = 1

            ZoomInToolStripMenuItem.Enabled = True
            ZoomOutToolStripMenuItem.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ZoomInToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomInToolStripMenuItem.Click
        Try

            If AdvRichTextBox1.ZoomFactor = 2.0F Then

                MsgBox("Further Zoom In is not possible", MsgBoxStyle.Information, "Zoom")

                ZoomInToolStripMenuItem.Enabled = False
                Exit Sub
            Else
                AdvRichTextBox1.ZoomFactor = AdvRichTextBox1.ZoomFactor + 0.5F
            End If
        Catch ex As Exception

        End Try

        ZoomOutToolStripMenuItem.Enabled = True

    End Sub

    Private Sub ZoomOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomOutToolStripMenuItem.Click
        Try
            If AdvRichTextBox1.ZoomFactor = 1.0F Then

                MsgBox("Further Zoom Out is not possible", MsgBoxStyle.Information, "Zoom")

                ZoomOutToolStripMenuItem.Enabled = False
                Exit Sub
            Else
                AdvRichTextBox1.ZoomFactor = AdvRichTextBox1.ZoomFactor - 0.5F
            End If
        Catch ex As Exception

        End Try

        ZoomInToolStripMenuItem.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        lblchar.Text = AdvRichTextBox1.TextLength.ToString()
        lblzoom.Text = AdvRichTextBox1.ZoomFactor.ToString()
        lblline.Text = AdvRichTextBox1.Lines.Count()
    
    End Sub

    Private Sub WordWrapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WordWrapToolStripMenuItem.Click
        If WordWrapToolStripMenuItem.Checked = True Then
            AdvRichTextBox1.WordWrap = True
        Else
            AdvRichTextBox1.WordWrap = False
        End If
    End Sub

    Private Sub CalendarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalendarToolStripMenuItem.Click
        frmCalendar.ShowDialog()
    End Sub


    Private Sub CheckForUpdatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckForUpdatesToolStripMenuItem.Click
        Try

            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://www.dropbox.com/s/3enl3j5u7i1b7ns/Notepad_Pro.txt?dl=1")
            Dim response As System.Net.HttpWebResponse = request.GetResponse()
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
            Dim newversion As String = sr.ReadToEnd
            Dim currentversion As String = Application.ProductVersion
            If newversion.Contains(currentversion) Then
                MsgBox(" Notepad Pro is up to date", MsgBoxStyle.Information, "Update")

            Else
                Dim x As DialogResult = MsgBox(" There is a new version available, Do you want to download it ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Update")
                If x = Windows.Forms.DialogResult.Yes Then
                    Try
                        Process.Start("https://notepadpro.github.io/")
                    Catch ex As Exception
                        MsgBox(" Url navigation is not possible", MsgBoxStyle.Critical, "Link")
                    End Try

                End If

            End If
        Catch ex As Exception
            MsgBox(" Can't check update, please check your internet connection", MsgBoxStyle.Critical, "Update")
        End Try
    End Sub

    Private Sub NewWindowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewWindowToolStripMenuItem.Click
        Try
            Dim x As String = Application.ExecutablePath

            Process.Start(x)

        Catch ex As Exception
            MsgBox("Executable path does not exist", MsgBoxStyle.Critical, "New Window")
        End Try
    End Sub

    Private Sub UndoContextMenuItem_Click(sender As Object, e As EventArgs) Handles UndoContextMenuItem.Click
        Undo()
    End Sub

    Private Sub RedoContextMenuItem_Click(sender As Object, e As EventArgs) Handles RedoContextMenuItem.Click
        Redo()
    End Sub

    Private Sub CutContextMenuItem_Click(sender As Object, e As EventArgs) Handles CutContextMenuItem.Click
        cut()
    End Sub

    Private Sub CopyContextMenuItem_Click(sender As Object, e As EventArgs) Handles CopyContextMenuItem.Click
        copy()
    End Sub

    Private Sub PasteContextMenuItem_Click(sender As Object, e As EventArgs) Handles PasteContextMenuItem.Click
        paste()
    End Sub

    Private Sub SelectAllContextMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllContextMenuItem.Click
        AdvRichTextBox1.SelectAll()
    End Sub

    Private Sub DeleteContextMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteContextMenuItem.Click
        Delete()
    End Sub

    Private Sub RefreshContextMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshContextMenuItem.Click
        AdvRichTextBox1.Refresh()
    End Sub

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        Undo()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click
        Redo()
    End Sub

    Private Sub NotepadProHomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotepadProHomeToolStripMenuItem.Click
        Try
            Process.Start("https://notepadpro.github.io/")
        Catch ex As Exception
            MsgBox(" Url navigation is not possible", MsgBoxStyle.Critical, "Link")
        End Try
    End Sub
End Class

'AdvRichTextBox is a class that helps to create a custom Rich TextBox control and 
'add graphical printing functionality (such as font-color, text background-color, images) to it.
Public Class AdvRichTextBox
    Inherits RichTextBox
    ''' <summary>
    ''' Maintains performance while updating.
    ''' </summary>
    ''' <remarks>
    ''' <para>
    ''' It is recommended to call this method before doing
    ''' any major updates that you do not wish the user to
    ''' see. Remember to call EndUpdate when you are finished
    ''' with the update. Nested calls are supported.
    ''' </para>
    ''' <para>
    ''' Calling this method will prevent redrawing. It will
    ''' also setup the event mask of the underlying richedit
    ''' control so that no events are sent.
    ''' </para>
    ''' </remarks>
    ''' '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ ALINEAR Y JUSTIFICAR
    Public Sub BeginUpdate()
        ' Deal with nested calls.
        updating += 1

        If updating > 1 Then
            Return
        End If

        ' Prevent the control from raising any events.
        oldEventMask = SendMessage(New HandleRef(Me, Handle), EM_SETEVENTMASK, 0, 0)

        ' Prevent the control from redrawing itself.
        SendMessage(New HandleRef(Me, Handle), WM_SETREDRAW, 0, 0)
    End Sub

    ''' <summary>
    ''' Resumes drawing and event handling.
    ''' </summary>
    ''' <remarks>
    ''' This method should be called every time a call is made
    ''' made to BeginUpdate. It resets the event mask to it's
    ''' original value and enables redrawing of the control.
    ''' </remarks>
    Public Sub EndUpdate()
        ' Deal with nested calls.
        updating -= 1

        If updating > 0 Then
            Return
        End If

        ' Allow the control to redraw itself.
        SendMessage(New HandleRef(Me, Handle), WM_SETREDRAW, 1, 0)

        ' Allow the control to raise event messages.
        SendMessage(New HandleRef(Me, Handle), EM_SETEVENTMASK, 0, oldEventMask)
    End Sub

 

    ''' <summary>
    ''' This member overrides
    ''' <see cref="Control"/>.OnHandleCreated.
    ''' </summary>
    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        MyBase.OnHandleCreated(e)

        ' Enable support for justification.
        SendMessage(New HandleRef(Me, Handle), EM_SETTYPOGRAPHYOPTIONS, TO_ADVANCEDTYPOGRAPHY, TO_ADVANCEDTYPOGRAPHY)
    End Sub

    Private updating As Integer = 0
    Private oldEventMask As Integer = 0

    ' Constants from the Platform SDK.
    Private Const EM_SETEVENTMASK As Integer = 1073
    Private Const EM_GETPARAFORMAT As Integer = 1085
    Private Const EM_SETPARAFORMAT As Integer = 1095
    Private Const EM_SETTYPOGRAPHYOPTIONS As Integer = 1226
    Private Const WM_SETREDRAW As Integer = 11
    Private Const TO_ADVANCEDTYPOGRAPHY As Integer = 1
    Private Const PFM_ALIGNMENT As Integer = 8
    Private Const SCF_SELECTION As Integer = 1

    ' It makes no difference if we use PARAFORMAT or
    ' PARAFORMAT2 here, so I have opted for PARAFORMAT2.
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure PARAFORMAT
        Public cbSize As Integer
        Public dwMask As UInteger
        Public wNumbering As Short
        Public wReserved As Short
        Public dxStartIndent As Integer
        Public dxRightIndent As Integer
        Public dxOffset As Integer
        Public wAlignment As Short
        Public cTabCount As Short
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)> _
        Public rgxTabs As Integer()

        ' PARAFORMAT2 from here onwards.
        Public dySpaceBefore As Integer
        Public dySpaceAfter As Integer
        Public dyLineSpacing As Integer
        Public sStyle As Short
        Public bLineSpacingRule As Byte
        Public bOutlineLevel As Byte
        Public wShadingWeight As Short
        Public wShadingStyle As Short
        Public wNumberingStart As Short
        Public wNumberingStyle As Short
        Public wNumberingTab As Short
        Public wBorderSpace As Short
        Public wBorderWidth As Short
        Public wBorders As Short
    End Structure

    <DllImport("user32", CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(hWnd As HandleRef, msg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function

    <DllImport("user32", CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(hWnd As HandleRef, msg As Integer, wParam As Integer, ByRef lp As PARAFORMAT) As Integer
    End Function

    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++  IMPRIMIR

    ' Convert the unit that is used by the .NET framework (1/100 inch) 
    ' and the unit that is used by Win32 API calls (twips 1/1440 inch)
    Private Const AnInch As Double = 14.4

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure CHARRANGE
        Public cpMin As Integer          ' First character of range (0 for start of doc)
        Public cpMax As Integer          ' Last character of range (-1 for end of doc)
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure FORMATRANGE
        Public hdc As IntPtr             ' Actual DC to draw on
        Public hdcTarget As IntPtr       ' Target DC for determining text formatting
        Public rc As RECT                ' Region of the DC to draw to (in twips)
        Public rcPage As RECT            ' Region of the whole DC (page size) (in twips)
        Public chrg As CHARRANGE         ' Range of text to draw (see above declaration)
    End Structure

    Private Const WM_USER As Integer = &H400
    Private Const EM_FORMATRANGE As Integer = WM_USER + 57

    Private Declare Function SendMessage Lib "USER32" Alias "SendMessageA" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wp As IntPtr, ByVal lp As IntPtr) As IntPtr

    ' Render the contents of the RichTextBox for printing
    '	Return the last character printed + 1 (printing start from this point for next page)
    Public Function Print(ByVal charFrom As Integer, ByVal charTo As Integer, ByVal e As PrintPageEventArgs) As Integer

        ' Mark starting and ending character 
        Dim cRange As CHARRANGE
        cRange.cpMin = charFrom
        cRange.cpMax = charTo

        ' Calculate the area to render and print
        Dim rectToPrint As RECT
        rectToPrint.Top = e.MarginBounds.Top * AnInch
        rectToPrint.Bottom = e.MarginBounds.Bottom * AnInch
        rectToPrint.Left = e.MarginBounds.Left * AnInch
        rectToPrint.Right = e.MarginBounds.Right * AnInch

        ' Calculate the size of the page
        Dim rectPage As RECT
        rectPage.Top = e.PageBounds.Top * AnInch
        rectPage.Bottom = e.PageBounds.Bottom * AnInch
        rectPage.Left = e.PageBounds.Left * AnInch
        rectPage.Right = e.PageBounds.Right * AnInch

        Dim hdc As IntPtr = e.Graphics.GetHdc()

        Dim fmtRange As FORMATRANGE
        fmtRange.chrg = cRange                 ' Indicate character from to character to 
        fmtRange.hdc = hdc                     ' Use the same DC for measuring and rendering
        fmtRange.hdcTarget = hdc               ' Point at printer hDC
        fmtRange.rc = rectToPrint              ' Indicate the area on page to print
        fmtRange.rcPage = rectPage             ' Indicate whole size of page

        Dim res As IntPtr = IntPtr.Zero

        Dim wparam As IntPtr = IntPtr.Zero
        wparam = New IntPtr(1)

        ' Move the pointer to the FORMATRANGE structure in memory
        Dim lparam As IntPtr = IntPtr.Zero
        lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange))
        Marshal.StructureToPtr(fmtRange, lparam, False)

        ' Send the rendered data for printing 
        res = SendMessage(Handle, EM_FORMATRANGE, wparam, lparam)

        ' Free the block of memory allocated
        Marshal.FreeCoTaskMem(lparam)

        ' Release the device context handle obtained by a previous call
        e.Graphics.ReleaseHdc(hdc)

        ' Return last + 1 character printer
        Return res.ToInt32()
    End Function
End Class

