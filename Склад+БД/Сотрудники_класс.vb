Imports System.Data.OleDb
Public Class Сотрудники_класс
    Dim bd_a As String = "Склад"
    Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
    Dim passDB As String = "" 'пароль базы данных
    Dim con As OleDb.OleDbConnection
    Dim SqlCom As OleDb.OleDbCommand
    Dim Сейчас As New Прочие_данные
    Dim adapter As OleDbDataAdapter
    Dim dt As DataTable = New DataTable()

    Public Function Создание_таблицы_Сотрудники()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        con.Open()
        Try
            SqlCom = New OleDbCommand("CREATE TABLE Сотрудники", con) 'Создаем таблицу
            SqlCom.ExecuteNonQuery()
            'MsgBox("Таблица Сотрудники успешно создана!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message & ". " & SqlCom.CommandText, MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try
        Return con
    End Function

    Public Function Добавляем_поля_Сотрудники()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        con.Open()

        Try
            'Добавляем поля
            SqlCom = New OleDb.OleDbCommand("alter table Сотрудники add [ID] COUNTER NOT NULL ", con) 'ID - счетчик, ключевое
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Сотрудники add [Дата приема на работу] DATETIME NOT NULL", con) ' DATA - дата/время, нулевое значение разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Сотрудники add [Фамилия] TEXT NOT NULL", con) 'CHISLO - числовое, обязательное, по умолчанию 0
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Сотрудники add [Имя] TEXT NOT NULL ", con) 'TEXT - тесктовое, нулевое значение разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Сотрудники add [Отчество] TEXT NOT NULL ", con) 'TEXT - тесктовое, нулевое значение разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Сотрудники add [Дата рождения] DATETIME NOT NULL ", con) 'TEXT - тесктовое, нулевое значение разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Сотрудники add [Образование] TEXT NOT NULL ", con) 'TEXT - тесктовое, нулевое значение разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Сотрудники add [Семейное положение] TEXT NOT NULL ", con) 'TEXT - тесктовое, нулевое значение разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Сотрудники add [Телефон] TEXT NOT NULL ", con) 'TEXT - тесктовое, нулевое значение разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Сотрудники add [Адрес прописки] TEXT   NULL ", con) 'TEXT - тесктовое, нулевое значение разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Сотрудники add [Паспортные данные] TEXT  NULL ", con) 'TEXT - тесктовое, нулевое значение разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Сотрудники add [Табельный номер] TEXT  NOT NULL PRIMARY KEY ", con) 'TEXT - тесктовое, нулевое значение разрешено
            SqlCom.ExecuteNonQuery()

            SqlCom = New OleDb.OleDbCommand("alter table Сотрудники add [Статус] TEXT  NULL ", con) 'TEXT - тесктовое, нулевое значение разрешено
            SqlCom.ExecuteNonQuery()

            'MsgBox("Поля таблицы успешно созданы!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message & ". " & SqlCom.CommandText, MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try
        Return SqlCom
    End Function

    Public Function Ввод_Данных_Сотрудников()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        Dim Дата_приема As DateTime = Форма_сотрудники.MaskedTextBox2.Text
        Dim Фамилия As String = Форма_сотрудники.TextBox1.Text
        Dim Имя As String = Форма_сотрудники.TextBox2.Text
        Dim Отчество As String = Форма_сотрудники.TextBox3.Text
        Dim Дата_рождения As DateTime = Форма_сотрудники.MaskedTextBox3.Text
        Dim Образование As String = Форма_сотрудники.TextBox5.Text
        Dim Семейное_положение As String = Форма_сотрудники.ComboBox1.Text
        Dim Телефон As String = Форма_сотрудники.MaskedTextBox1.Text
        Dim Адрес_прописки As String = Форма_сотрудники.TextBox7.Text
        Dim Паспортные_данные As String = Форма_сотрудники.TextBox6.Text
        Dim Табельный_номер As String = Форма_сотрудники.MaskedTextBox4.Text
        Dim Статус As String = Форма_сотрудники.ComboBox2.Text
        Dim insert_db As New OleDbCommand
        Dim db_con As New OleDbConnection
        con.Open()
        SqlCom = New OleDbCommand("INSERT INTO  Сотрудники ([Дата приема на работу], [Фамилия], [Имя], [Отчество], [Дата рождения], [Образование], [Семейное положение], [Телефон], [Адрес прописки], [Паспортные данные], [Табельный номер], [Статус])  VALUES ('" & Дата_приема & "', '" & Фамилия & "', '" & Имя & "', '" & Отчество & "', '" & Дата_рождения & "', '" & Образование & "', '" & Семейное_положение & "', '" & Телефон & "', '" & Адрес_прописки & "', '" & Паспортные_данные & "', '" & Табельный_номер & "', '" & Статус & "')", con)
        SqlCom.ExecuteNonQuery()
        con.Close()
        MsgBox("Данные добавлены!", MsgBoxStyle.Information)
        Return SqlCom
    End Function

    Public Function DGV()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        con.Open()
        Dim dt As New DataTable("Сотрудники")
        Dim rs As New OleDb.OleDbDataAdapter("Select * from Сотрудники", con)
        rs.Fill(dt)
        Форма_сотрудники.DataGridView1.DataSource = dt
        Форма_сотрудники.DataGridView1.Update()
        Форма_сотрудники.DataGridView1.Refresh()

        Форма_сотрудники.TextBox4.Text = dt.Rows.Count

        rs.Dispose()

        con.Close()
        Return dt
    End Function

    Public Function Поиск_данных()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        con.Open()
        Dim fnd As String
        fnd = Форма_сотрудники.MaskedTextBox4.Text
        Dim dt As New DataTable("Сотрудники")
        Dim rs As New OleDb.OleDbDataAdapter("Select * from Сотрудники WHERE [Табельный номер] = '" & fnd & "'", con)
        rs.Fill(dt)
        Форма_сотрудники.DataGridView2.DataSource = dt
        Return con
    End Function

End Class
