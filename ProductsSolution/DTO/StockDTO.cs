using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class StockDTO : BaseDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductDescription { get; set; }
        public int SalePointId { get; set; }
        public string SalePointDescription { get; set; }
        public int Amount { get; set; }

        public string Country { get; set; }

    }
}
