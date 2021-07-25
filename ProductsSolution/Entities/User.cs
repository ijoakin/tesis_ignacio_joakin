using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class User : BaseEntity
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get => base.Id; set => base.Id = value; }

        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public List<Product> Products { get; set; }
        public List<Sale> Sales { get; set; }
    }
}
