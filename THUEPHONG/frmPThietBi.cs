using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using BussinessLayer;
namespace THUEPHONG
{
    public partial class frmPThietBi : DevExpress.XtraEditors.XtraForm
    {
        public frmPThietBi()
        {
            InitializeComponent();
        }

        PTHietBi _pthietbi;
        PHONG _phong;
        ThietBi _thietbi;
        bool _them;
        string _madvi;
        int idPhong=0;

        private void frmPThietBi_Load(object sender, EventArgs e)
        {
            _phong = new PHONG();
            _pthietbi = new PTHietBi();
            _thietbi = new ThietBi();
            loadThietBi();
            loadPhong();
            showHideControl(true);
            _enabled(true);
            cboTB.SelectedIndexChanged += cboCty_SelectedIndexChanged;
            cboTPhong.SelectedIndexChanged += cboCty_SelectedIndexChanged;
            loadTenThietBi();
            loadTenPhong();
        }

        private void cboCty_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTenThietBi();
            loadTenPhong();
        }

        void showHideControl(bool t)
        {
            btnThem.Visible = t;
            btnSua.Visible = t;
            btnXoa.Visible = t;
            btnLuu.Visible = !t;
            btnBoQua.Visible = !t;
        }

        void _enabled(bool t)
        {
            cboTPhong.Enabled = t;
            cboTB.Enabled = t;
            cboSL.Enabled = t;
        }

        void _reset()
        {
            cboTPhong.Text = "";
            cboTB.Text = "";
            cboSL.Text = "0";
        }


        void loadThietBi()
        {
            cboTB.DataSource = _thietbi.getByThietBi();
            cboTB.DisplayMember = "TENTHIETBI";
            cboTB.ValueMember = "IDTB";
        }

        void loadPhong()
        {
            cboTPhong.DataSource = _phong.getAll();
            cboTPhong.DisplayMember = "TENPHONG";
            cboTPhong.ValueMember = "IDPHONG";
        }

        void loadData()
        {
            gcDanhSach.DataSource = _pthietbi.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void loadTenPhong()
        {

            gcDanhSach.DataSource = _pthietbi.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void loadTenThietBi()
        {
            gcDanhSach.DataSource = _phong.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {

        }
    }
}