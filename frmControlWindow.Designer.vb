<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControlWindow
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
        Me.picBoxStart = New System.Windows.Forms.PictureBox()
        Me.cboStart = New System.Windows.Forms.ComboBox()
        Me.lblAction = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        CType(Me.picBoxStart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picBoxStart
        '
        Me.picBoxStart.Location = New System.Drawing.Point(12, 25)
        Me.picBoxStart.Name = "picBoxStart"
        Me.picBoxStart.Size = New System.Drawing.Size(42, 36)
        Me.picBoxStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBoxStart.TabIndex = 9
        Me.picBoxStart.TabStop = False
        '
        'cboStart
        '
        Me.cboStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStart.FormattingEnabled = True
        Me.cboStart.Location = New System.Drawing.Point(60, 41)
        Me.cboStart.Name = "cboStart"
        Me.cboStart.Size = New System.Drawing.Size(197, 21)
        Me.cboStart.TabIndex = 8
        Me.cboStart.Tag = "XboxCBox"
        '
        'lblAction
        '
        Me.lblAction.AutoSize = True
        Me.lblAction.Location = New System.Drawing.Point(60, 25)
        Me.lblAction.Name = "lblAction"
        Me.lblAction.Size = New System.Drawing.Size(38, 13)
        Me.lblAction.TabIndex = 7
        Me.lblAction.Text = "Button"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(304, 173)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(64, 20)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(304, 199)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(64, 20)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmControlWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 298)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.picBoxStart)
        Me.Controls.Add(Me.cboStart)
        Me.Controls.Add(Me.lblAction)
        Me.Name = "frmControlWindow"
        Me.Text = "Control Window"
        CType(Me.picBoxStart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents picBoxStart As PictureBox
    Friend WithEvents cboStart As ComboBox
    Friend WithEvents lblAction As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnClose As Button
End Class
