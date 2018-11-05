Imports System.Data.OleDb
Public Class Номенклатура_класс
    Dim bd_a As String = "Склад"
    Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
    Dim passDB As String = "" 'пароль базы данных
    Dim con As OleDb.OleDbConnection
    Dim SqlCom As OleDb.OleDbCommand
    Dim Сейчас As New Прочие_данные
    Dim adapter As OleDbDataAdapter
    Dim dt As DataTable = New DataTable()
    Public Function Создание_таблицы_Номенклатура()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        con.Open()

        Try
            SqlCom = New OleDbCommand("CREATE TABLE Номенклатура_оборудования", con) 'Создаем таблицу
            SqlCom.ExecuteNonQuery()
            'MsgBox("Таблица Выдача успешно создана!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message & ". " & SqlCom.CommandText, MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try
        Return con
    End Function
    Public Function Добавляем_поля_Номенклатура()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        con.Open()
        Try
            'Добавляем поля
            SqlCom = New OleDb.OleDbCommand("alter table Номенклатура_оборудования add [ID] COUNTER NOT NULL PRIMARY KEY ", con) 'ID - счетчик, ключевое
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Номенклатура_оборудования add [Наименование оборудования] TEXT NOT NULL", con) 'CHISLO - числовое, обязательное, по умолчанию 0
            SqlCom.ExecuteNonQuery()

            'MsgBox("Поля таблицы успешно созданы!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message & ". " & SqlCom.CommandText, MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try
        Return SqlCom
    End Function
    Public Function Ввод_Данных()
        Dim insert_brand As String
        Dim insert_db As New OleDbCommand
        Dim db_con As New OleDbConnection
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        con.Open()
        insert_brand = Форма_номенклатура.TextBox1.Text
        SqlCom = New OleDbCommand("INSERT INTO Номенклатура_оборудования ([Наименование оборудования]) VALUES ('" & insert_brand & "')", con)
        SqlCom.ExecuteNonQuery()
        con.Close()
        'MsgBox("Данные добавлены!", MsgBoxStyle.Information)
        Return SqlCom
    End Function
End Class
