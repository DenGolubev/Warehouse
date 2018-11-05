Imports System.Data.OleDb
Public Class Брак_класс
    Dim bd_a As String = "Склад"
    Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
    Dim passDB As String = "" 'пароль базы данных
    Dim con As OleDbConnection
    Dim SqlCom As OleDbCommand

    Dim Сейчас As New Прочие_данные
    Dim adapter As OleDbDataAdapter
    Dim dt As DataTable = New DataTable()
    Public Function Создание_таблицы_Брак()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        con.Open()

        Try
            SqlCom = New OleDbCommand("CREATE TABLE Брак", con) 'Создаем таблицу
            SqlCom.ExecuteNonQuery()
            'MsgBox("Таблица Выдача успешно создана!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message & ". " & SqlCom.CommandText, MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try
        Return con
    End Function
    Public Function Добавляем_поля_Брак()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        con.Open()

        Try
            'Добавляем поля
            SqlCom = New OleDb.OleDbCommand("alter table Брак add [ID] COUNTER NOT NULL  ", con) 'ID - счетчик, ключевое
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Брак add [Дата] DATETIME NULL", con) ' DATA - дата/время, нулевое значение разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Брак add [Наименование оборудования] TEXT NULL", con) 'TEXT - тесктовое, нулевое значение не разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Брак add [Серийный номер] TEXT NOT NULL PRIMARY KEY", con) 'TEXT - тесктовое, нулевое значение не разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Брак add [Получатель] TEXT NULL", con) 'TEXT - тесктовое, нулевое значение не разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Брак add [Табельный номер] TEXT NULL", con) 'TEXT - тесктовое, нулевое значение не разрешено
            SqlCom.ExecuteNonQuery()

            'MsgBox("Поля таблицы успешно созданы!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message & ". " & SqlCom.CommandText, MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try
        Return SqlCom
    End Function

    Public Function Возврат_оборудования()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        Dim insert_date As DateTime
        Dim insert_sn As String
        Dim insert_fio As String
        Dim insert_tn As String
        Dim insert_db As New OleDbCommand
        Dim db_con As New OleDbConnection
        insert_date = Форма_выдача.Label1.Text
        insert_sn = Форма_выдача.TextBox1.Text
        insert_fio = Форма_выдача.ComboBox2.Text
        insert_tn = Форма_выдача.ComboBox2.ValueMember
        insert_sn = Форма_выдача.TextBox4.Text
        Try
            con.Open()
            Dim dt As New DataTable("Выдача")
            Dim rs As New OleDb.OleDbDataAdapter("INSERT INTO  Брак Select '" & insert_date & "' as [Дата], [Наименование оборудования], [Серийный номер], 'Брак' as [Получатель], '" & insert_tn & "' as [Табельный номер] from Выдача WHERE  [Серийный номер] = '" & insert_sn & "'", con)
            rs.Fill(dt)
            Форма_выдача.DataGridView4.DataSource = dt

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        Return SqlCom
    End Function

    Public Function Удаление_запаса()
        con.Open()
        Dim insert_sn As String
        insert_sn = Форма_выдача.TextBox1.Text
        Dim dt As New DataTable("Запасы")
        Dim rs As New OleDb.OleDbDataAdapter("Delete from Запасы WHERE [Серийный номер] = '" & insert_sn & "'", con)
        rs.Fill(dt)
        'Форма_выдача.DataGridView2.DataSource = dt
        con.Close()
    End Function

    Public Function Удаление_выдачи()
        con.Open()
        Dim insert_sn As String
        insert_sn = Форма_выдача.TextBox4.Text
        Dim dt As New DataTable("Выдача")
        Dim rs As New OleDb.OleDbDataAdapter("Delete from Выдача WHERE [Серийный номер] = '" & insert_sn & "'", con)
        rs.Fill(dt)
        'Форма_выдача.DataGridView2.DataSource = dt
        con.Close()
    End Function
End Class
