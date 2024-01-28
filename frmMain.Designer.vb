<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnLoadFile = New System.Windows.Forms.Button()
        Me.btnDefaultFile = New System.Windows.Forms.Button()
        Me.btnDefaultGamePadFile = New System.Windows.Forms.Button()
        Me.btnDefaultKBMFile = New System.Windows.Forms.Button()
        Me.btnOpenControls = New System.Windows.Forms.Button()
        Me.lblFile = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnLoadFile
        '
        Me.btnLoadFile.Location = New System.Drawing.Point(259, 75)
        Me.btnLoadFile.Name = "btnLoadFile"
        Me.btnLoadFile.Size = New System.Drawing.Size(114, 29)
        Me.btnLoadFile.TabIndex = 0
        Me.btnLoadFile.Text = "Load File"
        Me.btnLoadFile.UseVisualStyleBackColor = True
        '
        'btnDefaultFile
        '
        Me.btnDefaultFile.Location = New System.Drawing.Point(300, 121)
        Me.btnDefaultFile.Name = "btnDefaultFile"
        Me.btnDefaultFile.Size = New System.Drawing.Size(209, 29)
        Me.btnDefaultFile.TabIndex = 3
        Me.btnDefaultFile.Text = "Create Default Config File"
        Me.btnDefaultFile.UseVisualStyleBackColor = True
        '
        'btnDefaultGamePadFile
        '
        Me.btnDefaultGamePadFile.Location = New System.Drawing.Point(300, 156)
        Me.btnDefaultGamePadFile.Name = "btnDefaultGamePadFile"
        Me.btnDefaultGamePadFile.Size = New System.Drawing.Size(209, 32)
        Me.btnDefaultGamePadFile.TabIndex = 4
        Me.btnDefaultGamePadFile.Text = "Create Xbox Game Pad Config File"
        Me.btnDefaultGamePadFile.UseVisualStyleBackColor = True
        '
        'btnDefaultKBMFile
        '
        Me.btnDefaultKBMFile.Location = New System.Drawing.Point(300, 192)
        Me.btnDefaultKBMFile.Name = "btnDefaultKBMFile"
        Me.btnDefaultKBMFile.Size = New System.Drawing.Size(209, 32)
        Me.btnDefaultKBMFile.TabIndex = 5
        Me.btnDefaultKBMFile.Text = "Create Keyboard Config File"
        Me.btnDefaultKBMFile.UseVisualStyleBackColor = True
        '
        'btnOpenControls
        '
        Me.btnOpenControls.Location = New System.Drawing.Point(395, 75)
        Me.btnOpenControls.Name = "btnOpenControls"
        Me.btnOpenControls.Size = New System.Drawing.Size(114, 29)
        Me.btnOpenControls.TabIndex = 6
        Me.btnOpenControls.Text = "Edit Controls"
        Me.btnOpenControls.UseVisualStyleBackColor = True
        '
        'lblFile
        '
        Me.lblFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFile.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblFile.Location = New System.Drawing.Point(41, 41)
        Me.lblFile.Name = "lblFile"
        Me.lblFile.Size = New System.Drawing.Size(485, 20)
        Me.lblFile.TabIndex = 7
        Me.lblFile.Text = "<sample>"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(444, 311)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(82, 30)
        Me.btnExit.TabIndex = 8
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 376)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lblFile)
        Me.Controls.Add(Me.btnOpenControls)
        Me.Controls.Add(Me.btnDefaultKBMFile)
        Me.Controls.Add(Me.btnDefaultGamePadFile)
        Me.Controls.Add(Me.btnDefaultFile)
        Me.Controls.Add(Me.btnLoadFile)
        Me.Name = "frmMain"
        Me.Text = "Relayer JSON Button Mapper"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnLoadFile As Button
    Friend WithEvents btnDefaultFile As Button
    Friend WithEvents btnDefaultGamePadFile As Button
    Friend WithEvents btnDefaultKBMFile As Button
    Friend WithEvents btnOpenControls As Button
    Friend WithEvents lblFile As Label
    Friend WithEvents btnExit As Button
End Class
