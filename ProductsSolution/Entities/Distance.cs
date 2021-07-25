using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Distance: BaseEntity
    {
        public int SalePoint_origenId { get; set; }
        
        public int SalePoint_destinoId { get; set; }

        public int DistanceKm { get; set; }
    }
}
