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
        string _idPhong;
        string idphong;

        private void frmPThietBi_Load(object sender, EventArgs e)
        {
            _phong = new PHONG();
            _pthietbi = new PTHietBi();
            _thietbi = new ThietBi();
            showHideControl(true);
            _enabled(false);
            loadTenPhong();
        }

        private void cboCty_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            txtTenPhong.Enabled = t;
            txtTenTB.Enabled = t;
            txtSL.Enabled = t;
        }

        void _reset()
        {
            txtTenPhong.Text = "";
            txtTenTB.Text = "";
            txtSL.Text = "0";
        }

        void loadData()
        {
            gcDanhSach.DataSource = _pthietbi.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void loadTenPhong()
        {

            gcDanhSach.DataSource = _pthietbi.getAllByPTB(_idPhong);
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
                _pthietbi.delete(idphong);
            }
            loadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            //{

            //    tb_Phong_ThietBi sp = new tb_Phong_ThietBi();
            //    sp.TEN = txtTenSP.Text;
            //    sp.DISABLED = chDisabled.Checked;
            //    sp.DONGIA = int.Parse(txtDonGia.Text);
            //    _pthietbi.add(sp);
            //}
            //else
            //{
            //    tb_Phong_ThietBi sp = new tb_Phong_ThietBi();
            //    sp.TENSP = txtTenSP.Text;
            //    sp.DISABLED = chDisabled.Checked;
            //    sp.DONGIA = int.Parse(txtDonGia.Text);
            //    _pthietbi.update(sp);
            //}
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

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                txtTenTB.Text = gvDanhSach.GetFocusedRowCellValue("TENTHIETBI").ToString();
                txtSL.Text = gvDanhSach.GetFocusedRowCellValue("SOLUONG").ToString();
                txtTenPhong.Text = gvDanhSach.GetFocusedRowCellValue("TENPHONG").ToString();
            }
        }
    }
}