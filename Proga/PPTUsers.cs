using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPTUsers : UserControl
    {
        public PPTUsers()
        {
            Program.Users = this;
            InitializeComponent();
            dataGridUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 12F, FontStyle.Bold);
            dataGridUsers.DefaultCellStyle.Font = new Font("Candara", 10F);
        }
        //Запуск таймера на открытия поля для добавления данных
        private void btnAddUsers_Click(object sender, EventArgs e)
        {
            groupEditUsers.Visible = false;
            groupAddUsers.Visible = true;
            if (tableLayoutUsers.RowStyles[0].Height == 100 && tableLayoutUsers.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Запуск таймера на открытия поля для редактирования данных
        private void btnEditUsers_Click(object sender, EventArgs e)
        {
            groupAddUsers.Visible = false;
            groupEditUsers.Visible = true;
            if (tableLayoutUsers.RowStyles[0].Height == 100 && tableLayoutUsers.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Открытие поля для добавления или редактирования данных
        private void timer1_Tick(object sender, EventArgs e)
        {
            tableLayoutUsers.RowStyles[1].Height += 17;
            tableLayoutUsers.RowStyles[0].Height -= 5;
            if (tableLayoutUsers.RowStyles[1].Height == 136 && tableLayoutUsers.RowStyles[0].Height == 60)
            {
                timer1.Stop();
            }
        }
        //Закрытие поля для добавления или редактирования данных
        private void timer2_Tick(object sender, EventArgs e)
        {
            tableLayoutUsers.RowStyles[1].Height -= 17;
            tableLayoutUsers.RowStyles[0].Height += 5;
            if (tableLayoutUsers.RowStyles[1].Height == 0 && tableLayoutUsers.RowStyles[0].Height == 100)
            {
                timer2.Stop();
            }
        }
        //Удаление выбранной записи из таблицы «Пользователь»
        private void btnDelUsers_Click(object sender, EventArgs e)
        {
            if (dataGridUsers.Rows.Count > 0)
            {
                if (dataGridUsers.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataGridUsers.SelectedRows.Count; i++)
                        {
                            int key_r = Convert.ToInt32(dataGridUsers.Rows[dataGridUsers.SelectedRows[i].Index].Cells[0].Value);
                            string user = dataGridUsers.CurrentRow.Cells[1].Value.ToString();
                            string adres = dataGridUsers.CurrentRow.Cells[2].Value.ToString();
                            string telephone = dataGridUsers.CurrentRow.Cells[3].Value.ToString();
                            string login = dataGridUsers.CurrentRow.Cells[4].Value.ToString();
                            string password = new String('*', dataGridUsers.CurrentRow.Cells[5].Value.ToString().Length);
                            int log = DBConnection.DellTableSotryd(key_r);
                            switch (log)
                            {
                                case (1):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Пользователь ФИО:'" + user + "' Адрес: '" + adres + "' Телефон: '" + telephone + "' Логин: '" + login + "' Пароль: '" + password + "' успешно удален!");
                                    RefreshTable();
                                    break;
                                case (2):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Пользователя ФИО:'" + user + "' Адрес: '" + adres + "' Телефон: '" + telephone + "' Логин: '" + login + "' Пароль: '" + password + "' удалить не удалось!");
                                    break;
                                case (3):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Пользователь ФИО:'" + user + "' Адрес: '" + adres + "' Телефон: '" + telephone + "' Логин: '" + login + "' Пароль: '" + password + "' связан с таблицей 'Договора', удаление невозможно!");
                                    break;
                            }
                        }
                    }
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "В таблице нет записей, удаление невозможно!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Закрытие формы
        private void btnHideUsers_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        //Запуск таймера на закрытие поля для добавления или редактирования данных
        private void Close(object sender, EventArgs e)
        {
            if (tableLayoutUsers.RowStyles[1].Height == 136 && tableLayoutUsers.RowStyles[0].Height == 60)
            {
                timer2.Start();
            }
        }
        //Добавление данных в таблицу «Пользователь»
        private void addUsers_Click(object sender, EventArgs e)
        {
            int id_ylitca = DBConnection.keyRecord("s_street.id_ylitca", "s_street,s_city", "s_street.id_gorod = s_city.id_gorod and s_city.gorod = '" + comboBoxAddUsersGorod.Text + "' and s_street.ylitca", comboBoxAddUsersYlintca.Text);
            if (!String.IsNullOrEmpty(textBoxAddUsersFIO.Text)
                && !String.IsNullOrEmpty(id_ylitca.ToString())
                && !String.IsNullOrEmpty(textBoxAddUsersDom.Text)
                && !String.IsNullOrEmpty(textBoxAddUserTelephone.Text)
                && !String.IsNullOrEmpty(textBoxAddUsersLogin.Text)
                && !String.IsNullOrEmpty(textBoxAddUsersPassword.Text))
            {
                int log = DBConnection.AddTableUsers(textBoxAddUsersFIO.Text, id_ylitca, textBoxAddUsersDom.Text, textBoxAddUserTelephone.Text, textBoxAddUsersLogin.Text, textBoxAddUsersPassword.Text);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Пользователь ФИО:'" + textBoxAddUsersFIO.Text + "' Адрес: '" + comboBoxAddUsersGorod.Text +' '+comboBoxAddUsersYlintca.Text+' '+ textBoxAddUsersDom.Text +"' Телефон: '" + textBoxAddUserTelephone.Text + "' Логин: '" + textBoxAddUsersLogin.Text + "' Пароль: '" + new String('*', textBoxAddUsersPassword.TextLength) + "' был успешно добавлен!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Пользователя ФИО:'" + textBoxAddUsersFIO.Text + "' Адрес: '" + comboBoxAddUsersGorod.Text + ' ' + comboBoxAddUsersYlintca.Text + ' ' + textBoxAddUsersDom.Text + "' Телефон: '" + textBoxAddUserTelephone.Text + "' Логин: '" + textBoxAddUsersLogin.Text + "' Пароль: '" + new String('*', textBoxAddUsersPassword.TextLength) + "' добавить не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "ФИО:'" + textBoxAddUsersFIO.Text + "', Тел: '" + textBoxAddUserTelephone.Text + "' или Логин: '" + textBoxAddUsersLogin.Text + "' уже существует, добавление Пользователя ФИО:'" + textBoxAddUsersFIO.Text + "' Адрес: '" + comboBoxAddUsersGorod.Text + ' ' + comboBoxAddUsersYlintca.Text + ' ' + textBoxAddUsersDom.Text + "' Телефон: '" + textBoxAddUserTelephone.Text + "' Логин: '" + textBoxAddUsersLogin.Text + "' Пароль: '" + new String('*', textBoxAddUsersPassword.TextLength) + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Редактирование данных в таблице «Пользователь»
        private void editUsers_Click(object sender, EventArgs e)
        {
            int key_r = Convert.ToInt32(dataGridUsers.CurrentRow.Cells[0].Value);
            int id_ylitca = DBConnection.keyRecord("s_street.id_ylitca", "s_street,s_city", "s_street.id_gorod = s_city.id_gorod and s_city.gorod = '" + comboBoxEditUsersGorod.Text + "' and s_street.ylitca", comboBoxEditUsersYlintca.Text);
            string user = dataGridUsers.CurrentRow.Cells[1].Value.ToString();
            string adres = dataGridUsers.CurrentRow.Cells[2].Value.ToString();
            string telephone = dataGridUsers.CurrentRow.Cells[3].Value.ToString();
            string login = dataGridUsers.CurrentRow.Cells[4].Value.ToString();
            string password = new String('*', dataGridUsers.CurrentRow.Cells[5].Value.ToString().Length);
            if (!String.IsNullOrEmpty(textBoxEditUsersFIO.Text)
                && !String.IsNullOrEmpty(id_ylitca.ToString())
                && !String.IsNullOrEmpty(textBoxEditUsersDom.Text)
                && !String.IsNullOrEmpty(textBoxEditUsersLogin.Text)
                && !String.IsNullOrEmpty(textBoxEditUsersPassword.Text)
                && !String.IsNullOrEmpty(textBoxEditUserTelephone.Text))
            {
                int log = DBConnection.EditTableUsers(key_r, textBoxEditUsersFIO.Text, id_ylitca, textBoxEditUsersDom.Text, textBoxEditUserTelephone.Text, textBoxEditUsersLogin.Text, textBoxEditUsersPassword.Text);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Пользователь ФИО:'" + user + "' Адрес: '" + adres + "' Телефон: '" + telephone + "' Логин: '" + login + "' Пароль: '" + password + "' был успешно обновлен на ФИО:'" + textBoxEditUsersFIO.Text + "' Адрес: '" + comboBoxEditUsersGorod.Text +' '+ comboBoxEditUsersYlintca.Text+' '+textBoxEditUsersDom.Text+"' Телефон: '" + textBoxEditUserTelephone.Text + "' Логин: '" + textBoxEditUsersLogin.Text + "' Пароль: '" + new String('*', textBoxEditUsersPassword.TextLength) + "'!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Пользователя ФИО:'" + user + "' Адрес: '" + adres + "' Телефон: '" + telephone + "' Логин: '" + login + "' Пароль: '" + password + "' обновить на ФИО:'" + textBoxEditUsersFIO.Text + "' Адрес: '" + comboBoxEditUsersGorod.Text + ' ' + comboBoxEditUsersYlintca.Text + ' ' + textBoxEditUsersDom.Text + "' Телефон: '" + textBoxEditUserTelephone.Text + "' Логин: '" + textBoxEditUsersLogin.Text + "' Пароль: '" + new String('*', textBoxEditUsersPassword.TextLength) + "' не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "ФИО:'" + textBoxEditUsersFIO.Text + "', Телефон: '" + textBoxEditUserTelephone.Text + "' или Логин: '" + textBoxEditUsersLogin.Text + "' уже существует, обновление Пользователь ФИО:'" + user + "' Адрес: '" + adres + "' Телефон: '" + telephone + "' Логин: '" + login + "' Пароль: '" + password + "' на ФИО:'" + textBoxEditUsersFIO.Text + "' Адрес: '" + comboBoxEditUsersGorod.Text + ' ' + comboBoxEditUsersYlintca.Text + ' ' + textBoxEditUsersDom.Text + "' Телефон: '" + textBoxEditUserTelephone.Text + "' Логин: '" + textBoxEditUsersLogin.Text + "' Пароль: '" + new String('*', textBoxEditUsersPassword.TextLength) + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //При выборе города, в выпадающий список улиц для добавления выводятся улицы этого города
        private void comboBoxAddUsersGorod_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBConnection.ShowStreet(comboBoxAddUsersGorod.Text);
            comboBoxAddUsersYlintca.DataSource = DBConnection.street;
            comboBoxAddUsersYlintca.DisplayMember = "ylitca";
            comboBoxAddUsersYlintca.ValueMember = "id_ylitca";
        }
        //При выборе города, в выпадающий список улиц для редактирования выводятся улицы этого города
        private void comboBoxEditUsersGorod_SelectedIndexChanged(object sender, EventArgs e)
        {

            DBConnection.ShowStreet(comboBoxEditUsersGorod.Text);
            comboBoxEditUsersYlintca.DataSource = DBConnection.street;
            comboBoxEditUsersYlintca.DisplayMember = "ylitca";
            comboBoxEditUsersYlintca.ValueMember = "id_ylitca";
        }
        //Отображение данных таблицы «Пользователь» в таблицу
        private void PPTUsers_Load(object sender, EventArgs e)
        {
            dataGridUsers.DataSource = DBConnection.t_Users;
            comboBoxAddUsersGorod.DataSource = DBConnection.s_City;
            comboBoxAddUsersGorod.DisplayMember = "gorod";
            comboBoxEditUsersGorod.DataSource = DBConnection.s_City;
            comboBoxEditUsersGorod.DisplayMember = "gorod";
        }
        //Выбор строки записей в таблице
        private void dataGridUsers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textBoxEditUsersFIO.Text = dataGridUsers.CurrentRow.Cells[1].Value.ToString();
                comboBoxEditUsersGorod.Text = dataGridUsers.CurrentRow.Cells[6].Value.ToString();
                comboBoxEditUsersYlintca.Text = dataGridUsers.CurrentRow.Cells[7].Value.ToString();
                textBoxEditUsersDom.Text = dataGridUsers.CurrentRow.Cells[8].Value.ToString();
                textBoxEditUserTelephone.Text = dataGridUsers.CurrentRow.Cells[3].Value.ToString();
                textBoxEditUsersLogin.Text = dataGridUsers.CurrentRow.Cells[4].Value.ToString();
                textBoxEditUsersPassword.Text = dataGridUsers.CurrentRow.Cells[5].Value.ToString();
            }
        }
        //При выборе заголовка столбца правой кнопкой мыши выводится список для отбора записей
        int key;
        private void dataGridUsers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.ColumnIndex != 0 && e.RowIndex == -1)
            {
                Filter.Items.Clear();
                switch (e.ColumnIndex)
                {
                    case (1):
                        {
                            DBConnection.ShowFilter("fiosotryd", "authorization", "where authorization.key_doljnost = 2 order by fiosotryd");
                            key = 1;
                        }
                        break;
                    case (2):
                        {
                            DBConnection.ShowFilter("concat(s_city.gorod,' ', s_street.ylitca)", "authorization,s_street,s_city", "where authorization.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and authorization.key_doljnost = 2 order by concat(s_city.gorod,' ', s_street.ylitca)");
                            key = 2;
                        }
                        break;
                    case (3):
                        {
                            DBConnection.ShowFilter("telephone", "authorization", "where authorization.key_doljnost = 2 order by fiosotryd");
                            key = 3;
                        }
                        break;
                    case (4):
                        {
                            DBConnection.ShowFilter("login", "authorization", "where authorization.key_doljnost = 2 order by fiosotryd");
                            key = 4;
                        }
                        break;
                }
                for (int i = 0; i < DBConnection.filter.Rows.Count; i++)
                    Filter.Items.Add(new ToolStripMenuItem(DBConnection.filter.Rows[i].ItemArray.GetValue(0).ToString()));
                Filter.Show(MousePosition, ToolStripDropDownDirection.BelowRight);
            }
        }
        //Отбор записей в таблице
        private void Filter_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (key)
            {
                case (1):
                    {
                        DBConnection.ShowFilters("authorization.id_sotryd, authorization.fiosotryd, concat(s_city.gorod,' ', s_street.ylitca,' ', authorization.adres) as 'adres1', authorization.telephone, authorization.login, authorization.password,s_city.gorod,s_street.ylitca,authorization.adres",
"authorization,s_street,s_city",
"where authorization.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and authorization.key_doljnost = 2 and authorization.fiosotryd = '" + e.ClickedItem.Text + "'order by fiosotryd");
                    }
                    break;
                case (2):
                    {
                        DBConnection.ShowFilters("authorization.id_sotryd, authorization.fiosotryd, concat(s_city.gorod,' ', s_street.ylitca,' ', authorization.adres) as 'adres1', authorization.telephone, authorization.login, authorization.password,s_city.gorod,s_street.ylitca,authorization.adres",
"authorization,s_street,s_city",
"where authorization.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and authorization.key_doljnost = 2 and concat(s_city.gorod,' ', s_street.ylitca) = '" + e.ClickedItem.Text + "'order by concat(s_city.gorod,' ', s_street.ylitca)");
                    }
                    break;
                case (3):
                    {
                        DBConnection.ShowFilters("authorization.id_sotryd, authorization.fiosotryd, concat(s_city.gorod,' ', s_street.ylitca,' ', authorization.adres) as 'adres1', authorization.telephone, authorization.login, authorization.password,s_city.gorod,s_street.ylitca,authorization.adres",
"authorization,s_street,s_city",
"where authorization.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and authorization.key_doljnost = 2 and authorization.telephone = '" + e.ClickedItem.Text + "'order by telephone");
                    }
                    break;
                case (4):
                    {
                        DBConnection.ShowFilters("authorization.id_sotryd, authorization.fiosotryd, concat(s_city.gorod,' ', s_street.ylitca,' ', authorization.adres) as 'adres1', authorization.telephone, authorization.login, authorization.password,s_city.gorod,s_street.ylitca,authorization.adres",
"authorization,s_street,s_city",
"where authorization.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and authorization.key_doljnost = 2 and authorization.login = '" + e.ClickedItem.Text + "'order by login");
                    }
                    break;
            }
            dataGridUsers.DataSource = DBConnection.filters;
        }
        //Обновление данных в таблице
        private void btnUpdateUsers_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
        //Метод обновления данных
        private void RefreshTable()
        {
            DBConnection.ShowTableUsers();
            dataGridUsers.DataSource = DBConnection.t_Users;
        }
        //Поиск записей в таблице
        private void btnSearchUsers_Click(object sender, EventArgs e)
        {
            Searching s = new Searching();
            s.searched = Program.Users.dataGridUsers;
            s.ShowDialog();
        }
        //Заменяет пароль на символ «*»
        private void dataGridUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                e.Value = new String('*',e.Value.ToString().Length);
            }
        }
        //Ограничение на ввод только кириллицы
        private void textBoxEditUsersFIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Ограничение на ввод только кириллицы
        private void textBoxAddUsersFIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
    }
}
