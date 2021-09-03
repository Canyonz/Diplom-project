using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPODogovor : UserControl
    {
        public PPODogovor()
        {
            Program.Dogovor = this;
            InitializeComponent();
            this.dataGridDogovor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridDogovor.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 12F, FontStyle.Bold);
            dataGridDogovor.DefaultCellStyle.Font = new Font("Candara", 10F);
        }
        //Метод отображения данных таблицы «Договора» в таблицу
        public void Connect()
        {
            dataGridDogovor.DataSource = DBConnection.o_Dogovor;
        }
        //Рисует строку цветом статуса
        public void color()
        {
            for (int i = 0; i < dataGridDogovor.Rows.Count; i++)
            {
                if (dataGridDogovor.Rows[i].Cells[8].Value.ToString() != "")
                    dataGridDogovor.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(Convert.ToInt32(DBConnection.colorFromStatusE(dataGridDogovor.Rows[i].Cells[8].Value.ToString())));
            }
        }
        //Запуск таймера на открытия поля для добавления данных
        private void btnAddDogovor_Click(object sender, EventArgs e)
        {
            groupEditDogovor.Visible = false;
            groupAddDogovor.Visible = true;
            if (tableLayoutDogovor.RowStyles[0].Height == 100 && tableLayoutDogovor.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Запуск таймера на открытия поля для редактирования данных
        private void btnEditDogovor_Click(object sender, EventArgs e)
        {
            groupAddDogovor.Visible = false;
            groupEditDogovor.Visible = true;
            if (tableLayoutDogovor.RowStyles[0].Height == 100 && tableLayoutDogovor.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Открытие поля для добавления или редактирования данных
        private void timer1_Tick(object sender, EventArgs e)
        {
            tableLayoutDogovor.RowStyles[1].Height += 24;
            tableLayoutDogovor.RowStyles[0].Height -= 5;
            if (tableLayoutDogovor.RowStyles[1].Height == 192 && tableLayoutDogovor.RowStyles[0].Height == 60)
            {
                timer1.Stop();
            }
        }
        //Закрытие поля для добавления или редактирования данных
        private void timer2_Tick(object sender, EventArgs e)
        {
            tableLayoutDogovor.RowStyles[1].Height -= 24;
            tableLayoutDogovor.RowStyles[0].Height += 5;
            if (tableLayoutDogovor.RowStyles[1].Height == 0 && tableLayoutDogovor.RowStyles[0].Height == 100)
            {
                timer2.Stop();
            }
        }
        //Удаление выбранной записи из таблицы «Договора»
        private void btnDelDogovor_Click(object sender, EventArgs e)
        {
            if (dataGridDogovor.Rows.Count > 0)
            {
                if (dataGridDogovor.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataGridDogovor.SelectedRows.Count; i++)
                        {
                            int key_r = Convert.ToInt32(dataGridDogovor.Rows[dataGridDogovor.SelectedRows[i].Index].Cells[0].Value);
                            string nom = dataGridDogovor.CurrentRow.Cells[1].Value.ToString();
                            string abonent = dataGridDogovor.CurrentRow.Cells[2].Value.ToString();
                            string yslyga = dataGridDogovor.CurrentRow.Cells[3].Value.ToString();
                            string adres = dataGridDogovor.CurrentRow.Cells[4].Value.ToString();
                            string sotryd = dataGridDogovor.CurrentRow.Cells[6].Value.ToString();
                            string date = dataGridDogovor.CurrentRow.Cells[9].Value.ToString();
                            int log = DBConnection.DellTableDogovor(key_r);
                            switch (log)
                            {
                                case (1):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Договор №: '" + nom + "' Абонент: '" + abonent + "' Услуга: '" + yslyga + "' Адрес установки: '" + adres + "' Сотрудник: '" + sotryd + "' Дата: '" + date + "' успешно удален!");
                                    RefreshTable();
                                    break;
                                case (2):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Договор №: '" + nom + "' Абонент: '" + abonent + "' Услуга: '" + yslyga + "' Адрес установки: '" + adres + "' Сотрудник: '" + sotryd + "' Дата: '" + date + "' удалить не удалось!");
                                    break;
                                case (3):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Договор №: '" + nom + "' связан с таблицей 'Акты', удаление невозможно!");
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
        private void btnHideDogovor_Click(object sender, EventArgs e)
        {
           if (Program.Dogovors.tableLayoutPanel1.ColumnStyles[1].Width > 0 || Program.Dogovors.tableLayoutPanel1.ColumnStyles[2].Width > 0)
            {
                Program.Dogovors.tableLayoutPanel1.ColumnStyles[0].Width = 0;
            }
        }
        //Запуск таймера на закрытие поля для добавления или редактирования данных
        private void Close(object sender, EventArgs e)
        {
            if (tableLayoutDogovor.RowStyles[1].Height == 192 && tableLayoutDogovor.RowStyles[0].Height == 60)
            {
                timer2.Start();
            }
        }
        //Добавление данных в таблицу «Договора»
        private void addDogovor_Click(object sender, EventArgs e)
        {
            int Abonent = DBConnection.keyRecord("id_facialscore", "t_facialscore", "facialscore", comboBoxAddDogovorFacialS.Text);
            int Sotryd = DBConnection.keyRecord("id_sotryd", "authorization", "fiosotryd", DBConnection.NameUsers);
            int Yslyg = DBConnection.keyRecord("id_yslyg", "s_yslyg", "yslyga", comboBoxAddDogovorYslyga.Text);
            int Ylitca = DBConnection.keyRecord("s_street.id_ylitca", "s_street,s_city", "s_street.id_gorod = s_city.id_gorod and s_city.gorod = '" + comboBoxAddDogovorCity.Text + "' and s_street.ylitca", comboBoxAddDogovorStreet.Text);
            if (!String.IsNullOrEmpty(textBoxAddDogovorNomDog.Text)
                && !String.IsNullOrEmpty(Sotryd.ToString())
                && !String.IsNullOrEmpty(Abonent.ToString())
                && !String.IsNullOrEmpty(Yslyg.ToString())
                && !String.IsNullOrEmpty(Ylitca.ToString())
                && !String.IsNullOrEmpty(dateTimeAddDogovorDate.Text))
            {
                int log = DBConnection.AddTableDogovor(textBoxAddDogovorNomDog.Text, Yslyg, Ylitca, textBoxAddDogovorDom.Text, Sotryd, Abonent, 2, dateTimeAddDogovorDate.Value);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Договор №: '" + textBoxAddDogovorNomDog.Text + "' Абонент: '" + comboBoxAddDogovorAbonent.Text + "' Услуга: '" + comboBoxAddDogovorYslyga.Text + "' Адрес установки: '" + comboBoxAddDogovorCity.Text+' '+comboBoxAddDogovorStreet.Text+' '+textBoxAddDogovorDom.Text + "'  Сотрудник: '" + DBConnection.NameUsers + "' Дата: '" + dateTimeAddDogovorDate.Text + "' был успешно добавлен!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Договор №: '" + textBoxAddDogovorNomDog.Text + "' Абонент: '" + comboBoxAddDogovorAbonent.Text + "' Услуга: '" + comboBoxAddDogovorYslyga.Text + "' Адрес установки: '" + comboBoxAddDogovorCity.Text + ' ' + comboBoxAddDogovorStreet.Text + ' ' + textBoxAddDogovorDom.Text + "'  Сотрудник: '" + DBConnection.NameUsers + "' Дата: '" + dateTimeAddDogovorDate.Text + "' добавить не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Договор №: '" + textBoxAddDogovorNomDog.Text + "' уже существует, добавление Договора №: '" + textBoxAddDogovorNomDog.Text + "' Абонент: '" + comboBoxAddDogovorAbonent.Text + "' Услуга: '" + comboBoxAddDogovorYslyga.Text + "' Адрес установки: '" + comboBoxAddDogovorCity.Text + ' ' + comboBoxAddDogovorStreet.Text + ' ' + textBoxAddDogovorDom.Text + "' Сотрудник: '" + DBConnection.NameUsers + "' Дата: '" + dateTimeAddDogovorDate.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Редактирование данных в таблице «Договора»
        private void editDogovor_Click(object sender, EventArgs e)
        {
            int key_r = Convert.ToInt32(dataGridDogovor.CurrentRow.Cells[0].Value);
            int Abonent = Convert.ToInt32(DBConnection.keyRecord("id_facialscore", "t_facialscore", "facialscore", comboBoxEditDogovorFacialS.Text));
            int Yslyg = DBConnection.keyRecord("id_yslyg", "s_yslyg", "yslyga", comboBoxEditDogovorYslyga.Text);
            int Ylitca = DBConnection.keyRecord("s_street.id_ylitca", "s_street,s_city", "s_street.id_gorod = s_city.id_gorod and s_city.gorod = '" + comboBoxEditDogovorCity.Text + "' and s_street.ylitca", comboBoxEditDogovorStreet.Text);
            string nom = dataGridDogovor.CurrentRow.Cells[1].Value.ToString();
            string abonent = dataGridDogovor.CurrentRow.Cells[2].Value.ToString();
            string yslyga = dataGridDogovor.CurrentRow.Cells[3].Value.ToString();
            string adres = dataGridDogovor.CurrentRow.Cells[4].Value.ToString();
            string sotryd = dataGridDogovor.CurrentRow.Cells[6].Value.ToString();
            string date = dataGridDogovor.CurrentRow.Cells[9].Value.ToString();

            if (!String.IsNullOrEmpty(textBoxEditDogovorNomDog.Text)
                && !String.IsNullOrEmpty(Abonent.ToString())
                && !String.IsNullOrEmpty(dateTimeEditDogovorDate.Text))
            {
                int log = DBConnection.EditTableDogovor(key_r, textBoxEditDogovorNomDog.Text, Yslyg, Ylitca, textBoxEditDogovorDom.Text, Abonent, dateTimeEditDogovorDate.Value);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Договор №: '" + nom + "' Абонент: '" + abonent + "' Услуга: '" + yslyga + "' Адрес установки: '" + adres + "' Сотрудник: '" + sotryd + "' Дата: '" + date + "' был успешно обновлен на Договор №: '" + textBoxEditDogovorNomDog.Text + "' Абонент: '" + comboBoxEditDogovorAbonent.Text +' '+comboBoxEditDogovorFacialS.Text+ "' Услуга: '" + comboBoxEditDogovorYslyga.Text + "' Адрес установки: '" + comboBoxEditDogovorCity.Text + ' ' + comboBoxEditDogovorStreet.Text + ' ' + textBoxEditDogovorDom.Text + "' Сотрудник: '" + sotryd + "' Дата: '" + dateTimeEditDogovorDate.Text + "'!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Договор №: '" + nom + "' Абонент: '" + abonent + "' Услуга: '" + yslyga + "' Адрес установки: '" + adres + "'  Сотрудник: '" + sotryd + "' Дата: '" + date + "' обновить на Договор №: '" + textBoxEditDogovorNomDog.Text + "' Абонент: '" + comboBoxEditDogovorAbonent.Text + ' ' + comboBoxEditDogovorFacialS.Text + "' Услуга: '" + comboBoxEditDogovorYslyga.Text + "' Адрес установки: '" + comboBoxEditDogovorCity.Text + ' ' + comboBoxEditDogovorStreet.Text + ' ' + textBoxEditDogovorDom.Text + "' Сотрудник: '" + sotryd + "' Дата: '" + dateTimeEditDogovorDate.Text + "' не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Договор №: '" + textBoxEditDogovorNomDog.Text + "' уже существует, обновление Договора №: '" + nom + "' Абонент: '" + abonent + "' Услуга: '" + yslyga + "' Адрес установки: '" + adres + "'  Сотрудник: '" + sotryd + "' Дата: '" + date + "' на Договор №: '" + textBoxEditDogovorNomDog.Text + "' Абонент: '" + comboBoxEditDogovorAbonent.Text + ' ' + comboBoxEditDogovorFacialS.Text + "' Услуга: '" + comboBoxEditDogovorYslyga.Text + "' Адрес установки: '" + comboBoxEditDogovorCity.Text + ' ' + comboBoxEditDogovorStreet.Text + ' ' + textBoxEditDogovorDom.Text + "'  Сотрудник: '" + sotryd + "' Дата: '" + dateTimeEditDogovorDate.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;

        }
        //При выборе ФИО абонента, в выпадающий список лицевых счетов для добавления выводятся лицевые счета этого абонента
        private void comboBoxAddDogovorAbonent_SelectedIndexChanged(object sender, EventArgs e)
        {

            DBConnection.ShowTableFacialS(DBConnection.keyRecord("id_abonent", "t_abonent", "fioabonent", comboBoxAddDogovorAbonent.Text));
            comboBoxAddDogovorFacialS.DataSource = DBConnection.t_FacialS;
            comboBoxAddDogovorFacialS.DisplayMember = "facialscore";
        }
        //При выборе ФИО абонента, в выпадающий список лицевых счетов для редактирования выводятся лицевые счета этого абонента
        private void comboBoxEditDogovorAbonent_SelectedIndexChanged(object sender, EventArgs e)
        {

            DBConnection.ShowTableFacialS(DBConnection.keyRecord("id_abonent", "t_abonent", "fioabonent", comboBoxEditDogovorAbonent.Text));
            comboBoxEditDogovorFacialS.DataSource = DBConnection.t_FacialS;
            comboBoxEditDogovorFacialS.DisplayMember = "facialscore";
        }
        //Отображение данных таблицы «Договора» в таблицу
        private void PPTDogovor_Load(object sender, EventArgs e)
        {
            comboBoxAddDogovorAbonent.DataSource = DBConnection.t_Abonent;
            comboBoxAddDogovorAbonent.DisplayMember = "fioabonent";
            comboBoxAddDogovorCity.DataSource = DBConnection.s_City;
            comboBoxAddDogovorCity.DisplayMember = "gorod";
            comboBoxAddDogovorYslyga.DataSource = DBConnection.s_yslygi;
            comboBoxAddDogovorYslyga.DisplayMember = "yslyga";

            comboBoxEditDogovorAbonent.DataSource = DBConnection.t_Abonent;
            comboBoxEditDogovorAbonent.DisplayMember = "fioabonent";
            comboBoxEditDogovorCity.DataSource = DBConnection.s_City;
            comboBoxEditDogovorCity.DisplayMember = "gorod";
            comboBoxEditDogovorYslyga.DataSource = DBConnection.s_yslygi;
            comboBoxEditDogovorYslyga.DisplayMember = "yslyga";
            this.dataGridDogovor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }
        //При выборе города, в выпадающий список улиц для добавления выводятся улицы этого города
        private void comboBoxEditDogovorCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBConnection.ShowStreet(comboBoxAddDogovorCity.Text);
            comboBoxAddDogovorStreet.DataSource = DBConnection.street;
            comboBoxAddDogovorStreet.DisplayMember = "ylitca";
            comboBoxAddDogovorStreet.ValueMember = "id_ylitca";
        }
        //При выборе города, в выпадающий список улиц для редактирования выводятся улицы этого города
        private void comboBoxAddDogovorCity_SelectedIndexChanged(object sender, EventArgs e)
        {
           DBConnection.ShowStreet(comboBoxEditDogovorCity.Text);
            comboBoxEditDogovorStreet.DataSource = DBConnection.street;
            comboBoxEditDogovorStreet.DisplayMember = "ylitca";
            comboBoxEditDogovorStreet.ValueMember = "id_ylitca";
        }
        //Выбор строки записей в таблице, открытие формы «Акт»
        private void dataGridDogovor_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textBoxEditDogovorNomDog.Text = dataGridDogovor.CurrentRow.Cells[1].Value.ToString();
                comboBoxEditDogovorYslyga.Text = dataGridDogovor.CurrentRow.Cells[3].Value.ToString();
                comboBoxEditDogovorAbonent.Text = dataGridDogovor.CurrentRow.Cells[5].Value.ToString();
                comboBoxEditDogovorFacialS.Text = dataGridDogovor.CurrentRow.Cells[6].Value.ToString();

                comboBoxEditDogovorCity.Text = dataGridDogovor.CurrentRow.Cells[10].Value.ToString();
                comboBoxEditDogovorStreet.Text = dataGridDogovor.CurrentRow.Cells[11].Value.ToString();
                textBoxEditDogovorDom.Text = dataGridDogovor.CurrentRow.Cells[12].Value.ToString();
                dateTimeEditDogovorDate.Text = dataGridDogovor.CurrentRow.Cells[9].Value.ToString();

                if (e.Button == MouseButtons.Left && e.ColumnIndex == -1)
                {
                    DBConnection.ShowTableAct(Convert.ToInt32(dataGridDogovor.CurrentRow.Cells[0].Value.ToString()));
                    DBConnection.NomDogovor = Convert.ToInt32(dataGridDogovor.CurrentRow.Cells[0].Value.ToString());
                    Program.Act.dateTimeAddActDate.MinDate = Convert.ToDateTime(dataGridDogovor.CurrentRow.Cells[9].Value.ToString());
                    Program.Act.dateTimeEditActDate.MinDate = Convert.ToDateTime(dataGridDogovor.CurrentRow.Cells[9].Value.ToString());
                    Program.Act.Connect();
                    Program.Dogovors.tableLayoutPanel1.ColumnStyles[0].Width = 50;
                    Program.Dogovors.tableLayoutPanel1.ColumnStyles[1].Width = 50;
                }
            }
        }
        //При нажатии на кнопку отбора по статусу выводится список для отбора записей
        int key;
        private void FilterDate_MouseClick(object sender, MouseEventArgs e)
        {
            Filter.Items.Clear();
            DBConnection.ShowFilter("s_statusad.statusad,s_statusad.colorstatusad", "t_dogovor, s_statusad", "where t_dogovor.id_statusad = s_statusad.id_statusad");
            key = 8;
            int j = 0;
            for (int i = 0; i < DBConnection.filter.Rows.Count; i++)
            {
                if (!String.IsNullOrEmpty(DBConnection.filter.Rows[i].ItemArray.GetValue(0).ToString())
                    || !String.IsNullOrEmpty(DBConnection.filter.Rows[i].ItemArray.GetValue(1).ToString()))
                {
                    Filter.Items.Add(new ToolStripMenuItem(DBConnection.filter.Rows[i].ItemArray.GetValue(0).ToString()));
                    Filter.Items[j].BackColor = Color.FromArgb(Convert.ToInt32(DBConnection.filter.Rows[i].ItemArray.GetValue(1).ToString()));
                    j++;
                }
            }
            Filter.Show(MousePosition, ToolStripDropDownDirection.BelowRight);
        }
        //При выборе заголовка столбца правой кнопкой мыши выводится список для отбора записей
        private void dataGridAct_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Connect();
            }
            else
            if (e.Button == MouseButtons.Right && e.ColumnIndex != 0 && e.RowIndex == -1)
            {
                Filter.Items.Clear();
                switch (e.ColumnIndex)
                {
                    case (1):
                        {
                            DBConnection.ShowFilter("t_dogovor.nomdogovor", "t_dogovor", "");
                            key = 1;
                        }
                        break;
                    case (2):
                        {
                            DBConnection.ShowFilter("concat(t_abonent.fioabonent, ' - ' , t_facialscore.facialscore)", "t_dogovor, t_facialscore,t_abonent", "where t_dogovor.id_facialscore = t_facialscore.id_facialscore  and t_facialscore.id_abonent = t_abonent.id_abonent");
                            key = 2;
                        }
                        break;
                    case (3):
                        {
                            DBConnection.ShowFilter("s_yslyg.yslyga", "t_dogovor,s_yslyg", "where t_dogovor.id_yslyg = s_yslyg.id_yslyg");
                            key = 3;
                        }
                        break;
                    case (4):
                        {
                            DBConnection.ShowFilter("concat(s_city.gorod,' ',s_street.ylitca)", "t_dogovor,s_street,s_city", "where t_dogovor.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod");
                            key = 4;
                        }
                        break;
                    case (9):
                        {
                            DBConnection.ShowFilter("t_dogovor.date", "t_dogovor", "");
                            key = 9;
                        }
                        break;
                    case (7):
                        {
                            DBConnection.ShowFilter("authorization.fiosotryd", "t_dogovor, authorization", "where t_dogovor.id_sotryd = authorization.id_sotryd");
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
                        DBConnection.ShowFilters("t_dogovor.id_dogovor, t_dogovor.nomdogovor,concat(t_abonent.fioabonent, ' - ' , t_facialscore.facialscore) as 'abonent' ,s_yslyg.yslyga,concat(s_city.gorod,' ',s_street.ylitca ,' ',t_dogovor.adres) as 'adres1',t_abonent.fioabonent, t_facialscore.facialscore,  authorization.fiosotryd, s_statusad.statusad, t_dogovor.date,s_city.gorod,s_street.ylitca,t_dogovor.adres",
"t_dogovor, authorization, s_statusad, t_facialscore,t_abonent,s_street,s_city,s_yslyg",
"where t_dogovor.id_sotryd = authorization.id_sotryd and t_dogovor.id_yslyg = s_yslyg.id_yslyg and t_dogovor.id_statusad = s_statusad.id_statusad and t_dogovor.id_facialscore = t_facialscore.id_facialscore and t_dogovor.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and t_facialscore.id_abonent = t_abonent.id_abonent and t_dogovor.nomdogovor = '" + e.ClickedItem.Text + "' order by nomdogovor desc");
                    }
                    break;
                case (2):
                    {
                        DBConnection.ShowFilters("t_dogovor.id_dogovor, t_dogovor.nomdogovor,concat(t_abonent.fioabonent, ' - ' , t_facialscore.facialscore) as 'abonent' ,s_yslyg.yslyga,concat(s_city.gorod,' ',s_street.ylitca ,' ',t_dogovor.adres) as 'adres1',t_abonent.fioabonent, t_facialscore.facialscore,  authorization.fiosotryd, s_statusad.statusad, t_dogovor.date,s_city.gorod,s_street.ylitca,t_dogovor.adres",
        "t_dogovor, authorization, s_statusad, t_facialscore,t_abonent,s_street,s_city,s_yslyg",
        "where t_dogovor.id_sotryd = authorization.id_sotryd and t_dogovor.id_yslyg = s_yslyg.id_yslyg and t_dogovor.id_statusad = s_statusad.id_statusad and t_dogovor.id_facialscore = t_facialscore.id_facialscore and t_dogovor.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and t_facialscore.id_abonent = t_abonent.id_abonent and concat(t_abonent.fioabonent, ' - ' , t_facialscore.facialscore) = '" + e.ClickedItem.Text + "' order by nomdogovor desc");
                    }
                    break;
                case (3):
                    {
                        DBConnection.ShowFilters("t_dogovor.id_dogovor, t_dogovor.nomdogovor,concat(t_abonent.fioabonent, ' - ' , t_facialscore.facialscore) as 'abonent' ,s_yslyg.yslyga,concat(s_city.gorod,' ',s_street.ylitca ,' ',t_dogovor.adres) as 'adres1',t_abonent.fioabonent, t_facialscore.facialscore,  authorization.fiosotryd, s_statusad.statusad, t_dogovor.date,s_city.gorod,s_street.ylitca,t_dogovor.adres",
        "t_dogovor, authorization, s_statusad, t_facialscore,t_abonent,s_street,s_city,s_yslyg",
        "where t_dogovor.id_sotryd = authorization.id_sotryd and t_dogovor.id_yslyg = s_yslyg.id_yslyg and t_dogovor.id_statusad = s_statusad.id_statusad and t_dogovor.id_facialscore = t_facialscore.id_facialscore and t_dogovor.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and t_facialscore.id_abonent = t_abonent.id_abonent and s_yslyg.yslyga = '" + e.ClickedItem.Text + "' order by nomdogovor desc");
                    }
                    break;
                case (4):
                    {
                        DBConnection.ShowFilters("t_dogovor.id_dogovor, t_dogovor.nomdogovor,concat(t_abonent.fioabonent, ' - ' , t_facialscore.facialscore) as 'abonent' ,s_yslyg.yslyga,concat(s_city.gorod,' ',s_street.ylitca ,' ',t_dogovor.adres) as 'adres1',t_abonent.fioabonent, t_facialscore.facialscore,  authorization.fiosotryd, s_statusad.statusad, t_dogovor.date,s_city.gorod,s_street.ylitca,t_dogovor.adres",
        "t_dogovor, authorization, s_statusad, t_facialscore,t_abonent,s_street,s_city,s_yslyg",
        "where t_dogovor.id_sotryd = authorization.id_sotryd and t_dogovor.id_yslyg = s_yslyg.id_yslyg and t_dogovor.id_statusad = s_statusad.id_statusad and t_dogovor.id_facialscore = t_facialscore.id_facialscore and t_dogovor.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and t_facialscore.id_abonent = t_abonent.id_abonent and concat(s_city.gorod,' ',s_street.ylitca) = '" + e.ClickedItem.Text + "' order by nomdogovor desc");
                    }
                    break;
                case (9):
                    {
                        DBConnection.ShowFilters("t_dogovor.id_dogovor, t_dogovor.nomdogovor,concat(t_abonent.fioabonent, ' - ' , t_facialscore.facialscore) as 'abonent' ,s_yslyg.yslyga,concat(s_city.gorod,' ',s_street.ylitca ,' ',t_dogovor.adres) as 'adres1',t_abonent.fioabonent, t_facialscore.facialscore,  authorization.fiosotryd, s_statusad.statusad, t_dogovor.date,s_city.gorod,s_street.ylitca,t_dogovor.adres",
"t_dogovor, authorization, s_statusad, t_facialscore,t_abonent,s_street,s_city,s_yslyg",
"where t_dogovor.id_sotryd = authorization.id_sotryd and t_dogovor.id_yslyg = s_yslyg.id_yslyg and t_dogovor.id_statusad = s_statusad.id_statusad and t_dogovor.id_facialscore = t_facialscore.id_facialscore and t_dogovor.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and t_facialscore.id_abonent = t_abonent.id_abonent and t_dogovor.date = '" + Convert.ToDateTime(e.ClickedItem.Text).ToString("yyyy.MM.dd") + "' order by nomdogovor desc");
                    }
                    break;
                case (8):
                    {
                        DBConnection.ShowFilters("t_dogovor.id_dogovor, t_dogovor.nomdogovor,concat(t_abonent.fioabonent, ' - ' , t_facialscore.facialscore) as 'abonent' ,s_yslyg.yslyga,concat(s_city.gorod,' ',s_street.ylitca ,' ',t_dogovor.adres) as 'adres1',t_abonent.fioabonent, t_facialscore.facialscore,  authorization.fiosotryd, s_statusad.statusad, t_dogovor.date,s_city.gorod,s_street.ylitca,t_dogovor.adres",
        "t_dogovor, authorization, s_statusad, t_facialscore,t_abonent,s_street,s_city,s_yslyg",
        "where t_dogovor.id_sotryd = authorization.id_sotryd and t_dogovor.id_yslyg = s_yslyg.id_yslyg and t_dogovor.id_statusad = s_statusad.id_statusad and t_dogovor.id_facialscore = t_facialscore.id_facialscore and t_dogovor.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and t_facialscore.id_abonent = t_abonent.id_abonent and s_statusad.statusad = '" + e.ClickedItem.Text + "' order by nomdogovor desc");
                    }
                    break;
                case (7):
                    {
                        DBConnection.ShowFilters("t_dogovor.id_dogovor, t_dogovor.nomdogovor,concat(t_abonent.fioabonent, ' - ' , t_facialscore.facialscore) as 'abonent' ,s_yslyg.yslyga,concat(s_city.gorod,' ',s_street.ylitca ,' ',t_dogovor.adres) as 'adres1',t_abonent.fioabonent, t_facialscore.facialscore,  authorization.fiosotryd, s_statusad.statusad, t_dogovor.date,s_city.gorod,s_street.ylitca,t_dogovor.adres",
        "t_dogovor, authorization, s_statusad, t_facialscore,t_abonent,s_street,s_city,s_yslyg",
        "where t_dogovor.id_sotryd = authorization.id_sotryd and t_dogovor.id_yslyg = s_yslyg.id_yslyg and t_dogovor.id_statusad = s_statusad.id_statusad and t_dogovor.id_facialscore = t_facialscore.id_facialscore and t_dogovor.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod and t_facialscore.id_abonent = t_abonent.id_abonent and authorization.fiosotryd = '" + e.ClickedItem.Text + "' order by nomdogovor desc");
                    }
                    break;
            }
            dataGridDogovor.DataSource = DBConnection.filters;
            color();
        }
        //Обновление данных в таблице
        private void btnUpdateDogovor_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
        //Метод обновления данных
        private void RefreshTable()
        {
            DBConnection.ShowTableDogovor();
            Connect();
            color();
        }
        //Поиск записей в таблице
        private void btnSearchDogovor_Click(object sender, EventArgs e)
        {
            Searching s = new Searching();
            s.searched = Program.Dogovor.dataGridDogovor;
            s.ShowDialog();
        }
    }
}
