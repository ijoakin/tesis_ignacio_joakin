using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class SearchDTO : BaseDTO
    {
        public int id { get; set; }
        public string searchtext { get; set; }
        public bool success { get; set; }
        public int ProductId { get; set; }
        public int userid { get; set; } 
        public string productDescription { get; set; }
        public string SalePointDescription { get; set; }
        public int amount { get; set; }
        public int month { get; set; }
        public int year { get; set; }

        public int salepointid { get; set; }
    }
}
