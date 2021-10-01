using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BussinessLayer
{
    public class PHONG
    {
        Entities db;
        public PHONG()
        {
            db = Entities.CreateEntities();
        }
        public List<tb_Phong> getAll()
        {
            return db.tb_Phong.ToList();
        }

        public List<tb_Tang> getByTenTang()
        {
            return db.tb_Tang.ToList();
        }
        
        public List<tb_Phong> getByTenTangLoad()
        {
            return db.tb_Phong.ToList() ;
        }

        public List<tb_Phong> getByTenTangLoad(int idtang)
        {
            return db.tb_Phong.Where(x => x.IDTANG == idtang).ToList();

        }

        public List<tb_LoaiPhong> getByLoaiPhong(int _loaiphong)
        {
            return db.tb_LoaiPhong.Where(x => x.IDLOAIPHONG == _loaiphong).ToList();
        }

        public List<tb_Phong> getByTang(int idTang)
        {
            return db.tb_Phong.Where(x => x.IDTANG == idTang).ToList();
        }

        public List<OBJ_PHONG> getListFull()
        {
            var lsPhong = db.tb_Phong.ToList();
            List<OBJ_PHONG> lstDP = new List<OBJ_PHONG>();
            return lstDP;
        }
        public  OBJ_PHONG getItemFull(int _idPhong)
        {
            var _p = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == _idPhong);
            OBJ_PHONG phong = new OBJ_PHONG();
            phong.IDPHONG = _p.IDPHONG;
            phong.TENPHONG = _p.TENPHONG;
            phong.STATUS = bool.Parse(_p.STATUS.ToString());
            phong.DISABLED = bool.Parse(_p.DISABLED.ToString());
            phong.IDLOAIPHONG = _p.IDLOAIPHONG;
            phong.IDTANG = _p.IDTANG;
            var tang = db.tb_Tang.FirstOrDefault(t => t.IDTANG == _p.IDTANG);
            phong.TENTANG = tang.TENTANG;
            var lp = db.tb_LoaiPhong.FirstOrDefault(l =>l.IDLOAIPHONG==_p.IDLOAIPHONG);
            phong.TENLOAIPHONG = lp.TENLOAIPHONG;
            phong.DONGIA = double.Parse(lp.DONGIA.ToString());
            return phong;
        }

        public void add(tb_Phong phong)
        {
            try
            {
                db.tb_Phong.Add(phong);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi" + ex.Message);
            }
        }
        public void update(tb_Phong phong)
        {
            tb_Phong _kh = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == phong.IDPHONG);
            _kh.TENPHONG = phong.TENPHONG;
            _kh.STATUS = phong.STATUS;
            _kh.IDTANG = phong.IDTANG;
            _kh.IDLOAIPHONG = phong.IDLOAIPHONG;
            _kh.DISABLED = phong.DISABLED;
            try
            {
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra " + ex.Message);
            }

        }

        public void updateStatus(int id,bool status)
        {
            tb_Phong p = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == id);
            p.STATUS = status;
            db.SaveChanges();
        }

        public void delete(int idphong)
        {
            tb_Phong _kh = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == idphong);
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
