using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPTAbonent : UserControl
    {
        public PPTAbonent()
        {
            Program.Abonent = this;
            InitializeComponent();
            dataGridAbonent.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 12F, FontStyle.Bold);
            dataGridAbonent.DefaultCellStyle.Font = new Font("Candara", 10F);
        }
        //Запуск таймера на открытия поля для добавления данных
        private void btnAddAbonent_Click(object sender, EventArgs e)
        {
            groupEditAbonent.Visible = false;
            groupAddAbonent.Visible = true;
            if (tableLayoutAbonent.RowStyles[0].Height == 100 && tableLayoutAbonent.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Запуск таймера на открытия поля для редактирования данных
        private void btnEditAbonent_Click(object sender, EventArgs e)
        {
            groupAddAbonent.Visible = false;
            groupEditAbonent.Visible = true;
            if (tableLayoutAbonent.RowStyles[0].Height == 100 && tableLayoutAbonent.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Открытие поля для добавления или редактирования данных
        private void timer1_Tick(object sender, EventArgs e)
        {
            tableLayoutAbonent.RowStyles[1].Height += 17;
            tableLayoutAbonent.RowStyles[0].Height -= 5;
            if (tableLayoutAbonent.RowStyles[1].Height == 136 && tableLayoutAbonent.RowStyles[0].Height == 60)
            {
                timer1.Stop();
            }
        }
        //Закрытие поля для добавления или редактирования данных
        private void timer2_Tick(object sender, EventArgs e)
        {
            tableLayoutAbonent.RowStyles[1].Height -= 17;
            tableLayoutAbonent.RowStyles[0].Height += 5;
            if (tableLayoutAbonent.RowStyles[1].Height == 0 && tableLayoutAbonent.RowStyles[0].Height == 100)
            {
                timer2.Stop();
            }
        }
        //Удаление выбранной записи из таблицы «Абоненты»
        private void btnDelAbonent_Click(object sender, EventArgs e)
        {
            if (dataGridAbonent.Rows.Count > 0)
            {
                if (dataGridAbonent.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataGridAbonent.SelectedRows.Count; i++)
                        {
                            int key_r = Convert.ToInt32(dataGridAbonent.Rows[dataGridAbonent.SelectedRows[i].Index].Cells[0].Value);
                            string sotryd = dataGridAbonent.CurrentRow.Cells[1].Value.ToString();
                            string adres = dataGridAbonent.CurrentRow.Cells[2].Value.ToString();
                            string telephone = dataGridAbonent.CurrentRow.Cells[3].Value.ToString();
                            int log = DBConnection.DellTableAbonent(key_r);
                            switch (log)
                            {
                                case (1):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Абонент ФИО: '" + sotryd + "' Адрес: '" + adres + "' Тел: '" + telephone + "' успешно удален!");
                                    RefreshTable();
                                    break;
                                case (2):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Абонента ФИО: '" + sotryd + "' Адрес: '" + adres + "' Тел: '" + telephone + "' удалить не удалось!");
                                    break;
                                case (3):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Абонент ФИО: '" + sotryd + "' Адрес: '" + adres + "' Тел: '" + telephone + "' связан с таблицей 'Лицевой счет', удаление невозможно!");
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
        private void btnHideAbonent_Click(object sender, EventArgs e)
        {
            if (Program.Abonents.tableLayoutPanel1.ColumnStyles[1].Width > 0)
                Program.Abonents.tableLayoutPanel1.ColumnStyles[0].Width = 0;
        }
        //Запуск таймера на закрытие поля для добавления или редактирования данных
        private void Close(object sender, EventArgs e)
        {
            if (tableLayoutAbonent.RowStyles[1].Height == 136 && tableLayoutAbonent.RowStyles[0].Height == 60)
            {
                timer2.Start();
            }
        }
        //Добавление данных в таблицу «Абоненты»
        private void addAbonent_Click(object sender, EventArgs e)
        {
            int id_ylitca = DBConnection.keyRecord("s_street.id_ylitca", "s_street,s_city", "s_street.id_gorod = s_city.id_gorod and s_city.gorod = '" + comboBoxAddAbonentCity.Text + "' and s_street.ylitca", comboBoxAddAbonentStreet.Text);
            if (!String.IsNullOrEmpty(textBoxAddAbonentFIO.Text)
                && !String.IsNullOrEmpty(id_ylitca.ToString())
                && !String.IsNullOrEmpty(textBoxAddAbonentAdres.Text)
                && !String.IsNullOrEmpty(textBoxAddAbonentTelephone.Text))
            {
                int log = DBConnection.AddTableAbonent(textBoxAddAbonentFIO.Text, id_ylitca, textBoxAddAbonentAdres.Text, textBoxAddAbonentTelephone.Text);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Абонент ФИО: '" + textBoxAddAbonentFIO.Text + "' Адрес: '" + comboBoxAddAbonentCity.Text + ' ' + comboBoxAddAbonentStreet.Text + ' ' + textBoxAddAbonentAdres.Text + "' Тел: '" + textBoxAddAbonentTelephone.Text + "' был успешно добавлен!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Абонента ФИО: '" + textBoxAddAbonentFIO.Text + "' Адрес: '" + comboBoxAddAbonentCity.Text + ' ' + comboBoxAddAbonentStreet.Text + ' ' + textBoxAddAbonentAdres.Text + "' Тел: '" + textBoxAddAbonentTelephone.Text + "' добавить не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "ФИО:'" + textBoxAddAbonentFIO.Text + "' или Тел: '" + textBoxAddAbonentTelephone.Text + "' уже существует, добавление Абонента ФИО: '" + textBoxAddAbonentFIO.Text + "' Адрес: '" + comboBoxAddAbonentCity.Text + ' ' + comboBoxAddAbonentStreet.Text + ' ' + textBoxAddAbonentAdres.Text + "' Тел: '" + textBoxAddAbonentTelephone.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Редактирование данных в таблице «Абененты»
        private void editAbonent_Click(object sender, EventArgs e)
        {
            int key_r = Convert.ToInt32(dataGridAbonent.CurrentRow.Cells[0].Value);
            int id_ylitca = DBConnection.keyRecord("s_street.id_ylitca", "s_street,s_city", "s_street.id_gorod = s_city.id_gorod and s_city.gorod = '" + comboBoxEditAbonentCity.Text + "' and s_street.ylitca", comboBoxEditAbonentStreet.Text);
            string abonent = dataGridAbonent.CurrentRow.Cells[1].Value.ToString();
            string adres = dataGridAbonent.CurrentRow.Cells[2].Value.ToString();
            string telephone = dataGridAbonent.CurrentRow.Cells[3].Value.ToString();
            if (!String.IsNullOrEmpty(textBoxEditAbonentFIO.Text)
                && !String.IsNullOrEmpty(id_ylitca.ToString())
                && !String.IsNullOrEmpty(textBoxEditAbonentAdres.Text)
                && !String.IsNullOrEmpty(textBoxEditAbonentTelephone.Text))
            {
                int log = DBConnection.EditTableAbonent(key_r, textBoxEditAbonentFIO.Text, id_ylitca, textBoxEditAbonentAdres.Text, textBoxEditAbonentTelephone.Text);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Абонент ФИО: '" + abonent + "' Адрес: '" + adres + "' Тел: '" + telephone + "' был успешно обновлен на ФИО: '" + textBoxEditAbonentFIO.Text + "' Адрес: '" + comboBoxEditAbonentCity.Text + ' ' + comboBoxEditAbonentStreet.Text + ' ' + textBoxEditAbonentAdres.Text + "' Тел: '" + textBoxEditAbonentTelephone.Text + "'!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Абонента ФИО: '" + abonent + "' Адрес: '" + adres + "' Тел: '" + telephone + "' обновить на ФИО: '" + textBoxEditAbonentFIO.Text + "' Адрес: '" + comboBoxEditAbonentCity.Text + ' ' + comboBoxEditAbonentStreet.Text + ' ' + textBoxEditAbonentAdres.Text + "' Тел: '" + textBoxEditAbonentTelephone.Text + "' не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "ФИО:'" + textBoxEditAbonentFIO.Text + "' или Тел: '" + textBoxEditAbonentTelephone.Text + "' уже существует, обновление Абонента ФИО: '" + abonent + "' Адрес: '" + adres + "' Тел: '" + telephone + "' на ФИО: '" + textBoxEditAbonentFIO.Text + "' Адрес: '" + comboBoxEditAbonentCity.Text + ' ' + comboBoxEditAbonentStreet.Text + ' ' + textBoxEditAbonentAdres.Text + "' Тел: '" + textBoxEditAbonentTelephone.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //При выборе города, в выпадающий список улиц для добавления выводятся улицы этого города
        private void comboBoxAddAbonentCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBConnection.ShowStreet(comboBoxAddAbonentCity.Text);
            comboBoxAddAbonentStreet.DataSource = DBConnection.street;
            comboBoxAddAbonentStreet.DisplayMember = "ylitca";
            comboBoxAddAbonentStreet.ValueMember = "id_ylitca";
        }
        //При выборе города, в выпадающий список улиц для редактирования выводятся улицы этого города
        private void comboBoxEditAbonentCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBConnection.ShowStreet(comboBoxEditAbonentCity.Text);
            comboBoxEditAbonentStreet.DataSource = DBConnection.street;
            comboBoxEditAbonentStreet.DisplayMember = "ylitca";
            comboBoxEditAbonentStreet.ValueMember = "id_ylitca";
        }
        //Отображение данных таблицы «Абоненты» в таблицу
        private void PPTAbonent_Load(object sender, EventArgs e)
        {
            dataGridAbonent.DataSource = DBConnection.t_Abonent;
            comboBoxAddAbonentCity.DataSource = DBConnection.s_City;
            comboBoxAddAbonentCity.DisplayMember = "gorod";

            comboBoxEditAbonentCity.DataSource = DBConnection.s_City;
            comboBoxEditAbonentCity.DisplayMember = "gorod";
        }
        //Выбор строки записей в таблице, открытие формы «Лицевые счета»
        private void dataGridAbonent_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textBoxEditAbonentFIO.Text = dataGridAbonent.CurrentRow.Cells[1].Value.ToString();
                comboBoxEditAbonentCity.Text = dataGridAbonent.CurrentRow.Cells[4].Value.ToString();
                comboBoxEditAbonentStreet.Text = dataGridAbonent.CurrentRow.Cells[5].Value.ToString();
                textBoxEditAbonentAdres.Text = dataGridAbonent.CurrentRow.Cells[6].Value.ToString();
                textBoxEditAbonentTelephone.Text = dataGridAbonent.CurrentRow.Cells[3].Value.ToString();
                if (e.Button == MouseButtons.Left && e.ColumnIndex == -1)
                {
                    DBConnection.ShowTableFacialS(Convert.ToInt32(dataGridAbonent.CurrentRow.Cells[0].Value.ToString()));
                    DBConnection.NomAbonent = Convert.ToInt32(dataGridAbonent.CurrentRow.Cells[0].Value.ToString());
                    Program.FacialS.Connect();
                    Program.Abonents.tableLayoutPanel1.ColumnStyles[0].Width = 50;
                    Program.Abonents.tableLayoutPanel1.ColumnStyles[1].Width = 50;
                }
            }
        }
        //При выборе заголовка столбца правой кнопкой мыши выводится список для отбора записей
        int key;
        private void dataGridAbonent_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.ColumnIndex != 0 && e.RowIndex == -1)
            {
                Filter.Items.Clear();
                switch (e.ColumnIndex)
                {
                    case (1):
                        {
                            DBConnection.ShowFilter("fioabonent", "t_abonent", "order by fioabonent");
                            key = 1;
                        }
                        break;
                    case (2):
                        {
                            DBConnection.ShowFilter("concat(s_city.gorod,' ',s_street.ylitca)", "t_abonent,s_street,s_city", "where t_abonent.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod order by concat(s_city.gorod,' ',s_street.ylitca)");
                            key = 2;
                        }
                        break;
                    case (3):
                        {
                            DBConnection.ShowFilter("telephone", "t_abonent", "order by telephone");
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
                        DBConnection.ShowFilters("t_abonent.id_abonent,t_abonent.fioabonent,concat(s_city.gorod,' ',s_street.ylitca ,' ',t_abonent.adres) as 'adres1', t_abonent.telephone,s_city.gorod, s_street.ylitca, t_abonent.adres", "t_abonent,s_street,s_city ", "where t_abonent.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and t_abonent.fioabonent = '" + e.ClickedItem.Text + "' order by fioabonent ");
                    }
                    break;
                case (2):
                    {
                        DBConnection.ShowFilters("t_abonent.id_abonent,t_abonent.fioabonent,concat(s_city.gorod,' ',s_street.ylitca ,' ',t_abonent.adres) as 'adres1', t_abonent.telephone,s_city.gorod, s_street.ylitca, t_abonent.adres", "t_abonent,s_street,s_city ", "where t_abonent.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and concat(s_city.gorod,' ',s_street.ylitca) = '" + e.ClickedItem.Text + "' order by fioabonent");
                    }
                    break;
                case (3):
                    {
                        DBConnection.ShowFilters("t_abonent.id_abonent,t_abonent.fioabonent,concat(s_city.gorod,' ',s_street.ylitca ,' ',t_abonent.adres) as 'adres1', t_abonent.telephone,s_city.gorod, s_street.ylitca, t_abonent.adres", "t_abonent,s_street,s_city", "where  t_abonent.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and t_abonent.telephone = '" + e.ClickedItem.Text + "'order by fioabonent");
                    }
                    break;
            }
            dataGridAbonent.DataSource = DBConnection.filters;
        }
        //Обновление данных в таблице
        private void btnUpdateAbonent_Click(object sender, EventArgs e)
        {
           RefreshTable();
        }
        //Метод обновления данных
        private void RefreshTable()
        {
            DBConnection.ShowTableAbonent();
            dataGridAbonent.DataSource = DBConnection.t_Abonent;
        }
        //Поиск записей в таблице
        private void btnSearchAbonent_Click(object sender, EventArgs e)
        {
            Searching s = new Searching();
            s.searched = Program.Abonent.dataGridAbonent;
            s.ShowDialog();
        }
        //Ограничение на ввод только кириллицы и цифр
        private void textBoxEditAbonentFIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Ограничение на ввод только кириллицы и цифр
        private void textBoxEditAbonentAdres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Ограничение на ввод только кириллицы и цифр
        private void textBoxAddAbonentFIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Ограничение на ввод только кириллицы и цифр
        private void textBoxAddAbonentAdres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
    }
}
