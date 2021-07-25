using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class SalePoint : BaseEntity
    {
        public string Description { get; set; }
        public string Address { get; set; }
      
        public int CountryId { get; set; }
        
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
    }
}
