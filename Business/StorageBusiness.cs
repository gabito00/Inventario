using DataAccess;
using Entities2;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class StorageBusiness
    {
        public List<StorageEntity> GetList()
        {
            using (var db = new InventaryContext())
            {
                return db.Storages.ToList();
            }
        }

        public void Create(StorageEntity oStorage)
        {
            using (var db = new InventaryContext())
            {
                db.Storages.Add(oStorage);
                db.SaveChanges();
            }
        }

        public void Update(StorageEntity oStorage)
        {
            using (var db = new InventaryContext())
            {
                db.Storages.Update(oStorage);
                db.SaveChanges();
            }
        }

        public bool IsProductInWarehouse(string id)
        {
            using (InventaryContext db = new InventaryContext())
            {
                return db.Storages.ToList()
                    .Where(s => s.StorageID == id)
                    .Any();
            }

        }

        public List<StorageEntity> StorageProductsByWarehouse(string warehouseId)
        {
            using (var db = new InventaryContext())
            {
                return db.Storages
                    .Include(s => s.Product)
                    .Include(s => s.Warehouse)
                    .Where(s => s.WarehouseID == warehouseId)
                    .ToList();
            }
        }
    }
}
