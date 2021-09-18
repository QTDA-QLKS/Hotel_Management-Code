using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BussinessLayer
{
    public class CONGTY
    {
        Entities db;
        public CONGTY()
        {
            db = Entities.CreateEntities();
        }
        public tb_CongTy getItem(string macty)
        {
            return db.tb_CongTy.FirstOrDefault(x=> x.MACTY==macty);
        }
        public List<tb_CongTy> getAll()
        {
            return db.tb_CongTy.ToList();
        }
        public void add(tb_CongTy cty)
        {
            try 
            {
                db.tb_CongTy.Add(cty);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("Có lỗi"+ex.Message);
            }
        }
    }
}
