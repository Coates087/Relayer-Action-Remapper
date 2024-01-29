Public Class frmControlWindow


    Public gImageData As Bitmap = Nothing
    Public gControls As GameControls = Nothing
    Public gButton As GenericKey = Nothing

    Private Sub frmControlWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadControlData()
    End Sub
    Private Sub LoadControlData()
        picBoxButton.Image = gImageData
        Dim keyList As List(Of KeyboardClass) = GetKeyboardKeys()
        cboDefaultKey.DisplayMember = "KeyName"
        cboDefaultKey.ValueMember = "KeyCode"
        cboDefaultKey.DataSource = New List(Of KeyboardClass)(keyList)

        Dim strKeys As List(Of String) = gButton.KeyCode

        If strKeys.Count > 0 Then
            cboDefaultKey.SelectedValue = strKeys(0)
        End If

    End Sub


    Public Function GetKeyboardKeys() As List(Of KeyboardClass)
        Dim result As New List(Of KeyboardClass)

        '' Face buttons
        result.Add(New KeyboardClass With {.KeyCode = "None", .KeyName = "None"})

        result.Add(New KeyboardClass With {.KeyCode = "Backspace", .KeyName = "Backspace"})
        result.Add(New KeyboardClass With {.KeyCode = "Tab", .KeyName = "Tab"})
        result.Add(New KeyboardClass With {.KeyCode = "Clear", .KeyName = "Clear"})
        result.Add(New KeyboardClass With {.KeyCode = "Return", .KeyName = "Enter"})
        result.Add(New KeyboardClass With {.KeyCode = "Escape", .KeyName = "Escape"})
        result.Add(New KeyboardClass With {.KeyCode = "Pause", .KeyName = "Pause"})
        result.Add(New KeyboardClass With {.KeyCode = "Space", .KeyName = "Space"})
        result.Add(New KeyboardClass With {.KeyCode = "Exclaim", .KeyName = "Exclaimation"})
        result.Add(New KeyboardClass With {.KeyCode = "DoubleQuote", .KeyName = "DoubleQuote"})
        result.Add(New KeyboardClass With {.KeyCode = "Quote", .KeyName = "Quote"})
        result.Add(New KeyboardClass With {.KeyCode = "Hash", .KeyName = "# (Hash)"})
        result.Add(New KeyboardClass With {.KeyCode = "Dollar", .KeyName = "$ (Dollar)"})
        result.Add(New KeyboardClass With {.KeyCode = "Percent", .KeyName = "% (Percent)"})
        result.Add(New KeyboardClass With {.KeyCode = "Ampersand", .KeyName = "& (Ampersand)"})
        result.Add(New KeyboardClass With {.KeyCode = "LeftParen", .KeyName = "( (LeftParen)"})
        result.Add(New KeyboardClass With {.KeyCode = "RightParen", .KeyName = ") (RightParen)"})
        result.Add(New KeyboardClass With {.KeyCode = "Asterisk", .KeyName = "* (Asterisk)"})
        result.Add(New KeyboardClass With {.KeyCode = "Plus", .KeyName = "+ (Plus)"})
        result.Add(New KeyboardClass With {.KeyCode = "Comma", .KeyName = ", (Comma)"})
        result.Add(New KeyboardClass With {.KeyCode = "Minus", .KeyName = "- (Minus)"})
        result.Add(New KeyboardClass With {.KeyCode = "Period", .KeyName = ". (Period)"})
        result.Add(New KeyboardClass With {.KeyCode = "Slash", .KeyName = "/ (Slash)"})
        result.Add(New KeyboardClass With {.KeyCode = "Backslash", .KeyName = "\ (Back Slash)"})
        result.Add(New KeyboardClass With {.KeyCode = "Period", .KeyName = ". (Period)"})
        result.Add(New KeyboardClass With {.KeyCode = "Colon", .KeyName = ": (:)"})
        result.Add(New KeyboardClass With {.KeyCode = "Semicolon", .KeyName = "; (;)"})
        result.Add(New KeyboardClass With {.KeyCode = "Less", .KeyName = "< (Less)"})
        result.Add(New KeyboardClass With {.KeyCode = "Equals", .KeyName = "= (Equals)"})
        result.Add(New KeyboardClass With {.KeyCode = "Greater", .KeyName = "> (Greater)"})
        result.Add(New KeyboardClass With {.KeyCode = "Question", .KeyName = "? (Question)"})
        result.Add(New KeyboardClass With {.KeyCode = "At", .KeyName = "@ (At Symbol)"})
        result.Add(New KeyboardClass With {.KeyCode = "LeftBracket", .KeyName = "[ (LeftBracket)"})
        result.Add(New KeyboardClass With {.KeyCode = "RightBracket", .KeyName = "] (RighttBracket)"})
        result.Add(New KeyboardClass With {.KeyCode = "LeftCurlyBracket", .KeyName = "{ (LeftCurlyBracket)"})
        result.Add(New KeyboardClass With {.KeyCode = "RightCurlyBracket", .KeyName = "} (RightCurlyBracket)"})

        result.Add(New KeyboardClass With {.KeyCode = "Caret", .KeyName = "^ (Caret)"})
        result.Add(New KeyboardClass With {.KeyCode = "Underscore", .KeyName = "_ (Underscore)"})
        result.Add(New KeyboardClass With {.KeyCode = "BackQuote", .KeyName = "` (BackQuote)"})
        result.Add(New KeyboardClass With {.KeyCode = "A", .KeyName = "A"})
        result.Add(New KeyboardClass With {.KeyCode = "B", .KeyName = "B"})
        result.Add(New KeyboardClass With {.KeyCode = "C", .KeyName = "C"})
        result.Add(New KeyboardClass With {.KeyCode = "D", .KeyName = "D"})
        result.Add(New KeyboardClass With {.KeyCode = "E", .KeyName = "E"})
        result.Add(New KeyboardClass With {.KeyCode = "F", .KeyName = "F"})
        result.Add(New KeyboardClass With {.KeyCode = "G", .KeyName = "G"})
        result.Add(New KeyboardClass With {.KeyCode = "H", .KeyName = "H"})
        result.Add(New KeyboardClass With {.KeyCode = "I", .KeyName = "I"})
        result.Add(New KeyboardClass With {.KeyCode = "J", .KeyName = "J"})
        result.Add(New KeyboardClass With {.KeyCode = "K", .KeyName = "K"})
        result.Add(New KeyboardClass With {.KeyCode = "L", .KeyName = "L"})
        result.Add(New KeyboardClass With {.KeyCode = "M", .KeyName = "M"})
        result.Add(New KeyboardClass With {.KeyCode = "N", .KeyName = "N"})
        result.Add(New KeyboardClass With {.KeyCode = "O", .KeyName = "O"})

        result.Add(New KeyboardClass With {.KeyCode = "P", .KeyName = "P"})
        result.Add(New KeyboardClass With {.KeyCode = "Q", .KeyName = "Q"})
        result.Add(New KeyboardClass With {.KeyCode = "R", .KeyName = "R"})
        result.Add(New KeyboardClass With {.KeyCode = "S", .KeyName = "S"})
        result.Add(New KeyboardClass With {.KeyCode = "T", .KeyName = "T"})
        result.Add(New KeyboardClass With {.KeyCode = "U", .KeyName = "U"})
        result.Add(New KeyboardClass With {.KeyCode = "V", .KeyName = "V"})
        result.Add(New KeyboardClass With {.KeyCode = "W", .KeyName = "W"})
        result.Add(New KeyboardClass With {.KeyCode = "X", .KeyName = "X"})
        result.Add(New KeyboardClass With {.KeyCode = "Y", .KeyName = "Y"})
        result.Add(New KeyboardClass With {.KeyCode = "Z", .KeyName = "Z"})

        result.Add(New KeyboardClass With {.KeyCode = "Pipe", .KeyName = "| (Pipe)"})
        result.Add(New KeyboardClass With {.KeyCode = "Tilde", .KeyName = "~ (Tilde)"})
        result.Add(New KeyboardClass With {.KeyCode = "Delete", .KeyName = "Delete"})
        result.Add(New KeyboardClass With {.KeyCode = "Keypad0", .KeyName = "Keypad 0"})
        result.Add(New KeyboardClass With {.KeyCode = "Keypad1", .KeyName = "Keypad 1"})
        result.Add(New KeyboardClass With {.KeyCode = "Keypad2", .KeyName = "Keypad 2"})
        result.Add(New KeyboardClass With {.KeyCode = "Keypad3", .KeyName = "Keypad 3"})
        result.Add(New KeyboardClass With {.KeyCode = "Keypad4", .KeyName = "Keypad 4"})
        result.Add(New KeyboardClass With {.KeyCode = "Keypad5", .KeyName = "Keypad 5"})
        result.Add(New KeyboardClass With {.KeyCode = "Keypad6", .KeyName = "Keypad 6"})
        result.Add(New KeyboardClass With {.KeyCode = "Keypad7", .KeyName = "Keypad 7"})
        result.Add(New KeyboardClass With {.KeyCode = "Keypad8", .KeyName = "Keypad 8"})
        result.Add(New KeyboardClass With {.KeyCode = "Keypad9", .KeyName = "Keypad 9"})

        result.Add(New KeyboardClass With {.KeyCode = "KeypadPeriod", .KeyName = "Keypad ."})
        result.Add(New KeyboardClass With {.KeyCode = "KeypadDivide", .KeyName = "Keypad /"})
        result.Add(New KeyboardClass With {.KeyCode = "KeypadMultiply", .KeyName = "Keypad *"})
        result.Add(New KeyboardClass With {.KeyCode = "KeypadMinus", .KeyName = "Keypad -"})
        result.Add(New KeyboardClass With {.KeyCode = "KeypadPlus", .KeyName = "Keypad +"})
        result.Add(New KeyboardClass With {.KeyCode = "KeypadEnter", .KeyName = "Keypad Enter"})
        result.Add(New KeyboardClass With {.KeyCode = "UpArrow", .KeyName = "Up Arrow"})
        result.Add(New KeyboardClass With {.KeyCode = "DownArrow", .KeyName = "Down Arrow"})
        result.Add(New KeyboardClass With {.KeyCode = "LeftArrow", .KeyName = "Left Arrow"})
        result.Add(New KeyboardClass With {.KeyCode = "RightArrow", .KeyName = "Right Arrow"})

        result.Add(New KeyboardClass With {.KeyCode = "Insert", .KeyName = "Insert"})
        result.Add(New KeyboardClass With {.KeyCode = "Home", .KeyName = "Home"})
        result.Add(New KeyboardClass With {.KeyCode = "End", .KeyName = "End"})
        result.Add(New KeyboardClass With {.KeyCode = "PageUp", .KeyName = "Page Up"})
        result.Add(New KeyboardClass With {.KeyCode = "PageDown", .KeyName = "Page Down"})

        result.Add(New KeyboardClass With {.KeyCode = "F1", .KeyName = "F1"})
        result.Add(New KeyboardClass With {.KeyCode = "F2", .KeyName = "F2"})
        result.Add(New KeyboardClass With {.KeyCode = "F3", .KeyName = "F3"})
        result.Add(New KeyboardClass With {.KeyCode = "F4", .KeyName = "F4"})
        result.Add(New KeyboardClass With {.KeyCode = "F5", .KeyName = "F5"})
        result.Add(New KeyboardClass With {.KeyCode = "F6", .KeyName = "F6"})
        result.Add(New KeyboardClass With {.KeyCode = "F7", .KeyName = "F7"})
        result.Add(New KeyboardClass With {.KeyCode = "F8", .KeyName = "F8"})
        result.Add(New KeyboardClass With {.KeyCode = "F9", .KeyName = "F9"})
        result.Add(New KeyboardClass With {.KeyCode = "F10", .KeyName = "F10"})
        result.Add(New KeyboardClass With {.KeyCode = "F11", .KeyName = "F11"})
        result.Add(New KeyboardClass With {.KeyCode = "F12", .KeyName = "F12"})
        result.Add(New KeyboardClass With {.KeyCode = "F13", .KeyName = "F13"})
        result.Add(New KeyboardClass With {.KeyCode = "F14", .KeyName = "F14"})
        result.Add(New KeyboardClass With {.KeyCode = "F15", .KeyName = "F15"})
        result.Add(New KeyboardClass With {.KeyCode = "Numlock", .KeyName = "Numlock"})
        result.Add(New KeyboardClass With {.KeyCode = "CapsLock", .KeyName = "CapsLock"})
        result.Add(New KeyboardClass With {.KeyCode = "ScrollLock", .KeyName = "ScrollLock"})
        result.Add(New KeyboardClass With {.KeyCode = "LeftShift", .KeyName = "LeftShift"})
        result.Add(New KeyboardClass With {.KeyCode = "RightShift", .KeyName = "RightShift"})
        result.Add(New KeyboardClass With {.KeyCode = "LeftControl", .KeyName = "LeftControl"})
        result.Add(New KeyboardClass With {.KeyCode = "RightControl", .KeyName = "RightControl"})
        result.Add(New KeyboardClass With {.KeyCode = "LeftAlt", .KeyName = "LeftAlt"})
        result.Add(New KeyboardClass With {.KeyCode = "RightAlt", .KeyName = "RightAlt"})

        result.Add(New KeyboardClass With {.KeyCode = "LeftCommand", .KeyName = "LeftCommand"})
        result.Add(New KeyboardClass With {.KeyCode = "RightCommand", .KeyName = "RightCommand"})
        result.Add(New KeyboardClass With {.KeyCode = "LeftApple", .KeyName = "LeftApple"})
        result.Add(New KeyboardClass With {.KeyCode = "RightApple", .KeyName = "RightApple"})
        result.Add(New KeyboardClass With {.KeyCode = "Help", .KeyName = "Help"})
        result.Add(New KeyboardClass With {.KeyCode = "Print", .KeyName = "Print"})

        result.Add(New KeyboardClass With {.KeyCode = "SysReq", .KeyName = "SysReq"})
        result.Add(New KeyboardClass With {.KeyCode = "Break", .KeyName = "Break"})
        result.Add(New KeyboardClass With {.KeyCode = "Menu", .KeyName = "Menu"})

        result.Add(New KeyboardClass With {.KeyCode = "Mouse0", .KeyName = "Mouse 0"})
        result.Add(New KeyboardClass With {.KeyCode = "Mouse1", .KeyName = "Mouse 1"})
        result.Add(New KeyboardClass With {.KeyCode = "Mouse2", .KeyName = "Mouse 2"})
        result.Add(New KeyboardClass With {.KeyCode = "Mouse3", .KeyName = "Mouse 3"})
        result.Add(New KeyboardClass With {.KeyCode = "Mouse4", .KeyName = "Mouse 4"})
        result.Add(New KeyboardClass With {.KeyCode = "Mouse5", .KeyName = "Mouse 5"})
        result.Add(New KeyboardClass With {.KeyCode = "Mouse6", .KeyName = "Mouse 6"})

        'result.Add(New KeyboardClass With {.KeyCode = "None", .KeyName = "None"})
        'result.Add(New KeyboardClass With {.KeyCode = "None", .KeyName = "None"})
        'result.Add(New KeyboardClass With {.KeyCode = "None", .KeyName = "None"})

        Return result
    End Function

    'LeftWindows
    'RightWindows
    'AltGr

    'SysReq
    'Break
    'Menu
    'Mouse0
    'Mouse1
    'Mouse2
    'Mouse3
    'Mouse4
    'Mouse5
    'Mouse6

    'Alpha0
    'Alpha1
    'Alpha2
    'Alpha3
    'Alpha4
    'Alpha5
    'Alpha6
    'Alpha7
    'Alpha8
    'Alpha9


End Class