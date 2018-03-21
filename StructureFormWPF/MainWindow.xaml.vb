Imports System.ComponentModel
Imports pfcls

Class MainWindow
    Dim asyncConnection As IpfcAsyncConnection = Nothing
    Dim model As IpfcModel
    Dim activeserver As IpfcServer
    Dim paramown As IpfcParameterOwner
    Dim ipparam As IpfcParameter
    Dim ipbaseparam As IpfcBaseParameter
    Dim paramval As IpfcParamValue
    Dim session As IpfcBaseSession
    Dim Moditem As CMpfcModelItem

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        InfoTextBox.Text = "Checking if parameter is set..."
        Call StartApplicationAndConnect()


    End Sub

    Public Sub StartApplicationAndConnect()


        Try
            asyncConnection = (New CCpfcAsyncConnection).Connect(Nothing, Nothing, Nothing, Nothing)
            session = asyncConnection.Session
            activeserver = session.GetActiveServer
            model = session.CurrentModel

            If model Is Nothing Then
                MsgBox("Model is not present",, "Script message")
                Environment.Exit(0)
            End If

            If (Not model.Type = EpfcModelType.EpfcMDL_PART) And (Not model.Type = EpfcModelType.EpfcMDL_ASSEMBLY) Then
                MsgBox("Model is not a solid",, "Script message")
                Environment.Exit(0)
            End If

            If Not activeserver.IsObjectCheckedOut(activeserver.ActiveWorkspace, model.FileName) Then
                MsgBox("Please check out model first...",, "Script Message")
                Environment.Exit(0)
            End If
        Catch ex As Exception
            InfoTextBox.Text = "Sorry, something went wrong..."
        End Try
    End Sub


End Class
