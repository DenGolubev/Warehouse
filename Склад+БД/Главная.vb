Imports System.ComponentModel
Imports System.Data.OleDb
Public Class Форма_главная
    Dim Сейчас As New Прочие_данные
    Dim Склад_БД As New БД
    Dim Поставка As New Поставка_класс
    Dim Сотрудники As New Сотрудники_класс
    Dim Выдача As New Выдача_класс
    Dim Номенклатура As New Номенклатура_класс
    Dim Запасы As New Запасы_класс
    Dim Кладовщик As New Кладовщики_класс
    Dim con As OleDb.OleDbConnection
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CurDir As String = My.Application.Info.DirectoryPath
        Dim CusBD As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim CurFile As String = My.Application.Info.ToString
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"

        Label2.Text = pathDB
        Кладовщик_lable()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Склад_БД.База_Данных()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Склад_БД.Очистить_поля()
    End Sub

    Private Sub ПриемСотрудникаToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ПриемСотрудникаToolStripMenuItem.Click
        Форма_сотрудники.Show()
    End Sub

    Private Sub ВыдачаToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВыдачаToolStripMenuItem.Click
        Форма_выдача.Show()
    End Sub

    Private Sub УдалитьБДToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles УдалитьБДToolStripMenuItem.Click
        Склад_БД.Удаление_БД()
        Application.Exit()
    End Sub

    Private Sub ДобавитьТаблицуСотрудникиToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ДобавитьТаблицуСотрудникиToolStripMenuItem.Click
        Сотрудники.Создание_таблицы_Сотрудники()
        Сотрудники.Добавляем_поля_Сотрудники()
    End Sub

    Private Sub ДобавитьТаблицуВыдачаToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ДобавитьТаблицуВыдачаToolStripMenuItem.Click
        Выдача.Создание_таблицы_Выдача()
        Выдача.Добавляем_поля_Выдача()
    End Sub

    Private Sub ДобавитьТаблицуПоставкаToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ДобавитьТаблицуПоставкаToolStripMenuItem.Click
        Поставка.Создание_таблицы_Поставка()
        Поставка.Добавляем_поля_Поставка()
    End Sub

    Private Sub ДобавитьНоменклатуруToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ДобавитьНоменклатуруToolStripMenuItem.Click
        Форма_номенклатура.Show()
    End Sub

    Private Sub ДобавитьТаблицуНоменклатураToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ДобавитьТаблицуНоменклатураToolStripMenuItem.Click
        Номенклатура.Создание_таблицы_Номенклатура()
        Номенклатура.Добавляем_поля_Номенклатура()
    End Sub

    Private Sub ПоставкаToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ПоставкаToolStripMenuItem.Click
        Форма_поставка.Show()
    End Sub

    Private Sub ДобавитьТаблицуЗапасыToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ДобавитьТаблицуЗапасыToolStripMenuItem.Click
        Запасы.Создание_таблицы_Запасы()
        Запасы.Добавляем_поля_Запасы()
    End Sub

    Private Sub ЗапасыToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ЗапасыToolStripMenuItem.Click
        Форма_Запасы.Show()
    End Sub

    Private Sub ВыходToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВыходToolStripMenuItem.Click
        Кладовщик.Удалить_таблицу_Кладовщик()
        Application.Exit()
    End Sub

    Private Sub СформироватьТаблицыToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СформироватьТаблицыToolStripMenuItem.Click
        Форма_кладовщик.PB()
    End Sub

    Private Sub Форма_главная_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Кладовщик.Удалить_таблицу_Кладовщик()
        Application.Exit()
    End Sub

    Sub Кладовщик_lable()
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
        Dim passDB As String = "" 'пароль базы данных
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        con.Open()
        Dim insCom As New OleDb.OleDbCommand("Select [Табельный номер] from Кладовщик", con)
        Label3.Text = insCom.ExecuteScalar
        con.Close()
    End Sub

    Private Sub БракToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles БракToolStripMenuItem.Click
        Форма_брак.Show()
    End Sub

    Private Sub ВозвратToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВозвратToolStripMenuItem.Click
        Форма_возврат.Show()
    End Sub
End Class
