using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPOAct : UserControl
    {
        public PPOAct()
        {
            Program.Act = this;
            InitializeComponent();
            dataGridAct.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 12F, FontStyle.Bold);
            dataGridAct.DefaultCellStyle.Font = new Font("Candara", 10F);
        }
        //Метод отображения данных таблицы «Акт» в таблицу
        public void Connect()
        {
            dataGridAct.DataSource = DBConnection.o_Act;
            color();
        }
        //Рисует строку цветом статуса
        public void color()
        {
            for (int i = 0; i < dataGridAct.Rows.Count; i++)
            {
                if (dataGridAct.Rows[i].Cells[6].Value.ToString() != "")
                    dataGridAct.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(Convert.ToInt32(DBConnection.colorFromStatusE(dataGridAct.Rows[i].Cells[6].Value.ToString())));
            }
        }
        //Запуск таймера на открытия поля для добавления данных
        private void btnAddAct_Click(object sender, EventArgs e)
        {
            groupEditAct.Visible = false;
            groupAddAct.Visible = true;
            if (tableLayoutAct.RowStyles[0].Height == 100 && tableLayoutAct.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Запуск таймера на открытия поля для редактирования данных
        private void btnEditAct_Click(object sender, EventArgs e)
        {
            groupAddAct.Visible = false;
            groupEditAct.Visible = true;
            if (tableLayoutAct.RowStyles[0].Height == 100 && tableLayoutAct.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Открытие поля для добавления или редактирования данных
        private void timer1_Tick(object sender, EventArgs e)
        {
            tableLayoutAct.RowStyles[1].Height += 17;
            tableLayoutAct.RowStyles[0].Height -= 5;
            if (tableLayoutAct.RowStyles[1].Height == 136 && tableLayoutAct.RowStyles[0].Height == 60)
            {
                timer1.Stop();
            }
        }
        //Закрытие поля для добавления или редактирования данных
        private void timer2_Tick(object sender, EventArgs e)
        {
            tableLayoutAct.RowStyles[1].Height -= 17;
            tableLayoutAct.RowStyles[0].Height += 5;
            if (tableLayoutAct.RowStyles[1].Height == 0 && tableLayoutAct.RowStyles[0].Height == 100)
            {
                timer2.Stop();
            }
        }
        //Удаление выбранной записи из таблицы «Акт»
        private void btnDelAct_Click(object sender, EventArgs e)
        {
            if (dataGridAct.Rows.Count > 0)
            {
                if (dataGridAct.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataGridAct.SelectedRows.Count; i++)
                        {
                            int key_r = Convert.ToInt32(dataGridAct.Rows[dataGridAct.SelectedRows[i].Index].Cells[0].Value);
                            int nomdogovor = DBConnection.NomDogovor;
                            string nomact = dataGridAct.CurrentRow.Cells[2].Value.ToString();
                            string naznach = dataGridAct.CurrentRow.Cells[3].Value.ToString();
                            string type = dataGridAct.CurrentRow.Cells[4].Value.ToString();
                            string sotryd = dataGridAct.CurrentRow.Cells[5].Value.ToString();
                            string arenda = dataGridAct.CurrentRow.Cells[8].Value.ToString();
                            string date = dataGridAct.CurrentRow.Cells[9].Value.ToString();
                            int log = DBConnection.DellTableAct(key_r);
                            switch (log)
                            {
                                case (1):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У договора № '" + DBConnection.keyValue("nomdogovor", "t_dogovor", "id_dogovor", nomdogovor.ToString()) + "' Акт №: '" + nomact + "' на '" + naznach +' '+type+"' Сотрудник: '" + sotryd + "' Аренда: '" + arenda + "'мес. Дата: '" + date + "' успешно удален!");
                                    ColDog(nomdogovor);
                                    RefreshTable();
                                    break;
                                case (2):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У договора № '" + DBConnection.keyValue("nomdogovor", "t_dogovor", "id_dogovor", nomdogovor.ToString()) + "' Акт №: '" + nomact + "' на '" + naznach + ' ' + type + "' Сотрудник: '" + sotryd + "' Аренда: '" + arenda + "'мес. Дата: '" + date + "' удалить не удалось!");
                                    break;
                                case (3):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У договора № '" + DBConnection.keyValue("nomdogovor", "t_dogovor", "id_dogovor", nomdogovor.ToString()) + "' Акт №: '" + nomact + "' на '" + naznach + ' ' + type + "' Сотрудник: '" + sotryd + "' Аренда: '" + arenda + "'мес. Дата: '" + date + "' связан с таблицей 'Спецификация акта', удаление невозможно!");
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
        private void btnHideAct_Click(object sender, EventArgs e)
        {
            if (Program.Dogovors.tableLayoutPanel1.ColumnStyles[0].Width > 0 || Program.Dogovors.tableLayoutPanel1.ColumnStyles[2].Width > 0)
            {
                Program.Dogovors.tableLayoutPanel1.ColumnStyles[1].Width = 0;
            }
        }
        //Запуск таймера на закрытие поля для добавления или редактирования данных
        private void Close(object sender, EventArgs e)
        {
            if (tableLayoutAct.RowStyles[1].Height == 136 && tableLayoutAct.RowStyles[0].Height == 60)
            {
                timer2.Start();
            }
        }
        //Открытие формы «Договора»
        private void OpenPrew_Click(object sender, EventArgs e)
        {
            Program.Dogovors.tableLayoutPanel1.ColumnStyles[0].Width = 50;
            Program.Dogovors.tableLayoutPanel1.ColumnStyles[2].Width = 0;
        }
        //Добавление данных в таблицу «Договора»
        private void addAct_Click(object sender, EventArgs e)
        {
            int Dogovor = DBConnection.NomDogovor;
            int Naznach = Convert.ToInt32(DBConnection.s_naznach.Rows[comboBoxAddActNaznach.SelectedIndex].ItemArray.GetValue(0));
            int TypeAct = Convert.ToInt32(DBConnection.s_TypeAct.Rows[comboBoxAddActTypeAct.SelectedIndex].ItemArray.GetValue(0));
            int Sotryd = Convert.ToInt32(DBConnection.t_Sotryd.Rows[comboBoxAddActSotryd.SelectedIndex].ItemArray.GetValue(0));
            int Arenda = Convert.ToInt32(textBoxAddActArenda.Text);
            if (!String.IsNullOrEmpty(textBoxAddActNomAct.Text)
                && !String.IsNullOrEmpty(Dogovor.ToString())
                && !String.IsNullOrEmpty(Naznach.ToString())
                && !String.IsNullOrEmpty(TypeAct.ToString())
                && !String.IsNullOrEmpty(Sotryd.ToString())
                && !String.IsNullOrEmpty(Arenda.ToString())
                && !String.IsNullOrEmpty(dateTimeAddActDate.Text))
            {
                int log = 0;
                if (comboBoxAddActNaznach.SelectedIndex == 0 && (comboBoxAddActTypeAct.SelectedIndex == 0 || comboBoxAddActTypeAct.SelectedIndex == 1))
                {
                    if(!String.IsNullOrEmpty(comboBoxAddActNomAct.Text))
                        log = DBConnection.AddTableAct1(textBoxAddActNomAct.Text, Dogovor, Naznach, TypeAct, Sotryd, 3, Arenda, dateTimeAddActDate.Value);
                    else
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
                }
                else
                    log = DBConnection.AddTableAct(textBoxAddActNomAct.Text, Dogovor, Naznach, TypeAct, Sotryd, 3, Arenda, dateTimeAddActDate.Value);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У договора № '" + DBConnection.keyValue("nomdogovor", "t_dogovor", "id_dogovor", nomdogovor.ToString()) + "' Акт №: '" + textBoxAddActNomAct.Text + "' на '" + comboBoxAddActNaznach.Text + ' ' + comboBoxAddActTypeAct.Text + "' Сотрудник: '" + comboBoxAddActSotryd.Text + "' Аренда: '" + textBoxAddActArenda.Text + "'мес. Дата: '" + dateTimeAddActDate.Text + "' был успешно добавлен!");
                        ColDog(Dogovor);
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У договора № '" + DBConnection.keyValue("nomdogovor", "t_dogovor", "id_dogovor", nomdogovor.ToString()) + "' Акт №: '" + textBoxAddActNomAct.Text + "' на '" + comboBoxAddActNaznach.Text + ' ' + comboBoxAddActTypeAct.Text + "' Сотрудник: '" + comboBoxAddActSotryd.Text + "' Аренда: '" + textBoxAddActArenda.Text + "'мес. Дата: '" + dateTimeAddActDate.Text + "' добавить не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У договора № '" + DBConnection.keyValue("nomdogovor", "t_dogovor", "id_dogovor", nomdogovor.ToString()) + "' Акт №: '" + textBoxAddActNomAct.Text + "' уже существует, добавление Акта №: '" + textBoxAddActNomAct.Text + "' на '" + comboBoxAddActNaznach.Text + ' ' + comboBoxAddActTypeAct.Text + "' Сотрудник: '" + comboBoxAddActSotryd.Text + "' Аренда: '" + textBoxAddActArenda.Text + "'мес. Дата: '" + dateTimeAddActDate.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Редактирование данных в таблице «Договора»
        private void editAct_Click(object sender, EventArgs e)
        {
            int key_r = Convert.ToInt32(dataGridAct.CurrentRow.Cells[0].Value);
            int Dogovor = DBConnection.NomDogovor;
            int Naznach = Convert.ToInt32(DBConnection.s_naznach.Rows[comboBoxEditActNaznach.SelectedIndex].ItemArray.GetValue(0));
            int TypeAct = Convert.ToInt32(DBConnection.s_TypeAct.Rows[comboBoxEditActTypeAct.SelectedIndex].ItemArray.GetValue(0));
            int Sotryd = Convert.ToInt32(DBConnection.t_Sotryd.Rows[comboBoxEditActSotryd.SelectedIndex].ItemArray.GetValue(0));
            int Arenda = 0;
            string nomact = dataGridAct.CurrentRow.Cells[2].Value.ToString();
            string naznach = dataGridAct.CurrentRow.Cells[3].Value.ToString();
            string type = dataGridAct.CurrentRow.Cells[4].Value.ToString();
            string sotryd = dataGridAct.CurrentRow.Cells[5].Value.ToString();
            string arenda = dataGridAct.CurrentRow.Cells[8].Value.ToString();
            string date = dataGridAct.CurrentRow.Cells[9].Value.ToString();
            if (!String.IsNullOrEmpty(textBoxEditActNomAct.Text)
                && !String.IsNullOrEmpty(Naznach.ToString())
                && !String.IsNullOrEmpty(TypeAct.ToString())
                && !String.IsNullOrEmpty(Sotryd.ToString())
                && !String.IsNullOrEmpty(dateTimeEditActDate.Text))
            {
                int log = 0;
                if (!String.IsNullOrEmpty(textBoxEditActArenda.Text))
                    Arenda = Convert.ToInt32(textBoxEditActArenda.Text);
                if (comboBoxAddActNaznach.SelectedIndex == 0 && (comboBoxAddActTypeAct.SelectedIndex == 0 || comboBoxAddActTypeAct.SelectedIndex == 1))
                {
                    if (!String.IsNullOrEmpty(comboBoxAddActNomAct.Text))
                        log = DBConnection.EditTableAct1(key_r, textBoxEditActNomAct.Text, Dogovor, Naznach, TypeAct, Sotryd, Arenda, dateTimeEditActDate.Value);
                    else
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
                }
                else
                    log = DBConnection.EditTableAct(key_r, textBoxEditActNomAct.Text, Dogovor, Naznach, TypeAct, Sotryd, Arenda, dateTimeEditActDate.Value);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У договора № '" + DBConnection.keyValue("nomdogovor", "t_dogovor", "id_dogovor", nomdogovor.ToString()) + "' Акт №: '" + nomact + "' на '" + naznach + ' ' + type + "' Сотрудник: '" + sotryd + "' Аренда: '" + arenda + "'мес. Дата: '" + date + "' был успешно обновлен на Акт №: '" + textBoxEditActNomAct.Text + "' на '" + comboBoxEditActNaznach.Text + ' ' + comboBoxEditActTypeAct.Text + "' Сотрудник: '" + comboBoxEditActSotryd.Text + "' Аренда: '" + textBoxEditActArenda.Text + "'мес. Дата: '" + dateTimeEditActDate.Text + "'!");
                        DBConnection.ShowTableSpecAct(key_r);
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У договора № '" + DBConnection.keyValue("nomdogovor", "t_dogovor", "id_dogovor", nomdogovor.ToString()) + "' Акт №: '" + nomact + "' на '" + naznach + ' ' + type + "' Сотрудник: '" + sotryd + "' Аренда: '" + arenda + "'мес. Дата: '" + date + "' обновить на Акт №: '" + textBoxEditActNomAct.Text + "' на '" + comboBoxEditActNaznach.Text + ' ' + comboBoxEditActTypeAct.Text + "' Сотрудник: '" + comboBoxEditActSotryd.Text + "' Аренда: '" + textBoxEditActArenda.Text + "'мес. Дата: '" + dateTimeEditActDate.Text + "' не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У договора № '" + DBConnection.keyValue("nomdogovor", "t_dogovor", "id_dogovor", nomdogovor.ToString()) + "' Акт №: '" + nomact + "' уже существует, обновление Акт №: '" + nomact + "' на '" + naznach + ' ' + type + "' Сотрудник: '" + sotryd + "' Аренда: '" + arenda + "'мес. Дата: '" + date + "' на Акт №: '" + textBoxEditActNomAct.Text + "' на '" + comboBoxEditActNaznach.Text + ' ' + comboBoxEditActTypeAct.Text + "' Сотрудник: '" + comboBoxEditActSotryd.Text + "' Аренда: '" + textBoxEditActArenda.Text + "'мес. Дата: '" + dateTimeEditActDate.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Отображение данных таблицы «Акт» в таблицу
        private void PPTAct_Load(object sender, EventArgs e)
        {
            comboBoxAddActNomDogovor.DataSource = DBConnection.o_Dogovor;
            comboBoxAddActNomDogovor.DisplayMember = "nomdogovor";
            comboBoxAddActNaznach.DataSource = DBConnection.s_naznach;
            comboBoxAddActNaznach.DisplayMember = "naznach";
            comboBoxAddActTypeAct.DataSource = DBConnection.s_TypeAct;
            comboBoxAddActTypeAct.DisplayMember = "typeact";
            comboBoxAddActSotryd.DataSource = DBConnection.t_Sotryd;
            comboBoxAddActSotryd.DisplayMember = "fiosotryd";

            comboBoxEditActNomDogovor.DataSource = DBConnection.o_Dogovor;
            comboBoxEditActNomDogovor.DisplayMember = "nomdogovor";
            comboBoxEditActNaznach.DataSource = DBConnection.s_naznach;
            comboBoxEditActNaznach.DisplayMember = "naznach";
            comboBoxEditActTypeAct.DataSource = DBConnection.s_TypeAct;
            comboBoxEditActTypeAct.DisplayMember = "typeact";
            comboBoxEditActSotryd.DataSource = DBConnection.t_Sotryd;
            comboBoxEditActSotryd.DisplayMember = "fiosotryd";
        }
        //Настраивает видимость полей в таблице «Спецификация акта» под каждый выбор назначения и типа акта
        void specact()
        {
            if (DBConnection.keyRecord("id_naznach", "s_naznach", "naznach", dataGridAct.CurrentRow.Cells[3].Value.ToString()) == 2)
            {
                DBConnection.NomAct1 = dataGridAct.CurrentRow.Cells[2].Value.ToString();
            };
            DBConnection.Types1();
            Program.SpecAct.comboBoxAddSpecActTypeEquip.DataSource = DBConnection.Typee1;
            Program.SpecAct.comboBoxAddSpecActTypeEquip.DisplayMember = "typeequip";
            Program.SpecAct.comboBoxEditSpecActTypeEquip.DataSource = DBConnection.Typee1;
            Program.SpecAct.comboBoxEditSpecActTypeEquip.DisplayMember = "typeequip";
            Program.SpecAct.tableLayoutPanel3.ColumnStyles[1].Width = 50; Program.SpecAct.tableLayoutPanel4.ColumnStyles[1].Width = 50;
            Program.SpecAct.tableLayoutPanel3.ColumnStyles[2].Width = 50; Program.SpecAct.tableLayoutPanel4.ColumnStyles[2].Width = 50;
            Program.SpecAct.tableLayoutPanel3.ColumnStyles[3].Width = 50; Program.SpecAct.tableLayoutPanel4.ColumnStyles[3].Width = 50;
            Program.SpecAct.tableLayoutPanel3.ColumnStyles[4].Width = 50; Program.SpecAct.tableLayoutPanel4.ColumnStyles[4].Width = 50;
            Program.SpecAct.tableLayoutPanel3.ColumnStyles[5].Width = 0; Program.SpecAct.tableLayoutPanel4.ColumnStyles[5].Width = 0;
            Program.SpecAct.tableLayoutPanel3.ColumnStyles[6].Width = 0; Program.SpecAct.tableLayoutPanel4.ColumnStyles[6].Width = 0;
            Program.SpecAct.tableLayoutPanel3.ColumnStyles[7].Width = 0; Program.SpecAct.tableLayoutPanel4.ColumnStyles[7].Width = 0;
        }
        //открытие формы «Спецификация акта»
        private void dataGridAct_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                comboBoxEditActNomDogovor.Text = dataGridAct.CurrentRow.Cells[1].Value.ToString();
                textBoxEditActNomAct.Text = dataGridAct.CurrentRow.Cells[2].Value.ToString();
                comboBoxEditActNaznach.Text = dataGridAct.CurrentRow.Cells[3].Value.ToString();
                comboBoxEditActTypeAct.Text = dataGridAct.CurrentRow.Cells[4].Value.ToString();
                comboBoxEditActSotryd.Text = dataGridAct.CurrentRow.Cells[5].Value.ToString();
                textBoxEditActArenda.Text = dataGridAct.CurrentRow.Cells[8].Value.ToString();
                dateTimeEditActDate.Text = dataGridAct.CurrentRow.Cells[9].Value.ToString();

                switch (DBConnection.keyRecord("id_typeact", "s_typeact", "typeact", dataGridAct.CurrentRow.Cells[4].Value.ToString()))
                {
                    case (1):
                    case (2):
                        if (DBConnection.keyRecord("id_naznach", "s_naznach", "naznach", dataGridAct.CurrentRow.Cells[3].Value.ToString()) == 2)
                        {
                            tableLayoutPanel4.ColumnStyles[1].Width = 0;
                            tableLayoutPanel4.ColumnStyles[4].Width = 20;
                            tableLayoutPanel3.ColumnStyles[1].Width = 0;
                            tableLayoutPanel3.ColumnStyles[4].Width = 20;
                            DBConnection.NomNaznach = 1;
                        }
                        else
                        {
                            tableLayoutPanel4.ColumnStyles[1].Width = 20;
                            tableLayoutPanel4.ColumnStyles[4].Width = 0;
                            tableLayoutPanel3.ColumnStyles[1].Width = 20;
                            tableLayoutPanel3.ColumnStyles[4].Width = 0;
                            DBConnection.NomNaznach = 0;
                        }
                        break;
                }
                if (e.Button == MouseButtons.Left && e.ColumnIndex == -1)
                {
                    DBConnection.NomAct = Convert.ToInt32(dataGridAct.CurrentRow.Cells[0].Value.ToString());
                    DBConnection.ShowTableSpecAct(Convert.ToInt32(dataGridAct.CurrentRow.Cells[0].Value.ToString()));
                    Program.SpecAct.dataGridSpecAct.DataSource = DBConnection.o_SpecAct;
                    switch (DBConnection.keyRecord("id_typeact", "s_typeact", "typeact", dataGridAct.CurrentRow.Cells[4].Value.ToString()))
                    {
                        case (1):
                            DBConnection.NomTypeAct = 1;
                            Program.SpecAct.dataGridSpecAct.Columns[4].Visible = true;
                            Program.SpecAct.dataGridSpecAct.Columns[5].Visible = true;
                            Program.SpecAct.dataGridSpecAct.Columns[8].Visible = false;
                            Program.SpecAct.dataGridSpecAct.Columns[9].Visible = false;
                                Program.SpecAct.dataGridSpecAct.Columns[10].Visible = false;
                            specact();
                            break;
                        case (2):
                            DBConnection.NomTypeAct = 2;
                            Program.SpecAct.dataGridSpecAct.Columns[4].Visible = true;
                            Program.SpecAct.dataGridSpecAct.Columns[5].Visible = true;
                            Program.SpecAct.dataGridSpecAct.Columns[8].Visible = true;
                            Program.SpecAct.dataGridSpecAct.Columns[9].Visible = false;
                                Program.SpecAct.dataGridSpecAct.Columns[10].Visible = false;
                            specact();
                            break;
                        case (3):
                            DBConnection.NomTypeAct = 3; 
                            if (DBConnection.keyRecord("id_naznach", "s_naznach", "naznach", dataGridAct.CurrentRow.Cells[3].Value.ToString()) == 2)
                            {
                                DBConnection.NomNaznach = 1;
                                DBConnection.NomAct1 = dataGridAct.CurrentRow.Cells[2].Value.ToString();
                                Program.SpecAct.dataGridSpecAct.Columns[4].Visible = false;
                                Program.SpecAct.dataGridSpecAct.Columns[5].Visible = false;
                                Program.SpecAct.dataGridSpecAct.Columns[8].Visible = false;
                                Program.SpecAct.dataGridSpecAct.Columns[9].Visible = false;
                                Program.SpecAct.dataGridSpecAct.Columns[10].Visible = true;
                            }
                            else
                            {
                                DBConnection.NomNaznach = 0;
                                Program.SpecAct.dataGridSpecAct.Columns[4].Visible = false;
                                Program.SpecAct.dataGridSpecAct.Columns[5].Visible = false;
                                Program.SpecAct.dataGridSpecAct.Columns[8].Visible = false;
                                Program.SpecAct.dataGridSpecAct.Columns[9].Visible = true;
                                Program.SpecAct.dataGridSpecAct.Columns[10].Visible = true;
                            }
                            Program.SpecAct.tableLayoutPanel3.ColumnStyles[1].Width = 50; Program.SpecAct.tableLayoutPanel4.ColumnStyles[1].Width = 50;
                            Program.SpecAct.tableLayoutPanel3.ColumnStyles[2].Width = 50; Program.SpecAct.tableLayoutPanel4.ColumnStyles[2].Width = 50;
                            Program.SpecAct.tableLayoutPanel3.ColumnStyles[3].Width = 0; Program.SpecAct.tableLayoutPanel4.ColumnStyles[3].Width = 0;
                            Program.SpecAct.tableLayoutPanel3.ColumnStyles[4].Width = 0; Program.SpecAct.tableLayoutPanel4.ColumnStyles[4].Width = 0;
                            Program.SpecAct.tableLayoutPanel3.ColumnStyles[5].Width = 50; Program.SpecAct.tableLayoutPanel4.ColumnStyles[5].Width = 50;
                            Program.SpecAct.tableLayoutPanel3.ColumnStyles[6].Width = 50; Program.SpecAct.tableLayoutPanel4.ColumnStyles[6].Width = 50;
                            Program.SpecAct.tableLayoutPanel3.ColumnStyles[7].Width = 50; Program.SpecAct.tableLayoutPanel4.ColumnStyles[7].Width = 50;
                            DBConnection.Types1();
                            Program.SpecAct.comboBoxAddSpecActTypeEquip.DataSource = DBConnection.Typee1;
                            Program.SpecAct.comboBoxAddSpecActTypeEquip.DisplayMember = "typeequip";
                            Program.SpecAct.comboBoxEditSpecActTypeEquip.DataSource = DBConnection.Typee1;
                            Program.SpecAct.comboBoxEditSpecActTypeEquip.DisplayMember = "typeequip";
                            break;
                        case (4):
                            DBConnection.NomTypeAct = 4;
                            if (DBConnection.keyRecord("id_naznach", "s_naznach", "naznach", dataGridAct.CurrentRow.Cells[3].Value.ToString()) == 2)
                            {
                                DBConnection.NomNaznach = 1;
                                DBConnection.NomAct1 = dataGridAct.CurrentRow.Cells[2].Value.ToString();
                                Program.SpecAct.dataGridSpecAct.Columns[4].Visible = false;
                                Program.SpecAct.dataGridSpecAct.Columns[5].Visible = false;
                                Program.SpecAct.dataGridSpecAct.Columns[8].Visible = false;
                                Program.SpecAct.dataGridSpecAct.Columns[9].Visible = false;
                                Program.SpecAct.dataGridSpecAct.Columns[10].Visible = true;
                            }
                            else
                            {
                                DBConnection.NomNaznach = 0;
                                Program.SpecAct.dataGridSpecAct.Columns[4].Visible = false;
                                Program.SpecAct.dataGridSpecAct.Columns[5].Visible = true;
                                Program.SpecAct.dataGridSpecAct.Columns[8].Visible = false;
                                Program.SpecAct.dataGridSpecAct.Columns[9].Visible = true;
                                Program.SpecAct.dataGridSpecAct.Columns[10].Visible = true;
                            }
                            Program.SpecAct.tableLayoutPanel3.ColumnStyles[1].Width = 50; Program.SpecAct.tableLayoutPanel4.ColumnStyles[1].Width = 50;
                            Program.SpecAct.tableLayoutPanel3.ColumnStyles[2].Width = 50; Program.SpecAct.tableLayoutPanel4.ColumnStyles[2].Width = 50;
                            Program.SpecAct.tableLayoutPanel3.ColumnStyles[3].Width = 0; Program.SpecAct.tableLayoutPanel4.ColumnStyles[3].Width = 0;
                            Program.SpecAct.tableLayoutPanel3.ColumnStyles[4].Width = 0; Program.SpecAct.tableLayoutPanel4.ColumnStyles[4].Width = 0;
                            Program.SpecAct.tableLayoutPanel3.ColumnStyles[5].Width = 50; Program.SpecAct.tableLayoutPanel4.ColumnStyles[5].Width = 50;
                            Program.SpecAct.tableLayoutPanel3.ColumnStyles[6].Width = 50; Program.SpecAct.tableLayoutPanel4.ColumnStyles[6].Width = 50;
                            Program.SpecAct.tableLayoutPanel3.ColumnStyles[7].Width = 50; Program.SpecAct.tableLayoutPanel4.ColumnStyles[7].Width = 50;
                            DBConnection.Types1();
                            Program.SpecAct.comboBoxAddSpecActTypeEquip.DataSource = DBConnection.Typee1;
                            Program.SpecAct.comboBoxAddSpecActTypeEquip.DisplayMember = "typeequip";
                            Program.SpecAct.comboBoxEditSpecActTypeEquip.DataSource = DBConnection.Typee1;
                            Program.SpecAct.comboBoxEditSpecActTypeEquip.DisplayMember = "typeequip";
                            break;
                    }
                    DBConnection.Types1();
                    Program.SpecAct.comboBoxAddSpecActTypeEquip.DataSource = DBConnection.Typee1;
                    Program.SpecAct.comboBoxAddSpecActTypeEquip.DisplayMember = "typeequip";
                    Program.SpecAct.comboBoxEditSpecActTypeEquip.DataSource = DBConnection.Typee1;
                    Program.SpecAct.comboBoxEditSpecActTypeEquip.DisplayMember = "typeequip";
                    Program.Dogovors.tableLayoutPanel1.ColumnStyles[0].Width = 0;
                    Program.Dogovors.tableLayoutPanel1.ColumnStyles[1].Width = 50;
                    Program.Dogovors.tableLayoutPanel1.ColumnStyles[2].Width = 50;
                }
                else
            if (e.Button == MouseButtons.Right)
                {
                    dataGridAct.CurrentCell = dataGridAct.Rows[e.RowIndex].Cells[2];
                    ColorStatus.Items.Clear();
                    int j = 0;
                    for (int i = 0; i < DBConnection.t_StatusAD.Rows.Count; i++)
                    {
                        if ((!String.IsNullOrEmpty(DBConnection.t_StatusAD.Rows[i].ItemArray.GetValue(1).ToString())
                            || !String.IsNullOrEmpty(DBConnection.t_StatusAD.Rows[i].ItemArray.GetValue(2).ToString())) && i != 1)
                        {
                            ColorStatus.Items.Add(new ToolStripMenuItem(DBConnection.t_StatusAD.Rows[i].ItemArray.GetValue(1).ToString()));
                            ColorStatus.Items[j].BackColor = Color.FromArgb(Convert.ToInt32(DBConnection.t_StatusAD.Rows[i].ItemArray.GetValue(2).ToString()));
                            j++;
                        }
                    }
                    ColorStatus.Show(MousePosition, ToolStripDropDownDirection.BelowRight);
                }
            }
        }
        //Редактирует статус договора
        void ColDog(int id_dogovor)
        {
            if (DBConnection.countZavAct(id_dogovor, 1) == true)
            {
                DBConnection.edit("Update t_dogovor set id_statusad = '" + DBConnection.t_StatusAD.Rows[0].ItemArray.GetValue(0).ToString() + "' where id_dogovor = '" + id_dogovor + "'");
            }
            else
            {
                DBConnection.edit("Update t_dogovor set id_statusad = '" + DBConnection.t_StatusAD.Rows[1].ItemArray.GetValue(0).ToString() + "' where id_dogovor = '" + id_dogovor + "'");
            }
        }
        //Редактирует статус акта
        private void ColorStatus_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int key_r = Convert.ToInt32(dataGridAct.CurrentRow.Cells[0].Value);
            dataGridAct.CurrentRow.DefaultCellStyle.BackColor = e.ClickedItem.BackColor;
            int status = DBConnection.keyRecord("id_statusad", "s_statusad", "statusad", e.ClickedItem.Text);
            DBConnection.editColorAct(key_r, status);
            ColDog(DBConnection.NomDogovor);
            RefreshTable();
        }
        //При нажатии на кнопку отбора по статусу выводится список для отбора записей
        int key;
        private void FilterStatus_Click(object sender, EventArgs e)
        {
            Filter.Items.Clear();
            DBConnection.ShowFilter("s_statusad.statusad,s_statusad.colorstatusad ", "rostelecom4.t_akt,rostelecom4.s_statusad", "where t_akt.id_statusad = s_statusad.id_statusad and t_akt.id_dogovor = '" + DBConnection.NomDogovor + "'");
            key = 6;
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
                    case (2):
                        {
                            DBConnection.ShowFilter("t_akt.nomact", "rostelecom4.t_akt", "where t_akt.id_dogovor = '" + DBConnection.NomDogovor + "'");
                            key = 2;
                        }
                        break;
                    case (3):
                        {
                            DBConnection.ShowFilter("s_naznach.naznach", "rostelecom4.t_akt,rostelecom4.s_naznach", "where t_akt.id_naznach = s_naznach.id_naznach and t_akt.id_dogovor = '" + DBConnection.NomDogovor + "'");
                            key = 3;
                        }
                        break;
                    case (4):
                        {
                            DBConnection.ShowFilter("s_typeact.typeact", "rostelecom4.t_akt,rostelecom4.s_typeact", "where t_akt.id_typeact = s_typeact.id_typeact and t_akt.id_dogovor = '" + DBConnection.NomDogovor + "'");
                            key = 4;
                        }
                        break;
                    case (5):
                        {
                            DBConnection.ShowFilter("authorization.fiosotryd", "rostelecom4.t_akt, rostelecom4.authorization", "where t_akt.id_sotryd = authorization.id_sotryd and t_akt.id_dogovor = '" + DBConnection.NomDogovor + "'");
                            key = 5;
                        }
                        break;
                    case (7):
                        {
                            DBConnection.ShowFilter("t_akt.stoimost", "rostelecom4.t_akt", "where t_akt.id_dogovor = '" + DBConnection.NomDogovor + "'");
                            key = 7;
                        }
                        break;
                    case (8):
                        {
                            DBConnection.ShowFilter("t_akt.arenda", "rostelecom4.t_akt", "where t_akt.id_dogovor = '" + DBConnection.NomDogovor + "'");
                            key = 8;
                        }
                        break;
                    case (9):
                        {
                            DBConnection.ShowFilter("t_akt.date", "rostelecom4.t_akt", "where t_akt.id_dogovor = '" + DBConnection.NomDogovor + "' order by date desc");
                            key = 9;
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
                case (2):
                    {
                        DBConnection.ShowFilters("t_akt.id_akt, t_dogovor.nomdogovor,t_akt.nomact,s_naznach.naznach,s_typeact.typeact, authorization.fiosotryd, s_statusad.statusad,t_akt.stoimost,t_akt.arenda,t_akt.date ",
"rostelecom4.t_dogovor, rostelecom4.t_akt, rostelecom4.authorization, rostelecom4.s_statusad, rostelecom4.s_naznach, rostelecom4.s_typeact ",
"where t_akt.id_dogovor = t_dogovor.id_dogovor and t_akt.id_sotryd = authorization.id_sotryd and t_akt.id_statusad = s_statusad.id_statusad and t_akt.id_naznach = s_naznach.id_naznach and t_akt.id_typeact = s_typeact.id_typeact and t_akt.id_dogovor = '" + DBConnection.NomDogovor + "' and t_akt.nomact = '" + e.ClickedItem.Text + "'");
                    }
                    break;
                case (3):
                    {
                        DBConnection.ShowFilters("t_akt.id_akt, t_dogovor.nomdogovor,t_akt.nomact,s_naznach.naznach,s_typeact.typeact, authorization.fiosotryd, s_statusad.statusad,t_akt.stoimost,t_akt.arenda,t_akt.date",
        "rostelecom4.t_dogovor, rostelecom4.t_akt, rostelecom4.authorization, rostelecom4.s_statusad, rostelecom4.s_naznach, rostelecom4.s_typeact",
        "where t_akt.id_dogovor = t_dogovor.id_dogovor and t_akt.id_sotryd = authorization.id_sotryd and t_akt.id_statusad = s_statusad.id_statusad and t_akt.id_naznach = s_naznach.id_naznach and t_akt.id_typeact = s_typeact.id_typeact and t_akt.id_dogovor = '" + DBConnection.NomDogovor + "' and s_naznach.naznach = '" + e.ClickedItem.Text + "'");
                    }
                    break;
                case (4):
                    {
                        DBConnection.ShowFilters("t_akt.id_akt, t_dogovor.nomdogovor,t_akt.nomact,s_naznach.naznach,s_typeact.typeact, authorization.fiosotryd, s_statusad.statusad,t_akt.stoimost,t_akt.arenda,t_akt.date",
        "rostelecom4.t_dogovor, rostelecom4.t_akt, rostelecom4.authorization, rostelecom4.s_statusad, rostelecom4.s_naznach, rostelecom4.s_typeact",
        "where t_akt.id_dogovor = t_dogovor.id_dogovor and t_akt.id_sotryd = authorization.id_sotryd and t_akt.id_statusad = s_statusad.id_statusad and t_akt.id_naznach = s_naznach.id_naznach and t_akt.id_typeact = s_typeact.id_typeact and t_akt.id_dogovor = '" + DBConnection.NomDogovor + "' and s_typeact.typeact = '" + e.ClickedItem.Text + "'");
                    }
                    break;
                case (5):
                    {
                        DBConnection.ShowFilters("t_akt.id_akt, t_dogovor.nomdogovor,t_akt.nomact,s_naznach.naznach,s_typeact.typeact, authorization.fiosotryd, s_statusad.statusad,t_akt.stoimost,t_akt.arenda,t_akt.date",
        "rostelecom4.t_dogovor, rostelecom4.t_akt, rostelecom4.authorization, rostelecom4.s_statusad, rostelecom4.s_naznach, rostelecom4.s_typeact",
        "where t_akt.id_dogovor = t_dogovor.id_dogovor and t_akt.id_sotryd = authorization.id_sotryd and t_akt.id_statusad = s_statusad.id_statusad and t_akt.id_naznach = s_naznach.id_naznach and t_akt.id_typeact = s_typeact.id_typeact and t_akt.id_dogovor = '" + DBConnection.NomDogovor + "' and authorization.fiosotryd = '" + e.ClickedItem.Text + "'");
                    }
                    break;
                case (6):
                    {
                        DBConnection.ShowFilters("t_akt.id_akt, t_dogovor.nomdogovor,t_akt.nomact,s_naznach.naznach,s_typeact.typeact, authorization.fiosotryd, s_statusad.statusad,t_akt.stoimost,t_akt.arenda,t_akt.date",
        "rostelecom4.t_dogovor, rostelecom4.t_akt, rostelecom4.authorization, rostelecom4.s_statusad, rostelecom4.s_naznach, rostelecom4.s_typeact",
        "where t_akt.id_dogovor = t_dogovor.id_dogovor and t_akt.id_sotryd = authorization.id_sotryd and t_akt.id_statusad = s_statusad.id_statusad and t_akt.id_naznach = s_naznach.id_naznach and t_akt.id_typeact = s_typeact.id_typeact and t_akt.id_dogovor = '" + DBConnection.NomDogovor + "' and s_statusad.statusad = '" + e.ClickedItem.Text + "'");
                    }
                    break;
                case (7):
                    {
                        DBConnection.ShowFilters("t_akt.id_akt, t_dogovor.nomdogovor,t_akt.nomact,s_naznach.naznach,s_typeact.typeact, authorization.fiosotryd, s_statusad.statusad,t_akt.stoimost,t_akt.arenda,t_akt.date",
        "rostelecom4.t_dogovor, rostelecom4.t_akt, rostelecom4.authorization, rostelecom4.s_statusad, rostelecom4.s_naznach, rostelecom4.s_typeact",
        "where t_akt.id_dogovor = t_dogovor.id_dogovor and t_akt.id_sotryd = authorization.id_sotryd and t_akt.id_statusad = s_statusad.id_statusad and t_akt.id_naznach = s_naznach.id_naznach and t_akt.id_typeact = s_typeact.id_typeact and t_akt.id_dogovor = '" + DBConnection.NomDogovor + "' and t_akt.stoimost = '" + e.ClickedItem.Text + "'");
                    }
                    break;
                case (8):
                    {
                        DBConnection.ShowFilters("t_akt.id_akt, t_dogovor.nomdogovor,t_akt.nomact,s_naznach.naznach,s_typeact.typeact, authorization.fiosotryd, s_statusad.statusad,t_akt.stoimost,t_akt.arenda,t_akt.date",
        "rostelecom4.t_dogovor, rostelecom4.t_akt, rostelecom4.authorization, rostelecom4.s_statusad, rostelecom4.s_naznach, rostelecom4.s_typeact",
        "where t_akt.id_dogovor = t_dogovor.id_dogovor and t_akt.id_sotryd = authorization.id_sotryd and t_akt.id_statusad = s_statusad.id_statusad and t_akt.id_naznach = s_naznach.id_naznach and t_akt.id_typeact = s_typeact.id_typeact and t_akt.id_dogovor = '" + DBConnection.NomDogovor + "' and t_akt.arenda = '" + e.ClickedItem.Text + "'");
                    }
                    break;
                case (9):
                    {
                        DBConnection.ShowFilters("t_akt.id_akt, t_dogovor.nomdogovor,t_akt.nomact,s_naznach.naznach,s_typeact.typeact, authorization.fiosotryd, s_statusad.statusad,t_akt.stoimost,t_akt.arenda,t_akt.date",
        "rostelecom4.t_dogovor, rostelecom4.t_akt, rostelecom4.authorization, rostelecom4.s_statusad, rostelecom4.s_naznach, rostelecom4.s_typeact",
        "where t_akt.id_dogovor = t_dogovor.id_dogovor and t_akt.id_sotryd = authorization.id_sotryd and t_akt.id_statusad = s_statusad.id_statusad and t_akt.id_naznach = s_naznach.id_naznach and t_akt.id_typeact = s_typeact.id_typeact and t_akt.id_dogovor = '" + DBConnection.NomDogovor + "' and t_akt.date = '" + Convert.ToDateTime(e.ClickedItem.Text).ToString("yyyy.MM.dd") + "'");
                    }
                    break;
            }
            dataGridAct.DataSource = DBConnection.filters;
            color();
        }
        //Обновление данных в таблице
        private void btnUpdateAct_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
        //Метод обновления данных
        private void RefreshTable()
        {
            DBConnection.ShowTableAct(DBConnection.NomDogovor);
            Connect();
            color();
        }
        //Поиск записей в таблице
        private void btnSearchAct_Click(object sender, EventArgs e)
        {
            Searching s = new Searching();
            s.searched = Program.Act.dataGridAct;
            s.ShowDialog();
        }
        //Изменение видимых полей для добавления
        private void comboBoxAddActTypeAct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAddActTypeAct.SelectedIndex == 1)
            {
                tableLayoutPanel4.ColumnStyles[5].Width = 20;
            }
            else
            {
                tableLayoutPanel4.ColumnStyles[5].Width = 0;
                textBoxAddActArenda.Text = "0";
            }
            if (comboBoxAddActNaznach.SelectedIndex == 0 && (comboBoxAddActTypeAct.SelectedIndex == 0 || comboBoxAddActTypeAct.SelectedIndex == 1))
            {
                DBConnection.nomActFromReplace(comboBoxAddActTypeAct.SelectedIndex);
                comboBoxAddActNomAct.DataSource = DBConnection.NomActReplace;
                comboBoxAddActNomAct.DisplayMember = "nomact";
                tableLayoutPanel4.ColumnStyles[4].Width = 20;
                tableLayoutPanel4.ColumnStyles[1].Width = 0;
            }
            else
            {
                tableLayoutPanel4.ColumnStyles[4].Width = 0;
                tableLayoutPanel4.ColumnStyles[1].Width = 20;
            }
            comboBoxAddActNomAct_SelectedIndexChanged(sender, e);
        }
        //Изменение видимых полей для редактирования
        private void comboBoxEditActTypeAct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEditActTypeAct.SelectedIndex == 1)
            {
                tableLayoutPanel3.ColumnStyles[5].Width = 20;
            }
            else
            {
                tableLayoutPanel3.ColumnStyles[5].Width = 0;
                textBoxEditActArenda.Text = "0";
            }
            if (comboBoxEditActNaznach.SelectedIndex == 0 && (comboBoxEditActTypeAct.SelectedIndex == 0 || comboBoxEditActTypeAct.SelectedIndex == 1))
            {
                DBConnection.nomActFromReplace(comboBoxEditActTypeAct.SelectedIndex);
                comboBoxEditActNomAct.DataSource = DBConnection.NomActReplace;
                comboBoxEditActNomAct.DisplayMember = "nomact";
                tableLayoutPanel3.ColumnStyles[4].Width = 20;
                tableLayoutPanel3.ColumnStyles[1].Width = 0;
            }
            else
            {
                tableLayoutPanel3.ColumnStyles[4].Width = 0;
                tableLayoutPanel3.ColumnStyles[1].Width = 20;
            }
                comboBoxEditActNomAct_SelectedIndexChanged(sender,e);
        }
        //Вывод отчета на предворительный просмотр
        private void Report_Click(object sender, EventArgs e)
        {
            if (dataGridAct.Rows.Count>0) 
            {
            Report report = new Report();
            report.ShowDialog();
            }else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У договора № '" + DBConnection.keyValue("nomdogovor", "t_dogovor", "id_dogovor", nomdogovor.ToString()) + "' нет созданных актов, составление отчета невозможно!");
        }
        //Изменение видимых полей для добавления
        private void comboBoxAddActNaznach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAddActTypeAct.SelectedIndex == 1)
            {
                tableLayoutPanel4.ColumnStyles[5].Width = 20;
            }
            else
            {
                tableLayoutPanel4.ColumnStyles[5].Width = 0;
                textBoxAddActArenda.Text = "0";
            }
            if (comboBoxAddActNaznach.SelectedIndex == 0 && (comboBoxAddActTypeAct.SelectedIndex == 0 || comboBoxAddActTypeAct.SelectedIndex == 1))
            {
                DBConnection.nomActFromReplace(comboBoxAddActTypeAct.SelectedIndex);
                comboBoxAddActNomAct.DataSource = DBConnection.NomActReplace;
                comboBoxAddActNomAct.DisplayMember = "nomact";
                tableLayoutPanel4.ColumnStyles[4].Width = 20;
                tableLayoutPanel4.ColumnStyles[1].Width = 0;
            }
            else
            {
                tableLayoutPanel4.ColumnStyles[4].Width = 0;
                tableLayoutPanel4.ColumnStyles[1].Width = 20;
            }
                comboBoxAddActNomAct_SelectedIndexChanged(sender,e);
        }
        //Изменение видимых полей для редактирования
        private void comboBoxEditActNaznach_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (comboBoxEditActTypeAct.SelectedIndex == 1)
            {
                tableLayoutPanel3.ColumnStyles[5].Width = 20;
            }
            else
            {
                tableLayoutPanel3.ColumnStyles[5].Width = 0;
                textBoxEditActArenda.Text = "0";
            }
            if (comboBoxEditActNaznach.SelectedIndex == 0 && (comboBoxEditActTypeAct.SelectedIndex == 0 || comboBoxEditActTypeAct.SelectedIndex == 1))
            {
                DBConnection.nomActFromReplace(comboBoxEditActTypeAct.SelectedIndex);
                comboBoxEditActNomAct.DataSource = DBConnection.NomActReplace;
                comboBoxEditActNomAct.DisplayMember = "nomact";
                tableLayoutPanel3.ColumnStyles[4].Width = 20;
                tableLayoutPanel3.ColumnStyles[1].Width = 0;
            }
            else
            {
                tableLayoutPanel3.ColumnStyles[4].Width = 0;
                tableLayoutPanel3.ColumnStyles[1].Width = 20;
            }
                comboBoxEditActNomAct_SelectedIndexChanged(sender,e);
        }
        //Выбор номеров созданных актов с возратом для редактирования
        private void comboBoxEditActNomAct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEditActNomAct.Text != "" && comboBoxEditActNaznach.SelectedIndex == 0 && (comboBoxEditActTypeAct.SelectedIndex == 0 || comboBoxEditActTypeAct.SelectedIndex == 1))
            {
                dateTimeEditActDate.Enabled = false;
                dateTimeEditActDate.Text = DBConnection.dateRecord("date", "t_akt", "nomact", comboBoxEditActNomAct.Text).ToString();
                textBoxEditActNomAct.Text = comboBoxEditActNomAct.Text; 
            }else
                dateTimeEditActDate.Enabled = true;
        }
        //Выбор номеров  созданных актов с возратом для добавления
        private void comboBoxAddActNomAct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAddActNomAct.Text != "" && comboBoxAddActNaznach.SelectedIndex == 0 && (comboBoxAddActTypeAct.SelectedIndex == 0 || comboBoxAddActTypeAct.SelectedIndex == 1))
            {
                dateTimeAddActDate.Enabled = false;
                dateTimeAddActDate.Text = DBConnection.dateRecord("date", "t_akt", "nomact", comboBoxAddActNomAct.Text).ToString();
                textBoxAddActNomAct.Text = comboBoxAddActNomAct.Text;
            }else
                dateTimeAddActDate.Enabled = true;     
        }
    }
}
