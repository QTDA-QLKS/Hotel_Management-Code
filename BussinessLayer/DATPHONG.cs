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
        public void add(tb_DatPhong kh)
        {
            try
            {
                db.tb_DatPhong.Add(kh);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi" + ex.Message);
            }
        }
        public void update(tb_DatPhong kh)
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

            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra " + ex.Message);
            }

        }

        public void delete(int id)
        {
            tb_DatPhong _kh = db.tb_DatPhong.FirstOrDefault(x => x.IDDP == id);
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
