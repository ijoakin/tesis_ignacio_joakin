using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Entities
{
    public class Prediction : BaseEntity
    {
        public DateTime date { get; set; }

        public int day { get; set; }

        public int month { get; set; }

        public int year { get; set; }

        public int salepointid { get; set; }
        [ForeignKey("salepointid")]
        public SalePoint SalePoint { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]

        public Product Product { get; set; }

        public int amount { get; set; }

        public bool applied { get; set; }

        

        

    }
}
