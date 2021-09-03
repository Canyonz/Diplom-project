using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class ArhivSpisEquip : UserControl
    {
        public ArhivSpisEquip()
        {
            Program.ArhivSE = this;
            InitializeComponent();
            dataGridArhivSE.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 12F, FontStyle.Bold);
            dataGridArhivSE.DefaultCellStyle.Font = new Font("Candara", 10F);
        }
        //Удаление выбранной записи из таблицы «Архив»
        private void btnDelArhivSE_Click(object sender, EventArgs e)
        {
            if (dataGridArhivSE.Rows.Count > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridArhivSE.SelectedCells.Count; i++)
                    {
                        int key_r = Convert.ToInt32(dataGridArhivSE.Rows[dataGridArhivSE.SelectedCells[i].RowIndex].Cells[0].Value);
                        string equip = dataGridArhivSE.CurrentRow.Cells[3].Value.ToString();
                        string serial = dataGridArhivSE.CurrentRow.Cells[4].Value.ToString();
                        int log = DBConnection.DellTableArhivSE(key_r);
                        switch (log)
                        {
                            case (1):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Списанное Оборудование '" + equip + "' с Серийным номером '" + serial + "' из архива было успешно удалено!");
                                RefreshTable();
                                break;
                            case (2):
                                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss : ") + "Списанное Оборудование '" + equip + "' с Серийным номером '" + serial + "' из архива удалить не удалось!");
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
        private void btnHideArhivSE_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        //Отображение данных таблицы «Архив» в таблицу
        private void PPSArhivSE_Load(object sender, EventArgs e)
        {
            dataGridArhivSE.DataSource = DBConnection.ArhivSE;
        }
        //Обновление данных в таблице
        private void btnUpdateArhivSE_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
        //Метод обновления данных
        private void RefreshTable()
        {
            DBConnection.ShowTableArhivSE();
            dataGridArhivSE.DataSource = DBConnection.ArhivSE;
        }

        //При выборе заголовка столбца правой кнопкой мыши выводится список для отбора записей
        int key;
        private void dataGridArhivSE_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.ColumnIndex != 0 && e.RowIndex == -1)
            {
                Filter.Items.Clear();
                switch (e.ColumnIndex)
                {
                    case (1):
                        {
                            DBConnection.ShowFilter("t_dogovor.nomdogovor", "arhivse,t_dogovor,t_akt,t_specact", "where arhivse.id_specact = t_specact.id_specact and t_specact.id_act = t_akt.id_akt and t_akt.id_dogovor = t_dogovor.id_dogovor order by t_dogovor.nomdogovor");
                            key = 1;
                        }
                        break;
                    case (2):
                        {
                            DBConnection.ShowFilter("t_akt.nomact", "arhivse,t_akt,t_specact", "where arhivse.id_specact = t_specact.id_specact and t_specact.id_act = t_akt.id_akt order by t_akt.nomact");
                            key = 2;
                        }
                        break;
                    case (3):
                        {
                            DBConnection.ShowFilter("concat(s_typeequip.typeequip, ' ', t_sklad.equipment)", "arhivse,t_sklad,s_typeequip", "where arhivse.id_skladequip = t_sklad.id_skladequip and t_sklad.id_typeequip = s_typeequip.id_typeequip order by concat(s_typeequip.typeequip, ' ', t_sklad.equipment)");
                            key = 3;
                        }
                        break;
                    case (4):
                        {
                            DBConnection.ShowFilter("serialscore", "arhivse", "order by serialscore");
                            key = 4;
                        }
                        break;
                    case (5):
                        {
                            DBConnection.ShowFilter("dateSpis", "arhivse", "order by dateSpis desc");
                            key = 5;
                        }
                        break;
                }
                for (int i = 0; i < DBConnection.filter.Rows.Count; i++)
                    Filter.Items.Add(new ToolStripMenuItem(DBConnection.filter.Rows[i].ItemArray.GetValue(0).ToString()));
                Filter.Show(MousePosition, ToolStripDropDownDirection.BelowRight);
            }
        }

        private void Filter_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (key)
            {
                case (1):
                    {
                        DBConnection.ShowFilters("arhivse.id_arhivSE,t_dogovor.nomdogovor,t_akt.nomact,concat(s_typeequip.typeequip, ' ', t_sklad.equipment) as 'equip',arhivse.serialscore, arhivse.dateSpis", "arhivse,t_specact,t_sklad,s_typeequip,t_akt,t_dogovor"," where arhivse.id_specact = t_specact.id_specact and arhivse.id_skladequip = t_sklad.id_skladequip and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_specact.id_act = t_akt.id_akt and t_akt.id_dogovor = t_dogovor.id_dogovor and t_dogovor.nomdogovor = '" + e.ClickedItem.Text + "' order by arhivse.dateSpis desc ");
                    }
                    break;
                case (2):
                    {
                        DBConnection.ShowFilters("arhivse.id_arhivSE,t_dogovor.nomdogovor,t_akt.nomact,concat(s_typeequip.typeequip, ' ', t_sklad.equipment) as 'equip',arhivse.serialscore, arhivse.dateSpis", "arhivse,t_specact,t_sklad,s_typeequip,t_akt,t_dogovor", " where arhivse.id_specact = t_specact.id_specact and arhivse.id_skladequip = t_sklad.id_skladequip and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_specact.id_act = t_akt.id_akt and t_akt.id_dogovor = t_dogovor.id_dogovor and t_akt.nomact = '" + e.ClickedItem.Text + "' order by arhivse.dateSpis desc ");
                    }
                    break;
                case (3):
                    {
                        DBConnection.ShowFilters("arhivse.id_arhivSE,t_dogovor.nomdogovor,t_akt.nomact,concat(s_typeequip.typeequip, ' ', t_sklad.equipment) as 'equip',arhivse.serialscore, arhivse.dateSpis", "arhivse,t_specact,t_sklad,s_typeequip,t_akt,t_dogovor", " where arhivse.id_specact = t_specact.id_specact and arhivse.id_skladequip = t_sklad.id_skladequip and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_specact.id_act = t_akt.id_akt and t_akt.id_dogovor = t_dogovor.id_dogovor and concat(s_typeequip.typeequip, ' ', t_sklad.equipment) = '" + e.ClickedItem.Text + "' order by arhivse.dateSpis desc ");
                    }
                    break;
                case (4):
                    {
                        DBConnection.ShowFilters("arhivse.id_arhivSE,t_dogovor.nomdogovor,t_akt.nomact,concat(s_typeequip.typeequip, ' ', t_sklad.equipment) as 'equip',arhivse.serialscore, arhivse.dateSpis", "arhivse,t_specact,t_sklad,s_typeequip,t_akt,t_dogovor", " where arhivse.id_specact = t_specact.id_specact and arhivse.id_skladequip = t_sklad.id_skladequip and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_specact.id_act = t_akt.id_akt and t_akt.id_dogovor = t_dogovor.id_dogovor and arhivse.serialscore = '" + e.ClickedItem.Text + "' order by arhivse.dateSpis desc ");
                    }
                    break;
                case (5):
                    {
                        DBConnection.ShowFilters("arhivse.id_arhivSE,t_dogovor.nomdogovor,t_akt.nomact,concat(s_typeequip.typeequip, ' ', t_sklad.equipment) as 'equip',arhivse.serialscore, arhivse.dateSpis", "arhivse,t_specact,t_sklad,s_typeequip,t_akt,t_dogovor", " where arhivse.id_specact = t_specact.id_specact and arhivse.id_skladequip = t_sklad.id_skladequip and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_specact.id_act = t_akt.id_akt and t_akt.id_dogovor = t_dogovor.id_dogovor and arhivse.dateSpis = '" + Convert.ToDateTime(e.ClickedItem.Text).ToString("yyyy.MM.dd") + "' order by arhivse.dateSpis desc ");
                    }
                    break;
            }
            dataGridArhivSE.DataSource = DBConnection.filters;
        }
    }
}
