using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPTPostavhik : UserControl
    {
        public PPTPostavhik()
        {
            Program.Postav = this;
            InitializeComponent();
            Connect();
            dataGridPostav.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 12F, FontStyle.Bold);
            dataGridPostav.DefaultCellStyle.Font = new Font("Candara", 10F);
        }
        //Метод отображения данных таблицы «Поставщик» в таблицу
        public void Connect()
        {
            dataGridPostav.DataSource = DBConnection.t_Postav;
        }
        //Запуск таймера на открытия поля для добавления данных
        private void btnAddPostav_Click(object sender, EventArgs e)
        {
            groupEditPostav.Visible = false;
            groupAddPostav.Visible = true;
            if (tableLayoutPostav.RowStyles[0].Height == 100 && tableLayoutPostav.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Запуск таймера на открытия поля для редактирования данных
        private void btnEditPostav_Click(object sender, EventArgs e)
        {
            groupAddPostav.Visible = false;
            groupEditPostav.Visible = true;
            if (tableLayoutPostav.RowStyles[0].Height == 100 && tableLayoutPostav.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Открытие поля для добавления или редактирования данных
        private void timer1_Tick(object sender, EventArgs e)
        {
            tableLayoutPostav.RowStyles[1].Height += 24;
            tableLayoutPostav.RowStyles[0].Height -= 5;
            if (tableLayoutPostav.RowStyles[1].Height == 192 && tableLayoutPostav.RowStyles[0].Height == 60)
            {
                timer1.Stop();
            }
        }
        //Закрытие поля для добавления или редактирования данных
        private void timer2_Tick(object sender, EventArgs e)
        {
            tableLayoutPostav.RowStyles[1].Height -= 24;
            tableLayoutPostav.RowStyles[0].Height += 5;
            if (tableLayoutPostav.RowStyles[1].Height == 0 && tableLayoutPostav.RowStyles[0].Height == 100)
            {
                timer2.Stop();
            }
        }
        //Удаление выбранной записи из таблицы «Поставщик»
        private void btnDelPostav_Click(object sender, EventArgs e)
        {
            if (dataGridPostav.Rows.Count > 0)
            {
                if (dataGridPostav.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataGridPostav.SelectedRows.Count; i++)
                        {
                            int key_r = Convert.ToInt32(dataGridPostav.Rows[dataGridPostav.SelectedRows[i].Index].Cells[0].Value);
                            string postav = dataGridPostav.CurrentRow.Cells[1].Value.ToString();
                                string inn = dataGridPostav.CurrentRow.Cells[2].Value.ToString();
                                string kpp = dataGridPostav.CurrentRow.Cells[3].Value.ToString();
                                string ogrn = dataGridPostav.CurrentRow.Cells[4].Value.ToString();
                                string telephone = dataGridPostav.CurrentRow.Cells[5].Value.ToString();
                                string email = dataGridPostav.CurrentRow.Cells[6].Value.ToString();
                                string adres = dataGridPostav.CurrentRow.Cells[7].Value.ToString();
                            int log = DBConnection.DellTablePostav(key_r);
                            switch (log)
                            {
                                case (1):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поставщик: '" + postav + "' ИНН: '" + inn + "' КПП: '" + kpp + "' ОГРН: '" + ogrn + "' Тел: '" + telephone + "' Почта: '" + email + "' Адрес: '" + adres + "' успешно удален!");
                                    RefreshTable();
                                    break;
                                case (2):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поставщика: '" + postav + "' ИНН: '" + inn + "' КПП: '" + kpp + "' ОГРН: '" + ogrn + "' Тел: '" + telephone + "' Почта: '" + email + "' Адрес: '" + adres + "' удалить не удалось!");
                                    break;
                                case (3):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поставщик: '" + postav + "' ИНН: '" + inn + "' КПП: '" + kpp + "' ОГРН: '" + ogrn + "' Тел: '" + telephone + "' Почта: '" + email + "' Адрес: '" + adres + "' связан с таблицей 'Накладная', удаление невозможно!");
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
        private void btnHidePostav_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        //Запуск таймера на закрытие поля для добавления или редактирования данных
        private void Close(object sender, EventArgs e)
        {
            if (tableLayoutPostav.RowStyles[1].Height == 192 && tableLayoutPostav.RowStyles[0].Height == 60)
            {
                timer2.Start();
            }
        }
        //Добавление данных в таблицу «Поставщик»
        private void addPostav_Click(object sender, EventArgs e)
        {
            string email = textBoxAddPostavEmail.Text;
            string pattern = @"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$";
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            bool matched = r.Match(email).Success;
            if (matched == true)
            {
                int id_ylitca = DBConnection.keyRecord("s_street.id_ylitca", "s_street,s_city", "s_street.id_gorod = s_city.id_gorod and s_city.gorod = '" + comboBoxAddPostavCity.Text + "' and s_street.ylitca", comboBoxAddPostavStreet.Text);
                if (!String.IsNullOrEmpty(textBoxAddPostavNaim.Text)
                && !String.IsNullOrEmpty(id_ylitca.ToString())
                && !String.IsNullOrEmpty(textBoxAddPostavINN.Text)
                && !String.IsNullOrEmpty(textBoxAddPostavKPP.Text)
                && !String.IsNullOrEmpty(textBoxAddPostavOGRN.Text)
                && !String.IsNullOrEmpty(textBoxAddPostavTelephone.Text)
                && !String.IsNullOrEmpty(textBoxAddPostavEmail.Text)
                && !String.IsNullOrEmpty(textBoxAddPostavAdres.Text))
                {
                    int log = DBConnection.AddTablePostav(textBoxAddPostavNaim.Text, textBoxAddPostavINN.Text, textBoxAddPostavKPP.Text, textBoxAddPostavOGRN.Text, textBoxAddPostavTelephone.Text, textBoxAddPostavEmail.Text, id_ylitca, textBoxAddPostavAdres.Text);
                    switch (log)
                    {
                        case (1):
                            listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поставщик: '" + textBoxAddPostavNaim.Text + "' ИНН: '" + textBoxAddPostavINN.Text + "' КПП: '" + textBoxAddPostavKPP.Text + "' ОГРН: '" + textBoxAddPostavOGRN.Text + "' Тел: '" + textBoxAddPostavTelephone.Text + "' Почта: '" + textBoxAddPostavEmail.Text + "' Адрес: '" + textBoxAddPostavAdres.Text + "' был успешно добавлен!");
                            RefreshTable();
                            break;
                        case (2):
                            listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поставщика: '" + textBoxAddPostavNaim.Text + "' ИНН: '" + textBoxAddPostavINN.Text + "' КПП: '" + textBoxAddPostavKPP.Text + "' ОГРН: '" + textBoxAddPostavOGRN.Text + "' Тел: '" + textBoxAddPostavTelephone.Text + "' Почта: '" + textBoxAddPostavEmail.Text + "' Адрес: '" + textBoxAddPostavAdres.Text + "' добавить не удалось!");
                            break;
                        case (3):
                            listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поставщик: '" + textBoxAddPostavNaim.Text + "', ИНН: '" + textBoxAddPostavINN.Text + "', КПП: '" + textBoxAddPostavKPP.Text + "', ОГРН: '" + textBoxAddPostavOGRN.Text + "', Тел: '" + textBoxAddPostavTelephone.Text + "' или Почта: '" + textBoxAddPostavEmail.Text + "' уже существует, добавление Поставщика: '" + textBoxAddPostavNaim.Text + "' ИНН: '" + textBoxAddPostavINN.Text + "' КПП: '" + textBoxAddPostavKPP.Text + "' ОГРН: '" + textBoxAddPostavOGRN.Text + "' Тел: '" + textBoxAddPostavTelephone.Text + "' Почта: '" + textBoxAddPostavEmail.Text + "' Адрес: '" + textBoxAddPostavAdres.Text + "' невозможно!");
                            break;
                    }
                }
                else
                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Почта введена не правильно!");
            listBox1.TopIndex = listBox1.Items.Count - 1;

        }
        //Редактирование данных в таблице «Поставщик»
        private void editPostav_Click(object sender, EventArgs e)
        {
            string email = textBoxEditPostavEmail.Text;
            string pattern = @"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$";
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            bool matched = r.Match(email).Success;
            if (matched == true)
            {
                int key_r = Convert.ToInt32(dataGridPostav.CurrentRow.Cells[0].Value);
                int id_ylitca = DBConnection.keyRecord("s_street.id_ylitca", "s_street,s_city", "s_street.id_gorod = s_city.id_gorod and s_city.gorod = '" + comboBoxEditPostavCity.Text + "' and s_street.ylitca", comboBoxEditPostavStreet.Text);
                string postav = dataGridPostav.CurrentRow.Cells[1].Value.ToString();
                string inn = dataGridPostav.CurrentRow.Cells[2].Value.ToString();
                string kpp = dataGridPostav.CurrentRow.Cells[3].Value.ToString();
                string ogrn = dataGridPostav.CurrentRow.Cells[4].Value.ToString();
                string telephone = dataGridPostav.CurrentRow.Cells[5].Value.ToString();
                string emails = dataGridPostav.CurrentRow.Cells[6].Value.ToString();
                string adres = dataGridPostav.CurrentRow.Cells[7].Value.ToString();
                if (!String.IsNullOrEmpty(textBoxEditPostavNaim.Text)
                && !String.IsNullOrEmpty(id_ylitca.ToString())
                && !String.IsNullOrEmpty(textBoxEditPostavINN.Text)
                && !String.IsNullOrEmpty(textBoxEditPostavKPP.Text)
                && !String.IsNullOrEmpty(textBoxEditPostavOGRN.Text)
                && !String.IsNullOrEmpty(textBoxEditPostavTelephone.Text)
                && !String.IsNullOrEmpty(textBoxEditPostavEmail.Text)
                && !String.IsNullOrEmpty(textBoxEditPostavAdres.Text))
                {
                    int log = DBConnection.EditTablePostav(key_r, textBoxEditPostavNaim.Text, textBoxEditPostavINN.Text, textBoxEditPostavKPP.Text, textBoxEditPostavOGRN.Text, textBoxEditPostavTelephone.Text, textBoxEditPostavEmail.Text, id_ylitca, textBoxEditPostavAdres.Text);
                    switch (log)
                    {
                        case (1):
                            listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поставщик: '" + postav + "' ИНН: '" + inn + "' КПП: '" + kpp + "' ОГРН: '" + ogrn + "' Тел: '" + telephone + "' Почта: '" + emails + "' Адрес: '" + adres + "' был успешно обновлен на Поставщика: '" + textBoxEditPostavNaim.Text + "' ИНН: '" + textBoxEditPostavINN.Text + "' КПП: '" + textBoxEditPostavKPP.Text + "' ОГРН: '" + textBoxEditPostavOGRN.Text + "' Тел: '" + textBoxEditPostavTelephone.Text + "' Почта: '" + textBoxEditPostavEmail.Text + "' Адрес: '" + textBoxEditPostavAdres.Text + "'!");
                            RefreshTable();
                            break;
                        case (2):
                            listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поставщика: '" + postav + "' ИНН: '" + inn + "' КПП: '" + kpp + "' ОГРН: '" + ogrn + "' Тел: '" + telephone + "' Почта: '" + emails + "' Адрес: '" + adres + "' обновить на Поставщика: '" + textBoxEditPostavNaim.Text + "' ИНН: '" + textBoxEditPostavINN.Text + "' КПП: '" + textBoxEditPostavKPP.Text + "' ОГРН: '" + textBoxEditPostavOGRN.Text + "' Тел: '" + textBoxEditPostavTelephone.Text + "' Почта: '" + textBoxEditPostavEmail.Text + "' Адрес: '" + textBoxEditPostavAdres.Text + "'");
                            break;
                        case (3):
                            listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поставщик: '" + textBoxEditPostavNaim.Text + "', ИНН: '" + textBoxEditPostavINN.Text + "', КПП: '" + textBoxEditPostavKPP.Text + "', ОГРН: '" + textBoxEditPostavOGRN.Text + "', Тел: '" + textBoxEditPostavTelephone.Text + "' или Почта: '" + textBoxEditPostavEmail.Text + "' уже существует, обновление Поставщика: '" + postav + "' ИНН: '" + inn + "' КПП: '" + kpp + "' ОГРН: '" + ogrn + "' Тел: '" + telephone + "' Почта: '" + emails + "' Адрес: '" + adres + "' на на Поставщика: '" + textBoxEditPostavNaim.Text + "' ИНН: '" + textBoxEditPostavINN.Text + "' КПП: '" + textBoxEditPostavKPP.Text + "' ОГРН: '" + textBoxEditPostavOGRN.Text + "' Тел: '" + textBoxEditPostavTelephone.Text + "' Почта: '" + textBoxEditPostavEmail.Text + "' Адрес: '" + textBoxEditPostavAdres.Text + "' невозможно!");
                            break;
                    }
                }
                else
                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            }
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //При выборе города, в выпадающий список улиц для добавления выводятся улицы этого города
        private void comboBoxAddPostavCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBConnection.ShowStreet(comboBoxAddPostavCity.Text);
            comboBoxAddPostavStreet.DataSource = DBConnection.street;
            comboBoxAddPostavStreet.DisplayMember = "ylitca";
            comboBoxAddPostavStreet.ValueMember = "id_ylitca";
        }
        //При выборе города, в выпадающий список улиц для редактирования выводятся улицы этого города
        private void comboBoxEditPostavCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBConnection.ShowStreet(comboBoxEditPostavCity.Text);
            comboBoxEditPostavStreet.DataSource = DBConnection.street;
            comboBoxEditPostavStreet.DisplayMember = "ylitca";
            comboBoxEditPostavStreet.ValueMember = "id_ylitca";
        }
        //Отображение данных таблицы «Поставщик» в таблицу
        private void PPTPostav_Load(object sender, EventArgs e)
        {
            Connect();
            comboBoxAddPostavCity.DataSource = DBConnection.s_City;
            comboBoxAddPostavCity.DisplayMember = "gorod";

            comboBoxEditPostavCity.DataSource = DBConnection.s_City;
            comboBoxEditPostavCity.DisplayMember = "gorod";
        }
        //Выбор строки записей в таблице
        private void dataGridPostav_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textBoxEditPostavNaim.Text = dataGridPostav.CurrentRow.Cells[1].Value.ToString();
                textBoxEditPostavINN.Text = dataGridPostav.CurrentRow.Cells[2].Value.ToString();
                textBoxEditPostavKPP.Text = dataGridPostav.CurrentRow.Cells[3].Value.ToString();
                textBoxEditPostavOGRN.Text = dataGridPostav.CurrentRow.Cells[4].Value.ToString();
                textBoxEditPostavTelephone.Text = dataGridPostav.CurrentRow.Cells[5].Value.ToString();
                textBoxEditPostavEmail.Text = dataGridPostav.CurrentRow.Cells[6].Value.ToString();
                comboBoxEditPostavCity.Text = dataGridPostav.CurrentRow.Cells[8].Value.ToString();
                comboBoxEditPostavStreet.Text = dataGridPostav.CurrentRow.Cells[9].Value.ToString();
                textBoxEditPostavAdres.Text = dataGridPostav.CurrentRow.Cells[10].Value.ToString();
            }
        }
        //При выборе заголовка столбца правой кнопкой мыши выводится список для отбора записей
        int key;
        private void dataGridPostav_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.ColumnIndex != 0 && e.RowIndex == -1)
            {
                Filter.Items.Clear();
                switch (e.ColumnIndex)
                {
                    case (1):
                        {
                            DBConnection.ShowFilter("t_postavshik.naimpost", "t_postavshik", "order by naimpost");
                            key = 1;
                        }
                        break;
                    case (2):
                        {
                            DBConnection.ShowFilter("t_postavshik.INN", "t_postavshik", "order by INN");
                            key = 2;
                        }
                        break;
                    case (3):
                        {
                            DBConnection.ShowFilter("t_postavshik.KPP", "t_postavshik", "order by KPP");
                            key = 3;
                        }
                        break;
                    case (4):
                        {
                            DBConnection.ShowFilter("t_postavshik.OGRN", "t_postavshik", "order by OGRN");
                            key = 4;
                        }
                        break;
                    case (5):
                        {
                            DBConnection.ShowFilter("t_postavshik.telephone", "t_postavshik", "order by telephone");
                            key = 5;
                        }
                        break;
                    case (6):
                        {
                            DBConnection.ShowFilter("t_postavshik.email", "t_postavshik", "order by email");
                            key = 6;
                        }
                        break;
                    case (7):
                        {
                            DBConnection.ShowFilter("concat(s_city.gorod,' ',s_street.ylitca)", "t_postavshik,s_street,s_city", "where t_postavshik.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod order by concat(s_city.gorod,' ',s_street.ylitca)");
                            key = 7;
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
                        DBConnection.ShowFilters("t_postavshik.id_postavshik, t_postavshik.naimpost,  t_postavshik.INN, t_postavshik.KPP, t_postavshik.OGRN, t_postavshik.telephone, t_postavshik.email, concat(s_city.gorod,' ',s_street.ylitca,' ',t_postavshik.adres) as 'adres1',s_city.gorod,s_street.ylitca, t_postavshik.adres",
                            "t_postavshik,s_street,s_city", "where t_postavshik.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and t_postavshik.naimpost = '" + e.ClickedItem.Text + "' order by naimpost");
                    }
                    break;
                case (2):
                    {
                        DBConnection.ShowFilters("t_postavshik.id_postavshik, t_postavshik.naimpost,  t_postavshik.INN, t_postavshik.KPP, t_postavshik.OGRN, t_postavshik.telephone, t_postavshik.email, concat(s_city.gorod,' ',s_street.ylitca,' ',t_postavshik.adres) as 'adres1',s_city.gorod,s_street.ylitca, t_postavshik.adres",
                               "t_postavshik,s_street,s_city", "where t_postavshik.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and t_postavshik.INN = '" + e.ClickedItem.Text + "' order by naimpost");
                    }
                    break;
                case (3):
                    {
                        DBConnection.ShowFilters("t_postavshik.id_postavshik, t_postavshik.naimpost,  t_postavshik.INN, t_postavshik.KPP, t_postavshik.OGRN, t_postavshik.telephone, t_postavshik.email, concat(s_city.gorod,' ',s_street.ylitca,' ',t_postavshik.adres) as 'adres1',s_city.gorod,s_street.ylitca, t_postavshik.adres",
                            "t_postavshik,s_street,s_city", "where t_postavshik.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and t_postavshik.KPP = '" + e.ClickedItem.Text + "' order by naimpost");
                    }
                    break;
                case (4):
                    {
                        DBConnection.ShowFilters("t_postavshik.id_postavshik, t_postavshik.naimpost,  t_postavshik.INN, t_postavshik.KPP, t_postavshik.OGRN, t_postavshik.telephone, t_postavshik.email, concat(s_city.gorod,' ',s_street.ylitca,' ',t_postavshik.adres) as 'adres1',s_city.gorod,s_street.ylitca, t_postavshik.adres",
                            "t_postavshik,s_street,s_city", "where t_postavshik.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and t_postavshik.OGRN = '" + e.ClickedItem.Text + "' order by naimpost");
                    }
                    break;
                case (5):
                    {
                        DBConnection.ShowFilters("t_postavshik.id_postavshik, t_postavshik.naimpost,  t_postavshik.INN, t_postavshik.KPP, t_postavshik.OGRN, t_postavshik.telephone, t_postavshik.email, concat(s_city.gorod,' ',s_street.ylitca,' ',t_postavshik.adres) as 'adres1',s_city.gorod,s_street.ylitca, t_postavshik.adres",
                            "t_postavshik,s_street,s_city", "where t_postavshik.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and t_postavshik.telephone = '" + e.ClickedItem.Text + "' order by naimpost");
                    }
                    break;
                case (6):
                    {
                        DBConnection.ShowFilters("t_postavshik.id_postavshik, t_postavshik.naimpost,  t_postavshik.INN, t_postavshik.KPP, t_postavshik.OGRN, t_postavshik.telephone, t_postavshik.email, concat(s_city.gorod,' ',s_street.ylitca,' ',t_postavshik.adres) as 'adres1',s_city.gorod,s_street.ylitca, t_postavshik.adres",
                            "t_postavshik,s_street,s_city", "where t_postavshik.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and t_postavshik.email = '" + e.ClickedItem.Text + "' order by naimpost");
                    }
                    break;
                case (7):
                    {
                        DBConnection.ShowFilters("t_postavshik.id_postavshik, t_postavshik.naimpost,  t_postavshik.INN, t_postavshik.KPP, t_postavshik.OGRN, t_postavshik.telephone, t_postavshik.email, concat(s_city.gorod,' ',s_street.ylitca,' ',t_postavshik.adres) as 'adres1',s_city.gorod,s_street.ylitca, t_postavshik.adres",
                            "t_postavshik,s_street,s_city", "where t_postavshik.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and concat(s_city.gorod,' ',s_street.ylitca) = '" + e.ClickedItem.Text + "' order by naimpost");
                    }
                    break;
            }
            dataGridPostav.DataSource = DBConnection.filters;
        }
        //Обновление данных в таблице
        private void btnUpdatePostav_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
        //Метод обновления данных
        private void RefreshTable()
        {
            DBConnection.ShowTablePostav();
            Connect();
        }
        //Поиск записей в таблице
        private void btnSearchPostav_Click(object sender, EventArgs e)
        {
            Searching s = new Searching();
            s.searched = Program.Postav.dataGridPostav;
            s.ShowDialog();
        }
        //Ограничение на ввод только кириллицы и цифр
        private void textBoxEditPostavNaim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Ограничение на ввод только цифр
        private void textBoxEditPostavINN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
                e.Handled = true;
        }
        //Ограничение на ввод только цифр
        private void textBoxEditPostavOGRN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
                e.Handled = true;
        }
        //Ограничение на ввод только цифр
        private void textBoxEditPostavKPP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
                e.Handled = true;
        }
        //Ограничение на ввод только кириллицы и цифр
        private void textBoxAddPostavNaim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Ограничение на ввод только цифр
        private void textBoxAddPostavINN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
                e.Handled = true;
        }
        //Ограничение на ввод только цифр
        private void textBoxAddPostavKPP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
                e.Handled = true;
        }
        //Ограничение на ввод только цифр
        private void textBoxAddPostavOGRN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
                e.Handled = true;
        }
        //Ограничение на ввод только кириллицы и цифр
        private void textBoxEditPostavAdres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Ограничение на ввод только кириллицы и цифр
        private void textBoxAddPostavAdres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
    }
}
