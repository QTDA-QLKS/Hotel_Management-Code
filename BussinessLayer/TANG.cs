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
        public List<tb_Tang> getAll()
        {
            return db.tb_Tang.ToList();
        }
    }
}
