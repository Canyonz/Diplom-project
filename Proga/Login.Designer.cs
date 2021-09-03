namespace Proga
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textLogin = new System.Windows.Forms.TextBox();
            this.header = new System.Windows.Forms.Panel();
            this.pictureRT = new System.Windows.Forms.PictureBox();
            this.close = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.next = new System.Windows.Forms.Button();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRT)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.richTextBox1);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.pictureBox4);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.textLogin);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 54);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(287, 274);
            this.panel5.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(51, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 22);
            this.label1.TabIndex = 23;
            this.label1.Text = "Добро пожаловать";
            this.label1.Visible = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(22, 121);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.ShortcutsEnabled = false;
            this.richTextBox1.Size = new System.Drawing.Size(262, 41);
            this.richTextBox1.TabIndex = 22;
            this.richTextBox1.Text = "Введите адрес электронной почты, использовавшийся при регистрации.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(42, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 18);
            this.label2.TabIndex = 21;
            this.label2.Text = "Адрес электронной почты";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.BackgroundImage = global::Proga.Properties.Resources.icons8_login_24;
            this.pictureBox4.Location = new System.Drawing.Point(24, 197);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(24, 24);
            this.pictureBox4.TabIndex = 15;
            this.pictureBox4.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(24, 222);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(251, 1);
            this.panel2.TabIndex = 13;
            // 
            // textLogin
            // 
            this.textLogin.BackColor = System.Drawing.Color.White;
            this.textLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textLogin.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textLogin.ForeColor = System.Drawing.Color.Black;
            this.textLogin.Location = new System.Drawing.Point(55, 199);
            this.textLogin.MaxLength = 50;
            this.textLogin.Name = "textLogin";
            this.textLogin.Size = new System.Drawing.Size(217, 22);
            this.textLogin.TabIndex = 10;
            this.textLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textLogin_KeyPress);
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.White;
            this.header.Controls.Add(this.pictureRT);
            this.header.Controls.Add(this.close);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(287, 54);
            this.header.TabIndex = 11;
            this.header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.header_MouseDown);
            // 
            // pictureRT
            // 
            this.pictureRT.BackgroundImage = global::Proga.Properties.Resources.RT_logo_RGB;
            this.pictureRT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureRT.Location = new System.Drawing.Point(0, 0);
            this.pictureRT.Name = "pictureRT";
            this.pictureRT.Size = new System.Drawing.Size(61, 51);
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
            this.close.Size = new System.Drawing.Size(45, 48);
            this.close.TabIndex = 0;
            this.close.TabStop = false;
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(48)))));
            this.panel4.Controls.Add(this.next);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 328);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(287, 64);
            this.panel4.TabIndex = 12;
            // 
            // next
            // 
            this.next.BackColor = System.Drawing.Color.White;
            this.next.Dock = System.Windows.Forms.DockStyle.Fill;
            this.next.FlatAppearance.BorderSize = 0;
            this.next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.next.ForeColor = System.Drawing.Color.Black;
            this.next.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.next.Location = new System.Drawing.Point(0, 0);
            this.next.Name = "next";
            this.next.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.next.Size = new System.Drawing.Size(287, 64);
            this.next.TabIndex = 2;
            this.next.Text = "Продолжить";
            this.next.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.next.UseVisualStyleBackColor = false;
            this.next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 392);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.header);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ростелеком";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.header.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureRT)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textLogin;
        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.PictureBox pictureRT;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.RichTextBox richTextBox1;
    }
}