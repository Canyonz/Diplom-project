namespace Proga
{
    partial class PPODogovors
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ppoDogovor1 = new Proga.PPODogovor();
            this.ppoAct1 = new Proga.PPOAct();
            this.ppoSpecAct1 = new Proga.PPOSpecAct();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel1.Controls.Add(this.ppoDogovor1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ppoAct1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ppoSpecAct1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1430, 589);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ppoDogovor1
            // 
            this.ppoDogovor1.AutoSize = true;
            this.ppoDogovor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppoDogovor1.Location = new System.Drawing.Point(0, 0);
            this.ppoDogovor1.Margin = new System.Windows.Forms.Padding(0);
            this.ppoDogovor1.Name = "ppoDogovor1";
            this.ppoDogovor1.Size = new System.Drawing.Size(1430, 589);
            this.ppoDogovor1.TabIndex = 0;
            // 
            // ppoAct1
            // 
            this.ppoAct1.AutoSize = true;
            this.ppoAct1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppoAct1.Location = new System.Drawing.Point(1430, 0);
            this.ppoAct1.Margin = new System.Windows.Forms.Padding(0);
            this.ppoAct1.Name = "ppoAct1";
            this.ppoAct1.Size = new System.Drawing.Size(1, 589);
            this.ppoAct1.TabIndex = 1;
            // 
            // ppoSpecAct1
            // 
            this.ppoSpecAct1.AutoSize = true;
            this.ppoSpecAct1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppoSpecAct1.Location = new System.Drawing.Point(1430, 0);
            this.ppoSpecAct1.Margin = new System.Windows.Forms.Padding(0);
            this.ppoSpecAct1.Name = "ppoSpecAct1";
            this.ppoSpecAct1.Size = new System.Drawing.Size(1, 589);
            this.ppoSpecAct1.TabIndex = 2;
            // 
            // PPODogovors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PPODogovors";
            this.Size = new System.Drawing.Size(1430, 589);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PPODogovor ppoDogovor1;
        internal System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private PPOAct ppoAct1;
        internal PPOSpecAct ppoSpecAct1;
    }
}
