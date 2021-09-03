using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPTSotryd : UserControl
    {
        public PPTSotryd()
        {
            Program.Sotryd = this;
            InitializeComponent();
            Connect();
            dataGridSotryd.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 12F, FontStyle.Bold);
            dataGridSotryd.DefaultCellStyle.Font = new Font("Candara", 10F);
        }
        //Метод отображения данных таблицы «Сотрудник» в таблицу
        public void Connect()
        {
            dataGridSotryd.DataSource = DBConnection.t_Sotryd;
        }
        //Запуск таймера на открытия поля для добавления данных
        private void btnAddSotryd_Click(object sender, EventArgs e)
        {
            groupEditSotryd.Visible = false;
            groupAddSotryd.Visible = true;
            if (tableLayoutSotryd.RowStyles[0].Height == 100 && tableLayoutSotryd.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Запуск таймера на открытия поля для редактирования данных
        private void btnEditSotryd_Click(object sender, EventArgs e)
        {
            groupAddSotryd.Visible = false;
            groupEditSotryd.Visible = true;
            if (tableLayoutSotryd.RowStyles[0].Height == 100 && tableLayoutSotryd.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Открытие поля для добавления или редактирования данных
        private void timer1_Tick(object sender, EventArgs e)
        {
            tableLayoutSotryd.RowStyles[1].Height += 17;
            tableLayoutSotryd.RowStyles[0].Height -= 5;
            if (tableLayoutSotryd.RowStyles[1].Height == 136 && tableLayoutSotryd.RowStyles[0].Height == 60)
            {
                timer1.Stop();
            }
        }
        //Закрытие поля для добавления или редактирования данных
        private void timer2_Tick(object sender, EventArgs e)
        {
            tableLayoutSotryd.RowStyles[1].Height -= 17;
            tableLayoutSotryd.RowStyles[0].Height += 5;
            if (tableLayoutSotryd.RowStyles[1].Height == 0 && tableLayoutSotryd.RowStyles[0].Height == 100)
            {
                timer2.Stop();
            }
        }
        //Удаление выбранной записи из таблицы «Сотрудник»
        private void btnDelSotryd_Click(object sender, EventArgs e)
        {
            if (dataGridSotryd.Rows.Count > 0)
            {
                if (dataGridSotryd.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataGridSotryd.SelectedRows.Count; i++)
                        {
                            int key_r = Convert.ToInt32(dataGridSotryd.Rows[dataGridSotryd.SelectedRows[i].Index].Cells[0].Value);
                            string monter = dataGridSotryd.CurrentRow.Cells[1].Value.ToString();
                            string adres = dataGridSotryd.CurrentRow.Cells[2].Value.ToString();
                            string telephone = dataGridSotryd.CurrentRow.Cells[3].Value.ToString();
                            int log = DBConnection.DellTableSotryd(key_r);
                            switch (log)
                            {
                                case (1):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Монтер ФИО: '" + monter + "' Адрес: '" + adres + "' Тел: '" + telephone + "' успешно удален!");
                                    RefreshTable();
                                    break;
                                case (2):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Монтера ФИО: '" + monter + "' Адрес: '" + adres + "' Тел: '" + telephone + "' удалить не удалось!");
                                    break;
                                case (4):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Монтер ФИО: '" + monter + "' Адрес: '" + adres + "' Тел: '" + telephone + "' связан с таблицей 'Акты', удаление невозможно!");
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
        private void btnHideSotryd_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        //Запуск таймера на закрытие поля для добавления или редактирования данных
        private void Close(object sender, EventArgs e)
        {
            if (tableLayoutSotryd.RowStyles[1].Height == 136 && tableLayoutSotryd.RowStyles[0].Height == 60)
            {
                timer2.Start();
            }
        }
        //Добавление данных в таблицу «Сотрудник»
        private void addSotryd_Click(object sender, EventArgs e)
        {
            int id_ylitca = DBConnection.keyRecord("s_street.id_ylitca", "s_street,s_city", "s_street.id_gorod = s_city.id_gorod and s_city.gorod = '" + comboBoxAddSotrydCity.Text + "' and s_street.ylitca", comboBoxAddSotrydStreet.Text);
            if (!String.IsNullOrEmpty(textBoxAddSotrydFIO.Text) 
                && !String.IsNullOrEmpty(id_ylitca.ToString())
                && !String.IsNullOrEmpty(textBoxAddSotrydAdres.Text)
                && !String.IsNullOrEmpty(textBoxAddSotrydTelephone.Text))
            {
                int log = DBConnection.AddTableSotryd(textBoxAddSotrydFIO.Text, id_ylitca, textBoxAddSotrydAdres.Text, textBoxAddSotrydTelephone.Text);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Монтер ФИО: '" + textBoxAddSotrydFIO.Text + "' Адрес: '" + comboBoxAddSotrydCity.Text + ' ' + comboBoxAddSotrydStreet.Text + ' ' + textBoxAddSotrydAdres.Text + "' Тел: '" + textBoxAddSotrydTelephone.Text + "' был успешно добавлен!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Монтера ФИО: '" + textBoxAddSotrydFIO.Text + "' Адрес: '" + comboBoxAddSotrydCity.Text + ' ' + comboBoxAddSotrydStreet.Text + ' ' + textBoxAddSotrydAdres.Text + "' Тел: '" + textBoxAddSotrydTelephone.Text + "' добавить не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "ФИО:'" + textBoxAddSotrydFIO.Text + "' или Тел: '" + textBoxAddSotrydTelephone.Text + "' уже существует, добавление Монтера ФИО: '" + textBoxAddSotrydFIO.Text + "' Адрес: '" + comboBoxAddSotrydCity.Text + ' ' + comboBoxAddSotrydStreet.Text + ' ' + textBoxAddSotrydAdres.Text + "' Тел: '" + textBoxAddSotrydTelephone.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Редактирование данных в таблице «Сотрудник»
        private void editSotryd_Click(object sender, EventArgs e)
        {
            int key_r = Convert.ToInt32(dataGridSotryd.CurrentRow.Cells[0].Value);
            int id_ylitca = DBConnection.keyRecord("s_street.id_ylitca", "s_street,s_city", "s_street.id_gorod = s_city.id_gorod and s_city.gorod = '" + comboBoxEditSotrydCity.Text + "' and s_street.ylitca", comboBoxEditSotrydStreet.Text);
            string monter = dataGridSotryd.CurrentRow.Cells[1].Value.ToString();
            string adres = dataGridSotryd.CurrentRow.Cells[2].Value.ToString();
            string telephone = dataGridSotryd.CurrentRow.Cells[3].Value.ToString();
            if (!String.IsNullOrEmpty(textBoxEditSotrydFIO.Text)
                && !String.IsNullOrEmpty(id_ylitca.ToString())
                && !String.IsNullOrEmpty(textBoxEditSotrydAdres.Text)
                && !String.IsNullOrEmpty(textBoxEditSotrydTelephone.Text))
            {
                int log = DBConnection.EditTableSotryd(key_r, textBoxEditSotrydFIO.Text, id_ylitca, textBoxEditSotrydAdres.Text, textBoxEditSotrydTelephone.Text);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Монтер ФИО: '" + monter + "' Адрес: '" + adres + "' Тел: '" + telephone + "' был успешно обновлен на ФИО: '" + textBoxEditSotrydFIO.Text + "' Адрес: '" + comboBoxEditSotrydCity.Text + ' ' + comboBoxEditSotrydStreet.Text + ' ' + textBoxEditSotrydAdres.Text + "' Тел: '" + textBoxEditSotrydTelephone.Text + "'!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Монтера ФИО: '" + monter + "' Адрес: '" + adres + "' Тел: '" + telephone + "' обновить на ФИО: '" + textBoxEditSotrydFIO.Text + "' Адрес: '" + comboBoxEditSotrydCity.Text + ' ' + comboBoxEditSotrydStreet.Text + ' ' + textBoxEditSotrydAdres.Text + "' Тел: '" + textBoxEditSotrydTelephone.Text + "' не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "ФИО:'" + textBoxEditSotrydFIO.Text + "' или Тел: '" + textBoxEditSotrydTelephone.Text + "' уже существует, обновление Монтера ФИО: '" + monter + "' Адрес: '" + adres + "' Тел: '" + telephone + "' на ФИО: '" + textBoxEditSotrydFIO.Text + "' Адрес: '" + comboBoxEditSotrydCity.Text + ' ' + comboBoxEditSotrydStreet.Text + ' ' + textBoxEditSotrydAdres.Text + "' Тел: '" + textBoxEditSotrydTelephone.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //При выборе города, в выпадающий список улиц для добавления выводятся улицы этого города
        private void comboBoxAddSotrydCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBConnection.ShowStreet(comboBoxAddSotrydCity.Text);
            comboBoxAddSotrydStreet.DataSource = DBConnection.street;
            comboBoxAddSotrydStreet.DisplayMember = "ylitca";
            comboBoxAddSotrydStreet.ValueMember = "id_ylitca";
        }
        //При выборе города, в выпадающий список улиц для редактирования выводятся улицы этого города
        private void comboBoxEditSotrydCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBConnection.ShowStreet(comboBoxEditSotrydCity.Text);
            comboBoxEditSotrydStreet.DataSource = DBConnection.street;
            comboBoxEditSotrydStreet.DisplayMember = "ylitca";
            comboBoxEditSotrydStreet.ValueMember = "id_ylitca";
        }
        //Отображение данных таблицы «Сотрудник» в таблицу
        private void PPTSotryd_Load(object sender, EventArgs e)
        {
            Connect();
            comboBoxAddSotrydCity.DataSource = DBConnection.s_City;
            comboBoxAddSotrydCity.DisplayMember = "gorod";

            comboBoxEditSotrydCity.DataSource = DBConnection.s_City;
            comboBoxEditSotrydCity.DisplayMember = "gorod";
        }
        //Выбор строки записей в таблице
        private void dataGridSotryd_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textBoxEditSotrydFIO.Text = dataGridSotryd.CurrentRow.Cells[1].Value.ToString();
                comboBoxEditSotrydCity.Text = dataGridSotryd.CurrentRow.Cells[4].Value.ToString();
                comboBoxEditSotrydStreet.Text = dataGridSotryd.CurrentRow.Cells[5].Value.ToString();
                textBoxEditSotrydAdres.Text = dataGridSotryd.CurrentRow.Cells[6].Value.ToString();
                textBoxEditSotrydTelephone.Text = dataGridSotryd.CurrentRow.Cells[3].Value.ToString();
            }
        }
        //При выборе заголовка столбца правой кнопкой мыши выводится список для отбора записей
        int key;
        private void dataGridSotryd_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.ColumnIndex != 0 && e.RowIndex == -1)
            {
                Filter.Items.Clear();
                switch (e.ColumnIndex)
                {
                    case (1):
                        {
                            DBConnection.ShowFilter("authorization.fiosotryd", "authorization", "where authorization.key_doljnost = 1 order by authorization.fiosotryd");
                            key = 1;
                        }
                        break;
                    case (2):
                        {
                            DBConnection.ShowFilter("concat(s_city.gorod,' ', s_street.ylitca)", "authorization,s_street,s_city", "where authorization.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and authorization.key_doljnost = 1  order by concat(s_city.gorod,' ', s_street.ylitca)");
                            key = 2;
                        }
                        break;
                    case (3):
                        {
                            DBConnection.ShowFilter("authorization.telephone", "authorization", "where authorization.key_doljnost = 1 order by authorization.telephone");
                            key = 3;
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
                        DBConnection.ShowFilters("authorization.id_sotryd, authorization.fiosotryd, concat(s_city.gorod,' ', s_street.ylitca,' ', authorization.adres) as 'adres1', authorization.telephone,s_city.gorod,s_street.ylitca,authorization.adres",
                        "authorization,s_street,s_city", "where authorization.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and authorization.key_doljnost = 1 and authorization.fiosotryd = '" + e.ClickedItem.Text + "'  order by authorization.fiosotryd ");
                    }
                    break;
                case (2):
                    {
                        DBConnection.ShowFilters("authorization.id_sotryd, authorization.fiosotryd, concat(s_city.gorod,' ', s_street.ylitca,' ', authorization.adres) as 'adres1', authorization.telephone,s_city.gorod,s_street.ylitca,authorization.adres",
                        "authorization,s_street,s_city", "where authorization.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and authorization.key_doljnost = 1 and concat(s_city.gorod,' ', s_street.ylitca) = '" + e.ClickedItem.Text + "' order by authorization.fiosotryd");
                    }
                    break;
                case (3):
                    {
                        DBConnection.ShowFilters("authorization.id_sotryd, authorization.fiosotryd, concat(s_city.gorod,' ', s_street.ylitca,' ', authorization.adres) as 'adres1', authorization.telephone,s_city.gorod,s_street.ylitca,authorization.adres",
                        "authorization,s_street,s_city", "where authorization.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and authorization.key_doljnost = 1 and authorization.telephone = '" + e.ClickedItem.Text + "' order by authorization.fiosotryd");
                    }
                    break;
            }
            dataGridSotryd.DataSource = DBConnection.filters;
        }
        //Обновление данных в таблице
        private void btnUpdateSotryd_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
        //Метод обновления данных
        private void RefreshTable()
        {
            DBConnection.ShowTableSotryd();
            Connect();
        }
        //Поиск записей в таблице
        private void btnSearchSotryd_Click(object sender, EventArgs e)
        {
            Searching s = new Searching();
            s.searched = Program.Sotryd.dataGridSotryd;
            s.ShowDialog();
        }
        //Ограничение на ввод только кириллицы и цифр
        private void textBoxEditSotrydFIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Ограничение на ввод только кириллицы и цифр
        private void textBoxEditSotrydAdres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Ограничение на ввод только кириллицы и цифр
        private void textBoxAddSotrydFIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Ограничение на ввод только кириллицы и цифр
        private void textBoxAddSotrydAdres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
    }
}
