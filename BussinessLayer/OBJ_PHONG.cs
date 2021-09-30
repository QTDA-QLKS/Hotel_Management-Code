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
        public int? IDPHONG { set; get; }
        public string TENPHONG { set; get; }
        public double? DONGIA { set; get; }
        public string TENSP { set; get; }
        public int? SOLUONG { set; get; }
        public bool? STATUS { set; get; }
        public bool? DISABLED { set; get; }
        public int IDTANG { set; get; }
        public string TENTANG { set; get; }
        public int IDLOAIPHONG { set; get; }
        public string TENLOAIPHONG { set; get; }
    }
}
