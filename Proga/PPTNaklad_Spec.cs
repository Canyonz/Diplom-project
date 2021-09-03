using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proga
{
    public partial class PPTNaklad_Spec : UserControl
    {
        public PPTNaklad_Spec()
        {
            Program.Naklad_Spec = this;
            InitializeComponent();
        }
    }
}
