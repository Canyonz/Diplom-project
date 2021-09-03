namespace Proga
{
    partial class PPTSklad
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
            this.groupSklad = new System.Windows.Forms.GroupBox();
            this.btnSearchSklad = new System.Windows.Forms.Button();
            this.btnHideSklad = new System.Windows.Forms.Button();
            this.btnAddSklad = new System.Windows.Forms.Button();
            this.btnEditSklad = new System.Windows.Forms.Button();
            this.btnDelSklad = new System.Windows.Forms.Button();
            this.btnUpdateSklad = new System.Windows.Forms.Button();
            this.tableLayoutPanel30 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel31 = new System.Windows.Forms.TableLayoutPanel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tableLayoutSklad = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupEditSklad = new System.Windows.Forms.GroupBox();
            this.btnHideGroupSklad2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxEditSkladEquip = new System.Windows.Forms.TextBox();
            this.textBoxEditSkladCount = new System.Windows.Forms.TextBox();
            this.comboBoxEditSkladTypeEquip = new System.Windows.Forms.ComboBox();
            this.editSklad = new System.Windows.Forms.Button();
            this.groupAddSklad = new System.Windows.Forms.GroupBox();
            this.btnHideGroupSklad1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxAddSkladCount = new System.Windows.Forms.TextBox();
            this.comboBoxAddSkladTypeEquip = new System.Windows.Forms.ComboBox();
            this.textBoxAddSkladEquip = new System.Windows.Forms.TextBox();
            this.addSklad = new System.Windows.Forms.Button();
            this.dataGridSklad = new System.Windows.Forms.DataGridView();
            this.typeequip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_skladequip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupSklad.SuspendLayout();
            this.tableLayoutPanel30.SuspendLayout();
            this.tableLayoutPanel31.SuspendLayout();
            this.tableLayoutSklad.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupEditSklad.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupAddSklad.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSklad)).BeginInit();
            this.SuspendLayout();
            // 
            // groupSklad
            // 
            this.groupSklad.BackColor = System.Drawing.Color.MintCream;
            this.groupSklad.Controls.Add(this.btnSearchSklad);
            this.groupSklad.Controls.Add(this.btnHideSklad);
            this.groupSklad.Controls.Add(this.btnAddSklad);
            this.groupSklad.Controls.Add(this.btnEditSklad);
            this.groupSklad.Controls.Add(this.btnDelSklad);
            this.groupSklad.Controls.Add(this.btnUpdateSklad);
            this.groupSklad.Controls.Add(this.tableLayoutPanel30);
            this.groupSklad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSklad.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupSklad.Location = new System.Drawing.Point(0, 0);
            this.groupSklad.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.groupSklad.Name = "groupSklad";
            this.groupSklad.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.groupSklad.Size = new System.Drawing.Size(1145, 555);
            this.groupSklad.TabIndex = 30;
            this.groupSklad.TabStop = false;
            this.groupSklad.Text = "Склад";
            // 
            // btnSearchSklad
            // 
            this.btnSearchSklad.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnSearchSklad.BackgroundImage = global::Proga.Properties.Resources.icons8_поиск_24;
            this.btnSearchSklad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearchSklad.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnSearchSklad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnSearchSklad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnSearchSklad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchSklad.Location = new System.Drawing.Point(187, 1);
            this.btnSearchSklad.Name = "btnSearchSklad";
            this.btnSearchSklad.Size = new System.Drawing.Size(26, 26);
            this.btnSearchSklad.TabIndex = 37;
            this.toolTip1.SetToolTip(this.btnSearchSklad, "Поиск");
            this.btnSearchSklad.UseVisualStyleBackColor = false;
            this.btnSearchSklad.Click += new System.EventHandler(this.btnSearchSklad_Click);
            // 
            // btnHideSklad
            // 
            this.btnHideSklad.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnHideSklad.BackgroundImage = global::Proga.Properties.Resources.icons8_отмена_24;
            this.btnHideSklad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHideSklad.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnHideSklad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnHideSklad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnHideSklad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHideSklad.Location = new System.Drawing.Point(215, 1);
            this.btnHideSklad.Name = "btnHideSklad";
            this.btnHideSklad.Size = new System.Drawing.Size(26, 26);
            this.btnHideSklad.TabIndex = 22;
            this.toolTip1.SetToolTip(this.btnHideSklad, "Закрыть форму");
            this.btnHideSklad.UseVisualStyleBackColor = false;
            this.btnHideSklad.Click += new System.EventHandler(this.btnHideSklad_Click);
            // 
            // btnAddSklad
            // 
            this.btnAddSklad.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnAddSklad.BackgroundImage = global::Proga.Properties.Resources.icons8_сложение_24;
            this.btnAddSklad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddSklad.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnAddSklad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnAddSklad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnAddSklad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSklad.Location = new System.Drawing.Point(103, 1);
            this.btnAddSklad.Name = "btnAddSklad";
            this.btnAddSklad.Size = new System.Drawing.Size(26, 26);
            this.btnAddSklad.TabIndex = 18;
            this.toolTip1.SetToolTip(this.btnAddSklad, "Открыть поле для добавления");
            this.btnAddSklad.UseVisualStyleBackColor = false;
            this.btnAddSklad.Click += new System.EventHandler(this.btnAddSklad_Click);
            // 
            // btnEditSklad
            // 
            this.btnEditSklad.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnEditSklad.BackgroundImage = global::Proga.Properties.Resources.icons8_редактировать_24;
            this.btnEditSklad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditSklad.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnEditSklad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnEditSklad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnEditSklad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditSklad.Location = new System.Drawing.Point(131, 1);
            this.btnEditSklad.Name = "btnEditSklad";
            this.btnEditSklad.Size = new System.Drawing.Size(26, 26);
            this.btnEditSklad.TabIndex = 18;
            this.toolTip1.SetToolTip(this.btnEditSklad, "Открыть поле для редактирования");
            this.btnEditSklad.UseVisualStyleBackColor = false;
            this.btnEditSklad.Click += new System.EventHandler(this.btnEditSklad_Click);
            // 
            // btnDelSklad
            // 
            this.btnDelSklad.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnDelSklad.BackgroundImage = global::Proga.Properties.Resources.icons8_удалить_24;
            this.btnDelSklad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelSklad.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnDelSklad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnDelSklad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnDelSklad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelSklad.Location = new System.Drawing.Point(159, 1);
            this.btnDelSklad.Name = "btnDelSklad";
            this.btnDelSklad.Size = new System.Drawing.Size(26, 26);
            this.btnDelSklad.TabIndex = 18;
            this.toolTip1.SetToolTip(this.btnDelSklad, "Удалить запись");
            this.btnDelSklad.UseVisualStyleBackColor = false;
            this.btnDelSklad.Click += new System.EventHandler(this.btnDelSklad_Click);
            // 
            // btnUpdateSklad
            // 
            this.btnUpdateSklad.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnUpdateSklad.BackgroundImage = global::Proga.Properties.Resources.icons8_обновить_24;
            this.btnUpdateSklad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpdateSklad.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnUpdateSklad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnUpdateSklad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnUpdateSklad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateSklad.Location = new System.Drawing.Point(75, 1);
            this.btnUpdateSklad.Name = "btnUpdateSklad";
            this.btnUpdateSklad.Size = new System.Drawing.Size(26, 26);
            this.btnUpdateSklad.TabIndex = 15;
            this.toolTip1.SetToolTip(this.btnUpdateSklad, "Обновить");
            this.btnUpdateSklad.UseVisualStyleBackColor = false;
            this.btnUpdateSklad.Click += new System.EventHandler(this.btnUpdateSklad_Click);
            // 
            // tableLayoutPanel30
            // 
            this.tableLayoutPanel30.AutoSize = true;
            this.tableLayoutPanel30.ColumnCount = 1;
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel30.Controls.Add(this.tableLayoutPanel31, 0, 1);
            this.tableLayoutPanel30.Controls.Add(this.tableLayoutSklad, 0, 0);
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
            "Начало работы с таблицей Склад"});
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Margin = new System.Windows.Forms.Padding(0);
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new System.Drawing.Size(1139, 100);
            this.listBox1.TabIndex = 27;
            // 
            // tableLayoutSklad
            // 
            this.tableLayoutSklad.ColumnCount = 1;
            this.tableLayoutSklad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutSklad.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutSklad.Controls.Add(this.dataGridSklad, 0, 0);
            this.tableLayoutSklad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutSklad.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutSklad.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tableLayoutSklad.Name = "tableLayoutSklad";
            this.tableLayoutSklad.RowCount = 2;
            this.tableLayoutSklad.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutSklad.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutSklad.Size = new System.Drawing.Size(1133, 425);
            this.tableLayoutSklad.TabIndex = 26;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupEditSklad);
            this.panel1.Controls.Add(this.groupAddSklad);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 428);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1127, 1);
            this.panel1.TabIndex = 24;
            // 
            // groupEditSklad
            // 
            this.groupEditSklad.AutoSize = true;
            this.groupEditSklad.Controls.Add(this.btnHideGroupSklad2);
            this.groupEditSklad.Controls.Add(this.tableLayoutPanel1);
            this.groupEditSklad.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupEditSklad.Location = new System.Drawing.Point(0, -255);
            this.groupEditSklad.Margin = new System.Windows.Forms.Padding(0);
            this.groupEditSklad.Name = "groupEditSklad";
            this.groupEditSklad.Padding = new System.Windows.Forms.Padding(0);
            this.groupEditSklad.Size = new System.Drawing.Size(1127, 128);
            this.groupEditSklad.TabIndex = 32;
            this.groupEditSklad.TabStop = false;
            this.groupEditSklad.Text = "Изменение";
            this.groupEditSklad.Visible = false;
            // 
            // btnHideGroupSklad2
            // 
            this.btnHideGroupSklad2.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnHideGroupSklad2.BackgroundImage = global::Proga.Properties.Resources.icons8_отмена_24;
            this.btnHideGroupSklad2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHideGroupSklad2.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnHideGroupSklad2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnHideGroupSklad2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnHideGroupSklad2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHideGroupSklad2.Location = new System.Drawing.Point(121, 0);
            this.btnHideGroupSklad2.Name = "btnHideGroupSklad2";
            this.btnHideGroupSklad2.Size = new System.Drawing.Size(26, 26);
            this.btnHideGroupSklad2.TabIndex = 24;
            this.toolTip1.SetToolTip(this.btnHideGroupSklad2, "Закрытие поля редактирования");
            this.btnHideGroupSklad2.UseVisualStyleBackColor = false;
            this.btnHideGroupSklad2.Click += new System.EventHandler(this.Close);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.editSklad, 0, 1);
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
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label7, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label8, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBoxEditSkladEquip, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBoxEditSkladCount, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.comboBoxEditSkladTypeEquip, 0, 1);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(557, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Тип оборудования";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(566, 3);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(557, 29);
            this.label7.TabIndex = 0;
            this.label7.Text = "Оборудование";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(1129, 3);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1, 29);
            this.label8.TabIndex = 0;
            this.label8.Text = "Количество";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxEditSkladEquip
            // 
            this.textBoxEditSkladEquip.BackColor = System.Drawing.Color.White;
            this.textBoxEditSkladEquip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxEditSkladEquip.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxEditSkladEquip.Location = new System.Drawing.Point(567, 38);
            this.textBoxEditSkladEquip.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.textBoxEditSkladEquip.MaxLength = 45;
            this.textBoxEditSkladEquip.Name = "textBoxEditSkladEquip";
            this.textBoxEditSkladEquip.Size = new System.Drawing.Size(556, 23);
            this.textBoxEditSkladEquip.TabIndex = 8;
            // 
            // textBoxEditSkladCount
            // 
            this.textBoxEditSkladCount.BackColor = System.Drawing.Color.White;
            this.textBoxEditSkladCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxEditSkladCount.Location = new System.Drawing.Point(1129, 38);
            this.textBoxEditSkladCount.MaxLength = 6;
            this.textBoxEditSkladCount.Name = "textBoxEditSkladCount";
            this.textBoxEditSkladCount.Size = new System.Drawing.Size(1, 26);
            this.textBoxEditSkladCount.TabIndex = 10;
            // 
            // comboBoxEditSkladTypeEquip
            // 
            this.comboBoxEditSkladTypeEquip.BackColor = System.Drawing.Color.White;
            this.comboBoxEditSkladTypeEquip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxEditSkladTypeEquip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEditSkladTypeEquip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxEditSkladTypeEquip.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxEditSkladTypeEquip.FormattingEnabled = true;
            this.comboBoxEditSkladTypeEquip.Location = new System.Drawing.Point(3, 38);
            this.comboBoxEditSkladTypeEquip.Name = "comboBoxEditSkladTypeEquip";
            this.comboBoxEditSkladTypeEquip.Size = new System.Drawing.Size(557, 23);
            this.comboBoxEditSkladTypeEquip.TabIndex = 7;
            // 
            // editSklad
            // 
            this.editSklad.AutoSize = true;
            this.editSklad.BackColor = System.Drawing.Color.LavenderBlush;
            this.editSklad.Dock = System.Windows.Forms.DockStyle.Right;
            this.editSklad.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.editSklad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.editSklad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.editSklad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editSklad.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editSklad.Location = new System.Drawing.Point(1016, 67);
            this.editSklad.Name = "editSklad";
            this.editSklad.Size = new System.Drawing.Size(108, 34);
            this.editSklad.TabIndex = 24;
            this.editSklad.Text = "Изменить";
            this.editSklad.UseVisualStyleBackColor = false;
            this.editSklad.Click += new System.EventHandler(this.editSklad_Click);
            // 
            // groupAddSklad
            // 
            this.groupAddSklad.AutoSize = true;
            this.groupAddSklad.Controls.Add(this.btnHideGroupSklad1);
            this.groupAddSklad.Controls.Add(this.tableLayoutPanel2);
            this.groupAddSklad.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupAddSklad.Location = new System.Drawing.Point(0, -127);
            this.groupAddSklad.Margin = new System.Windows.Forms.Padding(0);
            this.groupAddSklad.Name = "groupAddSklad";
            this.groupAddSklad.Padding = new System.Windows.Forms.Padding(0);
            this.groupAddSklad.Size = new System.Drawing.Size(1127, 128);
            this.groupAddSklad.TabIndex = 29;
            this.groupAddSklad.TabStop = false;
            this.groupAddSklad.Text = "Добавление";
            this.groupAddSklad.Visible = false;
            // 
            // btnHideGroupSklad1
            // 
            this.btnHideGroupSklad1.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnHideGroupSklad1.BackgroundImage = global::Proga.Properties.Resources.icons8_отмена_24;
            this.btnHideGroupSklad1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHideGroupSklad1.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnHideGroupSklad1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnHideGroupSklad1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnHideGroupSklad1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHideGroupSklad1.Location = new System.Drawing.Point(121, 0);
            this.btnHideGroupSklad1.Name = "btnHideGroupSklad1";
            this.btnHideGroupSklad1.Size = new System.Drawing.Size(26, 26);
            this.btnHideGroupSklad1.TabIndex = 23;
            this.toolTip1.SetToolTip(this.btnHideGroupSklad1, "Закрытие поля добавления");
            this.btnHideGroupSklad1.UseVisualStyleBackColor = false;
            this.btnHideGroupSklad1.Click += new System.EventHandler(this.Close);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.MintCream;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.addSklad, 0, 1);
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
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel4.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.textBoxAddSkladCount, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.comboBoxAddSkladTypeEquip, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.textBoxAddSkladEquip, 1, 1);
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(3, 3);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(557, 29);
            this.label12.TabIndex = 0;
            this.label12.Text = "Тип оборудования";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(566, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(557, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Оборудование";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(1129, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1, 29);
            this.label5.TabIndex = 0;
            this.label5.Text = "Количество";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxAddSkladCount
            // 
            this.textBoxAddSkladCount.BackColor = System.Drawing.Color.White;
            this.textBoxAddSkladCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxAddSkladCount.Location = new System.Drawing.Point(1129, 38);
            this.textBoxAddSkladCount.MaxLength = 6;
            this.textBoxAddSkladCount.Name = "textBoxAddSkladCount";
            this.textBoxAddSkladCount.Size = new System.Drawing.Size(1, 26);
            this.textBoxAddSkladCount.TabIndex = 5;
            // 
            // comboBoxAddSkladTypeEquip
            // 
            this.comboBoxAddSkladTypeEquip.BackColor = System.Drawing.Color.White;
            this.comboBoxAddSkladTypeEquip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxAddSkladTypeEquip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAddSkladTypeEquip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxAddSkladTypeEquip.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxAddSkladTypeEquip.FormattingEnabled = true;
            this.comboBoxAddSkladTypeEquip.Location = new System.Drawing.Point(3, 38);
            this.comboBoxAddSkladTypeEquip.Name = "comboBoxAddSkladTypeEquip";
            this.comboBoxAddSkladTypeEquip.Size = new System.Drawing.Size(557, 23);
            this.comboBoxAddSkladTypeEquip.TabIndex = 2;
            // 
            // textBoxAddSkladEquip
            // 
            this.textBoxAddSkladEquip.BackColor = System.Drawing.Color.White;
            this.textBoxAddSkladEquip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxAddSkladEquip.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAddSkladEquip.Location = new System.Drawing.Point(567, 38);
            this.textBoxAddSkladEquip.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.textBoxAddSkladEquip.MaxLength = 45;
            this.textBoxAddSkladEquip.Name = "textBoxAddSkladEquip";
            this.textBoxAddSkladEquip.Size = new System.Drawing.Size(556, 23);
            this.textBoxAddSkladEquip.TabIndex = 4;
            // 
            // addSklad
            // 
            this.addSklad.AutoSize = true;
            this.addSklad.BackColor = System.Drawing.Color.LavenderBlush;
            this.addSklad.Dock = System.Windows.Forms.DockStyle.Right;
            this.addSklad.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.addSklad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.addSklad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.addSklad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addSklad.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addSklad.Location = new System.Drawing.Point(1017, 67);
            this.addSklad.Name = "addSklad";
            this.addSklad.Size = new System.Drawing.Size(107, 34);
            this.addSklad.TabIndex = 24;
            this.addSklad.Text = "Добавить";
            this.addSklad.UseVisualStyleBackColor = false;
            this.addSklad.Click += new System.EventHandler(this.addSklad_Click);
            // 
            // dataGridSklad
            // 
            this.dataGridSklad.AllowUserToAddRows = false;
            this.dataGridSklad.AllowUserToDeleteRows = false;
            this.dataGridSklad.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridSklad.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridSklad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridSklad.BackgroundColor = System.Drawing.Color.LavenderBlush;
            this.dataGridSklad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSklad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.typeequip,
            this.equipment,
            this.count,
            this.id_skladequip});
            this.dataGridSklad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridSklad.Location = new System.Drawing.Point(3, 3);
            this.dataGridSklad.Name = "dataGridSklad";
            this.dataGridSklad.ReadOnly = true;
            this.dataGridSklad.RowHeadersWidth = 25;
            this.dataGridSklad.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridSklad.Size = new System.Drawing.Size(1127, 419);
            this.dataGridSklad.TabIndex = 25;
            this.toolTip1.SetToolTip(this.dataGridSklad, "Для отбора нажмите ПКМ по названию столбца");
            this.dataGridSklad.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridSklad_CellMouseClick);
            this.dataGridSklad.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridSklad_ColumnHeaderMouseClick);
            // 
            // typeequip
            // 
            this.typeequip.DataPropertyName = "typeequip";
            this.typeequip.HeaderText = "Тип оборудования";
            this.typeequip.Name = "typeequip";
            this.typeequip.ReadOnly = true;
            // 
            // equipment
            // 
            this.equipment.DataPropertyName = "equipment";
            this.equipment.HeaderText = "Оборудование";
            this.equipment.Name = "equipment";
            this.equipment.ReadOnly = true;
            // 
            // count
            // 
            this.count.DataPropertyName = "count";
            this.count.HeaderText = "Количество";
            this.count.Name = "count";
            this.count.ReadOnly = true;
            // 
            // id_skladequip
            // 
            this.id_skladequip.DataPropertyName = "id_skladequip";
            this.id_skladequip.HeaderText = "Номер складоб";
            this.id_skladequip.Name = "id_skladequip";
            this.id_skladequip.ReadOnly = true;
            this.id_skladequip.Visible = false;
            // 
            // Filter
            // 
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(61, 4);
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
            // PPTSklad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupSklad);
            this.Name = "PPTSklad";
            this.Size = new System.Drawing.Size(1145, 555);
            this.Load += new System.EventHandler(this.PPTSklad_Load);
            this.groupSklad.ResumeLayout(false);
            this.groupSklad.PerformLayout();
            this.tableLayoutPanel30.ResumeLayout(false);
            this.tableLayoutPanel30.PerformLayout();
            this.tableLayoutPanel31.ResumeLayout(false);
            this.tableLayoutSklad.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupEditSklad.ResumeLayout(false);
            this.groupEditSklad.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupAddSklad.ResumeLayout(false);
            this.groupAddSklad.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSklad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupSklad;
        private System.Windows.Forms.Button btnHideSklad;
        private System.Windows.Forms.Button btnAddSklad;
        private System.Windows.Forms.Button btnEditSklad;
        private System.Windows.Forms.Button btnDelSklad;
        private System.Windows.Forms.Button btnUpdateSklad;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel30;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel31;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutSklad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupEditSklad;
        private System.Windows.Forms.Button btnHideGroupSklad2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button editSklad;
        private System.Windows.Forms.GroupBox groupAddSklad;
        private System.Windows.Forms.Button btnHideGroupSklad1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button addSklad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridSklad;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSearchSklad;
        private System.Windows.Forms.ContextMenuStrip Filter;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBoxEditSkladEquip;
        private System.Windows.Forms.TextBox textBoxEditSkladCount;
        private System.Windows.Forms.ComboBox comboBoxEditSkladTypeEquip;
        private System.Windows.Forms.TextBox textBoxAddSkladEquip;
        private System.Windows.Forms.ComboBox comboBoxAddSkladTypeEquip;
        private System.Windows.Forms.TextBox textBoxAddSkladCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeequip;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_skladequip;
    }
}
