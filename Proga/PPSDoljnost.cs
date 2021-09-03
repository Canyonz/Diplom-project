using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPSDoljnost : UserControl
    {
        public PPSDoljnost()
        {
            Program.Doljnost = this;
            InitializeComponent();
            dataGridDoljnost.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 12F, FontStyle.Bold);
            dataGridDoljnost.DefaultCellStyle.Font = new Font("Candara", 10F);
        }
        //Запуск таймера на открытия поля для добавления данных
        private void btnAddDoljnost_Click(object sender, EventArgs e)
        {
            groupEditDoljnost.Visible = false;
            groupAddDoljnost.Visible = true;
            if (tableLayoutDoljnost.RowStyles[0].Height == 100 && tableLayoutDoljnost.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Открытие поля для добавления или редактирования данных
        private void timer1_Tick(object sender, EventArgs e)
        {
            tableLayoutDoljnost.RowStyles[1].Height += 17;
            tableLayoutDoljnost.RowStyles[0].Height -= 5;
            if (tableLayoutDoljnost.RowStyles[1].Height == 136 && tableLayoutDoljnost.RowStyles[0].Height == 60)
            {
                timer1.Stop();
            }
        }
        //Запуск таймера на открытия поля для редактирования данных
        private void btnEditDoljnost_Click(object sender, EventArgs e)
        {
            groupAddDoljnost.Visible = false;
            groupEditDoljnost.Visible = true;
            if (tableLayoutDoljnost.RowStyles[0].Height == 100 && tableLayoutDoljnost.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Удаление выбранной записи из справочника «Должности»
        private void btnDelDoljnost_Click(object sender, EventArgs e)
        {
            if (dataGridDoljnost.Rows.Count > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridDoljnost.SelectedCells.Count; i++)
                    {
                        int key_r = Convert.ToInt32(dataGridDoljnost.Rows[dataGridDoljnost.SelectedCells[i].RowIndex].Cells[0].Value);
                        string Doljnost = dataGridDoljnost.CurrentRow.Cells[1].Value.ToString();
                        int log = DBConnection.DellTableDoljnost(key_r);
                        switch (log)
                        {
                            case (1):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Должность '" + Doljnost + "' успешно удален!");
                                RefreshTable();
                                break;
                            case (2):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Должность '" + Doljnost + "' удалить не удалось!");
                                break;
                            case (3):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Должность '" + Doljnost + "' имеет связь с таблицей 'Сотрудники', удаление невозможно!");
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
        private void btnHideDoljnost_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        //Запуск таймера на закрытие поля для добавления или редактирования данных
        private void Close(object sender, EventArgs e)
        {
            if (tableLayoutDoljnost.RowStyles[1].Height == 136 && tableLayoutDoljnost.RowStyles[0].Height == 60)
            {
                timer2.Start();
            }
        }
        //Закрытие поля для добавления или редактирования данных
        private void timer2_Tick(object sender, EventArgs e)
        {
            tableLayoutDoljnost.RowStyles[1].Height -= 17;
            tableLayoutDoljnost.RowStyles[0].Height += 5;
            if (tableLayoutDoljnost.RowStyles[1].Height == 0 && tableLayoutDoljnost.RowStyles[0].Height == 100)
            {
                timer2.Stop();
            }
        }
        //Добавление данных в справочник «Должности»
        private void addDoljnost_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textAddDoljnost.Text))
            {
                int log = DBConnection.AddTableDoljnost(textAddDoljnost.Text);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Должность '" + textAddDoljnost.Text + "' была успешно добавлена!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Должность '" + textAddDoljnost.Text + "' добавить не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Должность '" + textAddDoljnost.Text + "' уже существует, добавление '" + textAddDoljnost.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Редактирование данных в справочнике «Должности»
        private void editDoljnost_Click(object sender, EventArgs e)
        {
            int key_r = Convert.ToInt32(dataGridDoljnost.CurrentRow.Cells[0].Value);
            string type = dataGridDoljnost.CurrentRow.Cells[1].Value.ToString();
            if (!String.IsNullOrEmpty(textEditDoljnost.Text))
            {
                int log = DBConnection.EditTableDoljnost(key_r, textEditDoljnost.Text);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Должность '" + type + "' была успешно обновлена на '" + textEditDoljnost.Text + "'!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Должность '" + type + "' обновить на '" + textEditDoljnost.Text + "' не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Должность '" + textEditDoljnost.Text + "' уже существует, обновление '" + type + "' на '" + textEditDoljnost.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Отображение данных справочника «Должности» в таблицу
        private void PPSDoljnost_Load(object sender, EventArgs e)
        {
            dataGridDoljnost.DataSource = DBConnection.s_Doljnost;
        }
        //Обновление данных в таблице
        private void btnUpdateDoljnost_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
        //Метод обновления данных
        private void RefreshTable()
        {
            DBConnection.ShowTableDoljnost();
            dataGridDoljnost.DataSource = DBConnection.s_Doljnost;
        }
        //Ограничение на ввод только кириллицы
        private void textAddDoljnost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Ограничение на ввод только кириллицы
        private void textEditDoljnost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Открытие формы для поиска данных в таблице
        private void btnSearchDoljnost_Click(object sender, EventArgs e)
        {
            Searching s = new Searching();
            s.searched = Program.Doljnost.dataGridDoljnost;
            s.ShowDialog();
        }
        //Выбор строки записей в таблице
        private void dataGridDoljnost_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textEditDoljnost.Text = dataGridDoljnost.CurrentRow.Cells[1].Value.ToString();
            }
        }
    }
}
