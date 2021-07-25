using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Search : BaseEntity
    {
        public string searchtext { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public bool success { get; set; }

        public int UserId { get; set; }
        
        public int SalePointId { get; set; }

        [ForeignKey("SalePointId")]
        public SalePoint SalePoint { get; set; }

        public int amount { get; set; }
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public DateTime Date { get; set; }
        public string str_date { get; set; }
    }
}
