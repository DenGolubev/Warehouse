Imports System.Data.OleDb
Public Class БД
    Dim bd_a As String = "Склад"
    Dim pathDB As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb"
    Dim passDB As String = "" 'пароль базы данных
    Dim con As OleDb.OleDbConnection
    Dim SqlCom As OleDb.OleDbCommand
    Dim Сейчас As New Прочие_данные
    Dim adapter As OleDbDataAdapter
    Dim dt As DataTable = New DataTable()

    Public Function База_Данных()
        Try
            Dim BD As ADOX.Catalog = New ADOX.Catalog()
            BD.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb" & ";Jet OLEDB:Engine Type=5;Jet OLEDB:Database Password=" & passDB) 'Создание базы
            BD = Nothing
            MsgBox("База данных '" & "Склад" & "' успешно создана. Необходимо создать таблицы путем нажатия на кнопку Создать таблицы")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return bd_a
    End Function

    Public Function Очистить_поля()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb" & ";Jet OLEDB:Database Password=" & passDB)
        Dim insert_db As New OleDbCommand
        Dim db_con As New OleDbConnection
        con.Open()
        SqlCom = New OleDbCommand("Select * FROM  Поставка, Запасы, Выдача where [Серийный номер] = '""' ", con)
        SqlCom.ExecuteNonQuery()
        con.Close()
        MsgBox("Данные Удалены!", MsgBoxStyle.Information)
        Return SqlCom
    End Function

    Public Function Удаление_БД()
        Коннект_off()
        My.Computer.FileSystem.DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb",
        Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
        Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently,
        Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        Return MsgBox("База данных '" & "Склад" & "' Была безвозвратно удалена с вашего компьютера. ")
    End Function

    Public Function Коннект_on()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb" & ";Jet OLEDB:Database Password=" & passDB)
        con.Open()
        Return con
    End Function

    Public Function Коннект_off()
        con = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Склад" & ".mdb" & ";Jet OLEDB:Database Password=" & passDB)
        con.Close()
        Return con
    End Function


End Class
