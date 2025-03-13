Module Utilities

    Public Function RateFromHalflife(ByVal halflife As String) As Double
        'converts half life to rate. Assumes that a blank entry  means zero rate. Also assumes by EFED convention
        'that a 0 halflife means a zero rate.


        If halflife = "" THEN
            RateFromHalflife = 0.0   'Blank means stable
        ElseIf Convert.ToSingle(halflife) = 0.0 THEN
            RateFromHalflife = 0.0   'half life of 0 means stable
        Else
            RateFromHalflife = 0.69314 / halflife
        END IF


    End Function



    Public Function BlankMeansZero(ByVal input As String) As String
        'converts hato single, recognizes that user intends blans to mean zero
        BlankMeansZero = input
        If input = "" THEN
            BlankMeansZero = "0.0"  'Blank means stable
        END IF

    End Function




    Sub TestREALNumbers(ByRef TrueOrFalse As Boolean, ByRef msg As String, ByVal name As TextBox)
        'Tests if REAL
        'return True if everythin OK

        Dim TestNumber As Double
        TrueOrFalse = True
        name.BackColor = Color.White

        Try
            TestNumber = name.Text
        Catch ex As Exception



            name.BackColor = Color.Orange
            msg = "Check the value for " & name.Tag
            TrueOrFalse = False

            Return

        End Try

        If name.Text.Contains(",") THEN
            '  MsgBox("No commas allowed for " & name.Tag)
            name.BackColor = Color.Orange
            msg = "No commas allowed for " & name.Tag
            TrueOrFalse = False
            Return
        END IF

    End Sub


    Sub TestREALNumbers(ByRef TrueOrFalse As Boolean, ByRef msg As String, ByVal name As TextBox, ByVal except As String)
        'This OVERLOAD will allow exceptions to the REAL number requirement, For example the null string would
        'indicate a zero rate of degradation if box is left blank
        'Tests if REAL
        'return True if everythin OK

        Dim TestNumber As Double
        TrueOrFalse = True
        name.BackColor = Color.White

        If name.Text = except THEN
            TrueOrFalse = True
            Return
        END IF

        Try
            TestNumber = name.Text
        Catch ex As Exception

            name.BackColor = Color.Orange
            msg = "Check the value for " & name.Tag
            TrueOrFalse = False
            Return

        End Try

        If name.Text.Contains(",") THEN
            '  MsgBox("No commas allowed for " & name.Tag)
            name.BackColor = Color.Orange
            msg = "No commas allowed for " & name.Tag
            TrueOrFalse = False
            Return
        END IF

    End Sub


    Sub TestActualREALNumbers(ByRef TrueOrFalse As Boolean, ByRef msg As String, ByVal name As String)
        'This test the REAL number requirementfor any object, 
        'Tests if REAL
        'return True if everythin OK

        Dim TestNumber As Double
        TrueOrFalse = True


        Try
            TestNumber = name
        Catch ex As Exception
            msg = "Not a REAL number:"

            TrueOrFalse = False
            Return
        End Try

        If name = "" THEN Return  'blank boxes dont work with next
        If name.Contains(",") THEN
            msg = "No commas allowed:"
            TrueOrFalse = False
            Return
        END IF

    End Sub



    Sub TestINTEGERs(ByRef TrueOrFalse As Boolean, ByRef msg As String, ByVal name As TextBox, ByVal except As String)
        'This OVERLOAD will allow exceptions to the number requirement, For example the null string would
        'indicate a zero if box is left blank
        'otherwise Tests if INTEGER
        'return True if everythin OK

        Dim TestNumber As INTEGER
        Dim TestREAL As Double

        TrueOrFalse = True

        name.BackColor = Color.White
        'test to see if its  a number


        If name.Text = except THEN
            TrueOrFalse = True
            Return
        END IF

        Try
            TestNumber = name.Text
        Catch ex As Exception
            msg = "Check the value for " & name.Tag
            name.BackColor = Color.Orange
            TrueOrFalse = False
            Return
        End Try

        'testINTEGERs Today see if its an INTEGER

        TestREAL = name.Text
        If TestREAL - TestNumber > 0.01 THEN
            msg = "This value should be an INTEGER:  " & name.Tag
            name.BackColor = Color.Orange
            TrueOrFalse = False
            Return
        END IF

        If name.Text.Contains(",") THEN
            msg = "No commas allowed for " & name.Tag
            name.BackColor = Color.Orange
            TrueOrFalse = False
            Return
        END IF
    End Sub



    Sub TestINTEGERs(ByRef TrueOrFalse As Boolean, ByRef msg As String, ByVal name As TextBox)
        Dim TestNumber As INTEGER
        Dim TestREAL As Double

        TrueOrFalse = True

        name.BackColor = Color.White


        'test to see if its  a number

        Try
            TestNumber = name.Text
        Catch ex As Exception
            msg = "Check the value for " & name.Tag
            name.BackColor = Color.Orange
            TrueOrFalse = False
            Return
        End Try

        'testINTEGERs Today see if its an INTEGER


        TestREAL = name.Text
        If TestREAL - TestNumber > 0.01 THEN
            msg = "This value should be an INTEGER:  " & name.Tag
            name.BackColor = Color.Orange
            TrueOrFalse = False
            Return
        END IF

        If name.Text.Contains(",") THEN
            msg = "No commas allowed for " & name.Tag
            name.BackColor = Color.Orange
            TrueOrFalse = False
            Return
        END IF
    End Sub



    Sub TestActualINTEGERs(ByRef TrueOrFalse As Boolean, ByRef msg As String, ByVal name As String)
        ' Test string, instead of text boxes
        Dim TestNumber As INTEGER
        Dim TestREAL As Double

        TrueOrFalse = True


        Try
            TestNumber = name
        Catch ex As Exception
            msg = "Value should be an INTEGER"
            TrueOrFalse = False
            Return
        End Try

        'testINTEGERs Today see if its an INTEGER

        TestREAL = name
        If TestREAL - TestNumber > 0.01 THEN
            msg = "Value should be an INTEGER"
            TrueOrFalse = False
            Return
        END IF

        Try


            If name.Contains(",") THEN
                msg = "No commas allowed for " & name
                TrueOrFalse = False
                Return
            END IF

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub













    Sub CaLENdarCheck(ByVal dayBox As TextBox, ByVal monthBox As TextBox, ByRef TrueOrFalse As Boolean, ByRef msg As String)

        Dim monthtest As INTEGER
        Dim daytest As INTEGER

        TrueOrFalse = True
        msg = ""

        dayBox.BackColor = Color.White
        monthBox.BackColor = Color.White

        Try
            monthtest = Convert.ToInt16(monthBox.Text)
        Catch
            monthBox.BackColor = Color.Orange
            msg = "  Check " & monthBox.Tag
            TrueOrFalse = False
            Return
        End Try


        Try
            daytest = Convert.ToInt16(dayBox.Text)
        Catch
            dayBox.BackColor = Color.Orange
            msg = "  Check " & dayBox.Tag
            TrueOrFalse = False
            Return
        End Try

        If monthtest > 12 Or monthtest < 1 THEN
            monthBox.BackColor = Color.Orange
            msg = "The following month is not posssible: " & monthBox.Tag
            TrueOrFalse = False
            Return
        END IF

        Select Case monthtest
            Case 1, 3, 5, 7, 8, 10, 12
                If daytest > 31 Or daytest < 1 THEN
                    '   MsgBox("Bad day for " & dayBox.Tag)
                    dayBox.BackColor = Color.Orange
                    msg = "Bad day for " & dayBox.Tag
                    TrueOrFalse = False
                    Return
                END IF
            Case 2
                If daytest > 28 Or daytest < 1 THEN
                    dayBox.BackColor = Color.Orange
                    msg = "Bad day for you and " & dayBox.Tag
                    TrueOrFalse = False
                    Return
                END IF
            Case 4, 6, 9, 11
                If daytest > 30 Or daytest < 1 THEN
                    dayBox.BackColor = Color.Orange
                    TrueOrFalse = False
                    msg = "Bad day for " & dayBox.Tag
                    Return
                END IF
            Case Else
                monthBox.BackColor = Color.Orange
                TrueOrFalse = False
                msg = "Month does not exist on Earth caLENdar for " & monthBox.Tag
                Return
        End Select


    End Sub


    Public Function FindNode(ByVal depth As Double, ByVal horizonTable As DataGridView)

        'given a depth, returns the node that is closest to that depth as well as the approximated depth (testdepth) that will be used by the program.

        Dim deltaX As Double
        Dim testdepth As Double
        Dim node As INTEGER
        Dim increments As INTEGER
        Dim thickness As Double

        node = 0
        testdepth = 0.0

        'Smallest node is 1
        If depth <= 0 THEN
            node = 1
            Return node
        END IF


        For i As INTEGER = 0 To horizonTable.Rows.Count - 1
            increments = horizonTable(6, i).Value
            thickness = horizonTable(1, i).Value

            deltaX = thickness / increments

            For j As INTEGER = 1 To increments
                node = node + 1
                testdepth = testdepth + deltaX

                If testdepth >= depth THEN
                    'Test if the overshoot was too much
                    If (testdepth - depth) < (depth - (testdepth - deltaX)) THEN
                        Return node
                    Else
                        testdepth = testdepth - deltaX
                        node = node - 1
                        Return node
                    END IF
                END IF
            Next
        Next


        FindNode = node

    End Function


    Function CalculateSoilMass(ByVal horizonTable As DataGridView, ByVal top As INTEGER, ByVal bottom As INTEGER) As Double
        'Returns mass of soil per ha given a Horizon table with following set up:
        'Assume horizon table thickness is column 1 (zero based)
        'Assume horizon table density is column 2 (zero based)
        'Assume horizon table compartment number is in column 6 (zero based)

        Dim totalhorizons, totalcompartments As INTEGER

        totalhorizons = horizonTable.Rows.Count - 1

        totalcompartments = 0
        For i As INTEGER = 0 To totalhorizons - 1
            totalcompartments = totalcompartments + horizonTable(6, i).Value
        Next

        Dim mass(totalcompartments) As Double

        'Try


        'Create arrays
        Dim k As INTEGER
        k = 0
        For i As INTEGER = 0 To totalhorizons - 1

            For j As INTEGER = 1 To horizonTable(6, i).Value
                k = k + 1
                '   Kg = (thickness (cm)/ NumberComp/100)*(10000m2) * Bulk density kg/L * 1000 L/m3
                mass(k) = horizonTable(1, i).Value / horizonTable(6, i).Value * horizonTable(2, i).Value * 100000
            Next
        Next


        CalculateSoilMass = 0
        For i As INTEGER = top To bottom
            CalculateSoilMass = CalculateSoilMass + mass(i)
        Next




    End Function


End Module
