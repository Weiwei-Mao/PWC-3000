Imports System.Globalization

Partial Public Class Form1
    Private Sub CheckChemicalInputs(ByRef TrueOrFalse As Boolean, ByRef msg As String)
        TrueOrFalse = True


        TestREALNumbers(TrueOrFalse, msg, sorption1)
        If TrueOrFalse = False THEN Return

        TestREALNumbers(TrueOrFalse, msg, WaterColMetab1, "")
        If TrueOrFalse = False THEN Return

        If WaterColMetab1.Text <> "" THEN
            TestREALNumbers(TrueOrFalse, msg, WaterColRef1)
            If TrueOrFalse = False THEN Return
        END IF

        TestREALNumbers(TrueOrFalse, msg, BenthicMetab1, "")
        If TrueOrFalse = False THEN Return

        If BenthicMetab1.Text <> "" THEN
            TestREALNumbers(TrueOrFalse, msg, BenthicRef1)
            If TrueOrFalse = False THEN Return
        END IF

        TestREALNumbers(TrueOrFalse, msg, Photo1, "")
        If TrueOrFalse = False THEN Return

        If Photo1.Text <> "" THEN
            TestREALNumbers(TrueOrFalse, msg, PhotoLat1)
            If TrueOrFalse = False THEN Return
        END IF

        TestREALNumbers(TrueOrFalse, msg, Hydrolysis1, "")
        If TrueOrFalse = False THEN Return


        TestREALNumbers(TrueOrFalse, msg, SoilDegradation1, "")
        If TrueOrFalse = False THEN Return

        If SoilDegradation1.Text <> "" THEN
            TestREALNumbers(TrueOrFalse, msg, SoilRef1)
            If TrueOrFalse = False THEN Return
        END IF

        TestREALNumbers(TrueOrFalse, msg, MWT1, "")
        If TrueOrFalse = False THEN Return

        TestREALNumbers(TrueOrFalse, msg, VaporPress1, "")
        If TrueOrFalse = False THEN Return

        TestREALNumbers(TrueOrFalse, msg, Sol1, "")
        If TrueOrFalse = False THEN Return

        TestREALNumbers(TrueOrFalse, msg, Henry1, "")
        If TrueOrFalse = False THEN Return

        TestREALNumbers(TrueOrFalse, msg, AirDiff1, "")
        If TrueOrFalse = False THEN Return

        TestREALNumbers(TrueOrFalse, msg, HeaTHENry1, "")
        If TrueOrFalse = False THEN Return

        'OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
        If DoDegradate1.Checked THEN
            TestREALNumbers(TrueOrFalse, msg, WaterMolarRatio1, "")
            If TrueOrFalse = False THEN Return

            TestREALNumbers(TrueOrFalse, msg, BenthicMolarRatio1, "")
            If TrueOrFalse = False THEN Return

            TestREALNumbers(TrueOrFalse, msg, PhotoMolarRatio1, "")
            If TrueOrFalse = False THEN Return

            TestREALNumbers(TrueOrFalse, msg, HydroMolarRatio1, "")
            If TrueOrFalse = False THEN Return

            TestREALNumbers(TrueOrFalse, msg, SoilMolarRatio1, "")
            If TrueOrFalse = False THEN Return

            TestREALNumbers(TrueOrFalse, msg, FoliarMolarRatio1, "")
            If TrueOrFalse = False THEN Return


            TestREALNumbers(TrueOrFalse, msg, sorption2)
            If TrueOrFalse = False THEN Return

            TestREALNumbers(TrueOrFalse, msg, WaterColMetab2, "")
            If TrueOrFalse = False THEN Return

            If WaterColMetab2.Text <> "" THEN
                TestREALNumbers(TrueOrFalse, msg, WaterColRef2)
                If TrueOrFalse = False THEN Return
            END IF

            TestREALNumbers(TrueOrFalse, msg, BenthicMetab2, "")
            If TrueOrFalse = False THEN Return

            If BenthicMetab2.Text <> "" THEN
                TestREALNumbers(TrueOrFalse, msg, BenthicRef2)
                If TrueOrFalse = False THEN Return
            END IF

            TestREALNumbers(TrueOrFalse, msg, Photo2, "")
            If TrueOrFalse = False THEN Return

            If Photo2.Text <> "" THEN
                TestREALNumbers(TrueOrFalse, msg, PhotoLat2)
                If TrueOrFalse = False THEN Return
            END IF

            TestREALNumbers(TrueOrFalse, msg, Hydrolysis2, "")
            If TrueOrFalse = False THEN Return

            TestREALNumbers(TrueOrFalse, msg, SoilDegradation2, "")
            If TrueOrFalse = False THEN Return

            If SoilDegradation2.Text <> "" THEN
                TestREALNumbers(TrueOrFalse, msg, SoilRef2)
                If TrueOrFalse = False THEN Return
            END IF

            TestREALNumbers(TrueOrFalse, msg, MWT2, "")
            If TrueOrFalse = False THEN Return

            TestREALNumbers(TrueOrFalse, msg, VaporPress2, "")
            If TrueOrFalse = False THEN Return

            TestREALNumbers(TrueOrFalse, msg, Sol2, "")
            If TrueOrFalse = False THEN Return


            TestREALNumbers(TrueOrFalse, msg, Henry2, "")
            If TrueOrFalse = False THEN Return

            TestREALNumbers(TrueOrFalse, msg, AirDiff2, "")
            If TrueOrFalse = False THEN Return


            TestREALNumbers(TrueOrFalse, msg, HeaTHENry2, "")
            If TrueOrFalse = False THEN Return

        END IF

        If DoDegradate2.Checked THEN

            TestREALNumbers(TrueOrFalse, msg, WaterMolarRatio2, "")
            If TrueOrFalse = False THEN Return

            TestREALNumbers(TrueOrFalse, msg, BenthicMolarRatio2, "")
            If TrueOrFalse = False THEN Return

            TestREALNumbers(TrueOrFalse, msg, PhotoMolarRatio2, "")
            If TrueOrFalse = False THEN Return

            TestREALNumbers(TrueOrFalse, msg, HydroMolarRatio2, "")
            If TrueOrFalse = False THEN Return

            TestREALNumbers(TrueOrFalse, msg, SoilMolarRatio2, "")
            If TrueOrFalse = False THEN Return

            TestREALNumbers(TrueOrFalse, msg, FoliarMolarRatio2, "")
            If TrueOrFalse = False THEN Return


            TestREALNumbers(TrueOrFalse, msg, sorption3)
            If TrueOrFalse = False THEN Return

            TestREALNumbers(TrueOrFalse, msg, WaterColMetab3, "")
            If TrueOrFalse = False THEN Return

            If WaterColMetab3.Text <> "" THEN
                TestREALNumbers(TrueOrFalse, msg, WaterColRef3)
                If TrueOrFalse = False THEN Return
            END IF

            TestREALNumbers(TrueOrFalse, msg, BenthicMetab3, "")
            If TrueOrFalse = False THEN Return

            If BenthicMetab3.Text <> "" THEN
                TestREALNumbers(TrueOrFalse, msg, BenthicRef3)
                If TrueOrFalse = False THEN Return
            END IF

            TestREALNumbers(TrueOrFalse, msg, Photo3, "")
            If TrueOrFalse = False THEN Return

            If Photo3.Text <> "" THEN
                TestREALNumbers(TrueOrFalse, msg, PhotoLat3)
                If TrueOrFalse = False THEN Return
            END IF

            TestREALNumbers(TrueOrFalse, msg, Hydrolysis3, "")
            If TrueOrFalse = False THEN Return

            TestREALNumbers(TrueOrFalse, msg, SoilDegradation3, "")
            If TrueOrFalse = False THEN Return

            If SoilDegradation3.Text <> "" THEN
                TestREALNumbers(TrueOrFalse, msg, SoilRef3)
                If TrueOrFalse = False THEN Return
            END IF

            TestREALNumbers(TrueOrFalse, msg, MWT3, "")
            If TrueOrFalse = False THEN Return

            TestREALNumbers(TrueOrFalse, msg, VaporPress3, "")
            If TrueOrFalse = False THEN Return

            TestREALNumbers(TrueOrFalse, msg, Sol3, "")
            If TrueOrFalse = False THEN Return

            TestREALNumbers(TrueOrFalse, msg, Henry3, "")
            If TrueOrFalse = False THEN Return

            TestREALNumbers(TrueOrFalse, msg, AirDiff3, "")
            If TrueOrFalse = False THEN Return

            TestREALNumbers(TrueOrFalse, msg, HeaTHENry3, "")
            If TrueOrFalse = False THEN Return

        END IF

        'Check application information
        Dim NumberOfSchemes As INTEGER
        Dim ApplicationTable As New SchemeDetails
        Dim actualRowsInAppTable As INTEGER 'app table rows

        AppTableDisplay.CommitEdit(DataGridViewDataErrorContexts.Commit)  'commit the cell if cursor still on box

        NumberOfSchemes = SchemeTableDisplay.RowCount - 1
        SchemeTableDisplay.CommitEdit(DataGridViewDataErrorContexts.Commit) 'commit the cell if cursor still on box

        For i As INTEGER = 0 To NumberOfSchemes - 1

            ApplicationTable = SchemeInfoList(i)

            'Application Table Information
            actualRowsInAppTable = ApplicationTable.Days.Count   'AppTableDisplay.RowCount - 1
            If actualRowsInAppTable < 1 THEN
                msg = (String.Format("There are no pesticide applications for scheme number {0}", i + 1))
                TrueOrFalse = False
                Return
            END IF

            Dim formats() As String = {"MM/d/yyyy", "MM/dd/yyyy", "M/dd/yyyy", "M/d/yyyy", "M/d", "MM/d", "M/d", "M/dd"}
            Dim thisDt As DateTime

            For j As INTEGER = 0 To actualRowsInAppTable - 1

                If ApplicationTable.AbsoluteRelative THEN  'TRUE MEANS ABSOLUTE
                    If Not DateTime.TryParseExact(ApplicationTable.Days(j), formats, Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, thisDt) THEN
                        msg = "Absolute Application date is not in the right format" & String.Format(" for Scheme {0}, Row {1}", i + 1, j + 1)
                        TrueOrFalse = False
                        Return
                    END IF

                Else
                    TestActualINTEGERs(TrueOrFalse, msg, ApplicationTable.Days(j))
                    msg = msg & String.Format(" for Scheme {0}, Row {1}", i + 1, j + 1)
                    If TrueOrFalse = False THEN Return
                END IF

                TestActualREALNumbers(TrueOrFalse, msg, ApplicationTable.Amount(j))

                If TrueOrFalse = False THEN
                    msg = msg & " Application Amount" & String.Format(" for Scheme {0}, Row {1}", i + 1, j + 1)
                    Return
                END IF

                TestActualREALNumbers(TrueOrFalse, msg, ApplicationTable.Depth(j))


                If TrueOrFalse = False THEN
                    msg = msg & " Application Depth" & String.Format(" for Scheme {0}, Row {1}", i + 1, j + 1)
                    Return
                END IF

                TestActualREALNumbers(TrueOrFalse, msg, ApplicationTable.Split(j))
                If TrueOrFalse = False THEN
                    msg = msg & " Split Value" & String.Format(" for Scheme {0}, Row {1}", i + 1, j + 1)
                    Return
                END IF

                'TestActualREALNumbers(TrueOrFalse, msg, ApplicationTable.Efficiency(j))
                'If TrueOrFalse = False THEN Return


                TestActualREALNumbers(TrueOrFalse, msg, ApplicationTable.Drift(j))
                If TrueOrFalse = False THEN
                    msg = msg & " Drift Value"
                    Return
                END IF

                TestActualREALNumbers(TrueOrFalse, msg, ApplicationTable.DriftBuffer(j))
                If TrueOrFalse = False THEN
                    msg = msg & " Buffer Distance"
                    Return
                END IF

                TestActualREALNumbers(TrueOrFalse, msg, ApplicationTable.Periodicity(j))
                If TrueOrFalse = False THEN
                    msg = msg & " Application Period"
                    Return
                END IF


                'Periodicity must be 1 or greater
                If ApplicationTable.Periodicity(j) < 1 THEN
                    msg = "Periodicity in Application Table must be 1 or greater"
                    TrueOrFalse = False
                    Return
                END IF



                TestActualREALNumbers(TrueOrFalse, msg, ApplicationTable.Lag(j))
                If TrueOrFalse = False THEN
                    msg = msg & " Application Lag"
                    Return
                END IF



            Next
        Next



        'Check Optional Output Table
        AdditionalOutputGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)
        Dim zts_modes As New List(Of String) From {"TSER", "TCUM", "TAVE", "TSUM"}

        For i As INTEGER = 0 To AdditionalOutputGridView.RowCount - 2  'minus 2 because there is always a last empty row

            TestActualINTEGERs(TrueOrFalse, msg, AdditionalOutputGridView.Item(1, i).Value)
            If TrueOrFalse = False THEN Return

            If DoDegradate1.Checked = False THEN
                If AdditionalOutputGridView.Item(1, i).Value > 1 THEN
                    msg = String.Format("Chemical form must be less than 2.  Row {0} in Optional Outputs Table.  Degradate calculations were not selected on chemical tab.", i + 1)
                    TrueOrFalse = False
                    Return
                END IF
            END IF



            If DoDegradate2.Checked = False THEN
                If AdditionalOutputGridView.Item(1, i).Value > 2 THEN
                    msg = String.Format("Chemical form must be less than 3. Row {0} in Optional Outputs Table. Grandaughter calculations were not selected on chemical tab.", i + 1)
                    TrueOrFalse = False
                    Return
                END IF
            END IF

            If Not zts_modes.Contains((AdditionalOutputGridView.Item(2, i).Value)) THEN
                msg = String.Format("Mode selection can only be TSER, TAVE, TSUM, or TCUM.  Row {0} in Optional Outputs Table.", i + 1)
                TrueOrFalse = False
                Return
            END IF


            TestActualINTEGERs(TrueOrFalse, msg, AdditionalOutputGridView.Item(3, i).Value)
            msg = msg & String.Format(" Arg1 in Row {0} in Optional Outputs Table.", i + 1)
            If TrueOrFalse = False THEN Return


            TestActualINTEGERs(TrueOrFalse, msg, AdditionalOutputGridView.Item(4, i).Value)
            msg = msg & String.Format(" Arg2 in Row {0} in Optional Outputs Table.", i + 1)
            If TrueOrFalse = False THEN Return


            TestActualREALNumbers(TrueOrFalse, msg, AdditionalOutputGridView.Item(5, i).Value)
            msg = msg & String.Format(" Multiplier in Row {0} in Optional Outputs Table.", i + 1)
            If TrueOrFalse = False THEN Return

        Next

    End Sub

End Class