namespace Proga
{
    partial class PPTNakladnaya
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
            this.groupNaklad = new System.Windows.Forms.GroupBox();
            this.btnSearchNaklad = new System.Windows.Forms.Button();
            this.btnHideNaklad = new System.Windows.Forms.Button();
            this.btnAddNaklad = new System.Windows.Forms.Button();
            this.btnEditNaklad = new System.Windows.Forms.Button();
            this.btnDelNaklad = new System.Windows.Forms.Button();
            this.btnUpdateNaklad = new System.Windows.Forms.Button();
            this.tableLayoutPanel30 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel31 = new System.Windows.Forms.TableLayoutPanel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tableLayoutNaklad = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupEditNaklad = new System.Windows.Forms.GroupBox();
            this.btnHideGroupNaklad2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dateTimeEditNakladDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxEditNakladNaklad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxEditNakladPostav = new System.Windows.Forms.ComboBox();
            this.editNaklad = new System.Windows.Forms.Button();
            this.groupAddNaklad = new System.Windows.Forms.GroupBox();
            this.btnHideGroupNaklad1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.dateTimeAddNakladDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxAddNakladNaklad = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxAddNakladPostav = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addNaklad = new System.Windows.Forms.Button();
            this.dataGridNaklad = new System.Windows.Forms.DataGridView();
            this.numnaklad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_postavshik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datenakl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_nakladnaya = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupNaklad.SuspendLayout();
            this.tableLayoutPanel30.SuspendLayout();
            this.tableLayoutPanel31.SuspendLayout();
            this.tableLayoutNaklad.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupEditNaklad.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupAddNaklad.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNaklad)).BeginInit();
            this.SuspendLayout();
            // 
            // groupNaklad
            // 
            this.groupNaklad.BackColor = System.Drawing.Color.MintCream;
            this.groupNaklad.Controls.Add(this.btnSearchNaklad);
            this.groupNaklad.Controls.Add(this.btnHideNaklad);
            this.groupNaklad.Controls.Add(this.btnAddNaklad);
            this.groupNaklad.Controls.Add(this.btnEditNaklad);
            this.groupNaklad.Controls.Add(this.btnDelNaklad);
            this.groupNaklad.Controls.Add(this.btnUpdateNaklad);
            this.groupNaklad.Controls.Add(this.tableLayoutPanel30);
            this.groupNaklad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupNaklad.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupNaklad.Location = new System.Drawing.Point(0, 0);
            this.groupNaklad.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.groupNaklad.Name = "groupNaklad";
            this.groupNaklad.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.groupNaklad.Size = new System.Drawing.Size(1145, 555);
            this.groupNaklad.TabIndex = 30;
            this.groupNaklad.TabStop = false;
            this.groupNaklad.Text = "Накладная";
            // 
            // btnSearchNaklad
            // 
            this.btnSearchNaklad.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnSearchNaklad.BackgroundImage = global::Proga.Properties.Resources.icons8_поиск_24;
            this.btnSearchNaklad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearchNaklad.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnSearchNaklad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnSearchNaklad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnSearchNaklad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchNaklad.Location = new System.Drawing.Point(224, 1);
            this.btnSearchNaklad.Name = "btnSearchNaklad";
            this.btnSearchNaklad.Size = new System.Drawing.Size(26, 26);
            this.btnSearchNaklad.TabIndex = 37;
            this.toolTip1.SetToolTip(this.btnSearchNaklad, "Поиск");
            this.btnSearchNaklad.UseVisualStyleBackColor = false;
            this.btnSearchNaklad.Click += new System.EventHandler(this.btnSearchNaklad_Click);
            // 
            // btnHideNaklad
            // 
            this.btnHideNaklad.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnHideNaklad.BackgroundImage = global::Proga.Properties.Resources.icons8_отмена_24;
            this.btnHideNaklad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHideNaklad.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnHideNaklad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnHideNaklad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnHideNaklad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHideNaklad.Location = new System.Drawing.Point(252, 1);
            this.btnHideNaklad.Name = "btnHideNaklad";
            this.btnHideNaklad.Size = new System.Drawing.Size(26, 26);
            this.btnHideNaklad.TabIndex = 22;
            this.toolTip1.SetToolTip(this.btnHideNaklad, "Закрыть форму");
            this.btnHideNaklad.UseVisualStyleBackColor = false;
            this.btnHideNaklad.Click += new System.EventHandler(this.btnHideNaklad_Click);
            // 
            // btnAddNaklad
            // 
            this.btnAddNaklad.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnAddNaklad.BackgroundImage = global::Proga.Properties.Resources.icons8_сложение_24;
            this.btnAddNaklad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNaklad.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnAddNaklad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnAddNaklad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnAddNaklad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNaklad.Location = new System.Drawing.Point(140, 1);
            this.btnAddNaklad.Name = "btnAddNaklad";
            this.btnAddNaklad.Size = new System.Drawing.Size(26, 26);
            this.btnAddNaklad.TabIndex = 18;
            this.toolTip1.SetToolTip(this.btnAddNaklad, "Открыть поле для добавления");
            this.btnAddNaklad.UseVisualStyleBackColor = false;
            this.btnAddNaklad.Click += new System.EventHandler(this.btnAddNaklad_Click);
            // 
            // btnEditNaklad
            // 
            this.btnEditNaklad.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnEditNaklad.BackgroundImage = global::Proga.Properties.Resources.icons8_редактировать_24;
            this.btnEditNaklad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditNaklad.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnEditNaklad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnEditNaklad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnEditNaklad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditNaklad.Location = new System.Drawing.Point(168, 1);
            this.btnEditNaklad.Name = "btnEditNaklad";
            this.btnEditNaklad.Size = new System.Drawing.Size(26, 26);
            this.btnEditNaklad.TabIndex = 18;
            this.toolTip1.SetToolTip(this.btnEditNaklad, "Открыть поле для редактирования");
            this.btnEditNaklad.UseVisualStyleBackColor = false;
            this.btnEditNaklad.Click += new System.EventHandler(this.btnEditNaklad_Click);
            // 
            // btnDelNaklad
            // 
            this.btnDelNaklad.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnDelNaklad.BackgroundImage = global::Proga.Properties.Resources.icons8_удалить_24;
            this.btnDelNaklad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelNaklad.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnDelNaklad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnDelNaklad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnDelNaklad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelNaklad.Location = new System.Drawing.Point(196, 1);
            this.btnDelNaklad.Name = "btnDelNaklad";
            this.btnDelNaklad.Size = new System.Drawing.Size(26, 26);
            this.btnDelNaklad.TabIndex = 18;
            this.toolTip1.SetToolTip(this.btnDelNaklad, "Удалить запись");
            this.btnDelNaklad.UseVisualStyleBackColor = false;
            this.btnDelNaklad.Click += new System.EventHandler(this.btnDelNaklad_Click);
            // 
            // btnUpdateNaklad
            // 
            this.btnUpdateNaklad.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnUpdateNaklad.BackgroundImage = global::Proga.Properties.Resources.icons8_обновить_24;
            this.btnUpdateNaklad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpdateNaklad.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnUpdateNaklad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnUpdateNaklad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnUpdateNaklad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateNaklad.Location = new System.Drawing.Point(112, 1);
            this.btnUpdateNaklad.Name = "btnUpdateNaklad";
            this.btnUpdateNaklad.Size = new System.Drawing.Size(26, 26);
            this.btnUpdateNaklad.TabIndex = 15;
            this.toolTip1.SetToolTip(this.btnUpdateNaklad, "Обновить");
            this.btnUpdateNaklad.UseVisualStyleBackColor = false;
            this.btnUpdateNaklad.Click += new System.EventHandler(this.btnUpdateNaklad_Click);
            // 
            // tableLayoutPanel30
            // 
            this.tableLayoutPanel30.AutoSize = true;
            this.tableLayoutPanel30.ColumnCount = 1;
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel30.Controls.Add(this.tableLayoutPanel31, 0, 1);
            this.tableLayoutPanel30.Controls.Add(this.tableLayoutNaklad, 0, 0);
            this.tableLayoutPanel30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel30.Location = new System.Drawing.Point(3, 27);
            this.tableLayoutPanel30.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tableLayoutPanel30.Name = "tableLayoutPanel30";
            this.tableLayoutPanel30.RowCount = 2;
            this.tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel30.Size = new System.Drawing.Size(1139, 528);
            this.tableLayoutPanel30.TabIndex = 8;
            // 
            // tableLayoutPanel31
            // 
            this.tableLayoutPanel31.AutoSize = true;
            this.tableLayoutPanel31.ColumnCount = 1;
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 89.11326F));
            this.tableLayoutPanel31.Controls.Add(this.listBox1, 0, 0);
            this.tableLayoutPanel31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel31.Location = new System.Drawing.Point(0, 428);
            this.tableLayoutPanel31.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel31.Name = "tableLayoutPanel31";
            this.tableLayoutPanel31.RowCount = 1;
            this.tableLayoutPanel31.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel31.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel31.Size = new System.Drawing.Size(1139, 100);
            this.tableLayoutPanel31.TabIndex = 25;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Items.AddRange(new object[] {
            "Начало работы с таблицей Накладная"});
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Margin = new System.Windows.Forms.Padding(0);
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new System.Drawing.Size(1139, 100);
            this.listBox1.TabIndex = 27;
            // 
            // tableLayoutNaklad
            // 
            this.tableLayoutNaklad.ColumnCount = 1;
            this.tableLayoutNaklad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutNaklad.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutNaklad.Controls.Add(this.dataGridNaklad, 0, 0);
            this.tableLayoutNaklad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutNaklad.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutNaklad.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tableLayoutNaklad.Name = "tableLayoutNaklad";
            this.tableLayoutNaklad.RowCount = 2;
            this.tableLayoutNaklad.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutNaklad.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutNaklad.Size = new System.Drawing.Size(1133, 425);
            this.tableLayoutNaklad.TabIndex = 26;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupEditNaklad);
            this.panel1.Controls.Add(this.groupAddNaklad);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 428);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1127, 1);
            this.panel1.TabIndex = 24;
            // 
            // groupEditNaklad
            // 
            this.groupEditNaklad.AutoSize = true;
            this.groupEditNaklad.Controls.Add(this.btnHideGroupNaklad2);
            this.groupEditNaklad.Controls.Add(this.tableLayoutPanel1);
            this.groupEditNaklad.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupEditNaklad.Location = new System.Drawing.Point(0, -255);
            this.groupEditNaklad.Margin = new System.Windows.Forms.Padding(0);
            this.groupEditNaklad.Name = "groupEditNaklad";
            this.groupEditNaklad.Padding = new System.Windows.Forms.Padding(0);
            this.groupEditNaklad.Size = new System.Drawing.Size(1127, 128);
            this.groupEditNaklad.TabIndex = 32;
            this.groupEditNaklad.TabStop = false;
            this.groupEditNaklad.Text = "Изменение";
            this.groupEditNaklad.Visible = false;
            // 
            // btnHideGroupNaklad2
            // 
            this.btnHideGroupNaklad2.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnHideGroupNaklad2.BackgroundImage = global::Proga.Properties.Resources.icons8_отмена_24;
            this.btnHideGroupNaklad2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHideGroupNaklad2.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnHideGroupNaklad2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnHideGroupNaklad2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnHideGroupNaklad2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHideGroupNaklad2.Location = new System.Drawing.Point(121, 2);
            this.btnHideGroupNaklad2.Name = "btnHideGroupNaklad2";
            this.btnHideGroupNaklad2.Size = new System.Drawing.Size(26, 26);
            this.btnHideGroupNaklad2.TabIndex = 24;
            this.toolTip1.SetToolTip(this.btnHideGroupNaklad2, "Закрытие поля редактирования");
            this.btnHideGroupNaklad2.UseVisualStyleBackColor = false;
            this.btnHideGroupNaklad2.Click += new System.EventHandler(this.Close);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.editNaklad, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1127, 104);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.dateTimeEditNakladDate, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBoxEditNakladNaklad, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.comboBoxEditNakladPostav, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1127, 64);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // dateTimeEditNakladDate
            // 
            this.dateTimeEditNakladDate.CustomFormat = "";
            this.dateTimeEditNakladDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimeEditNakladDate.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimeEditNakladDate.Location = new System.Drawing.Point(753, 38);
            this.dateTimeEditNakladDate.Name = "dateTimeEditNakladDate";
            this.dateTimeEditNakladDate.Size = new System.Drawing.Size(371, 23);
            this.dateTimeEditNakladDate.TabIndex = 24;
            this.dateTimeEditNakladDate.Value = new System.DateTime(2020, 3, 25, 0, 0, 0, 0);
            // 
            // textBoxEditNakladNaklad
            // 
            this.textBoxEditNakladNaklad.BackColor = System.Drawing.Color.White;
            this.textBoxEditNakladNaklad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxEditNakladNaklad.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxEditNakladNaklad.Location = new System.Drawing.Point(3, 38);
            this.textBoxEditNakladNaklad.MaxLength = 12;
            this.textBoxEditNakladNaklad.Name = "textBoxEditNakladNaklad";
            this.textBoxEditNakladNaklad.Size = new System.Drawing.Size(369, 23);
            this.textBoxEditNakladNaklad.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(369, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Номер накладной";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(378, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(369, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "Поставщик";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(753, 3);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(371, 29);
            this.label7.TabIndex = 0;
            this.label7.Text = "Дата";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxEditNakladPostav
            // 
            this.comboBoxEditNakladPostav.BackColor = System.Drawing.Color.White;
            this.comboBoxEditNakladPostav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxEditNakladPostav.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEditNakladPostav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxEditNakladPostav.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxEditNakladPostav.FormattingEnabled = true;
            this.comboBoxEditNakladPostav.Location = new System.Drawing.Point(378, 38);
            this.comboBoxEditNakladPostav.Name = "comboBoxEditNakladPostav";
            this.comboBoxEditNakladPostav.Size = new System.Drawing.Size(369, 23);
            this.comboBoxEditNakladPostav.TabIndex = 7;
            // 
            // editNaklad
            // 
            this.editNaklad.AutoSize = true;
            this.editNaklad.BackColor = System.Drawing.Color.LavenderBlush;
            this.editNaklad.Dock = System.Windows.Forms.DockStyle.Right;
            this.editNaklad.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.editNaklad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.editNaklad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.editNaklad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editNaklad.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editNaklad.Location = new System.Drawing.Point(1016, 67);
            this.editNaklad.Name = "editNaklad";
            this.editNaklad.Size = new System.Drawing.Size(108, 34);
            this.editNaklad.TabIndex = 24;
            this.editNaklad.Text = "Изменить";
            this.editNaklad.UseVisualStyleBackColor = false;
            this.editNaklad.Click += new System.EventHandler(this.editNaklad_Click);
            // 
            // groupAddNaklad
            // 
            this.groupAddNaklad.AutoSize = true;
            this.groupAddNaklad.Controls.Add(this.btnHideGroupNaklad1);
            this.groupAddNaklad.Controls.Add(this.tableLayoutPanel2);
            this.groupAddNaklad.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupAddNaklad.Location = new System.Drawing.Point(0, -127);
            this.groupAddNaklad.Margin = new System.Windows.Forms.Padding(0);
            this.groupAddNaklad.Name = "groupAddNaklad";
            this.groupAddNaklad.Padding = new System.Windows.Forms.Padding(0);
            this.groupAddNaklad.Size = new System.Drawing.Size(1127, 128);
            this.groupAddNaklad.TabIndex = 29;
            this.groupAddNaklad.TabStop = false;
            this.groupAddNaklad.Text = "Добавление";
            this.groupAddNaklad.Visible = false;
            // 
            // btnHideGroupNaklad1
            // 
            this.btnHideGroupNaklad1.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnHideGroupNaklad1.BackgroundImage = global::Proga.Properties.Resources.icons8_отмена_24;
            this.btnHideGroupNaklad1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHideGroupNaklad1.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnHideGroupNaklad1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnHideGroupNaklad1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnHideGroupNaklad1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHideGroupNaklad1.Location = new System.Drawing.Point(121, 1);
            this.btnHideGroupNaklad1.Name = "btnHideGroupNaklad1";
            this.btnHideGroupNaklad1.Size = new System.Drawing.Size(26, 26);
            this.btnHideGroupNaklad1.TabIndex = 23;
            this.toolTip1.SetToolTip(this.btnHideGroupNaklad1, "Закрытие поля добавления");
            this.btnHideGroupNaklad1.UseVisualStyleBackColor = false;
            this.btnHideGroupNaklad1.Click += new System.EventHandler(this.Close);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.MintCream;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.addNaklad, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1127, 104);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.dateTimeAddNakladDate, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.textBoxAddNakladNaklad, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.comboBoxAddNakladPostav, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1127, 64);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // dateTimeAddNakladDate
            // 
            this.dateTimeAddNakladDate.CustomFormat = "";
            this.dateTimeAddNakladDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimeAddNakladDate.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimeAddNakladDate.Location = new System.Drawing.Point(753, 38);
            this.dateTimeAddNakladDate.Name = "dateTimeAddNakladDate";
            this.dateTimeAddNakladDate.Size = new System.Drawing.Size(371, 23);
            this.dateTimeAddNakladDate.TabIndex = 24;
            this.dateTimeAddNakladDate.Value = new System.DateTime(2020, 3, 25, 0, 0, 0, 0);
            // 
            // textBoxAddNakladNaklad
            // 
            this.textBoxAddNakladNaklad.BackColor = System.Drawing.Color.White;
            this.textBoxAddNakladNaklad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxAddNakladNaklad.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAddNakladNaklad.Location = new System.Drawing.Point(3, 38);
            this.textBoxAddNakladNaklad.MaxLength = 12;
            this.textBoxAddNakladNaklad.Name = "textBoxAddNakladNaklad";
            this.textBoxAddNakladNaklad.Size = new System.Drawing.Size(369, 23);
            this.textBoxAddNakladNaklad.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(3, 3);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(369, 29);
            this.label12.TabIndex = 0;
            this.label12.Text = "Номер накладной";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(753, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(371, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Дата";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxAddNakladPostav
            // 
            this.comboBoxAddNakladPostav.BackColor = System.Drawing.Color.White;
            this.comboBoxAddNakladPostav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxAddNakladPostav.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAddNakladPostav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxAddNakladPostav.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxAddNakladPostav.FormattingEnabled = true;
            this.comboBoxAddNakladPostav.Location = new System.Drawing.Point(378, 38);
            this.comboBoxAddNakladPostav.Name = "comboBoxAddNakladPostav";
            this.comboBoxAddNakladPostav.Size = new System.Drawing.Size(369, 23);
            this.comboBoxAddNakladPostav.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(378, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(369, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Поставщик";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addNaklad
            // 
            this.addNaklad.AutoSize = true;
            this.addNaklad.BackColor = System.Drawing.Color.LavenderBlush;
            this.addNaklad.Dock = System.Windows.Forms.DockStyle.Right;
            this.addNaklad.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.addNaklad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.addNaklad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.addNaklad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addNaklad.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addNaklad.Location = new System.Drawing.Point(1017, 67);
            this.addNaklad.Name = "addNaklad";
            this.addNaklad.Size = new System.Drawing.Size(107, 34);
            this.addNaklad.TabIndex = 24;
            this.addNaklad.Text = "Добавить";
            this.addNaklad.UseVisualStyleBackColor = false;
            this.addNaklad.Click += new System.EventHandler(this.addNaklad_Click);
            // 
            // dataGridNaklad
            // 
            this.dataGridNaklad.AllowUserToAddRows = false;
            this.dataGridNaklad.AllowUserToDeleteRows = false;
            this.dataGridNaklad.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridNaklad.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridNaklad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridNaklad.BackgroundColor = System.Drawing.Color.LavenderBlush;
            this.dataGridNaklad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridNaklad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numnaklad,
            this.id_postavshik,
            this.datenakl,
            this.id_nakladnaya});
            this.dataGridNaklad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridNaklad.Location = new System.Drawing.Point(3, 3);
            this.dataGridNaklad.Name = "dataGridNaklad";
            this.dataGridNaklad.ReadOnly = true;
            this.dataGridNaklad.RowHeadersWidth = 25;
            this.dataGridNaklad.Size = new System.Drawing.Size(1127, 419);
            this.dataGridNaklad.TabIndex = 25;
            this.toolTip1.SetToolTip(this.dataGridNaklad, "Для отбора нажмите ПКМ по названию столбца");
            this.dataGridNaklad.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridNaklad_CellMouseClick);
            this.dataGridNaklad.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridNaklad_ColumnHeaderMouseClick);
            // 
            // numnaklad
            // 
            this.numnaklad.DataPropertyName = "numnaklad";
            this.numnaklad.HeaderText = "Номер накладной";
            this.numnaklad.Name = "numnaklad";
            this.numnaklad.ReadOnly = true;
            // 
            // id_postavshik
            // 
            this.id_postavshik.DataPropertyName = "naimpost";
            this.id_postavshik.HeaderText = "Поставщик";
            this.id_postavshik.Name = "id_postavshik";
            this.id_postavshik.ReadOnly = true;
            // 
            // datenakl
            // 
            this.datenakl.DataPropertyName = "datenakl";
            this.datenakl.HeaderText = "Дата";
            this.datenakl.Name = "datenakl";
            this.datenakl.ReadOnly = true;
            // 
            // id_nakladnaya
            // 
            this.id_nakladnaya.DataPropertyName = "id_nakladnaya";
            this.id_nakladnaya.HeaderText = "Id накладной";
            this.id_nakladnaya.Name = "id_nakladnaya";
            this.id_nakladnaya.ReadOnly = true;
            this.id_nakladnaya.Visible = false;
            // 
            // Filter
            // 
            this.Filter.Name = "Filter";
            this.Filter.ShowImageMargin = false;
            this.Filter.ShowItemToolTips = false;
            this.Filter.Size = new System.Drawing.Size(36, 4);
            this.Filter.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Filter_ItemClicked);
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
            // PPTNakladnaya
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupNaklad);
            this.Name = "PPTNakladnaya";
            this.Size = new System.Drawing.Size(1145, 555);
            this.Load += new System.EventHandler(this.PPTNaklad_Load);
            this.groupNaklad.ResumeLayout(false);
            this.groupNaklad.PerformLayout();
            this.tableLayoutPanel30.ResumeLayout(false);
            this.tableLayoutPanel30.PerformLayout();
            this.tableLayoutPanel31.ResumeLayout(false);
            this.tableLayoutNaklad.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupEditNaklad.ResumeLayout(false);
            this.groupEditNaklad.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupAddNaklad.ResumeLayout(false);
            this.groupAddNaklad.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNaklad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupNaklad;
        private System.Windows.Forms.Button btnHideNaklad;
        private System.Windows.Forms.Button btnAddNaklad;
        private System.Windows.Forms.Button btnEditNaklad;
        private System.Windows.Forms.Button btnDelNaklad;
        private System.Windows.Forms.Button btnUpdateNaklad;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel30;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel31;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutNaklad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupEditNaklad;
        private System.Windows.Forms.Button btnHideGroupNaklad2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button editNaklad;
        private System.Windows.Forms.GroupBox groupAddNaklad;
        private System.Windows.Forms.Button btnHideGroupNaklad1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addNaklad;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSearchNaklad;
        private System.Windows.Forms.ContextMenuStrip Filter;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBoxEditNakladNaklad;
        private System.Windows.Forms.ComboBox comboBoxEditNakladPostav;
        private System.Windows.Forms.TextBox textBoxAddNakladNaklad;
        private System.Windows.Forms.ComboBox comboBoxAddNakladPostav;
        private System.Windows.Forms.DateTimePicker dateTimeEditNakladDate;
        private System.Windows.Forms.DateTimePicker dateTimeAddNakladDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn numnaklad;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_postavshik;
        private System.Windows.Forms.DataGridViewTextBoxColumn datenakl;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_nakladnaya;
        public System.Windows.Forms.DataGridView dataGridNaklad;
    }
}
