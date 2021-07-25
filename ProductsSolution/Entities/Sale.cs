using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Sale : BaseEntity
    {
        public int ProductId { get; set;}

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int Amount { get; set;}
        public DateTime Date { get; set;}
        public string str_date { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int SalePointId { get; set; }
        [ForeignKey("SalePointId")]
        public SalePoint SalePoint { get; set; }

        public int month { get; set; }
        public int year { get; set; }
        public int day { get; set; }
    }
}
