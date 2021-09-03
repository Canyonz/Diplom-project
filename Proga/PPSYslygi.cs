using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPSYslygi : UserControl
    {
        public PPSYslygi()
        {
            Program.Yslygi = this;
            InitializeComponent();
            dataGridYslygi.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 12F, FontStyle.Bold);
            dataGridYslygi.DefaultCellStyle.Font = new Font("Candara", 10F);
        }
        //Запуск таймера на открытия поля для добавления данных
        private void btnAddYslygi_Click(object sender, EventArgs e)
        {
            groupEditYslygi.Visible = false;
            groupAddYslygi.Visible = true;
            if (tableLayoutYslygi.RowStyles[0].Height == 100 && tableLayoutYslygi.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Открытие поля для добавления или редактирования данных
        private void timer1_Tick(object sender, EventArgs e)
        {
            tableLayoutYslygi.RowStyles[1].Height += 17;
            tableLayoutYslygi.RowStyles[0].Height -= 5;
            if (tableLayoutYslygi.RowStyles[1].Height == 136 && tableLayoutYslygi.RowStyles[0].Height == 60)
            {
                timer1.Stop();
            }
        }
        //Закрытие поля для добавления или редактирования данных
        private void timer2_Tick(object sender, EventArgs e)
        {
            tableLayoutYslygi.RowStyles[1].Height -= 17;
            tableLayoutYslygi.RowStyles[0].Height += 5;
            if (tableLayoutYslygi.RowStyles[1].Height == 0 && tableLayoutYslygi.RowStyles[0].Height == 100)
            {
                timer2.Stop();
            }
        }
        //Запуск таймера на открытия поля для редактирования данных
        private void btnEditYslygi_Click(object sender, EventArgs e)
        {
            groupAddYslygi.Visible = false;
            groupEditYslygi.Visible = true;
            if (tableLayoutYslygi.RowStyles[0].Height == 100 && tableLayoutYslygi.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Удаление выбранной записи из справочника «Услуги»
        private void btnDelYslygi_Click(object sender, EventArgs e)
        {
            if (dataGridYslygi.Rows.Count > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridYslygi.SelectedCells.Count; i++)
                    {
                        int key_r = Convert.ToInt32(dataGridYslygi.Rows[dataGridYslygi.SelectedCells[i].RowIndex].Cells[0].Value);
                        string type = dataGridYslygi.CurrentRow.Cells[1].Value.ToString();
                        int log = DBConnection.DellTableYslygi(key_r);
                        switch (log)
                        {
                            case (1):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Услуга '" + type + "' успешно удалена!");
                                RefreshTable();
                                break;
                            case (2):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Услугу '" + type + "' удалить не удалось!");
                                break;
                            case (3):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У услуги '" + type + "' имеется связь с таблицей 'Договора', удаление невозможно!");
                                break;
                        }
                    }
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "В таблице нет записей, удаление невозможно!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Запуск таймера на закрытие поля для добавления или редактирования данных
        private void Close(object sender, EventArgs e)
        {
            if (tableLayoutYslygi.RowStyles[1].Height == 136 && tableLayoutYslygi.RowStyles[0].Height == 60)
            {
                timer2.Start();
            }
        }
        //Закрытие формы
        private void btnHideYslygi_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        //Добавление данных в справочник «Услуги»
        private void addYslygi_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textAddYslygi.Text))
            {
                int log = DBConnection.AddTableYslygi(textAddYslygi.Text);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Услуга '" + textAddYslygi.Text + "' была успешно добавлена!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Услугу '" + textAddYslygi.Text + "' добавить не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Услуга '" + textAddYslygi.Text + "' уже существует, добавление '" + textAddYslygi.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Редактирование данных в справочнике «Услуги»
        private void editYslygi_Click(object sender, EventArgs e)
        {
            int key_r = Convert.ToInt32(dataGridYslygi.CurrentRow.Cells[0].Value);
            string type = dataGridYslygi.CurrentRow.Cells[1].Value.ToString();
            if (!String.IsNullOrEmpty(textEditYslygi.Text))
            {
                int log = DBConnection.EditTableYslygi(key_r, textEditYslygi.Text);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Услуга '" + type + "' была успешно обновлена на '" + textEditYslygi.Text + "'!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Услуга '" + type + "' обновить на '" + textEditYslygi.Text + "' не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Услуга '" + textEditYslygi.Text + "' уже существует, обновление '" + type + "' на '" + textEditYslygi.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Отображение данных справочника «Услуги» в таблицу
        private void PPSYslygi_Load(object sender, EventArgs e)
        {
            dataGridYslygi.DataSource = DBConnection.s_yslygi;
        }
        //Обновление данных в таблице
        private void btnUpdateYslygi_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
        //Метод обновления данных
        private void RefreshTable()
        {
            DBConnection.ShowTableYslygi();
            dataGridYslygi.DataSource = DBConnection.s_yslygi;
        }
        //Ограничение на ввод только кириллицы
        private void textAddYslygi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Ограничение на ввод только кириллицы
        private void textEditYslygi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Открытие формы для поиска данных в таблице
        private void btnSearchYslygi_Click(object sender, EventArgs e)
        {
            Searching s = new Searching();
            s.searched = Program.Yslygi.dataGridYslygi;
            s.ShowDialog();
        }
        //Выбор строки записей в таблице
        private void dataGridYslygi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textEditYslygi.Text = dataGridYslygi.CurrentRow.Cells[1].Value.ToString();
            }
        }
    }
}
