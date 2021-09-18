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
    public partial class frmDonVi : DevExpress.XtraEditors.XtraForm
    {
        public frmDonVi()
        {
            InitializeComponent();
        }

        DONVI _donvi;
        CONGTY _congty;
        bool _them;
        string _madvi;

        private void frmDonVi_Load(object sender, EventArgs e)
        {
            _donvi = new DONVI();
            _congty = new CONGTY();
            loadCongty();
            showHideControl(true);
            txtMACTY.Enabled = false;
            _enabled(false);
            cboCty.SelectedIndexChanged += cboCty_SelectedIndexChanged;
            loadDVIByCty();
        }

        private void cboCty_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDVIByCty();
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
            txtFax.Enabled = t;
            txtEmail.Enabled = t;
            txtDiaChi.Enabled = t;
            chDisabled.Visible = !t;
        }

        void _reset()
        {
            txtMACTY.Text = "";
            txtTen.Text = "";
            txtDienThoai.Text = "";
            txtFax.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            chDisabled.Checked = false;
        }


        void loadCongty()
        {
            cboCty.DataSource = _congty.getAll();
            cboCty.DisplayMember = "TENCTY";
            cboCty.ValueMember = "MACTY";
        }

        void loadData()
        {
            gcDanhSach.DataSource = _donvi.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void loadDVIByCty(){
            gcDanhSach.DataSource = _donvi.getAll(cboCty.SelectedValue.ToString());
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            showHideControl(false);
            txtMACTY.Enabled = true;
            _enabled(true);
            _reset();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            _enabled(true);
            txtMACTY.Enabled = false;
            showHideControl(false);

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa không hử", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _donvi.delete(_madvi);
            }
            loadData();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                tb_DonVi dvi = new tb_DonVi();
                dvi.MADVI = txtMACTY.Text;
                dvi.MACTY = cboCty.SelectedValue.ToString();
                dvi.TENDVI = txtTen.Text;
                dvi.DIACHI = txtDiaChi.Text;
                dvi.DIENTHOAI = txtDienThoai.Text;
                dvi.EMAIL = txtEmail.Text;
                dvi.FAX = txtFax.Text;
                dvi.DISABLED = chDisabled.Checked;
                _donvi.add(dvi);
            }
            else
            {
                tb_DonVi dvi = _donvi.getItem(_madvi);
                dvi.MACTY = cboCty.SelectedValue.ToString();
                dvi.TENDVI = txtTen.Text;
                dvi.DIACHI = txtDiaChi.Text;
                dvi.DIENTHOAI = txtDienThoai.Text;
                dvi.EMAIL = txtEmail.Text;
                dvi.FAX = txtFax.Text;
                dvi.DISABLED = chDisabled.Checked;
                _donvi.update(dvi);
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
                _madvi = gvDanhSach.GetFocusedRowCellValue("MADVI").ToString();
                cboCty.SelectedValue = gvDanhSach.GetFocusedRowCellValue("MACTY");
                txtMACTY.Text = gvDanhSach.GetFocusedRowCellValue("MADVI").ToString();
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENDVI").ToString();
                txtDienThoai.Text = gvDanhSach.GetFocusedRowCellValue("DIENTHOAI").ToString();
                txtFax.Text = gvDanhSach.GetFocusedRowCellValue("FAX").ToString();
                txtEmail.Text = gvDanhSach.GetFocusedRowCellValue("EMAIL").ToString();
                txtDiaChi.Text = gvDanhSach.GetFocusedRowCellValue("DIACHI").ToString();
                chDisabled.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("DISABLED").ToString());
            }
        }
    }
}