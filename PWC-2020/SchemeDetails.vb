﻿Public Class SchemeDetails
    Public Property Days As IList(Of String)
    Public Property Amount As IList(Of String)
    Public Property Method As IList(Of String)
    Public Property Depth As IList(Of String)
    Public Property Split As IList(Of String)
    'Public Property Efficiency As List(Of String)
    Public Property Drift As List(Of String)
    Public Property Periodicity As IList(Of String)
    Public Property Lag As IList(Of String)
    Public Property Scenarios As IList(Of String)
    Public Property AbsoluteRelative As Boolean
    Public Property Emerge As Boolean
    Public Property Maturity As Boolean
    Public Property Removal As Boolean
    Public Property UseApplicationWindow As Boolean
    Public Property ApplicationWindowSpan As String
    Public Property ApplicationWindowStep As String

    Public Sub ClearAll()
        Days.Clear()
        Amount.Clear()
        Method.Clear()
        Depth.Clear()
        Split.Clear()
        'Efficiency.Clear()
        Drift.Clear()
        Lag.Clear()
        Periodicity.Clear()
        Scenarios.Clear()
        AbsoluteRelative = False
        Emerge = False
        Maturity = False
        Removal = False
    End Sub
End Class
