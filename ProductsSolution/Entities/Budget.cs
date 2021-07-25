using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Budget
    {
        public int id { get; set; }
        public string description { get; set; }
        public decimal amount { get; set; }

        public int currentMonth { get; set; }

        public int currentYear { get; set; }

    }
}
