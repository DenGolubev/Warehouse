Imports System.Data.OleDb
Public Class Возврат_класс
    Dim bd_a As String = "Склад"
    Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
    Dim passDB As String = "" 'пароль базы данных
    Dim con As OleDbConnection
    Dim SqlCom As OleDbCommand

    Dim Сейчас As New Прочие_данные
    Dim adapter As OleDbDataAdapter
    Dim dt As DataTable = New DataTable()

    Public Function Возврат_оборудования()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        Dim insert_date As DateTime
        Dim insert_sn As String
        Dim insert_tn As String
        Dim insert_db As New OleDbCommand
        Dim db_con As New OleDbConnection
        insert_date = Форма_возврат.Label1.Text
        insert_sn = Форма_возврат.TextBox3.Text
        insert_tn = Форма_выдача.ComboBox2.ValueMember
        Try
            con.Open()
            Dim dt As New DataTable("Выдача")
            Dim rs As New OleDb.OleDbDataAdapter("INSERT INTO  Запасы Select '" & insert_date & "' as [Дата], [Наименование оборудования], [Серийный номер],'" & Форма_возврат.Label10.Text & "' as [Получатель], [Табельный номер] from Выдача WHERE [Серийный номер] = '" & insert_sn & "'", con)
            rs.Fill(dt)
            Форма_возврат.DataGridView3.DataSource = dt

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
        insert_sn = Форма_возврат.TextBox3.Text
        Dim dt As New DataTable("Выдача")
        Dim rs As New OleDb.OleDbDataAdapter("Delete from Выдача WHERE [Серийный номер] = '" & insert_sn & "'", con)
        rs.Fill(dt)
        'Форма_выдача.DataGridView2.DataSource = dt
        con.Close()
    End Function

End Class
