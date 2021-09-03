using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPSTypeEquip : UserControl
    {
        public PPSTypeEquip()
        {
            Program.TypeEquip = this;
            InitializeComponent();
            dataGridTypeEquip.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 12F, FontStyle.Bold);
            dataGridTypeEquip.DefaultCellStyle.Font = new Font("Candara", 10F);

        }
        //Запуск таймера на открытия поля для добавления данных
        private void btnAddTypeEquip_Click(object sender, EventArgs e)
        {
            groupEditTypeEquip.Visible = false;
            groupAddTypeEquip.Visible = true;
            if (tableLayoutTypeEquip.RowStyles[0].Height == 100 && tableLayoutTypeEquip.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Открытие поля для добавления или редактирования данных
        private void timer1_Tick(object sender, EventArgs e)
        {
            tableLayoutTypeEquip.RowStyles[1].Height += 17;
            tableLayoutTypeEquip.RowStyles[0].Height -= 5;
            if (tableLayoutTypeEquip.RowStyles[1].Height == 136 && tableLayoutTypeEquip.RowStyles[0].Height == 60)
            {
                timer1.Stop();
            }
        }
        //Закрытие поля для добавления или редактирования данных
        private void timer2_Tick(object sender, EventArgs e)
        {
            tableLayoutTypeEquip.RowStyles[1].Height -= 17;
            tableLayoutTypeEquip.RowStyles[0].Height += 5;
            if (tableLayoutTypeEquip.RowStyles[1].Height == 0 && tableLayoutTypeEquip.RowStyles[0].Height == 100)
            {
                timer2.Stop();
            }
        }
        //Запуск таймера на открытия поля для редактирования данных
        private void btnEditTypeEquip_Click(object sender, EventArgs e)
        {
            groupAddTypeEquip.Visible = false;
            groupEditTypeEquip.Visible = true;
            if (tableLayoutTypeEquip.RowStyles[0].Height == 100 && tableLayoutTypeEquip.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Удаление выбранной записи из справочника «Тип оборудования»
        private void btnDelTypeEquip_Click(object sender, EventArgs e)
        {
            if (dataGridTypeEquip.Rows.Count > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridTypeEquip.SelectedCells.Count; i++)
                    {
                        int key_r = Convert.ToInt32(dataGridTypeEquip.Rows[dataGridTypeEquip.SelectedCells[i].RowIndex].Cells[0].Value);
                        string type = dataGridTypeEquip.CurrentRow.Cells[1].Value.ToString();
                        int log = DBConnection.DellTableTypeEquip(key_r);
                        switch (log)
                        {
                            case (1):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Тип оборудования '" + type + "' успешно удален!");
                                RefreshTable();
                                break;
                            case (2):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Тип оборудования '" + type + "' удалить не удалось!");
                                break;
                            case (3):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У типа оборудования '" + type + "' имеется связь с таблицей 'Склад', удаление невозможно!");
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
            if (tableLayoutTypeEquip.RowStyles[1].Height == 136 && tableLayoutTypeEquip.RowStyles[0].Height == 60)
            {
                timer2.Start();
            }
        }
        //Закрытие формы
        private void btnHideTypeEquip_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        //Добавление данных в справочник «Тип оборудования»
        private void addTypeEquip_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textAddTypeEquip.Text))
            {
                int log = DBConnection.AddTableTypeEquip(textAddTypeEquip.Text);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Тип оборудования '" + textAddTypeEquip.Text + "' был успешно добавлен!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Тип оборудования '" + textAddTypeEquip.Text + "' добавить не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Тип оборудования '" + textAddTypeEquip.Text + "' уже существует, добавление '" + textAddTypeEquip.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Редактирование данных в справочнике «Тип оборудования»
        private void editTypeEquip_Click(object sender, EventArgs e)
        {
            int key_r = Convert.ToInt32(dataGridTypeEquip.CurrentRow.Cells[0].Value);
            string type = dataGridTypeEquip.CurrentRow.Cells[1].Value.ToString();
            if (!String.IsNullOrEmpty(textEditTypeEquip.Text))
            {
                int log = DBConnection.EditTableTypeEquip(key_r, textEditTypeEquip.Text);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Тип оборудования '" + type + "' был успешно обновлен на '" + textEditTypeEquip.Text + "'!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Тип оборудования '" + type + "' обновить на '" + textEditTypeEquip.Text + "' не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Тип оборудования '" + textEditTypeEquip.Text + "' уже существует, обновление '" + type + "' на '" + textEditTypeEquip.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Отображение данных справочника «Тип оборудования» в таблицу
        private void PPSTypeEquip_Load(object sender, EventArgs e)
        {
            dataGridTypeEquip.DataSource = DBConnection.s_TypeEquip;
        }
        //Обновление данных в таблице
        private void btnUpdateTypeEquip_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
        //Метод обновления данных
        private void RefreshTable()
        {
            DBConnection.ShowTableTypeEquip();
            dataGridTypeEquip.DataSource = DBConnection.s_TypeEquip;
        }
        //Ограничение на ввод только кириллицы
        private void textAddTypeEquip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Ограничение на ввод только кириллицы
        private void textEditTypeEquip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Открытие формы для поиска данных в таблице
        private void btnSearchTypeEquip_Click(object sender, EventArgs e)
        {
            Searching s = new Searching();
            s.searched = Program.TypeEquip.dataGridTypeEquip;
            s.ShowDialog();
        }
        //Выбор строки записей в таблице
        private void dataGridTypeEquip_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textEditTypeEquip.Text = dataGridTypeEquip.CurrentRow.Cells[1].Value.ToString();
            }
        }
    }
}
