using Entities2;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class InventaryContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<InOutEntity> InOut { get; set; }
        public DbSet<StorageEntity> Storages { get; set; }
        public DbSet<WarehouseEntity> Wherehouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                //options.UseSqlServer("Server=TUPC\\SQLEXPRESS; Database=name; Integrated Security=True; Trusted_Connection=True;");
                
                
                //options.UseSqlServer("Server=host;Database=name;Uid=user;Pwd=pass");

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoryEntity>().HasData(
                new CategoryEntity { CategoryID = "ASH", CategoryName = "Aseo Hogar" },
                new CategoryEntity { CategoryID = "ASP", CategoryName = "Aseo Personal" },
                new CategoryEntity { CategoryID = "HGR", CategoryName = "Hogar" },
                new CategoryEntity { CategoryID = "PRF", CategoryName = "Perfumería" },
                new CategoryEntity { CategoryID = "SLD", CategoryName = "Salud" },
                new CategoryEntity { CategoryID = "VDJ", CategoryName = "Video Juegos" });

            modelBuilder.Entity<WarehouseEntity>().HasData(
                new WarehouseEntity
                {
                    WarehouseID = Guid.NewGuid().ToString(),
                    WarehouseName = "Bodega Central",
                    WarehouseAddress = "Av. Rivadavia 10000"
                },
                new WarehouseEntity
                {
                    WarehouseID = Guid.NewGuid().ToString(),
                    WarehouseName = "Bodega Gran BsAs",
                    WarehouseAddress = "Av. Rivadavia"
                },
                new WarehouseEntity
                {
                    WarehouseID = Guid.NewGuid().ToString(),
                    WarehouseName = "Bodega Norte",
                    WarehouseAddress = "Dirección Desconocida"
                },
                new WarehouseEntity
                {
                    WarehouseID = Guid.NewGuid().ToString(),
                    WarehouseName = "Bodega Centro",
                    WarehouseAddress = "Dirección Desconocida"
                },
                new WarehouseEntity
                {
                    WarehouseID = Guid.NewGuid().ToString(),
                    WarehouseName = "Bodega Sur",
                    WarehouseAddress = "Dirección Desconocida"
                });
        }
    }


}
