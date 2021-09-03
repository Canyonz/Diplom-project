using Proga.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
            Confiq conf = new Confiq();
            conf.ResetBackColor(this, Settings.Default.BackColorMain);
            conf.ResetForeColor(this, Settings.Default.ForeColor);
            panel2.BackColor = Settings.Default.ForeColor;
            panel3.BackColor = Settings.Default.ForeColor;
            Opacity = 0;
            timer1.Interval = 10;
            timer1.Start();
            timer1.Tick += new EventHandler((sender, e) =>
            {
                if ((Opacity += 0.2) == 1) timer1.Stop();
            });
        }
        //Перетаскивание формы за шапку
        private void header_MouseDown(object sender, MouseEventArgs e)
        {
            header.Capture = false;
            Message m = Message.Create(this.Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
        //Перетаскивание формы за картинку
        private void pictureRT_MouseDown(object sender, MouseEventArgs e)
        {
            pictureRT.Capture = false;
            Message m = Message.Create(this.Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
        //сворачивание окна
        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //отключение от базы, закрытие программы
        private void close_Click(object sender, EventArgs e)
        {
            DBConnection.Close();
            Application.Exit();
        }
        //Присваивание полю текста «Логин»
        private void textLogin_Leave(object sender, EventArgs e)
        {
            if (textLogin.Text == "")
            {
                textLogin.Text = "Логин";
            }
        }
        //Очищает поле при нажатие на него
        private void textLogin_Enter(object sender, EventArgs e)
        {
            textLogin.Clear();
        }
        //Присваивание полю текста «Пароль»
        private void textPassword_Leave(object sender, EventArgs e)
        {
            if (textPassword.Text == "")
            {
                textPassword.Text = "Пароль";
            }
        }
        //Очищает поле при нажатие на него
        private void textPassword_Enter(object sender, EventArgs e)
        {
            textPassword.Clear();
        }
        //Подключение к базе данных
        private void Authorization_Load(object sender, EventArgs e)
        {
            if (!DBConnection.Connect(0))
            {
                Application.Exit();
            }
            else
            {
                DBConnection.SaveLPAuthorizatoin();
                textLogin.Text = DBConnection.LoginSave;
                textPassword.Text = DBConnection.PasswordSave;
            }
        }
        //Авторизация пользователя и открытие меню программы
        private void signIn_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            DBConnection.Authorization(textLogin.Text, textPassword.Text);
            switch (DBConnection.Doljnost)
            {
                case null:
                    MessageBox.Show("Неверные данные!");
                    break;
                default:
                    Hide();
                    Settings.Default.saveuser = 0;
                    if (checkSave.Checked == true)
                    {
                        Settings.Default.saveuser = DBConnection.keyRecord("id_sotryd", "authorization", "login", textLogin.Text);
                    }
                    Settings.Default.Save();
                    main.Show();
                    textLogin.Clear();
                    textPassword.Clear();
                    break;
            }
        }
        //Когда указатель мыши наводится на элемент, текст становится синим цветом
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Blue;
        }
        //Когда указатель мыши выходит за пределы элемента, текст становится черным цветом
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            if (Settings.Default.Theme == 2)
                label1.ForeColor = Color.White;
            else
                label1.ForeColor = Color.Black;
        }
        //Открывает форму для восстановления пароля
        private void label1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
        }
    }
}
