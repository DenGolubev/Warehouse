Imports System.Data.OleDb
Imports System.Globalization

Public Class Форма_сотрудники
    Dim Сейчас As New Прочие_данные
    Dim Поставка As New Поставка_класс
    Dim BD As New БД
    Dim con As OleDb.OleDbConnection
    Dim dgv As New DataGridView
    Dim Склад_БД As New БД
    Dim Сотрудники As New Сотрудники_класс
    Private Sub Сотрудники_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label12.Text = Сейчас.Полная_дата

        DataGreed()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Сотрудники.Ввод_Данных_Сотрудников()
        DataGreed()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Сотрудники.Поиск_данных()
    End Sub

    Sub DataGreed()
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
        Dim passDB As String = "" 'пароль базы данных
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        BD.Коннект_on()
        Dim dt As New DataTable("Сотрудники")
        Dim rs As New OleDb.OleDbDataAdapter("Select * from Сотрудники", con)
        rs.Fill(dt)
        DataGridView1.DataSource = dt
        DataGridView1.Update()
        DataGridView1.Refresh()
        TextBox4.Text = dt.Rows.Count
        rs.Dispose()
        BD.Коннект_off()
    End Sub
End Class