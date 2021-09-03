namespace Proga
{
    partial class Authorization
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authorization));
            this.header = new System.Windows.Forms.Panel();
            this.pictureRT = new System.Windows.Forms.PictureBox();
            this.close = new System.Windows.Forms.Button();
            this.minimize = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.signIn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkSave = new System.Windows.Forms.CheckBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textLogin = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRT)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.White;
            this.header.Controls.Add(this.pictureRT);
            this.header.Controls.Add(this.close);
            this.header.Controls.Add(this.minimize);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(287, 83);
            this.header.TabIndex = 0;
            this.header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.header_MouseDown);
            // 
            // pictureRT
            // 
            this.pictureRT.BackgroundImage = global::Proga.Properties.Resources.RT_logo_RGB;
            this.pictureRT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureRT.Location = new System.Drawing.Point(0, 0);
            this.pictureRT.Name = "pictureRT";
            this.pictureRT.Size = new System.Drawing.Size(88, 83);
            this.pictureRT.TabIndex = 2;
            this.pictureRT.TabStop = false;
            this.pictureRT.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureRT_MouseDown);
            // 
            // close
            // 
            this.close.BackgroundImage = global::Proga.Properties.Resources.close;
            this.close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.close.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.close.FlatAppearance.BorderSize = 0;
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.ForeColor = System.Drawing.Color.Black;
            this.close.Location = new System.Drawing.Point(239, 3);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(45, 59);
            this.close.TabIndex = 0;
            this.close.TabStop = false;
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // minimize
            // 
            this.minimize.BackgroundImage = global::Proga.Properties.Resources.minimize;
            this.minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.minimize.FlatAppearance.BorderSize = 0;
            this.minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimize.ForeColor = System.Drawing.Color.Aqua;
            this.minimize.Location = new System.Drawing.Point(188, 3);
            this.minimize.Name = "minimize";
            this.minimize.Size = new System.Drawing.Size(45, 59);
            this.minimize.TabIndex = 0;
            this.minimize.TabStop = false;
            this.minimize.UseVisualStyleBackColor = false;
            this.minimize.Click += new System.EventHandler(this.minimize_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(48)))));
            this.panel4.Controls.Add(this.signIn);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 329);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(287, 64);
            this.panel4.TabIndex = 9;
            // 
            // signIn
            // 
            this.signIn.BackColor = System.Drawing.Color.White;
            this.signIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signIn.FlatAppearance.BorderSize = 0;
            this.signIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signIn.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.signIn.ForeColor = System.Drawing.Color.Black;
            this.signIn.Image = global::Proga.Properties.Resources.icons8_войти_32;
            this.signIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.signIn.Location = new System.Drawing.Point(0, 0);
            this.signIn.Name = "signIn";
            this.signIn.Padding = new System.Windows.Forms.Padding(82, 0, 82, 0);
            this.signIn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.signIn.Size = new System.Drawing.Size(287, 64);
            this.signIn.TabIndex = 2;
            this.signIn.Text = "Войти";
            this.signIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.signIn.UseVisualStyleBackColor = false;
            this.signIn.Click += new System.EventHandler(this.signIn_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.checkSave);
            this.panel5.Controls.Add(this.pictureBox4);
            this.panel5.Controls.Add(this.pictureBox3);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.textPassword);
            this.panel5.Controls.Add(this.textLogin);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 83);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(287, 246);
            this.panel5.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(93, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Забыли пароль";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // checkSave
            // 
            this.checkSave.AutoSize = true;
            this.checkSave.Checked = true;
            this.checkSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSave.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkSave.Location = new System.Drawing.Point(47, 172);
            this.checkSave.Name = "checkSave";
            this.checkSave.Size = new System.Drawing.Size(200, 22);
            this.checkSave.TabIndex = 16;
            this.checkSave.TabStop = false;
            this.checkSave.Text = "Запомнить данные для входа";
            this.checkSave.UseVisualStyleBackColor = true;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.BackgroundImage = global::Proga.Properties.Resources.icons8_login_24;
            this.pictureBox4.Location = new System.Drawing.Point(32, 51);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(24, 24);
            this.pictureBox4.TabIndex = 15;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.BackgroundImage = global::Proga.Properties.Resources.icons8_password_24;
            this.pictureBox3.Location = new System.Drawing.Point(32, 132);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(32, 157);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(225, 1);
            this.panel3.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(32, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(225, 1);
            this.panel2.TabIndex = 13;
            // 
            // textPassword
            // 
            this.textPassword.BackColor = System.Drawing.Color.White;
            this.textPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPassword.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textPassword.ForeColor = System.Drawing.Color.Black;
            this.textPassword.HideSelection = false;
            this.textPassword.Location = new System.Drawing.Point(66, 134);
            this.textPassword.MaxLength = 12;
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(191, 22);
            this.textPassword.TabIndex = 11;
            this.textPassword.Text = "Пароль";
            this.textPassword.UseSystemPasswordChar = true;
            this.textPassword.WordWrap = false;
            this.textPassword.Enter += new System.EventHandler(this.textPassword_Enter);
            this.textPassword.Leave += new System.EventHandler(this.textPassword_Leave);
            // 
            // textLogin
            // 
            this.textLogin.BackColor = System.Drawing.Color.White;
            this.textLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textLogin.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textLogin.ForeColor = System.Drawing.Color.Black;
            this.textLogin.Location = new System.Drawing.Point(66, 53);
            this.textLogin.MaxLength = 40;
            this.textLogin.Name = "textLogin";
            this.textLogin.Size = new System.Drawing.Size(191, 22);
            this.textLogin.TabIndex = 10;
            this.textLogin.Text = "Логин";
            this.textLogin.Enter += new System.EventHandler(this.textLogin_Enter);
            this.textLogin.Leave += new System.EventHandler(this.textLogin_Leave);
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(287, 393);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.header);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Authorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ростелеком";
            this.Load += new System.EventHandler(this.Authorization_Load);
            this.header.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureRT)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button minimize;
        private System.Windows.Forms.PictureBox pictureRT;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button signIn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textLogin;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.CheckBox checkSave;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Timer timer1;
    }
}

