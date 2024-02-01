Imports System.IO
Imports System.Text.Json
Imports System.Reflection
Imports RelayerJsonActionMapper.ButtonItems
Imports System.Text.Json.Nodes

'' Add toggle for when the user only wants to set keyboard and mouse, gamepad or both
'' Add form for warning use about gamepad only mode. Using built-in message dialog box isn't that great
Public Class frmAddUpdateControls
    Public assemblyName As String = String.Empty
    Public gStrOpenFileName As String = String.Empty
    Public gControls As GameControls = Nothing

    Public gSaveControls As GameControls = Nothing
    Public fileResourceList As New List(Of String)

    Public imageStreamList As New List(Of ImageName)
    Public gamepadOnlyFirstTime As Boolean = True
    Public gamepadOnly As Boolean = False

    Private Const conDlbQuote As String = Chr(34)
    Private Const gamepadOnlyWarningText As String = "You have selected "“Edit for Controller Only”". This mode is intended for the Controller Button Prompts mod on Nexus Mods and Game Banana. This mode will override all changes made for keyboard and mouse controls. Do you wish to use this mode?"

    Public Class ImageName
        Public FileName As String = String.Empty
        Public ImageData As Bitmap = Nothing
    End Class

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        gControls = Nothing
        Me.Close()
    End Sub

    Private Sub frmAddUpdateControls_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btnClose.DialogResult = DialogResult.Cancel
        btnSave.DialogResult = DialogResult.OK
        lblFile.Text = ""
        If Not String.IsNullOrWhiteSpace(gStrOpenFileName) Then
            lblFile.Text = "Reading from: " & Path.GetFileName(gStrOpenFileName)
        End If
        ShowXboxControls()
        HideKeyboardControls()
        LoadForm()
        SetToolTips()
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim saveControls As New GameControls
        saveControls = PrepSaveControls()
        gSaveControls = saveControls
        Me.Close()
    End Sub
    Private Sub rbnController_CheckedChanged(sender As Object, e As EventArgs) Handles rbnController.CheckedChanged

        If rbnController.Checked Then
            If gamepadOnlyFirstTime Then

                Dim myWarning As New frmControllerDialog

                Dim myResult = myWarning.ShowDialog()

                If myResult = vbYes Then
                    gamepadOnlyFirstTime = False
                    ForceViewGamePadOnly()
                    DisableViewControls()
                Else
                    EnableViewControls()
                End If
            Else
                ForceViewGamePadOnly()
                DisableViewControls()
            End If
            gamepadOnly = True
        Else
            gamepadOnly = False
            EnableViewControls()
        End If
    End Sub

    Private Sub rbnEditAll_CheckedChanged(sender As Object, e As EventArgs) Handles rbnEditAll.CheckedChanged
        If rbnEditAll.Checked Then
            EnableViewControls()
        End If
    End Sub

    Private Sub rbnViewGamePad_CheckedChanged(sender As Object, e As EventArgs) Handles rbnViewGamePad.CheckedChanged
        If rbnViewGamePad.Checked Then
            ShowXboxControls()
            HideKeyboardControls()
        End If
    End Sub

    Private Sub rbnViewKeyboard_CheckedChanged(sender As Object, e As EventArgs) Handles rbnViewKeyboard.CheckedChanged
        If rbnViewKeyboard.Checked Then
            ShowKeyboardControls()
            HideXboxControls()
        End If
    End Sub

    Private Sub btnKeyStart_Click(sender As Object, e As EventArgs) Handles btnKeyStart.Click
        ShowKeyboardDialog("Xbox_start_button.png", gControls.Escape)
    End Sub

    Private Sub ShowKeyboardDialog(xboxButtonName As String, aButton As GenericKey)
        Dim selectedImage = imageStreamList.Where(Function(e) e.FileName = xboxButtonName).FirstOrDefault()

        If Not IsNothing(selectedImage) Then
            Dim myControlForm As New frmControlWindow
            myControlForm.gImageData = selectedImage.ImageData
            myControlForm.gControls = gControls
            myControlForm.gButton = aButton

            Dim dialogResults = myControlForm.ShowDialog()

            If dialogResults = DialogResult.OK Then
                aButton.KeyCode = myControlForm.gStrKeys
                MapValues()
            End If

            SetToolTips()
        End If
    End Sub

    Private Sub ForceViewGamePadOnly()
        rbnViewGamePad.Checked = True
    End Sub

    Private Sub DisableViewControls()
        rbnViewKeyboard.Enabled = False
        rbnViewGamePad.Enabled = False
    End Sub

    Private Sub EnableViewControls()
        rbnViewKeyboard.Enabled = True
        rbnViewGamePad.Enabled = True
    End Sub

    Private Sub HideXboxControls()

        Dim myControls As List(Of Control) = gboxFields.Controls.Cast(Of Control)().Where(Function(e) {"XboxLabel", "XboxCBox"}.Contains(e.Tag?.ToString)).ToList
        HideControls(myControls)
    End Sub

    Private Sub HideKeyboardControls()

        Dim myControls As List(Of Control) = gboxFields.Controls.Cast(Of Control)().Where(Function(e) {"KeyLabel", "KeyButton"}.Contains(e.Tag?.ToString)).ToList
        HideControls(myControls)
    End Sub

    Private Sub ShowXboxControls()

        Dim myControls As List(Of Control) = gboxFields.Controls.Cast(Of Control)().Where(Function(e) {"XboxLabel", "XboxCBox"}.Contains(e.Tag?.ToString)).ToList
        ShowControls(myControls)
    End Sub

    Private Sub ShowKeyboardControls()

        Dim myControls As List(Of Control) = gboxFields.Controls.Cast(Of Control)().Where(Function(e) {"KeyLabel", "KeyButton"}.Contains(e.Tag?.ToString)).ToList
        ShowControls(myControls)
    End Sub

    Private Sub HideControls(myControls As IEnumerable(Of Control))
        For Each aControl In myControls
            aControl.Visible = False
        Next
    End Sub

    Private Sub ShowControls(myControls As IEnumerable(Of Control))
        For Each aControl In myControls
            aControl.Visible = True
        Next
    End Sub

    Private Sub SetToolTips()
        Dim myControls As List(Of Control) = gboxFields.Controls.Cast(Of Control)().Where(Function(e) {"KeyLabel"}.Contains(e.Tag?.ToString)).ToList

        For Each aLabelControl In myControls
            'aLabelControl.too
            tip1.SetToolTip(aLabelControl, aLabelControl.Text)
        Next
        ' tip1.Sho
    End Sub


    Public Sub LoadForm()
        fileResourceList = New List(Of String) From {
        "Icon_BtnXbox_dpad_down.png",
        "Icon_BtnXbox_dpad_left.png",
        "Icon_BtnXbox_dpad_right.png",
        "Icon_BtnXbox_dpad_up.png",
        "Icon_BtnXbox_LB.png",
        "Icon_BtnXbox_LT.png",
        "Icon_BtnXbox_RB.png",
        "Icon_BtnXbox_RT.png",
        "Xbox_A_button.png",
        "Xbox_back_button.png",
        "Xbox_B_button.png",
        "Xbox_L_StickClick.png",
        "Xbox_L_Sticks_down.png",
        "Xbox_L_Sticks_left.png",
        "Xbox_L_Sticks_right.png",
        "Xbox_L_Sticks_up.png",
        "Xbox_menu_button.png",
        "Xbox_R_StickClick.png",
        "Xbox_R_Sticks_down.png",
        "Xbox_R_Sticks_left.png",
        "Xbox_R_Sticks_right.png",
        "Xbox_R_Sticks_up.png",
        "Xbox_start_button.png",
        "Xbox_view_button.png",
        "Xbox_X_button.png",
        "Xbox_Y_button.png"
        }
        imageStreamList = New List(Of ImageName)

        For Each strFile As String In fileResourceList

            Dim imageResult As Bitmap = LoadImage(strFile)

            imageStreamList.Add(New ImageName With {.FileName = strFile, .ImageData = imageResult})


        Next


        For Each imageStream As ImageName In imageStreamList
            If Not IsNothing(imageStream.ImageData) Then
                If imageStream.FileName = "Xbox_start_button.png" Then
                    picBoxStart.Image = imageStream.ImageData
                ElseIf imageStream.FileName = "Xbox_back_button.png" Then
                    picBoxBack.Image = imageStream.ImageData
                ElseIf imageStream.FileName = "Xbox_A_button.png" Then
                    picBoxA.Image = imageStream.ImageData
                ElseIf imageStream.FileName = "Xbox_B_button.png" Then
                    picBoxB.Image = imageStream.ImageData
                ElseIf imageStream.FileName = "Xbox_X_button.png" Then
                    picBoxX.Image = imageStream.ImageData
                ElseIf imageStream.FileName = "Xbox_Y_button.png" Then
                    picBoxY.Image = imageStream.ImageData
                ElseIf imageStream.FileName = "Icon_BtnXbox_LB.png" Then
                    picBoxLB.Image = imageStream.ImageData
                ElseIf imageStream.FileName = "Icon_BtnXbox_RB.png" Then
                    picBoxRB.Image = imageStream.ImageData
                ElseIf imageStream.FileName = "Icon_BtnXbox_LT.png" Then
                    picBoxLT.Image = imageStream.ImageData
                ElseIf imageStream.FileName = "Icon_BtnXbox_RT.png" Then
                    picBoxRT.Image = imageStream.ImageData
                    ''dpad
                ElseIf imageStream.FileName = "Icon_BtnXbox_dpad_up.png" Then
                    picBox_dUp.Image = imageStream.ImageData
                ElseIf imageStream.FileName = "Icon_BtnXbox_dpad_down.png" Then
                    picBox_dDown.Image = imageStream.ImageData
                ElseIf imageStream.FileName = "Icon_BtnXbox_dpad_left.png" Then
                    picBox_dLeft.Image = imageStream.ImageData
                ElseIf imageStream.FileName = "Icon_BtnXbox_dpad_right.png" Then
                    picBox_dRight.Image = imageStream.ImageData

                ElseIf imageStream.FileName = "Xbox_L_Sticks_up.png" Then
                    picBoxLsUp.Image = imageStream.ImageData
                ElseIf imageStream.FileName = "Xbox_L_Sticks_down.png" Then
                    picBoxLsDown.Image = imageStream.ImageData
                ElseIf imageStream.FileName = "Xbox_L_Sticks_left.png" Then
                    picBoxLsLeft.Image = imageStream.ImageData
                ElseIf imageStream.FileName = "Xbox_L_Sticks_right.png" Then
                    picBoxLsRight.Image = imageStream.ImageData
                ElseIf imageStream.FileName = "Xbox_L_StickClick.png" Then
                    picBoxLsButton.Image = imageStream.ImageData


                ElseIf imageStream.FileName = "Xbox_R_Sticks_up.png" Then
                    picBoxRsUp.Image = imageStream.ImageData
                ElseIf imageStream.FileName = "Xbox_R_Sticks_down.png" Then
                    picBoxRsDown.Image = imageStream.ImageData
                ElseIf imageStream.FileName = "Xbox_R_Sticks_left.png" Then
                    picBoxRsLeft.Image = imageStream.ImageData
                ElseIf imageStream.FileName = "Xbox_R_Sticks_right.png" Then
                    picBoxRsRight.Image = imageStream.ImageData
                ElseIf imageStream.FileName = "Xbox_R_StickClick.png" Then
                    picBoxRsButton.Image = imageStream.ImageData
                End If
            End If
        Next

        Dim xboxButtonList As New List(Of XboxButton)

        xboxButtonList.Add(New XboxButton With {.XboxButtonName = "", .XboxButtonValue = ""})
        xboxButtonList.AddRange(GetXboxButtons())

        Dim myControls = gboxFields.Controls.Cast(Of Control)().Where(Function(e) e.GetType = GetType(ComboBox) And e.Tag?.ToString = "XboxCBox").ToList
        Dim xboxCboxes As New List(Of ComboBox)
        xboxCboxes = myControls.ConvertAll(Of ComboBox)(Function(t As Control) DirectCast(t, ComboBox))
        For Each xboxCBox In xboxCboxes
            xboxCBox.DisplayMember = "XboxButtonName"
            xboxCBox.ValueMember = "XboxButtonValue"
            xboxCBox.DataSource = New List(Of XboxButton)(xboxButtonList)

        Next
        MapValues()
    End Sub


    Public Sub MapValues()
        If Not IsNothing(gControls) Then
            cboStart.SelectedValue = gControls.Escape.ButtonName
            cboBack.SelectedValue = gControls.V.ButtonName
            cboA.SelectedValue = gControls.Enter.ButtonName
            cboB.SelectedValue = gControls.Backspace.ButtonName
            cboX.SelectedValue = gControls.Tab.ButtonName
            cboY.SelectedValue = gControls.Shift.ButtonName

            cboLB.SelectedValue = gControls.Q.ButtonName
            cboRB.SelectedValue = gControls.E.ButtonName
            cboLT.SelectedValue = gControls.WheelUp.ButtonName
            cboRT.SelectedValue = gControls.WheelDown.ButtonName

            cbodUp.SelectedValue = gControls.W.ButtonName
            cbodDown.SelectedValue = gControls.S.ButtonName
            cbodLeft.SelectedValue = gControls.A.ButtonName
            cbodRight.SelectedValue = gControls.D.ButtonName

            cboLsUp.SelectedValue = gControls.CtrlW.ButtonName
            cboLsDown.SelectedValue = gControls.CtrlS.ButtonName
            cboLsLeft.SelectedValue = gControls.CtrlA.ButtonName
            cboLsRight.SelectedValue = gControls.CtrlD.ButtonName
            cboLsButton.SelectedValue = gControls.F.ButtonName

            cboRsUp.SelectedValue = gControls.UpArrow.ButtonName
            cboRsDown.SelectedValue = gControls.DownArrow.ButtonName
            cboRsLeft.SelectedValue = gControls.DownArrow.ButtonName
            cboRsRight.SelectedValue = gControls.DownArrow.ButtonName
            cboRsButton.SelectedValue = gControls.R.ButtonName

            lblStart.Text = String.Join(", ", gControls.Escape.KeyCode)
        End If
    End Sub

    Public Function LoadImage(strFile As String) As Bitmap
        Dim image As Bitmap = Nothing

        Dim fullResourceName As String = assemblyName + "." + strFile

        Dim thisAssembly As Assembly = Assembly.GetExecutingAssembly()
        Dim obj = thisAssembly.GetManifestResourceNames()
        Dim readReflect = thisAssembly.GetManifestResourceStream(fullResourceName)

        If Not IsNothing(readReflect) Then

            image = New Bitmap(readReflect)
        End If
        Return image
    End Function



    Public Function PrepSaveControls() As GameControls
        Dim saveControls As New GameControls
        saveControls = gControls

        saveControls.Escape.ButtonName = ReplaceIfNothing(cboStart.SelectedValue, "")
        saveControls.V.ButtonName = ReplaceIfNothing(cboBack.SelectedValue, "")
        saveControls.Enter.ButtonName = ReplaceIfNothing(cboA.SelectedValue, "")
        saveControls.Backspace.ButtonName = ReplaceIfNothing(cboB.SelectedValue, "")
        saveControls.Tab.ButtonName = ReplaceIfNothing(cboX.SelectedValue, "")
        saveControls.Shift.ButtonName = ReplaceIfNothing(cboY.SelectedValue, "")

        saveControls.Q.ButtonName = ReplaceIfNothing(cboLB.SelectedValue, "")
        saveControls.E.ButtonName = ReplaceIfNothing(cboRB.SelectedValue, "")
        saveControls.WheelUp.ButtonName = ReplaceIfNothing(cboLT.SelectedValue, "")
        saveControls.WheelDown.ButtonName = ReplaceIfNothing(cboRT.SelectedValue, "")

        saveControls.W.ButtonName = ReplaceIfNothing(cbodUp.SelectedValue, "")
        saveControls.S.ButtonName = ReplaceIfNothing(cbodDown.SelectedValue, "")
        saveControls.A.ButtonName = ReplaceIfNothing(cbodLeft.SelectedValue, "")
        saveControls.D.ButtonName = ReplaceIfNothing(cbodRight.SelectedValue, "")

        saveControls.CtrlW.ButtonName = ReplaceIfNothing(cboLsUp.SelectedValue, "")
        saveControls.CtrlS.ButtonName = ReplaceIfNothing(cboLsDown.SelectedValue, "")
        saveControls.CtrlA.ButtonName = ReplaceIfNothing(cboLsLeft.SelectedValue, "")
        saveControls.CtrlD.ButtonName = ReplaceIfNothing(cboLsRight.SelectedValue, "")
        saveControls.F.ButtonName = ReplaceIfNothing(cboLsButton.SelectedValue, "")

        saveControls.UpArrow.ButtonName = ReplaceIfNothing(cboRsUp.SelectedValue, "")
        saveControls.DownArrow.ButtonName = ReplaceIfNothing(cboRsDown.SelectedValue, "")
        saveControls.LeftArrow.ButtonName = ReplaceIfNothing(cboRsLeft.SelectedValue, "")
        saveControls.RightArrow.ButtonName = ReplaceIfNothing(cboRsRight.SelectedValue, "")
        saveControls.R.ButtonName = ReplaceIfNothing(cboRsButton.SelectedValue, "")
        saveControls = SetControlsForGamepadOnly(saveControls)
        Return saveControls
    End Function

    Private Function SetControlsForGamepadOnly(saveControls As GameControls) As GameControls
        Dim myControls As New GameControls
        myControls = saveControls
        If gamepadOnly Then
            Dim myOptions As New JsonSerializerOptions
            myOptions.WriteIndented = True
            myOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            Dim root = JsonNode.Parse(JsonSerializer.Serialize(myControls, myOptions)).AsObject()
            Dim keyActions As List(Of String) = GetKeyActionNameList()

            For Each aKey In keyActions
                Dim aKeyList As New List(Of String)
                If aKey = "Ctrl" Then
                    root.Item(aKey).Item("KeyCode").AsArray().Clear()
                    root.Item(aKey).Item("KeyCode").AsArray().Add("Control")
                Else
                    root.Item(aKey).Item("KeyCode").AsArray().Clear()
                    Dim result = GetRightKey(root.Item(aKey).Item("ButtonName"))
                    root.Item(aKey).Item("KeyCode").AsArray().Add(result)
                End If
            Next
            myControls = JsonSerializer.Deserialize(Of GameControls)(root.ToString)
        End If
        Return myControls
    End Function

    Private Function GetRightKey(buttonName As String) As String
        Dim keyName As String = String.Empty

        Select Case buttonName
            Case "joystick_button_0"
                keyName = "Return"
            Case "joystick_button_1"
                keyName = "Backspace"
            Case "joystick_button_3"
                keyName = "Shift"
            Case "joystick_button_2"
                keyName = "Tab"
            Case "Axis_7_P"
                keyName = "W"
            Case "Axis_7_N"
                keyName = "S"
            Case "Axis_6_N"
                keyName = "A"
            Case "Axis_6_P"
                keyName = "D"
            Case "joystick_button_4"
                keyName = "Q"
            Case "joystick_button_5"
                keyName = "E"
            Case "joystick_button_8"
                keyName = "F"
            Case "joystick_button_9"
                keyName = "R"
            Case "joystick_button_6"
                keyName = "V"
            Case "joystick_button_7"
                keyName = "Escape"

            Case "Axis_5_N"
                keyName = "UpArrow"
            Case "Axis_5_P"
                keyName = "DownArrow"
            Case "Axis_4_N"
                keyName = "LeftArrow"
            Case "Axis_4_P"
                keyName = "RightArrow"

            Case "Axis_9_P"
                keyName = ""
            Case "Axis_10_P"
                keyName = ""
        End Select

        Return keyName
    End Function

    Private Function GetKeyActionNameList() As List(Of String)
        Dim keyActions As New List(Of String)

        keyActions.Add("Enter")
        keyActions.Add("Backspace")
        keyActions.Add("Shift")
        keyActions.Add("Tab")
        keyActions.Add("W")
        keyActions.Add("S")
        keyActions.Add("A")
        keyActions.Add("D")
        keyActions.Add("Q")
        keyActions.Add("E")
        keyActions.Add("F")
        keyActions.Add("R")
        keyActions.Add("V")
        keyActions.Add("Escape")
        keyActions.Add("UpArrow")
        keyActions.Add("DownArrow")
        keyActions.Add("LeftArrow")
        keyActions.Add("RightArrow")
        keyActions.Add("WheelUp")
        keyActions.Add("WheelDown")
        keyActions.Add("Ctrl")
        'keyActions.Add("CtrlW")
        'keyActions.Add("CtrlS")
        'keyActions.Add("CtrlA")
        'keyActions.Add("CtrlD")

        Return keyActions
    End Function

    Public Function ReplaceIfNothing(ByVal objValue As Object, ByVal altValue As Object) As Object
        Dim result As Object = objValue
        If IsNothing(objValue) Then
            result = altValue
        End If
        Return result
    End Function
End Class