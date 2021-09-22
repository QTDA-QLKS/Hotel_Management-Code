using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BussinessLayer
{
    public class SANPHAM
    {
        Entities db;
        public SANPHAM()
        {
            db = Entities.CreateEntities();
        }
        public tb_SanPham getItem(int sp)
        {
            return db.tb_SanPham.FirstOrDefault(x => x.IDSP == sp);
        }
        public List<tb_SanPham> getAll()
        {
            return db.tb_SanPham.ToList();
        }
        public void add(tb_SanPham sp)
        {
            try
            {
                db.tb_SanPham.Add(sp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi" + ex.Message);
            }
        }
        public void update(tb_SanPham sp)
        {
            tb_SanPham _cty = db.tb_SanPham.FirstOrDefault(x => x.IDSP == sp.IDSP);
            _cty.TENSP = sp.TENSP;
            _cty.DONGIA = sp.DONGIA;
            _cty.DISABLED = sp.DISABLED;
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
            tb_SanPham cty = db.tb_SanPham.FirstOrDefault(x => x.IDSP == idsp);
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
