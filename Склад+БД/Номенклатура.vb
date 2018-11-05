Imports System.Data.OleDb
Public Class Форма_номенклатура
    Dim Сейчас As New Прочие_данные
    Dim Поставка As New Поставка_класс
    Dim BD As New БД
    Dim con As OleDb.OleDbConnection
    Dim dgv As New DataGridView
    Dim Склад_БД As New БД
    Dim Сотрудники As New Сотрудники_класс
    Dim Номенклатура As New Номенклатура_класс
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Номенклатура.Ввод_Данных()
    End Sub

    Private Sub Форма_номенклатура_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGreed()
    End Sub
    Sub DataGreed()
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
        Dim passDB As String = "" 'пароль базы данных
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        BD.Коннект_on()
        Dim dt As New DataTable("Сотрудники")
        Dim rs As New OleDb.OleDbDataAdapter("Select * from Номенклатура_оборудования", con)
        rs.Fill(dt)
        DataGridView1.DataSource = dt
        DataGridView1.Update()
        DataGridView1.Refresh()
        TextBox4.Text = dt.Rows.Count
        rs.Dispose()
        BD.Коннект_off()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        Dim i As Integer = 1
        If e.KeyCode = Keys.Enter Then
            Номенклатура.Ввод_Данных()
            TextBox1.Clear()
            DataGreed()
        End If
    End Sub
End Class