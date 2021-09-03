using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPTStatusAD : UserControl
    {
        public PPTStatusAD()
        {
            Program.StatusAD = this;
            InitializeComponent();
            Connect();
            dataGridStatusAD.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 12F, FontStyle.Bold);
            dataGridStatusAD.DefaultCellStyle.Font = new Font("Candara", 10F);
        }
        //Метод отображения данных таблицы «Статус» в таблицу, заполняет столбец «Цвет» соответсвующими цветами
        public void Connect()
        {
            dataGridStatusAD.DataSource = DBConnection.t_StatusAD;
            if (dataGridStatusAD.RowCount != 0)
                for (int i = 0; i < dataGridStatusAD.Rows.Count; i++)
                {
                    if (dataGridStatusAD.Rows[i].Cells[3].Value.ToString() != "")
                        dataGridStatusAD.Rows[i].Cells[0].Style.BackColor = Color.FromArgb(Convert.ToInt32(dataGridStatusAD.Rows[i].Cells[3].Value));
                }
        }
        //Запуск таймера на открытия поля для добавления данных
        private void btnAddStatusAD_Click(object sender, EventArgs e)
        {
            groupEditStatusAD.Visible = false;
            groupAddStatusAD.Visible = true;
            if (tableLayoutStatusAD.RowStyles[0].Height == 100 && tableLayoutStatusAD.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Запуск таймера на открытия поля для редактирования данных
        private void btnEditStatusAD_Click(object sender, EventArgs e)
        {
            groupAddStatusAD.Visible = false;
            groupEditStatusAD.Visible = true;
            if (tableLayoutStatusAD.RowStyles[0].Height == 100 && tableLayoutStatusAD.RowStyles[1].Height == 0)
            {
                timer1.Start();
            }
        }
        //Открытие поля для добавления или редактирования данных
        private void timer1_Tick(object sender, EventArgs e)
        {
            tableLayoutStatusAD.RowStyles[1].Height += 17;
            tableLayoutStatusAD.RowStyles[0].Height -= 5;
            if (tableLayoutStatusAD.RowStyles[1].Height == 136 && tableLayoutStatusAD.RowStyles[0].Height == 60)
            {
                timer1.Stop();
            }
        }
        //Закрытие поля для добавления или редактирования данных
        private void timer2_Tick(object sender, EventArgs e)
        {
            tableLayoutStatusAD.RowStyles[1].Height -= 17;
            tableLayoutStatusAD.RowStyles[0].Height += 5;
            if (tableLayoutStatusAD.RowStyles[1].Height == 0 && tableLayoutStatusAD.RowStyles[0].Height == 100)
            {
                timer2.Stop();
            }
        }
        //Удаление выбранной записи из таблицы «Статус»
        private void btnDelStatusAD_Click(object sender, EventArgs e)
        {
            if (dataGridStatusAD.Rows.Count > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridStatusAD.SelectedCells.Count; i++)
                    {
                        int key_r = Convert.ToInt32(dataGridStatusAD.Rows[dataGridStatusAD.SelectedCells[i].RowIndex].Cells[1].Value);
                        string status = dataGridStatusAD.CurrentRow.Cells[2].Value.ToString();
                        int log = DBConnection.DellTableStatusAD(key_r);
                        switch (log)
                        {
                            case (1):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Статус '" + status + "' успешно удален!");
                                RefreshTable();
                                break;
                            case (2):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Статус '" + status + "' удалить не удалось!");
                                break;
                            case (3):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У статуса '" + status + "' имеется связь с таблицей 'Акт', удаление невозможно!");
                                break;
                            case (4):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "У статуса '" + status + "' имеется связь с таблицей 'Договора', удаление невозможно!");
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
        private void btnHideStatusAD_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        //Запуск таймера на закрытие поля для добавления или редактирования данных
        private void Close(object sender, EventArgs e)
        {
            if (tableLayoutStatusAD.RowStyles[1].Height == 136 && tableLayoutStatusAD.RowStyles[0].Height == 60)
            {
                timer2.Start();
            }
        }
        //Добавление данных в таблицу «Статус»
        private void addStatusAD_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxAddStatusADStatus.Text)
             && !String.IsNullOrEmpty(ButtonAddStatusADColor.BackColor.ToArgb().ToString()))
            {
                int log = DBConnection.AddTableStatusAD(textBoxAddStatusADStatus.Text, ButtonAddStatusADColor.BackColor.ToArgb().ToString());
                switch (log)
                {
                    case (1):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Статус '" + textBoxAddStatusADStatus.Text + "' был успешно добавлен!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Статус '" + textBoxAddStatusADStatus.Text + "' добавить не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Статус '" + textBoxAddStatusADStatus.Text + "' или выбранный цвет уже существует, добавление '" + textBoxAddStatusADStatus.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Редактирование данных в таблице «Статус»
        private void editStatusAD_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxEditStatusADStatus.Text)
             && !String.IsNullOrEmpty(ButtonEditStatusADColor.BackColor.ToArgb().ToString()))
            {
                int key_r = Convert.ToInt32(dataGridStatusAD.CurrentRow.Cells[1].Value);
                string status = dataGridStatusAD.CurrentRow.Cells[2].Value.ToString();
                int log = DBConnection.EditTableStatusAD(key_r, textBoxEditStatusADStatus.Text, ButtonEditStatusADColor.BackColor.ToArgb().ToString());
                switch (log)
                {
                    case (1):
                        if (textBoxEditStatusADStatus.Text == status)
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Цвет статуса '" + status + "' был успешно обновлен!");
                        else
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Статус '" + status + "' был успешно обновлен на '" + textBoxEditStatusADStatus.Text + "'!");
                        RefreshTable();
                        break;
                    case (2):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Статус '" + status + "' обновить на '" + textBoxEditStatusADStatus.Text + "' не удалось!");
                        break;
                    case (3):
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Статус '" + textBoxEditStatusADStatus.Text + "' или выбранный цвет уже существует, обновление '" + status + "' на '" + textBoxEditStatusADStatus.Text + "' невозможно!");
                        break;
                }
            }
            else
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Поле не может быть пустым!");
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        //Отображение данных таблицы «Статус» в таблицу
        private void PPTStatusAD_Load(object sender, EventArgs e)
        {
            Connect();
        }
        //Выбор строки записей в таблице
        private void dataGridStatusAD_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                textBoxEditStatusADStatus.Text = dataGridStatusAD.CurrentRow.Cells[2].Value.ToString();
                ButtonEditStatusADColor.BackColor = dataGridStatusAD.CurrentRow.Cells[0].Style.BackColor;
            }
        }
        //Обновление данных в таблице
        private void btnUpdateStatusAD_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
        //Метод обновления данных
        private void RefreshTable()
        {
            DBConnection.ShowTableStatusAD();
            Connect();
        }
        //Поиск записей в таблице
        private void btnSearchStatusAD_Click(object sender, EventArgs e)
        {
            Searching s = new Searching();
            s.searched = Program.StatusAD.dataGridStatusAD;
            s.ShowDialog();
        }
        //Выбор цвета для добавления при нажатии на кнопку
        private void ButtonAddStatusADColor_Click(object sender, EventArgs e)
        {
            if (colorRecord.ShowDialog() == DialogResult.Cancel)
                return;
            ButtonAddStatusADColor.BackColor = colorRecord.Color;
        }
        //Выбор цвета для редактирования при нажатии на кнопку
        private void ButtonEditStatusADColor_Click(object sender, EventArgs e)
        {
            if (colorRecord.ShowDialog() == DialogResult.Cancel)
                return;
            ButtonEditStatusADColor.BackColor = colorRecord.Color;
        }
        //Ограничение на ввод только кириллицы
        private void textBoxEditStatusADStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8)
                e.Handled = true;
        }
        //Ограничение на ввод только кириллицы
        private void textBoxAddStatusADStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
