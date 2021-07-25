using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PredictionDTO : BaseDTO
    {
        public int Id { get; set; }

        public DateTime date { get; set; }

        public int day { get; set; }

        public int month { get; set; }

        public int year { get; set; }

        public int salepointid { get; set; }

        public string salepoint { get; set; }

        public int productid { get; set; }

        public string product { get; set; }

        public int amount { get; set; }

        public bool applied { get; set; }
    }
}
