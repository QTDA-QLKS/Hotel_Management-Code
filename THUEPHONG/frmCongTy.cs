using BussinessLayer;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using DataLayer;
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

namespace THUEPHONG
{
    public partial class frmCongTy : DevExpress.XtraEditors.XtraForm
    {
        public frmCongTy()
        {
            InitializeComponent();
        }

        CONGTY _congty;
        bool _them;
        string _macty;
        private void frmCongTy_Load(object sender, EventArgs e)
        {
            _congty = new CONGTY();
            loadData();
            txtMACTY.Enabled = false;
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

        void loadData()
        {
            gcDanhSach.DataSource = _congty.getAll();
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
            _them = false;
            _enabled(true);
            txtMACTY.Enabled = false;
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn muốn xóa không hử","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                _congty.delete(_macty);
            }
            loadData();
                
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                tb_CongTy cty = new tb_CongTy();
                cty.MACTY = txtMACTY.Text;
                cty.TENCTY = txtTen.Text;
                cty.DIACHI = txtDiaChi.Text;
                cty.DIENTHOAI = txtDienThoai.Text;
                cty.EMAIL = txtEmail.Text;
                cty.FAX = txtFax.Text;
                cty.DISABLED = chDisabled.Checked;
                _congty.add(cty);
            }
            else
            {
                tb_CongTy cty = _congty.getItem(_macty);
                cty.TENCTY = txtTen.Text;
                cty.DIACHI = txtDiaChi.Text;
                cty.DIENTHOAI = txtDienThoai.Text;
                cty.EMAIL = txtEmail.Text;
                cty.FAX = txtFax.Text;
                cty.DISABLED = chDisabled.Checked;
                _congty.update(cty);
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

        private void XuatReport(string _reportName, string _tieude)
        {
            if (_macty != null)
            {
                Form frm = new Form();
                CrystalReportViewer Crv = new CrystalReportViewer();
                Crv.ShowGroupTreeButton = false;
                Crv.ShowParameterPanelButton = false;
                Crv.ToolPanelView = ToolPanelViewType.None;
                TableLogOnInfo Thongtin;
                ReportDocument doc = new ReportDocument();
                doc.Load(System.Windows.Forms.Application.StartupPath + "\\Report\\" + _reportName + @".rpt");
                Thongtin = doc.Database.Tables[0].LogOnInfo;
                Thongtin.ConnectionInfo.ServerName = myFunctions._srv;
                Thongtin.ConnectionInfo.DatabaseName = myFunctions._db;
                //Thongtin.ConnectionInfo.UserID = myFunctions._us;
                //Thongtin.ConnectionInfo.Password = myFunctions._pw;
                doc.Database.Tables[0].ApplyLogOnInfo(Thongtin);
                try
                {
                    doc.SetParameterValue("macty", _macty.ToString());
                    Crv.Dock = DockStyle.Fill;
                    Crv.ReportSource = doc;
                    frm.Controls.Add(Crv);
                    Crv.Refresh();
                    frm.Text = _tieude;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.ToString());
                }
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _macty = gvDanhSach.GetFocusedRowCellValue("MACTY").ToString();
                txtMACTY.Text=gvDanhSach.GetFocusedRowCellValue("MACTY").ToString();
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENCTY").ToString();
                txtDienThoai.Text = gvDanhSach.GetFocusedRowCellValue("DIENTHOAI").ToString();
                txtFax.Text = gvDanhSach.GetFocusedRowCellValue("FAX").ToString();
                txtEmail.Text = gvDanhSach.GetFocusedRowCellValue("EMAIL").ToString();
                txtDiaChi.Text = gvDanhSach.GetFocusedRowCellValue("DIACHI").ToString();
                chDisabled.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("DISABLED").ToString());
            }
        }

        private void gvDanhSach_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            
        }

        private void btnIn_Click_1(object sender, EventArgs e)
        {
            XuatReport("DM_CONGTY", "Phiếu phòng chi tiết");
        }
    }
}