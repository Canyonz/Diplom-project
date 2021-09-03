using Proga.Properties;
using System;
using System.Windows.Forms;

namespace Proga
{
    public partial class Searching : Form
    {
        public Searching()
        {
            InitializeComponent();
            Confiq conf = new Confiq();
            conf.ResetBackColor(this, Settings.Default.BackColorMain);
            conf.ResetForeColor(this, Settings.Default.ForeColor);
            conf.ResetBackColorButton(this);
        }
        //Закрытие формы
        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Поиск записей в таблице
        public DataGridView searched;
        private void searchs_Click(object sender, EventArgs e)
        {
            bool search = false;
            for (int i = 0; i < searched.Rows.Count; i++)
            {
                searched.Rows[i].Selected = false;
                for (int j = 1; j < searched.Columns.Count; j++)
                {
                    if (searched.Rows[i].Cells[j].Value != null)
                        if (searched.Rows[i].Cells[j].Value.ToString().IndexOf(textBoxSearch.Text,StringComparison.OrdinalIgnoreCase)>=0)
                            {
                            search = true;
                            searched.Rows[i].Cells[j].Selected = true;
                            Close();
                            break;
                        }
                }
            }
            if (search == false)
            {
                MessageBox.Show("Запись не найдена!");
                searched = null;
            }
        }
        //Перетаскивание формы за шапку формы
        private void tableLayoutPanel2_MouseDown(object sender, MouseEventArgs e)
        {
            tableLayoutPanel2.Capture = false;
            Message m = Message.Create(this.Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
        //Перетаскивание формы за название формы
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Capture = false;
            Message m = Message.Create(this.Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
    }
}
