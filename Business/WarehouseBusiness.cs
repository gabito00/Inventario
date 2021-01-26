using DataAccess;
using Entities2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class WarehouseBusiness
    {
        public List<WarehouseEntity> GetList()
        {
            using (var db = new InventaryContext())
            {
                return db.Wherehouses.ToList();
            }
        }
        public WarehouseEntity GetWarehousesByID(string id)
        {
            using (var db = new InventaryContext())
            {

                return db.Wherehouses.FirstOrDefault(p => p.WarehouseID == id);
            }
        }
        public void Create(WarehouseEntity oWarehouse)
        {
            using (var db = new InventaryContext())
            {
                db.Wherehouses.Add(oWarehouse);
                db.SaveChanges();
            }
        }

        public void Update(WarehouseEntity oWarehouse)
        {
            using (var db = new InventaryContext())
            {
                db.Wherehouses.Update(oWarehouse);
                db.SaveChanges();
            }
        }
    }
}
