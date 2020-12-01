<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Форма_главная
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.СкладToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ВыдачаToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ВозвратToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ПоставкаToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ЗапасыToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.БракToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ВыходToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.СотрудникиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ПриемСотрудникаToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.СевисToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.УдалитьБДToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ДобавитьToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ДобавитьТаблицуПоставкаToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ДобавитьТаблицуВыдачаToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ДобавитьТаблицуСотрудникиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ДобавитьТаблицуНоменклатураToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ДобавитьТаблицуЗапасыToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.СформироватьТаблицыToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.НоменклатураToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ДобавитьНоменклатуруToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ПоставкаBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MenuStrip1.SuspendLayout()
        CType(Me.ПоставкаBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.СкладToolStripMenuItem, Me.СотрудникиToolStripMenuItem, Me.СевисToolStripMenuItem, Me.НоменклатураToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(784, 24)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'СкладToolStripMenuItem
        '
        Me.СкладToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ПоставкаToolStripMenuItem, Me.ВыдачаToolStripMenuItem, Me.ВозвратToolStripMenuItem, Me.БракToolStripMenuItem, Me.ЗапасыToolStripMenuItem, Me.ВыходToolStripMenuItem})
        Me.СкладToolStripMenuItem.Name = "СкладToolStripMenuItem"
        Me.СкладToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.СкладToolStripMenuItem.Text = "Склад"
        '
        'ВыдачаToolStripMenuItem
        '
        Me.ВыдачаToolStripMenuItem.Name = "ВыдачаToolStripMenuItem"
        Me.ВыдачаToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ВыдачаToolStripMenuItem.Text = "Выдача"
        '
        'ВозвратToolStripMenuItem
        '
        Me.ВозвратToolStripMenuItem.Name = "ВозвратToolStripMenuItem"
        Me.ВозвратToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ВозвратToolStripMenuItem.Text = "Возврат"
        '
        'ПоставкаToolStripMenuItem
        '
        Me.ПоставкаToolStripMenuItem.Name = "ПоставкаToolStripMenuItem"
        Me.ПоставкаToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ПоставкаToolStripMenuItem.Text = "Поставка"
        '
        'ЗапасыToolStripMenuItem
        '
        Me.ЗапасыToolStripMenuItem.Name = "ЗапасыToolStripMenuItem"
        Me.ЗапасыToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ЗапасыToolStripMenuItem.Text = "Запасы"
        '
        'БракToolStripMenuItem
        '
        Me.БракToolStripMenuItem.Name = "БракToolStripMenuItem"
        Me.БракToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.БракToolStripMenuItem.Text = "Брак"
        '
        'ВыходToolStripMenuItem
        '
        Me.ВыходToolStripMenuItem.Name = "ВыходToolStripMenuItem"
        Me.ВыходToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ВыходToolStripMenuItem.Text = "Выход"
        '
        'СотрудникиToolStripMenuItem
        '
        Me.СотрудникиToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ПриемСотрудникаToolStripMenuItem})
        Me.СотрудникиToolStripMenuItem.Name = "СотрудникиToolStripMenuItem"
        Me.СотрудникиToolStripMenuItem.Size = New System.Drawing.Size(85, 20)
        Me.СотрудникиToolStripMenuItem.Text = "Сотрудники"
        '
        'ПриемСотрудникаToolStripMenuItem
        '
        Me.ПриемСотрудникаToolStripMenuItem.Name = "ПриемСотрудникаToolStripMenuItem"
        Me.ПриемСотрудникаToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ПриемСотрудникаToolStripMenuItem.Text = "Прием сотрудника"
        '
        'СевисToolStripMenuItem
        '
        Me.СевисToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.УдалитьБДToolStripMenuItem, Me.ДобавитьToolStripMenuItem, Me.СформироватьТаблицыToolStripMenuItem})
        Me.СевисToolStripMenuItem.Name = "СевисToolStripMenuItem"
        Me.СевисToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.СевисToolStripMenuItem.Text = "Сервис"
        '
        'УдалитьБДToolStripMenuItem
        '
        Me.УдалитьБДToolStripMenuItem.Name = "УдалитьБДToolStripMenuItem"
        Me.УдалитьБДToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.УдалитьБДToolStripMenuItem.Text = "Удалить БД"
        '
        'ДобавитьToolStripMenuItem
        '
        Me.ДобавитьToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ДобавитьТаблицуПоставкаToolStripMenuItem, Me.ДобавитьТаблицуВыдачаToolStripMenuItem, Me.ДобавитьТаблицуСотрудникиToolStripMenuItem, Me.ДобавитьТаблицуНоменклатураToolStripMenuItem, Me.ДобавитьТаблицуЗапасыToolStripMenuItem})
        Me.ДобавитьToolStripMenuItem.Name = "ДобавитьToolStripMenuItem"
        Me.ДобавитьToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.ДобавитьToolStripMenuItem.Text = "Добавить"
        '
        'ДобавитьТаблицуПоставкаToolStripMenuItem
        '
        Me.ДобавитьТаблицуПоставкаToolStripMenuItem.Name = "ДобавитьТаблицуПоставкаToolStripMenuItem"
        Me.ДобавитьТаблицуПоставкаToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.ДобавитьТаблицуПоставкаToolStripMenuItem.Text = "Добавить таблицу Поставка"
        '
        'ДобавитьТаблицуВыдачаToolStripMenuItem
        '
        Me.ДобавитьТаблицуВыдачаToolStripMenuItem.Name = "ДобавитьТаблицуВыдачаToolStripMenuItem"
        Me.ДобавитьТаблицуВыдачаToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.ДобавитьТаблицуВыдачаToolStripMenuItem.Text = "Добавить таблицу Выдача"
        '
        'ДобавитьТаблицуСотрудникиToolStripMenuItem
        '
        Me.ДобавитьТаблицуСотрудникиToolStripMenuItem.Name = "ДобавитьТаблицуСотрудникиToolStripMenuItem"
        Me.ДобавитьТаблицуСотрудникиToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.ДобавитьТаблицуСотрудникиToolStripMenuItem.Text = "Добавить таблицу Сотрудники"
        '
        'ДобавитьТаблицуНоменклатураToolStripMenuItem
        '
        Me.ДобавитьТаблицуНоменклатураToolStripMenuItem.Name = "ДобавитьТаблицуНоменклатураToolStripMenuItem"
        Me.ДобавитьТаблицуНоменклатураToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.ДобавитьТаблицуНоменклатураToolStripMenuItem.Text = "Добавить таблицу Номенклатура"
        '
        'ДобавитьТаблицуЗапасыToolStripMenuItem
        '
        Me.ДобавитьТаблицуЗапасыToolStripMenuItem.Name = "ДобавитьТаблицуЗапасыToolStripMenuItem"
        Me.ДобавитьТаблицуЗапасыToolStripMenuItem.Size = New System.Drawing.Size(258, 22)
        Me.ДобавитьТаблицуЗапасыToolStripMenuItem.Text = "Добавить таблицу Запасы"
        '
        'СформироватьТаблицыToolStripMenuItem
        '
        Me.СформироватьТаблицыToolStripMenuItem.Name = "СформироватьТаблицыToolStripMenuItem"
        Me.СформироватьТаблицыToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.СформироватьТаблицыToolStripMenuItem.Text = "Сформировать таблицы"
        '
        'НоменклатураToolStripMenuItem
        '
        Me.НоменклатураToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ДобавитьНоменклатуруToolStripMenuItem})
        Me.НоменклатураToolStripMenuItem.Name = "НоменклатураToolStripMenuItem"
        Me.НоменклатураToolStripMenuItem.Size = New System.Drawing.Size(100, 20)
        Me.НоменклатураToolStripMenuItem.Text = "Номенклатура"
        '
        'ДобавитьНоменклатуруToolStripMenuItem
        '
        Me.ДобавитьНоменклатуруToolStripMenuItem.Name = "ДобавитьНоменклатуруToolStripMenuItem"
        Me.ДобавитьНоменклатуруToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.ДобавитьНоменклатуруToolStripMenuItem.Text = "Добавить номенклатуру"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(131, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 16)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Label2"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 79)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(757, 39)
        Me.ProgressBar1.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 16)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Путь к файлу БД:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(328, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 16)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Label3"
        '
        'ПоставкаBindingSource
        '
        Me.ПоставкаBindingSource.DataMember = "Поставка"
        '
        'Форма_главная
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 183)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Форма_главная"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Склад+БД"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.ПоставкаBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents СкладToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents СотрудникиToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ПриемСотрудникаToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ВыдачаToolStripMenuItem As ToolStripMenuItem
    'Friend WithEvents СкладDataSet1 As СкладDataSet1
    Friend WithEvents ПоставкаBindingSource As BindingSource
    'Friend WithEvents ПоставкаTableAdapter As СкладDataSet1TableAdapters.ПоставкаTableAdapter
    Friend WithEvents СевисToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents УдалитьБДToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ДобавитьToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ДобавитьТаблицуПоставкаToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ДобавитьТаблицуВыдачаToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ДобавитьТаблицуСотрудникиToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents НоменклатураToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ДобавитьНоменклатуруToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ДобавитьТаблицуНоменклатураToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ПоставкаToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label2 As Label
    Friend WithEvents ДобавитьТаблицуЗапасыToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ЗапасыToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ВыходToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Timer1 As Timer
    Friend WithEvents СформироватьТаблицыToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents БракToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ВозвратToolStripMenuItem As ToolStripMenuItem
End Class
