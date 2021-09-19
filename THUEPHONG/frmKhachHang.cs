using DevExpress.XtraEditors;
using System;
using BussinessLayer;
using DataLayer;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THUEPHONG
{
    public partial class frmKhachHang : DevExpress.XtraEditors.XtraForm
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }

        KHACHHANG _khachhang;
        bool _them;
        int _idkh;

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            _khachhang = new KHACHHANG();
            loadData();
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
            txtMACTY.Enabled = t;
            txtTen.Enabled = t;
            txtDienThoai.Enabled = t;
            txtCCCD.Enabled = t;
            txtEmail.Enabled = t;
            txtDiaChi.Enabled = t;
            chDisabled.Visible = !t;
        }

        void _reset()
        {
            txtMACTY.Text = "";
            txtTen.Text = "";
            txtDienThoai.Text = "";
            txtCCCD.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            chDisabled.Checked = false;
        }

        void loadData()
        {
            gcDanhSach.DataSource = _khachhang.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            txtMACTY.Enabled = true;
            showHideControl(false);
            _enabled(true);
            _reset();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa không hử", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _khachhang.delete(_idkh);
            }
            loadData();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                tb_KhachHang kh = new tb_KhachHang();
                kh.HOTEN = txtTen.Text;
                kh.DIACHI = txtDiaChi.Text;
                kh.DIENTHOAI = txtDienThoai.Text;
                kh.EMAIL = txtEmail.Text;
                kh.CCCD = txtCCCD.Text;
                kh.DISABLED = chDisabled.Checked;
                _khachhang.add(kh);
            }
            else
            {
                tb_KhachHang kh = _khachhang.getItem(_idkh);
                kh.HOTEN = txtTen.Text;
                kh.DIACHI = txtDiaChi.Text;
                kh.DIENTHOAI = txtDienThoai.Text;
                kh.EMAIL = txtEmail.Text;
                kh.CCCD = txtCCCD.Text;
                kh.DISABLED = chDisabled.Checked;
                _khachhang.update(kh);
            }
            _them = false;
            loadData();
            _enabled(false);
            showHideControl(true);

        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            txtMACTY.Enabled = false;
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
                //_idkh = gvDanhSach.GetFocusedRowCellValue("IDKH").ToString();
                txtMACTY.Text = gvDanhSach.GetFocusedRowCellValue("IDKH").ToString();
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("HOTEN").ToString();
                txtDienThoai.Text = gvDanhSach.GetFocusedRowCellValue("DIENTHOAI").ToString();
                txtCCCD.Text = gvDanhSach.GetFocusedRowCellValue("CCCD").ToString();
                txtEmail.Text = gvDanhSach.GetFocusedRowCellValue("EMAIL").ToString();
                txtDiaChi.Text = gvDanhSach.GetFocusedRowCellValue("DIACHI").ToString();
                chDisabled.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("DISABLED").ToString());
            }
        }
    }
}