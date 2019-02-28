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
    Public Sub setParameter()
        Dim Paraname As String = "SURFACE_FINISH"
        Try
            ipparam = model.GetParam(Paraname)
            ipbaseparam = ipparam
            Moditem = New CMpfcModelItem

            paramval = Moditem.CreateStringParamValue(CStr("SEE DECORATION SPECIFICATION"))
            ipbaseparam.Value = paramval

            'MsgBox("Surface finish has been set to 'SEE DECORATION SPECIFICATION'",, "Script Message")
            'asyncConnection.Disconnect(1)

            Call getCurrentParameterSetting()

        Catch ex As Exception
        End Try
    End Sub

    Public Sub clearParameter()
        Dim Paraname As String = "SURFACE_FINISH"
        Try
            'asyncConnection = (New CCpfcAsyncConnection).Connect(Nothing, Nothing, Nothing, Nothing)
            'session = asyncConnection.Session
            'activeserver = session.GetActiveServer
            'model = session.CurrentModel


            'If model Is Nothing Then
            '    MsgBox("Model is not present",, "Script message")
            '    Environment.Exit(0)
            'End If

            'If (Not model.Type = EpfcModelType.EpfcMDL_PART) And (Not model.Type = EpfcModelType.EpfcMDL_ASSEMBLY) Then
            '    MsgBox("Model is not a solid",, "Script message")
            '    Environment.Exit(0)
            'End If

            'If Not activeserver.IsObjectCheckedOut(activeserver.ActiveWorkspace, model.FileName) Then
            '    MsgBox("Please check out model first...",, "Script Message")
            '    Environment.Exit(0)
            'End If


            ipparam = model.GetParam(Paraname)
            ipbaseparam = ipparam

            Moditem = New CMpfcModelItem

            paramval = Moditem.CreateStringParamValue(CStr("-"))
            ipbaseparam.Value = paramval

            'MsgBox("Surface finish has been set to '-'",, "Script Message")
            'asyncConnection.Disconnect(1)

            Call getCurrentParameterSetting()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub setGreenColorMacro()

        Try
            'asyncConnection = (New CCpfcAsyncConnection).Connect(Nothing, Nothing, Nothing, Nothing)
            'session = asyncConnection.Session
            'activeserver = session.GetActiveServer
            'model = session.CurrentModel
            Dim macrostring As String
            macrostring = "~ Select `main_dlg_cur` `View:ProCmdViewGallery`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Select `main_dlg_cur` \"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "`ProCmdViewGallery_layoutph.palette_holder.myAppPalette.NamesList` 1 \"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "`deco_green`;~ Timer `UI Desktop` `UI Desktop` `Gallery_UI_Timer`;"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Close `main_dlg_cur` `View:ProCmdViewGallery`;"

            session.RunMacro(macrostring)


        Catch ex As Exception

        End Try

    End Sub

    Private Sub setBlueColorMacro()
        Try
            'asyncConnection = (New CCpfcAsyncConnection).Connect(Nothing, Nothing, Nothing, Nothing)
            'session = asyncConnection.Session
            'activeserver = session.GetActiveServer
            'model = session.CurrentModel
            Dim macrostring As String
            macrostring = "~ Select `main_dlg_cur` `View:ProCmdViewGallery`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Select `main_dlg_cur` \"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "`ProCmdViewGallery_layoutph.palette_holder.myAppPalette.NamesList` 1 \"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "`deco_blue`;~ Timer `UI Desktop` `UI Desktop` `Gallery_UI_Timer`;"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Close `main_dlg_cur` `View:ProCmdViewGallery`;"

            session.RunMacro(macrostring)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub setYellowColorMacro()

        Try
            'asyncConnection = (New CCpfcAsyncConnection).Connect(Nothing, Nothing, Nothing, Nothing)
            'session = asyncConnection.Session
            'activeserver = session.GetActiveServer
            'model = session.CurrentModel
            Dim macrostring As String
            macrostring = "~ Select `main_dlg_cur` `View:ProCmdViewGallery`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Select `main_dlg_cur` \"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "`ProCmdViewGallery_layoutph.palette_holder.myAppPalette.NamesList` 1 \"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "`deco_yellow`;~ Timer `UI Desktop` `UI Desktop` `Gallery_UI_Timer`;"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Close `main_dlg_cur` `View:ProCmdViewGallery`;"

            session.RunMacro(macrostring)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub setRedColorMacro()

        Try
            'asyncConnection = (New CCpfcAsyncConnection).Connect(Nothing, Nothing, Nothing, Nothing)
            'session = asyncConnection.Session
            'activeserver = session.GetActiveServer
            'model = session.CurrentModel
            Dim macrostring As String
            macrostring = "~ Select `main_dlg_cur` `View:ProCmdViewGallery`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Select `main_dlg_cur` \"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "`ProCmdViewGallery_layoutph.palette_holder.myAppPalette.NamesList` 1 \"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "`deco_red`;~ Timer `UI Desktop` `UI Desktop` `Gallery_UI_Timer`;"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Close `main_dlg_cur` `View:ProCmdViewGallery`;"

            session.RunMacro(macrostring)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub setWhiteBackMacro()

        Try
            'asyncConnection = (New CCpfcAsyncConnection).Connect(Nothing, Nothing, Nothing, Nothing)
            'session = asyncConnection.Session
            'activeserver = session.GetActiveServer
            'model = session.CurrentModel
            Dim macrostring As String
            macrostring = "~ Trail `UI Desktop` `UI Desktop` `PREVIEW_POPUP_TIMER` \"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "`main_dlg_w1:PHTLeft.AssyTree:<NULL>`;~ Select `main_dlg_cur` `appl_casc`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Close `main_dlg_cur` `appl_casc`;~ Command `ProCmdRibbonOptionsDlg` ;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Select `ribbon_options_dialog` `PageSwitcherPageList` 1 `colors_layouts`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Open `ribbon_options_dialog` `colors_layouts.Color_scheme_optMenu`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Close `ribbon_options_dialog` `colors_layouts.Color_scheme_optMenu`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Select `ribbon_options_dialog` `colors_layouts.Color_scheme_optMenu` 1 `2`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Activate `ribbon_options_dialog` `OkPshBtn`;"


            session.RunMacro(macrostring)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub clearAppearanceMacro()

        Try
            'asyncConnection = (New CCpfcAsyncConnection).Connect(Nothing, Nothing, Nothing, Nothing)
            'session = asyncConnection.Session
            'activeserver = session.GetActiveServer
            'model = session.CurrentModel
            Dim macrostring As String
            'macrostring = "~ Select `main_dlg_cur` `appl_casc`;\"
            'macrostring = macrostring & vbCrLf
            'macrostring = macrostring & "~ Close `main_dlg_cur` `appl_casc`;\"
            'macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Select `main_dlg_cur` `View:ProCmdViewGallery`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Select `main_dlg_cur` \"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "`ProCmdViewGallery_layoutph.palette_holder.clearAppearance`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Close `main_dlg_cur` \"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "`ProCmdViewGallery_layoutph.palette_holder.clearAppearance`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Activate `main_dlg_cur` `clearAllAppearance`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ FocusIn `UI Message Dialog` `yes`;~ Activate `UI Message Dialog` `yes`;"

            session.RunMacro(macrostring)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub getCurrentParameterSetting()
        Dim Paraname As String = "SURFACE_FINISH"

        Try
            'asyncConnection = (New CCpfcAsyncConnection).Connect(Nothing, Nothing, Nothing, Nothing)
            'session = asyncConnection.Session
            'activeserver = session.GetActiveServer
            'model = session.CurrentModel

            'If model Is Nothing Then
            '    MsgBox("Model is not present",, "Script message")
            '    Environment.Exit(0)
            'End If

            'If (Not model.Type = EpfcModelType.EpfcMDL_PART) And (Not model.Type = EpfcModelType.EpfcMDL_ASSEMBLY) Then
            '    MsgBox("Model is not a solid",, "Script message")
            '    Environment.Exit(0)
            'End If

            'If Not activeserver.IsObjectCheckedOut(activeserver.ActiveWorkspace, model.FileName) Then
            '    MsgBox("Please check out model first...",, "Script Message")
            '    Environment.Exit(0)
            'End If

            ipparam = model.GetParam(Paraname)


            If ipparam.GetScaledValue.StringValue = "SEE DECORATION SPECIFICATION" Then
                InfoTextBox.Text = "Surface finish is set to" & vbCrLf & "'SEE DECORATION SPECIFICATION'"
                InfoTextBox.Background = New SolidColorBrush(Color.FromArgb(255, 90, 165, 9))
                myToggle.IsChecked = True

            ElseIf ipparam.GetScaledValue.StringValue = "-" Then
                InfoTextBox.Text = "Surface finish is set to '-'" & vbCrLf & "Remember to use the switch above."
                InfoTextBox.Background = New SolidColorBrush(Color.FromArgb(255, 184, 0, 0))
                InfoTextBox.Foreground = New SolidColorBrush(Colors.White)
                myToggle.IsChecked = False
            End If

            'asyncConnection.Disconnect(1)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        InfoTextBox.Text = "Checking if parameter is set..."
        Call StartApplicationAndConnect()
        Call getCurrentParameterSetting()
        Call CreateDecoView()
        Call getDecoView()

    End Sub

    Private Sub CreateDecoView()
        Dim macrostring As String

        Try

            macrostring = "~ Command `ProCmdViewVisTool` ;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Command `ProCmdViewVisTool` ;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Select `visual_dlg0` `RadioSelApplMgr` 1 `appearance state`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Activate `visual_dlg0` `ZoneNmCreate`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Input `visual_dlg0` `Table_INPUT` `Decoration Specification`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Update `visual_dlg0` `Table_INPUT` `Decoration Specification`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Activate `visual_dlg0` `Table_INPUT`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Arm `visual_dlg0` `Table` 2 `Default appearance` `name_column`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Select `visual_dlg0` `Table` 2 `Default appearance` `name_column`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Arm `visual_dlg0` `Table` 2 `Default appearance` `name_column`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Activate `visual_dlg0` `Table` 2 `Default appearance` `name_column`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Activate `visual_dlg0` `CloseBtn`;"


            session.RunMacro(macrostring)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub getDecoView()
        Dim macrostring As String

        Try

            macrostring = "~ Activate `main_dlg_cur` `page_View_control_btn` 1;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Command `ProCmdViewVisTool` ;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Select `visual_dlg0` `RadioSelApplMgr` 1 `appearance state`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Arm `visual_dlg0` `Table` 2 `decoration specification` `name_column`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Select `visual_dlg0` `Table` 2 `decoration specification` `name_column`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Arm `visual_dlg0` `Table` 2 `decoration specification` `name_column`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Activate `visual_dlg0` `Table` 2 `decoration specification` `name_column`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Close `visual_dlg0` `visual_dlg0`;"


            session.RunMacro(macrostring)
        Catch ex As Exception

        End Try


    End Sub
    Private Sub getDefaultView()
        Dim macrostring As String
        Try
            macrostring = "~ Activate `main_dlg_cur` `page_View_control_btn` 1;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Command `ProCmdViewVisTool` ;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Select `visual_dlg0` `RadioSelApplMgr` 1 `appearance state`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Arm `visual_dlg0` `Table` 2 `default appearance` `name_column`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Select `visual_dlg0` `Table` 2 `default appearance` `name_column`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Arm `visual_dlg0` `Table` 2 `default appearance` `name_column`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Activate `visual_dlg0` `Table` 2 `default appearance` `name_column`;\"
            macrostring = macrostring & vbCrLf
            macrostring = macrostring & "~ Close `visual_dlg0` `visual_dlg0`;"


            session.RunMacro(macrostring)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub setGreenColor_Click(sender As Object, e As RoutedEventArgs) Handles setGreenColor.Click
        Call setGreenColorMacro()
    End Sub


    Private Sub setYellowColor_Click(sender As Object, e As RoutedEventArgs) Handles setYellowColor.Click
        Call setYellowColorMacro()
    End Sub

    Private Sub setRedColor_Click(sender As Object, e As RoutedEventArgs) Handles setRedColor.Click
        Call setRedColorMacro()
    End Sub

    Private Sub setWhiteBack_Click(sender As Object, e As RoutedEventArgs) Handles setWhiteBack.Click
        Call setWhiteBackMacro()
    End Sub

    Private Sub clearAppearance_Click(sender As Object, e As RoutedEventArgs) Handles clearAppearance.Click
        Call clearAppearanceMacro()
    End Sub

    Private Sub myToggle_Unchecked(sender As Object, e As RoutedEventArgs) Handles myToggle.Unchecked
        Call clearParameter()
    End Sub

    Private Sub myToggle_Checked(sender As Object, e As RoutedEventArgs) Handles myToggle.Checked
        Call setParameter()
    End Sub

    Private Sub helpButton_Click(sender As Object, e As RoutedEventArgs) Handles helpButton.Click
        Dim target = "\\Storage03\hw-apps\ptc\decoration_specification\CreoApplication\helpfiles\helpfile.html"
        Process.Start(target)
    End Sub


    Private Sub MainWindow_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            getDefaultView()
            asyncConnection.Disconnect(1)
        Catch
        End Try
    End Sub

End Class
