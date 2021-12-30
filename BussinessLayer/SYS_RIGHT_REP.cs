using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class SYS_RIGHT_REP
    {
        Entities db;
        public SYS_RIGHT_REP()
        {
            db = Entities.CreateEntities();
        }
        // lay ra cac quyen
      /*  public List<tb_SYS_RIGHT_REP> getListByUser(int idUser)
        {
            SYS_GROUP sGroup = new SYS_GROUP();
            var group = sGroup.getGroupByMemBer(idUser)
            if(group == null)
            {
                return db.tb_SYS_RIGHT_REP.Where(x => x.IDUSER == idUser && x.USER_RIGHT == true).ToList(); //lay quyen user
            }
            else
            {
                List<tb_SYS_RIGHT_REP> lstByGroup = db.tb_SYS_RIGHT_REP.Where(x => x.IDUSER == group.GROUP && x.USER_RIGHT == true).ToList();  //lay ra quyen cua nhom
                List<tb_SYS_RIGHT_REP> lstByUser = db.tb_SYS_RIGHT_REP.Where(x => x.IDUSER == idUser && x.USER_RIGHT == true).ToList(); //lay ra quyen cua rieng no 
                List<tb_SYS_RIGHT_REP> lstAll = lstByUser.Concat(lstByGroup).ToList(); // hop 2 quyen 
                return lstAll;
            }
        }*/
        public void update(int idUser, int rep_code, bool right)
        {
            tb_SYS_RIGHT_REP sRigh = db.tb_SYS_RIGHT_REP.FirstOrDefault(x => x.IDUSER == idUser && x.REP_CODE == rep_code);
            try
            {
                sRigh.USER_RIGHT = right;
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
