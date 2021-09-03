using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPSReasons : UserControl
    {
        public PPSReasons()
        {
            Program.Reasons = this;
            InitializeComponent();
            dataGridReasons.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 12F, FontStyle.Bold);
            dataGridReasons.DefaultCellStyle.Font = new Font("Candara", 10F);
        }
        //Запуск таймера на открытия поля для добавления данных
        private void btnAddReasons_Click(object sender, EventArgs e)
        {
            groupEditReasons.Visible = false;
            groupAddReasons.Visible = true;
            if (tableLayoutReasons.RowStyles[0].Height == 100 && tableLayoutReasons.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Открытие поля для добавления или редактирования данных
        private void timer1_Tick(object sender, EventArgs e)
        {
            tableLayoutReasons.RowStyles[1].Height += 17;
            tableLayoutReasons.RowStyles[0].Height -= 5;
            if (tableLayoutReasons.RowStyles[1].Height == 136 && tableLayoutReasons.RowStyles[0].Height == 60)
            {
                timer1.Stop();
            }
        }
        //Закрытие поля для добавления или редактирования данных
        private void timer2_Tick(object sender, EventArgs e)
        {
            tableLayoutReasons.RowStyles[1].Height -= 17;
            tableLayoutReasons.RowStyles[0].Height += 5;
            if (tableLayoutReasons.RowStyles[1].Height == 0 && tableLayoutReasons.RowStyles[0].Height == 100)
            {
                timer2.Stop();
            }
        }
        //Запуск таймера на открытия поля для редактирования данных
        private void btnEditReasons_Click(object sender, EventArgs e)
        {
            groupAddReasons.Visible = false;
            groupEditReasons.Visible = true;
            if (tableLayoutReasons.RowStyles[0].Height == 100 && tableLayoutReasons.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Удаление выбранной записи из справочника «Причины»
        private void btnDelReasons_Click(object sender, EventArgs e)
        {
            if (dataGridReasons.Rows.Count > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridReasons.SelectedCells.Count; i++)
                    {
                        int key_r = Convert.ToInt32(dataGridReasons.Rows[dataGridReasons.SelectedCells[i].RowIndex].Cells[0].Value);
                        string reasons = dataGridReasons.CurrentRow.Cells[1].Value.ToString();
                        int log = DBConnection.DellTableReasons(key_r);
                        switch (log)
                        {
                            case (1):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Причина '" + reasons + "' успешно удалена!");
                                RefreshTable();
                                break;
                            case (2):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Причину '" + reasons + "' удалить не удалось!");
                                break;
                            case (3):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У причины '" + reasons + "' имеется связь с таблицей 'Спецификация акта', удаление невозможно!");
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
            if (tableLayoutReasons.RowStyles[1].Height == 136 && tableLayoutReasons.RowStyles[0].Height == 60)
            {
                timer2.Start();
            }
        }
        //Закрытие формы
        private void btnHideReasons_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        //Добавление данных в справочник «Причины»
        private void addReasons_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textAddReasons.Text))
            {
                int log = DBConnection.AddTableReasons(textAddReasons.Text);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Причина '" + textAddReasons.Text + "' была успешно добавлена!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Причину '" + textAddReasons.Text + "' добавить не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Причина '" + textAddReasons.Text + "' уже существует, добавление '" + textAddReasons.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Редактирование данных в справочнике «Причины»
        private void editReasons_Click(object sender, EventArgs e)
        {
            int key_r = Convert.ToInt32(dataGridReasons.CurrentRow.Cells[0].Value);
            string reasons = dataGridReasons.CurrentRow.Cells[1].Value.ToString();
            if (!String.IsNullOrEmpty(textEditReasons.Text))
            {
                int log = DBConnection.EditTableReasons(key_r, textEditReasons.Text);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Причина '" + reasons + "' была успешно обновлена на '" + textEditReasons.Text + "'!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Причину '" + reasons + "' обновить на '" + textEditReasons.Text + "' не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Причина '" + textEditReasons.Text + "' уже существует, обновление '" + reasons + "' на '" + textEditReasons.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Отображение данных справочника «Причины» в таблицу
        private void PPSReasons_Load(object sender, EventArgs e)
        {
            dataGridReasons.DataSource = DBConnection.s_Reasons;
        }
        //Обновление данных в таблице
        private void btnUpdateReasons_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
        //Метод обновления данных
        private void RefreshTable()
        {
            DBConnection.ShowTableReasons();
            dataGridReasons.DataSource = DBConnection.s_Reasons;
        }
        //Ограничение на ввод только кириллицы
        private void textAddReasons_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Ограничение на ввод только кириллицы
        private void textEditReasons_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Открытие формы для поиска данных в таблице
        private void btnSearchReasons_Click(object sender, EventArgs e)
        {
            Searching s = new Searching();
            s.searched = Program.Reasons.dataGridReasons;
            s.ShowDialog();
        }
        //Выбор строки записей в таблице
        private void dataGridReasons_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textEditReasons.Text = dataGridReasons.CurrentRow.Cells[1].Value.ToString();
            }
        }
    }
}
