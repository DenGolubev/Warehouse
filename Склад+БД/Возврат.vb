Imports System.Data.OleDb
Public Class Форма_возврат
    Dim Сейчас As New Прочие_данные
    Dim Поставка As New Поставка_класс
    Dim BD As New БД
    Dim con As OleDb.OleDbConnection
    Dim dgv As New DataGridView
    Dim Склад_БД As New БД
    Dim Сотрудники As New Сотрудники_класс
    Dim Выдача_класс As New Выдача_класс
    Dim Брак As New Брак_класс
    Dim Списание As New Списание_класс
    Dim Счетчики As New Счетчики_класс
    Dim Возврат As New Возврат_класс
    Private Sub Форма_возврат_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGreed_Возврат()
        Label1.Text = Сейчас.Полная_дата
        Кладовщик_lable()

    End Sub

    Sub DataGreed_Возврат()
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
        Dim passDB As String = "" 'пароль базы данных
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        BD.Коннект_on()
        Dim dt As New DataTable("Запасы")
        Dim rs As New OleDb.OleDbDataAdapter("Select * from Запасы", con)
        rs.Fill(dt)
        DataGridView3.DataSource = dt
        DataGridView3.Update()
        DataGridView3.Refresh()
        'Сотрудники.TextBox4.Text = dt.Rows.Count
        rs.Dispose()
        BD.Коннект_off()
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        Dim i As Integer = 1
        If e.KeyCode = Keys.Enter Then
            Возврат.Возврат_оборудования()
            Возврат.Удаление_выдачи()
            TextBox3.Clear()
            DataGreed_Возврат()
        End If
    End Sub

    Sub Кладовщик_lable()
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
        Dim passDB As String = "" 'пароль базы данных
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        Dim dt As New DataTable("Сотрудники")
        con.Open()
        Dim insCom As New OleDb.OleDbCommand("Select Кладовщик from Кладовщик", con)
        Label10.Text = insCom.ExecuteScalar
        con.Close()
    End Sub
End Class