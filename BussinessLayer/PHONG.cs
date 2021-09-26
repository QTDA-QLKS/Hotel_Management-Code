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
        public List<tb_Phong> getByTang(int idTang)
        {
            return db.tb_Phong.Where(x => x.IDTANG == idTang).ToList();
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
