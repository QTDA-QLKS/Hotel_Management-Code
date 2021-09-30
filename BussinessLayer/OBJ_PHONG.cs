using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BussinessLayer;
namespace BussinessLayer
{
    public class OBJ_PHONG
    {
        public int? IDSP { set; get; }
        public int? IDDPSP { set; get; }
        public string TENSP { set; get; }
        public int? SOLUONG { set; get; }
        public double? DONGIA { set; get; }
        public double? THANHTIEN { set; get; }
        public int? IDPHONG { set; get; }
        public string TENPHONG { set; get; }
        public int IDDP { set; get; }

        Entities db;
        public OBJ_PHONG()
        {
            db = Entities.CreateEntities();
        }
        public tb_Phong getItemFull()
        {
            return db.tb_Phong.ToList();
        }
    }
}
