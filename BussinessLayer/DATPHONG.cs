using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BussinessLayer;
namespace BussinessLayer
{
    public class DATPHONG
    {
        Entities db;
        public DATPHONG()
        {
            db = Entities.CreateEntities();
        }
        public tb_DatPhong getItem(int id)
        {
            return db.tb_DatPhong.FirstOrDefault(x => x.IDDP == id);
        }
        public List<tb_DatPhong> getAll()
        {
            return db.tb_DatPhong.ToList();
        }

        //public List<tb_DatPhong> getAll(DateTime tungay, DateTime denngay, string madvi, string macty)
        //{
        //    return db.tb_DatPhong.Where(x => x.NGAYDATPHONG >= tungay && x.NGAYDATPHONG < denngay && x.MACTY == macty && x.MADVI == madvi).ToList(); 
        //}

        //public List<OBJ_DATPHONG> getAll(DateTime tungay, DateTime denngay, string madvi, string macty)
        //{
        //    var listDP = db.tb_DatPhong.Where(x => x.NGAYDATPHONG >= tungay && x.NGAYDATPHONG < denngay && x.MACTY == macty && x.MADVI == madvi).ToList();
        //    List<OBJ_DATPHONG> lstDP = new List<OBJ_DATPHONG>();
        //    OBJ_DATPHONG dp;
        //    foreach (var item in listDP)
        //    {
        //        dp = new OBJ_DATPHONG();
        //        dp.IDDP = item.IDDP;
        //        dp.IDKH = item.IDKH;
        //        var kh = db.tb_KhachHang.FirstOrDefault(x => x.IDKH == item.IDKH);
        //        dp.HOTEN = kh.HOTEN;
        //        dp.IDUSER = item.IDUSER;
        //        dp.NGAYDATPHONG = item.NGAYDATPHONG;
        //        dp.NGAYTRAPHONG = item.NGAYTRAPHONG;
        //        dp.MACTY = item.MACTY;
        //        dp.MADVI = item.MADVI;
        //        dp.SONGUOIO = item.SONGUOIO;
        //        dp.SOTIEN = item.SOTIEN;
        //        dp.STATUS = item.STATUS;
        //        dp.THEODOAN = item.THEODOAN;
        //        dp.DISABLED = item.DISABLED;
        //        dp.GHICHU = item.GHICHU;
        //        lstDP.Add(dp);
        //    }
        //    return lstDP;
        //}

        public List<OBJ_DATPHONG> getAll(DateTime tungay, DateTime denngay)
        {
            var listDP = db.tb_DatPhong.Where(x => x.NGAYDATPHONG >= tungay && x.NGAYDATPHONG < denngay).ToList();
            List<OBJ_DATPHONG> lstDP = new List<OBJ_DATPHONG>();
            OBJ_DATPHONG dp;
            foreach (var item in listDP)
            {
                dp = new OBJ_DATPHONG();
                dp.IDDP = item.IDDP;
                dp.IDKH = item.IDKH;
                var kh = db.tb_KhachHang.FirstOrDefault(x => x.IDKH == item.IDKH);
                dp.HOTEN = kh.HOTEN;
                dp.IDUSER = item.IDUSER;
                dp.NGAYDATPHONG = item.NGAYDATPHONG;
                dp.NGAYTRAPHONG = item.NGAYTRAPHONG;
                dp.MACTY = item.MACTY;
                dp.MADVI = item.MADVI;
                dp.SONGUOIO = item.SONGUOIO;
                dp.SOTIEN = item.SOTIEN;
                dp.STATUS = item.STATUS;
                dp.THEODOAN = item.THEODOAN;
                dp.DISABLED = item.DISABLED;
                dp.GHICHU = item.GHICHU;
                lstDP.Add(dp);
            }
            return lstDP;
        }

        public tb_DatPhong add(tb_DatPhong kh)
        {
            try
            {
                db.tb_DatPhong.Add(kh);
                db.SaveChanges();
                return kh;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi" + ex.Message);
            }
        }
        public tb_DatPhong update(tb_DatPhong kh)
        {
            tb_DatPhong _kh = db.tb_DatPhong.FirstOrDefault(x => x.IDDP == kh.IDDP);
            _kh.IDKH = kh.IDKH;
            _kh.MACTY = kh.MACTY;
            _kh.MADVI = kh.MADVI;
            _kh.NGAYDATPHONG = kh.NGAYDATPHONG;
            _kh.NGAYTRAPHONG = kh.NGAYTRAPHONG;
            _kh.SONGUOIO = kh.SONGUOIO;
            _kh.SOTIEN = kh.SOTIEN;
            _kh.IDUSER = kh.IDUSER;
            _kh.THEODOAN = kh.THEODOAN;
            _kh.GHICHU = kh.GHICHU;
            _kh.DISABLED = kh.DISABLED;
            _kh.CREATED_DATE = kh.CREATED_DATE;
            try
            {
                db.SaveChanges();
                return kh;

            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra " + ex.Message);
            }

        }

        public void delete(int id)
        {
            tb_DatPhong _kh = db.tb_DatPhong.FirstOrDefault(x => x.IDDP == id);
            _kh.DISABLED = true;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi rồi bạn ơi" + ex.Message);
            }
        }
    }
}
