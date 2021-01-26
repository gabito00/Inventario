using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities2
{
    public class InOutEntity
    {
        [Key]
        [StringLength(50)]
        public string InOutID { get; set; }

        [Required]
        public DateTime InOutDate { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public bool IsInput { get; set; }

        public string StorageID { get; set; }
        public StorageEntity Storage { get; set; }
    }
}
