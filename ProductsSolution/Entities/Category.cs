using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Category : BaseEntity
    {
        public string description { get; set; }

        public string code { get; set; }
        public int maxprice { get; set; }

    }
}
