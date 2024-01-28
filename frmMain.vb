Imports System.IO
Imports System.Text.Json
Imports System.Reflection
''
Public Class frmMain
    Delegate Sub InvokeDelegate()

    Public assemblyName As String = String.Empty
    Public gStrOpenFileName As String = String.Empty
    Public gControls As GameControls = Nothing
    Public gUnsavedChanges As Boolean = False

    Const resKeyConfigDefault As String = "KeyConfigDefault.json"
    Const resKeyGamePadConfigDefault As String = "KeyConfigDefaultController.json"
    Const resKeyboardConfigDefault As String = "KeyConfigDefaultKeyboard.json"

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim thisAssembly As Assembly = Assembly.GetExecutingAssembly()
        Dim anAssemblyName = thisAssembly.GetName()

        assemblyName = anAssemblyName.Name
        lblFile.Text = ""
    End Sub

    Private Sub txtFileName_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub btnDefaultFile_Click(sender As Object, e As EventArgs) Handles btnDefaultFile.Click
        CreateDefaultJsonFile(0)
    End Sub

    Private Sub btnDefaultGamePadFile_Click(sender As Object, e As EventArgs) Handles btnDefaultGamePadFile.Click
        CreateDefaultJsonFile(1)
    End Sub

    Private Sub btnDefaultKBMFile_Click(sender As Object, e As EventArgs) Handles btnDefaultKBMFile.Click
        CreateDefaultJsonFile(2)
    End Sub

    Private Sub btnLoadFile_Click(sender As Object, e As EventArgs) Handles btnLoadFile.Click
        'BeginInvoke(New InvokeDelegate(AddressOf DisableFileTextBox))
        'LoadFile()
        'BeginInvoke(New InvokeDelegate(AddressOf EnableFileTextBox))

        Dim oFile As New frmOpenFile

        Dim controlDialog As DialogResult = oFile.ShowDialog()
        lblFile.Text = ""

        If controlDialog = DialogResult.OK Then
            gControls = oFile.gControls
            gStrOpenFileName = oFile.gStrOpenFileName
            lblFile.Text = "File Loaded: " & Path.GetFileName(gStrOpenFileName)
            ''gUnsavedChanges = True
        End If
    End Sub



    Public Sub CreateDefaultJsonFile(intDefaultType As Integer)
        Dim sFile As New SaveFileDialog
        sFile.DefaultExt = ".json"
        sFile.Filter = "JSON File (.json)|*.json" ' Filter files by extension
        Dim strSaveFilePath As String = ""

        Dim strFileData As String = String.Empty
        ' Show open file dialog box
        Dim result As Boolean = sFile.ShowDialog()

        ' Process open file dialog box results
        If result = True Then
            ' Open document
            strSaveFilePath = sFile.FileName
        Else
            Exit Sub
        End If

        Dim fullResourceName As String = ""

        Select Case intDefaultType
            Case 0
                fullResourceName = assemblyName + "." + resKeyConfigDefault
            Case 1
                fullResourceName = assemblyName + "." + resKeyGamePadConfigDefault
            Case 2
                fullResourceName = assemblyName + "." + resKeyboardConfigDefault
            Case Else
                fullResourceName = assemblyName + "." + resKeyConfigDefault
        End Select

        Dim thisAssembly As Assembly = Assembly.GetExecutingAssembly()
        Dim readReflect = thisAssembly.GetManifestResourceStream(fullResourceName)
        Dim reader = New StreamReader(readReflect)
        Dim strResult As String = reader.ReadToEnd()
        reader.Close()

        Dim writeFileResult = WriteToFile(strResult, strSaveFilePath)
        Dim dirPath As String = ""
        If writeFileResult = True Then
            Dim msgResult = MessageBox.Show("Do you wish to open the directory for this file?", "Save Successful", MessageBoxButtons.YesNo)

            If msgResult = DialogResult.Yes Then
                dirPath = IO.Path.GetDirectoryName(strSaveFilePath)
                Process.Start("explorer.exe", "/select,/separate," & Chr(34) & strSaveFilePath & Chr(34))
                'Process.Start("explorer.exe", "/select" & Chr(34) & strSaveFilePath & Chr(34))
                'Process.Start(dirPath)
            End If
        End If

    End Sub

    Public Function WriteToFile(strText, strPath) As Boolean
        Dim result As Boolean = True
        Try

            File.WriteAllText(strPath, strText)
        Catch ex As Exception
            result = False
        End Try

        Return result
    End Function


    Private Sub btnOpenControls_Click(sender As Object, e As EventArgs) Handles btnOpenControls.Click
        Dim editControls As New frmAddUpdateControls
        editControls.assemblyName = assemblyName
        editControls.gStrOpenFileName = gStrOpenFileName
        editControls.gControls = gControls
        Dim controlDialog As DialogResult = editControls.ShowDialog()

        If controlDialog = DialogResult.OK Then
            gControls = editControls.gSaveControls
            gUnsavedChanges = True
        End If
    End Sub

End Class
