using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BussinessLayer
{
    public class ThietBi
    {
        Entities db;
        public ThietBi()
        {
            db = Entities.CreateEntities();
        }
        public tb_ThietBi getItem(string tp)
        {
            return db.tb_ThietBi.FirstOrDefault(x => x.IDTB == tp);
        }
        public List<tb_ThietBi> getByThietBi()
        {
            return db.tb_ThietBi.ToList();
        }

        public void add(tb_ThietBi tp)
        {
            try
            {
                db.tb_ThietBi.Add(tp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi" + ex.Message);
            }
        }

        public void update(tb_ThietBi tp)
        {
            tb_ThietBi _tp = db.tb_ThietBi.FirstOrDefault(x => x.IDTB == tp.IDTB);
            _tp.TENTHIETBI = tp.TENTHIETBI;
            _tp.DONGIA = tp.DONGIA;
            _tp.DISABLED = tp.DISABLED;
            try
            {
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra " + ex.Message);
            }

        }
        public void delete(string idtp)
        {
            tb_ThietBi tb = db.tb_ThietBi.FirstOrDefault(x => x.IDTB == idtp);
            tb.DISABLED = true;
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
