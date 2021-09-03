using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPOSpecAct : UserControl
    {
        public PPOSpecAct()
        {
            Program.SpecAct = this;
            InitializeComponent();
            Connect();
            dataGridSpecAct.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 12F, FontStyle.Bold);
            dataGridSpecAct.DefaultCellStyle.Font = new Font("Candara", 10F);
        }
        //Метод отображения данных таблицы «Акт» в таблицу
        public void Connect()
        {
            dataGridSpecAct.DataSource = DBConnection.o_SpecAct;
        }
        //Запуск таймера на открытия поля для добавления данных
        private void btnAddSpecAct_Click(object sender, EventArgs e)
        {
            groupEditSpecAct.Visible = false;
            groupAddSpecAct.Visible = true;
            if (tableLayoutSpecAct.RowStyles[0].Height == 100 && tableLayoutSpecAct.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Запуск таймера на открытия поля для редактирования данных
        private void btnEditSpecAct_Click(object sender, EventArgs e)
        {
            groupAddSpecAct.Visible = false;
            groupEditSpecAct.Visible = true;
            if (tableLayoutSpecAct.RowStyles[0].Height == 100 && tableLayoutSpecAct.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Открытие поля для добавления или редактирования данных
        private void timer1_Tick(object sender, EventArgs e)
        {
            tableLayoutSpecAct.RowStyles[1].Height += 17;
            tableLayoutSpecAct.RowStyles[0].Height -= 5;
            if (tableLayoutSpecAct.RowStyles[1].Height == 136 && tableLayoutSpecAct.RowStyles[0].Height == 60)
            {
                timer1.Stop();
            }
        }
        //Закрытие поля для добавления или редактирования данных
        private void timer2_Tick(object sender, EventArgs e)
        {
           tableLayoutSpecAct.RowStyles[1].Height -= 17;
            tableLayoutSpecAct.RowStyles[0].Height += 5;
            if (tableLayoutSpecAct.RowStyles[1].Height == 0 && tableLayoutSpecAct.RowStyles[0].Height == 100)
            {
                timer2.Stop();
            }
        }
        //Удаление выбранной записи из таблицы «Акт»
        private void btnDelSpecAct_Click(object sender, EventArgs e)
        {
            if (dataGridSpecAct.Rows.Count > 0)
            {
                if (dataGridSpecAct.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataGridSpecAct.SelectedRows.Count; i++)
                        {
                            int key_r = Convert.ToInt32(dataGridSpecAct.Rows[dataGridSpecAct.SelectedRows[i].Index].Cells[0].Value);
                            int Equip = DBConnection.keyRecord("t_sklad.id_skladequip", "t_sklad,s_typeequip", "t_sklad.id_typeequip = s_typeequip.id_typeequip and s_typeequip.typeequip = '" + dataGridSpecAct.CurrentRow.Cells[5].Value.ToString() + "' and t_sklad.equipment", dataGridSpecAct.CurrentRow.Cells[6].Value.ToString());

                            string eq = dataGridSpecAct.CurrentRow.Cells[2].Value.ToString();
                            string serial = dataGridSpecAct.CurrentRow.Cells[3].Value.ToString();
                            string state = dataGridSpecAct.CurrentRow.Cells[4].Value.ToString();
                            int price = Convert.ToInt32(dataGridSpecAct.CurrentRow.Cells[5].Value.ToString());

                            int log = DBConnection.DellTableSpecAct(key_r);
                            switch (log)
                            {
                                case (1):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У договора "+DBConnection.keyValue("nomdogovor", "t_dogovor", "id_dogovor", DBConnection.NomDogovor.ToString())+" У акта №: '" + DBConnection.keyValue("nomact", "t_akt", "id_akt", DBConnection.NomAct.ToString()) + "' Оборудование: '" + eq + "' Серийный номер: '" + serial + "' Состояние: '" + state + "' успешно удалено!");
                                    if (DBConnection.edit("update t_akt set stoimost = stoimost - '" + price + "' where id_akt = '" + DBConnection.NomAct + "'"))
                                        DBConnection.ShowTableAct(DBConnection.NomDogovor);
                                    if (DBConnection.edit("update t_sklad set count = count + 1 where id_skladequip = '" + Equip + "'"))
                                        DBConnection.ShowTableSklad();
                        Program.Act.color();
                                    RefreshTable();
                                    break;
                                case (2):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У договора " + DBConnection.keyValue("nomdogovor", "t_dogovor", "id_dogovor", DBConnection.NomDogovor.ToString()) + " У акта №: '" + DBConnection.keyValue("nomact", "t_akt", "id_akt", DBConnection.NomAct.ToString()) + "' Оборудование: '" + eq + "' Серийный номер: '" + serial + "' Состояние: '" + state + "' удалить не удалось!");
                                    break;
                                case (3):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У договора " + DBConnection.keyValue("nomdogovor", "t_dogovor", "id_dogovor", DBConnection.NomDogovor.ToString()) + " У акта №: '" + DBConnection.keyValue("nomact", "t_akt", "id_akt", DBConnection.NomAct.ToString()) + "' Оборудование: '" + eq + "' Серийный номер: '" + serial + "' Состояние: '" + state + "' связано с таблицей 'Архив списанного оборудования', удаление невозможно!");
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
        private void btnHideSpecAct_Click(object sender, EventArgs e)
        {
            if (Program.Dogovors.tableLayoutPanel1.ColumnStyles[0].Width > 0 || Program.Dogovors.tableLayoutPanel1.ColumnStyles[1].Width > 0)
            {
                Program.Dogovors.tableLayoutPanel1.ColumnStyles[2].Width = 0;
            }
        }
        //Открытие формы «Акт»
        private void OpenPrew_Click(object sender, EventArgs e)
        {
            Program.Dogovors.tableLayoutPanel1.ColumnStyles[1].Width = 50;
        }
        //Запуск таймера на закрытие поля для добавления или редактирования данных
        private void Close(object sender, EventArgs e)
        {
            if (tableLayoutSpecAct.RowStyles[1].Height == 136 && tableLayoutSpecAct.RowStyles[0].Height == 60)
            {
                timer2.Start();
            }
        }
        //Добавление данных в таблицу «Договора»
        private void addSpecAct_Click(object sender, EventArgs e)
        {
            int Act = Convert.ToInt32(DBConnection.NomAct);
            string equip = comboBoxAddSpecActTypeEquip.Text + " " + comboBoxAddSpecActEquip.Text;
            int Equip = DBConnection.keyRecord("id_skladequip", "t_sklad,s_typeequip", "concat(s_typeequip.typeequip,' ', t_sklad.equipment)", equip);
            int count = DBConnection.keyRecord("count", "t_sklad", "id_skladequip", Equip.ToString());
            int reasons = DBConnection.keyRecord("id_reasons", "s_reasons", "reasons", comboBoxAddSpecActReason.Text);
            int State = Convert.ToInt32(DBConnection.s_stateequip.Rows[comboBoxAddSpecActStateEquip.SelectedIndex].ItemArray.GetValue(0));

            int price = DBConnection.price(Equip);
            if (count > 0) {
                if (!String.IsNullOrEmpty(textBoxAddSpecActSerial.Text)
                && !String.IsNullOrEmpty(Equip.ToString())
                && !String.IsNullOrEmpty(State.ToString()))
            {
                int log = DBConnection.AddTableSpecAct(Act, Equip, textBoxAddSpecActSerial.Text, State, price, reasons);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У договора " + DBConnection.keyValue("nomdogovor", "t_dogovor", "id_dogovor", DBConnection.NomDogovor.ToString()) + " У акта №: '" + DBConnection.keyValue("nomact", "t_akt", "id_akt", DBConnection.NomAct.ToString()) + "' Оборудование: '" + equip + "' Серийный номер: '" + textBoxAddSpecActSerial.Text + "' Состояние: '" + comboBoxAddSpecActStateEquip.Text + "' было успешно добавлено!");

                        if ((DBConnection.NomTypeAct == 3 || DBConnection.NomTypeAct == 4) && checkBoxAdd.Checked == true)
                        {
                            int serial = DBConnection.keyRecord("id_specact", "t_specact", "serialscore", textBoxAddSpecActSerial.Text);
                            int log1 = DBConnection.AddTableArhivSE(serial, Equip, textBoxAddSpecActSerial.Text, DateTime.Now);
                            switch (log1)
                            {
                                case (1):
                                    DBConnection.ShowTableArhivSE();
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Оборудование: '" + equip + "' Серийный номер: '" + textBoxAddSpecActSerial.Text + "' было успешно списано и добавлено в архив!");
                                    break;
                                case (2):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Оборудование: '" + equip + "' Серийный номер: '" + textBoxAddSpecActSerial.Text + "' списать и добавить в архив не удалось!");
                                    break;
                                case (3):
                                    listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Оборудование: '" + equip + "' Серийный номер: '" + textBoxAddSpecActSerial.Text + "' уже существует, списание и добавление в архив невозможно!");
                                    break;
                            }
                        }
                        if (DBConnection.NomNaznach == 1 && DBConnection.NomTypeAct == 4)
                            price = 0;
                        if (DBConnection.edit("update t_akt set stoimost = stoimost + '" + price + "' where id_akt = '" + DBConnection.NomAct + "'"))
                            DBConnection.ShowTableAct(DBConnection.NomDogovor);

                        if (DBConnection.edit("update t_sklad set count = count - 1 where id_skladequip = '" + Equip + "'"))
                            DBConnection.ShowTableSklad();
                            comboBoxAddSpecActTypeEquip_SelectedIndexChanged(sender, e);
                        Program.Act.color();
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У договора " + DBConnection.keyValue("nomdogovor", "t_dogovor", "id_dogovor", DBConnection.NomDogovor.ToString()) + " У акта №: '" + DBConnection.keyValue("nomact", "t_akt", "id_akt", DBConnection.NomAct.ToString()) + "' Оборудование: '" + equip + "' Серийный номер: '" + textBoxAddSpecActSerial.Text + "' Состояние: '" + comboBoxAddSpecActStateEquip.Text + "' добавить не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У договора " + DBConnection.keyValue("nomdogovor", "t_dogovor", "id_dogovor", DBConnection.NomDogovor.ToString()) + " У акта №: '" + DBConnection.keyValue("nomact", "t_akt", "id_akt", DBConnection.NomAct.ToString()) + "' у Оборудования: '" + equip + "' Серийный номер: '" + textBoxAddSpecActSerial.Text + "' уже существует, добавление Оборудования: '" + equip + "' с Серийным номером: '" + textBoxAddSpecActSerial.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            }else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Оборудование на складе закончилось!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Редактирование данных в таблице «Договора»
        private void editSpecAct_Click(object sender, EventArgs e)
        {
            int key_r = Convert.ToInt32(dataGridSpecAct.CurrentRow.Cells[0].Value);
            int id_prevskladequip = DBConnection.keyRecord("id_skladequip", "t_sklad", "equipment", dataGridSpecAct.CurrentRow.Cells[6].Value.ToString());
            string equip = comboBoxEditSpecActTypeEquip.Text + " " + comboBoxEditSpecActEquip.Text;
            int Equip = DBConnection.keyRecord("id_skladequip", "t_sklad,s_typeequip", "concat(s_typeequip.typeequip,' ', t_sklad.equipment)", equip);
            int State = Convert.ToInt32(DBConnection.s_stateequip.Rows[comboBoxEditSpecActStateEquip.SelectedIndex].ItemArray.GetValue(0));
            int reasons = DBConnection.keyRecord("id_reasons", "s_reasons", "reasons", comboBoxEditSpecActReason.Text);
            int price = DBConnection.price(Equip);

            int id_specact = DBConnection.keyRecord("id_specact", "t_specact", "serialscore", textBoxEditSpecActSerial.Text);
            string equip1 = dataGridSpecAct.CurrentRow.Cells[2].Value.ToString();
            int Equip1 = DBConnection.keyRecord("id_skladequip", "t_sklad,s_typeequip", "concat(s_typeequip.typeequip,' ', t_sklad.equipment)", equip1);
            int id_state = DBConnection.keyRecord("id_stateequip", "s_stateequip", "stateequip", dataGridSpecAct.CurrentRow.Cells[4].Value.ToString());
            string serialscore = dataGridSpecAct.CurrentRow.Cells[3].Value.ToString();
            int price1 = Convert.ToInt32(dataGridSpecAct.CurrentRow.Cells[5].Value.ToString());
            int id_akt = DBConnection.keyRecord("id_akt", "t_akt,t_specact", "t_akt.id_akt = t_specact.id_act and serialscore", textBoxEditSpecActSerial.Text);
            int count = DBConnection.keyRecord("count", "t_sklad", "id_skladequip", Equip.ToString());
            if(count > 0) { 
            if (!String.IsNullOrEmpty(textBoxEditSpecActSerial.Text)
                && !String.IsNullOrEmpty(Equip.ToString())
                && !String.IsNullOrEmpty(State.ToString()))
            {
                int log = DBConnection.EditTableSpecAct(key_r, DBConnection.NomAct, Equip, textBoxEditSpecActSerial.Text, State, price/*, pricearenda*/, reasons);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У договора " + DBConnection.keyValue("nomdogovor", "t_dogovor", "id_dogovor", DBConnection.NomDogovor.ToString()) + " У акта №: '" + DBConnection.keyValue("nomact", "t_akt", "id_akt", DBConnection.NomAct.ToString()) + "' Оборудование: '" + equip1 + "' Серийный номер: '" + serialscore + "' Состояние: '" + dataGridSpecAct.CurrentRow.Cells[4].Value.ToString() + "' было успешно обновлено на Оборудование: '" + equip + "' Серийный номер: '" + textBoxEditSpecActSerial + "' Состояние: '" + comboBoxEditSpecActStateEquip.Text + "'!");

                        if (DBConnection.NomTypeAct == 4 || DBConnection.NomTypeAct == 3)
                        {
                            DBConnection.edit("Update t_specact SET  id_skladequip = '" + Equip1 + "', serialscore = '" + serialscore + "', id_stateequip = '" + id_state + "', price = '" + price1 + "', dateArend = 0  WHERE id_specact = '" + id_specact + "'");
                            if (DBConnection.NomNaznach != 1 && DBConnection.NomTypeAct != 4)
                            {
                                DBConnection.edit("update t_akt set stoimost = stoimost - '" + price1 + "' where id_akt = '" + DBConnection.NomAct + "'");
                                DBConnection.edit("update t_akt set stoimost = stoimost + '" + price + "' where id_akt = '" + DBConnection.NomAct + "'");
                            }
                            DBConnection.edit("update t_akt set stoimost = stoimost - '" + price + "' where id_akt = '" + id_akt + "'");
                            DBConnection.edit("update t_akt set stoimost = stoimost + '" + price1 + "' where id_akt = '" + id_akt + "'");
                            if (checkBoxEdit.Checked == true)
                            {
                                int serial = DBConnection.keyRecord("id_specact", "t_specact", "serialscore", textBoxEditSpecActSerial.Text);
                                int log1 = DBConnection.EditTableArhivSE(serial, Equip, textBoxEditSpecActSerial.Text, DateTime.Now, serialscore);
                                switch (log1)
                                {
                                    case (1):
                                        DBConnection.ShowTableArhivSE();
                                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Оборудование: '" + equip + "' Серийный номер: '" + textBoxEditSpecActSerial.Text + "' было успешно списано и обновлено в архив!");
                                        break;
                                    case (2):
                                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Оборудование: '" + equip + "' Серийный номер: '" + textBoxEditSpecActSerial.Text + "' списать и обновить в архив не удалось!");
                                        break;
                                    case (3):
                                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Оборудование: '" + equip + "' Серийный номер: '" + textBoxEditSpecActSerial.Text + "' уже существует, списание и обновление в архив невозможно!");
                                        break;
                                }
                            }
                            else
                            {
                                int key_r1 = DBConnection.keyRecord("id_arhivSE", "arhivse", "serialscore", serialscore);
                                DBConnection.DellTableArhivSE(key_r1);
                                        DBConnection.ShowTableArhivSE();
                            }
                        }
                        else
            if (DBConnection.edit("update t_akt set stoimost = stoimost - '" + Convert.ToInt32(dataGridSpecAct.CurrentRow.Cells[5].Value.ToString()) + "' where id_akt = '" + DBConnection.NomAct + "'"))
                            DBConnection.edit("update t_akt set stoimost = stoimost + '" + price + "' where id_akt = '" + DBConnection.NomAct + "'");
                        DBConnection.ShowTableAct(DBConnection.NomDogovor);

                        if (DBConnection.edit("update t_sklad set count = count - 1 where id_skladequip = '" + Equip + "'"))
                        {
                            DBConnection.edit("update t_sklad set count = count + 1 where id_skladequip = '" + id_prevskladequip + "'");
                            DBConnection.ShowTableSklad();
                        }
                        DBConnection.Types1();
                        comboBoxAddSpecActTypeEquip.DataSource = DBConnection.Typee1;
                        comboBoxAddSpecActTypeEquip.DisplayMember = "typeequip";
                        comboBoxEditSpecActTypeEquip.DataSource = DBConnection.Typee1;
                        comboBoxEditSpecActTypeEquip.DisplayMember = "typeequip";
                        comboBoxEditSpecActTypeEquip_SelectedIndexChanged(sender, e);

                        Program.Act.color();
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У договора " + DBConnection.keyValue("nomdogovor", "t_dogovor", "id_dogovor", DBConnection.NomDogovor.ToString()) + " У акта №: '" + DBConnection.keyValue("nomact", "t_akt", "id_akt", DBConnection.NomAct.ToString()) + "' Оборудование: '" + equip1 + "' Серийный номер: '" + serialscore + "' Состояние: '" + dataGridSpecAct.CurrentRow.Cells[4].Value.ToString() + "' обновить на Оборудование: '" + equip + "' Серийный номер: '" + textBoxEditSpecActSerial + "' Состояние: '" + comboBoxEditSpecActStateEquip.Text + "' не удалось!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
        }else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Оборудование на складе закончилось!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //При выборе Типа оборудования, в выпадающий список Оборудования для добавления выводятся оборудования этого типа
        private void comboBoxAddSpecActTypeEquip_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBConnection.equipFromType1(comboBoxAddSpecActTypeEquip.Text);
            comboBoxAddSpecActEquip.DataSource = DBConnection.Equip1;
            comboBoxAddSpecActEquip.DisplayMember = "Equipment";
        }
        //При выборе Типа оборудования, в выпадающий список Оборудования для редактирования выводятся оборудования этого типа
        private void comboBoxEditSpecActTypeEquip_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBConnection.equipFromType1(comboBoxEditSpecActTypeEquip.Text);
            comboBoxEditSpecActEquip.DataSource = DBConnection.Equip1;
            comboBoxEditSpecActEquip.DisplayMember = "Equipment";
        }
        //При выборе оборудования, в выпадающий список Серийный номер для добавления выводятся серийные номера этого оборудования
        private void comboBoxAddSpecActEquip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DBConnection.NomTypeAct == 3 || DBConnection.NomTypeAct == 4)
            {
                string equip = comboBoxAddSpecActTypeEquip.Text + " " + comboBoxAddSpecActEquip.Text;
                DBConnection.SerialScore(equip);
                comboBoxAddSpecActSerialScore.DataSource = DBConnection.serialscore;
                comboBoxAddSpecActSerialScore.DisplayMember = "serialscore";
            }
        }
        //При выборе оборудования, в выпадающий список Серийный номер для редактирования выводятся серийные номера этого оборудования
        private void comboBoxEditSpecActEquip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DBConnection.NomTypeAct == 3 || DBConnection.NomTypeAct == 4)
            {
                string equip = comboBoxEditSpecActTypeEquip.Text + " " + comboBoxEditSpecActEquip.Text;
                DBConnection.SerialScore(equip);
                comboBoxEditSpecActSerialScore.DataSource = DBConnection.serialscore;
                comboBoxEditSpecActSerialScore.DisplayMember = "serialscore";
            }
        }
        //При выборе серийного номера, в текстовое поле серийного номера для добавления заносится выбранный серийный номер
        private void comboBoxAddSpecActSerialScore_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxAddSpecActSerial.Text = comboBoxAddSpecActSerialScore.Text;
        }
        //При выборе серийного номера, в текстовое поле серийного номера для редактирования заносится выбранный серийный номер
        private void comboBoxEditSpecActSerialScore_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxEditSpecActSerial.Text = comboBoxEditSpecActSerialScore.Text;

        }
        //Отображение данных таблицы «Спецификация акта» в таблицу
        private void PPTSpecAct_Load(object sender, EventArgs e)
        {
            Connect();
            comboBoxAddSpecActNomAct.DataSource = DBConnection.o_Act;
            comboBoxAddSpecActNomAct.DisplayMember = "nomact";
            comboBoxAddSpecActStateEquip.DataSource = DBConnection.s_stateequip;
            comboBoxAddSpecActStateEquip.DisplayMember = "stateequip";
            comboBoxAddSpecActReason.DataSource = DBConnection.s_Reasons;
            comboBoxAddSpecActReason.DisplayMember = "reasons";

            comboBoxEditSpecActNomAct.DataSource = DBConnection.o_Act;
            comboBoxEditSpecActNomAct.DisplayMember = "nomact";
            comboBoxEditSpecActStateEquip.DataSource = DBConnection.s_stateequip;
            comboBoxEditSpecActStateEquip.DisplayMember = "stateequip";
            comboBoxEditSpecActReason.DataSource = DBConnection.s_Reasons;
            comboBoxEditSpecActReason.DisplayMember = "reasons";
        }
        //Выбор строки записей в таблице
        private void dataGridSpecAct_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                comboBoxEditSpecActNomAct.Text = dataGridSpecAct.CurrentRow.Cells[1].Value.ToString();
                comboBoxEditSpecActTypeEquip.Text = dataGridSpecAct.CurrentRow.Cells[6].Value.ToString();
                comboBoxEditSpecActEquip.Text = dataGridSpecAct.CurrentRow.Cells[7].Value.ToString();
                textBoxEditSpecActSerial.Text = dataGridSpecAct.CurrentRow.Cells[3].Value.ToString();
                comboBoxEditSpecActStateEquip.Text = dataGridSpecAct.CurrentRow.Cells[4].Value.ToString();
            }
        }
        //При выборе заголовка столбца правой кнопкой мыши выводится список для отбора записей
        int key;
        private void dataGridSpecAct_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.ColumnIndex != 0 && e.RowIndex == -1)
            {
                Filter.Items.Clear();
                switch (e.ColumnIndex)
                {
                    case (2):
                        {
                            DBConnection.ShowFilter("concat(s_typeequip.typeequip, ' ', t_sklad.equipment) as 'equipment'", "t_specact, t_akt, t_sklad, s_typeequip",
                                "where t_specact.id_act = t_akt.id_akt and t_specact.id_skladequip = t_sklad.id_skladequip and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_specact.id_act = '" + DBConnection.NomAct + "'");
                            key = 2;
                        }
                        break;
                    case (3):
                        {
                            DBConnection.ShowFilter("t_specact.serialscore", "t_specact", "where t_specact.id_act = '" + DBConnection.NomAct + "'");
                            key = 3;
                        }
                        break;
                    case (4):
                        {
                            DBConnection.ShowFilter("s_stateequip.stateequip", "t_specact,s_stateequip", "where t_specact.id_stateequip = s_stateequip.id_stateequip and t_specact.id_act = '" + DBConnection.NomAct + "'");
                            key = 4;
                        }
                        break;
                    case (5):
                        {
                            DBConnection.ShowFilter("t_specact.price", "t_specact", "where t_specact.id_act = '" + DBConnection.NomAct + "'");
                            key = 5;
                        }
                        break;
                    case (9):
                        {
                            DBConnection.ShowFilter("t_specact.dateArend", "t_specact", "where t_specact.id_act = '" + DBConnection.NomAct + "'");
                            key = 9;
                        }
                        break;
                    case (10):
                        {
                            DBConnection.ShowFilter("s_reasons.reasons", "t_specact,s_reasons", "where t_specact.id_reasons = s_reasons.id_reasons and t_specact.id_act = '" + DBConnection.NomAct + "'");
                            key = 10;
                        }
                        break;
                }
                if (e.ColumnIndex != 8) 
                { 
                for (int i = 0; i < DBConnection.filter.Rows.Count; i++)
                    Filter.Items.Add(new ToolStripMenuItem(DBConnection.filter.Rows[i].ItemArray.GetValue(0).ToString()));
                Filter.Show(MousePosition, ToolStripDropDownDirection.BelowRight);
            }
            }
        }
        //Отбор записей в таблице
        private void Filter_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (key)
            {
                case (2):
                    {
                        DBConnection.ShowFilters("t_specact.id_specact, t_akt.nomact,  concat(s_typeequip.typeequip,' ', t_sklad.equipment) as 'equipments', t_specact.serialscore, s_stateequip.stateequip, t_specact.price, s_typeequip.typeequip, t_sklad.equipment,t_specact.price/t_akt.arenda as 'pricearenda',t_specact.dateArend,s_reasons.reasons",
"t_specact, t_akt, t_sklad,s_stateequip,s_typeequip,s_reasons",
"where t_specact.id_act = t_akt.id_akt and t_specact.id_skladequip = t_sklad.id_skladequip and t_specact.id_stateequip = s_stateequip.id_stateequip and t_specact.id_reasons = s_reasons.id_reasons and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_specact.id_act = '" + DBConnection.NomAct + "' and concat(s_typeequip.typeequip, ' ', t_sklad.equipment) = '" + e.ClickedItem.Text + "'");
                    }
                    break;
                case (3):
                    {
                        DBConnection.ShowFilters("t_specact.id_specact, t_akt.nomact,  concat(s_typeequip.typeequip,' ', t_sklad.equipment) as 'equipments', t_specact.serialscore, s_stateequip.stateequip, t_specact.price, s_typeequip.typeequip, t_sklad.equipment,t_specact.price/t_akt.arenda as 'pricearenda',t_specact.dateArend,s_reasons.reasons",
        "t_specact, t_akt, t_sklad,s_stateequip,s_typeequip,s_reasons",
        "where t_specact.id_act = t_akt.id_akt and t_specact.id_skladequip = t_sklad.id_skladequip and t_specact.id_stateequip = s_stateequip.id_stateequip and t_specact.id_reasons = s_reasons.id_reasons and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_specact.id_act = '" + DBConnection.NomAct + "' and t_specact.serialscore = '" + e.ClickedItem.Text + "'");
                    }
                    break;
                case (4):
                    {
                        DBConnection.ShowFilters("t_specact.id_specact, t_akt.nomact,  concat(s_typeequip.typeequip,' ', t_sklad.equipment) as 'equipments', t_specact.serialscore, s_stateequip.stateequip, t_specact.price, s_typeequip.typeequip, t_sklad.equipment,t_specact.price/t_akt.arenda as 'pricearenda',t_specact.dateArend,s_reasons.reasons",
        "t_specact, t_akt, t_sklad,s_stateequip,s_typeequip,s_reasons",
        "where t_specact.id_act = t_akt.id_akt and t_specact.id_skladequip = t_sklad.id_skladequip and t_specact.id_stateequip = s_stateequip.id_stateequip and t_specact.id_reasons = s_reasons.id_reasons and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_specact.id_act = '" + DBConnection.NomAct + "' and s_stateequip.stateequip = '" + e.ClickedItem.Text + "'");
                    }
                    break;
                case (5):
                    {
                        DBConnection.ShowFilters("t_specact.id_specact, t_akt.nomact,  concat(s_typeequip.typeequip,' ', t_sklad.equipment) as 'equipments', t_specact.serialscore, s_stateequip.stateequip, t_specact.price, s_typeequip.typeequip, t_sklad.equipment,t_specact.price/t_akt.arenda as 'pricearenda',t_specact.dateArend,s_reasons.reasons",
"t_specact, t_akt, t_sklad,s_stateequip,s_typeequip,s_reasons",
"where t_specact.id_act = t_akt.id_akt and t_specact.id_skladequip = t_sklad.id_skladequip and t_specact.id_stateequip = s_stateequip.id_stateequip and t_specact.id_reasons = s_reasons.id_reasons and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_specact.id_act = '" + DBConnection.NomAct + "' and t_specact.price = '" + e.ClickedItem.Text + "'");
                    }
                    break;
                case (9):
                    {
                        DBConnection.ShowFilters("t_specact.id_specact, t_akt.nomact,  concat(s_typeequip.typeequip,' ', t_sklad.equipment) as 'equipments', t_specact.serialscore, s_stateequip.stateequip, t_specact.price, s_typeequip.typeequip, t_sklad.equipment,t_specact.price/t_akt.arenda as 'pricearenda',t_specact.dateArend,s_reasons.reasons",
        "t_specact, t_akt, t_sklad,s_stateequip,s_typeequip,s_reasons",
        "where t_specact.id_act = t_akt.id_akt and t_specact.id_skladequip = t_sklad.id_skladequip and t_specact.id_stateequip = s_stateequip.id_stateequip and t_specact.id_reasons = s_reasons.id_reasons and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_specact.id_act = '" + DBConnection.NomAct + "' and t_specact.dateArend = '" + Convert.ToDateTime(e.ClickedItem.Text).ToString("yyyy.MM.dd") + "'  order by typeequip");
                    }
                    break;
                case (10):
                    {
                        DBConnection.ShowFilters("t_specact.id_specact, t_akt.nomact,  concat(s_typeequip.typeequip,' ', t_sklad.equipment) as 'equipments', t_specact.serialscore, s_stateequip.stateequip, t_specact.price, s_typeequip.typeequip, t_sklad.equipment,t_specact.price/t_akt.arenda as 'pricearenda',t_specact.dateArend,s_reasons.reasons",
        "t_specact, t_akt, t_sklad,s_stateequip,s_typeequip,s_reasons",
        "where t_specact.id_act = t_akt.id_akt and t_specact.id_skladequip = t_sklad.id_skladequip and t_specact.id_stateequip = s_stateequip.id_stateequip and t_specact.id_reasons = s_reasons.id_reasons and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_specact.id_act = '" + DBConnection.NomAct + "' and s_reasons.reasons = '" + e.ClickedItem.Text + "'  order by typeequip");
                    }
                    break;
            }
            dataGridSpecAct.DataSource = DBConnection.filters;
        }
        //Обновление данных в таблице
        private void btnUpdateSpecAct_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
        //Метод обновления данных
        private void RefreshTable()
        {
            DBConnection.ShowTableSpecAct(DBConnection.NomAct);
            Connect();
        }
        //Поиск записей в таблице
        private void btnSearchSpecAct_Click(object sender, EventArgs e)
        {
            Searching s = new Searching();
            s.searched = Program.SpecAct.dataGridSpecAct;
            s.ShowDialog();
        }
        //Ограничение на ввод только цифр
        private void textBoxEditSpecActSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
                e.Handled = true;
        }
        //Ограничение на ввод только цифр
        private void textBoxAddSpecActSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
