using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class MLModelDTO : BaseDTO
    {
        public int month { get; set; }
        public int year { get; set; }
        public int salepoint { get; set; }
        public int product { get; set; }
        public int success { get; set; }
        public int amount { get; set; }
    }
}
