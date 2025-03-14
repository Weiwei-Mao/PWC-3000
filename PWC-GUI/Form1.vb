﻿Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles




Public Class Form1
    Const VersionNumber As Double = 1.0

    Private READOnly SchemeInfoList As New ArrayList ' this is a list and CHARACTERistics of all the application schemes, icluding crops, rates everything from labels

    ' these are for hiding the tabs that are not normally used
    Private tempTabpage1 As TabPage
    Private tempTabpage2 As TabPage
    Private tempTabpage3 As TabPage
    Private tempTabpage4 As TabPage
    Private tempTabpage5 As TabPage  'application tab
    Private tempTabpage6 As TabPage  'scenario tab

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        System.ThREADing.ThREAD.CurrentThREAD.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US")
        Me.Text = "Pesticide Water Calculator, Version " & Standard.VersionNumber

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MakeApplicationTable()
        tempTabpage1 = AdvancedTab
        tempTabpage2 = ScenarioExaminerTab
        tempTabpage3 = OptionalOutputTab
        tempTabpage4 = WaterbodyExaminerTab
        tempTabpage5 = SchemeApplicationsTab
        tempTabpage6 = SchemeScenariosTab

        TabControl1.Controls.Remove(AdvancedTab)
        TabControl1.Controls.Remove(ScenarioExaminerTab)
        TabControl1.Controls.Remove(OptionalOutputTab)
        TabControl1.Controls.Remove(WaterbodyExaminerTab)
        TabControl1.Controls.Remove(SchemeApplicationsTab)
        TabControl1.Controls.Remove(SchemeScenariosTab)

        LoadDefaultDiscretizations()
        MakeSprayTable()

    End Sub

    Private Sub LoadDefaultDiscretizations()
        DiscretizationGridView.Rows.Add(3, 30)
        DiscretizationGridView.Rows.Add(7, 7)
        DiscretizationGridView.Rows.Add(10, 2)
        DiscretizationGridView.Rows.Add(80, 4)
        DiscretizationGridView.Rows.Add(900, 18)
        DiscretizationGridView.Rows.Add(100, 2)
    End Sub

    Private Sub MakeSprayTable()
        SprayGridView.Rows.Add(Standard.sprayterm0) 'Header with buffer LENgth in ft
        SprayGridView.Rows.Add(Standard.sprayterm1)
        SprayGridView.Rows.Add(Standard.sprayterm2)
        SprayGridView.Rows.Add(Standard.sprayterm3)
        SprayGridView.Rows.Add(Standard.sprayterm4)
        SprayGridView.Rows.Add(Standard.sprayterm5)
        SprayGridView.Rows.Add(Standard.sprayterm6)
        SprayGridView.Rows.Add(Standard.sprayterm7)
        SprayGridView.Rows.Add(Standard.sprayterm8)
        SprayGridView.Rows.Add(Standard.sprayterm9)
        SprayGridView.Rows.Add(Standard.sprayterm10)
        SprayGridView.Rows.Add(Standard.sprayterm11)
        SprayGridView.Rows.Add(Standard.sprayterm12)
        SprayGridView.Rows.Add(Standard.sprayterm13)
        SprayGridView.Rows.Add(Standard.sprayterm14)
        SprayGridView.Rows.Add(Standard.sprayterm15)
        SprayGridView.Rows.Add(Standard.sprayterm16)

        SprayGridView.Rows(0).DefaultCellStyle = New DataGridViewCellStyle With {.Font = New System.Drawing.Font("Arial", 10.0!, FontStyle.Bold)}
        SprayGridView.Rows(0).DefaultCellStyle.ForeColor = Color.Purple

    End Sub


    Private Sub MakeApplicationTable()
        'Add Columns
        AppTableDisplay.ColumnCount = 2
        AppTableDisplay.Columns(0).Name = "Days"
        AppTableDisplay.Columns(0).Width = 70

        AppTableDisplay.Columns(1).Name = "Amount (kg/ha)"
        AppTableDisplay.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        AppTableDisplay.Columns(1).Width = 60

        Dim combo As New DataGridViewComboBoxColumn With {
            .HeaderText = "Application Method",
            .Width = 135
        }

        combo.Items.Add(Standard.method1)
        combo.Items.Add(Standard.method2)
        combo.Items.Add(Standard.method3)
        combo.Items.Add(Standard.method4)
        combo.Items.Add(Standard.method5)
        combo.Items.Add(Standard.method6)
        combo.Items.Add(Standard.method7)

        'combo.Items.Add(Convert.ToString(ChrW(9661))) ' "▽" 'convert to string, or else there are problems elsewhere in READ and save
        ''   combo.Items.Add(Convert.ToString(ChrW(9651))) ' "△"


        'combo.Items.Add(Standard.method7)
        AppTableDisplay.Columns.Add(combo)

        AppTableDisplay.Columns.Add("Depth", "Depth (cm)")
        ' AppTableDisplay.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        AppTableDisplay.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        AppTableDisplay.Columns(3).Width = 42

        AppTableDisplay.Columns.Add("Split", "Split")
        '    AppTableDisplay.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        AppTableDisplay.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        AppTableDisplay.Columns(4).Width = 44


        Dim driftcombo As New DataGridViewComboBoxColumn With {
            .HeaderText = "Drift Type",
            .DropDownWidth = 220,
            .Width = 160
        }

        driftcombo.Items.Add(Standard.sprayterm1)
        driftcombo.Items.Add(Standard.sprayterm2)
        driftcombo.Items.Add(Standard.sprayterm3)
        driftcombo.Items.Add(Standard.sprayterm4)
        driftcombo.Items.Add(Standard.sprayterm5)
        driftcombo.Items.Add(Standard.sprayterm6)
        driftcombo.Items.Add(Standard.sprayterm7)
        driftcombo.Items.Add(Standard.sprayterm8)
        driftcombo.Items.Add(Standard.sprayterm9)
        driftcombo.Items.Add(Standard.sprayterm10)
        driftcombo.Items.Add(Standard.sprayterm11)
        driftcombo.Items.Add(Standard.sprayterm12)
        driftcombo.Items.Add(Standard.sprayterm13)
        driftcombo.Items.Add(Standard.sprayterm14)
        driftcombo.Items.Add(Standard.sprayterm15)
        driftcombo.Items.Add(Standard.sprayterm16)

        AppTableDisplay.Columns.Add(driftcombo)


        'AppTableDisplay.Columns.Add("Drift", "Drift")
        '' AppTableDisplay.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'AppTableDisplay.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        'AppTableDisplay.Columns(5).Width = 80

        AppTableDisplay.Columns.Add("Buffer", "Drift Buffer (ft)")
        'AppTableDisplay.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        AppTableDisplay.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
        AppTableDisplay.Columns(6).Width = 64

        AppTableDisplay.Columns.Add("Periodicity", "Period")
        'AppTableDisplay.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        AppTableDisplay.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable
        AppTableDisplay.Columns(7).Width = 56

        AppTableDisplay.Columns.Add("Lag", "Lag")
        '  AppTableDisplay.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        AppTableDisplay.Columns(8).SortMode = DataGridViewColumnSortMode.NotSortable
        AppTableDisplay.Columns(8).Width = 42

        Dim btn As New DataGridViewButtonColumn()
        btn.Text = "delete"
        btn.HeaderText = "Delete"
        btn.Name = "Delete"
        btn.UseColumnTextForButtonValue = True
        btn.FlatStyle = FlatStyle.Popup
        btn.DefaultCellStyle.BackColor = Color.Orange

        AppTableDisplay.Columns.Add(btn)
        AppTableDisplay.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub RunoffGridView_RowPostPaint(ByVal sender As Object, ByVal e As DataGridViewRowPostPaintEventArgs)
        'Adds line numbers to the runoff table
        Using b As SolidBrush = New SolidBrush(HydroDataGrid.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(e.RowIndex + 1, HydroDataGrid.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4)
        End Using
    End Sub



    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click

        Dim result As System.Windows.Forms.DialogResult

        SaveFileDialogMain.Filter = "PWC 3 INPUT Files (*.PW3)|*.PW3|ALL Files (*.*)|*.*"
        SaveFileDialogMain.FilterIndex = 1

        SaveFileDialogMain.InitialDirectory = FiLENames.WorkingDirectory
        SaveFileDialogMain.FiLEName = ""
        result = SaveFileDialogMain.ShowDialog(Me)

        'Cancel button will cuase return without further execution
        If result = Windows.Forms.DialogResult.Cancel THEN
            Return
        END IF

        FiLENames.InputFiLEName = SaveFileDialogMain.FiLEName


        FiLENames.WorkingDirectory = System.IO.Path.GetDirectoryName(SaveFileDialogMain.FiLEName) & "\"
        WorkingDirectoryLabel.Text = FiLENames.WorkingDirectory
        SaveFileDialogMain.InitialDirectory = WorkingDirectoryLabel.Text

        IOFamilyName.Text = System.IO.Path.GetFiLENameWithoutExtension(SaveFileDialogMain.FiLEName)

        SaveInputsAsTextFile(SaveFileDialogMain.FiLEName)

    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            TextBox2.Text = Chr(TextBox3.Text)
        Catch ex As Exception

        End Try

        Try
            TextBox5.Text = ChrW(TextBox3.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WorkingDirectoryLabel_DoubleClick(sender As Object, e As EventArgs) Handles WorkingDirectoryLabel.DoubleClick
        'Go to directory if it exists

        If System.IO.Directory.Exists(WorkingDirectoryLabel.Text) THEN
            Process.Start("explorer.exe", WorkingDirectoryLabel.Text)
        Else
            Return
        END IF
    End Sub

    Private Sub WorkingDirectoryLabel_MouseEnter(sender As Object, e As EventArgs) Handles WorkingDirectoryLabel.MouseEnter
        If System.IO.Directory.Exists(WorkingDirectoryLabel.Text) THEN
            WorkingDirectoryLabel.ForeColor = Color.Blue
        Else
            Return
        END IF
    End Sub

    Private Sub WorkingDirectoryLabel_MouseLeave(sender As Object, e As EventArgs) Handles WorkingDirectoryLabel.MouseLeave
        WorkingDirectoryLabel.ForeColor = Color.Black
    End Sub

    Private Sub RetrieveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RetrieveToolStripMenuItem.Click
        Dim result As System.Windows.Forms.DialogResult

        RetrieveMainInput.Filter = "PWC 3 INPUT Files (*.PW3)|*.PW3|ALL Files (*.*)|*.*"

        'Opens the desktop if there is no previous open
        If System.IO.Directory.Exists(FiLENames.WorkingDirectory) THEN
            RetrieveMainInput.InitialDirectory = FiLENames.WorkingDirectory
        Else
            '  RetrieveMainInput.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        END IF

        RetrieveMainInput.FiLEName = ""

        result = RetrieveMainInput.ShowDialog(Me)

        'Cancel button will cause return without further execution
        If result = Windows.Forms.DialogResult.Cancel THEN
            Return
        END IF

        FiLENames.WorkingDirectory = System.IO.Path.GetDirectoryName(RetrieveMainInput.FiLEName) & "\"

        READInputsFromTextFile(RetrieveMainInput.FiLEName)

        'disable all edit buttons in scheme table on first retrieve
        Dim buttonCell As DataGridViewDisableButtonCell
        For i As INTEGER = 0 To SchemeTableDisplay.RowCount - 1
            buttonCell = CType(SchemeTableDisplay.Rows(i).Cells("Commit"), DataGridViewDisableButtonCell)
            buttonCell.Enabled = False
        Next

        'Disable the last new row button
        buttonCell = CType(SchemeTableDisplay.Rows(SchemeTableDisplay.Rows.Count - 1).Cells("Delete"), DataGridViewDisableButtonCell)
        buttonCell.Enabled = False


    End Sub

    Private Sub CalculateButton_Click(sender As Object, e As EventArgs) Handles CalculateButton.Click


        If Not System.IO.Directory.Exists(WorkingDirectoryLabel.Text) THEN
            MsgBox("No Working Directory. Save this work, And a working directory will be automatcally established")
            Return
        END IF

        System.IO.Directory.SetCurrentDirectory(WorkingDirectoryLabel.Text)

        Dim isCorrect As Boolean
        Dim WarningMessage As String = ""
        CheckChemicalInputs(isCorrect, WarningMessage)
        If Not isCorrect THEN
            MsgBox(WarningMessage)
            Return
        END IF


        RunPRZMandVVWM()



    End Sub

    Private Sub YearlyCycleButton_CheckedChanged(sender As Object, e As EventArgs)

        If HydroDataGrid.IsHandleCreated THEN ' need this to prevent firing at load time before grid is available
            If YearlyCycleButton.Checked THEN
                HydroDataGrid.Columns(0).HeaderText = "Date (m/d)"
            Else
                HydroDataGrid.Columns(0).HeaderText = "Date (m/d/y)"
            END IF
        END IF

    End Sub

    Private Sub EvergreenCheckbox_CheckedChanged(sender As Object, e As EventArgs)
        If Evergreen.Checked THEN
            EvergreenPanel.Visible = True
            CropGridView.Visible = False
        Else
            EvergreenPanel.Visible = False
            CropGridView.Visible = True
        END IF
    End Sub





    Private Sub AbsoluteDaysButton_CheckedChanged(sender As Object, e As EventArgs) Handles AbsoluteDaysButton.CheckedChanged, emerge.CheckedChanged

        If AppTableDisplay.IsHandleCreated THEN
            If AbsoluteDaysButton.Checked THEN
                AppTableDisplay.Columns(0).Name = "Date"
            Else
                AppTableDisplay.Columns(0).Name = "Days"
            END IF
        END IF

    End Sub

    Private Sub GetWeatherFileDirectory_Click(sender As Object, e As EventArgs) Handles GetWeatherFileDirectory.Click
        Dim result As System.Windows.Forms.DialogResult

        result = WeatherFolderBrowser.ShowDialog(Me)

        'Cancel button will cuase return without further execution
        If result = Windows.Forms.DialogResult.Cancel THEN
            Return
        END IF

        WeatherDirectoryBox.Text = WeatherFolderBrowser.SelectedPath & "\"
    End Sub

    Private Sub GetWeatherFile_Click(sender As Object, e As EventArgs) Handles GetWeatherFile.Click
        Dim result As System.Windows.Forms.DialogResult
        GetWeatherFileDialog.Filter = "WEA files (*.WEA)|*.WEA|All files (*.*)|*.*"

        If System.IO.Directory.Exists(FiLENames.PreviousWeatherPath) THEN
            GetWeatherFileDialog.InitialDirectory = FiLENames.PreviousWeatherPath
        END IF

        result = GetWeatherFileDialog.ShowDialog() 'display Open dialog box

        'Cancel button will cuase return without further execution
        If result = Windows.Forms.DialogResult.Cancel THEN
            Return
        END IF

        WeatherFiLEName.Text = System.IO.Path.GetFiLEName(GetWeatherFileDialog.FiLEName)
        WeatherDirectoryBox.Text = System.IO.Path.GetDirectoryName(GetWeatherFileDialog.FiLEName) & "\"

        FiLENames.PreviousWeatherPath = System.IO.Path.GetDirectoryName(GetWeatherFileDialog.FiLEName)

    End Sub

    ' This event handler manually raises the CellValueChanged event
    ' by calling the CommitEdit method.
    Public Sub DataGridView1_CurrentCellDirtyStateChanged(
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles SchemeTableDisplay.CurrentCellDirtyStateChanged

        If SchemeTableDisplay.IsCurrentCellDirty THEN
            SchemeTableDisplay.CommitEdit(DataGridViewDataErrorContexts.Commit)
        END IF
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles SchemeTableDisplay.CellContentClick

        Dim NumberofApplications As INTEGER
        Dim ApplicationTable As New SchemeDetails With {
            .Days = New List(Of String),
            .Amount = New List(Of String),
            .Method = New List(Of String),
            .Depth = New List(Of String),
            .Split = New List(Of String),
            .Drift = New List(Of String),
            .Lag = New List(Of String),
            .Periodicity = New List(Of String),
            .Scenarios = New List(Of String)
        } 'local for picking up schem inforation

        Dim Description As String
        Dim SchemeLabels As String
        Dim DisplayedSchemeNumber As INTEGER

        If e.RowIndex < 0 THEN
            Exit Sub
        END IF

        Select Case SchemeTableDisplay.Columns(e.ColumnIndex).Name
                Case "Edit"

                    'clear all got it
                    For i As INTEGER = 0 To SchemeTableDisplay.RowCount - 1
                        SchemeTableDisplay.Rows(i).Cells("Commit").Value = ""
                    Next

                'this if statement ensures that all buttons are deactivated when unchecked
                If SchemeTableDisplay.Rows(e.RowIndex).Cells("Edit").Value = True THEN

                    For Each oRow As DataGridViewRow In SchemeTableDisplay.Rows
                        oRow.Cells("Edit").Value = False
                    Next
                    SchemeTableDisplay.Rows(e.RowIndex).Cells("Edit").Value = True

                    'toggle scenario and app tab on if checked
                    If TabControl1.Controls.Contains(tempTabpage5) = False THEN
                        'tab 5 and 6 are always together, so only need to see if oe or the other is active
                        TabControl1.Controls.Add(tempTabpage5)
                        TabControl1.Controls.Add(tempTabpage6)
                    END IF

                Else
                    For Each oRow As DataGridViewRow In SchemeTableDisplay.Rows
                        oRow.Cells("Edit").Value = False
                    Next

                    'toggle off scenario and app tab if nothing checked
                    TabControl1.Controls.Remove(SchemeApplicationsTab)
                    TabControl1.Controls.Remove(SchemeScenariosTab)
                END IF


                If SchemeTableDisplay.Columns(e.ColumnIndex).Name = "Edit" THEN
                        Dim buttonCell As DataGridViewDisableButtonCell
                        Dim checkCell As DataGridViewCheckBoxCell = CType(SchemeTableDisplay.Rows(e.RowIndex).Cells("Edit"), DataGridViewCheckBoxCell)

                        For i As INTEGER = 0 To SchemeTableDisplay.RowCount - 1
                            buttonCell = CType(SchemeTableDisplay.Rows(i).Cells("Commit"), DataGridViewDisableButtonCell)
                            buttonCell.Enabled = False

                            'dont allow scheme description to be edited unless checked
                            SchemeTableDisplay.Rows(i).Cells(3).READOnly = True
                        Next

                        '________________________________________________________________________
                        'When a new row is created, Make the delete button imediatelty active and disable the new button


                        If (SchemeTableDisplay.Rows.Count - 2 = e.RowIndex) THEN
                            buttonCell = CType(SchemeTableDisplay.Rows(e.RowIndex).Cells("Delete"), DataGridViewDisableButtonCell)
                            buttonCell.Enabled = True
                            buttonCell = CType(SchemeTableDisplay.Rows(e.RowIndex + 1).Cells("Delete"), DataGridViewDisableButtonCell)
                            buttonCell.Enabled = False
                        END IF

                    '_______________________________________________

                    'allow only active scheme description to be edited
                    SchemeTableDisplay.Rows(e.RowIndex).Cells(3).READOnly = False

                        buttonCell = CType(SchemeTableDisplay.Rows(e.RowIndex).Cells("Commit"), DataGridViewDisableButtonCell)

                        buttonCell.Enabled = CType(checkCell.Value, [Boolean])

                        SchemeTableDisplay.Invalidate()
                    END IF

                    Description = SchemeTableDisplay.Rows(e.RowIndex).Cells(3).Value

                    DisplayedSchemeNumber = e.RowIndex + 1
                    SchemeLabels = DisplayedSchemeNumber & " " & Description

                    Label88.Text = SchemeLabels
                    Label87.Text = SchemeLabels

                    If SchemeInfoList.Count - 1 < e.RowIndex THEN
                        'in case edit button is pushed before anything is populated previously an error will not throw
                        Exit Sub
                    END IF

                    ApplicationTable = SchemeInfoList(e.RowIndex)

                    NumberofApplications = ApplicationTable.Days.Count
                    AppTableDisplay.Rows.Clear()

                If NumberofApplications > 0 THEN  'prevents error if user attempts to save without any applications
                    AppTableDisplay.Rows.Add(NumberofApplications)

                    For i As INTEGER = 0 To NumberofApplications - 1
                        AppTableDisplay.Item(0, i).Value = ApplicationTable.Days(i)
                        AppTableDisplay.Item(1, i).Value = ApplicationTable.Amount(i)


                        Select Case (ApplicationTable.Method(i))
                            Case (1)
                                AppTableDisplay.Item(2, i).Value = Standard.method1
                            Case (2)
                                AppTableDisplay.Item(2, i).Value = Standard.method2
                            Case (3)
                                AppTableDisplay.Item(2, i).Value = Standard.method3
                            Case (4)
                                AppTableDisplay.Item(2, i).Value = Standard.method4
                            Case (5)
                                AppTableDisplay.Item(2, i).Value = Standard.method5
                            Case (6)
                                AppTableDisplay.Item(2, i).Value = Standard.method6
                            Case (7)
                                AppTableDisplay.Item(2, i).Value = Standard.method7
                            Case Else
                                AppTableDisplay.Item(2, i).Value = Standard.method1
                        End Select


                        AppTableDisplay.Item(3, i).Value = ApplicationTable.Depth(i)
                        AppTableDisplay.Item(4, i).Value = ApplicationTable.Split(i)
                        '   AppTableDisplay.Item(5, i).Value = ApplicationTable.Drift(i)

                        Select Case ApplicationTable.Drift(i)
                            Case 1
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm1
                            Case 2
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm2
                            Case 3
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm3
                            Case 4
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm4
                            Case (5)
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm5
                            Case (6)
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm6
                            Case (7)
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm7
                            Case (8)
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm8
                            Case (9)
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm9
                            Case (10)
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm10
                            Case (11)
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm11
                            Case (12)
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm12
                            Case (13)
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm13
                            Case (14)
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm14
                            Case (15)
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm15
                            Case (16)
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm16
                        End Select


                        AppTableDisplay.Item(6, i).Value = ApplicationTable.DriftBuffer(i)
                        AppTableDisplay.Item(7, i).Value = ApplicationTable.Periodicity(i)
                        AppTableDisplay.Item(8, i).Value = ApplicationTable.Lag(i)

                    Next
                END IF


                AbsoluteDaysButton.Checked = ApplicationTable.AbsoluteRelative

                emerge.Checked = ApplicationTable.Emerge
                maturity.Checked = ApplicationTable.Maturity
                removal.Checked = ApplicationTable.Removal

                UseApplicationWindow.Checked = ApplicationTable.UseApplicationWindow
                ApplicationWindowDays.Text = ApplicationTable.ApplicationWindowSpan
                ApplicationWindowStep.Text = ApplicationTable.ApplicationWindowStep

                UseRainFast.Checked = ApplicationTable.UseRainFast
                RainLimit.Text = ApplicationTable.RainLimit
                IntolerableRainWindow.Text = ApplicationTable.IntolerableRainWindow
                OptimumApplicationWindow.Text = ApplicationTable.OptimumApplicationWindow
                MinDaysBetweenApps.Text = ApplicationTable.MinDaysBetweenApps
                GetScenariosBatchCheckBox.Checked = ApplicationTable.UseBatchScenarioFile
                ScenarioBatchFiLEName.Text = ApplicationTable.ScenarioBatchFiLEName

                RunoffMitigation.Text = ApplicationTable.RunoffMitigation
                ErosionMitigation.Text = ApplicationTable.ErosionMitigation
                DriftMitigation.Text = ApplicationTable.DriftMitigation

                ScenarioListBox.Items.Clear()
                    For Each ee As String In ApplicationTable.Scenarios
                        ScenarioListBox.Items.Add(ee)
                    Next

                Case "Commit"



                    ' Some error messages have been arising in here ...

                    '    'Disabling button apparently does not REALly disable its action, only its color
                    '    'So I added the following IF to kick out of the commit button if the edit box is not checked



                    If SchemeTableDisplay.Rows(e.RowIndex).Cells("Edit").Value = False THEN
                        Exit Sub
                    END IF


                    'same set of lines as in EDIT above, but needed because if you change scheme description
                    'without unchecking and rechecking EDIT, THEN the labvels will not be loaded
                    Description = SchemeTableDisplay.Rows(e.RowIndex).Cells(3).Value

                    DisplayedSchemeNumber = e.RowIndex + 1
                    SchemeLabels = DisplayedSchemeNumber & " " & Description

                    Label88.Text = SchemeLabels
                    Label87.Text = SchemeLabels


                    For i As INTEGER = 0 To SchemeTableDisplay.RowCount - 1
                        SchemeTableDisplay.Rows(i).Cells(e.ColumnIndex).Value = ""
                    Next

                    RecordScheme(e.RowIndex)

                    SchemeTableDisplay.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "got it"

                    Timer1.Start()



                Case "Delete"




                    If SchemeTableDisplay.CurrentRow.IsNewRow THEN
                        Beep()
                    Else
                        'toggle off scenario and app tab if delete the checked scheme 

                        If SchemeTableDisplay.Rows(e.RowIndex).Cells(1).Value THEN
                            TabControl1.Controls.Remove(SchemeApplicationsTab)
                            TabControl1.Controls.Remove(SchemeScenariosTab)
                        END IF



                        SchemeTableDisplay.Rows.Remove(SchemeTableDisplay.Rows(e.RowIndex))
                    END IF

                    If SchemeInfoList.Count > e.RowIndex THEN
                        'this if condition is needed if there is an uncommitted row, THEN you can still delete it
                        'likewise if there is an uncommited row, THEN this prevents attempting to delete a nonexistent scheme
                        'only want to delete table row, and not schemeinfolist item

                        SchemeInfoList.RemoveAt(e.RowIndex)
                    END IF



                Case Else
                    Exit Sub
            End Select





    End Sub


    Private Sub SchemeTableDisplay_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles SchemeTableDisplay.CellMouseEnter

        If e.RowIndex < 0 THEN
            Exit Sub
        END IF

        Dim buttonCell As DataGridViewDisableButtonCell
        buttonCell = CType(SchemeTableDisplay.Rows(e.RowIndex).Cells("Delete"), DataGridViewDisableButtonCell)

        'this logic signifies a new row,;iterally "isnewrow" does not work so resorted to this.
        If (SchemeTableDisplay.Rows.Count - 1 = e.RowIndex) THEN
            buttonCell.Enabled = False
            SchemeTableDisplay.Invalidate()  'redraw
            Exit Sub
        Else
            buttonCell.Enabled = True
        END IF


        SchemeTableDisplay.Invalidate()  'redraw



        Select Case SchemeTableDisplay.Columns(e.ColumnIndex).Name
            Case "Delete"

                SchemeTableDisplay.Rows(e.RowIndex).Cells("Delete").Value = "Delete"


            Case "Commit"
                If SchemeTableDisplay.Rows(e.RowIndex).Cells("Edit").Value = True THEN
                    SchemeTableDisplay.Rows(e.RowIndex).Cells("Commit").Value = "Commit"
                END IF
        End Select

    End Sub

    Private Sub SchemeTableDisplay_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles SchemeTableDisplay.CellMouseLeave
        If e.RowIndex < 0 THEN
            Exit Sub
        END IF

        Select Case SchemeTableDisplay.Columns(e.ColumnIndex).Name
            Case "Delete"
                SchemeTableDisplay.Rows(e.RowIndex).Cells("Delete").Value = ""
            Case "Commit"
                SchemeTableDisplay.Rows(e.RowIndex).Cells("Commit").Value = ""
        End Select
    End Sub




    Private Sub SchemeTableDisplay_SelectionChanged(sender As Object, e As EventArgs) Handles SchemeTableDisplay.SelectionChanged

        'Prevents adding new schemes until previous scheme is committed. It does this by checking whether the rows
        ' in the SchemeTableDisplay equal the number items of items in the SchemeInfoList, specifically by checking:
        '(SchemeInfoList.Count vs. SchemeTableDisplay.Rows.Count - 1)


        If SchemeTableDisplay.CurrentRow.IsNewRow THEN  'schemes can only be added on the "new row"

            If SchemeInfoList.Count < SchemeTableDisplay.Rows.Count - 1 THEN  'Previous row is not committed

                SchemeTableDisplay.CurrentRow.Cells(3).READOnly = True  'Current row is new row, so no entry allowed util commit
                '  SchemeTableDisplay.CurrentRow.Cells(1).Value = False    'clear any checks
                SchemeTableDisplay.CurrentRow.Cells(1).READOnly = True  'dont allow any checks in edit box
                MsgBox("Previous scheme has never been committed. Commit that scheme before adding another scheme")
            Else
                SchemeTableDisplay.CurrentRow.Cells(1).READOnly = False   'allow the edit box to be checked
            END IF

        Else


            'prevents previous row from being editable without checkbox after a new row has been populated
            If SchemeTableDisplay.CurrentRow.Cells(1).Value = False THEN
                SchemeTableDisplay.CurrentRow.Cells(3).READOnly = True
            Else
                SchemeTableDisplay.CurrentRow.Cells(3).READOnly = False
            END IF



        END IF



    End Sub






    Private Sub SelectScenarios_Click(sender As Object, e As EventArgs) Handles SelectScenarios.Click
        Dim result As System.Windows.Forms.DialogResult

        OpenAndSelectScenarios.Filter = "Scenario Files V2 (*.SCN2)|*.SCN2| All files (*.*)|*.*"

        OpenAndSelectScenarios.InitialDirectory = FiLENames.DefaultScenarioDirectory

        If System.IO.Directory.Exists(FiLENames.PreviousScenarioPath) THEN
            OpenAndSelectScenarios.InitialDirectory = FiLENames.PreviousScenarioPath
        END IF

        result = OpenAndSelectScenarios.ShowDialog() 'display Open dialog box
        'Cancel button will cuase return without further execution
        If result = Windows.Forms.DialogResult.Cancel THEN
            Return
        END IF

        FiLENames.PreviousScenarioPath = System.IO.Path.GetDirectoryName(OpenAndSelectScenarios.FiLEName)
        Dim selectedScenario As String

        For Each selectedScenario In OpenAndSelectScenarios.FiLENames
            ' ScenariosList.Items.Add(System.IO.Path.GetFiLEName(selectedScenario))
            'need path
            ScenarioListBox.Items.Add(selectedScenario)
        Next

        FiLENames.PreviousScenarioPath = System.IO.Path.GetDirectoryName(OpenAndSelectScenarios.FiLEName)

    End Sub

    Private Sub ClearSelectedScenarios_Click(sender As Object, e As EventArgs) Handles ClearSelectedScenarios.Click
        Dim selectedScenario As String
        Dim selectedScenarios = (From i In ScenarioListBox.SelectedItems).ToArray()

        For Each selectedScenario In selectedScenarios
            ScenarioListBox.Items.Remove(selectedScenario)
        Next
    End Sub

    Private Sub ClearAllScenarios_Click(sender As Object, e As EventArgs) Handles ClearAllScenarios.Click
        ScenarioListBox.Items.Clear()
    End Sub

    Private Sub SchemeTableDisplay_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles SchemeTableDisplay.RowPostPaint
        'Adds line numbers to the scheme table
        Using b As SolidBrush = New SolidBrush(SchemeTableDisplay.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(e.RowIndex + 1, SchemeTableDisplay.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    Private Sub DoDegradate1_CheckedChanged(sender As Object, e As EventArgs) Handles DoDegradate1.CheckedChanged
        If DoDegradate1.Checked = False THEN
            DoDegradate2.Checked = False
            DoDegradate2.Enabled = False
            DaughterVisibleStatus(False)
        Else
            DoDegradate2.Enabled = True
            DaughterVisibleStatus(True)
        END IF
    End Sub

    Private Sub DoDegradate2_CheckedChanged(sender As Object, e As EventArgs) Handles DoDegradate2.CheckedChanged
        If DoDegradate2.Checked = False THEN
            GrandaughterVisibleStatus(False)
        Else
            GrandaughterVisibleStatus(True)
        END IF
    End Sub


    Private Sub GrandaughterVisibleStatus(status As Boolean)
        sorption3.Visible = status
        WaterColMetab3.Visible = status
        WaterColRef3.Visible = status
        BenthicMetab3.Visible = status
        BenthicRef3.Visible = status
        Photo3.Visible = status
        PhotoLat3.Visible = status
        Hydrolysis3.Visible = status
        SoilDegradation3.Visible = status
        SoilRef3.Visible = status
        FoliarDeg3.Visible = status
        FoliarWashoff3.Visible = status
        MWT3.Visible = status
        VaporPress3.Visible = status
        Sol3.Visible = status
        Henry3.Visible = status
        AirDiff3.Visible = status
        HeaTHENry3.Visible = status

        WaterMolarRatio2.Visible = status
        BenthicMolarRatio2.Visible = status
        PhotoMolarRatio2.Visible = status
        HydroMolarRatio2.Visible = status
        SoilMolarRatio2.Visible = status
        FoliarMolarRatio2.Visible = status


    End Sub

    Private Sub DaughterVisibleStatus(status As Boolean)

        sorption2.Visible = status
        WaterColMetab2.Visible = status
        WaterColRef2.Visible = status
        BenthicMetab2.Visible = status
        BenthicRef2.Visible = status
        Photo2.Visible = status
        PhotoLat2.Visible = status
        Hydrolysis2.Visible = status
        SoilDegradation2.Visible = status
        SoilRef2.Visible = status
        FoliarDeg2.Visible = status
        FoliarWashoff2.Visible = status
        MWT2.Visible = status
        VaporPress2.Visible = status
        Sol2.Visible = status
        Henry2.Visible = status
        AirDiff2.Visible = status
        HeaTHENry2.Visible = status

        WaterMolarRatio1.Visible = status
        BenthicMolarRatio1.Visible = status
        PhotoMolarRatio1.Visible = status
        HydroMolarRatio1.Visible = status
        SoilMolarRatio1.Visible = status
        FoliarMolarRatio1.Visible = status


    End Sub






    Private Sub ItsOther_CheckedChanged(sender As Object, e As EventArgs) Handles ItsOther.CheckedChanged
        'If ItsOther.Checked THEN
        '    waterbodypanel.Visible = True
        'Else
        '    waterbodypanel.Visible = False
        'END IF
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As System.Windows.Forms.DialogResult

        OpenAndSelectScenarios.Filter = "Water Body Files (*.WAT)|*.WAT| All files (*.*)|*.*"

        OpenAndSelectScenarios.InitialDirectory = FiLENames.DefaultWaterBodyDirectory

        If System.IO.Directory.Exists(FiLENames.PreviousWaterBodyPath) THEN
            OpenAndSelectScenarios.InitialDirectory = FiLENames.PreviousWaterBodyPath
        END IF

        result = OpenAndSelectScenarios.ShowDialog() 'display Open dialog box
        'Cancel button will cuase return without further execution
        If result = Windows.Forms.DialogResult.Cancel THEN
            Return
        END IF

        FiLENames.PreviousWaterBodyPath = System.IO.Path.GetDirectoryName(OpenAndSelectScenarios.FiLEName)
        Dim selectedScenario As String

        For Each selectedScenario In OpenAndSelectScenarios.FiLENames
            ' ScenariosList.Items.Add(System.IO.Path.GetFiLEName(selectedScenario))
            'need path
            WaterbodyList.Items.Add(selectedScenario)
        Next

        FiLENames.PreviousScenarioPath = System.IO.Path.GetDirectoryName(OpenAndSelectScenarios.FiLEName)



    End Sub

    Private Sub ClearSelectedWaterBody_Click(sender As Object, e As EventArgs) Handles ClearSelectedWaterBody.Click
        Dim WaterBody As String

        Dim selectedWaterBodies = (From i In WaterbodyList.SelectedItems).ToArray()

        For Each WaterBody In selectedWaterBodies
            WaterbodyList.Items.Remove(WaterBody)
        Next
    End Sub

    Private Sub ClearAllWaterBodies_Click(sender As Object, e As EventArgs) Handles ClearAllWaterBodies.Click
        WaterbodyList.Items.Clear()
    End Sub

    Private Sub PushToLoadScenario_Click(sender As Object, e As EventArgs) Handles PushToLoadScenario.Click

        If LoadFromCSV.Checked THEN
            OpenSingleScenarioFile.Filter = "Batch CSV Files (*.CSV)|*.CSV"
        Else
            OpenSingleScenarioFile.Filter = "Scenario Files (*.SCN2)|*.SCN2"
        END IF


        If System.IO.Directory.Exists(FiLENames.PreviousScenarioPath) THEN
            OpenSingleScenarioFile.InitialDirectory = FiLENames.PreviousScenarioPath
        Else
            OpenSingleScenarioFile.InitialDirectory = FiLENames.DefaultScenarioDirectory
        END IF

        Dim result As System.Windows.Forms.DialogResult
        result = OpenSingleScenarioFile.ShowDialog(Me)

        'Cancel button will cuase return without further execution
        If result = Windows.Forms.DialogResult.Cancel THEN
            Return
        END IF

        FiLENames.PreviousScenarioPath = System.IO.Path.GetDirectoryName(OpenSingleScenarioFile.FiLEName)

        If LoadFromCSV.Checked THEN
            LoadSingleBatchFileScenario(OpenSingleScenarioFile.FiLEName)
        Else
            READScenarioPARAMETERs(OpenSingleScenarioFile.FiLEName)
        END IF






    End Sub

    Private Sub PushToSaveScenario_Click(sender As Object, e As EventArgs) Handles PushToSaveScenario.Click

        Dim result As System.Windows.Forms.DialogResult

        SaveSingleScenarioFile.Filter = "Scenario Files V2 (*.scn2)|*.SCN2"
        SaveSingleScenarioFile.InitialDirectory = FiLENames.PreviousCustomScenarioPath

        'make the file default to be the last file retrieved
        SaveSingleScenarioFile.FiLEName = FiLENames.PreviousScenarioFile

        result = SaveSingleScenarioFile.ShowDialog(Me)

        'Cancel button will cuase return without further execution
        If result = Windows.Forms.DialogResult.Cancel THEN
            Return
        END IF

        FiLENames.PreviousScenarioPath = System.IO.Path.GetDirectoryName(SaveSingleScenarioFile.FiLEName)

        Dim msg As String

        msg = CreateScenarioString()

        Try
            My.Computer.FileSystem.WRITEAllText(SaveSingleScenarioFile.FiLEName, msg, False, System.Text.Encoding.ASCII)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub PushToLoadWaterBody_Click(sender As Object, e As EventArgs) Handles PushToLoadWaterBody.Click



        OpenWaterbodyFile.Filter = "Waterbody Files (*.WAT)|*.WAT"

        If System.IO.Directory.Exists(FiLENames.PreviousWaterBodyPath) THEN
            OpenWaterbodyFile.InitialDirectory = FiLENames.PreviousWaterBodyPath
        Else
            OpenWaterbodyFile.InitialDirectory = FiLENames.DefaultScenarioDirectory
        END IF


        Dim result As System.Windows.Forms.DialogResult

        result = OpenWaterbodyFile.ShowDialog(Me)

        'Cancel button will cuase return without further execution
        If result = Windows.Forms.DialogResult.Cancel THEN
            Return
        END IF


        FiLENames.PreviousWaterBodyPath = System.IO.Path.GetDirectoryName(OpenWaterbodyFile.FiLEName)

        READwaterBodyPARAMETERs(OpenWaterbodyFile.FiLEName)


    End Sub

    Private Sub PushToSaveWaterBody_Click(sender As Object, e As EventArgs) Handles PushToSaveWaterBody.Click


        Dim result As System.Windows.Forms.DialogResult

        SaveWaterbodyFile.Filter = "Waterbody Files (*.WAT)|*.WAT|ALL Files (*.*)|*.*"
        SaveWaterbodyFile.InitialDirectory = FiLENames.PreviousWaterBodyPath

        'make the file default to be the last file retrieved
        SaveWaterbodyFile.FiLEName = FiLENames.PreviousScenarioFile

        result = SaveWaterbodyFile.ShowDialog(Me)

        'Cancel button will cuase return without further execution
        If result = Windows.Forms.DialogResult.Cancel THEN
            Return
        END IF

        FiLENames.PreviousWaterBodyPath = System.IO.Path.GetDirectoryName(SaveWaterbodyFile.FiLEName)

        Dim msg As String

        msg = CreateWaterbodyString()

        Try
            My.Computer.FileSystem.WRITEAllText(SaveWaterbodyFile.FiLEName, msg, False, System.Text.Encoding.ASCII)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim a As INTEGER
        Dim b As INTEGER
        a = SchemeTableDisplay.CurrentCell.RowIndex
        b = SchemeTableDisplay.CurrentCell.ColumnIndex
        SchemeTableDisplay.Rows(a).Cells(b).Value = ""
        Timer1.Stop()
    End Sub
    Private Sub ToggleAdvancedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToggleAdvancedToolStripMenuItem.Click
        If TabControl1.Controls.Contains(tempTabpage1) THEN
            TabControl1.Controls.Remove(AdvancedTab)
            Return
        END IF
        TabControl1.Controls.Add(tempTabpage1)
    End Sub
    Private Sub ToggleScenarioExaminerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToggleScenarioExaminerToolStripMenuItem.Click
        If TabControl1.Controls.Contains(tempTabpage2) THEN
            TabControl1.Controls.Remove(ScenarioExaminerTab)
            Return
        END IF
        TabControl1.Controls.Add(tempTabpage2)
    End Sub


    Private Sub ToggeWaterbodyExaminerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToggeWaterbodyExaminerToolStripMenuItem.Click
        If TabControl1.Controls.Contains(tempTabpage4) THEN
            TabControl1.Controls.Remove(WaterbodyExaminerTab)
            Return
        END IF
        TabControl1.Controls.Add(tempTabpage4)
    End Sub



    Private Sub ToggleMoreOutputToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToggleMoreOutputToolStripMenuItem.Click
        If TabControl1.Controls.Contains(tempTabpage3) THEN
            TabControl1.Controls.Remove(OptionalOutputTab)
            Return
        END IF
        TabControl1.Controls.Add(tempTabpage3)
    End Sub














    Private Sub AdditionalOutputGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles AdditionalOutputGridView.CellContentClick


        If AdditionalOutputGridView.Columns(e.ColumnIndex).HeaderText = "Delete" THEN
            If AdditionalOutputGridView.CurrentRow.IsNewRow THEN
                Beep()
            Else
                AdditionalOutputGridView.Rows.Remove(AdditionalOutputGridView.Rows(e.RowIndex))
            END IF
        END IF




    End Sub

    Private Sub AppTableDisplay_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles AppTableDisplay.CellContentClick, AppTableDisplay.CellValueChanged


        Select Case AppTableDisplay.Columns(e.ColumnIndex).Name

            Case "Delete"

                If AppTableDisplay.CurrentRow.IsNewRow THEN

                    Beep()
                Else

                    'AppTableDisplay.Rows.Remove(AppTableDisplay.Rows(AppTableDisplay.SelectedCells.Item(0).RowIndex))

                    AppTableDisplay.Rows.Remove(AppTableDisplay.Rows(e.RowIndex))
                    Exit Sub

                    AppTableDisplay.ClearSelection()

                END IF


            Case Else

                If e.RowIndex > -1 THEN
                    Select Case AppTableDisplay.Rows(e.RowIndex).Cells(2).Value
                        Case Standard.method1, Standard.method2                    'above and below crop
                            AppTableDisplay.Rows(e.RowIndex).Cells(3).Value = "4.0"
                            AppTableDisplay.Rows(e.RowIndex).Cells(4).Value = "0.0"

                            AppTableDisplay.Rows(e.RowIndex).Cells(3).READOnly = True
                            AppTableDisplay.Rows(e.RowIndex).Cells(4).READOnly = True
                            AppTableDisplay.Item(3, e.RowIndex).Style.ForeColor = Color.Gray
                            AppTableDisplay.Item(4, e.RowIndex).Style.ForeColor = Color.Gray


                        Case Standard.method3, Standard.method4, Standard.method6, Standard.method7      'Uniform and triangles
                            AppTableDisplay.Rows(e.RowIndex).Cells(4).Value = "0.0"

                            AppTableDisplay.Item(3, e.RowIndex).Style.ForeColor = Color.Black
                            AppTableDisplay.Item(4, e.RowIndex).Style.ForeColor = Color.Gray
                            AppTableDisplay.Rows(e.RowIndex).Cells(3).READOnly = False
                            AppTableDisplay.Rows(e.RowIndex).Cells(4).READOnly = True


                        Case Else
                            AppTableDisplay.Item(3, e.RowIndex).Style.ForeColor = Color.Black
                            AppTableDisplay.Item(4, e.RowIndex).Style.ForeColor = Color.Black
                            AppTableDisplay.Rows(e.RowIndex).Cells(3).READOnly = False
                            AppTableDisplay.Rows(e.RowIndex).Cells(4).READOnly = False

                    End Select


                END IF



        End Select

    End Sub

    Private Sub EstimateHenryConst_Click(sender As Object, e As EventArgs) Handles EstimateHenryConst.Click

        Dim henryConstant As Single
        Dim TrueOrFalse As Boolean
        Dim msg As String

        msg = ""

        If MsgBox("Do you want To overWRITE the Henry's Law value with an estimate based on the solubility and vapor pressure?", 4, "OverWRITE Warning") = 7 THEN
            Return
        END IF


        TestREALNumbers(TrueOrFalse, msg, VaporPress1)

        If TrueOrFalse = False THEN
            MsgBox(msg)


            Return
        END IF

        TestREALNumbers(TrueOrFalse, msg, Sol1)
        If TrueOrFalse = False THEN
            MsgBox(msg)
            Return
        END IF

        TestREALNumbers(TrueOrFalse, msg, MWT1)
        If TrueOrFalse = False THEN
            MsgBox(msg)
            Return
        END IF

        henryConstant = Henry.UnitlessVolumetric(VaporPress1.Text, Sol1.Text, MWT1.Text)
        Henry1.Text = String.Format("{0:G3}", henryConstant)

        If DoDegradate1.Checked THEN
            TestREALNumbers(TrueOrFalse, msg, VaporPress2)
            If TrueOrFalse = False THEN
                MsgBox(msg)
                Return
            END IF

            TestREALNumbers(TrueOrFalse, msg, Sol2)
            If TrueOrFalse = False THEN
                MsgBox(msg)
                Return
            END IF

            TestREALNumbers(TrueOrFalse, msg, MWT2)
            If TrueOrFalse = False THEN
                MsgBox(msg)
                Return
            END IF

            henryConstant = Henry.UnitlessVolumetric(VaporPress2.Text, Sol2.Text, MWT2.Text)
            Henry2.Text = String.Format("{0:G3}", henryConstant)
        END IF

        If DoDegradate2.Checked THEN
            TestREALNumbers(TrueOrFalse, msg, VaporPress3)
            If TrueOrFalse = False THEN
                MsgBox(msg)
                Return
            END IF

            TestREALNumbers(TrueOrFalse, msg, Sol3)
            If TrueOrFalse = False THEN
                MsgBox(msg)
                Return
            END IF

            TestREALNumbers(TrueOrFalse, msg, MWT3)
            If TrueOrFalse = False THEN
                MsgBox(msg)
                Return
            END IF

            henryConstant = Henry.UnitlessVolumetric(VaporPress3.Text, Sol3.Text, MWT3.Text)
            Henry3.Text = String.Format("{0:G3}", henryConstant)
        END IF



    End Sub



    Private Sub HorizonGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles HorizonGridView.CellContentClick

        Select Case HorizonGridView.Columns(e.ColumnIndex).HeaderText
            Case "Delete"

                If HorizonGridView.CurrentRow.IsNewRow THEN
                    Beep()
                Else
                    HorizonGridView.Rows.Remove(HorizonGridView.Rows(e.RowIndex))
                END IF
            Case Else
                Exit Sub

        End Select

    End Sub

    Private Sub SelectScenarioBatchFile_Click(sender As Object, e As EventArgs) Handles SelectScenarioBatchFile.Click
        Dim result As System.Windows.Forms.DialogResult


        OpenSelectScenarioBatchFile.Filter = "Scenario Batch Files (*.CSV)|*.CSV| All files (*.*)|*.*"


        OpenSelectScenarioBatchFile.InitialDirectory = FiLENames.DefaultScenarioDirectory

        If System.IO.Directory.Exists(FiLENames.PreviousScenarioPath) THEN
            OpenSelectScenarioBatchFile.InitialDirectory = FiLENames.PreviousScenarioPath
        END IF

        result = OpenSelectScenarioBatchFile.ShowDialog() 'display Open dialog box
        'Cancel button will cuase return without further execution
        If result = Windows.Forms.DialogResult.Cancel THEN
            Return
        END IF

        FiLENames.PreviousScenarioPath = System.IO.Path.GetDirectoryName(OpenSelectScenarioBatchFile.FiLEName)
        ScenarioBatchFiLEName.Text = OpenSelectScenarioBatchFile.FiLEName

        FiLENames.PreviousScenarioPath = System.IO.Path.GetDirectoryName(OpenSelectScenarioBatchFile.FiLEName)

    End Sub

    Private Sub ScenarioListBox_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ScenarioListBox.MouseDoubleClick
        Dim intIndex As INTEGER = ScenarioListBox.Items.IndexOf(ScenarioListBox.SelectedItem)
        Dim objInputBox As Object = InputBox("Change Item :", "Edit", ScenarioListBox.SelectedItem)
        If Not objInputBox = Nothing THEN
            ScenarioListBox.Items.Remove(ScenarioListBox.SelectedItem)
            ScenarioListBox.Items.Insert(intIndex, objInputBox)
        END IF




    End Sub

    Private Sub ClearTable_Click(sender As Object, e As EventArgs) Handles ClearTable.Click

        AppTableDisplay.Rows.Clear()


    End Sub

    Private Sub ItsaPond_CheckedChanged(sender As Object, e As EventArgs) Handles ItsaPond.CheckedChanged
        If ItsaPond.Checked THEN
            ItsTPEZWPEZ.Enabled = True
        Else
            ItsTPEZWPEZ.Enabled = False
            ItsTPEZWPEZ.Checked = False
        END IF
    End Sub

    Private Sub ModifyScenarios_Click(sender As Object, e As EventArgs) Handles ModifyScenarios.Click
        'Dim msg As String
        'Dim newfiLEName As String

        MsgBox("disabled, for developer only")

        'For Each scenariofiLEName As String In ScenarioListBox.Items

        '    READScenarioPARAMETERs(scenariofiLEName)

        '    'Put modifications here:
        '    useAutoGWprofile.Checked = True


        '    'Version numbering
        '    newfiLEName = Replace(scenariofiLEName, "V4.scn2", "v5.scn2")

        '    msg = CreateScenarioString()

        '    Try
        '        My.Computer.FileSystem.WRITEAllText(newfiLEName, msg, False, System.Text.Encoding.ASCII)
        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try

        'Next
    End Sub

    Private Sub WRITESchemeTableToFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WRITESchemeTableToFileToolStripMenuItem.Click

        Dim result As System.Windows.Forms.DialogResult

        SaveFileDialogMain.Filter = "PWC 3 Scheme File (*.sch)|*.SCH|CSV File (*.csv)|*.CSV|ALL Files (*.*)|*.*"
        SaveFileDialogMain.FilterIndex = 1

        SaveFileDialogMain.InitialDirectory = FiLENames.WorkingDirectory
        SaveFileDialogMain.FiLEName = ""
        result = SaveFileDialogMain.ShowDialog(Me)

        'Cancel button will cuase return without further execution
        If result = Windows.Forms.DialogResult.Cancel THEN
            Return
        END IF

        FiLENames.SchemeFiLEName = SaveFileDialogMain.FiLEName


        'FiLENames.WorkingDirectory = System.IO.Path.GetDirectoryName(SaveFileDialogMain.FiLEName) & "\"
        'WorkingDirectoryLabel.Text = FiLENames.WorkingDirectory
        'SaveFileDialogMain.InitialDirectory = WorkingDirectoryLabel.Text

        'IOFamilyName.Text = System.IO.Path.GetFiLENameWithoutExtension(SaveFileDialogMain.FiLEName)

        SaveSchemeTableAsTextFile(SaveFileDialogMain.FiLEName)

    End Sub

    Private Sub LoadSchemeTableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadSchemeTableToolStripMenuItem.Click


        Dim result As System.Windows.Forms.DialogResult

        RetrieveMainInput.Filter = "PWC 3 Scheme Files (*.SCH)|*.SCH|CSV Files (*.CSV)|*.CSV|ALL Files (*.*)|*.*"

        'Opens the desktop if there is no previous open
        If System.IO.Directory.Exists(FiLENames.WorkingDirectory) THEN
            RetrieveMainInput.InitialDirectory = FiLENames.WorkingDirectory
        Else
            '  RetrieveMainInput.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        END IF

        RetrieveMainInput.FiLEName = ""

        result = RetrieveMainInput.ShowDialog(Me)

        'Cancel button will cause return without further execution
        If result = Windows.Forms.DialogResult.Cancel THEN
            Return
        END IF



        READSchemeFile(RetrieveMainInput.FiLEName)

        'disable all edit buttons in scheme table on first retrieve
        Dim buttonCell As DataGridViewDisableButtonCell
        For i As INTEGER = 0 To SchemeTableDisplay.RowCount - 1
            buttonCell = CType(SchemeTableDisplay.Rows(i).Cells("Commit"), DataGridViewDisableButtonCell)
            buttonCell.Enabled = False
        Next

        'Disable the last new row button
        buttonCell = CType(SchemeTableDisplay.Rows(SchemeTableDisplay.Rows.Count - 1).Cells("Delete"), DataGridViewDisableButtonCell)
        buttonCell.Enabled = False


    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork


        'The file name should be stored somewhere alREADy but for now here it is
        Dim PRZMVVWMinputFile As String = FiLENames.WorkingDirectory & "PRZMVVWM.txt"
        SaveInputsAsTextFile(PRZMVVWMinputFile)


        Dim p As Process = New Process
        p.StartInfo.FiLEName = My.Application.Info.DirectoryPath() & "\PRZM-VVWM.exe"
        p.StartInfo.Arguments = """" & PRZMVVWMinputFile & """"
        p.StartInfo.UseShellExecute = False
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.RedirectStandardError = True
        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        p.StartInfo.CreateNoWindow = True
        p.Start()

        Dim output As String = p.StandardOutput.READToEnd
        Dim output2 As String = p.StandardError.READToEnd

        '  p.WaitForExit()
        My.Computer.FileSystem.WRITEAllText("run_status.txt", output & output2, False, System.Text.Encoding.ASCII)



    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        CalculateButton.Text = "Calculate"
        CalculateButton.Enabled = True
    End Sub

    Private Sub ContactToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContactToolStripMenuItem.Click
        MsgBox("Technical Support:" & vbCr & "Dirk Young" & vbCr & "USEPA" & vbCr & "young.dirk@epa.gov")
    End Sub

    Private Sub poundToKiloConversion_CheckedChanged(sender As Object, e As EventArgs) Handles poundToKiloConversion.CheckedChanged
        If poundToKiloConversion.Checked THEN
            AppTableDisplay.Columns(1).Name = "Amount (lb/acre)"
        Else
            AppTableDisplay.Columns(1).Name = "Amount (kg/ha)"
        END IF


    End Sub

    Private Sub Evergreen_CheckedChanged(sender As Object, e As EventArgs) Handles Evergreen.CheckedChanged
        If Evergreen.Checked = True THEN
            EvergreenPanel.Visible = True
        Else
            EvergreenPanel.Visible = False
        END IF
    End Sub
End Class



Public Class DataGridViewDisableButtonColumn
    Inherits DataGridViewButtonColumn

    Public Sub New()
        Me.CellTemplate = New DataGridViewDisableButtonCell()
    End Sub
End Class

Public Class DataGridViewDisableButtonCell
    Inherits DataGridViewButtonCell

    Private enabledValue As Boolean
    Public Property Enabled() As Boolean
        Get
            Return enabledValue
        End Get
        Set(ByVal value As Boolean)
            enabledValue = value
        End Set
    End Property

    ' Override the Clone method so that the Enabled property is copied.
    Public Overrides Function Clone() As Object
        Dim Cell As DataGridViewDisableButtonCell =
            CType(MyBase.Clone(), DataGridViewDisableButtonCell)
        Cell.Enabled = Me.Enabled
        Return Cell
    End Function

    ' By default, enable the button cell.
    Public Sub New()
        Me.enabledValue = True
    End Sub

    Protected Overrides Sub Paint(ByVal graphics As Graphics,
        ByVal clipBounds As Rectangle, ByVal cellBounds As Rectangle,
        ByVal rowIndex As INTEGER,
        ByVal elementState As DataGridViewElementStates,
        ByVal value As Object, ByVal formattedValue As Object,
        ByVal errorText As String,
        ByVal cellStyle As DataGridViewCellStyle,
        ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle,
        ByVal paintParts As DataGridViewPaintParts)

        ' The button cell is disabled, so paint the border,  
        ' background, and disabled button for the cell.
        If Not Me.enabledValue THEN

            ' Draw the background of the cell, if specified.
            If (paintParts And DataGridViewPaintParts.Background) =
                DataGridViewPaintParts.Background THEN

                Dim cellBackground As New SolidBrush(cellStyle.BackColor)
                graphics.FillRectangle(cellBackground, cellBounds)
                cellBackground.Dispose()
            END IF

            ' Draw the cell borders, if specified.
            If (paintParts And DataGridViewPaintParts.Border) =
                DataGridViewPaintParts.Border THEN

                PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
                    advancedBorderStyle)
            END IF

            ' Calculate the area in which to draw the button.
            Dim buttonArea As Rectangle = cellBounds
            Dim buttonAdjustment As Rectangle =
                Me.BorderWidths(advancedBorderStyle)
            buttonArea.X += buttonAdjustment.X
            buttonArea.Y += buttonAdjustment.Y
            buttonArea.Height -= buttonAdjustment.Height
            buttonArea.Width -= buttonAdjustment.Width

            ' Draw the disabled button.                
            ButtonRenderer.DrawButton(graphics, buttonArea, PushButtonState.Disabled)

            ' Draw the disabled button text. 
            If TypeOf Me.FormattedValue Is String THEN
                TextRenderer.DrawText(graphics, CStr(Me.FormattedValue),
                    Me.DataGridView.Font, buttonArea, SystemColors.GrayText)
            END IF

        Else
            ' The button cell is enabled, so let the base class 
            ' handle the painting.
            MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex,
                elementState, value, formattedValue, errorText,
                cellStyle, advancedBorderStyle, paintParts)
        END IF
    End Sub

End Class