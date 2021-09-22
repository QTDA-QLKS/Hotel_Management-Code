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
    public partial class frmTang : DevExpress.XtraEditors.XtraForm
    {
        public frmTang()
        {
            InitializeComponent();
        }

        TANG _tang;
        bool _them;
        string _idtang;

        private void frmTang_Load(object sender, EventArgs e)
        {
            _tang = new TANG();
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
            txtTen.Enabled = t;
            chDisabled.Visible = !t;
        }

        void _reset()
        {
            txtTen.Text = "";
            chDisabled.Checked = false;
        }

        void loadData()
        {
            gcDanhSach.DataSource = _tang.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            txtTen.Enabled = true;
            showHideControl(false);
            _enabled(true);
            _reset();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            _enabled(true);
            txtTen.Enabled = false;
            showHideControl(false);

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa không hử", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _tang.delete(_idtang);
            }
            loadData();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                tb_Tang kh = new tb_Tang();
                kh.TENTANG = txtTen.Text;
                kh.DISABLED = chDisabled.Checked;
                _tang.add(kh);
            }
            else
            {
                tb_Tang kh = new tb_Tang();
                kh.TENTANG = txtTen.Text;
                kh.DISABLED = chDisabled.Checked;
                _tang.update(kh);
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

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENTANG").ToString();
                chDisabled.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("DISABLED").ToString());
            }
        }
    }
}