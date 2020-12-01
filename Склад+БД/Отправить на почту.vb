Imports System.Net.Mail
Public Class Отправить_на_почту


    Public Function Отправить_на_почту()
        Dim mail As New MailMessage()
        mail.From = New MailAddress("мыло от кого")
        mail.To.Add("мыло Кому")
        mail.Subject = "Тема"
        mail.Body = "Письмо"
        mail.IsBodyHtml = True

        Try
            mail.Attachments.Add(New Attachment(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Отчеты" & "\" & Отчет_по_монтажнику.ComboBox1.Text & ".xls"))
        Catch ex As Exception
        End Try

        Dim smtp As New SmtpClient("smtp.yandex.ru", "25") 'Например
        smtp.Credentials = New System.Net.NetworkCredential("Мыло отправителя", "Пароль отправителя")
        Try
            smtp.Send(mail)
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Critical)
        Finally
            mail.Dispose()
            smtp = Nothing
        End Try
    End Function


End Class
