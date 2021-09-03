using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPSCityStreet : UserControl
    {
        public PPSCityStreet()
        {
            Program.CityStreet = this;
            InitializeComponent();
        }
    }
}
