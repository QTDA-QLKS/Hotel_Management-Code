using System;
using DataLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class TANG
    {
        Entities db;
        public TANG()
        {
            db = Entities.CreateEntities();
        }

        public tb_Tang getItem(int tang)
        {
            return db.tb_Tang.FirstOrDefault(x => x.IDTANG == tang);
        }

        public List<tb_Tang> getAll()
        {
            return db.tb_Tang.ToList();
        }

        public void add(tb_Tang cty)
        {
            try
            {
                db.tb_Tang.Add(cty);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi" + ex.Message);
            }
        }
        public void update(tb_Tang cty)
        {
            tb_Tang _cty = db.tb_Tang.FirstOrDefault(x => x.TENTANG == cty.TENTANG);
            _cty.DISABLED = cty.DISABLED;
            try
            {
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra " + ex.Message);
            }

        }
        public void delete(string macty)
        {
            tb_Tang cty = db.tb_Tang.FirstOrDefault(x => x.TENTANG == macty);
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
