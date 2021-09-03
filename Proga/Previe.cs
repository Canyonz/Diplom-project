using System;
using System.Windows.Forms;

namespace Proga
{
    public partial class Previe : Form
    {
        public Previe()
        {
            InitializeComponent();
            Opacity = 0;
            timer1.Interval = 40;
            timer1.Start();
        }

        private void Previe_Load(object sender, EventArgs e)
        {
            //this.TransparencyKey = this.BackColor;
        }
        //Проявление формы
        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((Opacity += 0.1) == 1) timer1.Stop();
        }
    }
}
