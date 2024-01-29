Imports System.Text.Json.Serialization

Public Class GenericKey
    Inherits GenericKeyButtonName
    <JsonInclude>
    Public Property KeyCode As New List(Of String)
End Class

Public Class GenericKeyButtonName
    <JsonInclude>
    Public Property ButtonName As String
    <JsonIgnore>
    Public Property XBoxButton As String

End Class
Public Class GenericKeyCode
    <JsonInclude>
    Public Property KeyCode As New List(Of String)

End Class

Public Class GameControls
    <JsonInclude>
    Public Property Enter As GenericKey
    <JsonInclude>
    Public Property Backspace As GenericKey
    <JsonInclude>
    Public Property Shift As GenericKey
    <JsonInclude>
    Public Property Tab As GenericKey
    <JsonInclude>
    Public Property W As GenericKey
    <JsonInclude>
    Public Property S As GenericKey
    <JsonInclude>
    Public Property A As GenericKey
    <JsonInclude>
    Public Property D As GenericKey
    <JsonInclude>
    Public Property Q As GenericKey
    <JsonInclude>
    Public Property E As GenericKey
    <JsonInclude>
    Public Property F As GenericKey
    <JsonInclude>
    Public Property R As GenericKey
    <JsonInclude>
    Public Property V As GenericKey
    <JsonInclude>
    Public Property Escape As GenericKey
    <JsonInclude>
    Public Property UpArrow As GenericKey
    <JsonInclude>
    Public Property DownArrow As GenericKey
    <JsonInclude>
    Public Property LeftArrow As GenericKey
    <JsonInclude>
    Public Property RightArrow As GenericKey
    <JsonInclude>
    Public Property WheelUp As GenericKey
    <JsonInclude>
    Public Property WheelDown As GenericKey
    Public Property Ctrl As GenericKeyCode
    <JsonInclude>
    <JsonPropertyName("Ctrl+W")>
    Public Property CtrlW As GenericKeyButtonName
    <JsonInclude>
    <JsonPropertyName("Ctrl+S")>
    Public Property CtrlS As GenericKeyButtonName
    <JsonInclude>
    <JsonPropertyName("Ctrl+A")>
    Public Property CtrlA As GenericKeyButtonName
    <JsonInclude>
    <JsonPropertyName("Ctrl+D")>
    Public Property CtrlD As GenericKeyButtonName
End Class

Public Class KeyboardClass
    Public Property KeyCode As String
    Public Property KeyName As String
End Class
