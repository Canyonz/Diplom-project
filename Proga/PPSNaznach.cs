using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPSNaznach : UserControl
    {
        public PPSNaznach()
        {
            Program.naznach = this;
            InitializeComponent();
            dataGridNaznach.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 12F, FontStyle.Bold);
            dataGridNaznach.DefaultCellStyle.Font = new Font("Candara", 10F);
        }
        //Запуск таймера на открытия поля для добавления данных
        private void btnAddNaznach_Click(object sender, EventArgs e)
        {
            groupEditNaznach.Visible = false;
            groupAddNaznach.Visible = true;
            if (tableLayoutNaznach.RowStyles[0].Height == 100 && tableLayoutNaznach.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Открытие поля для добавления или редактирования данных
        private void timer1_Tick(object sender, EventArgs e)
        {
            tableLayoutNaznach.RowStyles[1].Height += 17;
            tableLayoutNaznach.RowStyles[0].Height -= 5;
            if (tableLayoutNaznach.RowStyles[1].Height == 136 && tableLayoutNaznach.RowStyles[0].Height == 60)
            {
                timer1.Stop();
            }
        }
        //Запуск таймера на открытия поля для редактирования данных
        private void btnEditNaznach_Click(object sender, EventArgs e)
        {
            groupAddNaznach.Visible = false;
            groupEditNaznach.Visible = true;
            if (tableLayoutNaznach.RowStyles[0].Height == 100 && tableLayoutNaznach.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Удаление выбранной записи из справочника «Назначения»
        private void btnDelNaznach_Click(object sender, EventArgs e)
        {
            if (dataGridNaznach.Rows.Count > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridNaznach.SelectedCells.Count; i++)
                    {
                        int key_r = Convert.ToInt32(dataGridNaznach.Rows[dataGridNaznach.SelectedCells[i].RowIndex].Cells[0].Value);
                        string naznach = dataGridNaznach.CurrentRow.Cells[1].Value.ToString();
                        int log = DBConnection.DellTableNaznach(key_r);
                        switch (log)
                        {
                            case (1):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Назначение акта '" + naznach + "' успешно удалено!");
                                RefreshTable();
                                break;
                            case (2):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Назначение акта '" + naznach + "' удалить не удалось!");
                                break;
                            case (3):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У назначения акта '" + naznach + "' имеется связь с таблицей 'Спецификация акта', удаление невозможно!");
                                break;
                        }
                    }
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "В таблице нет записей, удаление невозможно!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Закрытие формы
        private void btnHideNaznach_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        //Закрытие поля для добавления или редактирования данных
        private void timer2_Tick(object sender, EventArgs e)
        {
            tableLayoutNaznach.RowStyles[1].Height -= 17;
            tableLayoutNaznach.RowStyles[0].Height += 5;
            if (tableLayoutNaznach.RowStyles[1].Height == 0 && tableLayoutNaznach.RowStyles[0].Height == 100)
            {
                timer2.Stop();
            }
        }
        //Добавление данных в справочник «Назначения»
        private void addNaznach_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textAddNaznach.Text))
            {
                int log = DBConnection.AddTableNaznach(textAddNaznach.Text);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Назначение акта '" + textAddNaznach.Text + "' было успешно добавлено!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Назначение акта '" + textAddNaznach.Text + "' добавить не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Назначение акта '" + textAddNaznach.Text + "' уже существует, добавление '" + textAddNaznach.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Редактирование данных в справочнике «Назначения»
        private void editNaznach_Click(object sender, EventArgs e)
        {
            int key_r = Convert.ToInt32(dataGridNaznach.CurrentRow.Cells[0].Value);
            string naznach = dataGridNaznach.CurrentRow.Cells[1].Value.ToString();
            if (!String.IsNullOrEmpty(textEditNaznach.Text))
            {
                int log = DBConnection.EditTableNaznach(key_r, textEditNaznach.Text);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Назначение акта '" + naznach + "' было успешно обновлено на '" + textEditNaznach.Text + "'!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Назначение акта '" + naznach + "' обновить на '" + textEditNaznach.Text + "' не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Назначение акта '" + textEditNaznach.Text + "' уже существует, обновление '" + naznach + "' на '" + textEditNaznach.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Запуск таймера на закрытие поля для добавления или редактирования данных
        private void Close(object sender, EventArgs e)
        {
            if (tableLayoutNaznach.RowStyles[1].Height == 136 && tableLayoutNaznach.RowStyles[0].Height == 60)
            {
                timer2.Start();
            }
        }
        //Отображение данных справочника «Назначения» в таблицу
        private void PPSNaznach_Load(object sender, EventArgs e)
        {
            dataGridNaznach.DataSource = DBConnection.s_naznach;
        }
        //Обновление данных в таблице
        private void btnUpdateNaznach_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
        //Метод обновления данных
        private void RefreshTable()
        {
            DBConnection.ShowTableNaznach();
            dataGridNaznach.DataSource = DBConnection.s_naznach;
        }
        //Ограничение на ввод только кириллицы
        private void textAddNaznach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != '-' && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Ограничение на ввод только кириллицы
        private void textEditNaznach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != '-' && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Открытие формы для поиска данных в таблице
        private void btnSearchNaznach_Click(object sender, EventArgs e)
        {
            Searching s = new Searching();
            s.searched = Program.naznach.dataGridNaznach;
            s.ShowDialog();
        }
        //Выбор строки записей в таблице
        private void dataGridNaznach_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textEditNaznach.Text = dataGridNaznach.CurrentRow.Cells[1].Value.ToString();
            }
        }
    }
}
