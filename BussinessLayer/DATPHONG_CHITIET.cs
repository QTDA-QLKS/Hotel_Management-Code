using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BussinessLayer;
namespace BussinessLayer
{
    public class DATPHONG_CHITITET
    {
        Entities db;
        public DATPHONG_CHITITET()
        {
            db = Entities.CreateEntities();
        }
        public tb_DatPhong_CT getItem(int id)
        {
            return db.tb_DatPhong_CT.FirstOrDefault(x => x.IDDP == id);
        }
        public List<tb_DatPhong_CT> getAllByDatPhong(int _idDP)
        {
            return db.tb_DatPhong_CT.Where(x => x.IDDP== _idDP).ToList();
        }

        public tb_DatPhong_CT getIDDPByPhong(int idPhong)
        {
            //Sắp xếp giảm dần theo ngày
            return db.tb_DatPhong_CT.OrderByDescending(x => x.NGAY).FirstOrDefault(x => x.IDPHONG == idPhong);
        }
        public tb_DatPhong_CT add(tb_DatPhong_CT kh)
        {
            try
            {
                db.tb_DatPhong_CT.Add(kh);
                db.SaveChanges();
                return kh;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi" + ex.Message);
            }
        }
        public void update(tb_DatPhong_CT kh)
        {
            tb_DatPhong_CT _kh = db.tb_DatPhong_CT.FirstOrDefault(x => x.IDDPCT == kh.IDDPCT);
            _kh.IDDP = kh.IDDP;
            _kh.IDPHONG = kh.IDPHONG;
            _kh.IDDPCT = kh.IDDPCT;
            _kh.NGAY = kh.NGAY;
            _kh.DONGIA = kh.DONGIA;
            _kh.SONGAYO = kh.SONGAYO;
            _kh.THANHTIEN = kh.THANHTIEN;
            try
            {
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra " + ex.Message);
            }

        }

        public void delete(int _idDP,int _idPhong)
        {
            tb_DatPhong_CT _kh = db.tb_DatPhong_CT.FirstOrDefault(x => x.IDDP == _idDP &&x.IDPHONG==_idPhong);
            try
            {
                db.tb_DatPhong_CT.Remove(_kh);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi rồi bạn ơi" + ex.Message);
            }
        }

        public void deleteAll(int idDP)
        {
            List<tb_DatPhong_CT> lstDPCT = db.tb_DatPhong_CT.Where(x => x.IDDP == idDP).ToList();
            try
            {
                db.tb_DatPhong_CT.RemoveRange(lstDPCT);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi dữ liệu" + ex.Message);
            }
        }
    }
}
