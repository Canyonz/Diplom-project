using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPSCity : UserControl
    {
        public PPSCity()
        {
            Program.City = this;
            InitializeComponent();
            dataGridCity.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 12F, FontStyle.Bold);
            dataGridCity.DefaultCellStyle.Font = new Font("Candara", 10F);
        }
        //Запуск таймера на открытия поля для добавления данных
        private void btnAddCity_Click(object sender, EventArgs e)
        {
            groupEditSotryd.Visible = false;
            groupAddSotryd.Visible = true;
            if (tableLayoutCity.RowStyles[0].Height == 100 && tableLayoutCity.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Открытие поля для добавления или редактирования данных
        private void timer1_Tick(object sender, EventArgs e)
        {
            tableLayoutCity.RowStyles[1].Height += 17;
            tableLayoutCity.RowStyles[0].Height -= 5;
            if (tableLayoutCity.RowStyles[1].Height >= 136 && tableLayoutCity.RowStyles[0].Height <= 60)
            {
                timer1.Stop();
            }
        }
        //Запуск таймера на открытия поля для редактирования данных
        private void btnEditCity_Click(object sender, EventArgs e)
        {

            groupAddSotryd.Visible = false;
            groupEditSotryd.Visible = true;
            if (tableLayoutCity.RowStyles[0].Height == 100 && tableLayoutCity.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Удаление выбранной записи из справочника «Города»
        private void btnDelCity_Click(object sender, EventArgs e)
        {
            if (dataGridCity.Rows.Count > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridCity.SelectedRows.Count; i++)
                    {
                        int key_r = Convert.ToInt32(dataGridCity.Rows[dataGridCity.SelectedRows[i].Index].Cells[0].Value);
                        string City = dataGridCity.Rows[dataGridCity.SelectedRows[i].Index].Cells[1].Value.ToString();
                        int log = DBConnection.DellTableCity(key_r);
                        switch (log)
                        {
                            case (1):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Город '" + City + "' успешно удалён!");
                                RefreshTable();
                                break;
                            case (2):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Город '" + City + "' удалить не удалось!");
                                break;
                            case (3):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У города '" + City + "' имеется связь с таблицей 'Улицы', удаление '" + City + "' невозможно!");
                                break;
                        }
                    }
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "В таблице нет записей, удаление невозможно!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Закрытие формы «Города»
        private void btnHideCity_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            if (Program.CityStreet.tableLayoutPanel1.ColumnStyles[1].Width > 0)
                Program.CityStreet.tableLayoutPanel1.ColumnStyles[0].Width = 0;
        }
        //Закрытие поля для добавления или редактирования данных
        private void timer2_Tick(object sender, EventArgs e)
        {
            tableLayoutCity.RowStyles[1].Height -= 17;
            tableLayoutCity.RowStyles[0].Height += 5;
            if (tableLayoutCity.RowStyles[1].Height == 0 || tableLayoutCity.RowStyles[0].Height == 100)
            {
                timer2.Stop();
            }
        }
        //Запуск таймера на закрытие поля для добавления или редактирования данных
        private void Close(object sender, EventArgs e)
        {
            if (tableLayoutCity.RowStyles[1].Height == 136 && tableLayoutCity.RowStyles[0].Height == 60)
            {
                timer2.Start();
            }
        }
        //Добавление данных в справочник «Города»
        private void addCity_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textAddCity.Text))
            {
                int log = DBConnection.AddTableCity(textAddCity.Text);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Город '" + textAddCity.Text + "' был успешно добавлен!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Город '" + textAddCity.Text + "' добавить не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Город '" + textAddCity.Text + "' уже существует, добавление '" + textAddCity.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Редактирование данных в справочнике «Города»
        private void editCity_Click(object sender, EventArgs e)
        {
            int key_r = Convert.ToInt32(dataGridCity.CurrentRow.Cells[0].Value);
            string city = dataGridCity.CurrentRow.Cells[1].Value.ToString();
            if (!String.IsNullOrEmpty(textEditCity.Text))
            {
                int log = DBConnection.EditTableCity(key_r, textEditCity.Text);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Город '" + city + "' был успешно обновлен на '" + textEditCity.Text + "'!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Город '" + city + "' обновить на '" + textEditCity.Text + "' не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Город '" + textEditCity.Text + "' уже существует, обновление '" + city + "' на '" + textEditCity.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Отображение данных справочника «Города» в таблицу
        private void PPSCity_Load(object sender, EventArgs e)
        {
            dataGridCity.DataSource = DBConnection.s_City;
        }
        //Обновление данных в таблице
        private void btnUpdateCity_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
        //Метод обновления данных
        private void RefreshTable()
        {
            DBConnection.ShowTableCity();
            dataGridCity.DataSource = DBConnection.s_City;
        }
        //Ограничение на ввод только кириллицы
        private void textAddCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Ограничение на ввод только кириллицы
        private void textEditCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Открытие формы для поиска данных в таблице
        private void btnSearchCity_Click(object sender, EventArgs e)
        {
            Searching s = new Searching();
            s.searched = Program.City.dataGridCity;
            s.ShowDialog();
        }
        //Выбор строки записей в таблице и открытие формы «Улицы»
        private void dataGridCity_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textEditCity.Text = dataGridCity.CurrentRow.Cells[1].Value.ToString();
                if (e.Button == MouseButtons.Left && e.ColumnIndex == -1)
                {
                    DBConnection.ShowTableStreet(Convert.ToInt32(dataGridCity.CurrentRow.Cells[0].Value.ToString()));
                    DBConnection.NomCity = Convert.ToInt32(dataGridCity.CurrentRow.Cells[0].Value.ToString());
                    Program.CityStreet.tableLayoutPanel1.ColumnStyles[0].Width = 50;
                    Program.CityStreet.tableLayoutPanel1.ColumnStyles[1].Width = 50;
                }
            }
        }
    }
}
