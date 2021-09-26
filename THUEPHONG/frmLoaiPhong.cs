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
    public partial class frmLoaiPhong : DevExpress.XtraEditors.XtraForm
    {
        public frmLoaiPhong()
        {
            InitializeComponent();
        }

        LOAIPHONG _loaiphong;
        bool _them;
        int _idsp;

        private void frmLoaiPhong_Load(object sender, EventArgs e)
        {
            _loaiphong = new LOAIPHONG();
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
            txtTenLoaiPhong.Enabled = t;
            txtSoNguoi.Enabled = t;
            txtSoGiuong.Enabled = t;
            txtDonGia.Enabled = t;
            chDisabled.Visible = !t;
        }

        void _reset()
        {
            txtTenLoaiPhong.Text = "";
            txtSoNguoi.Text = "0";
            txtSoGiuong.Text = "0";
            txtDonGia.Text = "0.1";
            chDisabled.Checked = false;
        }

        void loadData()
        {
            gcDanhSach.DataSource = _loaiphong.getAll();
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
                _loaiphong.delete(_idsp);
            }
            loadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                tb_LoaiPhong sp = new tb_LoaiPhong();
                sp.TENLOAIPHONG = txtTenLoaiPhong.Text;
                sp.SOGIUONG = int.Parse(txtSoGiuong.Text);
                sp.SONGUOITOIDA = int.Parse(txtSoNguoi.Text);
                sp.DISABLED = chDisabled.Checked;
                sp.DONGIA = int.Parse(txtDonGia.Text);
                _loaiphong.add(sp);
            }
            else
            {
                tb_LoaiPhong sp = new tb_LoaiPhong();
                sp.TENLOAIPHONG = txtTenLoaiPhong.Text;
                sp.SOGIUONG = int.Parse(txtSoGiuong.Text);
                sp.SONGUOITOIDA = int.Parse(txtSoNguoi.Text);
                sp.DISABLED = chDisabled.Checked;
                sp.DONGIA = int.Parse(txtDonGia.Text);
                _loaiphong.update(sp);
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
                txtTenLoaiPhong.Text = gvDanhSach.GetFocusedRowCellValue("TENLOAIPHONG").ToString();
                txtSoNguoi.Text = gvDanhSach.GetFocusedRowCellValue("SONGUOITOIDA").ToString();
                txtSoGiuong.Text = gvDanhSach.GetFocusedRowCellValue("SOGIUONG").ToString();
                txtDonGia.Text = gvDanhSach.GetFocusedRowCellValue("DONGIA").ToString();
                chDisabled.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("DISABLED").ToString());
            }
        }
    }
}