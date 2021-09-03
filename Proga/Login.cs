using Microsoft.Win32;
using Proga.Properties;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proga
{
    public partial class Login : Form
    {
        public static string ALogin;//Запоминание Логина пользователя
        public static string AKod;//Запоминание отправленного кода подтверждения
        public Login()
        {
            InitializeComponent();
            Confiq conf = new Confiq();
            conf.ResetBackColor(this, Settings.Default.BackColorMain);
            conf.ResetForeColor(this, Settings.Default.ForeColor);
            panel2.BackColor = Settings.Default.ForeColor;
            conf.ResetBackColorButton(panel4);
        }
        //Перетаскивание формы за шапку
        private void header_MouseDown(object sender, MouseEventArgs e)
        {
            header.Capture = false;
            Message m = Message.Create(this.Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }
        //Перетаскивание формы за картинку
        private void pictureRT_MouseDown(object sender, MouseEventArgs e)
        {
            pictureRT.Capture = false;
            Message m = Message.Create(this.Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }
        //Закрытие программы если пользователь не создан, иначе, закрытие формы
        private void close_Click(object sender, EventArgs e)
        {
            if (Program.user == null)
            {
                Environment.Exit(0);
            }
            else
                Close();
        }
        //Регистрация почты пользователя и переход на следующую форму регистрации
        private void Next_Click(object sender, EventArgs e)
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                if (!String.IsNullOrEmpty(textLogin.Text))
                {
                    string email = textLogin.Text;
                    string pattern = @"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$";
                    Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
                    bool matched = r.Match(email).Success;
                    if (matched == true)
                    {
                        if (Program.user == null)
                        {
                            if (DBConnection.ALogin(textLogin.Text) == false)
                            {
                                Hide();
                                MessageBox.Show("Для регистрации на вашу почту отправлено сообщение с кодом подтверждения!");
                                ALogin = textLogin.Text;
                                Email(textLogin.Text, "Запрос на создание учетной записи", "<img src='https://www.company.rt.ru/about/identity/logo_new/small/RT_full_logo-RGB_Horizontal_rus_small.png'> <h1>Приветствуем</h1><hr>" + Environment.NewLine +
                "<h2>Для создания вашей учетной записи Rostelecom введите код подтверждения.</h2>" + Environment.NewLine +
                "<h2>Код подтверждения - " + GenRandomString() + " </h2>").GetAwaiter();
                                ReplacePassword rp = new ReplacePassword();
                                rp.ShowDialog();
                                Close();
                            }
                            else
                                MessageBox.Show("Учетная запись с данной электронной почтой уже существует!");
                        }
                        else
                if (DBConnection.ALogin(textLogin.Text))
                        {
                            Hide();
                            MessageBox.Show("Для восстановления пароля на вашу почту отправлено сообщение с кодом подтверждения!");
                            ALogin = textLogin.Text;
                            Email(textLogin.Text, "Запрос на восстановление пароля", "<img src='https://www.company.rt.ru/about/identity/logo_new/small/RT_full_logo-RGB_Horizontal_rus_small.png'> <h1>Приветствуем</h1><hr>" + Environment.NewLine +
            "<h2>Для смены пароля вашей учетной записи Rostelecom введите код подтверждения.</h2>" + Environment.NewLine +
            "<h2>Код подтверждения - " + GenRandomString() + " </h2>").GetAwaiter();
                            ReplacePassword rp = new ReplacePassword();
                            rp.ShowDialog();
                            Close();
                        }
                        else
                            MessageBox.Show("Учетная запись с данной электронной почтой не существует!");
                    }
                    else
                        MessageBox.Show("Некорректный ввод электронной почты!");
                }
            }else
                MessageBox.Show("Отсутствует или ограниченно физическое подключение к сети...\nПроверьте настройки вашего сетевого подключения!");
        }
        //Генератор кода подтверждения
        string GenRandomString()
        {
            string Alphabet = "123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder(7);
            int Position = 0;

            for (int i = 0; i < 8; i++)
            {
                Position = rnd.Next(0, Alphabet.Length - 1);
                sb.Append(Alphabet[Position]);
            }
            AKod = sb.ToString();
            return sb.ToString();
        }
        //Закрытие программы если не удалось подключиться к базе данных, иначе, создание регистра "DATA"
        private void Login_Load(object sender, EventArgs e)
        {
            if (!DBConnection.Connect(0))
            {
                Environment.Exit(0);
            }
            if (Program.user == null)
            {
                label1.Visible = true;
                richTextBox1.Text = "Введите адрес электронной почты.";
                RegistryKey currentUserKey = Registry.Users;
                RegistryKey sub = currentUserKey.OpenSubKey(".DEFAULT");
                RegistryKey subsub = sub.OpenSubKey("Software");
                RegistryKey rostelecom = subsub.OpenSubKey("Rostelecom", true);
                RegistryKey rostelecomdata = rostelecom.OpenSubKey("Data");
                if (rostelecomdata == null)
                {
                    RegistryKey data = rostelecom.CreateSubKey("Data");
                    data.Close();
                    rostelecom.Close();
                    subsub.Close();
                    sub.Close();
                }
            }
            textLogin.Text = "";
        }
        //Отправка кода подтверждения на почту пользователя
        private static async Task Email(string login, string theme, string text)
        {
            MailAddress from = new MailAddress("rostelecomrus51@gmail.com", "Ростелеком");
            MailAddress to = new MailAddress(login, login);
            MailMessage m = new MailMessage(from, to);
            m.Subject = theme;
            m.Body = text;
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(from.Address, "RvoassTielleecvoDmRT2020");
            await smtp.SendMailAsync(m);
        }
        //Ограничение на ввод Логина пользователя, запрет на ввод кириллицы
        private void textLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 'А' && e.KeyChar < 'я')
                e.Handled = true;
        }
    }
}
