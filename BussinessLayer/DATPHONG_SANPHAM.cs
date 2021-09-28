using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BussinessLayer
{
    public class DATPHONG_SANPHAM
    {
        Entities db;
        public DATPHONG_SANPHAM()
        {
            db = Entities.CreateEntities();
        }

        public List<OBJ_DPSP> getAllByDatPhong(int idDP)
        {
            var lst = db.tb_DatPhong_SanPham.Where(x => x.IDDP == idDP).ToList();
            List<OBJ_DPSP> lstDPSP = new List<OBJ_DPSP>();
            OBJ_DPSP sp;
            foreach( var item in lst)
            {
                sp = new OBJ_DPSP();
                sp.IDDPSP = item.IDDPSP;
                sp.IDDP = item.IDDP;
                sp.IDPHONG = item.IDPHONG;
                var p = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == item.IDPHONG);
                sp.TENPHONG = p.TENPHONG;
                sp.IDSP = item.IDSP;
                var s = db.tb_SanPham.FirstOrDefault(x => x.IDSP == item.IDSP);
                sp.TENSP = s.TENSP;
                sp.SOLUONG = item.SOLUONG;
                sp.DONGIA = item.DONGIA;
                sp.THANHTIEN = item.THANHTIEN;
                lstDPSP.Add(sp);

            }
            return lstDPSP;
        }
        public void add(tb_DatPhong_SanPham dpsp)
        {
            try
            {
                db.tb_DatPhong_SanPham.Add(dpsp);
                db.SaveChanges();

            }catch(Exception ex)
            {
                throw new Exception("Có lỗi dữ liệu" + ex.Message);
            }
        }
        public void deleteAll(int idDP)
        {
            List<tb_DatPhong_SanPham> lstDP = db.tb_DatPhong_SanPham.Where(x => x.IDDP == idDP).ToList();
            try
            {
                db.tb_DatPhong_SanPham.RemoveRange(lstDP);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi dữ liệu" + ex.Message);
            }
        }
    }
}
