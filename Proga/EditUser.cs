using Proga.Properties;
using System;
using System.Windows.Forms;

namespace Proga
{
    public partial class EditUser : Form
    {
        public EditUser()
        {
            InitializeComponent();
            Confiq conf = new Confiq();
            conf.ResetBackColor(this, Settings.Default.BackColorMain);
            conf.ResetForeColor(this, Settings.Default.ForeColor);
            panel1.BackColor = Settings.Default.ForeColor;
            panel2.BackColor = Settings.Default.ForeColor;
            panel3.BackColor = Settings.Default.ForeColor;
            conf.ResetBackColorButton(panel4);
        }
        //Перетаскивание формы за шапку формы
        private void header_MouseDown(object sender, MouseEventArgs e)
        {
            header.Capture = false;
            Message m = Message.Create(this.Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }
        //Перетаскивание формы за картинку формы
        private void pictureRT_MouseDown(object sender, MouseEventArgs e)
        {
            pictureRT.Capture = false;
            Message m = Message.Create(this.Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }
        //Закрытие формы
        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Изменение пароля пользователя
        private void EditLP_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textPassword.Text) && !String.IsNullOrEmpty(textPasswordr.Text))
            {
                if (textPassword.TextLength >= 8 && textPasswordr.TextLength >= 8)
                {
                    if (textPassword.Text == textPasswordr.Text)
                    {
                        DBConnection.EditTableAuthorization(textLogin.Text, textPasswordr.Text, true);
                        Settings.Default.saveuser = 0;
                        Close();
                    }
                    else
                        MessageBox.Show("Пароли не совпадают!");
                }
                else
                    MessageBox.Show("Пароль должен состоять не меньше 8 символов!");
            }
        }

        private void EditUser_Load(object sender, EventArgs e)
        {
            textLogin.Text = DBConnection.UserAuthorizationL;
            textPassword.Text = DBConnection.UserAuthorizationP;
            textPasswordr.Text = DBConnection.UserAuthorizationP;
        }
        //Ограничение на ввод только англ.символов и цифр
        private void textPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'A' || e.KeyChar > 'z') && (e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
                e.Handled = true;
        }
        //Ограничение на ввод только англ. символов и цифр
        private void textPasswordr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 'A' || e.KeyChar > 'z') && (e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
