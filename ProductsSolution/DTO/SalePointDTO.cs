using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class SalePointDTO : BaseDTO
    {
        public int id { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public int countryId { get; set; }
            
        public string country { get; set; }

        public string countryCategory { get; set; }
    }
}
