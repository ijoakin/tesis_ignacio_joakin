using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class ProductType : BaseEntity
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get => base.Id; set => base.Id = value; }

        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}
