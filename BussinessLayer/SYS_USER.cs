using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
namespace BussinessLayer
{
    public class SYS_USER
    {
        Entities db;
        public SYS_USER()
        {
            db = Entities.CreateEntities();
        }

        public List<tb_SYS_USER> getAll()
        {
            return db.tb_SYS_USER.ToList();
        }

        public tb_SYS_USER getItem(int idUser)
        {
            return db.tb_SYS_USER.FirstOrDefault(x => x.IDUSER == idUser);
        }


        public tb_SYS_USER getItem(string username,string password)
        {
            return db.tb_SYS_USER.FirstOrDefault(x => x.USERNAME == username&& x.PASSWD==password);
        }

        public List<tb_SYS_USER> getByDVI(string macty, string madvi)
        {
            return db.tb_SYS_USER.Where(x=>x.MACTY==macty&& x.MADVI==madvi).ToList();
        }

        public bool checkUserExist(string username)
        {
            var us = db.tb_SYS_USER.FirstOrDefault(x => x.USERNAME == username);
            if (us != null)
                return true;
            else
                return false;
        }
    }
}
