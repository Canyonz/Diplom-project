using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPSTypeAct : UserControl
    {
        public PPSTypeAct()
        {
            Program.typeact = this;
            InitializeComponent();
            dataGridTypeAct.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 12F, FontStyle.Bold) ;
            dataGridTypeAct.DefaultCellStyle.Font = new Font("Candara", 10F);
        }
        //Запуск таймера на открытия поля для добавления данных
        private void btnAddTypeAct_Click(object sender, EventArgs e)
        {
            groupEditTypeA.Visible = false;
            groupAddTypeA.Visible = true;
            if (tableLayoutTypeAct.RowStyles[0].Height == 100 && tableLayoutTypeAct.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Открытие поля для добавления или редактирования данных
        private void timer1_Tick(object sender, EventArgs e)
        {
            tableLayoutTypeAct.RowStyles[1].Height += 17;
            tableLayoutTypeAct.RowStyles[0].Height -= 5;
            if (tableLayoutTypeAct.RowStyles[1].Height == 136 && tableLayoutTypeAct.RowStyles[0].Height == 60)
            {
                timer1.Stop();
            }
        }
        //Запуск таймера на закрытие поля для добавления или редактирования данных
        private void Close(object sender, EventArgs e)
        {
            if (tableLayoutTypeAct.RowStyles[1].Height == 136 && tableLayoutTypeAct.RowStyles[0].Height == 60)
            {
                timer2.Start();
            }
        }
        //Закрытие поля для добавления или редактирования данных
        private void timer2_Tick(object sender, EventArgs e)
        {
            tableLayoutTypeAct.RowStyles[1].Height -= 17;
            tableLayoutTypeAct.RowStyles[0].Height += 5;
            if (tableLayoutTypeAct.RowStyles[1].Height == 0 && tableLayoutTypeAct.RowStyles[0].Height == 100)
            {
                timer2.Stop();
            }
        }
        //Запуск таймера на открытия поля для редактирования данных
        private void btnEditTypeAct_Click(object sender, EventArgs e)
        {
            groupAddTypeA.Visible = false;
            groupEditTypeA.Visible = true;
            if (tableLayoutTypeAct.RowStyles[0].Height == 100 && tableLayoutTypeAct.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Удаление выбранной записи из справочника «Тип акта»
        private void btnDelTypeAct_Click(object sender, EventArgs e)
        {
            if (dataGridTypeAct.Rows.Count > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridTypeAct.SelectedCells.Count; i++)
                    {
                        int key_r = Convert.ToInt32(dataGridTypeAct.Rows[dataGridTypeAct.SelectedCells[i].RowIndex].Cells[0].Value);
                        string type = dataGridTypeAct.CurrentRow.Cells[1].Value.ToString();
                        int log = DBConnection.DellTableTypeAct(key_r);
                        switch (log)
                        {
                            case (1):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Тип акта '" + type + "' успешно удален!");
                                RefreshTable();
                                break;
                            case (2):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Тип акта '" + type + "' удалить не удалось!");
                                break;
                            case (3):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У типа акта '" + type + "' имеется связь с таблицей 'Акт', удаление невозможно!");
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
        private void btnHideTypeAct_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        //Добавление данных в справочник «Тип акта»
        private void addTypeAct_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textAddTypeAct.Text))
            {
                int log = DBConnection.AddTableTypeAct(textAddTypeAct.Text);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Тип акта '" + textAddTypeAct.Text + "' был успешно добавлен!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Тип акта '" + textAddTypeAct.Text + "' добавить не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Тип акта '" + textAddTypeAct.Text + "' уже существует, добавление '" + textAddTypeAct.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Редактирование данных в справочнике «Тип акта»
        private void editTypeAct_Click(object sender, EventArgs e)
        {
            int key_r = Convert.ToInt32(dataGridTypeAct.CurrentRow.Cells[0].Value);
            string type = dataGridTypeAct.CurrentRow.Cells[1].Value.ToString();
            if (!String.IsNullOrEmpty(textEditTypeAct.Text))
            {
                int log = DBConnection.EditTableTypeAct(key_r, textEditTypeAct.Text);
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Тип акта '" + type + "' был успешно обновлен на '" + textEditTypeAct.Text + "'!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Тип акта '" + type + "' обновить на '" + textEditTypeAct.Text + "' не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Тип акта '" + textEditTypeAct.Text + "' уже существует, обновление '" + type + "' на '" + textEditTypeAct.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Отображение данных справочника «Тип акта» в таблицу
        private void PPSTypeAct_Load(object sender, EventArgs e)
        {
            dataGridTypeAct.DataSource = DBConnection.s_TypeAct;
        }
        //Обновление данных в таблице
        private void btnUpdateTypeAct_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
        //Метод обновления данных
        private void RefreshTable()
        {
            DBConnection.ShowTableTypeAct();
            dataGridTypeAct.DataSource = DBConnection.s_TypeAct;
        }
        //Ограничение на ввод только кириллицы
        private void textAddTypeAct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Ограничение на ввод только кириллицы
        private void textEditTypeAct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Открытие формы для поиска данных в таблице
        private void btnSearchTypeAct_Click(object sender, EventArgs e)
        {
            Searching s = new Searching();
            s.searched = Program.typeact.dataGridTypeAct;
            s.ShowDialog();
        }
        //Выбор строки записей в таблице
        private void dataGridTypeAct_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textEditTypeAct.Text = dataGridTypeAct.CurrentRow.Cells[1].Value.ToString();
            }
        }
    }
}
