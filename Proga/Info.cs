using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }
        //Сворачивание окна
        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Развертывание окна
        private void maximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }
        //Закрытие окна
        private void close_Click(object sender, EventArgs e)
        {
            Program.main.f1close = true;
            Close();
        }
        //Перетаскивание формы за шапку формы
        private void tableLayoutPanel6_MouseDown(object sender, MouseEventArgs e)
        {
            tableLayoutPanel6.Capture = false;
            Message m = Message.Create(this.Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
        //Когда указатель мыши наводится на элемент текст становится синим цветом
        private void MainBut_MouseEnter(object sender, EventArgs e)
        {
            MainBut.ForeColor = Color.Blue;
        }
        //Когда указатель мыши выходит за пределы элемента текст становится черным цветом
        private void MainBut_MouseLeave(object sender, EventArgs e)
        {
            MainBut.ForeColor = Color.Black;
        }
        //Открывает панель для просмотра информации
        private void MainBut_Click(object sender, EventArgs e)
        {
            if(tableLayoutPanel8.RowStyles[5].Height == 0)
            {
                tableLayoutPanel8.RowStyles[5].Height = 500;
                MainBut.Text = "- Основная форма";
            }
            else
            {
            tableLayoutPanel8.RowStyles[5].Height = 0;
                MainBut.Text = "+ Основная форма";
            }
        }
        //Открывает панель для просмотра информации
        private void SpravBut_Click(object sender, EventArgs e)
        {
            if (tableLayoutPanel8.RowStyles[7].Height == 0)
            {
                tableLayoutPanel8.RowStyles[7].Height = 500;
                SpravBut.Text = "- Работа со справочниками";
            }
            else
            {
                tableLayoutPanel8.RowStyles[7].Height = 0;
                SpravBut.Text = "+ Работа со справочниками";
            }
        }
        //Когда указатель мыши наводится на элемент текст становится синим цветом
        private void SpravBut_MouseEnter(object sender, EventArgs e)
        {
            SpravBut.ForeColor = Color.Blue;
        }
        //Когда указатель мыши выходит за пределы элемента текст становится черным цветом
        private void SpravBut_MouseLeave(object sender, EventArgs e)
        {
            SpravBut.ForeColor = Color.Black;
        }
        //Открывает панель для просмотра информации
        private void SettingBut_Click(object sender, EventArgs e)
        {
            if (tableLayoutPanel8.RowStyles[13].Height == 0)
            {
                tableLayoutPanel8.RowStyles[13].Height = 425;
                SettingBut.Text = "- Настройки темы";
            }
            else
            {
                tableLayoutPanel8.RowStyles[13].Height = 0;
                SettingBut.Text = "+ Настройки темы";
            }
        }
        //Когда указатель мыши наводится на элемент текст становится синим цветом
        private void SettingBut_MouseEnter(object sender, EventArgs e)
        {
            SettingBut.ForeColor = Color.Blue;
        }
        //Когда указатель мыши выходит за пределы элемента текст становится черным цветом
        private void SettingBut_MouseLeave(object sender, EventArgs e)
        {
            SettingBut.ForeColor = Color.Black;
        }
        //Открывает панель для просмотра информации
        private void RepBut_Click(object sender, EventArgs e)
        {
            if (tableLayoutPanel8.RowStyles[15].Height == 0)
            {
                tableLayoutPanel8.RowStyles[15].Height = 425;
                RepBut.Text = "- Работа с отчетами";
            }
            else
            {
                tableLayoutPanel8.RowStyles[15].Height = 0;
                RepBut.Text = "+ Работа с отчетами";
            }
        }
        //Когда указатель мыши наводится на элемент текст становится синим цветом
        private void RepBut_MouseEnter(object sender, EventArgs e)
        {
            RepBut.ForeColor = Color.Blue;
        }
        //Когда указатель мыши выходит за пределы элемента текст становится черным цветом
        private void RepBut_MouseLeave(object sender, EventArgs e)
        {
            RepBut.ForeColor = Color.Black;
        }
        //Открывает панель для просмотра информации
        private void TableBut_Click(object sender, EventArgs e)
        {
            if (tableLayoutPanel8.RowStyles[9].Height == 0)
            {
                tableLayoutPanel8.RowStyles[9].Height = 610;
                TableBut.Text = "- Работа с таблицами";
            }
            else
            {
                tableLayoutPanel8.RowStyles[9].Height = 0;
                TableBut.Text = "+ Работа с таблицами";
            }
        }
        //Когда указатель мыши наводится на элемент текст становится синим цветом
        private void TableBut_MouseEnter(object sender, EventArgs e)
        {
            TableBut.ForeColor = Color.Blue;
        }
        //Когда указатель мыши выходит за пределы элемента текст становится черным цветом
        private void TableBut_MouseLeave(object sender, EventArgs e)
        {
            TableBut.ForeColor = Color.Black;
        }
        //Открывает панель для просмотра информации
        private void RelogPas_Click(object sender, EventArgs e)
        {
            if (tableLayoutPanel8.RowStyles[11].Height == 0)
            {
                tableLayoutPanel8.RowStyles[11].Height = 400;
                RelogPas.Text = "- Смена пароля";
            }
            else
            {
                tableLayoutPanel8.RowStyles[11].Height = 0;
                RelogPas.Text = "+ Смена пароля";
            }
        }
        //Когда указатель мыши наводится на элемент текст становится синим цветом
        private void RelogPas_MouseEnter(object sender, EventArgs e)
        {
            RelogPas.ForeColor = Color.Blue;
        }
        //Когда указатель мыши выходит за пределы элемента текст становится черным цветом
        private void RelogPas_MouseLeave(object sender, EventArgs e)
        {
            RelogPas.ForeColor = Color.Black;
        }
    }
}
