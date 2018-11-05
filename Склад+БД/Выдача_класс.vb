Imports System.Data.OleDb
Public Class Выдача_класс
    Dim bd_a As String = "Склад"
    Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
    Dim passDB As String = "" 'пароль базы данных
    Dim con As OleDbConnection
    Dim SqlCom As OleDbCommand

    Dim Сейчас As New Прочие_данные
    Dim adapter As OleDbDataAdapter
    Dim dt As DataTable = New DataTable()
    Public Function Создание_таблицы_Выдача()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        con.Open()

        Try
            SqlCom = New OleDbCommand("CREATE TABLE Выдача", con) 'Создаем таблицу
            SqlCom.ExecuteNonQuery()
            'MsgBox("Таблица Выдача успешно создана!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message & ". " & SqlCom.CommandText, MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try
        Return con
    End Function
    Public Function Добавляем_поля_Выдача()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        con.Open()

        Try
            'Добавляем поля
            SqlCom = New OleDb.OleDbCommand("alter table Выдача add [ID] COUNTER NOT NULL  ", con) 'ID - счетчик, ключевое
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Выдача add [Дата] DATETIME NULL", con) ' DATA - дата/время, нулевое значение разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Выдача add [Наименование оборудования] TEXT NULL", con) 'TEXT - тесктовое, нулевое значение не разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Выдача add [Серийный номер] TEXT NOT NULL PRIMARY KEY", con) 'TEXT - тесктовое, нулевое значение не разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Выдача add [Получатель] TEXT NULL", con) 'TEXT - тесктовое, нулевое значение не разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Выдача add [Табельный номер] TEXT NULL", con) 'TEXT - тесктовое, нулевое значение не разрешено
            SqlCom.ExecuteNonQuery()

            'MsgBox("Поля таблицы успешно созданы!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message & ". " & SqlCom.CommandText, MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try
        Return SqlCom
    End Function
    Public Function Проверка_выдача()
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
        Dim passDB As String = "" 'пароль базы данных
        Dim i As Integer
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        con.Open()
        Dim dt As New DataTable("Сотрудники")
        Dim rs As New OleDbDataAdapter("Select * from Сотрудники", con)
        rs.Fill(dt)
        i = dt.Rows.Count
        If i > 0 Then
            Форма_выдача.Text = Сейчас.Полная_дата
            Форма_выдача.Combo_box()
        Else
            Форма_сотрудники.Show()
            Форма_выдача.Close()
        End If
        rs.Dispose()
        con.Close()
    End Function
    Public Function Поиск_данных()
        Dim i As Integer = 1
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        Dim dt As New DataTable()
        Dim fnd As String
        fnd = Форма_выдача.TextBox2.Text
        con.Open()
        Dim rs As New OleDb.OleDbDataAdapter("Select *, 'В Браке' from Брак as [Серийный номер]  WHERE [Серийный номер] = '" & fnd & "' UNION Select *, 'Выдано' from Выдача as [Серийный номер]  WHERE [Серийный номер] = '" & fnd & "' UNION Select *, 'На складе' from Запасы as [Серийный номер]  WHERE [Серийный номер] = '" & fnd & "' UNION Select *, 'Поставка' from Поставка as [Серийный номер]  WHERE [Серийный номер] = '" & fnd & "'", con)
        rs.Fill(dt)
        Форма_выдача.DataGridView1.DataSource = dt
        If dt.Rows.Count > 1 Then
            Форма_выдача.TextBox2.Clear()
        End If

        Return con
    End Function

    Public Function Выдача_оборудования()
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
        Try
            con.Open()
            Dim dt As New DataTable("Запасы")
            Dim rs As New OleDb.OleDbDataAdapter("INSERT INTO  Выдача Select '" & insert_date & "' as [Дата], [Наименование оборудования], [Серийный номер], '" & insert_fio & "' as [Получатель], '" & insert_tn & "' as [Табельный номер] from Запасы WHERE  [Серийный номер] = '" & insert_sn & "'", con)
            rs.Fill(dt)
            Форма_выдача.DataGridView2.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message, )
        Finally
            con.Close()
        End Try

        Return SqlCom
    End Function
    Public Function Возврат_оборудования()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        Dim insert_date As DateTime
        Dim insert_sn As String
        Dim insert_tn As String
        Dim insert_db As New OleDbCommand
        Dim db_con As New OleDbConnection
        insert_date = Форма_выдача.Label1.Text
        insert_sn = Форма_выдача.TextBox3.Text
        insert_tn = Форма_выдача.ComboBox2.ValueMember
        Try
            con.Open()
            Dim dt As New DataTable("Выдача")
            Dim rs As New OleDb.OleDbDataAdapter("INSERT INTO  Запасы Select '" & insert_date & "' as [Дата], [Наименование оборудования], [Серийный номер],'" & Форма_выдача.Label10.Text & "' as [Получатель], '" & insert_tn & "' as [Табельный номер] from Выдача WHERE [Серийный номер] = '" & insert_sn & "'", con)
            rs.Fill(dt)
            Форма_выдача.DataGridView3.DataSource = dt

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
        insert_sn = Форма_выдача.TextBox3.Text
        Dim dt As New DataTable("Выдача")
        Dim rs As New OleDb.OleDbDataAdapter("Delete from Выдача WHERE [Серийный номер] = '" & insert_sn & "'", con)
        rs.Fill(dt)
        'Форма_выдача.DataGridView2.DataSource = dt
        con.Close()
    End Function

End Class
