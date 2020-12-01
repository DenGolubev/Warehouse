Imports System.Data.OleDb

Public Class Отчет_по_монтажнику
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
    Dim Почта As New Отправить_на_почту
    Dim Сохранить As New Сохранить_в_файл

    Sub Combo_box()
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
        Dim passDB As String = "" 'пароль базы данных
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        Dim dt As New DataTable("Сотрудники")
        Dim rs As New OleDbDataAdapter("Select Фамилия + ' ' + Имя + ' ' + Отчество  as Фамилия, [Табельный номер] from Сотрудники", con)
        BD.Коннект_on()
        rs.Fill(dt)
        ComboBox1.DataSource = dt
        ComboBox1.DisplayMember = ("Фамилия")
        ComboBox1.ValueMember = "Табельный номер"
        'ComboBox2.Update()
        'ComboBox2.Refresh()
        rs.Dispose()
        BD.Коннект_off()

    End Sub

    Public Function DataGreed_счетчик_Номенклатура()
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
        Dim passDB As String = "" 'пароль базы данных
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        BD.Коннект_on()
        Dim dt As New DataTable("Выдача")
        Dim rs As New OleDb.OleDbDataAdapter("Select Дата, [Наименование оборудования], [Серийный номер] from Выдача where Получатель = '" & ComboBox1.Text & "' ORDER BY  [Наименование оборудования] ", con)
        rs.Fill(dt)
        'Форма_выдача.Label15.Text = dt.Rows.Count
        DataGridView1.DataSource = dt
        DataGridView1.Update()
        DataGridView1.Refresh()
        rs.Dispose()
        BD.Коннект_off()
    End Function

    Private Sub Отчет_по_монтажнику_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Combo_box()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGreed_счетчик_Номенклатура()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Сохранить.Сохранить_excel()
        'Почта.Отправить_на_почту()
    End Sub

End Class