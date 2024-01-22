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
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDefaultFile = New System.Windows.Forms.Button()
        Me.btnDefaultGamePadFile = New System.Windows.Forms.Button()
        Me.btnDefaultKBMFile = New System.Windows.Forms.Button()
        Me.btnOpenControls = New System.Windows.Forms.Button()
        Me.lblFile = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnLoadFile
        '
        Me.btnLoadFile.Location = New System.Drawing.Point(412, 81)
        Me.btnLoadFile.Name = "btnLoadFile"
        Me.btnLoadFile.Size = New System.Drawing.Size(114, 20)
        Me.btnLoadFile.TabIndex = 0
        Me.btnLoadFile.Text = "Load File"
        Me.btnLoadFile.UseVisualStyleBackColor = True
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(24, 81)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(373, 20)
        Me.txtFileName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "FileName"
        '
        'btnDefaultFile
        '
        Me.btnDefaultFile.Location = New System.Drawing.Point(225, 193)
        Me.btnDefaultFile.Name = "btnDefaultFile"
        Me.btnDefaultFile.Size = New System.Drawing.Size(209, 20)
        Me.btnDefaultFile.TabIndex = 3
        Me.btnDefaultFile.Text = "Create Default Config File"
        Me.btnDefaultFile.UseVisualStyleBackColor = True
        '
        'btnDefaultGamePadFile
        '
        Me.btnDefaultGamePadFile.Location = New System.Drawing.Point(225, 228)
        Me.btnDefaultGamePadFile.Name = "btnDefaultGamePadFile"
        Me.btnDefaultGamePadFile.Size = New System.Drawing.Size(209, 20)
        Me.btnDefaultGamePadFile.TabIndex = 4
        Me.btnDefaultGamePadFile.Text = "Create Game Pad Config File"
        Me.btnDefaultGamePadFile.UseVisualStyleBackColor = True
        '
        'btnDefaultKBMFile
        '
        Me.btnDefaultKBMFile.Location = New System.Drawing.Point(225, 264)
        Me.btnDefaultKBMFile.Name = "btnDefaultKBMFile"
        Me.btnDefaultKBMFile.Size = New System.Drawing.Size(209, 20)
        Me.btnDefaultKBMFile.TabIndex = 5
        Me.btnDefaultKBMFile.Text = "Create Keyboard Config File"
        Me.btnDefaultKBMFile.UseVisualStyleBackColor = True
        '
        'btnOpenControls
        '
        Me.btnOpenControls.Location = New System.Drawing.Point(412, 132)
        Me.btnOpenControls.Name = "btnOpenControls"
        Me.btnOpenControls.Size = New System.Drawing.Size(114, 20)
        Me.btnOpenControls.TabIndex = 6
        Me.btnOpenControls.Text = "Edit Controls"
        Me.btnOpenControls.UseVisualStyleBackColor = True
        '
        'lblFile
        '
        Me.lblFile.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblFile.Location = New System.Drawing.Point(33, 132)
        Me.lblFile.Name = "lblFile"
        Me.lblFile.Size = New System.Drawing.Size(364, 20)
        Me.lblFile.TabIndex = 7
        Me.lblFile.Text = "<sample>"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 406)
        Me.Controls.Add(Me.lblFile)
        Me.Controls.Add(Me.btnOpenControls)
        Me.Controls.Add(Me.btnDefaultKBMFile)
        Me.Controls.Add(Me.btnDefaultGamePadFile)
        Me.Controls.Add(Me.btnDefaultFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.btnLoadFile)
        Me.Name = "frmMain"
        Me.Text = "Relayer JSON Button Mapper"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnLoadFile As Button
    Friend WithEvents txtFileName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnDefaultFile As Button
    Friend WithEvents btnDefaultGamePadFile As Button
    Friend WithEvents btnDefaultKBMFile As Button
    Friend WithEvents btnOpenControls As Button
    Friend WithEvents lblFile As Label
End Class
