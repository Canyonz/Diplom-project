using System;
using System.Windows.Forms;

namespace Proga
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        //Выводит выбранный отчет
        private void Report_Load(object sender, EventArgs e)
        {
            if (DBConnection.NomNaznach == 1)
            {
                if (DBConnection.NomTypeAct == 4 || DBConnection.NomTypeAct == 1)
                {
                    ClearShowPanel();
                    reportViewer5.Visible = true;
                    this.ActReplaceSaleTableAdapter.Fill(this.ActReplaceSaleDataSet.ActReplaceSale, DBConnection.NomDogovor, DBConnection.NomAct1);
                }
                else if (DBConnection.NomTypeAct == 3 || DBConnection.NomTypeAct == 2)
                {
                    ClearShowPanel();
                    reportViewer6.Visible = true;
                    this.ActReplaceArendTableAdapter.Fill(this.ActReplaceArendDataSet.ActReplaceArend, DBConnection.NomDogovor, DBConnection.NomAct1);
                }else
                    MessageBox.Show("АКТ не выбран!");
            }
            else
                switch (DBConnection.NomTypeAct)
                {
                    case (1):
                        ClearShowPanel();
                        reportViewer1.Visible = true;
                        this.ActTableAdapter.Fill(this.ActSaleDataSet1.Act, DBConnection.NomDogovor, DBConnection.NomAct);
                        break;
                    case (2):
                        ClearShowPanel();
                        reportViewer2.Visible = true;
                        this.ActArendaTableAdapter.Fill(this.ActArendaDataSet.ActArenda, DBConnection.NomDogovor, DBConnection.NomAct);
                        break;
                    case (3):
                        ClearShowPanel();
                        reportViewer4.Visible = true;
                        this.ActReturnArendaTableAdapter.Fill(this.ActReturnArendDataSet.ActReturnArenda, DBConnection.NomDogovor, DBConnection.NomAct);
                        break;
                    case (4):
                        ClearShowPanel();
                        reportViewer3.Visible = true;
                        this.ActReturnSaleTableAdapter.Fill(this.ActReturnSaleDataSet.ActReturnSale, DBConnection.NomDogovor, DBConnection.NomAct);
                        break;
                    default:
                        MessageBox.Show("АКТ не выбран!");
                        break;
                }
            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer3.RefreshReport();
            this.reportViewer4.RefreshReport();
            this.reportViewer5.RefreshReport();
            this.reportViewer6.RefreshReport();
        }
        //Закрывает все отчеты
        private void ClearShowPanel()
        {
            foreach (Control c in panel1.Controls) { c.Visible = false; }
        }
        //Закрытие формы
        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Развертывание окна
        private void maximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }
        //Сворачивание окна
        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Перетаскивание формы за шапку
        private void tableLayoutPanel6_MouseDown(object sender, MouseEventArgs e)
        {
            tableLayoutPanel6.Capture = false;
            Message m = Message.Create(this.Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
    }
}
