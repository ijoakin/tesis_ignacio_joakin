using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class SaleDTO : BaseDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SalePointId { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public string ProductDescription { get; set; }

        public string SalePointDescription { get; set; }
        public int month { get; set; }
        public int year { get; set; }
    }
    
}
