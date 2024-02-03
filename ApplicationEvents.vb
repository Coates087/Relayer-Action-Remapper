Imports System.Reflection
Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private WithEvents MyDomain As AppDomain = AppDomain.CurrentDomain

        Private Function LoadDLL(
        ByVal sender As Object,
        ByVal args As System.ResolveEventArgs) As System.Reflection.Assembly Handles MyDomain.AssemblyResolve

            Dim resourceName As String = "RelayerJsonActionMapper." & New AssemblyName(args.Name).Name & ".dll"
            'had to use this line to debug and figure out why it didnt load at first
            Dim resources() As String = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames
            Dim myAssembly As Assembly = Nothing
            ''"RelayerJsonActionMapper.Relayer Action Mapper.resources.dll"
            If resources.Contains(resourceName) Then

                Using stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName)

                    Dim assemblyData(CInt(stream.Length - 1)) As Byte

                    stream.Read(assemblyData, 0, assemblyData.Length)

                    myAssembly = System.Reflection.Assembly.Load(assemblyData)

                End Using
            End If
            Return myAssembly
        End Function

    End Class
End Namespace
