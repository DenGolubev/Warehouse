Imports System.Data.OleDb
Public Class Счетчики_класс
    Dim Сейчас As New Прочие_данные
    Dim Поставка As New Поставка_класс
    Dim BD As New БД
    Dim con As OleDb.OleDbConnection
    Dim dgv As New DataGridView
    Dim Склад_БД As New БД
    Dim Сотрудники As New Сотрудники_класс
    Dim Выдача_класс As New Выдача_класс
    Dim Брак As New Брак_класс
    Dim Списание As New Списание_класс
    Public Function DataGreed_счетчик_Выдано()
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
        Dim passDB As String = "" 'пароль базы данных
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        BD.Коннект_on()
        Dim dt As New DataTable("Выдача")
        Dim rs As New OleDb.OleDbDataAdapter("Select * from Выдача", con)
        rs.Fill(dt)
        Форма_поставка.Label6.Text = dt.Rows.Count
        rs.Dispose()
        BD.Коннект_off()
    End Function

    Public Function DataGreed_счетчик_на_Складе()
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
        Dim passDB As String = "" 'пароль базы данных
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        BD.Коннект_on()
        Dim dt As New DataTable("Запасы")
        Dim rs As New OleDb.OleDbDataAdapter("Select * from Запасы", con)
        rs.Fill(dt)
        Форма_поставка.Label12.Text = dt.Rows.Count
        rs.Dispose()
        BD.Коннект_off()
    End Function

    Public Function DataGreed_счетчик_Списано()
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
        Dim passDB As String = "" 'пароль базы данных
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        BD.Коннект_on()
        Dim dt As New DataTable("Списание")
        Dim rs As New OleDb.OleDbDataAdapter("Select * from Списание", con)
        rs.Fill(dt)
        Форма_поставка.Label15.Text = dt.Rows.Count
        rs.Dispose()
        BD.Коннект_off()
    End Function
    Public Function DataGreed_счетчик_Номенклатура()
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
        Dim passDB As String = "" 'пароль базы данных
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        BD.Коннект_on()
        Dim dt As New DataTable("Запасы")
        Dim rs As New OleDb.OleDbDataAdapter("Select [Наименование оборудования], count([Серийный номер]) as 'Количество' from Запасы GROUP BY  [Наименование оборудования] ", con)
        rs.Fill(dt)
        'Форма_выдача.Label15.Text = dt.Rows.Count
        Форма_выдача.DataGridView6.DataSource = dt
        Форма_выдача.DataGridView6.Update()
        Форма_выдача.DataGridView6.Refresh()
        rs.Dispose()
        BD.Коннект_off()
    End Function
End Class
