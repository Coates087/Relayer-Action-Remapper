﻿Imports System.IO
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
        BeginInvoke(New InvokeDelegate(AddressOf DisableFileTextBox))
        LoadFile()
        BeginInvoke(New InvokeDelegate(AddressOf EnableFileTextBox))
    End Sub

    Public Sub DisableFileTextBox()

        txtFileName.Enabled = False
    End Sub

    Public Sub EnableFileTextBox()

        txtFileName.Enabled = True
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

    Public Sub LoadFile()
        Dim oFile As New OpenFileDialog
        oFile.DefaultExt = ".json"
        oFile.Filter = "JSON File (.json)|*.json" ' Filter files by extension

        Dim strFileData As String = String.Empty
        ' Show open file dialog box
        Dim result? As Boolean = oFile.ShowDialog()
        lblFile.Text = ""
        ' Process open file dialog box results
        If result = True Then
            ' Open document
            Dim strFilename As String = oFile.FileName
            gStrOpenFileName = strFilename
            txtFileName.Text = strFilename
            lblFile.Text = "File Loaded: " & Path.GetFileName(gStrOpenFileName)
            strFileData = My.Computer.FileSystem.ReadAllText(gStrOpenFileName)
        Else
            Exit Sub
        End If

        Dim myOptions As New JsonSerializerOptions
        myOptions.WriteIndented = True
        myOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping

        ''Dim em As System.Text.Json.JsonSerializer
        'Dim json As JsonSerializer

        'JsonSerializer.Deserialize()
        Dim myControls As GameControls = Nothing
        Dim validResult As String = ""

        Try

            myControls = JsonSerializer.Deserialize(Of GameControls)(strFileData)
            validResult = ValidateJSON(myControls)

            If Not validResult = "" Then
                MessageBox.Show("JSON file not formatted properly")
            End If


            gControls = myControls
            Dim em As String = JsonSerializer.Serialize(myControls, myOptions)
            Console.WriteLine(em)

        Catch ex As Exception
            MessageBox.Show("JSON file not formatted properly")
        End Try



    End Sub



    Public Function ValidateJSON(ByRef myControls As GameControls) As String

        Dim result As String = ""
        Dim objEmpty As Boolean = False
        If IsNothing(myControls) Then
            objEmpty = True
            result = "JSON object is empty"
            Return result
        End If


        '' dpad up
        If objEmpty = False AndAlso IsNothing(myControls.W) Then
            objEmpty = True
            result = "{W} Key is invalid"
        End If
        If objEmpty = False AndAlso IsNothing(myControls.W.ButtonName) Then
            objEmpty = True
            result = "{W} Key's ButtonName is invalid"
        Else
            If objEmpty = False Then
                myControls.W.XBoxButton = "dpad_up"
            End If
        End If

        '' dpad left
        If objEmpty = False AndAlso IsNothing(myControls.A) Then
            objEmpty = True
            result = "{A} Key is invalid"
        End If
        If objEmpty = False AndAlso IsNothing(myControls.A.ButtonName) Then
            objEmpty = True
            result = "{A} Key's ButtonName is invalid"
        Else
            If objEmpty = False Then
                myControls.A.XBoxButton = "dpad_left"
            End If
        End If

        '' dpad down
        If objEmpty = False AndAlso IsNothing(myControls.S) Then
            objEmpty = True
            result = "{S} Key is invalid"
        End If
        If objEmpty = False AndAlso IsNothing(myControls.S.ButtonName) Then
            objEmpty = True
            result = "{S} Key's ButtonName is invalid"
        Else
            If objEmpty = False Then
                myControls.S.XBoxButton = "dpad_down"
            End If
        End If

        '' dpad right
        If objEmpty = False AndAlso IsNothing(myControls.D) Then
            objEmpty = True
            result = "{D} Key is invalid"
        End If
        If objEmpty = False AndAlso IsNothing(myControls.D.ButtonName) Then
            objEmpty = True
            result = "{D} Key's ButtonName is invalid"
        Else
            If objEmpty = False Then
                myControls.D.XBoxButton = "dpad_right"
            End If
        End If

        '' A
        If objEmpty = False AndAlso IsNothing(myControls.Enter) Then
            objEmpty = True
            result = "{Enter} Key is invalid"
        End If
        If objEmpty = False AndAlso IsNothing(myControls.Enter.ButtonName) Then
            objEmpty = True
            result = "{Enter} Key's ButtonName is invalid"
        Else
            If objEmpty = False Then
                myControls.Enter.XBoxButton = "xbox_a"
            End If
        End If

        '' B
        If objEmpty = False AndAlso IsNothing(myControls.Backspace) Then
            objEmpty = True
            result = "{Backspace} Key is invalid"
        End If
        If objEmpty = False AndAlso IsNothing(myControls.Backspace.ButtonName) Then
            objEmpty = True
            result = "{Backspace} Key's ButtonName is invalid"
        Else
            If objEmpty = False Then
                myControls.Backspace.XBoxButton = "xbox_b"
            End If
        End If

        '' Xbox Start
        If objEmpty = False AndAlso IsNothing(myControls.Escape) Then
            objEmpty = True
            result = "{Escape} Key is invalid"
        End If
        If objEmpty = False AndAlso IsNothing(myControls.Escape.ButtonName) Then
            objEmpty = True
            result = "{Escape} Key's ButtonName is invalid"
        Else
            If objEmpty = False Then
                myControls.Escape.XBoxButton = "xbox_start"
            End If
        End If

        '' Y
        If objEmpty = False AndAlso IsNothing(myControls.Shift) Then
            objEmpty = True
            result = "{Shift} Key is invalid"
        End If
        If objEmpty = False AndAlso IsNothing(myControls.Shift.ButtonName) Then
            objEmpty = True
            result = "{Shift} Key's ButtonName is invalid"
        Else
            If objEmpty = False Then
                myControls.Shift.XBoxButton = "xbox_y"
            End If
        End If

        '' X
        If objEmpty = False AndAlso IsNothing(myControls.Tab) Then
            objEmpty = True
            result = "{Tab} Key is invalid"
        End If
        If objEmpty = False AndAlso IsNothing(myControls.Tab.ButtonName) Then
            objEmpty = True
            result = "{Tab} Key's ButtonName is invalid"
        Else
            If objEmpty = False Then
                myControls.Tab.XBoxButton = "xbox_x"
            End If
        End If

        '' LB
        If objEmpty = False AndAlso IsNothing(myControls.Q) Then
            objEmpty = True
            result = "{Q} Key is invalid"
        End If
        If objEmpty = False AndAlso IsNothing(myControls.Q.ButtonName) Then
            objEmpty = True
            result = "{Q} Key's ButtonName is invalid"
        Else
            If objEmpty = False Then
                myControls.Q.XBoxButton = "xbox_lb"
            End If
        End If

        '' RB
        If objEmpty = False AndAlso IsNothing(myControls.E) Then
            objEmpty = True
            result = "{E} Key is invalid"
        End If
        If objEmpty = False AndAlso IsNothing(myControls.E.ButtonName) Then
            objEmpty = True
            result = "{E} Key's ButtonName is invalid"
        Else
            If objEmpty = False Then
                myControls.E.XBoxButton = "xbox_rb"
            End If
        End If

        '' Left Stick Button
        If objEmpty = False AndAlso IsNothing(myControls.F) Then
            objEmpty = True
            result = "{F} Key is invalid"
        End If
        If objEmpty = False AndAlso IsNothing(myControls.F.ButtonName) Then
            objEmpty = True
            result = "{F} Key's ButtonName is invalid"
        Else
            If objEmpty = False Then
                myControls.F.XBoxButton = "xbox_lStickBtn"
            End If
        End If

        '' Right Stick Button
        If objEmpty = False AndAlso IsNothing(myControls.R) Then
            objEmpty = True
            result = "{R} Key is invalid"
        End If
        If objEmpty = False AndAlso IsNothing(myControls.R.ButtonName) Then
            objEmpty = True
            result = "{R} Key's ButtonName is invalid"
        Else
            If objEmpty = False Then
                myControls.R.XBoxButton = "xbox_rStickBtn"
            End If
        End If

        '' Xbox Back
        If objEmpty = False AndAlso IsNothing(myControls.V) Then
            objEmpty = True
            result = "{VE} Key is invalid"
        End If
        If objEmpty = False AndAlso IsNothing(myControls.V.ButtonName) Then
            objEmpty = True
            result = "{V} Key's ButtonName is invalid"
        Else
            If objEmpty = False Then
                myControls.V.XBoxButton = "xbox_back"
            End If
        End If

        '' Right Stick Up
        If objEmpty = False AndAlso IsNothing(myControls.UpArrow) Then
            objEmpty = True
            result = "{UpArrow} Key is invalid"
        End If
        If objEmpty = False AndAlso IsNothing(myControls.UpArrow.ButtonName) Then
            objEmpty = True
            result = "{UpArrow} Key's ButtonName is invalid"
        Else
            If objEmpty = False Then
                myControls.UpArrow.XBoxButton = "xbox_rStickUp"
            End If
        End If

        '' Right Stick Down
        If objEmpty = False AndAlso IsNothing(myControls.DownArrow) Then
            objEmpty = True
            result = "{DownArrow} Key is invalid"
        End If
        If objEmpty = False AndAlso IsNothing(myControls.DownArrow.ButtonName) Then
            objEmpty = True
            result = "{DownArrow} Key's ButtonName is invalid"
        Else
            If objEmpty = False Then
                myControls.DownArrow.XBoxButton = "xbox_rStickDown"
            End If
        End If

        '' Right Stick Left
        If objEmpty = False AndAlso IsNothing(myControls.LeftArrow) Then
            objEmpty = True
            result = "{LeftArrow} Key is invalid"
        End If
        If objEmpty = False AndAlso IsNothing(myControls.LeftArrow.ButtonName) Then
            objEmpty = True
            result = "{LeftArrow} Key's ButtonName is invalid"
        Else
            If objEmpty = False Then
                myControls.LeftArrow.XBoxButton = "xbox_rStickLeft"
            End If
        End If

        '' Right Stick Right
        If objEmpty = False AndAlso IsNothing(myControls.RightArrow) Then
            objEmpty = True
            result = "{RightArrow} Key is invalid"
        End If
        If objEmpty = False AndAlso IsNothing(myControls.RightArrow.ButtonName) Then
            objEmpty = True
            result = "{RightArrow} Key's ButtonName is invalid"
        Else
            If objEmpty = False Then
                myControls.RightArrow.XBoxButton = "xbox_rStickRight"
            End If
        End If

        '' LT
        If objEmpty = False AndAlso IsNothing(myControls.WheelUp) Then
            objEmpty = True
            result = "{WheelUp} Key is invalid"
        End If
        If objEmpty = False AndAlso IsNothing(myControls.WheelUp.ButtonName) Then
            objEmpty = True
            result = "{WheelUp} Key's ButtonName is invalid"
        Else
            If objEmpty = False Then
                myControls.WheelUp.XBoxButton = "xbox_lt"
            End If
        End If

        '' RT
        If objEmpty = False AndAlso IsNothing(myControls.WheelDown) Then
            objEmpty = True
            result = "{WheelDown} Key is invalid"
        End If
        If objEmpty = False AndAlso IsNothing(myControls.WheelDown.ButtonName) Then
            objEmpty = True
            result = "{WheelDown} Key's ButtonName is invalid"
        Else
            If objEmpty = False Then
                myControls.WheelDown.XBoxButton = "xbox_rt"
            End If
        End If


        '' Left Stick Up
        If objEmpty = False AndAlso IsNothing(myControls.CtrlW) Then
            objEmpty = True
            result = "{CtrlW} Key is invalid"
        End If
        If objEmpty = False AndAlso IsNothing(myControls.CtrlW.ButtonName) Then
            objEmpty = True
            result = "{CtrlW} Key's ButtonName is invalid"
        Else
            If objEmpty = False Then
                myControls.CtrlW.XBoxButton = "xbox_lStickup"
            End If
        End If

        '' Left Stick Down
        If objEmpty = False AndAlso IsNothing(myControls.CtrlS) Then
            objEmpty = True
            result = "{CtrlS} Key is invalid"
        End If
        If objEmpty = False AndAlso IsNothing(myControls.CtrlS.ButtonName) Then
            objEmpty = True
            result = "{CtrlS} Key's ButtonName is invalid"
        Else
            If objEmpty = False Then
                myControls.CtrlS.XBoxButton = "xbox_lStickDown"
            End If
        End If

        '' Left Stick Left
        If objEmpty = False AndAlso IsNothing(myControls.CtrlA) Then
            objEmpty = True
            result = "{CtrlA} Key is invalid"
        End If
        If objEmpty = False AndAlso IsNothing(myControls.CtrlA.ButtonName) Then
            objEmpty = True
            result = "{CtrlA} Key's ButtonName is invalid"
        Else
            If objEmpty = False Then
                myControls.CtrlA.XBoxButton = "xbox_lStickLeft"
            End If
        End If

        '' Left Stick Right
        If objEmpty = False AndAlso IsNothing(myControls.CtrlD) Then
            objEmpty = True
            result = "{CtrlD} Key is invalid"
        End If
        If objEmpty = False AndAlso IsNothing(myControls.CtrlD.ButtonName) Then
            objEmpty = True
            result = "{CtrlD} Key's ButtonName is invalid"
        Else
            If objEmpty = False Then
                myControls.CtrlD.XBoxButton = "xbox_lStickRight"
            End If
        End If

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
