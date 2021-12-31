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
    public partial class frmThietBi : DevExpress.XtraEditors.XtraForm
    {
        public frmThietBi()
        {
            InitializeComponent();
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
                _thietbi.delete(_idtp);
            }
            loadData();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                tb_ThietBi tp = new tb_ThietBi();
                //sp.IDTB = txtIDTB.Text;
                tp.TENTHIETBI = txtTenSP.Text;
                tp.DISABLED = chDisabled.Checked;
                tp.DONGIA = int.Parse(txtDonGia.Text);
                _thietbi.add(tp);
            }
            else
            {
                tb_ThietBi tp = _thietbi.getItem(_idtp);
                tp.TENTHIETBI = txtTenSP.Text;
                tp.DISABLED = chDisabled.Checked;
                tp.DONGIA = int.Parse(txtDonGia.Text);
                _thietbi.add(tp);
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

        ThietBi _thietbi;
        bool _them;
        string _idtp;

        private void frmThietBi_Load(object sender, EventArgs e)
        {
            _thietbi = new ThietBi();
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
            gcDanhSach.DataSource = _thietbi.getByThietBi();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _idtp = gvDanhSach.GetFocusedRowCellValue("IDTB").ToString();
                //txtIDTB.Text = gvDanhSach.GetFocusedRowCellValue("IDTB").ToString();
                txtTenSP.Text = gvDanhSach.GetFocusedRowCellValue("TENTHIETBI").ToString();
                txtDonGia.Text = gvDanhSach.GetFocusedRowCellValue("DONGIA").ToString();
                chDisabled.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("DISABLED").ToString());
            }
        }
    }
}