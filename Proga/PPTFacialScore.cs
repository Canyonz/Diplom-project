using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPTFacialScore : UserControl
    {
        public PPTFacialScore()
        {
            Program.FacialS = this;
            InitializeComponent();
            Connect();
            dataGridFacialS.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 12F, FontStyle.Bold);
            dataGridFacialS.DefaultCellStyle.Font = new Font("Candara", 10F);
        }
        //Метод отображения данных таблицы «Лицевой счет» в таблицу
        public void Connect()
        {
            dataGridFacialS.DataSource = DBConnection.t_FacialS;
        }
        //Запуск таймера на открытия поля для добавления данных
        private void btnAddFacialS_Click(object sender, EventArgs e)
        {
            groupEditFacialS.Visible = false;
            groupAddFacialS.Visible = true;
            if (tableLayoutFacialS.RowStyles[0].Height == 100 && tableLayoutFacialS.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Запуск таймера на открытия поля для редактирования данных
        private void btnEditFacialS_Click(object sender, EventArgs e)
        {
            groupAddFacialS.Visible = false;
            groupEditFacialS.Visible = true;
            if (tableLayoutFacialS.RowStyles[0].Height == 100 && tableLayoutFacialS.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Открытие поля для добавления или редактирования данных
        private void timer1_Tick(object sender, EventArgs e)
        {
            tableLayoutFacialS.RowStyles[1].Height += 17;
            tableLayoutFacialS.RowStyles[0].Height -= 5;
            if (tableLayoutFacialS.RowStyles[1].Height == 136 && tableLayoutFacialS.RowStyles[0].Height == 60)
            {
                timer1.Stop();
            }
        }
        //Закрытие поля для добавления или редактирования данных
        private void timer2_Tick(object sender, EventArgs e)
        {
            tableLayoutFacialS.RowStyles[1].Height -= 17;
            tableLayoutFacialS.RowStyles[0].Height += 5;
            if (tableLayoutFacialS.RowStyles[1].Height == 0 && tableLayoutFacialS.RowStyles[0].Height == 100)
            {
                timer2.Stop();
            }
        }
        //Удаление выбранной записи из таблицы «Лицевой счет»
        private void btnDelFacialS_Click(object sender, EventArgs e)
        {
            if (dataGridFacialS.Rows.Count > 0)
            {
                if (dataGridFacialS.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataGridFacialS.SelectedRows.Count; i++)
                        {
                            int Abonent = DBConnection.NomAbonent;
                            int key_r = Convert.ToInt32(dataGridFacialS.Rows[dataGridFacialS.SelectedRows[i].Index].Cells[0].Value);
                            string fs = dataGridFacialS.CurrentRow.Cells[1].Value.ToString();
                            int log = DBConnection.DellTableFacialS(key_r);
                            switch (log)
                            {
                                case (1):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У абонента "+DBConnection.keyValue("fioabonent", "t_abonent", "id_abonent", Abonent.ToString())+" Лицевой счет: '" + fs + "' успешно удален!");
                                    RefreshTable();
                                    break;
                                case (2):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У абонента " + DBConnection.keyValue("fioabonent", "t_abonent", "id_abonent", Abonent.ToString()) + " Лицевой счет: '" + fs + "' удалить не удалось!");
                                    break;
                                case (3):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У абонента " + DBConnection.keyValue("fioabonent", "t_abonent", "id_abonent", Abonent.ToString()) + " Лицевой счет: '" + fs + "' связан с таблицей 'Договора', удаление невозможно!");
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
        private void btnHideFacialS_Click(object sender, EventArgs e)
        {
            if (Program.Abonents.tableLayoutPanel1.ColumnStyles[0].Width > 0)
                Program.Abonents.tableLayoutPanel1.ColumnStyles[1].Width = 0;
        }
        //Запуск таймера на закрытие поля для добавления или редактирования данных
        private void Close(object sender, EventArgs e)
        {
            if (tableLayoutFacialS.RowStyles[1].Height == 136 && tableLayoutFacialS.RowStyles[0].Height == 60)
            {
                timer2.Start();
            }
        }
        //Открытие формы «Абоненты»
        private void ShowPrev_Click(object sender, EventArgs e)
        {
            Program.Abonents.tableLayoutPanel1.ColumnStyles[0].Width = 50;
        }
        //Добавление данных в таблицу «Лицевой счет»
        private void addFacialS_Click(object sender, EventArgs e)
        {
            int Abonent = DBConnection.NomAbonent;
            if (!String.IsNullOrEmpty(textBoxAddFacialSFS.Text)
                && !String.IsNullOrEmpty(Abonent.ToString()))
            {
                int log = DBConnection.AddTableFacialS(textBoxAddFacialSFS.Text, Abonent);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У абонента " + DBConnection.keyValue("fioabonent", "t_abonent", "id_abonent", Abonent.ToString()) + " Лицевой счет: '" + textBoxAddFacialSFS.Text + "' был успешно добавлен!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У абонента " + DBConnection.keyValue("fioabonent", "t_abonent", "id_abonent", Abonent.ToString()) + " Лицевой счет: '" + textBoxAddFacialSFS.Text + "' добавить не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Лицевой счет: '" + textBoxAddFacialSFS.Text + "' уже существует, добавление '" + textBoxAddFacialSFS.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Редактирование данных в таблице «Лицевой счет»
        private void editFacialS_Click(object sender, EventArgs e)
        {
            int Abonent = DBConnection.NomAbonent;
            int key_r = Convert.ToInt32(dataGridFacialS.CurrentRow.Cells[0].Value);
            string fs = dataGridFacialS.CurrentRow.Cells[1].Value.ToString();
            if (!String.IsNullOrEmpty(textBoxEditFacialSFS.Text))
            {
                int log = DBConnection.EditTableFacialS(key_r, textBoxEditFacialSFS.Text);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У абонента " + DBConnection.keyValue("fioabonent", "t_abonent", "id_abonent", Abonent.ToString()) + " Лицевой счет: '" + fs + "' был успешно обновлен на '" + textBoxEditFacialSFS.Text + "'!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У абонента " + DBConnection.keyValue("fioabonent", "t_abonent", "id_abonent", Abonent.ToString()) + " Лицевой счет: '" + fs + "' обновить на '" + textBoxEditFacialSFS.Text + "' не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Лицевой счет: '" + textBoxEditFacialSFS.Text + "' уже существует, обновление '" + fs + "' на '" + textBoxEditFacialSFS.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Отображение данных таблицы «Лицевой счет» в таблицу
        private void PPTFacialS_Load(object sender, EventArgs e)
        {
            Connect();
            comboBoxAddFacialSAbonent.DataSource = DBConnection.t_Abonent;
            comboBoxAddFacialSAbonent.DisplayMember = "fioabonent";

            comboBoxEditFacialSAbonent.DataSource = DBConnection.t_Abonent;
            comboBoxEditFacialSAbonent.DisplayMember = "fioabonent";
        }
        //Выбор строки записей в таблице, открытие формы «Лицевые счета»
        private void dataGridFacialS_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textBoxEditFacialSFS.Text = dataGridFacialS.CurrentRow.Cells[1].Value.ToString();
            }
        }
        //Обновление данных в таблице
        private void btnUpdateFacialS_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
        //Ограничение на ввод только цифр
        private void RefreshTable()
        {
            DBConnection.ShowTableFacialS(DBConnection.NomAbonent);
            Connect();
        }
        //Ограничение на ввод только цифр
        private void textBoxAddFacialSFacial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
                e.Handled = true;
        }
        //Ограничение на ввод только цифр
        private void textBoxEditFacialSFacial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
                e.Handled = true;
        }
        //Поиск записей в таблице
        private void btnSearchFacialS_Click(object sender, EventArgs e)
        {
            Searching s = new Searching();
            s.searched = Program.FacialS.dataGridFacialS;
            s.ShowDialog();
        }
    }
}
