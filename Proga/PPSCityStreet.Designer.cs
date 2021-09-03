namespace Proga
{
    partial class PPSCityStreet
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
            this.ppsStreet1 = new Proga.PPSStreet();
            this.ppsCity1 = new Proga.PPSCity();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.ppsCity1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ppsStreet1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1145, 555);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ppsStreet1
            // 
            this.ppsStreet1.AutoSize = true;
            this.ppsStreet1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppsStreet1.Location = new System.Drawing.Point(1145, 0);
            this.ppsStreet1.Margin = new System.Windows.Forms.Padding(0);
            this.ppsStreet1.Name = "ppsStreet1";
            this.ppsStreet1.Size = new System.Drawing.Size(1, 555);
            this.ppsStreet1.TabIndex = 1;
            // 
            // ppsCity1
            // 
            this.ppsCity1.AutoSize = true;
            this.ppsCity1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppsCity1.Location = new System.Drawing.Point(0, 0);
            this.ppsCity1.Margin = new System.Windows.Forms.Padding(0);
            this.ppsCity1.Name = "ppsCity1";
            this.ppsCity1.Size = new System.Drawing.Size(1145, 555);
            this.ppsCity1.TabIndex = 0;
            // 
            // PPSCityStreet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PPSCityStreet";
            this.Size = new System.Drawing.Size(1145, 555);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private PPSCity ppsCity1;
        private PPSStreet ppsStreet1;
    }
}
