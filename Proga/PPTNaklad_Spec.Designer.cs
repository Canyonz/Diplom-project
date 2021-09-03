namespace Proga
{
    partial class PPTNaklad_Spec
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
            this.pptNakladnaya1 = new Proga.PPTNakladnaya();
            this.pptSpecNaklad1 = new Proga.PPTSpecNaklad();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel1.Controls.Add(this.pptNakladnaya1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pptSpecNaklad1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1207, 573);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pptNakladnaya1
            // 
            this.pptNakladnaya1.AutoSize = true;
            this.pptNakladnaya1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pptNakladnaya1.Location = new System.Drawing.Point(0, 0);
            this.pptNakladnaya1.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.pptNakladnaya1.Name = "pptNakladnaya1";
            this.pptNakladnaya1.Size = new System.Drawing.Size(1206, 573);
            this.pptNakladnaya1.TabIndex = 0;
            // 
            // pptSpecNaklad1
            // 
            this.pptSpecNaklad1.AutoSize = true;
            this.pptSpecNaklad1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pptSpecNaklad1.Location = new System.Drawing.Point(1208, 0);
            this.pptSpecNaklad1.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.pptSpecNaklad1.Name = "pptSpecNaklad1";
            this.pptSpecNaklad1.Size = new System.Drawing.Size(1, 573);
            this.pptSpecNaklad1.TabIndex = 1;
            // 
            // PPTNaklad_Spec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PPTNaklad_Spec";
            this.Size = new System.Drawing.Size(1207, 573);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PPTNakladnaya pptNakladnaya1;
        private PPTSpecNaklad pptSpecNaklad1;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
