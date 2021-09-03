namespace Proga
{
    partial class ArhivSpisEquip
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupArhivSE = new System.Windows.Forms.GroupBox();
            this.btnSearchArhivSE = new System.Windows.Forms.Button();
            this.btnHideArhivSE = new System.Windows.Forms.Button();
            this.btnDelArhivSE = new System.Windows.Forms.Button();
            this.btnUpdateArhivSE = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tableLayoutArhivSE = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridArhivSE = new System.Windows.Forms.DataGridView();
            this.dataGridArhivSEKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomdogovor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serialscore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateSpis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Filter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupArhivSE.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutArhivSE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridArhivSE)).BeginInit();
            this.SuspendLayout();
            // 
            // groupArhivSE
            // 
            this.groupArhivSE.BackColor = System.Drawing.Color.MintCream;
            this.groupArhivSE.Controls.Add(this.btnSearchArhivSE);
            this.groupArhivSE.Controls.Add(this.btnHideArhivSE);
            this.groupArhivSE.Controls.Add(this.btnDelArhivSE);
            this.groupArhivSE.Controls.Add(this.btnUpdateArhivSE);
            this.groupArhivSE.Controls.Add(this.tableLayoutPanel3);
            this.groupArhivSE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupArhivSE.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupArhivSE.Location = new System.Drawing.Point(0, 0);
            this.groupArhivSE.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.groupArhivSE.Name = "groupArhivSE";
            this.groupArhivSE.Size = new System.Drawing.Size(1080, 550);
            this.groupArhivSE.TabIndex = 26;
            this.groupArhivSE.TabStop = false;
            this.groupArhivSE.Text = "Архив списанного оборудования";
            // 
            // btnSearchArhivSE
            // 
            this.btnSearchArhivSE.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnSearchArhivSE.BackgroundImage = global::Proga.Properties.Resources.icons8_поиск_24;
            this.btnSearchArhivSE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearchArhivSE.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnSearchArhivSE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnSearchArhivSE.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnSearchArhivSE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchArhivSE.Location = new System.Drawing.Point(360, 1);
            this.btnSearchArhivSE.Name = "btnSearchArhivSE";
            this.btnSearchArhivSE.Size = new System.Drawing.Size(26, 26);
            this.btnSearchArhivSE.TabIndex = 51;
            this.toolTip1.SetToolTip(this.btnSearchArhivSE, "Поиск");
            this.btnSearchArhivSE.UseVisualStyleBackColor = false;
            // 
            // btnHideArhivSE
            // 
            this.btnHideArhivSE.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnHideArhivSE.BackgroundImage = global::Proga.Properties.Resources.icons8_отмена_24;
            this.btnHideArhivSE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHideArhivSE.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnHideArhivSE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnHideArhivSE.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnHideArhivSE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHideArhivSE.Location = new System.Drawing.Point(388, 1);
            this.btnHideArhivSE.Name = "btnHideArhivSE";
            this.btnHideArhivSE.Size = new System.Drawing.Size(26, 26);
            this.btnHideArhivSE.TabIndex = 50;
            this.toolTip1.SetToolTip(this.btnHideArhivSE, "Закрыть форму");
            this.btnHideArhivSE.UseVisualStyleBackColor = false;
            this.btnHideArhivSE.Click += new System.EventHandler(this.btnHideArhivSE_Click);
            // 
            // btnDelArhivSE
            // 
            this.btnDelArhivSE.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnDelArhivSE.BackgroundImage = global::Proga.Properties.Resources.icons8_удалить_24;
            this.btnDelArhivSE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelArhivSE.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnDelArhivSE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnDelArhivSE.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnDelArhivSE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelArhivSE.Location = new System.Drawing.Point(332, 1);
            this.btnDelArhivSE.Name = "btnDelArhivSE";
            this.btnDelArhivSE.Size = new System.Drawing.Size(26, 26);
            this.btnDelArhivSE.TabIndex = 49;
            this.toolTip1.SetToolTip(this.btnDelArhivSE, "Удалить запись");
            this.btnDelArhivSE.UseVisualStyleBackColor = false;
            this.btnDelArhivSE.Click += new System.EventHandler(this.btnDelArhivSE_Click);
            // 
            // btnUpdateArhivSE
            // 
            this.btnUpdateArhivSE.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnUpdateArhivSE.BackgroundImage = global::Proga.Properties.Resources.icons8_обновить_24;
            this.btnUpdateArhivSE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpdateArhivSE.FlatAppearance.BorderColor = System.Drawing.Color.MistyRose;
            this.btnUpdateArhivSE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btnUpdateArhivSE.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose;
            this.btnUpdateArhivSE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateArhivSE.Location = new System.Drawing.Point(304, 1);
            this.btnUpdateArhivSE.Name = "btnUpdateArhivSE";
            this.btnUpdateArhivSE.Size = new System.Drawing.Size(26, 26);
            this.btnUpdateArhivSE.TabIndex = 44;
            this.toolTip1.SetToolTip(this.btnUpdateArhivSE, "Обновить");
            this.btnUpdateArhivSE.UseVisualStyleBackColor = false;
            this.btnUpdateArhivSE.Click += new System.EventHandler(this.btnUpdateArhivSE_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutArhivSE, 0, 0);
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
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.17505F));
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
            "Начало работы с Архивом списанного оборудования"});
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Margin = new System.Windows.Forms.Padding(0);
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new System.Drawing.Size(1074, 80);
            this.listBox1.TabIndex = 29;
            // 
            // tableLayoutArhivSE
            // 
            this.tableLayoutArhivSE.ColumnCount = 1;
            this.tableLayoutArhivSE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutArhivSE.Controls.Add(this.dataGridArhivSE, 0, 0);
            this.tableLayoutArhivSE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutArhivSE.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutArhivSE.Name = "tableLayoutArhivSE";
            this.tableLayoutArhivSE.RowCount = 2;
            this.tableLayoutArhivSE.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutArhivSE.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutArhivSE.Size = new System.Drawing.Size(1068, 434);
            this.tableLayoutArhivSE.TabIndex = 26;
            // 
            // dataGridArhivSE
            // 
            this.dataGridArhivSE.AllowUserToAddRows = false;
            this.dataGridArhivSE.AllowUserToDeleteRows = false;
            this.dataGridArhivSE.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridArhivSE.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridArhivSE.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridArhivSE.BackgroundColor = System.Drawing.Color.LavenderBlush;
            this.dataGridArhivSE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridArhivSE.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridArhivSEKey,
            this.nomdogovor,
            this.nomact,
            this.equip,
            this.Serialscore,
            this.dateSpis});
            this.dataGridArhivSE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridArhivSE.Location = new System.Drawing.Point(3, 3);
            this.dataGridArhivSE.Name = "dataGridArhivSE";
            this.dataGridArhivSE.ReadOnly = true;
            this.dataGridArhivSE.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridArhivSE.RowHeadersWidth = 25;
            this.dataGridArhivSE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridArhivSE.Size = new System.Drawing.Size(1062, 428);
            this.dataGridArhivSE.TabIndex = 23;
            this.toolTip1.SetToolTip(this.dataGridArhivSE, "Для отбора нажмите ПКМ по названию столбца");
            this.dataGridArhivSE.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridArhivSE_ColumnHeaderMouseClick);
            // 
            // dataGridArhivSEKey
            // 
            this.dataGridArhivSEKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridArhivSEKey.DataPropertyName = "id_arhivSE";
            this.dataGridArhivSEKey.HeaderText = "Номер списания";
            this.dataGridArhivSEKey.Name = "dataGridArhivSEKey";
            this.dataGridArhivSEKey.ReadOnly = true;
            this.dataGridArhivSEKey.Visible = false;
            // 
            // nomdogovor
            // 
            this.nomdogovor.DataPropertyName = "nomdogovor";
            this.nomdogovor.HeaderText = "Договор";
            this.nomdogovor.Name = "nomdogovor";
            this.nomdogovor.ReadOnly = true;
            // 
            // nomact
            // 
            this.nomact.DataPropertyName = "nomact";
            this.nomact.HeaderText = "Акт";
            this.nomact.Name = "nomact";
            this.nomact.ReadOnly = true;
            // 
            // equip
            // 
            this.equip.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.equip.DataPropertyName = "equip";
            this.equip.HeaderText = "Оборудование";
            this.equip.Name = "equip";
            this.equip.ReadOnly = true;
            // 
            // Serialscore
            // 
            this.Serialscore.DataPropertyName = "serialscore";
            this.Serialscore.HeaderText = "Серийный номер";
            this.Serialscore.Name = "Serialscore";
            this.Serialscore.ReadOnly = true;
            // 
            // dateSpis
            // 
            this.dateSpis.DataPropertyName = "dateSpis";
            this.dateSpis.HeaderText = "Дата списания";
            this.dateSpis.Name = "dateSpis";
            this.dateSpis.ReadOnly = true;
            // 
            // Filter
            // 
            this.Filter.Name = "Filter";
            this.Filter.ShowImageMargin = false;
            this.Filter.ShowItemToolTips = false;
            this.Filter.Size = new System.Drawing.Size(156, 26);
            this.Filter.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Filter_ItemClicked);
            // 
            // ArhivSpisEquip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupArhivSE);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ArhivSpisEquip";
            this.Size = new System.Drawing.Size(1080, 550);
            this.Load += new System.EventHandler(this.PPSArhivSE_Load);
            this.groupArhivSE.ResumeLayout(false);
            this.groupArhivSE.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutArhivSE.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridArhivSE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupArhivSE;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutArhivSE;
        private System.Windows.Forms.Button btnHideArhivSE;
        private System.Windows.Forms.Button btnDelArhivSE;
        private System.Windows.Forms.Button btnUpdateArhivSE;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnSearchArhivSE;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.DataGridView dataGridArhivSE;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridArhivSEKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomdogovor;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomact;
        private System.Windows.Forms.DataGridViewTextBoxColumn equip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serialscore;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateSpis;
        private System.Windows.Forms.ContextMenuStrip Filter;
    }
}
