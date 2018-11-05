Imports System.Data.OleDb
Public Class Кладовщики_класс
    Dim bd_a As String = "Склад"
    Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
    Dim passDB As String = "" 'пароль базы данных
    Dim con As OleDbConnection
    Dim SqlCom As OleDbCommand

    Dim Сейчас As New Прочие_данные
    Dim adapter As OleDbDataAdapter
    Dim dt As DataTable = New DataTable()

    Public Function Создание_таблицы_Кладовщик()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        con.Open()
        Try
            SqlCom = New OleDbCommand("CREATE TABLE Кладовщик", con) 'Создаем таблицу
            SqlCom.ExecuteNonQuery()
            'MsgBox("Таблица Выдача успешно создана!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message & ". " & SqlCom.CommandText, MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try
        Return con
    End Function

    Public Function Добавляем_поля_Кладовщик()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        con.Open()

        Try
            'Добавляем поля
            SqlCom = New OleDb.OleDbCommand("alter table Кладовщик add [ID] COUNTER NOT NULL  ", con) 'ID - счетчик, ключевое
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Кладовщик add [Дата] DATETIME NULL", con) ' DATA - дата/время, нулевое значение разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Кладовщик add [Кладовщик] TEXT NULL", con) 'TEXT - тесктовое, нулевое значение не разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Кладовщик add [Табельный номер] TEXT NULL", con) 'TEXT - тесктовое, нулевое значение не разрешено
            SqlCom.ExecuteNonQuery()

            'MsgBox("Поля таблицы успешно созданы!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message & ". " & SqlCom.CommandText, MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try
        Return SqlCom
    End Function

    Public Function Ввод_Данных_Кладовщика()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        Dim Дата As DateTime = Форма_кладовщик.Label2.Text
        Dim Кладовщик As String = Форма_кладовщик.ComboBox1.Text
        Dim Табельный_номер As String
        Табельный_номер = Форма_кладовщик.ComboBox1.ValueMember
        Dim insert_db As New OleDbCommand
        Dim db_con As New OleDbConnection
        con.Open()
        SqlCom = New OleDbCommand("INSERT INTO  Кладовщик ([Дата], [Кладовщик], [Табельный номер])  VALUES ('" & Дата & "','" & Кладовщик & "', '" & Табельный_номер & "')", con)
        SqlCom.ExecuteNonQuery()
        con.Close()
        'MsgBox("Данные добавлены!", MsgBoxStyle.Information)
        Return SqlCom
    End Function

    Public Function Удалить_таблицу_Кладовщик()

        Try
            Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
            Dim passDB As String = "" 'пароль базы данных
            con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
            Dim dt As New DataTable("Кладовщик")
            Dim rs As New OleDbDataAdapter("Delete * from Кладовщик ", con)
            rs.Fill(dt)
            If MessageBox.Show("Do you really want to Delete this Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then

                MsgBox("Operation Cancelled")
                Application.Restart()



            End If
        Catch ex As Exception
            MessageBox.Show("Error while deleting record on table..." & ex.Message, "Delete Records")

        Finally

            con.Close()
        End Try
    End Function
End Class
