using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BussinessLayer
{
    public class LOAIPHONG
    {
        Entities db;
        public LOAIPHONG()
        {
            db = Entities.CreateEntities();
        }
        public tb_LoaiPhong getItem(int sp)
        {
            return db.tb_LoaiPhong.FirstOrDefault(x => x.IDLOAIPHONG == sp);
        }
        public List<tb_LoaiPhong> getAll()
        {
            return db.tb_LoaiPhong.ToList();
        }
        public void add(tb_LoaiPhong sp)
        {
            try
            {
                db.tb_LoaiPhong.Add(sp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi" + ex.Message);
            }
        }
        public void update(tb_LoaiPhong sp)
        {
            tb_LoaiPhong _sp = db.tb_LoaiPhong.FirstOrDefault(x => x.TENLOAIPHONG == sp.TENLOAIPHONG);
            _sp.DONGIA = sp.DONGIA;
            _sp.SONGUOITOIDA = sp.SONGUOITOIDA;
            _sp.SOGIUONG = sp.SOGIUONG;
            _sp.DISABLED = sp.DISABLED;
            try
            {
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra " + ex.Message);
            }

        }


        public void delete(int idsp)
        {
            tb_LoaiPhong cty = db.tb_LoaiPhong.FirstOrDefault(x => x.IDLOAIPHONG == idsp);
            cty.DISABLED = true;
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
