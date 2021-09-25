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
using BussinessLayer;
using DataLayer;
namespace THUEPHONG
{
    public partial class frmSanPham : DevExpress.XtraEditors.XtraForm
    {
        public frmSanPham()
        {
            InitializeComponent();
        }

        SANPHAM _sanpham;
        bool _them;
        int _idsp;

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            _sanpham = new SANPHAM();
            loadData();
            txtTenSP.Enabled = false;
            _enabled(true);
            showHideControl(true);
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
            txtTenSP.Enabled = t;
            txtDonGia.Enabled = t;
            chDisabled.Visible = !t;
        }

        void _reset()
        {
            txtTenSP.Text = "";
            txtDonGia.Text = "0.1";
            chDisabled.Checked = false;
        }

        void loadData()
        {
            gcDanhSach.DataSource = _sanpham.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            showHideControl(false);
            _enabled(true);
            _reset();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            _enabled(true);
            showHideControl(false);

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa không hử", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _sanpham.delete(_idsp);
            }
            loadData();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                tb_SanPham sp = new tb_SanPham();
                sp.TENSP = txtTenSP.Text;
                sp.DISABLED = chDisabled.Checked;
                sp.DONGIA = int.Parse(txtDonGia.Text);
                _sanpham.add(sp);
            }
            else
            {
                tb_SanPham sp = new tb_SanPham();
                sp.TENSP = txtTenSP.Text;
                sp.DISABLED = chDisabled.Checked;
                sp.DONGIA = int.Parse(txtDonGia.Text);
                _sanpham.update(sp);
            }
            _them = false;
            loadData();
            _enabled(false);
            showHideControl(true);

        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            _enabled(false);
            showHideControl(true);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                txtTenSP.Text = gvDanhSach.GetFocusedRowCellValue("TENSP").ToString();
                txtDonGia.Text = gvDanhSach.GetFocusedRowCellValue("DONGIA").ToString();
                chDisabled.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("DISABLED").ToString());
            }
        }
    }
}