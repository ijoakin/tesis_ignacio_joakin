using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class CountryDTO: BaseDTO
    {
        public int id { get; set; }

        public string description { get; set; }

        public string category { get; set; }

        public string code { get; set; }
    }
}
