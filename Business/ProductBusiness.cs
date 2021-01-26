using DataAccess;
using Entities2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class ProductBusiness
    {
        public List<ProductEntity> GetList()
        {
            using (var db = new InventaryContext())
            {
                return db.Products.ToList();
            }
        }

        public ProductEntity GetProductByID(string id)
        {
            using (var db = new InventaryContext())
            {

                return db.Products.FirstOrDefault(p=> p.ProductID == id);
            }
        }

        public void Create(ProductEntity oProduct)
        {
            using (var db = new InventaryContext())
            {
                db.Products.Add(oProduct);
                db.SaveChanges();
            }
        }

        public void Update(ProductEntity oProduct)
        {
            using (var db = new InventaryContext())
            {
                db.Products.Update(oProduct);
                db.SaveChanges();
            }
        }
    }
}
