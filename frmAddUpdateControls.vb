Imports System.IO
Imports System.Text.Json
Imports System.Reflection
Imports RelayerJsonActionMapper.ButtonItems

'' Add toggle for when the user only wants to set keyboard and mouse, gamepad or both
'' Get saving working
Public Class frmAddUpdateControls
    Public assemblyName As String = String.Empty
    Public gStrOpenFileName As String = String.Empty
    Public gControls As GameControls = Nothing

    Public gSaveControls As GameControls = Nothing
    Public fileResourceList As New List(Of String)

    Public imageStreamList As New List(Of ImageName)

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
        LoadForm()
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Dim em = cboStart.SelectedValue
        'Dim em2 = cboStart.Text

        Dim saveControls As New GameControls
        saveControls = PrepSaveControls()
        gSaveControls = saveControls
        Me.Close()
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
        saveControls.DownArrow.ButtonName = ReplaceIfNothing(cboRsLeft.SelectedValue, "")
        saveControls.DownArrow.ButtonName = ReplaceIfNothing(cboRsRight.SelectedValue, "")
        saveControls.R.ButtonName = ReplaceIfNothing(cboRsButton.SelectedValue, "")
        Return saveControls
    End Function

    Public Function ReplaceIfNothing(ByVal objValue As Object, ByVal altValue As Object) As Object
        Dim result As Object = objValue
        If IsNothing(objValue) Then
            result = altValue
        End If
        Return result
    End Function
End Class