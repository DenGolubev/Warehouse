Imports System.Data.OleDb
Public Class Поставка_класс
    Dim bd_a As String = "Склад"
    Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
    Dim passDB As String = "" 'пароль базы данных
    Dim con As OleDb.OleDbConnection
    Dim SqlCom As OleDb.OleDbCommand
    Dim Сейчас As New Прочие_данные
    Dim adapter As OleDbDataAdapter
    Dim dt As DataTable = New DataTable()
    Public Function Создание_таблицы_Поставка()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        con.Open()

        Try
            SqlCom = New OleDbCommand("CREATE TABLE Поставка", con) 'Создаем таблицу
            SqlCom.ExecuteNonQuery()
            'MsgBox("Таблица Поставка успешно создана!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message & ". " & SqlCom.CommandText, MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try
        Return con

    End Function
    Public Function Добавляем_поля_Поставка()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        con.Open()

        Try
            'Добавляем поля
            SqlCom = New OleDb.OleDbCommand("alter table Поставка add [ID] COUNTER NOT NULL  ", con) 'ID - счетчик, ключевое
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Поставка add [Дата] DATETIME NOT NULL", con) ' DATA - дата/время, нулевое значение разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Поставка add [Наименование оборудования] TEXT NOT NULL", con) 'CHISLO - числовое, обязательное, по умолчанию 0
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Поставка add [Серийный номер] TEXT NOT NULL PRIMARY KEY", con) 'TEXT - тесктовое, нулевое значение разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Поставка add [Получатель] TEXT NOT NULL", con) 'TEXT - тесктовое, нулевое значение разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Поставка add [Табельный номер] TEXT NOT NULL", con) 'TEXT - тесктовое, нулевое значение разрешено
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
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
        Dim passDB As String = "" 'пароль базы данных
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        Dim insert_date As DateTime
        Dim insert_brand As String
        Dim insert_sn As String
        Dim insert_poluchatel As String
        Dim insert_tn As String
        Dim insert_db As New OleDbCommand
        Dim db_con As New OleDbConnection
        insert_date = Форма_поставка.Label1.Text
        insert_brand = Форма_поставка.ComboBox1.Text
        insert_sn = Форма_поставка.TextBox1.Text
        insert_poluchatel = Форма_поставка.ComboBox2.Text
        insert_tn = Форма_поставка.ComboBox2.ValueMember
        Try
            con.Open()
            SqlCom = New OleDbCommand("INSERT INTO  Поставка ([Дата], [Наименование оборудования], [Серийный номер], [Получатель], [Табельный номер])  VALUES ('" & insert_date & "', '" & insert_brand & "', '" & insert_sn & "', '" & insert_poluchatel & "', '" & insert_tn & "')", con)
            SqlCom.ExecuteNonQuery()
            SqlCom = New OleDbCommand("INSERT INTO  Запасы ([Дата], [Наименование оборудования], [Серийный номер], [Получатель], [Табельный номер])  VALUES ('" & insert_date & "', '" & insert_brand & "', '" & insert_sn & "', '" & insert_poluchatel & "', '" & insert_tn & "')", con)
            SqlCom.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        con.Close()
        'MsgBox("Данные добавлены!", MsgBoxStyle.Information)
        Return SqlCom
    End Function
    Public Function DataGridViewForm1()
        Dim i As Integer
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        con.Open()
        Dim dt As New DataTable("Поставка")
        Dim rs As New OleDb.OleDbDataAdapter("Select * from Поставка", con)
        rs.Fill(dt)
        Форма_сотрудники.DataGridView1.DataSource = dt
        Форма_сотрудники.DataGridView1.Refresh()
        For i = 1 To 5
            rs.Fill(dt)
            Форма_сотрудники.DataGridView1.DataSource = dt
        Next
        'Сотрудники.TextBox4.Text = dt.Rows.Count

        rs.Dispose()

        con.Close()
        Return dt
    End Function
End Class
