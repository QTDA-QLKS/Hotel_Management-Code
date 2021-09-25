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

        public List<tb_Phong_ThietBi> getAll(string phong)
        {
            return db.tb_Phong_ThietBi.Where(x => x.IDTB == phong).ToList();
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
