using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPTNakladnaya : UserControl
    {
        public PPTNakladnaya()
        {
            Program.Naklad = this;
            InitializeComponent();
            Connect();
            dataGridNaklad.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 12F, FontStyle.Bold);
            dataGridNaklad.DefaultCellStyle.Font = new Font("Candara", 10F);
        }
        //Метод отображения данных таблицы «Накладная» в таблицу
        public void Connect()
        {
            dataGridNaklad.DataSource = DBConnection.t_Naklad;
        }
        //Запуск таймера на открытия поля для добавления данных
        private void btnAddNaklad_Click(object sender, EventArgs e)
        {
            groupEditNaklad.Visible = false;
            groupAddNaklad.Visible = true;
            if (tableLayoutNaklad.RowStyles[0].Height == 100 && tableLayoutNaklad.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Запуск таймера на открытия поля для редактирования данных
        private void btnEditNaklad_Click(object sender, EventArgs e)
        {
            groupAddNaklad.Visible = false;
            groupEditNaklad.Visible = true;
            if (tableLayoutNaklad.RowStyles[0].Height == 100 && tableLayoutNaklad.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Открытие поля для добавления или редактирования данных
        private void timer1_Tick(object sender, EventArgs e)
        {
            tableLayoutNaklad.RowStyles[1].Height += 17;
            tableLayoutNaklad.RowStyles[0].Height -= 5;
            if (tableLayoutNaklad.RowStyles[1].Height == 136 && tableLayoutNaklad.RowStyles[0].Height == 60)
            {
                timer1.Stop();
            }
        }
        //Закрытие поля для добавления или редактирования данных
        private void timer2_Tick(object sender, EventArgs e)
        {
            tableLayoutNaklad.RowStyles[1].Height -= 17;
            tableLayoutNaklad.RowStyles[0].Height += 5;
            if (tableLayoutNaklad.RowStyles[1].Height == 0 && tableLayoutNaklad.RowStyles[0].Height == 100)
            {
                timer2.Stop();
            }
        }
        //Удаление выбранной записи из таблицы «Накладная»
        private void btnDelNaklad_Click(object sender, EventArgs e)
        {
            if (dataGridNaklad.Rows.Count > 0)
            {
                if (dataGridNaklad.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataGridNaklad.SelectedRows.Count; i++)
                        {
                            int key_r = Convert.ToInt32(dataGridNaklad.Rows[dataGridNaklad.SelectedRows[i].Index].Cells[0].Value);
                            string nom = dataGridNaklad.CurrentRow.Cells[1].Value.ToString();
                            string postav = dataGridNaklad.CurrentRow.Cells[2].Value.ToString();
                            string date = dataGridNaklad.CurrentRow.Cells[3].Value.ToString();
                            int log = DBConnection.DellTableNaklad(key_r);
                            switch (log)
                            {
                                case (1):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Накладная №: '" + nom + "' Поставщик: '" + postav + "' Дата: '" + date + "' успешно удалена!");
                                    RefreshTable();
                                    break;
                                case (2):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Накладную №: '" + nom + "' Поставщик: '" + postav + "' Дата: '" + date + "' удалить не удалось!");
                                    break;
                                case (3):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Накладная №: '" + nom + "' Поставщик: '" + postav + "' Дата: '" + date + "' связана с таблицей 'Спецификация накладной', удаление невозможно!");
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
        private void btnHideNaklad_Click(object sender, EventArgs e)
        {
            if (Program.Naklad_Spec.tableLayoutPanel1.ColumnStyles[1].Width > 0)
                Program.Naklad_Spec.tableLayoutPanel1.ColumnStyles[0].Width = 0;
        }
        //Запуск таймера на закрытие поля для добавления или редактирования данных
        private void Close(object sender, EventArgs e)
        {
            if (tableLayoutNaklad.RowStyles[1].Height == 136 && tableLayoutNaklad.RowStyles[0].Height == 60)
            {
                timer2.Start();
            }
        }
        //Добавление данных в таблицу «Накладная»
        private void addNaklad_Click(object sender, EventArgs e)
        {
            int Postav = DBConnection.keyRecord("id_postavshik", "t_postavshik", "naimpost", comboBoxAddNakladPostav.Text);
            if (!String.IsNullOrEmpty(textBoxAddNakladNaklad.Text)
                && !String.IsNullOrEmpty(Postav.ToString())
                && !String.IsNullOrEmpty(dateTimeAddNakladDate.Text))
            {
                int log = DBConnection.AddTableNaklad(textBoxAddNakladNaklad.Text, Postav, dateTimeAddNakladDate.Value);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Накладная №: '" + textBoxAddNakladNaklad.Text + "' Поставщик: '" + comboBoxAddNakladPostav.Text + "' Дата: '" + dateTimeAddNakladDate.Text + "' была успешно добавлена!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Накладную №: '" + textBoxAddNakladNaklad.Text + "' Поставщик: '" + comboBoxAddNakladPostav.Text + "' Дата: '" + dateTimeAddNakladDate.Text + "' добавить не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Накладная №: '" + textBoxAddNakladNaklad.Text + "' уже существует, добавление Накладной №: '" + textBoxAddNakladNaklad.Text + "' Поставщик: '" + comboBoxAddNakladPostav.Text + "' Дата: '" + dateTimeAddNakladDate.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Редактирование данных в таблице «Накладная»
        private void editNaklad_Click(object sender, EventArgs e)
        {
            int key_r = Convert.ToInt32(dataGridNaklad.CurrentRow.Cells[0].Value);
            int Postav = DBConnection.keyRecord("id_postavshik", "t_postavshik", "naimpost", comboBoxEditNakladPostav.Text);
            string nom = dataGridNaklad.CurrentRow.Cells[1].Value.ToString();
            string postav = dataGridNaklad.CurrentRow.Cells[2].Value.ToString();
            string date = dataGridNaklad.CurrentRow.Cells[3].Value.ToString();
            if (!String.IsNullOrEmpty(textBoxEditNakladNaklad.Text)
                && !String.IsNullOrEmpty(Postav.ToString())
                && !String.IsNullOrEmpty(dateTimeEditNakladDate.Text))
            {
                int log = DBConnection.EditTableNaklad(key_r, textBoxEditNakladNaklad.Text, Postav, dateTimeEditNakladDate.Value);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Накладная №: '" + nom + "' Поставщик: '" + postav + "' Дата: '" + date + "' была успешно обновлена на Накладную №: '" + textBoxEditNakladNaklad.Text + "' Поставщик: '" + comboBoxEditNakladPostav.Text + "' Дата: '" + dateTimeEditNakladDate.Text + "'!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Накладную №: '" + nom + "' Поставщик: '" + postav + "' Дата: '" + date + "' обновить на Накладную №: '" + textBoxEditNakladNaklad.Text + "' Поставщик: '" + comboBoxEditNakladPostav.Text + "' Дата: '" + dateTimeEditNakladDate.Text + "' не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Накладная №: '" + textBoxEditNakladNaklad.Text + "' уже существует, обновление Накладной №: '" + nom + "' Поставщик: '" + postav + "' Дата: '" + date + "' на Накладную №: '" + textBoxEditNakladNaklad.Text + "' Поставщик: '" + comboBoxEditNakladPostav.Text + "' Дата: '" + dateTimeEditNakladDate.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Отображение данных таблицы «Накладная» в таблицу
        private void PPTNaklad_Load(object sender, EventArgs e)
        {
            Connect();
            comboBoxAddNakladPostav.DataSource = DBConnection.t_Postav;
            comboBoxAddNakladPostav.DisplayMember = "naimpost";

            comboBoxEditNakladPostav.DataSource = DBConnection.t_Postav;
            comboBoxEditNakladPostav.DisplayMember = "naimpost";
        }
        //Выбор строки записей в таблице, открытие формы «Спецификация накладной»
        private void dataGridNaklad_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textBoxEditNakladNaklad.Text = dataGridNaklad.CurrentRow.Cells[1].Value.ToString();
                comboBoxEditNakladPostav.Text = dataGridNaklad.CurrentRow.Cells[2].Value.ToString();
                dateTimeEditNakladDate.Text = dataGridNaklad.CurrentRow.Cells[3].Value.ToString();
                if (e.Button == MouseButtons.Left && e.ColumnIndex == -1)
                {
                    DBConnection.ShowTableSpecNaklad(Convert.ToInt32(dataGridNaklad.CurrentRow.Cells[0].Value.ToString()));
                    DBConnection.NomNaklad = Convert.ToInt32(dataGridNaklad.CurrentRow.Cells[0].Value.ToString());
                    Program.Naklad_Spec.tableLayoutPanel1.ColumnStyles[0].Width = 50;
                    Program.Naklad_Spec.tableLayoutPanel1.ColumnStyles[1].Width = 50;
                }
            }
        }
        //При выборе заголовка столбца правой кнопкой мыши выводится список для отбора записей
        int key;
        private void dataGridNaklad_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.ColumnIndex != 0 && e.RowIndex == -1)
            {
                Filter.Items.Clear();
                switch (e.ColumnIndex)
                {
                    case (1):
                        {
                            DBConnection.ShowFilter("t_nakladnaya.numnaklad", "t_nakladnaya", "order by numnaklad desc");
                            key = 1;
                        }
                        break;
                    case (2):
                        {
                            DBConnection.ShowFilter("t_postavshik.naimpost", "t_nakladnaya, t_postavshik", "where t_nakladnaya.id_postavshik = t_postavshik.id_postavshik order by t_postavshik.naimpost");
                            key = 2;
                        }
                        break;
                    case (3):
                        {
                            DBConnection.ShowFilter("t_nakladnaya.datenakl", "t_nakladnaya", "order by datenakl desc");
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
                        DBConnection.ShowFilters("t_nakladnaya.id_nakladnaya, t_nakladnaya.numnaklad,  t_postavshik.naimpost, t_nakladnaya.datenakl",
"t_nakladnaya, t_postavshik", "where t_nakladnaya.id_postavshik = t_postavshik.id_postavshik and t_nakladnaya.numnaklad = '" + e.ClickedItem.Text + "' order by datenakl desc");
                    }
                    break;
                case (2):
                    {
                        DBConnection.ShowFilters("t_nakladnaya.id_nakladnaya, t_nakladnaya.numnaklad,  t_postavshik.naimpost, t_nakladnaya.datenakl",
"t_nakladnaya, t_postavshik", "where t_nakladnaya.id_postavshik = t_postavshik.id_postavshik and t_postavshik.naimpost = '" + e.ClickedItem.Text + "' order by datenakl desc");
                    }
                    break;
                case (3):
                    {
                        DBConnection.ShowFilters("t_nakladnaya.id_nakladnaya, t_nakladnaya.numnaklad,  t_postavshik.naimpost, t_nakladnaya.datenakl",
"t_nakladnaya, t_postavshik", "where t_nakladnaya.id_postavshik = t_postavshik.id_postavshik and t_nakladnaya.datenakl = '" + Convert.ToDateTime(e.ClickedItem.Text).ToString("yyyy.MM.dd") + "' order by datenakl desc");
                    }
                    break;
            }
            dataGridNaklad.DataSource = DBConnection.filters;
        }
        //Обновление данных в таблице
        private void btnUpdateNaklad_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
        //Метод обновления данных
        private void RefreshTable()
        {
            DBConnection.ShowTableNaklad();
            Connect();
        }
        //Поиск записей в таблице
        private void btnSearchNaklad_Click(object sender, EventArgs e)
        {
            Searching s = new Searching();
            s.searched = Program.Naklad.dataGridNaklad;
            s.ShowDialog();
        }
    }
}
