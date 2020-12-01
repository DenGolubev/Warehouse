Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class Сохранить_в_файл
    Public Function Сохранить_excel()
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Worksheets(1)
        For i = 0 To Отчет_по_монтажнику.DataGridView1.RowCount - 2
            For j = 0 To Отчет_по_монтажнику.DataGridView1.ColumnCount - 1
                xlWorkSheet.Cells(i + 1, j + 1) =
                    Отчет_по_монтажнику.DataGridView1(j, i).Value.ToString()
            Next
        Next

        xlWorkSheet.SaveAs(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & "Отчеты" & "\" & Format(Now, "Long Date") & Отчет_по_монтажнику.ComboBox1.Text & ".xls")
        xlWorkBook.Close()
        xlApp.Quit()

        MsgBox("Ваш файл сохранен")
    End Function

End Class
