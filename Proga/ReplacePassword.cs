using Microsoft.Win32;
using Proga.Properties;
using System;
using System.Windows.Forms;

namespace Proga
{
    public partial class ReplacePassword : Form
    {
        public ReplacePassword()
        {
            InitializeComponent();
            Confiq conf = new Confiq();
            conf.ResetBackColor(this, Settings.Default.BackColorMain);
            conf.ResetForeColor(this, Settings.Default.ForeColor);
            panel2.BackColor = Settings.Default.ForeColor;
            panel6.BackColor = Settings.Default.ForeColor;
            panel7.BackColor = Settings.Default.ForeColor;
            panel8.BackColor = Settings.Default.ForeColor;
            panel1.BackColor = Settings.Default.ForeColor;
            panel3.BackColor = Settings.Default.ForeColor;
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
        //Регистрация или восстановление пароля пользователя
        private void Reestablish_Click(object sender, EventArgs e)
        {
            if (textKode.Text == Login.AKod)
            {
                if (!String.IsNullOrEmpty(textPassword.Text) && !String.IsNullOrEmpty(textPasswordr.Text))
                {
                    if (textPassword.TextLength >=8 && textPasswordr.TextLength >= 8)
                    {
                        if (textPassword.Text == textPasswordr.Text)
                        {
                            RegistryKey currentUserKey = Registry.Users;
                            RegistryKey sub = currentUserKey.OpenSubKey(".DEFAULT", true);
                            RegistryKey subsub = sub.OpenSubKey("Software", true);
                            RegistryKey rostelecom = subsub.OpenSubKey("Rostelecom",true);
                            if (Program.user == null)
                            {
                                if (DBConnection.Autho(textBoxFIO.Text, textBoxAdres.Text, textBoxPhone.Text, Login.ALogin, textPasswordr.Text))
                                {
                                    Hide();
                                    MessageBox.Show("Поздравляю, вы успешно зарегистрировались!");
                                    RegistryKey User = rostelecom.CreateSubKey("User");
                                    Program.user = rostelecom.OpenSubKey("User");
                                    User.Close();
                                    rostelecom.Close();
                                    subsub.Close();
                                    sub.Close();
                                    Close();
                                }
                            }
                            else
                            {
                                DBConnection.EditTableAuthorization(Login.ALogin, textPasswordr.Text, false);
                                MessageBox.Show("Пароль успешно восстановлен!");
                                Close();
                            }
                        }
                        else
                            MessageBox.Show("Пароли не совпадают!");
                    }else
                        MessageBox.Show("Пароль должен состоять не меньше 8 символов!");
                }
            }
            else
                MessageBox.Show("Код подтверждения не совпадает!");
        }
        private void ReplacePassword_Load(object sender, EventArgs e)
        {
            textKode.Text = "";
            textPassword.Text = "";
            if (Program.user == null)
            {
                reestablish.Text = "Создать";
                this.Height = 450;
            }

        }
        //Ограничение на ввод кириллицы
        private void textKode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'A' || e.KeyChar > 'z') && (e.KeyChar < '0' || e.KeyChar > '9') && Control.ModifierKeys != Keys.Control && e.KeyChar != 8)
                e.Handled = true;
        }
        //Ограничение на ввод кириллицы
        private void textPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'A' || e.KeyChar > 'z') && (e.KeyChar < '0' || e.KeyChar > '9') && Control.ModifierKeys != Keys.Control && e.KeyChar != 8)
                e.Handled = true;
        }
        //Ограничение на ввод кириллицы
        private void textPasswordr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'A' || e.KeyChar > 'z') && (e.KeyChar < '0' || e.KeyChar > '9') && Control.ModifierKeys != Keys.Control && e.KeyChar != 8)
                e.Handled = true;
        }
        //Ограничение на ввод только кириллицы
        private void textBoxFIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        //Ограничение на ввод кириллицы
        private void textBoxAdres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'А' || e.KeyChar > 'я') && (e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
    }
}
