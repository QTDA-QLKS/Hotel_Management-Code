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
        bool _them;
        int _idsp;
        int _idLoaiPhong = 0;

        private void frmPhong_Load(object sender, EventArgs e)
        {
            _phong = new PHONG();
            loadTang();
            //loadLoaiPhong();
            cboTang.SelectedIndexChanged += cboCty_SelectedIndexChanged;
            //cboTPhong.SelectedIndexChanged += cboCty_SelectedIndexChanged;
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
            gcDanhSach.DataSource = _phong.getByTenTangLoad(int.Parse(cboTang.SelectedValue.ToString()));
            gvDanhSach.OptionsBehavior.Editable = false;
        }
    }
}