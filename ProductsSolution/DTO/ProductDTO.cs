using System;

namespace DTO
{
    public class ProductDTO: BaseDTO
    {
        public int id { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int productTypeId { get; set; }

        public string productTypeDescription { get; set; }

        public int userid { get; set; }

        public Byte[] imagen { get; set; }

    }
}
