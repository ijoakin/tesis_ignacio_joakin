using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Product : BaseEntity
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get => base.Id; set => base.Id = value; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ProductTypeId { get; set; }

        public int UserId { get; set; }

        [ForeignKey("ProductTypeId")]
        public ProductType ProductType { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public Byte[] imageData { get; set; }

    }
}
