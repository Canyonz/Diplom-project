using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPSDelivery : UserControl
    {
        public PPSDelivery()
        {
            Program.delivery = this;
            InitializeComponent();
            dataGridDelivery.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 13F);
            dataGridDelivery.DefaultCellStyle.Font = new Font("Arial", 12F);
        }

        //ПОДКЛЮЧЕНИЕ К ТАБЛИЦЕ В БАЗЕ ДАННЫХ И ОБНОВЛЕНИЕ ДАННЫХ В ТАБЛИЦЕ
        private void Connect()
        {
            DBConnection.ShowTableDelivery();
            dataGridDelivery.DataSource = DBConnection.s_Delivery;
        }


        //ОТКРЫТИЕ ПОЛЯ ДЛЯ ДОБАВЛЕНИЯ ДАННЫХ
        private void btnAddDelivery_Click(object sender, EventArgs e)
        {
            showAddDelivery_Click(sender, e);
            if (tableLayoutDelivery.ColumnStyles[0].Width == 100 && tableLayoutDelivery.ColumnStyles[1].Width == 0)
            {
                timer1.Start();
                hideShow.Visible = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tableLayoutDelivery.ColumnStyles[1].Width += 25;
            tableLayoutDelivery.ColumnStyles[0].Width -= 25;
            if (tableLayoutDelivery.ColumnStyles[1].Width >= 50 && tableLayoutDelivery.ColumnStyles[0].Width <= 50)
            {
                timer1.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            tableLayoutDelivery.ColumnStyles[1].Width -= 10;
            tableLayoutDelivery.ColumnStyles[0].Width += 10;
            if (tableLayoutDelivery.ColumnStyles[1].Width <= 0 || tableLayoutDelivery.ColumnStyles[0].Width >= 100)
            {
                timer2.Stop();
            }
        }

        //ОТКРЫТИЕ ПОЛЯ ДЛЯ РЕДАКТИРОВАНИЯ ДАННЫХ
        private void btnEditDelivery_Click(object sender, EventArgs e)
        {
            showEditDelivery_Click(sender, e);
            if (tableLayoutDelivery.ColumnStyles[0].Width == 100 && tableLayoutDelivery.ColumnStyles[1].Width == 0)
            {
                timer1.Start();
                hideShow.Visible = true;
            }
        }

        //ОТКРЫТИЕ ПОЛЯ ДЛЯ УДАЛЕНИЯ ДАННЫХ
        private void btnDelDelivery_Click(object sender, EventArgs e)
        {
            showDelDelivery_Click(sender, e);
            if (tableLayoutDelivery.ColumnStyles[0].Width == 100 && tableLayoutDelivery.ColumnStyles[1].Width == 0)
            {
                timer1.Start();
                hideShow.Visible = true;
            }
        }

        //ЗАКРЫТИЕ ФОРМЫ
        private void btnHideDelivery_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        //ПОИСК
        private void btnSearchDelivery_Click(object sender, EventArgs e)
        {
            Searching s = new Searching();
            s.searched = Program.delivery.dataGridDelivery;
            s.ShowDialog();
        }

        //ОТКРЫТИЕ ПОЛЯ ДЛЯ ДОБАВЛЕНИЯ ДАННЫХ
        private void showAddDelivery_Click(object sender, EventArgs e)
        {
            panelAddDelivery.Visible = true;
            panelEditDelivery.Visible = false;
            panelDelDelivery.Visible = false;
        }

        //ОТКРЫТИЕ ПОЛЯ ДЛЯ РЕДАКТИРОВАНИЯ ДАННЫХ
        private void showEditDelivery_Click(object sender, EventArgs e)
        {
            panelAddDelivery.Visible = false;
            panelEditDelivery.Visible = true;
            panelDelDelivery.Visible = false;
        }

        //ОТКРЫТИЕ ПОЛЯ ДЛЯ УДАЛЕНИЯ ДАННЫХ
        private void showDelDelivery_Click(object sender, EventArgs e)
        {
            panelAddDelivery.Visible = false;
            panelEditDelivery.Visible = false;
            panelDelDelivery.Visible = true;
        }

        //ЗАКРЫТИЕ ПОЛЯ ДЛЯ РЕДАКТИРОАНИЯ ТАБЛИЦЫ
        private void hideShow_Click(object sender, EventArgs e)
        {
            if (tableLayoutDelivery.ColumnStyles[0].Width == 50 && tableLayoutDelivery.ColumnStyles[1].Width == 50)
            {
                timer2.Start();
                hideShow.Visible = false;
            }
        }

        //ДОБАВЛЕНИЕ ЗАПИСИ В ТАБЛИЦУ
        private void addDelivery_Click(object sender, EventArgs e)
        {
            if (DBConnection.AddTableDelivery(textAddDelivery.Text, true))
            {
            Connect();
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " Запись '" + textAddDelivery.Text + "' была успешно добавлена!");
            }
        }

        //РЕДАКТИРОВАНИЕ ЗАПИСИ В ТАБЛИЦЕ
        private void editDelivery_Click(object sender, EventArgs e)
        {
            int key_r = Convert.ToInt32(dataGridDelivery.CurrentRow.Cells[0].Value);
            if (DBConnection.EditTableDelivery(key_r, textEditDelivery.Text))
            {
            Connect();
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " Запись '" + textEditDelivery.Text + "' была успешно обновлена!");
            }
        }

        //ПОДТВЕРЖЕНИЕ НА УДАЛЕНИЕ ЗАПИСИ ИЗ ТАБЛИЦЫ
        private void delDeliveryY_Click(object sender, EventArgs e)
        {
                if (DBConnection.s_Delivery.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridDelivery.SelectedCells.Count; i++)
                    {
                        int key_r = Convert.ToInt32(dataGridDelivery.Rows[dataGridDelivery.SelectedCells[i].RowIndex].Cells[0].Value);
                        string deli = dataGridDelivery.Rows[dataGridDelivery.SelectedCells[i].RowIndex].Cells[1].Value.ToString();
                        if (DBConnection.DellTableDelivery(key_r, deli, true))
                        {
                    Connect();
                            listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " Запись '" + deli + "' была успешно удалена!");
                    }
                    }
                }
                else
                {
                    MessageBox.Show("В таблице нет записей!");
                }
            hideShow_Click(sender, e);
        }

        //ОТМЕНА УДАЛЕНИЯ ЗАПИСИ ИЗ ТАБЛИЦЫ
        private void delDeliveryN_Click(object sender, EventArgs e)
        {
            hideShow_Click(sender, e);
        }

        private void PPSDelivery_Load(object sender, EventArgs e)
        {
            dataGridDelivery.DataSource = DBConnection.s_Delivery;
        }

        //ЭКСПОРТ В ЭКСЕЛЬ
        private void btnExportDelivery_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridDelivery.Rows.Count > 0)
                {
                    Microsoft.Office.Interop.Excel.Application csv = new Microsoft.Office.Interop.Excel.Application();
                    csv.Application.Workbooks.Add(Type.Missing);
                    csv.DefaultSaveFormat = Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel8;
                    Microsoft.Office.Interop.Excel.Worksheet csvName = csv.Worksheets["Лист1"];
                    csvName.Name = "УсловияВыдачи";
                    csv.Cells[1, 1] = "№";
                    csv.Cells[1, 2] = dataGridDelivery.Columns[1].HeaderText.ToString();
                    for (int i = 0; i < dataGridDelivery.Rows.Count; i++)
                    {
                            csv.Cells[i + 2, 1] = i + 1;
                        for (int j = 1; j < dataGridDelivery.Columns.Count; j++)
                        {
                            csv.Cells[i + 2, j + 1] = dataGridDelivery.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    csv.Columns.AutoFit();
                    csv.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Произошла ошибка!");
            }
        }

        //ИМПОРТ ИЗ ЭКСЕЛЯ
        private void btnImportDelivery_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog OFDialog = new OpenFileDialog();
                if (OFDialog.ShowDialog() == DialogResult.OK)
                {
                    //Excel 97-2003 XLS
                    string ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source= " + OFDialog.FileName + " ;Extended Properties=\"Excel 8.0;HDR = Yes;\";";
                    //Excel 2013
                    //XLSX
                    //string sConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + OFDialog.FileName + "; Extended Properties = \"Excel 12.0 Xml;HDR=YES\";";
                    //XSLB
                    //string sConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + OFDialog.FileName + "; Extended Properties = \"Excel 12.0;HDR=YES\";";

                    using (OleDbConnection Connect = new OleDbConnection(ConnectionString))
                    {
                        OleDbDataAdapter Adapter = new OleDbDataAdapter("SELECT * FROM [Условия выдачи$] ", Connect);
                        DataTable dt = new DataTable();
                        Adapter.Fill(dt);
                        dataGridDelivery.DataSource = dt;
                        dataGridDelivery.Columns[0].Visible = false;
                    }
                }
           }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Произошла ошибка!");
            }
        }

        //ОБНОВЛЕНИЕ ТАБЛИЦЫ
        private void btnUpdateDelivery_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }

        //ОБНОВЛЕНИЕ
        private void RefreshTable()
        {
            dataGridDelivery.DataSource = null;
            dataGridDelivery.Columns.Clear();
            dataGridDelivery.ColumnCount = 2;
            dataGridDelivery.Columns[0].Name = "Номер условия выдачи";
            dataGridDelivery.Columns[0].DataPropertyName = "key_deli";
            dataGridDelivery.Columns[0].Visible = false;
            dataGridDelivery.Columns[1].Name = "Условие выдачи";
            dataGridDelivery.Columns[1].DataPropertyName = "delivery";
            Connect();
        }

        //СОХРАНЕНИЕ
        private void saveDelivery_Click(object sender, EventArgs e)
        {
            if (dataGridDelivery.DataSource == DBConnection.s_Delivery)
            {
                MessageBox.Show("Сохранение прошло успешно!");
            }
            else
            {
                bool del;
                for (int i = 0; i < DBConnection.s_Delivery.Rows.Count; i++)
                {
                    del = true;
                    for (int j = 0; j < dataGridDelivery.Rows.Count; j++)
                    {
                        if (j < DBConnection.s_Delivery.Rows.Count)
                        {
                            if (DBConnection.s_Delivery.Rows[j].Field<string>(1) == dataGridDelivery.Rows[j].Cells[1].Value.ToString())
                            {
                                del = false;
                                break;
                            }
                        }
                    }
                    if (del == true)
                    {
                        int key_r = Convert.ToInt32(DBConnection.s_Delivery.Rows[i].Field<int>(0));
                        string deli = DBConnection.s_Delivery.Rows[i].Field<string>(1);
                        DBConnection.DellTableDelivery(key_r, deli, false);
                    }
                }
                for (int i = 0; i < dataGridDelivery.Rows.Count; i++)
                {
                    if (DBConnection.AddTableDelivery(dataGridDelivery.Rows[i].Cells[1].Value.ToString(), false))
                    {
                        listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " Запись '" + dataGridDelivery.Rows[i].Cells[1].Value.ToString() + "' была успешно добавлена!");
                    }
                }
                MessageBox.Show("Сохранение прошло успешно!");
                RefreshTable();
            }
        }

        //ВВОД ТОЛЬКО ДОПУСТИМЫХ СИМВОЛОВ
        private void textAddDelivery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8)
                e.Handled = true;
        }

        //ВВОД ТОЛЬКО ДОПУСТИМЫХ СИМВОЛОВ
        private void textEditDelivery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8)
                e.Handled = true;
        }

        private void dataGridDelivery_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textEditDelivery.Text = dataGridDelivery.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
