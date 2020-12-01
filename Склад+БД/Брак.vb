Imports System.Data.OleDb
Public Class Форма_брак
    Dim bd_a As String = "Склад"
    Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
    Dim passDB As String = "" 'пароль базы данных
    Dim con As OleDbConnection
    Dim SqlCom As OleDbCommand
    Dim Сейчас As New Прочие_данные
    Dim adapter As OleDbDataAdapter
    Dim Поставка As New Поставка_класс
    Dim BD As New БД
    Dim Сотрудники As New Сотрудники_класс
    Dim Выдача_класс As New Выдача_класс
    Dim Брак As New Брак_класс
    Dim Списание As New Списание_класс
    Dim Счетчики As New Счетчики_класс
    Dim dt As DataTable = New DataTable()

    Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            Брак.Возврат_оборудования_брак()
            Брак.Удаление_выдачи()
            Брак.Удаление_запаса()
            DataGreed_Брак()
            TextBox4.Clear()
        End If

    End Sub

    Private Sub Форма_брак_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGreed_Брак()
        Кладовщик_lable()
        Label1.Text = Сейчас.Полная_дата
    End Sub

    Sub DataGreed_Брак()
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
        Dim passDB As String = "" 'пароль базы данных
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        con.Open()
        Dim dt As New DataTable("Брак")
        Dim rs As New OleDb.OleDbDataAdapter("Select * from Брак", con)
        rs.Fill(dt)
        DataGridView4.DataSource = dt
        DataGridView4.Update()
        DataGridView4.Refresh()
        'Сотрудники.TextBox4.Text = dt.Rows.Count
        rs.Dispose()
        con.Close()
    End Sub

    Sub Кладовщик_lable()
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
        Dim passDB As String = "" 'пароль базы данных
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        Dim dt As New DataTable("Сотрудники")
        con.Open()
        Dim insCom As New OleDb.OleDbCommand("Select Кладовщик from Кладовщик", con)
        Label10.Text = insCom.ExecuteScalar
        con.Close()
    End Sub

End Class
