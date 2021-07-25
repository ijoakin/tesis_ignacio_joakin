using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Stock : BaseEntity
    {

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int Amount { get; set; }
        public int SalePointId { get; set; }

        [ForeignKey("SalePointId")]
        public SalePoint SalePoint { get; set; }
    }
}
