using DataAccess;
using Entities2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class CategoryBusiness
    {
        public List<CategoryEntity> GetList()
        {
            using (var db = new InventaryContext())
            {
                return db.Categories.ToList();
            }    
        }
        public CategoryEntity GetCategoryByID(string id)
        {
            using (var db = new InventaryContext())
            {

                return db.Categories.FirstOrDefault(p => p.CategoryID == id);
            }
        }
        public void Create(CategoryEntity oCategory)
        {
            using (var db = new InventaryContext())
            {
                db.Categories.Add(oCategory);
                db.SaveChanges();
            }
        }

        public void Update(CategoryEntity oCategory)
        {
            using (var db = new InventaryContext())
            {
                db.Categories.Update(oCategory);
                db.SaveChanges();
            }
        }

    }
}
