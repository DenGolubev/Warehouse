Imports System.Data.OleDb
Public Class Прочие_данные

    Dim Дата As DateTime = Now
    Public Function Полная_дата()
        Dim ДатаВремя As String
        ДатаВремя = Format(Дата, "Long Date")
        Return ДатаВремя
    End Function


End Class
