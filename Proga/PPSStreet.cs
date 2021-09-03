using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPSStreet : UserControl
    {
        public PPSStreet()
        {
            Program.Street = this;
            InitializeComponent();
            dataGridStreet.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 12F, FontStyle.Bold);
            dataGridStreet.DefaultCellStyle.Font = new Font("Candara", 10F);
        }
        //Запуск таймера на открытия поля для добавления данных
        private void btnAddStreet_Click(object sender, EventArgs e)
        {
            groupEditSotryd.Visible = false;
            groupAddSotryd.Visible = true;
            if (tableLayoutStreet.RowStyles[0].Height == 100 && tableLayoutStreet.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Открытие поля для добавления или редактирования данных
        private void timer1_Tick(object sender, EventArgs e)
        {
            tableLayoutStreet.RowStyles[1].Height += 17;
            tableLayoutStreet.RowStyles[0].Height -= 5;
            if (tableLayoutStreet.RowStyles[1].Height == 136 && tableLayoutStreet.RowStyles[0].Height == 60)
            {
                timer1.Stop();
            }
        }
        //Запуск таймера на открытия поля для редактирования данных
        private void btnEditStreet_Click(object sender, EventArgs e)
        {
            groupAddSotryd.Visible = false;
            groupEditSotryd.Visible = true;
            if (tableLayoutStreet.RowStyles[0].Height == 100 && tableLayoutStreet.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Запуск таймера на закрытие поля для добавления или редактирования данных
        private void Close(object sender, EventArgs e)
        {
            if (tableLayoutStreet.RowStyles[1].Height == 136 && tableLayoutStreet.RowStyles[0].Height == 60)
            {
                timer2.Start();
            }
        }
        //Удаление выбранной записи из справочника «Улицы»
        private void btnDelStreet_Click(object sender, EventArgs e)
        {
            if (dataGridStreet.Rows.Count > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridStreet.SelectedCells.Count; i++)
                    {
                        int City = DBConnection.NomCity;
                        int key_r = Convert.ToInt32(dataGridStreet.Rows[dataGridStreet.SelectedCells[i].RowIndex].Cells[0].Value);
                        string Street = dataGridStreet.Rows[dataGridStreet.SelectedCells[i].RowIndex].Cells[2].Value.ToString();
                        int log = DBConnection.DellTableStreet(key_r, Street);
                        switch (log)
                        {
                            case (1):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У города '" + DBConnection.keyValue("gorod", "s_city", "id_gorod", City.ToString()) + "' Улица '" + Street + "' успешно удалена!");
                                if (i == dataGridStreet.SelectedCells.Count - 1)
                                    RefreshTable();
                                break;
                            case (2):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У города '" + DBConnection.keyValue("gorod", "s_city", "id_gorod", City.ToString()) + "' Улицу '" + Street + "' удалить не удалось!");
                                break;
                            case (3):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У города '" + DBConnection.keyValue("gorod", "s_city", "id_gorod", City.ToString()) + "' Улица '" + Street + "' имеет связь с таблицей 'Абоненты', удаление '" + Street + "' невозможно!");
                                break;
                            case (4):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У города '" + DBConnection.keyValue("gorod", "s_city", "id_gorod", City.ToString()) + "' Улица '" + Street + "' имеет связь с таблицей 'Сотрудники', удаление '" + Street + "' невозможно!");
                                break;
                            case (5):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У города '" + DBConnection.keyValue("gorod", "s_city", "id_gorod", City.ToString()) + "' Улица '" + Street + "' имеет связь с таблицей 'Поставщики', удаление '" + Street + "' невозможно!");
                                break;
                        }
                        MessageBox.Show(dataGridStreet.SelectedCells.Count.ToString());
                    }
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "В таблице нет записей, удаление невозможно!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Закрытие формы
        private void btnHideStreet_Click(object sender, EventArgs e)
        {
            if (Program.CityStreet.tableLayoutPanel1.ColumnStyles[0].Width > 0)
                Program.CityStreet.tableLayoutPanel1.ColumnStyles[1].Width = 0;
        }
        //Закрытие поля для добавления или редактирования данных
        private void timer2_Tick(object sender, EventArgs e)
        {
            tableLayoutStreet.RowStyles[1].Height -= 17;
            tableLayoutStreet.RowStyles[0].Height += 5;
            if (tableLayoutStreet.RowStyles[1].Height == 0 || tableLayoutStreet.RowStyles[0].Height == 100)
            {
                timer2.Stop();
            }
        }
        //Добавление данных в справочник «Улицы»
        private void addStreet_Click(object sender, EventArgs e)
        {
            int City = DBConnection.NomCity;
            if (!String.IsNullOrEmpty(textAddStreet.Text))
            {
                int log = DBConnection.AddTableStreet(textAddStreet.Text, City);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У города '" + DBConnection.keyValue("gorod", "s_city", "id_gorod", City.ToString()) + "' Улица '" + textAddStreet.Text + "' была успешно добавлена!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У города '" + DBConnection.keyValue("gorod", "s_city", "id_gorod", City.ToString()) + "' Улицу '" + textAddStreet.Text + "' добавить не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У города '" + DBConnection.keyValue("gorod", "s_city", "id_gorod", City.ToString()) + "' Улица '" + textAddStreet.Text + "' уже существует, добавление '" + textAddStreet.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Редактирование данных в справочнике «Улицы»
        private void editStreet_Click(object sender, EventArgs e)
        {
            int key_r = Convert.ToInt32(dataGridStreet.CurrentRow.Cells[0].Value);
            int City = DBConnection.NomCity;
            string street = dataGridStreet.CurrentRow.Cells[2].Value.ToString();
            if (!String.IsNullOrEmpty(textEditStreet.Text))
            {
                int log = DBConnection.EditTableStreet(key_r, textEditStreet.Text, City);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У города '" + DBConnection.keyValue("gorod", "s_city", "id_gorod", City.ToString()) + "' Улица '" + street + "' была успешно обновлена на '" + textEditStreet.Text + "'!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У города '" + DBConnection.keyValue("gorod", "s_city", "id_gorod", City.ToString()) + "' Улицу '" + street + "' обновить на '" + textEditStreet.Text + "' не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У города '" + DBConnection.keyValue("gorod", "s_city", "id_gorod", City.ToString()) + "' Улица '" + textEditStreet.Text + "' уже существует, обновление '" + street + "' на '" + textEditStreet.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Отображение данных справочника «Улицы» в таблицу
        private void PPSStreet_Load(object sender, EventArgs e)
        {
            dataGridStreet.DataSource = DBConnection.s_Street;
        }
        //Обновление данных в таблице
        private void btnUpdateStreet_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
        //Метод обновления данных
        private void RefreshTable()
        {
            DBConnection.ShowTableStreet(DBConnection.NomCity);
            dataGridStreet.DataSource = DBConnection.s_Street;
        }
        //Ограничение на ввод только кириллицы
        private void textAddStreet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Ограничение на ввод только кириллицы
        private void textEditStreet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Открытие формы для поиска данных в таблице
        private void btnSearchStreet_Click(object sender, EventArgs e)
        {
            Searching s = new Searching();
            s.searched = Program.Street.dataGridStreet;
            s.ShowDialog();
        }
        //Выбор строки записей в таблице
        private void dataGridStreet_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textEditStreet.Text = dataGridStreet.CurrentRow.Cells[2].Value.ToString();
            }
        }
        //Открытие формы «Города»
        private void ShowPrev_Click(object sender, EventArgs e)
        {
            Program.CityStreet.tableLayoutPanel1.ColumnStyles[0].Width = 50;
        }
    }
}
