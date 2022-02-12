<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmreplace
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmreplace))
        Me.txtfind = New System.Windows.Forms.TextBox()
        Me.match_case = New System.Windows.Forms.CheckBox()
        Me.btnReplace = New System.Windows.Forms.Button()
        Me.btnFind_next = New System.Windows.Forms.Button()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.txtReplace = New System.Windows.Forms.TextBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnReplace_all = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtfind
        '
        Me.txtfind.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfind.Location = New System.Drawing.Point(105, 20)
        Me.txtfind.Name = "txtfind"
        Me.txtfind.ShortcutsEnabled = False
        Me.txtfind.Size = New System.Drawing.Size(226, 25)
        Me.txtfind.TabIndex = 5
        '
        'match_case
        '
        Me.match_case.AutoSize = True
        Me.match_case.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.match_case.Location = New System.Drawing.Point(15, 118)
        Me.match_case.Name = "match_case"
        Me.match_case.Size = New System.Drawing.Size(88, 19)
        Me.match_case.TabIndex = 9
        Me.match_case.Text = "Match Case"
        Me.match_case.UseVisualStyleBackColor = True
        '
        'btnReplace
        '
        Me.btnReplace.Enabled = False
        Me.btnReplace.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReplace.Location = New System.Drawing.Point(348, 61)
        Me.btnReplace.Name = "btnReplace"
        Me.btnReplace.Size = New System.Drawing.Size(83, 30)
        Me.btnReplace.TabIndex = 8
        Me.btnReplace.Text = "Replace"
        Me.btnReplace.UseVisualStyleBackColor = True
        '
        'btnFind_next
        '
        Me.btnFind_next.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFind_next.Location = New System.Drawing.Point(447, 17)
        Me.btnFind_next.Name = "btnFind_next"
        Me.btnFind_next.Size = New System.Drawing.Size(83, 30)
        Me.btnFind_next.TabIndex = 7
        Me.btnFind_next.Text = "Find Next"
        Me.btnFind_next.UseVisualStyleBackColor = True
        '
        'btnFind
        '
        Me.btnFind.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFind.Location = New System.Drawing.Point(348, 17)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(83, 30)
        Me.btnFind.TabIndex = 6
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'txtReplace
        '
        Me.txtReplace.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReplace.Location = New System.Drawing.Point(105, 61)
        Me.txtReplace.Name = "txtReplace"
        Me.txtReplace.ShortcutsEnabled = False
        Me.txtReplace.Size = New System.Drawing.Size(226, 25)
        Me.txtReplace.TabIndex = 10
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(446, 107)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(83, 30)
        Me.btnClear.TabIndex = 12
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 15)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Find What"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 15)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Replace With"
        '
        'btnReplace_all
        '
        Me.btnReplace_all.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReplace_all.Location = New System.Drawing.Point(447, 61)
        Me.btnReplace_all.Name = "btnReplace_all"
        Me.btnReplace_all.Size = New System.Drawing.Size(83, 30)
        Me.btnReplace_all.TabIndex = 15
        Me.btnReplace_all.Text = "Replace All"
        Me.btnReplace_all.UseVisualStyleBackColor = True
        '
        'frmreplace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(541, 149)
        Me.Controls.Add(Me.btnReplace_all)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.txtReplace)
        Me.Controls.Add(Me.txtfind)
        Me.Controls.Add(Me.match_case)
        Me.Controls.Add(Me.btnReplace)
        Me.Controls.Add(Me.btnFind_next)
        Me.Controls.Add(Me.btnFind)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmreplace"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Replace"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtfind As System.Windows.Forms.TextBox
    Friend WithEvents match_case As System.Windows.Forms.CheckBox
    Friend WithEvents btnReplace As System.Windows.Forms.Button
    Friend WithEvents btnFind_next As System.Windows.Forms.Button
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents txtReplace As System.Windows.Forms.TextBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnReplace_all As System.Windows.Forms.Button
End Class
