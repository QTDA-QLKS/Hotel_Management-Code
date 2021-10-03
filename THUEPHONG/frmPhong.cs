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
    public partial class frmPhong : DevExpress.XtraEditors.XtraForm
    {
        public frmPhong()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        PHONG _phong;
        TANG _tang;
        List<OBJ_PHONG> obj_phong;
        bool _them;
        int _idsp;
        int _idPhong = 0;
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
            txtTenPhong.Enabled = t;
            txtLoaiPhong.Enabled = t;
            chbDaThue.Visible = !t;
            chDisabled.Visible = t;
        }

        void _reset()
        {
            txtTenPhong.Text = "";
            txtLoaiPhong.Text = "";
            chDisabled.Checked = false;
            chbDaThue.Checked = false;
        }
        private void frmPhong_Load(object sender, EventArgs e)
        {
            _phong = new PHONG();
            _tang = new TANG();
            loadTang();
            cboTang.SelectedIndexChanged += cboCty_SelectedIndexChanged;
            showHideControl(true);
            _enabled(false);
            loadDVIByCty();
        }

        private void cboCty_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDVIByCty();
        }

        void loadTang()
        {
            cboTang.DataSource = _phong.getByTenTang();
            cboTang.DisplayMember = "TENTANG";
            cboTang.ValueMember = "IDTANG";
        }

        //void loadData()
        //{
        //    gcDanhSach.DataSource = _phong.getAll();
        //    gvDanhSach.OptionsBehavior.Editable = false;
        //}

        void loadDVIByCty()
        {
             gcDanhSach.DataSource = _phong.getAllByPhong(int.Parse(cboTang.SelectedValue.ToString()));
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                txtTenPhong.Text = gvDanhSach.GetFocusedRowCellValue("TENPHONG").ToString();
                txtLoaiPhong.Text = gvDanhSach.GetFocusedRowCellValue("TENLOAIPHONG").ToString();
                chDisabled.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("DISABLED").ToString());
                chbDaThue.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("STATUS").ToString());
            }
        }
    }
}