Imports System.Data.OleDb
Public Class Информация_о_БД
    Dim bd_a As String = "Склад"
    Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
    Dim passDB As String = "" 'пароль базы данных
    Dim con As OleDb.OleDbConnection
    Dim SqlCom As OleDb.OleDbCommand
    Dim Сейчас As New Прочие_данные
    Dim adapter As OleDbDataAdapter
    Dim dt As DataTable = New DataTable()
    Private Sub Информация_о_БД_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Function Очистить_поля()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb" & ";Jet OLEDB:Database Password=" & passDB)
        Dim insert_db As New OleDbCommand
        Dim db_con As New OleDbConnection
        con.Open()
        SqlCom = New OleDbCommand("Select * FROM  Поставка, Запасы, Выдача where [Серийный номер] = '""' ", con)
        SqlCom.ExecuteNonQuery()
        con.Close()
        MsgBox("Данные Удалены!", MsgBoxStyle.Information)
        Return SqlCom
    End Function
End Class