﻿Imports System.Data.OleDb
Public Class Форма_выдача
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

    Private Sub Выдача_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Выдача_класс.Проверка_выдача()
        Label1.Text = Сейчас.Полная_дата
        Кладовщик_lable()
        DataGreed_Выдача()
        DataGreed_Списание()
        Счетчики.DataGreed_счетчик_Номенклатура()

    End Sub

    Sub Combo_box()
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
        Dim passDB As String = "" 'пароль базы данных
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        Dim dt As New DataTable("Сотрудники")
        Dim rs As New OleDbDataAdapter("Select Фамилия + ' ' + Имя + ' ' + Отчество  as Фамилия, [Табельный номер] from Сотрудники", con)
        BD.Коннект_on()
        rs.Fill(dt)
        ComboBox2.DataSource = dt
        ComboBox2.DisplayMember = ("Фамилия")
        ComboBox2.ValueMember = "Табельный номер"
        'ComboBox2.Update()
        'ComboBox2.Refresh()
        rs.Dispose()
        BD.Коннект_off()
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown

        Dim i As Integer = 1
        If e.KeyCode = Keys.Enter Then
            Выдача_класс.Выдача_оборудования()
            Выдача_класс.Удаление_запаса()
            TextBox1.Clear()
            DataGreed_Выдача()
            DataGreed_Списание()

        End If

    End Sub

    Sub DataGreed_Выдача()
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
        Dim passDB As String = "" 'пароль базы данных
        Dim dm As String
        dm = ComboBox2.DisplayMember
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        BD.Коннект_on()
        Dim dt As New DataTable("Выдача")
        Dim rs As New OleDb.OleDbDataAdapter("Select * from Выдача where '" & dm & "'", con)
        rs.Fill(dt)
        DataGridView2.DataSource = dt
        DataGridView2.Update()
        DataGridView2.Refresh()
        'Сотрудники.TextBox4.Text = dt.Rows.Count
        rs.Dispose()
        BD.Коннект_off()
    End Sub

    Sub DataGreed_Списание()
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
        Dim passDB As String = "" 'пароль базы данных
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        BD.Коннект_on()
        Dim dt As New DataTable("Списание")
        Dim rs As New OleDb.OleDbDataAdapter("Select * from Списание", con)
        rs.Fill(dt)
        DataGridView5.DataSource = dt
        DataGridView5.Update()
        DataGridView5.Refresh()
        'Сотрудники.TextBox4.Text = dt.Rows.Count
        rs.Dispose()
        BD.Коннект_off()
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

    Private Sub ComboBox2_DisplayMemberChanged(sender As Object, e As EventArgs) Handles ComboBox2.DisplayMemberChanged
        DataGreed_Выдача()
    End Sub

    Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox2.Text = Nothing Then
                MsgBox("Введите номер Акта")
                TextBox5.Clear()
            Else
                Списание.Списание_оборудования()
                Списание.Удаление_выдачи()
                TextBox5.Clear()
                DataGreed_Выдача()
                DataGreed_Списание()
            End If


        End If
    End Sub

    Private Sub ОстаткиНаМонтажникеToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ОстаткиНаМонтажникеToolStripMenuItem.Click
        Отчет_по_монтажнику.Show()

    End Sub
End Class