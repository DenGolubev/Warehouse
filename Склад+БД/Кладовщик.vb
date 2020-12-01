Imports System.Data.OleDb
Public Class Форма_кладовщик
    Dim Сейчас As New Прочие_данные
    Dim Поставка As New Поставка_класс
    Dim BD As New БД
    Dim con As OleDb.OleDbConnection
    Dim dgv As New DataGridView
    Dim Склад_БД As New БД
    Dim Сотрудники As New Сотрудники_класс
    Dim Выдача_класс As New Выдача_класс
    Dim Кладовщик_класс As New Кладовщики_класс
    Dim Выдача As New Выдача_класс
    Dim Номенклатура As New Номенклатура_класс
    Dim Запасы As New Запасы_класс
    Dim Кладовщик As New Кладовщики_класс
    Dim Брак As New Брак_класс
    Dim Списание As New Списание_класс
    Private Sub Форма_кладовщик_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.FileExists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb") Then
            My.Computer.FileSystem.CopyFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Архив\" & "Склад" & ".mdb", FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
            MsgBox("База данных успешно подключена")
            Combo_box()
        Else
            Склад_БД.База_Данных()
            PB()
            Форма_сотрудники.Show()
        End If

        Label2.Text = Сейчас.Полная_дата
    End Sub
    Sub Combo_box()
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
        Dim passDB As String = "" 'пароль базы данных
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & pathDB & ";Jet OLEDB:Database Password=" & passDB)
        Dim dt As New DataTable("Сотрудники")
        Dim rs As New OleDbDataAdapter("Select Фамилия + ' ' + Имя + ' ' + Отчество as Фамилия from Сотрудники where Статус = 'Менеджер'", con)
        con.Open()

        rs.Fill(dt)
        ComboBox1.DataSource = dt
        ComboBox1.DisplayMember = ("Фамилия")
        ComboBox1.ValueMember = ""


        'ComboBox2.Update()
        'ComboBox2.Refresh()
        rs.Dispose()
        con.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Кладовщик_класс.Ввод_Данных_Кладовщика()
        Me.Hide()
        Форма_главная.Show()
    End Sub

    Sub PB()
        Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
        Dim i As Integer = 1
        Try
            Dim wM = ProgressBar1.Maximum
            Call Номенклатура.Создание_таблицы_Номенклатура()
            ProgressBar1.Value = wM * 0.0625
            Application.DoEvents()
            Call Номенклатура.Добавляем_поля_Номенклатура()
            ProgressBar1.Value = wM * 0.125
            Application.DoEvents()
            Call Запасы.Создание_таблицы_Запасы()
            ProgressBar1.Value = wM * 0.188
            Application.DoEvents()
            Call Запасы.Добавляем_поля_Запасы()
            ProgressBar1.Value = wM * 0.25
            Application.DoEvents()
            Call Сотрудники.Создание_таблицы_Сотрудники()
            ProgressBar1.Value = wM * 0.313
            Application.DoEvents()
            Call Сотрудники.Добавляем_поля_Сотрудники()
            ProgressBar1.Value = wM * 0.375
            Application.DoEvents()
            Call Выдача.Создание_таблицы_Выдача()
            ProgressBar1.Value = wM * 0.438
            Application.DoEvents()
            Call Выдача.Добавляем_поля_Выдача()
            ProgressBar1.Value = wM * 0.5
            Application.DoEvents()
            Call Поставка.Создание_таблицы_Поставка()
            ProgressBar1.Value = wM * 0.562
            Application.DoEvents()
            Call Поставка.Добавляем_поля_Поставка()
            ProgressBar1.Value = wM * 0.625
            Application.DoEvents()
            Call Кладовщик.Создание_таблицы_Кладовщик()
            ProgressBar1.Value = wM * 0.688
            Application.DoEvents()
            Call Кладовщик.Добавляем_поля_Кладовщик()
            ProgressBar1.Value = wM * 0.75
            Application.DoEvents()
            Call Брак.Создание_таблицы_Брак()
            ProgressBar1.Value = wM * 0.813
            Application.DoEvents()
            Call Брак.Добавляем_поля_Брак()
            ProgressBar1.Value = wM * 0.88
            Application.DoEvents()
            Call Списание.Создание_таблицы_Списание()
            ProgressBar1.Value = wM * 0.938
            Application.DoEvents()
            Call Списание.Добавляем_поля_Списание()
            ProgressBar1.Value = wM
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub


End Class