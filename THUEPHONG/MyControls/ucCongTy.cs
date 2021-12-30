using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLayer;
using DataLayer;
namespace THUEPHONG.MyControls
{
    public partial class ucCongTy : UserControl
    {
        public ucCongTy()
        {
            InitializeComponent();
        }

        private void ucCongTy_Load(object sender, EventArgs e)
        {
            CONGTY _congty = new CONGTY();
            cboCongTy.DisplayMember = "TENCY";
            cboCongTy.ValueMember = "MACTY";
            cboCongTy.SelectedValue = myFunctions._macty;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
