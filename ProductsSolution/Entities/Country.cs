using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Country : BaseEntity
    {
        public string description { get; set; }

        public string category { get; set; }

        public string code { get; set; }
    }
}
