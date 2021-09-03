namespace Proga
{
    partial class PTTAbonents
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
            this.pptAbonent1 = new Proga.PPTAbonent();
            this.pptFacialScore1 = new Proga.PPTFacialScore();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel1.Controls.Add(this.pptAbonent1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pptFacialScore1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1345, 640);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pptAbonent1
            // 
            this.pptAbonent1.AutoSize = true;
            this.pptAbonent1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pptAbonent1.Location = new System.Drawing.Point(0, 0);
            this.pptAbonent1.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.pptAbonent1.Name = "pptAbonent1";
            this.pptAbonent1.Size = new System.Drawing.Size(1344, 640);
            this.pptAbonent1.TabIndex = 0;
            // 
            // pptFacialScore1
            // 
            this.pptFacialScore1.AutoSize = true;
            this.pptFacialScore1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pptFacialScore1.Location = new System.Drawing.Point(1346, 0);
            this.pptFacialScore1.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.pptFacialScore1.Name = "pptFacialScore1";
            this.pptFacialScore1.Size = new System.Drawing.Size(1, 640);
            this.pptFacialScore1.TabIndex = 1;
            // 
            // PTTAbonents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PTTAbonents";
            this.Size = new System.Drawing.Size(1345, 640);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private PPTAbonent pptAbonent1;
        private PPTFacialScore pptFacialScore1;
        internal System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
