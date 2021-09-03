using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPTSpecNaklad : UserControl
    {
        public PPTSpecNaklad()
        {
            Program.SpecNaklad = this;
            InitializeComponent();
            Connect();
            dataGridSpecNaklad.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 12F, FontStyle.Bold);
            dataGridSpecNaklad.DefaultCellStyle.Font = new Font("Candara", 10F);
        }
        //Метод отображения данных таблицы «Спецификация накладной» в таблицу
        public void Connect()
        {
            dataGridSpecNaklad.DataSource = DBConnection.t_SpecNaklad;
        }
        //Открытие формы «Накладная»
        private void ShowPrev_Click(object sender, EventArgs e)
        {
            Program.Naklad_Spec.tableLayoutPanel1.ColumnStyles[0].Width = 50;
        }
        //Запуск таймера на открытия поля для добавления данных
        private void btnAddSpecNaklad_Click(object sender, EventArgs e)
        {
            groupEditSpecNaklad.Visible = false;
            groupAddSpecNaklad.Visible = true;
            if (tableLayoutSpecNaklad.RowStyles[0].Height == 100 && tableLayoutSpecNaklad.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Запуск таймера на открытия поля для редактирования данных
        private void btnEditSpecNaklad_Click(object sender, EventArgs e)
        {
            groupAddSpecNaklad.Visible = false;
            groupEditSpecNaklad.Visible = true;
            if (tableLayoutSpecNaklad.RowStyles[0].Height == 100 && tableLayoutSpecNaklad.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Открытие поля для добавления или редактирования данных
        private void timer1_Tick(object sender, EventArgs e)
        {
            tableLayoutSpecNaklad.RowStyles[1].Height += 17;
            tableLayoutSpecNaklad.RowStyles[0].Height -= 5;
            if (tableLayoutSpecNaklad.RowStyles[1].Height == 136 && tableLayoutSpecNaklad.RowStyles[0].Height == 60)
            {
                timer1.Stop();
            }
        }
        //Закрытие поля для добавления или редактирования данных
        private void timer2_Tick(object sender, EventArgs e)
        {
            tableLayoutSpecNaklad.RowStyles[1].Height -= 17;
            tableLayoutSpecNaklad.RowStyles[0].Height += 5;
            if (tableLayoutSpecNaklad.RowStyles[1].Height <= 0 && tableLayoutSpecNaklad.RowStyles[0].Height >= 100)
            {
                timer2.Stop();
            }
        }
        //Удаление выбранной записи из таблицы «Спецификация накладной»
        private void btnDelSpecNaklad_Click(object sender, EventArgs e)
        {
            if (dataGridSpecNaklad.Rows.Count > 0)
            {
                if (dataGridSpecNaklad.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataGridSpecNaklad.SelectedRows.Count; i++)
                        {
                            int id_nakladnaya = DBConnection.NomNaklad;
                            int key_r = Convert.ToInt32(dataGridSpecNaklad.Rows[dataGridSpecNaklad.SelectedRows[i].Index].Cells[0].Value);
                            int id_skladequip = DBConnection.keyRecord("t_sklad.id_skladequip", "t_sklad,s_typeequip", "t_sklad.id_typeequip = s_typeequip.id_typeequip and s_typeequip.typeequip = '" + dataGridSpecNaklad.CurrentRow.Cells[1].Value.ToString() + "' and t_sklad.equipment", dataGridSpecNaklad.CurrentRow.Cells[2].Value.ToString());
                            string equip = dataGridSpecNaklad.CurrentRow.Cells[3].Value.ToString();
                            int price = Convert.ToInt32(dataGridSpecNaklad.CurrentRow.Cells[5].Value.ToString());
                            int count = Convert.ToInt32(dataGridSpecNaklad.CurrentRow.Cells[4].Value.ToString());
                            int log = DBConnection.DellTableSpecNaklad(key_r);
                            switch (log)
                            {
                                case (1):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У накладной №: '" + DBConnection.keyValue("numnaklad", "t_nakladnaya", "id_nakladnaya", id_nakladnaya.ToString()) + "' Оборудование: '" + equip + "' с количеством: '" + count + "' по цене: '" + price + "' успешно удалено!");
                                    if (DBConnection.edit("update t_sklad set count = count - '" + count + "' where id_skladequip = '" + id_skladequip + "'"))
                                    {
                                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Со склада отгружено оборудование: '" + equip + "' в количестве: '" + count + "'!");
                                        DBConnection.ShowTableSklad();
                                    }
                                    else
                                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Со склада оборудование: '" + equip + "' в количестве: '" + count + "' отгрузить не удалось!");
                                    RefreshTable();
                                    break;
                                case (2):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У накладной №: '" + DBConnection.keyValue("numnaklad", "t_nakladnaya", "id_nakladnaya", id_nakladnaya.ToString()) + "' Оборудование: '" + equip + "' с количеством: '" + count + "' по цене: '" + price + "' удалить не удалось!");
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
        private void btnHideSpecNaklad_Click(object sender, EventArgs e)
        {
            if (Program.Naklad_Spec.tableLayoutPanel1.ColumnStyles[0].Width > 0)
                Program.Naklad_Spec.tableLayoutPanel1.ColumnStyles[1].Width = 0;
        }
        //Запуск таймера на закрытие поля для добавления или редактирования данных
        private void Close(object sender, EventArgs e)
        {
            if (tableLayoutSpecNaklad.RowStyles[1].Height == 136 && tableLayoutSpecNaklad.RowStyles[0].Height == 60)
            {
                timer2.Start();
            }
        }
        //Добавление данных в таблицу «Спецификация накладной»
        private void addSpecNaklad_Click(object sender, EventArgs e)
        {
            int id_nakladnaya = DBConnection.NomNaklad;
            int id_skladequip = DBConnection.keyRecord("t_sklad.id_skladequip", "t_sklad,s_typeequip", "t_sklad.id_typeequip = s_typeequip.id_typeequip and s_typeequip.typeequip = '" + comboBoxAddSpecNakladTypeEquip.Text + "' and t_sklad.equipment", comboBoxAddSpecNakladEquip.Text);
            if (!String.IsNullOrEmpty(textBoxAddSpecNakladCount.Text)
                && !String.IsNullOrEmpty(id_nakladnaya.ToString())
                && !String.IsNullOrEmpty(id_skladequip.ToString())
                && !String.IsNullOrEmpty(textBoxAddSpecNakladPrice.Text))
            {
                int log = DBConnection.AddTableSpecNaklad(id_nakladnaya, id_skladequip, Convert.ToInt32(textBoxAddSpecNakladCount.Text), Convert.ToInt32(textBoxAddSpecNakladPrice.Text));
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "В накладную №: '" + DBConnection.keyValue("numnaklad", "t_nakladnaya", "id_nakladnaya", id_nakladnaya.ToString()) + "' Оборудование: '" + comboBoxAddSpecNakladTypeEquip.Text +' '+ comboBoxAddSpecNakladEquip.Text +"' с количеством: '" + textBoxAddSpecNakladCount.Text + "' по цене: '" + textBoxAddSpecNakladPrice.Text + "' было успешно добавлено!");
                        if (DBConnection.edit("update t_sklad set count = count + '" + Convert.ToInt32(textBoxAddSpecNakladCount.Text) + "' where id_skladequip = '" + id_skladequip + "'"))
                        {
                           listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "На склад поступило оборудование: '" + comboBoxAddSpecNakladTypeEquip.Text + ' ' + comboBoxAddSpecNakladEquip.Text + "' в количестве: '" + textBoxAddSpecNakladCount.Text + "'!");
                            DBConnection.ShowTableSklad();
                        }else
                            listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "На склад оборудование: '" + comboBoxAddSpecNakladTypeEquip.Text + ' ' + comboBoxAddSpecNakladEquip.Text + "' в количестве: '" + textBoxAddSpecNakladCount.Text + "' не поступило!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "В накладную №: '" + DBConnection.keyValue("numnaklad", "t_nakladnaya", "id_nakladnaya", id_nakladnaya.ToString()) + "' Оборудование: '" + comboBoxAddSpecNakladTypeEquip.Text + ' ' + comboBoxAddSpecNakladEquip.Text + "' с количеством: '" + textBoxAddSpecNakladCount.Text + "' по цене: '" + textBoxAddSpecNakladPrice.Text + "' добавить не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "В накладной №: '" + DBConnection.keyValue("numnaklad", "t_nakladnaya", "id_nakladnaya", id_nakladnaya.ToString()) + "' Оборудование: '" + comboBoxAddSpecNakladTypeEquip.Text + ' ' + comboBoxAddSpecNakladEquip.Text + "' уже существует, добавление Оборудования: '" + comboBoxAddSpecNakladTypeEquip.Text + ' ' + comboBoxAddSpecNakladEquip.Text + "' с количеством: '" + textBoxAddSpecNakladCount.Text + "' по цене: '" + textBoxAddSpecNakladPrice.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Редактирование данных в таблице «Спецификация накладной»
        private void editSpecNaklad_Click(object sender, EventArgs e)
        {
            int key_r = Convert.ToInt32(dataGridSpecNaklad.CurrentRow.Cells[0].Value);
            int id_nakladnaya = DBConnection.NomNaklad;
            int id_skladequip = DBConnection.keyRecord("t_sklad.id_skladequip", "t_sklad,s_typeequip", "t_sklad.id_typeequip = s_typeequip.id_typeequip and s_typeequip.typeequip = '" + comboBoxEditSpecNakladTypeEquip.Text + "' and t_sklad.equipment", comboBoxEditSpecNakladEquip.Text);
            string equip = dataGridSpecNaklad.CurrentRow.Cells[3].Value.ToString();
            int count = Convert.ToInt32(dataGridSpecNaklad.CurrentRow.Cells[4].Value.ToString());
            int price = Convert.ToInt32(dataGridSpecNaklad.CurrentRow.Cells[5].Value.ToString());
            int id_prevskladequip = DBConnection.keyRecord("t_sklad.id_skladequip", "t_sklad,s_typeequip", "t_sklad.id_typeequip = s_typeequip.id_typeequip and s_typeequip.typeequip = '" + dataGridSpecNaklad.CurrentRow.Cells[1].Value.ToString() + "' and t_sklad.equipment", dataGridSpecNaklad.CurrentRow.Cells[2].Value.ToString());

            if (!String.IsNullOrEmpty(textBoxEditSpecNakladCount.Text)
                && !String.IsNullOrEmpty(id_nakladnaya.ToString())
                && !String.IsNullOrEmpty(id_skladequip.ToString())
                && !String.IsNullOrEmpty(textBoxEditSpecNakladPrice.Text))
            {
                int log = DBConnection.EditTableSpecNaklad(key_r, id_nakladnaya, id_skladequip, Convert.ToInt32(textBoxEditSpecNakladCount.Text), Convert.ToInt32(textBoxEditSpecNakladPrice.Text));
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "В накладной №: '" + DBConnection.keyValue("numnaklad", "t_nakladnaya", "id_nakladnaya", id_nakladnaya.ToString()) + "' Оборудование: '" + equip + "' с количеством: '" + count + "' по цене: '" + price + "' было успешно обновлено на Оборудование: '" + comboBoxEditSpecNakladTypeEquip.Text + ' ' + comboBoxEditSpecNakladEquip.Text + "' с количество: '" + textBoxEditSpecNakladCount.Text + "' по цене: '" + textBoxEditSpecNakladPrice.Text + "'!");
                        if (DBConnection.edit("update t_sklad set count = count + '" + Convert.ToInt32(textBoxEditSpecNakladCount.Text) + "' where id_skladequip = '" + id_skladequip + "'"))
                        {
                            DBConnection.edit("update t_sklad set count = count - '" + count + "' where id_skladequip = '" + id_prevskladequip + "'");
                            if (count - Convert.ToInt32(textBoxEditSpecNakladCount.Text) > 0)
                            {
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "На складе оборудование: '" + comboBoxEditSpecNakladTypeEquip.Text + ' ' + comboBoxEditSpecNakladEquip.Text + "' было отгружено в количестве: '" + textBoxEditSpecNakladCount.Text + "'!");
                            }else
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "На склад оборудование: '" + comboBoxEditSpecNakladTypeEquip.Text + ' ' + comboBoxEditSpecNakladEquip.Text + "' поступило в количестве: '" + textBoxEditSpecNakladCount.Text + "'!");
                            DBConnection.ShowTableSklad();
                        }
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "В накладной №: '" + DBConnection.keyValue("numnaklad", "t_nakladnaya", "id_nakladnaya", id_nakladnaya.ToString()) + "' Оборудование: '" + equip + "' с количеством: '" + count + "' по цене: '" + price + "' обновить на Оборудование: '" + comboBoxEditSpecNakladTypeEquip.Text + ' ' + comboBoxEditSpecNakladEquip.Text + "' с количество: '" + textBoxEditSpecNakladCount.Text + "' по цене: '" + textBoxEditSpecNakladPrice.Text + "' не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "В накладной №: '" + DBConnection.keyValue("numnaklad", "t_nakladnaya", "id_nakladnaya", id_nakladnaya.ToString()) + "' Оборудование: '" + comboBoxEditSpecNakladTypeEquip.Text + ' ' + comboBoxEditSpecNakladEquip.Text + "' уже существует, обновление Оборудования: '" + equip + "' на Оборудование: '" + comboBoxEditSpecNakladTypeEquip.Text + ' ' + comboBoxEditSpecNakladEquip.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //При выборе Типа оборудования, в выпадающий список Оборудования для добавления выводятся оборудования этого типа
        private void comboBoxAddSpecNakladTypeEquip_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBConnection.equipFromType(comboBoxAddSpecNakladTypeEquip.Text);
            comboBoxAddSpecNakladEquip.DataSource = DBConnection.Equip;
            comboBoxAddSpecNakladEquip.DisplayMember = "Equipment";
        }
        //При выборе Типа оборудования, в выпадающий список Оборудования для редактирования выводятся оборудования этого типа
        private void comboBoxEditSpecNakladTypeEquip_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBConnection.equipFromType(comboBoxEditSpecNakladTypeEquip.Text);
            comboBoxEditSpecNakladEquip.DataSource = DBConnection.Equip;
            comboBoxEditSpecNakladEquip.DisplayMember = "Equipment";
        }
        //Отображение данных таблицы «Спецификация накладной» в таблицу
        private void PPTSpecNaklad_Load(object sender, EventArgs e)
        {
            Connect();
            comboBoxAddSpecNakladTypeEquip.DataSource = DBConnection.Typee;
            comboBoxAddSpecNakladTypeEquip.DisplayMember = "typeequip";
            comboBoxAddSpecNakladEquip.DataSource = DBConnection.t_Sklad;
            comboBoxAddSpecNakladEquip.DisplayMember = "equipment";
            comboBoxEditSpecNakladTypeEquip.DataSource = DBConnection.Typee;
            comboBoxEditSpecNakladTypeEquip.DisplayMember = "typeequip";
            comboBoxEditSpecNakladEquip.DataSource = DBConnection.t_Sklad;
            comboBoxEditSpecNakladEquip.DisplayMember = "equipment";
        }
        //Выбор строки записей в таблице
        private void dataGridSpecNaklad_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                comboBoxEditSpecNakladTypeEquip.Text = dataGridSpecNaklad.CurrentRow.Cells[1].Value.ToString();
                comboBoxEditSpecNakladEquip.Text = dataGridSpecNaklad.CurrentRow.Cells[2].Value.ToString();
                textBoxEditSpecNakladCount.Text = dataGridSpecNaklad.CurrentRow.Cells[4].Value.ToString();
                textBoxEditSpecNakladPrice.Text = dataGridSpecNaklad.CurrentRow.Cells[5].Value.ToString();
            }
        }
        //При выборе заголовка столбца правой кнопкой мыши выводится список для отбора записей
        int key;
        private void dataGridSpecNaklad_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.ColumnIndex != 0 && e.RowIndex == -1)
            {
                Filter.Items.Clear();
                switch (e.ColumnIndex)
                {
                    case (3):
                        {
                            DBConnection.ShowFilter("s_typeequip.typeequip", "t_specnakl,t_sklad,s_typeequip",
                            "where t_specnakl.id_nakladnaya = '" + DBConnection.NomNaklad + "' and t_specnakl.id_skladequip = t_sklad.id_skladequip and t_sklad.id_typeequip = s_typeequip.id_typeequip order by s_typeequip.typeequip");
                            key = 1;
                        }
                        break;
                    case (4):
                        {
                            DBConnection.ShowFilter("t_specnakl.count", "t_specnakl", "where t_specnakl.id_nakladnaya = '" + DBConnection.NomNaklad + "' order by t_specnakl.count");
                            key = 2;
                        }
                        break;
                    case (5):
                        {
                            DBConnection.ShowFilter("t_specnakl.price", "t_specnakl", "where t_specnakl.id_nakladnaya = '" + DBConnection.NomNaklad + "' order by t_specnakl.price");
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
                        DBConnection.ShowFilters("t_specnakl.id_specnakl,s_typeequip.typeequip,t_sklad.equipment, concat(s_typeequip.typeequip,' ', t_sklad.equipment) as 'type_equipment', t_specnakl.count, t_specnakl.price",
"t_specnakl,t_sklad,s_typeequip",
" where t_specnakl.id_nakladnaya = '" + DBConnection.NomNaklad + "' and t_specnakl.id_skladequip = t_sklad.id_skladequip and t_sklad.id_typeequip = s_typeequip.id_typeequip and s_typeequip.typeequip = '" + e.ClickedItem.Text + "' order by concat(s_typeequip.typeequip,' ', t_sklad.equipment)");
                    }
                    break;
                case (2):
                    {
                        DBConnection.ShowFilters("t_specnakl.id_specnakl,s_typeequip.typeequip,t_sklad.equipment, concat(s_typeequip.typeequip,' ', t_sklad.equipment) as 'type_equipment', t_specnakl.count, t_specnakl.price",
"t_specnakl,t_sklad,s_typeequip",
"where t_specnakl.id_nakladnaya = '" + DBConnection.NomNaklad + "' and t_specnakl.id_skladequip = t_sklad.id_skladequip and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_specnakl.count = '" + e.ClickedItem.Text + "' order by concat(s_typeequip.typeequip,' ', t_sklad.equipment)");
                    }
                    break;
                case (3):
                    {
                        DBConnection.ShowFilters("t_specnakl.id_specnakl,s_typeequip.typeequip,t_sklad.equipment, concat(s_typeequip.typeequip,' ', t_sklad.equipment) as 'type_equipment', t_specnakl.count, t_specnakl.price",
"t_specnakl,t_sklad,s_typeequip",
"where t_specnakl.id_nakladnaya = '" + DBConnection.NomNaklad + "' and t_specnakl.id_skladequip = t_sklad.id_skladequip and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_specnakl.price = '" + e.ClickedItem.Text + "' order by concat(s_typeequip.typeequip,' ', t_sklad.equipment)");
                    }
                    break;
            }
            dataGridSpecNaklad.DataSource = DBConnection.filters;
        }
        //Обновление данных в таблице
        private void btnUpdateSpecNaklad_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
        //Метод обновления данных
        private void RefreshTable()
        {
            DBConnection.ShowTableSpecNaklad(DBConnection.NomNaklad);
            Connect();
        }
        //Ограничение на ввод только цифр
        private void textBoxEditSpecNakladCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
                e.Handled = true;
        }
        //Ограничение на ввод только цифр
        private void textBoxAddSpecNakladCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
                e.Handled = true;
        }
        //Ограничение на ввод только цифр
        private void textBoxEditSpecNakladPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
                e.Handled = true;
        }
        //Ограничение на ввод только цифр
        private void textBoxAddSpecNakladPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
                e.Handled = true;
        }
        //Поиск записей в таблице
        private void btnSearchSpecNaklad_Click(object sender, EventArgs e)
        {
            Searching s = new Searching();
            s.searched = Program.SpecNaklad.dataGridSpecNaklad;
            s.ShowDialog();
        }
    }
}
