using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities2
{
    public class WarehouseEntity
    {
        [Key]
        [StringLength(50)]
        public string WarehouseID { get; set; }

        [Required]
        [StringLength(100)]
        public string WarehouseName { get; set; }

        [Required]
        [StringLength(100)]
        public string WarehouseAddress { get; set; }

        public ICollection<StorageEntity> Storages { get; set; }
    }
}
