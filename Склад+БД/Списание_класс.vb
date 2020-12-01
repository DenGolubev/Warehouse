Imports System.Data.OleDb
Public Class Списание_класс
    Dim bd_a As String = "Склад"
    Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
    Dim passDB As String = "" 'пароль базы данных
    Dim con As OleDbConnection
    Dim SqlCom As OleDbCommand

    Dim Сейчас As New Прочие_данные
    Dim adapter As OleDbDataAdapter
    Dim dt As DataTable = New DataTable()
    Public Function Создание_таблицы_Списание()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        con.Open()

        Try
            SqlCom = New OleDbCommand("CREATE TABLE Списание", con) 'Создаем таблицу
            SqlCom.ExecuteNonQuery()
            'MsgBox("Таблица Выдача успешно создана!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message & ". " & SqlCom.CommandText, MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try
        Return con
    End Function
    Public Function Добавляем_поля_Списание()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        con.Open()

        Try
            'Добавляем поля
            SqlCom = New OleDb.OleDbCommand("alter table Списание add [ID] COUNTER NOT NULL  ", con) 'ID - счетчик, ключевое
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Списание add [Дата] DATETIME NULL", con) ' DATA - дата/время, нулевое значение разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Списание add [Номер Акта] TEXT NOT NULL", con) 'TEXT - тесктовое, нулевое значение не разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Списание add [Наименование оборудования] TEXT NULL", con) 'TEXT - тесктовое, нулевое значение не разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Списание add [Серийный номер] TEXT NOT NULL PRIMARY KEY", con) 'TEXT - тесктовое, нулевое значение не разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Списание add [Получатель] TEXT NULL", con) 'TEXT - тесктовое, нулевое значение не разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Списание add [Табельный номер] TEXT NULL", con) 'TEXT - тесктовое, нулевое значение не разрешено
            SqlCom.ExecuteNonQuery()

            'MsgBox("Поля таблицы успешно созданы!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message & ". " & SqlCom.CommandText, MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try
        Return SqlCom
    End Function
    Public Function Списание_оборудования()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        Dim insert_date As DateTime
        Dim insert_sn As String
        Dim insert_fio As String
        Dim insert_tn As String
        Dim insert_akt As String
        Dim insert_db As New OleDbCommand
        Dim db_con As New OleDbConnection
        insert_date = Форма_выдача.Label1.Text
        insert_akt = Форма_выдача.TextBox2.Text
        insert_fio = Форма_выдача.ComboBox2.Text
        insert_tn = Форма_выдача.ComboBox2.ValueMember
        insert_sn = Форма_выдача.TextBox5.Text
        Try
            con.Open()
            Dim dt As New DataTable("Выдача")
            Dim rs As New OleDb.OleDbDataAdapter("INSERT INTO  Списание Select '" & insert_date & "' as [Дата], '" & insert_akt & "' as [Номер Акта],  [Наименование оборудования], [Серийный номер], '" & insert_fio & "' as [Получатель], '" & insert_tn & "' as [Табельный номер] from Выдача WHERE  [Серийный номер] = '" & insert_sn & "'", con)
            rs.Fill(dt)
            Форма_выдача.DataGridView5.DataSource = dt
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
        insert_sn = Форма_выдача.TextBox5.Text
        Dim dt As New DataTable("Запасы")
        Dim rs As New OleDb.OleDbDataAdapter("Delete from Запасы WHERE [Серийный номер] = '" & insert_sn & "'", con)
        rs.Fill(dt)
        'Форма_выдача.DataGridView2.DataSource = dt
        con.Close()
    End Function

    Public Function Удаление_выдачи()
        con.Open()
        Dim insert_sn As String
        insert_sn = Форма_выдача.TextBox5.Text
        Dim dt As New DataTable("Выдача")
        Dim rs As New OleDb.OleDbDataAdapter("Delete from Выдача WHERE [Серийный номер] = '" & insert_sn & "'", con)
        rs.Fill(dt)
        'Форма_выдача.DataGridView2.DataSource = dt
        con.Close()
    End Function
End Class
