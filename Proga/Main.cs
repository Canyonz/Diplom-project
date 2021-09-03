using Proga.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WMPLib;
namespace Proga
{
    public partial class Main : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public Main()
        {
            Program.main = this;
            InitializeComponent();
            theme();
            timer1.Start();
            DBConnection.ShowTableNaznach();
            DBConnection.ShowTableTypeEquip();
            DBConnection.ShowTableTypeAct();
            DBConnection.ShowTableStateEquipment();
            DBConnection.ShowTableStatusAD();
            DBConnection.ShowTableDoljnost();
            DBConnection.ShowTableSotryd();
            DBConnection.ShowTableUsers();
            DBConnection.ShowTableAbonent();
            DBConnection.ShowTablePostav();
            DBConnection.ShowTableNaklad();
            DBConnection.ShowTableSklad();
            DBConnection.ShowTableDogovor();
            DBConnection.ShowTableCity();
            DBConnection.Types();
            DBConnection.ShowTableYslygi();
            DBConnection.ShowTableReasons();
            DBConnection.ShowTableArhivSE();
        }
        //Настройка темы приложения которую выбрал пользователь
        public void theme()
        {
            Confiq conf = new Confiq();
            conf.ResetBackColor(tableLayoutPanel2, Settings.Default.BackColorMain);
            conf.ResetBackColor(tableLayoutPanel3, Settings.Default.BackColorMain);
            conf.ResetForeColor(tableLayoutPanel1, Settings.Default.ForeColor);
            conf.ResetGridColor1(panelShow);
            conf.ResetBackColor(panelShow, Settings.Default.BackColorGroup);
            conf.ResetBackColorButton(panelShow);
            conf.ResetBackColor(panel1, Settings.Default.BackColorMain);
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
        //Разграничение прав доступа, объявление клавиши Ф1.
        private void Main_Load(object sender, EventArgs e)
        {
            switch (DBConnection.Doljnost)
            {
                case "2":
                    tableLayoutHierarchy.RowStyles[2].Height = 0;
                    tableLayoutHierarchy.RowStyles[3].Height = 0;
                    tableLayoutHierarchy1.RowStyles[2].Height = 0;
                    tableLayoutHierarchy1.RowStyles[3].Height = 0;
                    break;
                case "3":
                    tableLayoutHierarchy.RowStyles[0].Height = 0;
                    tableLayoutHierarchy.RowStyles[1].Height = 0;
                    tableLayoutHierarchy1.RowStyles[0].Height = 0;
                    tableLayoutHierarchy1.RowStyles[1].Height = 0;
                    break;
            }
            globalKeyboardHook f1 = new globalKeyboardHook();
            f1.HookedKeys.Add(Keys.F1);
            f1.KeyUp += new KeyEventHandler(f1_KeyUp);
            player.URL = "Music/Music.mp3";
            player.controls.play();
            player.settings.volume = 0;
            player.settings.autoStart = true;
            player.settings.setMode("loop", true);
            DBConnection.NameUser();
            ToolStripMenuItem.Text = DBConnection.NameUsers;
            ToolStripMenuItem1.Text = DBConnection.NameUsers;
            if (Settings.Default.menu == 1)
            {
                tableLayoutMain.ColumnStyles[0].Width = 225;
                panel1.Visible = false;
                ShowHideHierarchy.Visible = true;
                ShowHideHierarchy2.Image = null;
                ShowHideHierarchy.Image = Resources.icons8_назад_16;
            }
            else if (Settings.Default.menu == 2)
            {
                tableLayoutMain.ColumnStyles[0].Width = 0;
                panel1.Visible = true;
                ShowHideHierarchy.Visible = false;
                ShowHideHierarchy2.Image = Resources.icons8_вперед_16;
            }
        }
        public bool f1close = true;
        //Вызов горячей клавиши F1
        void f1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (f1close)
                {
                    f1close = false;
                    Info info = new Info();
                    info.ShowDialog();
                    info.Location = MousePosition;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DT.Text = "Текущие дата и время: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        }
        //Перетаскивание формы за шапку формы
        private void tableLayoutPanel4_MouseDown(object sender, MouseEventArgs e)
        {
            this.Opacity = 0.5;
            tableLayoutPanel4.Capture = false;
            Message m = Message.Create(this.Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
            this.Opacity = 100;
        }
        //Перетаскивание формы за шапку формы
        private void tableLayoutPanel6_MouseDown(object sender, MouseEventArgs e)
        {
            this.Opacity = 0.5;
            tableLayoutPanel6.Capture = false;
            Message m = Message.Create(this.Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
            this.Opacity = 100;
        }
        //Перетаскивание формы за картинку формы
        private void pictureRT_MouseDown(object sender, MouseEventArgs e)
        {
            this.Opacity = 0.5;
            pictureRT.Capture = false;
            Message m = Message.Create(this.Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
            this.Opacity = 100;
        }
        //Сворачивание программы в трей
        private void close_Click(object sender, EventArgs e)
        {
            this.Hide();
            Treey.Visible = true;
            Treey.ShowBalloonTip(3000);
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
        //Сворачивает или разворачивает меню
        private void ShowHideHierarchy_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false)
            {
                if (tableLayoutMain.ColumnStyles[0].Width == 225)
                {
                    timer2.Start();
                }
                else
                {
                    timer3.Start();
                }
            }
        }
        //Сворачивает меню по таймера
        private void timer2_Tick(object sender, EventArgs e)
        {
            tableLayoutMain.ColumnStyles[0].Width -= 25;
            if (tableLayoutMain.ColumnStyles[0].Width == 0)
            {
                timer2.Stop();
                ShowHideHierarchy.Image = null;
            }
        }
        //Разворачивает меню по таймеру
        private void timer3_Tick(object sender, EventArgs e)
        {
            tableLayoutMain.ColumnStyles[0].Width += 25;
            if (tableLayoutMain.ColumnStyles[0].Width == 225)
            {
                timer3.Stop();
                ShowHideHierarchy.Image = Properties.Resources.icons8_назад_16;
            }
        }
        //Меняет стили меню
        private void ShowHideHierarchy2_Click(object sender, EventArgs e)
        {
            if (tableLayoutMain.ColumnStyles[0].Width == 0 && panel1.Visible == true)
            {
                Settings.Default.menu = 1;
                Settings.Default.Save();
                tableLayoutMain.ColumnStyles[0].Width = 225;
                panel1.Visible = false;
                ShowHideHierarchy.Visible = true;
                ShowHideHierarchy2.Image = null;
                ShowHideHierarchy.Image = Resources.icons8_назад_16;
            }
            else
            {
                Settings.Default.menu = 2;
                Settings.Default.Save();
                tableLayoutMain.ColumnStyles[0].Width = 0;
                panel1.Visible = true;
                ShowHideHierarchy.Visible = false;
                ShowHideHierarchy2.Image = Resources.icons8_вперед_16;
            }

        }
        int num = 0;
        Button knopka;
        TableLayoutPanel layout;
        //Открывает выбранную зону для показа списка меню
        private void timer8_Tick(object sender, EventArgs e)
        {
            switch (num)
            {
                case 0:
                    layout.RowStyles[0].Height += 25;
                    if (layout.RowStyles[0].Height == 208)
                    {
                        timer8.Stop();
                        knopka.Image = Resources.icons8_шеврон_вверх_24;
                    }
                    break;
                case 1:
                    layout.RowStyles[1].Height += 25;
                    if (layout.RowStyles[1].Height == 158)
                    {
                        timer8.Stop();
                        knopka.Image = Resources.icons8_шеврон_вверх_24;
                    }
                    break;
                case 2:
                    layout.RowStyles[2].Height += 25;
                    if (layout.RowStyles[2].Height == 83)
                    {
                        timer8.Stop();
                        knopka.Image = Resources.icons8_шеврон_вверх_24;
                    }
                    break;
                case 3:
                    layout.RowStyles[3].Height += 25;
                    if (layout.RowStyles[3].Height == 158)
                    {
                        timer8.Stop();
                        knopka.Image = Resources.icons8_шеврон_вверх_24;
                    }
                    break;
            }
        }
        //Скрывает выбранную зону
        private void timer9_Tick(object sender, EventArgs e)
        {
            layout.RowStyles[num].Height -= 25;
            if (layout.RowStyles[num].Height == 33)
            {
                timer9.Stop();
                knopka.Image = Properties.Resources.icons8_шеврон_вниз_24;
            }
        }
        //Скрывает или отображает зону таблиц
        private void ShowHideTables_Click(object sender, EventArgs e)
        {
            knopka = (sender as Button);
            if (knopka == ShowHideTables)
                layout = tableLayoutHierarchy;
            else
                layout = tableLayoutHierarchy1;
            num = 0;
            if (layout.RowStyles[0].Height == 33)
            {
                timer8.Start();
            }
            else
             if (layout.RowStyles[0].Height == 208)
            {
                timer9.Start();
            }
        }
        //Скрывает или отображает зону справочников
        private void ShowHideDirectory_Click(object sender, EventArgs e)
        {
            knopka = (sender as Button);
            if (knopka == ShowHideDirectory)
                layout = tableLayoutHierarchy;
            else
                layout = tableLayoutHierarchy1;
            num = 1;
            if (layout.RowStyles[1].Height == 33)
            {
                timer8.Start();
            }
            else
             if (layout.RowStyles[1].Height == 158)
            {
                timer9.Start();
            }
        }
        //Скрывает или отображает зону пользователей
        private void ShowHideUsers_Click(object sender, EventArgs e)
        {
            knopka = (sender as Button);
            if (knopka == ShowHideUsers)
                layout = tableLayoutHierarchy;
            else
                layout = tableLayoutHierarchy1;
            num = 2;
            if (layout.RowStyles[2].Height == 33)
            {
                timer8.Start();
            }
            else
             if (layout.RowStyles[2].Height == 83)
            {
                timer9.Start();
            }
        }
        //Скрывает или отображает зону данных
        private void ShowHideData_Click(object sender, EventArgs e)
        {
            knopka = (sender as Button);
            if (knopka == ShowHideData)
                layout = tableLayoutHierarchy;
            else
                layout = tableLayoutHierarchy1;
            num = 3;
            if (layout.RowStyles[3].Height == 33)
            {
                timer8.Start();
            }
            else
             if (layout.RowStyles[3].Height == 158)
            {
                timer9.Start();
            }
        }
        //Открытие поля для смены пароля
        private void изменитьПарольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditUser EU = new EditUser();
            EU.ShowDialog();
        }
        //Открытие спарвочника «Назначения»
        private void showNazn_Click(object sender, EventArgs e)
        {
            ClearShowPanel();
            ppsNaznach1.Visible = true;
        }
        //Открытие спарвочника «Тип акта»
        private void showTypeAct_Click(object sender, EventArgs e)
        {
            ClearShowPanel();
            ppsTypeAct1.Visible = true;
        }
        //Открытие спарвочника «Состояние оборудования»
        private void showStateEquipment_Click(object sender, EventArgs e)
        {
            ClearShowPanel();
            ppStateEquipment1.Visible = true;
        }
        //Открытие спарвочника «Статус»
        private void showStatusAD_Click(object sender, EventArgs e)
        {
            ClearShowPanel();
            pptStatusAD1.Visible = true;
        }
        //Открытие спарвочника «Должность»
        private void showDoljnost_Click(object sender, EventArgs e)
        {
            ClearShowPanel();
            ppsDoljnost1.Visible = true;
        }
        //Открытие спарвочника «Тип оборудования»
        private void showTypeEquip_Click(object sender, EventArgs e)
        {
            ClearShowPanel();
            ppsTypeEquip1.Visible = true;
        }
        //Открытие таблицы «Сотрудники»
        private void showSotrydnik_Click(object sender, EventArgs e)
        {
            ClearShowPanel();
            pptSotryd1.Visible = true;
        }
        //Открытие таблицы «Пользователи»
        private void showUsers_Click(object sender, EventArgs e)
        {
            ClearShowPanel();
            pptUsers1.Visible = true;
        }
        //Открытие таблиц «Абоненты» и «Лицевой счет»
        private void showAbonent_Click(object sender, EventArgs e)
        {
            ClearShowPanel();
            pttAbonents1.Visible = true;
        }
        //Открытие таблицы «Поставщики»
        private void showPostavshik_Click(object sender, EventArgs e)
        {
            ClearShowPanel();
            pptPostavhik1.Visible = true;
        }
        //Открытие таблицы «Склад»
        private void showSklad_Click(object sender, EventArgs e)
        {
            ClearShowPanel();
            pptSklad1.Visible = true;
        }
        //Открытие таблиц «Договора», «Акт» и «Спецификация акта»
        private void showDogActSpec_Click(object sender, EventArgs e)
        {
            ClearShowPanel();
            ppoDogovors1.Visible = true;
            Program.Dogovor.Connect();
            Program.Dogovor.color();
        }
        //Открытие таблиц «Накладные» и «Спецификация накладной»
        private void ShowNaklad_Spec_Click(object sender, EventArgs e)
        {
            ClearShowPanel();
            pptNaklad_Spec1.Visible = true;
        }
        //Открытие спарвочников «Города» и «Улицы»
        private void ShowCityStreet_Click(object sender, EventArgs e)
        {
            ClearShowPanel();
            ppsCityStreet1.Visible = true;
        }
        //Открытие спарвочника «Услуги»
        private void showYslygi_Click(object sender, EventArgs e)
        {
            ClearShowPanel();
            ppsYslygi1.Visible = true;
        }
        //Открытие спарвочника «Причины»
        private void showReasons_Click(object sender, EventArgs e)
        {
            ClearShowPanel();
            ppsReasons1.Visible = true;
        }
        //Открытие таблицы «Архив»
        private void ShowArhiv_Click(object sender, EventArgs e)
        {
            ClearShowPanel();
            arhivSpisEquip1.Visible = true;
        }
        //Скрывает все таиблицы и справочники
        private void ClearShowPanel()
        {
            foreach (Control c in panelShow.Controls)
            {
                if (c != panel1 && c != label1 && c != label2 && c != tableLayoutPanel9)
                    c.Visible = false;
            }
        }
        //Конвертирует цвета картинки
        private void pictureRT_MouseEnter(object sender, EventArgs e)
        {
            pictureRT.BackgroundImage = Properties.Resources.RT_logo_RGB_reverse;
        }
        //Конвертирует цвета картинки обратно
        private void pictureRT_MouseLeave(object sender, EventArgs e)
        {
            pictureRT.BackgroundImage = Properties.Resources.RT_logo_RGB;
        }
        //Когда указатель мыши наводится на элемент открывается второе меню
        private void tableLayoutPanel5_Enter(object sender, EventArgs e)
        {
            panel1.Width = 214;
        }
        //Когда указатель мыши выходит за пределы элемента скрывается второе меню
        private void tableLayoutPanel5_Leave(object sender, EventArgs e)
        {
            panel1.Width = 26;
            if (tableLayoutHierarchy1.RowStyles[2].Height == 0 && tableLayoutHierarchy1.RowStyles[3].Height == 0)
            {
                tableLayoutHierarchy1.RowStyles[0].Height = 33;
                tableLayoutHierarchy1.RowStyles[1].Height = 33;
                ShowHideTables1.Image = Properties.Resources.icons8_шеврон_вниз_24;
                ShowHideDirectory1.Image = Properties.Resources.icons8_шеврон_вниз_24;
            }
            else if (tableLayoutHierarchy1.RowStyles[0].Height == 0 && tableLayoutHierarchy1.RowStyles[1].Height == 0)
            {
                tableLayoutHierarchy1.RowStyles[2].Height = 33;
                tableLayoutHierarchy1.RowStyles[3].Height = 33;
                ShowHideUsers1.Image = Properties.Resources.icons8_шеврон_вниз_24;
                ShowHideData1.Image = Properties.Resources.icons8_шеврон_вниз_24;
            }
        }
        //Разворачиет программу из трея
        private void Treey_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            Treey.Visible = false;
            WindowState = FormWindowState.Normal;
        }
        //Убирает эконку программы из трея
        private void Main_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Normal == this.WindowState)
                Treey.Visible = false;
        }
        //Закрывает программу
        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            DBConnection.Close();
        }
        //Открывает форму с выбором темы программы
        private void ConfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearShowPanel();
            config1.Visible = true;
        }
    }
}
