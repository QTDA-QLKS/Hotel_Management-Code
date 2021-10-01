using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BussinessLayer;
namespace BussinessLayer
{
    public class PTHietBi
    {
        Entities db;
        public PTHietBi()
        {
            db = Entities.CreateEntities();
        }
        public tb_Phong_ThietBi getItem(int idphong)
        {
            return db.tb_Phong_ThietBi.FirstOrDefault(x => x.IDPHONG == idphong);
        }
        public List<tb_Phong_ThietBi> getAll()
        {
            return db.tb_Phong_ThietBi.ToList();
        }

        public List<tb_Phong> getAll(int macty)
        {
            return db.tb_Phong.Where(x => x.IDPHONG == macty).ToList();
        }

        public List<OBJ_PHONG> getAllByPTB(string _idPhong)
        {
            //var listDP = db.tb_Phong.Where(x => x.NGAYDATPHONG >= tungay && x.NGAYDATPHONG < denngay).ToList();
            var lst = db.tb_Phong_ThietBi.ToList();
            List<OBJ_PHONG> lstDPSP = new List<OBJ_PHONG>();
            OBJ_PHONG sp;
            foreach (var item in lst)
            {
                sp = new OBJ_PHONG();
                sp.IDTB = item.IDTB;
                sp.IDPHONG = item.IDPHONG;
                sp.SOLUONG = item.SOLUONG;
                var s = db.tb_ThietBi.FirstOrDefault(x => x.IDTB == item.IDTB);
                sp.TENTHIETBI = s.TENTHIETBI;
                var l = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == item.IDPHONG);
                sp.TENPHONG = l.TENPHONG;
                lstDPSP.Add(sp);
            }
            return lstDPSP;
        }

        public List<tb_Phong> getByTPhong(int idPhong)
        {
            return db.tb_Phong.Where(x => x.IDPHONG == idPhong).ToList();
            //tb_Phong _kh = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == idPhong);
            //tb_ThietBi _h = db.tb_ThietBi.FirstOrDefault(x => x.IDTB == id);
        }

        public List<tb_ThietBi> getByTB(string idtp)
        {
            return db.tb_ThietBi.Where(x => x.IDTB == idtp).ToList();
        }

        public List<tb_Phong_ThietBi> getByPhong(int tb)
        {
            return db.tb_Phong_ThietBi.Where(x => x.IDPHONG == tb).ToList();
        }

        public void add(tb_Phong_ThietBi pth)
        {
            try
            {
                db.tb_Phong_ThietBi.Add(pth);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi" + ex.Message);
            }
        }
        public void update(tb_Phong_ThietBi pth)
        {
            tb_Phong_ThietBi _kh = db.tb_Phong_ThietBi.FirstOrDefault(x => x.IDPHONG == pth.IDPHONG);
            _kh.IDTB = pth.IDTB;
            _kh.SOLUONG = pth.SOLUONG;
            try
            {
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra " + ex.Message);
            }

        }

        public void delete(string idphong)
        {
            tb_Phong_ThietBi _kh = db.tb_Phong_ThietBi.FirstOrDefault(x => x.IDTB == idphong);
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
