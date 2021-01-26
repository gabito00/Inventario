using DataAccess;
using Entities2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class InOutBusiness
    {
        public List<InOutEntity> GetList()
        {
            using (var db = new InventaryContext())
            {
                return db.InOut.ToList();
            }
        }
        public InOutEntity GetInOutByID(string id)
        {
            using (var db = new InventaryContext())
            {

                return db.InOut.FirstOrDefault(p => p.InOutID == id);
            }
        }
        public void Create(InOutEntity oInOut)
        {
            using (var db = new InventaryContext())
            {
                db.InOut.Add(oInOut);
                db.SaveChanges();
            }
        }

        public void Update(InOutEntity oInOut)
        {
            using (var db = new InventaryContext())
            {
                db.InOut.Update(oInOut);
                db.SaveChanges();
            }
        }
    }
}
