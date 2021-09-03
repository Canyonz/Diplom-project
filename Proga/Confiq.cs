using Proga.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    class Confiq
    {
       public Color c,c1;

        public class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
        }
        //Окрашивание в градиент ToolStrip
        private class MyColors : ProfessionalColorTable
        {
            public override Color MenuItemSelectedGradientBegin
            {
                get {return Color.FromArgb(51, 51, 51); }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.FromArgb(72, 48, 109); }
            }
            public override Color MenuItemBorder
            {
                get { return Color.FromArgb(65, 55, 75); }
            }
        }

        //Перебирает все элементы
        public void ResetBackColor(Control control,Color col)
        {
            c = col;
            control.BackColor = c;
            foreach (Control c in control.Controls)
            {
                ResetAllBackColor(c);
            }
        }
        //Окрашивает фон элементов
        public void ResetAllBackColor(Control control)
        {
            if(control.Name != "tableLayoutPanel9")
            {
                control.BackColor = c;
                if (control.HasChildren)
                {
                    foreach (Control childControl in control.Controls)
                    {
                        ResetAllBackColor(childControl);
                    }
                }
            }
        }
        //Перебирает все элементы
        public void ResetForeColor(Control control, Color col)
        {
            c1 = col;
            control.ForeColor = c1;
            foreach (Control c in control.Controls)
            {
                ResetAllForeColor(c);
            }
        }
        //Задает цвет текста элементам
        public void ResetAllForeColor(Control control)
        {
            control.ForeColor = c1;
            if (control.HasChildren)
            {
                foreach (Control childControl in control.Controls)
                {
                    ResetAllForeColor(childControl);
                }
            }
        }
        //Перебирает все кнопки
        public void ResetBackColorButton(Control control)
        {
            if (!(control is Config))
            foreach (Control c in control.Controls)
            {
                if (c is Button)
                    ResetAllBackColorButton((Button)c);
                else
                  if (control.HasChildren)
                    foreach (Control childControl in control.Controls)
                        ResetBackColorButton(childControl);
            }
        }
        //Окрашивает фон кнопок
        public void ResetAllBackColorButton(Button control)
        {
            control.BackColor = Settings.Default.ButtonBackColor;
            control.FlatAppearance.BorderColor = Settings.Default.ButtonBorderColor;
            control.FlatAppearance.MouseDownBackColor = Settings.Default.ButtonDown;
            control.FlatAppearance.MouseOverBackColor = Settings.Default.ButtonOver;
        }
        //Перебирает все таблицы
        public void ResetGridColor1(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is DataGridView)
                        ResetGridColor((DataGridView)c);
                else
                  if (control.HasChildren)
                    foreach (Control childControl in control.Controls)
                        ResetGridColor1(childControl);
            }
        }
        //Задает фон таблицым
        public void ResetGridColor(DataGridView control)
        {
            control.BackgroundColor = Settings.Default.GridBackColor;
            control.ForeColor = Settings.Default.GridForeColor;
            control.DefaultCellStyle.BackColor = Settings.Default.GridCellsColor;
            control.AlternatingRowsDefaultCellStyle.BackColor = Settings.Default.GridAlter;
            control.DefaultCellStyle.SelectionBackColor = Settings.Default.GridSelColor;
        }
    }
}
