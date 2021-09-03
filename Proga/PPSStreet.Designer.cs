namespace Proga
{
    partial class PPSStreet
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupStreet = new System.Windows.Forms.GroupBox();
            this.ShowPrev = new System.Windows.Forms.Button();
            this.btnSearchStreet = new System.Windows.Forms.Button();
            this.btnHideStreet = new System.Windows.Forms.Button();
            this.btnAddStreet = new System.Windows.Forms.Button();
            this.btnEditStreet = new System.Windows.Forms.Button();
            this.btnDelStreet = new System.Windows.Forms.Button();
            this.btnUpdateStreet = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tableLayoutStreet = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupEditSotryd = new System.Windows.Forms.GroupBox();
            this.btnHideGroupSotryd2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.textEditStreet = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.editStreet = new System.Windows.Forms.Button();
            this.groupAddSotryd = new System.Windows.Forms.GroupBox();
            this.btnHideGroupSotryd1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.textAddStreet = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.addStreet = new System.Windows.Forms.Button();
            this.dataGridStreet = new System.Windows.Forms.DataGridView();
            this.ylitca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_ylitca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_gorod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupStreet.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutStreet.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupEditSotryd.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.groupAddSotryd.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStreet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupStreet
            // 
            this.groupStreet.BackColor = System.Drawing.Color.MintCream;
            this.groupStreet.Controls.Add(this.ShowPrev);
            this.groupStreet.Controls.Add(this.btnSearchStreet);
            this.groupStreet.Controls.Add(this.btnHideStreet);
            this.groupStreet.Controls.Add(this.btnAddStreet);
            this.groupStreet.Controls.Add(this.btnEditStreet);
            this.groupStreet.Controls.Add(this.btnDelStreet);
            this.groupStreet.Controls.Add(this.btnUpdateStreet);
            this.groupStreet.Controls.Add(this.tableLayoutPanel3);
            this.groupStreet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupStreet.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupStreet.Location = new System.Drawing.Point(0, 0);
            this.groupStreet.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.groupStreet.Name = "groupStreet";
            this.groupStreet.Size = new System.Drawing.Size(1004, 579);
            this.groupStreet.TabIndex = 26;
            this.groupStreet.TabStop = false;
            this.groupStreet.Text = "Улицы";
            // 
            // ShowPrev
            // 
            this.ShowPrev.BackColor = System.Drawing.Color.LavenderBlush;
            this.ShowPrev.BackgroundImage = global::Proga.Properties.Resources.icons8_шеврон_влево_24;
            this.ShowPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ShowPrev.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.ShowPrev.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.ShowPrev.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.ShowPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowPrev.Location = new System.Drawing.Point(78, 1);
            this.ShowPrev.Name = "ShowPrev";
            this.ShowPrev.Size = new System.Drawing.Size(26, 26);
            this.ShowPrev.TabIndex = 52;
            this.toolTip1.SetToolTip(this.ShowPrev, "Открыть таблицу города");
            this.ShowPrev.UseVisualStyleBackColor = false;
            this.ShowPrev.Click += new System.EventHandler(this.ShowPrev_Click);
            // 
            // btnSearchStreet
            // 
            this.btnSearchStreet.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnSearchStreet.BackgroundImage = global::Proga.Properties.Resources.icons8_поиск_24;
            this.btnSearchStreet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearchStreet.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnSearchStreet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnSearchStreet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnSearchStreet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchStreet.Location = new System.Drawing.Point(218, 1);
            this.btnSearchStreet.Name = "btnSearchStreet";
            this.btnSearchStreet.Size = new System.Drawing.Size(26, 26);
            this.btnSearchStreet.TabIndex = 51;
            this.toolTip1.SetToolTip(this.btnSearchStreet, "Поиск");
            this.btnSearchStreet.UseVisualStyleBackColor = false;
            this.btnSearchStreet.Click += new System.EventHandler(this.btnSearchStreet_Click);
            // 
            // btnHideStreet
            // 
            this.btnHideStreet.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnHideStreet.BackgroundImage = global::Proga.Properties.Resources.icons8_отмена_24;
            this.btnHideStreet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHideStreet.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnHideStreet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnHideStreet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnHideStreet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHideStreet.Location = new System.Drawing.Point(246, 1);
            this.btnHideStreet.Name = "btnHideStreet";
            this.btnHideStreet.Size = new System.Drawing.Size(26, 26);
            this.btnHideStreet.TabIndex = 50;
            this.toolTip1.SetToolTip(this.btnHideStreet, "Закрыть форму");
            this.btnHideStreet.UseVisualStyleBackColor = false;
            this.btnHideStreet.Click += new System.EventHandler(this.btnHideStreet_Click);
            // 
            // btnAddStreet
            // 
            this.btnAddStreet.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnAddStreet.BackgroundImage = global::Proga.Properties.Resources.icons8_сложение_24;
            this.btnAddStreet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddStreet.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnAddStreet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnAddStreet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnAddStreet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStreet.Location = new System.Drawing.Point(134, 1);
            this.btnAddStreet.Name = "btnAddStreet";
            this.btnAddStreet.Size = new System.Drawing.Size(26, 26);
            this.btnAddStreet.TabIndex = 47;
            this.toolTip1.SetToolTip(this.btnAddStreet, "Открыть поле для добавления");
            this.btnAddStreet.UseVisualStyleBackColor = false;
            this.btnAddStreet.Click += new System.EventHandler(this.btnAddStreet_Click);
            // 
            // btnEditStreet
            // 
            this.btnEditStreet.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnEditStreet.BackgroundImage = global::Proga.Properties.Resources.icons8_редактировать_24;
            this.btnEditStreet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditStreet.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnEditStreet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnEditStreet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnEditStreet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditStreet.Location = new System.Drawing.Point(162, 1);
            this.btnEditStreet.Name = "btnEditStreet";
            this.btnEditStreet.Size = new System.Drawing.Size(26, 26);
            this.btnEditStreet.TabIndex = 48;
            this.toolTip1.SetToolTip(this.btnEditStreet, "Открыть поле для редактирования");
            this.btnEditStreet.UseVisualStyleBackColor = false;
            this.btnEditStreet.Click += new System.EventHandler(this.btnEditStreet_Click);
            // 
            // btnDelStreet
            // 
            this.btnDelStreet.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnDelStreet.BackgroundImage = global::Proga.Properties.Resources.icons8_удалить_24;
            this.btnDelStreet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelStreet.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnDelStreet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnDelStreet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnDelStreet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelStreet.Location = new System.Drawing.Point(190, 1);
            this.btnDelStreet.Name = "btnDelStreet";
            this.btnDelStreet.Size = new System.Drawing.Size(26, 26);
            this.btnDelStreet.TabIndex = 49;
            this.toolTip1.SetToolTip(this.btnDelStreet, "Удалить запись");
            this.btnDelStreet.UseVisualStyleBackColor = false;
            this.btnDelStreet.Click += new System.EventHandler(this.btnDelStreet_Click);
            // 
            // btnUpdateStreet
            // 
            this.btnUpdateStreet.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnUpdateStreet.BackgroundImage = global::Proga.Properties.Resources.icons8_обновить_24;
            this.btnUpdateStreet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpdateStreet.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnUpdateStreet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnUpdateStreet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnUpdateStreet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStreet.Location = new System.Drawing.Point(106, 1);
            this.btnUpdateStreet.Name = "btnUpdateStreet";
            this.btnUpdateStreet.Size = new System.Drawing.Size(26, 26);
            this.btnUpdateStreet.TabIndex = 44;
            this.toolTip1.SetToolTip(this.btnUpdateStreet, "Обновить");
            this.btnUpdateStreet.UseVisualStyleBackColor = false;
            this.btnUpdateStreet.Click += new System.EventHandler(this.btnUpdateStreet_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutStreet, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 27);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(998, 549);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.08194F));
            this.tableLayoutPanel7.Controls.Add(this.listBox1, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 469);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(998, 80);
            this.tableLayoutPanel7.TabIndex = 25;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.Items.AddRange(new object[] {
            "Начало работы со справочником Улиц"});
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Margin = new System.Windows.Forms.Padding(0);
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new System.Drawing.Size(998, 80);
            this.listBox1.TabIndex = 29;
            // 
            // tableLayoutStreet
            // 
            this.tableLayoutStreet.ColumnCount = 1;
            this.tableLayoutStreet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutStreet.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutStreet.Controls.Add(this.dataGridStreet, 0, 0);
            this.tableLayoutStreet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutStreet.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutStreet.Name = "tableLayoutStreet";
            this.tableLayoutStreet.RowCount = 2;
            this.tableLayoutStreet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutStreet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutStreet.Size = new System.Drawing.Size(992, 463);
            this.tableLayoutStreet.TabIndex = 26;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.groupEditSotryd);
            this.panel1.Controls.Add(this.groupAddSotryd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 466);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(986, 1);
            this.panel1.TabIndex = 30;
            // 
            // groupEditSotryd
            // 
            this.groupEditSotryd.AutoSize = true;
            this.groupEditSotryd.Controls.Add(this.btnHideGroupSotryd2);
            this.groupEditSotryd.Controls.Add(this.tableLayoutPanel5);
            this.groupEditSotryd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupEditSotryd.Location = new System.Drawing.Point(0, -255);
            this.groupEditSotryd.Margin = new System.Windows.Forms.Padding(0);
            this.groupEditSotryd.Name = "groupEditSotryd";
            this.groupEditSotryd.Padding = new System.Windows.Forms.Padding(0);
            this.groupEditSotryd.Size = new System.Drawing.Size(986, 128);
            this.groupEditSotryd.TabIndex = 36;
            this.groupEditSotryd.TabStop = false;
            this.groupEditSotryd.Text = "Изменение";
            this.groupEditSotryd.Visible = false;
            // 
            // btnHideGroupSotryd2
            // 
            this.btnHideGroupSotryd2.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnHideGroupSotryd2.BackgroundImage = global::Proga.Properties.Resources.icons8_отмена_24;
            this.btnHideGroupSotryd2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHideGroupSotryd2.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnHideGroupSotryd2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnHideGroupSotryd2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnHideGroupSotryd2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHideGroupSotryd2.Location = new System.Drawing.Point(121, 0);
            this.btnHideGroupSotryd2.Name = "btnHideGroupSotryd2";
            this.btnHideGroupSotryd2.Size = new System.Drawing.Size(26, 26);
            this.btnHideGroupSotryd2.TabIndex = 24;
            this.toolTip1.SetToolTip(this.btnHideGroupSotryd2, "Закрытие поля редактирования");
            this.btnHideGroupSotryd2.UseVisualStyleBackColor = false;
            this.btnHideGroupSotryd2.Click += new System.EventHandler(this.Close);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.editStreet, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(986, 104);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.textEditStreet, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(986, 64);
            this.tableLayoutPanel6.TabIndex = 3;
            // 
            // textEditStreet
            // 
            this.textEditStreet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditStreet.Location = new System.Drawing.Point(3, 38);
            this.textEditStreet.MaxLength = 30;
            this.textEditStreet.Name = "textEditStreet";
            this.textEditStreet.Size = new System.Drawing.Size(980, 26);
            this.textEditStreet.TabIndex = 14;
            this.textEditStreet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEditStreet_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(980, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Улица";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // editStreet
            // 
            this.editStreet.AutoSize = true;
            this.editStreet.BackColor = System.Drawing.Color.LavenderBlush;
            this.editStreet.Dock = System.Windows.Forms.DockStyle.Right;
            this.editStreet.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.editStreet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.editStreet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.editStreet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editStreet.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editStreet.Location = new System.Drawing.Point(887, 67);
            this.editStreet.Name = "editStreet";
            this.editStreet.Size = new System.Drawing.Size(96, 34);
            this.editStreet.TabIndex = 24;
            this.editStreet.Text = "Изменить";
            this.editStreet.UseVisualStyleBackColor = false;
            this.editStreet.Click += new System.EventHandler(this.editStreet_Click);
            // 
            // groupAddSotryd
            // 
            this.groupAddSotryd.AutoSize = true;
            this.groupAddSotryd.Controls.Add(this.btnHideGroupSotryd1);
            this.groupAddSotryd.Controls.Add(this.tableLayoutPanel2);
            this.groupAddSotryd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupAddSotryd.Location = new System.Drawing.Point(0, -127);
            this.groupAddSotryd.Margin = new System.Windows.Forms.Padding(0);
            this.groupAddSotryd.Name = "groupAddSotryd";
            this.groupAddSotryd.Padding = new System.Windows.Forms.Padding(0);
            this.groupAddSotryd.Size = new System.Drawing.Size(986, 128);
            this.groupAddSotryd.TabIndex = 34;
            this.groupAddSotryd.TabStop = false;
            this.groupAddSotryd.Text = "Добавление";
            this.groupAddSotryd.Visible = false;
            // 
            // btnHideGroupSotryd1
            // 
            this.btnHideGroupSotryd1.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnHideGroupSotryd1.BackgroundImage = global::Proga.Properties.Resources.icons8_отмена_24;
            this.btnHideGroupSotryd1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHideGroupSotryd1.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnHideGroupSotryd1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnHideGroupSotryd1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnHideGroupSotryd1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHideGroupSotryd1.Location = new System.Drawing.Point(121, 1);
            this.btnHideGroupSotryd1.Name = "btnHideGroupSotryd1";
            this.btnHideGroupSotryd1.Size = new System.Drawing.Size(26, 26);
            this.btnHideGroupSotryd1.TabIndex = 23;
            this.toolTip1.SetToolTip(this.btnHideGroupSotryd1, "Закрытие поля добавления");
            this.btnHideGroupSotryd1.UseVisualStyleBackColor = false;
            this.btnHideGroupSotryd1.Click += new System.EventHandler(this.Close);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.MintCream;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.addStreet, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(986, 104);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.textAddStreet, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(986, 64);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // textAddStreet
            // 
            this.textAddStreet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textAddStreet.Location = new System.Drawing.Point(3, 38);
            this.textAddStreet.MaxLength = 30;
            this.textAddStreet.Name = "textAddStreet";
            this.textAddStreet.Size = new System.Drawing.Size(980, 26);
            this.textAddStreet.TabIndex = 17;
            this.textAddStreet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textAddStreet_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(3, 3);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(980, 29);
            this.label12.TabIndex = 0;
            this.label12.Text = "Улица";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addStreet
            // 
            this.addStreet.AutoSize = true;
            this.addStreet.BackColor = System.Drawing.Color.LavenderBlush;
            this.addStreet.Dock = System.Windows.Forms.DockStyle.Right;
            this.addStreet.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.addStreet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.addStreet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.addStreet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addStreet.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addStreet.Location = new System.Drawing.Point(887, 67);
            this.addStreet.Name = "addStreet";
            this.addStreet.Size = new System.Drawing.Size(96, 34);
            this.addStreet.TabIndex = 24;
            this.addStreet.Text = "Добавить";
            this.addStreet.UseVisualStyleBackColor = false;
            this.addStreet.Click += new System.EventHandler(this.addStreet_Click);
            // 
            // dataGridStreet
            // 
            this.dataGridStreet.AllowUserToAddRows = false;
            this.dataGridStreet.AllowUserToDeleteRows = false;
            this.dataGridStreet.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridStreet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridStreet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridStreet.BackgroundColor = System.Drawing.Color.LavenderBlush;
            this.dataGridStreet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridStreet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ylitca,
            this.id_ylitca,
            this.id_gorod});
            this.dataGridStreet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridStreet.Location = new System.Drawing.Point(3, 3);
            this.dataGridStreet.Name = "dataGridStreet";
            this.dataGridStreet.ReadOnly = true;
            this.dataGridStreet.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridStreet.RowHeadersVisible = false;
            this.dataGridStreet.RowHeadersWidth = 25;
            this.dataGridStreet.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridStreet.Size = new System.Drawing.Size(986, 457);
            this.dataGridStreet.TabIndex = 23;
            this.dataGridStreet.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridStreet_CellMouseClick);
            // 
            // ylitca
            // 
            this.ylitca.DataPropertyName = "ylitca";
            this.ylitca.HeaderText = "Улица";
            this.ylitca.Name = "ylitca";
            this.ylitca.ReadOnly = true;
            // 
            // id_ylitca
            // 
            this.id_ylitca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id_ylitca.DataPropertyName = "id_ylitca";
            this.id_ylitca.HeaderText = "Номер улицы";
            this.id_ylitca.Name = "id_ylitca";
            this.id_ylitca.ReadOnly = true;
            this.id_ylitca.Visible = false;
            // 
            // id_gorod
            // 
            this.id_gorod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id_gorod.DataPropertyName = "id_gorod";
            this.id_gorod.HeaderText = "Город";
            this.id_gorod.Name = "id_gorod";
            this.id_gorod.ReadOnly = true;
            this.id_gorod.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // PPSStreet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupStreet);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PPSStreet";
            this.Size = new System.Drawing.Size(1004, 579);
            this.Load += new System.EventHandler(this.PPSStreet_Load);
            this.groupStreet.ResumeLayout(false);
            this.groupStreet.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutStreet.ResumeLayout(false);
            this.tableLayoutStreet.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupEditSotryd.ResumeLayout(false);
            this.groupEditSotryd.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.groupAddSotryd.ResumeLayout(false);
            this.groupAddSotryd.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStreet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupStreet;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutStreet;
        private System.Windows.Forms.Button btnHideStreet;
        private System.Windows.Forms.Button btnAddStreet;
        private System.Windows.Forms.Button btnEditStreet;
        private System.Windows.Forms.Button btnDelStreet;
        private System.Windows.Forms.Button btnUpdateStreet;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnSearchStreet;
        private System.Windows.Forms.TextBox textEditStreet;
        private System.Windows.Forms.TextBox textAddStreet;
        private System.Windows.Forms.DataGridView dataGridStreet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupEditSotryd;
        private System.Windows.Forms.Button btnHideGroupSotryd2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button editStreet;
        private System.Windows.Forms.GroupBox groupAddSotryd;
        private System.Windows.Forms.Button btnHideGroupSotryd1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button addStreet;
        private System.Windows.Forms.DataGridViewTextBoxColumn ylitca;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_ylitca;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_gorod;
        private System.Windows.Forms.Button ShowPrev;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}
