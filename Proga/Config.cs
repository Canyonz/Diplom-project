using Proga.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class Config : UserControl
    {
        public Config()
        {
            InitializeComponent(); 
            comboBoxAddDogovorAbonent.SelectedIndex = 0; 
            Confiq conf = new Confiq();
            Hide.BackColor = Settings.Default.ButtonBackColor;
            Hide.FlatAppearance.BorderColor = Settings.Default.ButtonBorderColor;
            Hide.FlatAppearance.MouseDownBackColor = Settings.Default.ButtonDown;
            Hide.FlatAppearance.MouseOverBackColor = Settings.Default.ButtonOver;
            comboBoxAddDogovorAbonent.SelectedIndex = 0;
            if (Settings.Default.Theme == 2)
            {
                menuStrip1.Renderer = new Confiq.MyRenderer();
                menuStrip2.Renderer = new Confiq.MyRenderer();
                menuStrip3.Renderer = new Confiq.MyRenderer();
                menuStrip4.Renderer = new Confiq.MyRenderer();
            }
            else
            {
                menuStrip1.Renderer = null;
                menuStrip2.Renderer = null;
                menuStrip3.Renderer = null;
                menuStrip4.Renderer = null;
            }
        }
        //Закрытие формы
        private void Hide_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        //Сохранение выбранной темы
        private void Save_Click(object sender, EventArgs e)
        {
            Confiq conf = new Confiq();
            if (comboBoxAddDogovorAbonent.SelectedIndex == 0)
            {
                Settings.Default.Theme = 1;
                
                Settings.Default.ForeColor = Color.FromArgb(255, 11, 11, 11);
                conf.ResetForeColor(tableLayoutPanel6, Settings.Default.ForeColor);

                Settings.Default.BackColorMain = Color.FromArgb(255, 250, 250, 255);
                conf.ResetBackColor(tableLayoutPanel10, Settings.Default.BackColorMain);
                conf.ResetBackColor(tableLayoutPanel91, Settings.Default.BackColorMain);
                conf.ResetBackColor(panel2, Settings.Default.BackColorMain);

                Settings.Default.BackColorGroup = Color.MintCream;
                conf.ResetBackColor(groupStreet, Settings.Default.BackColorGroup);

                Settings.Default.ButtonBackColor = Color.LavenderBlush;
                Settings.Default.ButtonBorderColor = Color.MistyRose;
                Settings.Default.ButtonDown = Color.LightPink;
                Settings.Default.ButtonOver = Color.MistyRose;
                conf.ResetBackColorButton(groupStreet);

                Settings.Default.GridForeColor = Color.FromArgb(255, 11, 11, 11);
                Settings.Default.GridBackColor = Color.LavenderBlush;
                Settings.Default.GridSelColor= Color.LightPink;
                Settings.Default.GridCellsColor = Color.White;
                Settings.Default.GridAlter = Color.FromArgb(255, 224, 224, 224);
                conf.ResetGridColor1(groupStreet);
                Settings.Default.Save();
                Program.main.theme();
            }
            else if (comboBoxAddDogovorAbonent.SelectedIndex == 1)
            {
                Settings.Default.Theme = 2;
                Settings.Default.ForeColor = Color.FromArgb(255, 241, 241, 241);
                conf.ResetForeColor(tableLayoutPanel6, Settings.Default.ForeColor);

                Settings.Default.BackColorMain = Color.FromArgb(255, 45, 45, 48);
                conf.ResetBackColor(tableLayoutPanel10, Settings.Default.BackColorMain);
                conf.ResetBackColor(tableLayoutPanel91, Settings.Default.BackColorMain);
                conf.ResetBackColor(panel2, Settings.Default.BackColorMain);

                Settings.Default.BackColorGroup = Color.FromArgb(255, 37, 37, 38);
                conf.ResetBackColor(groupStreet, Settings.Default.BackColorGroup);

                Settings.Default.ButtonBackColor = Color.FromArgb(255, 55, 55, 55);
                Settings.Default.ButtonBorderColor = Color.FromArgb(255, 55, 45, 65);
                Settings.Default.ButtonDown = Color.FromArgb(255, 35, 35, 35);
                Settings.Default.ButtonOver = Color.FromArgb(255, 55, 45, 65);
                conf.ResetBackColorButton(groupStreet);

                Settings.Default.GridForeColor = Color.FromArgb(255, 241, 241, 241);
                Settings.Default.GridBackColor = Color.FromArgb(255, 30, 30, 30);
                Settings.Default.GridSelColor = Color.FromArgb(255, 75, 65, 85);
                Settings.Default.GridCellsColor = Color.FromArgb(255, 75, 75, 75);
                Settings.Default.GridAlter = Color.FromArgb(255, 45, 45, 45);
                conf.ResetGridColor1(groupStreet);
                Settings.Default.Save();
                Program.main.theme();
            }
            if (Settings.Default.Theme == 2)
            {
                menuStrip1.Renderer = new Confiq.MyRenderer();
                menuStrip2.Renderer = new Confiq.MyRenderer();
                menuStrip3.Renderer = new Confiq.MyRenderer();
                menuStrip4.Renderer = new Confiq.MyRenderer();
            }
            else
            {
                menuStrip1.Renderer = null;
                menuStrip2.Renderer = null;
                menuStrip3.Renderer = null;
                menuStrip4.Renderer = null;
            }
        }
        //Предварительный просмотр при выборе темы из выпадающего списка
        private void comboBoxAddDogovorAbonent_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Confiq conf = new Confiq();
            if (comboBoxAddDogovorAbonent.SelectedIndex == 0)
            {
                Settings.Default.Theme = 1;
                Settings.Default.ForeColor = Color.FromArgb(255, 11, 11, 11);
                conf.ResetForeColor(tableLayoutPanel6, Settings.Default.ForeColor);

                Settings.Default.BackColorMain = Color.FromArgb(255, 250, 250, 255);
                conf.ResetBackColor(tableLayoutPanel10, Settings.Default.BackColorMain);
                conf.ResetBackColor(tableLayoutPanel91, Settings.Default.BackColorMain);

                Settings.Default.BackColorGroup = Color.MintCream;
                conf.ResetBackColor(groupStreet, Settings.Default.BackColorGroup);

                Settings.Default.ButtonBackColor = Color.LavenderBlush;
                Settings.Default.ButtonBorderColor = Color.MistyRose;
                Settings.Default.ButtonDown = Color.LightPink;
                Settings.Default.ButtonOver = Color.MistyRose;
                conf.ResetBackColorButton(groupStreet);

                Settings.Default.GridForeColor = Color.FromArgb(255, 11, 11, 11);
                Settings.Default.GridBackColor = Color.LavenderBlush;
                Settings.Default.GridSelColor= Color.LightPink;
                Settings.Default.GridCellsColor = Color.FromArgb(255, 241, 241, 241);
                conf.ResetGridColor1(groupStreet);
                conf.ResetBackColor(panel2, Settings.Default.BackColorMain);

            }
            else if (comboBoxAddDogovorAbonent.SelectedIndex == 1)
            {
                Settings.Default.Theme = 2;
                Settings.Default.ForeColor = Color.FromArgb(255, 241, 241, 241);
                conf.ResetForeColor(tableLayoutPanel6, Settings.Default.ForeColor);

                Settings.Default.BackColorMain = Color.FromArgb(255, 45, 45, 48);
                conf.ResetBackColor(tableLayoutPanel10, Settings.Default.BackColorMain);
                conf.ResetBackColor(tableLayoutPanel91, Settings.Default.BackColorMain);
                conf.ResetBackColor(panel2, Settings.Default.BackColorMain);

                Settings.Default.BackColorGroup = Color.FromArgb(255, 37, 37, 38);
                conf.ResetBackColor(groupStreet, Settings.Default.BackColorGroup);

                Settings.Default.GridForeColor = Color.FromArgb(255, 241, 241, 241);
                Settings.Default.GridBackColor = Color.FromArgb(255, 30, 30, 30);
                Settings.Default.GridSelColor= Color.FromArgb(255, 55, 45, 65);
                Settings.Default.GridCellsColor = Color.FromArgb(255, 65, 65, 65);
                conf.ResetGridColor1(groupStreet);

                Settings.Default.ButtonBackColor = Color.FromArgb(255, 55, 55, 55);
                Settings.Default.ButtonBorderColor = Color.FromArgb(255, 55, 45, 65);
                Settings.Default.ButtonDown = Color.FromArgb(255, 35, 35, 35);
                Settings.Default.ButtonOver = Color.FromArgb(255, 55, 45, 65);
                conf.ResetBackColorButton(groupStreet);
                conf.ResetBackColorButton(tableLayoutPanel2);
                conf.ResetBackColorButton(tableLayoutPanel3);
                conf.ResetBackColorButton(panel1);

            }
            if (Settings.Default.Theme == 2)
            {
                menuStrip1.Renderer = new Confiq.MyRenderer();
                menuStrip2.Renderer = new Confiq.MyRenderer();
                menuStrip3.Renderer = new Confiq.MyRenderer();
                menuStrip4.Renderer = new Confiq.MyRenderer();
            }
            else
            {
                menuStrip1.Renderer = null;
                menuStrip2.Renderer = null;
                menuStrip3.Renderer = null;
                menuStrip4.Renderer = null;
            }
        }
        

        Button knopka;
        TableLayoutPanel layout;
        //Скрывает или отображает зону таблиц
        private void ShowHideTables_Click(object sender, EventArgs e)
        {
            knopka = (sender as Button);
            if (knopka == ShowHideTables)
                layout = tableLayoutHierarchy;
            else
                layout = tableLayoutHierarchy1;
            if (layout.RowStyles[0].Height == 33)
            {
                layout.RowStyles[0].Height = 183;
                knopka.Image = Properties.Resources.icons8_шеврон_вверх_24;
            }
            else
             if (layout.RowStyles[0].Height == 183)
            {
                layout.RowStyles[0].Height = 33;
                    knopka.Image = Properties.Resources.icons8_шеврон_вниз_24;
            }
        }
        //Меняет стили меню
        private void ShowHideHierarchy2_Click(object sender, EventArgs e)
        {
            if (tableLayoutMain.ColumnStyles[0].Width == 0 && panel2.Visible == true)
            {
                tableLayoutMain.ColumnStyles[0].Width = 200;
                panel2.Visible = false;
                ShowHideHierarchy.Visible = true;
                ShowHideHierarchy2.Image = null;
                ShowHideHierarchy.Image = Properties.Resources.icons8_назад_16;
            }
            else
            {
                tableLayoutMain.ColumnStyles[0].Width = 0;
                panel2.Visible = true;
                ShowHideHierarchy.Visible = false;
                ShowHideHierarchy2.Image = Properties.Resources.icons8_вперед_16;
            }
        }
        //Закрытие формы с таблицей
        private void btnHideTable_Click(object sender, EventArgs e)
        {
            groupStreet.Visible = false;
        }
        //Закрытие поля для добавления
        private void btnHideGroup1_Click_1(object sender, EventArgs e)
        {
            tableLayoutStreet.RowStyles[1].Height = 0;
        }
        //Открытие поля для добавления
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            tableLayoutStreet.RowStyles[1].Height = 136;
        }
        //Закрытие меню
        private void ShowHideHierarchy_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == false)
            {
                if (tableLayoutMain.ColumnStyles[0].Width == 200)
                {
                    tableLayoutMain.ColumnStyles[0].Width = 0;
                    ShowHideHierarchy.Image = null;
                }
                else
                {
                    tableLayoutMain.ColumnStyles[0].Width = 200;
                    ShowHideHierarchy.Image = Properties.Resources.icons8_назад_16;
                }
            }
        }
        //Открытие формы
        private void showTable_Click(object sender, EventArgs e)
        {
            groupStreet.Visible = true;
        }
        //Когда указатель мыши наводится на элемент открывается второе меню
        private void menuStrip3_MouseEnter(object sender, EventArgs e)
        {
            panel2.Width = 214;
        }
        //Когда указатель мыши выходит за пределы элемента скрывается второе меню
        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.Width = 26;
                tableLayoutHierarchy1.RowStyles[0].Height = 33;
                ShowHideTables1.Image = Resources.icons8_шеврон_вниз_24;
        }
    }
}
