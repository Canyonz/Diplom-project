using System;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPSAccessUsers : UserControl
    {
        public PPSAccessUsers()
        {
            InitializeComponent();
        }

        //ПОДКЛЮЧЕНИЕ К ТАБЛИЦЕ В БАЗЕ ДАННЫХ И ОБНОВЛЕНИЕ ДАННЫХ В ТАБЛИЦЕ
        private void Connect()
        {
            DBConnection.ShowTableAccessUsers();
            dataGridAccessUsers.DataSource = DBConnection.s_AccessUsers;
        }
        //ОТКРЫТИЕ ПОЛЯ ДЛЯ ДОБАВЛЕНИЯ ДАННЫХ
        private void btnAddAccessUsers_Click(object sender, EventArgs e)
        {
            tableLayoutRole.ColumnStyles[1].Width = 400;
            hideShow.Visible = true;
            showAddRole_Click(sender, e);
        }

        //ОТКРЫТИЕ ПОЛЯ ДЛЯ РЕДАКТИРОВАНИЯ ДАННЫХ
        private void btnEditAccessUsers_Click(object sender, EventArgs e)
        {
            tableLayoutRole.ColumnStyles[1].Width = 400;
            hideShow.Visible = true;
            showEditRole_Click(sender, e);
        }

        //ОТКРЫТИЕ ПОЛЯ ДЛЯ УДАЛЕНИЯ ДАННЫХ
        private void btnDelAccessUsers_Click(object sender, EventArgs e)
        {
            tableLayoutRole.ColumnStyles[1].Width = 400;
            hideShow.Visible = true;
            showDelRole_Click(sender, e);
        }

        //ЗАКРЫТИЕ ФОРМЫ
        private void btnHideAccessUsers_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        //ОТКРЫТИЕ ПОЛЯ ДЛЯ ДОБАВЛЕНИЯ ДАННЫХ
        private void showAddRole_Click(object sender, EventArgs e)
        {
            panelAddRole.Visible = true;
            panelEditRole.Visible = false;
            panelDelRole.Visible = false;
        }

        //ОТКРЫТИЕ ПОЛЯ ДЛЯ РЕДАКТИРОВАНИЯ ДАННЫХ
        private void showEditRole_Click(object sender, EventArgs e)
        {
            panelAddRole.Visible = false;
            panelEditRole.Visible = true;
            panelDelRole.Visible = false;
        }

        //ОТКРЫТИЕ ПОЛЯ ДЛЯ УДАЛЕНИЯ ДАННЫХ
        private void showDelRole_Click(object sender, EventArgs e)
        {
            panelAddRole.Visible = false;
            panelEditRole.Visible = false;
            panelDelRole.Visible = true;
        }

        //ЗАКРЫТИЕ ПОЛЯ ДЛЯ РЕДАКТИРОАНИЯ ТАБЛИЦЫ
        private void hideShow_Click(object sender, EventArgs e)
        {
            if (tableLayoutRole.ColumnStyles[1].Width == 400)
            {
                tableLayoutRole.ColumnStyles[1].Width = 0;
                hideShow.Visible = false;
            }
        }

        //ДОБАВЛЕНИЕ ЗАПИСИ В ТАБЛИЦУ
        private void addRole_Click(object sender, EventArgs e)
        {
            if (DBConnection.AddTableAccessUsers(textAddRole.Text))
            {
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " Запись '" + textAddRole.Text + "' была успешно добавлена!");
            }
            Connect();
        }

        //РЕДАКТИРОВАНИЕ ЗАПИСИ В ТАБЛИЦЕ
        private void editRole_Click(object sender, EventArgs e)
        {
            int key_r = Convert.ToInt32(dataGridAccessUsers.CurrentRow.Cells[0].Value);
            if (DBConnection.EditTableAccessUsers(key_r, textEditRole.Text))
            {
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " Запись '" + textEditRole.Text + "' была успешно обновлена!");
            }
            Connect();
        }

        //ПОДТВЕРЖЕНИЕ НА УДАЛЕНИЕ ЗАПИСИ ИЗ ТАБЛИЦЫ
        private void delRoleY_Click(object sender, EventArgs e)
        {
            int key_r = Convert.ToInt32(dataGridAccessUsers.CurrentRow.Cells[0].Value);
            string record = dataGridAccessUsers.CurrentRow.Cells[1].Value.ToString();
            if (DBConnection.DellTableAccessUsers(key_r))
            {
                listBox1.Items.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " Запись '" + record + "' была успешно удалена!");
            }
            Connect();
        }

        //ОТМЕНА УДАЛЕНИЯ ЗАПИСИ ИЗ ТАБЛИЦЫ
        private void delRoleN_Click(object sender, EventArgs e)
        {
            hideShow_Click(sender, e);
        }

        //ПОДКЛЮЧЕНИЕ БАЗЫ ДАННЫХ К ТАБЛИЦЕ
        private void PPSAccessUsers_Load(object sender, EventArgs e)
        {
            dataGridAccessUsers.DataSource = DBConnection.s_AccessUsers;
        }
    }
}
