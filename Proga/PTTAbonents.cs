using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class PTTAbonents : UserControl
    {
        public PTTAbonents()
        {
            Program.Abonents = this;
            InitializeComponent();
        }
    }
}
