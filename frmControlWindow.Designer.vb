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
        Me.picBoxButton = New System.Windows.Forms.PictureBox()
        Me.cboDefaultKey = New System.Windows.Forms.ComboBox()
        Me.lblAction = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.panKeys = New System.Windows.Forms.Panel()
        CType(Me.picBoxButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panKeys.SuspendLayout()
        Me.SuspendLayout()
        '
        'picBoxButton
        '
        Me.picBoxButton.Location = New System.Drawing.Point(7, 14)
        Me.picBoxButton.Name = "picBoxButton"
        Me.picBoxButton.Size = New System.Drawing.Size(42, 36)
        Me.picBoxButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBoxButton.TabIndex = 9
        Me.picBoxButton.TabStop = False
        '
        'cboDefaultKey
        '
        Me.cboDefaultKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDefaultKey.FormattingEnabled = True
        Me.cboDefaultKey.Location = New System.Drawing.Point(55, 30)
        Me.cboDefaultKey.Name = "cboDefaultKey"
        Me.cboDefaultKey.Size = New System.Drawing.Size(197, 21)
        Me.cboDefaultKey.TabIndex = 8
        Me.cboDefaultKey.Tag = "0"
        '
        'lblAction
        '
        Me.lblAction.AutoSize = True
        Me.lblAction.Location = New System.Drawing.Point(55, 14)
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
        'panKeys
        '
        Me.panKeys.Controls.Add(Me.picBoxButton)
        Me.panKeys.Controls.Add(Me.lblAction)
        Me.panKeys.Controls.Add(Me.cboDefaultKey)
        Me.panKeys.Location = New System.Drawing.Point(12, 12)
        Me.panKeys.Name = "panKeys"
        Me.panKeys.Size = New System.Drawing.Size(286, 261)
        Me.panKeys.TabIndex = 14
        '
        'frmControlWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 305)
        Me.ControlBox = False
        Me.Controls.Add(Me.panKeys)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Name = "frmControlWindow"
        Me.Text = "Control Window"
        CType(Me.picBoxButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panKeys.ResumeLayout(False)
        Me.panKeys.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picBoxButton As PictureBox
    Friend WithEvents cboDefaultKey As ComboBox
    Friend WithEvents lblAction As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents panKeys As Panel
End Class
