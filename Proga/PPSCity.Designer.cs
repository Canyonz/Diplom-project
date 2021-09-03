namespace Proga
{
    partial class PPSCity
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
            this.groupCity = new System.Windows.Forms.GroupBox();
            this.btnSearchCity = new System.Windows.Forms.Button();
            this.btnHideCity = new System.Windows.Forms.Button();
            this.btnAddCity = new System.Windows.Forms.Button();
            this.btnEditCity = new System.Windows.Forms.Button();
            this.btnDelCity = new System.Windows.Forms.Button();
            this.btnUpdateCity = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tableLayoutCity = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridCity = new System.Windows.Forms.DataGridView();
            this.id_gorod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gorod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupEditSotryd = new System.Windows.Forms.GroupBox();
            this.btnHideGroupSotryd2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.textEditCity = new System.Windows.Forms.TextBox();
            this.editCity = new System.Windows.Forms.Button();
            this.groupAddSotryd = new System.Windows.Forms.GroupBox();
            this.btnHideGroupSotryd1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.textAddCity = new System.Windows.Forms.TextBox();
            this.addCity = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupCity.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutCity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCity)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupEditSotryd.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.groupAddSotryd.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupCity
            // 
            this.groupCity.BackColor = System.Drawing.Color.MintCream;
            this.groupCity.Controls.Add(this.btnSearchCity);
            this.groupCity.Controls.Add(this.btnHideCity);
            this.groupCity.Controls.Add(this.btnAddCity);
            this.groupCity.Controls.Add(this.btnEditCity);
            this.groupCity.Controls.Add(this.btnDelCity);
            this.groupCity.Controls.Add(this.btnUpdateCity);
            this.groupCity.Controls.Add(this.tableLayoutPanel3);
            this.groupCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupCity.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupCity.Location = new System.Drawing.Point(0, 0);
            this.groupCity.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.groupCity.Name = "groupCity";
            this.groupCity.Size = new System.Drawing.Size(1080, 550);
            this.groupCity.TabIndex = 26;
            this.groupCity.TabStop = false;
            this.groupCity.Text = "Города";
            // 
            // btnSearchCity
            // 
            this.btnSearchCity.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnSearchCity.BackgroundImage = global::Proga.Properties.Resources.icons8_поиск_24;
            this.btnSearchCity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearchCity.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnSearchCity.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnSearchCity.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnSearchCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchCity.Location = new System.Drawing.Point(199, 1);
            this.btnSearchCity.Name = "btnSearchCity";
            this.btnSearchCity.Size = new System.Drawing.Size(26, 26);
            this.btnSearchCity.TabIndex = 51;
            this.toolTip1.SetToolTip(this.btnSearchCity, "Поиск");
            this.btnSearchCity.UseVisualStyleBackColor = false;
            this.btnSearchCity.Click += new System.EventHandler(this.btnSearchCity_Click);
            // 
            // btnHideCity
            // 
            this.btnHideCity.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnHideCity.BackgroundImage = global::Proga.Properties.Resources.icons8_отмена_24;
            this.btnHideCity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHideCity.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnHideCity.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnHideCity.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnHideCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHideCity.Location = new System.Drawing.Point(227, 1);
            this.btnHideCity.Name = "btnHideCity";
            this.btnHideCity.Size = new System.Drawing.Size(26, 26);
            this.btnHideCity.TabIndex = 50;
            this.toolTip1.SetToolTip(this.btnHideCity, "Закрыть форму");
            this.btnHideCity.UseVisualStyleBackColor = false;
            this.btnHideCity.Click += new System.EventHandler(this.btnHideCity_Click);
            // 
            // btnAddCity
            // 
            this.btnAddCity.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnAddCity.BackgroundImage = global::Proga.Properties.Resources.icons8_сложение_24;
            this.btnAddCity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddCity.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnAddCity.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnAddCity.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnAddCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCity.Location = new System.Drawing.Point(115, 1);
            this.btnAddCity.Name = "btnAddCity";
            this.btnAddCity.Size = new System.Drawing.Size(26, 26);
            this.btnAddCity.TabIndex = 47;
            this.toolTip1.SetToolTip(this.btnAddCity, "Открыть поле для добавления");
            this.btnAddCity.UseVisualStyleBackColor = false;
            this.btnAddCity.Click += new System.EventHandler(this.btnAddCity_Click);
            // 
            // btnEditCity
            // 
            this.btnEditCity.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnEditCity.BackgroundImage = global::Proga.Properties.Resources.icons8_редактировать_24;
            this.btnEditCity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditCity.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnEditCity.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnEditCity.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnEditCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditCity.Location = new System.Drawing.Point(143, 1);
            this.btnEditCity.Name = "btnEditCity";
            this.btnEditCity.Size = new System.Drawing.Size(26, 26);
            this.btnEditCity.TabIndex = 48;
            this.toolTip1.SetToolTip(this.btnEditCity, "Открыть поле для редактирования");
            this.btnEditCity.UseVisualStyleBackColor = false;
            this.btnEditCity.Click += new System.EventHandler(this.btnEditCity_Click);
            // 
            // btnDelCity
            // 
            this.btnDelCity.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnDelCity.BackgroundImage = global::Proga.Properties.Resources.icons8_удалить_24;
            this.btnDelCity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelCity.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnDelCity.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnDelCity.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnDelCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelCity.Location = new System.Drawing.Point(171, 1);
            this.btnDelCity.Name = "btnDelCity";
            this.btnDelCity.Size = new System.Drawing.Size(26, 26);
            this.btnDelCity.TabIndex = 49;
            this.toolTip1.SetToolTip(this.btnDelCity, "Удалить запись");
            this.btnDelCity.UseVisualStyleBackColor = false;
            this.btnDelCity.Click += new System.EventHandler(this.btnDelCity_Click);
            // 
            // btnUpdateCity
            // 
            this.btnUpdateCity.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnUpdateCity.BackgroundImage = global::Proga.Properties.Resources.icons8_обновить_24;
            this.btnUpdateCity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpdateCity.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnUpdateCity.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnUpdateCity.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnUpdateCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateCity.Location = new System.Drawing.Point(87, 1);
            this.btnUpdateCity.Name = "btnUpdateCity";
            this.btnUpdateCity.Size = new System.Drawing.Size(26, 26);
            this.btnUpdateCity.TabIndex = 44;
            this.toolTip1.SetToolTip(this.btnUpdateCity, "Обновить");
            this.btnUpdateCity.UseVisualStyleBackColor = false;
            this.btnUpdateCity.Click += new System.EventHandler(this.btnUpdateCity_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutCity, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 27);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1074, 520);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Controls.Add(this.listBox1, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 440);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(1074, 80);
            this.tableLayoutPanel7.TabIndex = 25;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.Items.AddRange(new object[] {
            "Начало работы с справочником Города"});
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Margin = new System.Windows.Forms.Padding(0);
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new System.Drawing.Size(1074, 80);
            this.listBox1.TabIndex = 29;
            // 
            // tableLayoutCity
            // 
            this.tableLayoutCity.ColumnCount = 1;
            this.tableLayoutCity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutCity.Controls.Add(this.dataGridCity, 0, 0);
            this.tableLayoutCity.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutCity.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutCity.Name = "tableLayoutCity";
            this.tableLayoutCity.RowCount = 2;
            this.tableLayoutCity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutCity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutCity.Size = new System.Drawing.Size(1068, 434);
            this.tableLayoutCity.TabIndex = 26;
            // 
            // dataGridCity
            // 
            this.dataGridCity.AllowUserToAddRows = false;
            this.dataGridCity.AllowUserToDeleteRows = false;
            this.dataGridCity.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridCity.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridCity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCity.BackgroundColor = System.Drawing.Color.LavenderBlush;
            this.dataGridCity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_gorod,
            this.gorod});
            this.dataGridCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridCity.Location = new System.Drawing.Point(3, 3);
            this.dataGridCity.Name = "dataGridCity";
            this.dataGridCity.ReadOnly = true;
            this.dataGridCity.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridCity.RowHeadersWidth = 25;
            this.dataGridCity.Size = new System.Drawing.Size(1062, 428);
            this.dataGridCity.TabIndex = 23;
            this.dataGridCity.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridCity_CellMouseClick);
            // 
            // id_gorod
            // 
            this.id_gorod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id_gorod.DataPropertyName = "id_gorod";
            this.id_gorod.HeaderText = "Номер города";
            this.id_gorod.Name = "id_gorod";
            this.id_gorod.ReadOnly = true;
            this.id_gorod.Visible = false;
            // 
            // gorod
            // 
            this.gorod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gorod.DataPropertyName = "gorod";
            this.gorod.HeaderText = "Город";
            this.gorod.Name = "gorod";
            this.gorod.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.groupEditSotryd);
            this.panel1.Controls.Add(this.groupAddSotryd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 437);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1062, 1);
            this.panel1.TabIndex = 24;
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
            this.groupEditSotryd.Size = new System.Drawing.Size(1062, 128);
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
            this.tableLayoutPanel5.Controls.Add(this.editCity, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1062, 104);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.textEditCity, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(1062, 64);
            this.tableLayoutPanel6.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1056, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Город";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textEditCity
            // 
            this.textEditCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditCity.Location = new System.Drawing.Point(3, 38);
            this.textEditCity.MaxLength = 30;
            this.textEditCity.Name = "textEditCity";
            this.textEditCity.Size = new System.Drawing.Size(1056, 26);
            this.textEditCity.TabIndex = 14;
            this.textEditCity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEditCity_KeyPress);
            // 
            // editCity
            // 
            this.editCity.AutoSize = true;
            this.editCity.BackColor = System.Drawing.Color.LavenderBlush;
            this.editCity.Dock = System.Windows.Forms.DockStyle.Right;
            this.editCity.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.editCity.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.editCity.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.editCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editCity.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editCity.Location = new System.Drawing.Point(951, 67);
            this.editCity.Name = "editCity";
            this.editCity.Size = new System.Drawing.Size(108, 34);
            this.editCity.TabIndex = 24;
            this.editCity.Text = "Изменить";
            this.editCity.UseVisualStyleBackColor = false;
            this.editCity.Click += new System.EventHandler(this.editCity_Click);
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
            this.groupAddSotryd.Size = new System.Drawing.Size(1062, 128);
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
            this.btnHideGroupSotryd1.Location = new System.Drawing.Point(121, -1);
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
            this.tableLayoutPanel2.Controls.Add(this.addCity, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1062, 104);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.textAddCity, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1062, 64);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(3, 3);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1056, 29);
            this.label12.TabIndex = 0;
            this.label12.Text = "Город";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textAddCity
            // 
            this.textAddCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textAddCity.Location = new System.Drawing.Point(3, 38);
            this.textAddCity.MaxLength = 30;
            this.textAddCity.Name = "textAddCity";
            this.textAddCity.Size = new System.Drawing.Size(1056, 26);
            this.textAddCity.TabIndex = 17;
            this.textAddCity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textAddCity_KeyPress);
            // 
            // addCity
            // 
            this.addCity.AutoSize = true;
            this.addCity.BackColor = System.Drawing.Color.LavenderBlush;
            this.addCity.Dock = System.Windows.Forms.DockStyle.Right;
            this.addCity.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.addCity.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.addCity.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.addCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addCity.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addCity.Location = new System.Drawing.Point(952, 67);
            this.addCity.Name = "addCity";
            this.addCity.Size = new System.Drawing.Size(107, 34);
            this.addCity.TabIndex = 24;
            this.addCity.Text = "Добавить";
            this.addCity.UseVisualStyleBackColor = false;
            this.addCity.Click += new System.EventHandler(this.addCity_Click);
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
            // PPSCity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupCity);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PPSCity";
            this.Size = new System.Drawing.Size(1080, 550);
            this.Load += new System.EventHandler(this.PPSCity_Load);
            this.groupCity.ResumeLayout(false);
            this.groupCity.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutCity.ResumeLayout(false);
            this.tableLayoutCity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCity)).EndInit();
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupCity;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutCity;
        private System.Windows.Forms.Button btnHideCity;
        private System.Windows.Forms.Button btnAddCity;
        private System.Windows.Forms.Button btnEditCity;
        private System.Windows.Forms.Button btnDelCity;
        private System.Windows.Forms.Button btnUpdateCity;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnSearchCity;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.DataGridView dataGridCity;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_gorod;
        private System.Windows.Forms.DataGridViewTextBoxColumn gorod;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupEditSotryd;
        private System.Windows.Forms.Button btnHideGroupSotryd2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textEditCity;
        private System.Windows.Forms.Button editCity;
        private System.Windows.Forms.GroupBox groupAddSotryd;
        private System.Windows.Forms.Button btnHideGroupSotryd1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textAddCity;
        private System.Windows.Forms.Button addCity;
    }
}
