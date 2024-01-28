<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpenFile
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.btnLoadFile = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "FileName"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(34, 84)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(373, 20)
        Me.txtFileName.TabIndex = 4
        '
        'btnLoadFile
        '
        Me.btnLoadFile.Location = New System.Drawing.Point(422, 84)
        Me.btnLoadFile.Name = "btnLoadFile"
        Me.btnLoadFile.Size = New System.Drawing.Size(114, 20)
        Me.btnLoadFile.TabIndex = 3
        Me.btnLoadFile.Text = "Load File"
        Me.btnLoadFile.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(422, 147)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(114, 20)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.Location = New System.Drawing.Point(51, 147)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(114, 20)
        Me.btnOk.TabIndex = 7
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'frmOpenFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 230)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.btnLoadFile)
        Me.Name = "frmOpenFile"
        Me.Text = "frmOpenFile"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtFileName As TextBox
    Friend WithEvents btnLoadFile As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOk As Button
End Class
