using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities2
{
    public class CategoryEntity
    {
        [Key]
        [StringLength(50)]
        public string CategoryID { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        public ICollection<ProductEntity> Products { get; set; }
    }
}
