Imports System.Data.OleDb
Imports System.Globalization

Public Class Форма_поставка
    Dim Сейчас As New Прочие_данные
    Dim Поставка As New Поставка_класс
    Dim Счетчики As New Счетчики_класс
    Dim BD As New БД
    Dim con As OleDb.OleDbConnection
    Dim dgv As New DataGridView
    Dim Клад As String
    Private Sub Поставка_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Combo_box()
        Lable_box()
        Label1.Text = Сейчас.Полная_дата
        DataGreed()
        DataGreed_Поиск()
        Счетчики.DataGreed_счетчик_Выдано()
        Счетчики.DataGreed_счетчик_на_Складе()
        Счетчики.DataGreed_счетчик_Списано()
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(New CultureInfo("en-US"))
        Dim i As Integer = 1
        If e.KeyCode = Keys.Enter Then
            Поставка.Ввод_Данных()
            TextBox1.Clear()
            DataGreed()
        End If
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        Dim i As Integer = 1
        If e.KeyCode = Keys.Enter Then
            Поставка.Поиск_данных()
            TextBox3.Clear()
            'DataGreed_Поиск()
        End If
    End Sub

    Sub DataGreed()
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
        Dim passDB As String = "" 'пароль базы данных
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        BD.Коннект_on()
        Dim dt As New DataTable("Поставка")
        Dim rs As New OleDb.OleDbDataAdapter("Select * from Поставка", con)
        rs.Fill(dt)
        DataGridView1.DataSource = dt
        DataGridView1.Update()
        DataGridView1.Refresh()
        'Сотрудники.TextBox4.Text = dt.Rows.Count
        rs.Dispose()
        BD.Коннект_off()
    End Sub
    Sub Combo_box()
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
        Dim passDB As String = "" 'пароль базы данных
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        BD.Коннект_on()
        Dim dt As New DataTable("Номенклатура_оборудования")
        Dim rs As New OleDb.OleDbDataAdapter("Select * from Номенклатура_оборудования", con)
        rs.Fill(dt)
        ComboBox1.DataSource = dt
        ComboBox1.DisplayMember = ("Наименование оборудования")
        ComboBox1.ValueMember = "ID"
        ComboBox1.Update()
        ComboBox1.Refresh()
        rs.Dispose()
        BD.Коннект_off()
    End Sub

    Sub Lable_box()
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
        Dim passDB As String = "" 'пароль базы данных
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        BD.Коннект_on()
        Dim dt As New DataTable("Кладовщик")
        Dim rs As New OleDb.OleDbDataAdapter("Select * from Кладовщик", con)
        rs.Fill(dt)
        ComboBox2.DataSource = dt
        ComboBox2.DisplayMember = ("Кладовщик")
        ComboBox2.ValueMember = "Табельный номер"
        ComboBox2.Update()
        ComboBox2.Refresh()
        rs.Dispose()
        BD.Коннект_off()
    End Sub

    Sub DataGreed_Поиск()
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
        Dim passDB As String = "" 'пароль базы данных
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        BD.Коннект_on()
        Dim dt As New DataTable("Запасы")
        Dim rs As New OleDb.OleDbDataAdapter("Select * from Запасы", con)
        rs.Fill(dt)
        DataGridView2.DataSource = dt
        DataGridView2.Update()
        DataGridView2.Refresh()
        'Сотрудники.TextBox4.Text = dt.Rows.Count
        rs.Dispose()
        BD.Коннект_off()
    End Sub


End Class