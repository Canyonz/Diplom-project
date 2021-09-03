using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPTSklad : UserControl
    {
        public PPTSklad()
        {
            Program.Sklad = this;
            InitializeComponent();
            dataGridSklad.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 12F, FontStyle.Bold);
            dataGridSklad.DefaultCellStyle.Font = new Font("Candara", 10F);
        }
        //Запуск таймера на открытия поля для добавления данных
        private void btnAddSklad_Click(object sender, EventArgs e)
        {
            groupEditSklad.Visible = false;
            groupAddSklad.Visible = true;
            if (tableLayoutSklad.RowStyles[0].Height == 100 && tableLayoutSklad.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Запуск таймера на открытия поля для редактирования данных
        private void btnEditSklad_Click(object sender, EventArgs e)
        {
            groupAddSklad.Visible = false;
            groupEditSklad.Visible = true;
            if (tableLayoutSklad.RowStyles[0].Height == 100 && tableLayoutSklad.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Открытие поля для добавления или редактирования данных
        private void timer1_Tick(object sender, EventArgs e)
        {
            tableLayoutSklad.RowStyles[1].Height += 17;
            tableLayoutSklad.RowStyles[0].Height -= 5;
            if (tableLayoutSklad.RowStyles[1].Height == 136 && tableLayoutSklad.RowStyles[0].Height == 60)
            {
                timer1.Stop();
            }
        }
        //Закрытие поля для добавления или редактирования данных
        private void timer2_Tick(object sender, EventArgs e)
        {
            tableLayoutSklad.RowStyles[1].Height -= 17;
            tableLayoutSklad.RowStyles[0].Height += 5;
            if (tableLayoutSklad.RowStyles[1].Height == 0 && tableLayoutSklad.RowStyles[0].Height == 100)
            {
                timer2.Stop();
            }
        }
        //Удаление выбранной записи из таблицы «Склад»
        private void btnDelSklad_Click(object sender, EventArgs e)
        {
            if (dataGridSklad.Rows.Count > 0)
            {
                if (dataGridSklad.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataGridSklad.SelectedRows.Count; i++)
                        {
                            int key_r = Convert.ToInt32(dataGridSklad.Rows[dataGridSklad.SelectedRows[i].Index].Cells[0].Value);
                            string type = dataGridSklad.CurrentRow.Cells[1].Value.ToString();
                            string equip = dataGridSklad.CurrentRow.Cells[2].Value.ToString();
                            string count = dataGridSklad.CurrentRow.Cells[3].Value.ToString();
                            int log = DBConnection.DellTableSklad(key_r);
                            switch (log)
                            {
                                case (1):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Со склада Оборудование: '" + type +' '+ equip + "' с Количеством: '" + count + "' успешно удалено!");
                                    RefreshTable();
                                    break;
                                case (2):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Со склада Оборудование: '" + type + ' ' + equip + "' с Количеством: '" + count + "' удалить не удалось!");
                                    break;
                                case (3):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Со склада Оборудование: '" + type + ' ' + equip + "' связано с таблицей 'Спецификация акта', удаление невозможно!");
                                    break;
                                case (4):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "На складе Оборудование: '" + type + ' ' + equip + "' связано с таблицей 'Спецификация накладной', удаление невозможно!");
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
        private void btnHideSklad_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        //Запуск таймера на закрытие поля для добавления или редактирования данных
        private void Close(object sender, EventArgs e)
        {
            if (tableLayoutSklad.RowStyles[1].Height == 136 && tableLayoutSklad.RowStyles[0].Height == 60)
            {
                timer2.Start();
            }
        }
        //Добавление данных в таблицу «Склад»
        private void addSklad_Click(object sender, EventArgs e)
        {
            int TypeEquip = Convert.ToInt32(DBConnection.s_TypeEquip.Rows[comboBoxAddSkladTypeEquip.SelectedIndex].ItemArray.GetValue(0));
            if (!String.IsNullOrEmpty(textBoxAddSkladEquip.Text)
                && !String.IsNullOrEmpty(TypeEquip.ToString()))
            {
                int log = DBConnection.AddTableSklad(TypeEquip,textBoxAddSkladEquip.Text);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "На склад Оборудование: '" + comboBoxAddSkladTypeEquip.Text + ' ' + textBoxAddSkladEquip.Text+ "' было успешно добавлено!");
                        DBConnection.Types();
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "На склад Оборудование: '" + comboBoxAddSkladTypeEquip.Text + ' ' + textBoxAddSkladEquip.Text + "' добавить не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Оборудование: '" +textBoxAddSkladEquip.Text + "' уже существует, добавление Оборудования: '" + comboBoxAddSkladTypeEquip.Text + ' ' + textBoxAddSkladEquip.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Редактирование данных в таблице «Склад»
        private void editSklad_Click(object sender, EventArgs e)
        {
            int key_r = Convert.ToInt32(dataGridSklad.CurrentRow.Cells[0].Value);
            int TypeEquip = Convert.ToInt32(DBConnection.s_TypeEquip.Rows[comboBoxEditSkladTypeEquip.SelectedIndex].ItemArray.GetValue(0));
            string type = dataGridSklad.CurrentRow.Cells[1].Value.ToString();
            string equip = dataGridSklad.CurrentRow.Cells[2].Value.ToString();
            string count = dataGridSklad.CurrentRow.Cells[3].Value.ToString();
            if (!String.IsNullOrEmpty(textBoxEditSkladEquip.Text)
                && !String.IsNullOrEmpty(TypeEquip.ToString()))
            {
                int log = DBConnection.EditTableSklad(key_r, TypeEquip,textBoxEditSkladEquip.Text, Convert.ToInt32(textBoxEditSkladCount.Text));
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "На складе Оборудование: '" + type + ' ' + equip + "' было успешно обновлено на Оборудование: '" + comboBoxEditSkladTypeEquip.Text + textBoxEditSkladEquip.Text + "'!");
                        DBConnection.Types();
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "На складе Оборудование: '" + type + ' ' + equip + "' обновить на Оборудование: '" + comboBoxEditSkladTypeEquip.Text + textBoxEditSkladEquip.Text + "' не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Оборудование: '" + textBoxEditSkladEquip.Text + "' уже существует, обновление Оборудования: '" + type + ' ' + equip + "' на Оборудование: '" + comboBoxEditSkladTypeEquip.Text + ' ' + textBoxEditSkladEquip.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Отображение данных таблицы «Склад» в таблицу
        private void PPTSklad_Load(object sender, EventArgs e)
        {
            dataGridSklad.DataSource = DBConnection.t_Sklad;
            comboBoxAddSkladTypeEquip.DataSource = DBConnection.s_TypeEquip;
            comboBoxAddSkladTypeEquip.DisplayMember = "typeequip";

            comboBoxEditSkladTypeEquip.DataSource = DBConnection.s_TypeEquip;
            comboBoxEditSkladTypeEquip.DisplayMember = "typeequip";
        }
        //Выбор строки записей в таблице
        private void dataGridSklad_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                comboBoxEditSkladTypeEquip.Text = dataGridSklad.CurrentRow.Cells[1].Value.ToString();
                textBoxEditSkladEquip.Text = dataGridSklad.CurrentRow.Cells[2].Value.ToString();
                textBoxEditSkladCount.Text = dataGridSklad.CurrentRow.Cells[3].Value.ToString();
            }
        }
        //При выборе заголовка столбца правой кнопкой мыши выводится список для отбора записей
        int key;
        private void dataGridSklad_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.ColumnIndex != 0 && e.RowIndex == -1)
            {
                Filter.Items.Clear();
                switch (e.ColumnIndex)
                {
                    case (1):
                        {
                            DBConnection.ShowFilter("s_typeequip.typeequip", "t_sklad, s_typeequip", "where t_sklad.id_typeequip = s_typeequip.id_typeequip order by s_typeequip.typeequip");
                            key = 1;
                        }
                        break;
                    case (2):
                        {
                            DBConnection.ShowFilter("t_sklad.equipment", "t_sklad", "order by t_sklad.equipment");
                            key = 2;
                        }
                        break;
                    case (3):
                        {
                            DBConnection.ShowFilter("t_sklad.count", "t_sklad", "order by t_sklad.count");
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
                        DBConnection.ShowFilters("t_sklad.id_skladequip, s_typeequip.typeequip, t_sklad.equipment, t_sklad.count",
                        "t_sklad, s_typeequip", "where t_sklad.id_typeequip = s_typeequip.id_typeequip and s_typeequip.typeequip = '" + e.ClickedItem.Text + "' order by s_typeequip.typeequip");
                    }
                    break;
                case (2):
                    {
                        DBConnection.ShowFilters("t_sklad.id_skladequip, s_typeequip.typeequip, t_sklad.equipment, t_sklad.count",
                        "t_sklad, s_typeequip", "where t_sklad.id_typeequip = s_typeequip.id_typeequip and t_sklad.equipment = '" + e.ClickedItem.Text + "' order by s_typeequip.typeequip");
                    }
                    break;
                case (3):
                    {
                        DBConnection.ShowFilters("t_sklad.id_skladequip, s_typeequip.typeequip, t_sklad.equipment, t_sklad.count",
                        "t_sklad, s_typeequip", "where t_sklad.id_typeequip = s_typeequip.id_typeequip and t_sklad.count = '" + e.ClickedItem.Text + "' order by s_typeequip.typeequip");
                    }
                    break;
            }
            dataGridSklad.DataSource = DBConnection.filters;
        }
        //Обновление данных в таблице
        private void btnUpdateSklad_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
        //Метод обновления данных
        private void RefreshTable()
        {
            DBConnection.ShowTableSklad();
            dataGridSklad.DataSource = DBConnection.t_Sklad;
        }
        //Поиск записей в таблице
        private void btnSearchSklad_Click(object sender, EventArgs e)
        {
            Searching s = new Searching();
            s.searched = Program.Sklad.dataGridSklad;
            s.ShowDialog();
        }
    }
}
