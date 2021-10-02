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
    public partial class frmDatPhongDon : DevExpress.XtraEditors.XtraForm
    {
        public frmDatPhongDon()
        {
            InitializeComponent();
        }
        public bool _them;
        public int _idPhong;
        int _idDP = 0;
        string _macty;
        string _madvi;
        SYS_PARAM _param;
        DATPHONG _datphong;
        DATPHONG_CHITITET _datphongct;
        DATPHONG_SANPHAM _datphongsp;
        OBJ_PHONG  _phongHienTai;
        SANPHAM _sanpham;
        PHONG _phong;
        List<OBJ_DPSP> lstDPSP;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(searchKH.EditValue==null|| searchKH.EditValue.ToString() == "")
            {
                MessageBox.Show("Vui lòng chọn khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            saveData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDatPhongDon_Load(object sender, EventArgs e)
        {
            _datphong = new DATPHONG();
            _datphongct = new DATPHONG_CHITITET();
            _datphongsp = new DATPHONG_SANPHAM();
            _sanpham = new SANPHAM();
            _phong = new PHONG();
            _param = new SYS_PARAM();
            lstDPSP = new List<OBJ_DPSP>();
            _phongHienTai = _phong.getItemFull(_idPhong);
            lblPhong.Text = _phongHienTai.TENPHONG + " - Đơn giá : " +_phongHienTai.DONGIA.ToString("N0") +" VND";
            var _prm = _param.GetParam();
            _macty = _prm.MACTY;
            _madvi = _prm.MADVI;
            
            dtNgayDat.Value = DateTime.Now;
            dtNgayTra.Value = DateTime.Now.AddDays(1);
            cbTrangThai.DataSource = TRANGTHAI.getList();
            cbTrangThai.ValueMember = "_value";
            cbTrangThai.DisplayMember = "_display";
            spSoNguoi.Text = "1";
            loadKH();
            loadSP();
            searchKH.EditValue = 1;
        }

        void loadSP()
        {
            gcSanPham.DataSource = _sanpham.getAll();
            gvSanPham.OptionsBehavior.Editable = false;
        }
        public void loadKH()
        {
            KHACHHANG _khachhang = new KHACHHANG();
            searchKH.Properties.DataSource = _khachhang.getAll();
            searchKH.Properties.ValueMember = "IDKH";
            searchKH.Properties.DisplayMember = "HOTEN";
        }

        public void setKH (string idkh)
        {
            searchKH.EditValue = idkh;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.kh_dp = "datphongdon";
            frm.ShowDialog();
        }

        private void gcSanPham_DoubleClick(object sender, EventArgs e)
        {
            if (_idPhong == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng?", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (gvSanPham.GetFocusedRowCellValue("IDSP") != null)
            {
                OBJ_DPSP sp = new OBJ_DPSP();
                sp.IDSP = int.Parse(gvSanPham.GetFocusedRowCellValue("IDSP").ToString());
                sp.TENSP = gvSanPham.GetFocusedRowCellValue("TENSP").ToString();
                sp.IDPHONG = _idPhong;
                sp.TENPHONG = _phongHienTai.TENPHONG; ;
                sp.SOLUONG = 1;
                sp.DONGIA = float.Parse(gvSanPham.GetFocusedRowCellValue("DONGIA").ToString());
                sp.THANHTIEN = sp.DONGIA * sp.SOLUONG;
                foreach (var item in lstDPSP)
                {
                    if (item.IDSP == sp.IDSP && item.IDPHONG == sp.IDPHONG)
                    {
                        item.SOLUONG = item.SOLUONG + 1;
                        item.THANHTIEN = item.SOLUONG * item.DONGIA;
                        loadDPSP();
                        return;
                    }

                }
                lstDPSP.Add(sp);
            }
            loadDPSP();
            txtThanhTien.Text = (double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + _phongHienTai.DONGIA).ToString("N0");
        }

        void loadDPSP()
        {
            List<OBJ_DPSP> lsDP = new List<OBJ_DPSP>();
            foreach (var item in lstDPSP)
            {
                lsDP.Add(item);
            }
            gcSPDV.DataSource = lstDPSP;
        }

        private void gvSPDV_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "SOLUONG")
            {
                int sl = int.Parse(e.Value.ToString());
                if (sl != 0)
                {
                    double gia = double.Parse(gvSPDV.GetRowCellValue(gvSPDV.FocusedRowHandle, "DONGIA").ToString());
                    gvSPDV.SetRowCellValue(gvSPDV.FocusedRowHandle, "THANHTIEN", sl * gia);
                }
                else
                {
                    gvSPDV.SetRowCellValue(gvSPDV.FocusedRowHandle, "THANHTIEN", 0);
                }
            }
            gvSPDV.UpdateTotalSummary();
            txtThanhTien.Text = (double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString())+_phongHienTai.DONGIA).ToString("N0");
        }

        private void gvSPDV_HiddenEditor(object sender, EventArgs e)
        {
            gvSPDV.UpdateCurrentRow();
        }

        void saveData()
        {
            if (_them)
            {
                tb_DatPhong dp = new tb_DatPhong();
                tb_DatPhong_CT dpct;
                tb_DatPhong_SanPham dpsp;
                dp.NGAYDATPHONG = dtNgayDat.Value;
                dp.NGAYTRAPHONG = dtNgayTra.Value;
                dp.SONGUOIO = int.Parse(spSoNguoi.EditValue.ToString());
                dp.STATUS = bool.Parse(cbTrangThai.SelectedValue.ToString());
                dp.THEODOAN = false;
                dp.DISABLED = false;
                dp.IDKH = searchKH.EditValue.ToString();
                dp.SOTIEN = double.Parse(txtThanhTien.Text);
                dp.GHICHU = txtGhiChu.Text;
                dp.IDUSER = 1;
                dp.MACTY = _macty;
                dp.MADVI = _madvi;
                dp.CREATED_DATE = DateTime.Now;
                var _dp = _datphong.add(dp);
                _idDP = _dp.IDDP;
                    dpct = new tb_DatPhong_CT();
                    dpct.IDDP = _dp.IDDP;
                    dpct.IDPHONG = _idPhong;
                    dpct.SONGAYO = dtNgayTra.Value.Day - dtNgayDat.Value.Day;
                    dpct.DONGIA = int.Parse(_phongHienTai.DONGIA.ToString());
                    dpct.THANHTIEN = dpct.SONGAYO = dpct.DONGIA;
                    dpct.NGAY = DateTime.Now;
                    var _dpct = _datphongct.add(dpct);
                    _phong.updateStatus(dpct.IDPHONG, true);
                    if (gvSPDV.RowCount > 0)
                    {
                        for (int j = 0; j < gvSPDV.RowCount; j++)
                        {
                            if (dpct.IDPHONG == int.Parse(gvSPDV.GetRowCellValue(j, "IDPHONG").ToString()))
                            {
                                dpsp = new tb_DatPhong_SanPham();
                                dpsp.IDDP = _dp.IDDP;
                                dpsp.IDDPCT = _dpct.IDDPCT;
                                dpsp.IDPHONG = int.Parse(gvSPDV.GetRowCellValue(j, "IDPHONG").ToString());
                                dpsp.IDSP = int.Parse(gvSPDV.GetRowCellValue(j, "IDSP").ToString());
                                dpsp.SOLUONG = int.Parse(gvSPDV.GetRowCellValue(j, "SOLUONG").ToString());
                                dpsp.DONGIA = int.Parse(gvSPDV.GetRowCellValue(j, "DONGIA").ToString());
                                dpsp.THANHTIEN = dpsp.SOLUONG * dpsp.DONGIA;
                                _datphongsp.add(dpsp);
                            }
                        }
                }
            }
            else
            {
                //update
                tb_DatPhong dp = _datphong.getItem(_idDP);
                tb_DatPhong_CT dpct;
                tb_DatPhong_SanPham dpsp;
                dp.NGAYDATPHONG = dtNgayDat.Value;
                dp.NGAYTRAPHONG = dtNgayTra.Value;
                dp.SONGUOIO = int.Parse(spSoNguoi.EditValue.ToString());
                dp.STATUS = bool.Parse(cbTrangThai.SelectedValue.ToString());
                dp.IDKH = searchKH.EditValue.ToString();
                dp.SOTIEN = double.Parse(txtThanhTien.Text);
                dp.GHICHU = txtGhiChu.Text;
                dp.IDUSER = 1;
                dp.UPDATE_BY = 1;
                dp.UPDATE_DATE = DateTime.Now;

                var _dp = _datphong.update(dp);
                _idDP = _dp.IDDP;
                _datphongct.deleteAll(_dp.IDDP);
                _datphongsp.deleteAll(_dp.IDDP);
                    dpct = new tb_DatPhong_CT();
                    dpct.IDDP = _dp.IDDP;
                    dpct.IDPHONG = _idPhong;
                    dpct.SONGAYO = dtNgayTra.Value.Day - dtNgayDat.Value.Day;
                    dpct.DONGIA = int.Parse(_phongHienTai.DONGIA.ToString());
                    dpct.THANHTIEN = dpct.SONGAYO = dpct.DONGIA;
                    dpct.NGAY = DateTime.Now;
                    var _dpct = _datphongct.add(dpct);
                    _phong.updateStatus(dpct.IDPHONG, true);
                    if (gvSPDV.RowCount > 0)
                    {
                        for (int j = 0; j < gvSPDV.RowCount; j++)
                        {
                            if (dpct.IDPHONG == int.Parse(gvSPDV.GetRowCellValue(j, "IDPHONG").ToString()))
                            {
                                dpsp = new tb_DatPhong_SanPham();
                                dpsp.IDDP = _dp.IDDP;
                                dpsp.IDDPCT = _dpct.IDDPCT;
                                dpsp.IDPHONG = int.Parse(gvSPDV.GetRowCellValue(j, "IDPHONG").ToString());
                                dpsp.IDSP = int.Parse(gvSPDV.GetRowCellValue(j, "IDSP").ToString());
                                dpsp.SOLUONG = int.Parse(gvSPDV.GetRowCellValue(j, "SOLUONG").ToString());
                                dpsp.DONGIA = int.Parse(gvSPDV.GetRowCellValue(j, "DONGIA").ToString());
                                dpsp.THANHTIEN = dpsp.SOLUONG * dpsp.DONGIA;
                                _datphongsp.add(dpsp);
                            }
                        }
                }
            }
        }

    }
}