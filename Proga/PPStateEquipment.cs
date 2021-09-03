using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPStateEquipment : UserControl
    {
        public PPStateEquipment()
        {
            Program.state = this;
            InitializeComponent();
            dataGridStateEquipment.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 12F, FontStyle.Bold);
            dataGridStateEquipment.DefaultCellStyle.Font = new Font("Candara", 10F);
        }
        //Запуск таймера на открытия поля для добавления данных
        private void btnAddStateEquipment_Click(object sender, EventArgs e)
        {
            groupEditStateEquipment.Visible = false;
            groupAddStateEquipment.Visible = true;
            if (tableLayoutStateEquipment.RowStyles[0].Height == 100 && tableLayoutStateEquipment.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Открытие поля для добавления или редактирования данных
        private void timer1_Tick(object sender, EventArgs e)
        {
            tableLayoutStateEquipment.RowStyles[1].Height += 17;
            tableLayoutStateEquipment.RowStyles[0].Height -= 5;
            if (tableLayoutStateEquipment.RowStyles[1].Height == 136 && tableLayoutStateEquipment.RowStyles[0].Height == 60)
            {
                timer1.Stop();
            }
        }
        //Закрытие поля для добавления или редактирования данных
        private void timer2_Tick(object sender, EventArgs e)
        {
            tableLayoutStateEquipment.RowStyles[1].Height -= 17;
            tableLayoutStateEquipment.RowStyles[0].Height += 5;
            if (tableLayoutStateEquipment.RowStyles[1].Height == 0 && tableLayoutStateEquipment.RowStyles[0].Height == 100)
            {
                timer2.Stop();
            }
        }
        //Запуск таймера на открытия поля для редактирования данных
        private void btnEditStateEquipment_Click(object sender, EventArgs e)
        {
            groupAddStateEquipment.Visible = false;
            groupEditStateEquipment.Visible = true;
            if (tableLayoutStateEquipment.RowStyles[0].Height == 100 && tableLayoutStateEquipment.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Удаление выбранной записи из справочника «Состояние оборудования»
        private void btnDelStateEquipment_Click(object sender, EventArgs e)
        {
            if (dataGridStateEquipment.Rows.Count > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridStateEquipment.SelectedCells.Count; i++)
                    {
                        int key_r = Convert.ToInt32(dataGridStateEquipment.Rows[dataGridStateEquipment.SelectedCells[i].RowIndex].Cells[0].Value);
                        string state = dataGridStateEquipment.CurrentRow.Cells[1].Value.ToString();
                        int log = DBConnection.DellTableStateEquipment(key_r);
                        switch (log)
                        {
                            case (1):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Состояние оборудования '" + state + "' успешно удалено!");
                                RefreshTable();
                                break;
                            case (2):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Состояние оборудования '" + state + "' удалить не удалось!");
                                break;
                            case (3):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У состояния оборудования '" + state + "' имеется связь с таблицей 'Спецификация акта', удаление невозможно!");
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
        private void btnHideStateEquipment_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        //Запуск таймера на закрытие поля для добавления или редактирования данных
        private void Close(object sender, EventArgs e)
        {
            if (tableLayoutStateEquipment.RowStyles[1].Height == 136 && tableLayoutStateEquipment.RowStyles[0].Height == 60)
            {
                timer2.Start();
            }
        }
        //Добавление данных в справочник «Состояние оборудования»
        private void addStateEquipment_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textAddStateEquipment.Text))
            {
                int log = DBConnection.AddTableStateEquipment(textAddStateEquipment.Text);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Состояние оборудования '" + textAddStateEquipment.Text + "' было успешно добавлено!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Состояние оборудования '" + textAddStateEquipment.Text + "' добавить не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Состояние оборудования '" + textAddStateEquipment.Text + "' уже существует, добавление '" + textAddStateEquipment.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Редактирование данных в справочнике «Состояние оборудования»
        private void editStateEquipment_Click(object sender, EventArgs e)
        {
            int key_r = Convert.ToInt32(dataGridStateEquipment.CurrentRow.Cells[0].Value);
            string state = dataGridStateEquipment.CurrentRow.Cells[1].Value.ToString();
            if (!String.IsNullOrEmpty(textEditStateEquipment.Text))
            {
                int log = DBConnection.EditTableStateEquipment(key_r, textEditStateEquipment.Text);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Состояние оборудования '" + state + "' было успешно обновлено на '" + textEditStateEquipment.Text + "'!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Состояние оборудования '" + state + "' обновить на '" + textEditStateEquipment.Text + "' не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Состояние оборудования '" + textEditStateEquipment.Text + "' уже существует, обновление '" + state + "' на '" + textEditStateEquipment.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Отображение данных справочника «Состояние оборудования» в таблицу
        private void PPStateEquipment_Load(object sender, EventArgs e)
        {
            dataGridStateEquipment.DataSource = DBConnection.s_stateequip;
        }
        //Обновление данных в таблице
        private void btnUpdateStateEquipment_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
        //Метод обновления данных
        private void RefreshTable()
        {
            DBConnection.ShowTableStateEquipment();
            dataGridStateEquipment.DataSource = DBConnection.s_stateequip;
        }
        //Ограничение на ввод только кириллицы
        private void textAddStateEquipment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Ограничение на ввод только кириллицы
        private void textEditStateEquipment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Открытие формы для поиска данных в таблице
        private void btnSearchStateEquipment_Click(object sender, EventArgs e)
        {
            Searching s = new Searching();
            s.searched = Program.state.dataGridStateEquipment;
            s.ShowDialog();
        }
        //Выбор строки записей в таблице
        private void dataGridStateEquipment_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textEditStateEquipment.Text = dataGridStateEquipment.CurrentRow.Cells[1].Value.ToString();
            }
        }
    }
}
