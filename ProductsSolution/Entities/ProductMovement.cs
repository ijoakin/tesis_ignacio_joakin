using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class ProductMovement: BaseEntity
    {
        public int SalePointSourceId { get; set; }

        public int SalePoinTargetId { get; set; }

        public int productId { get; set; }

        public int Amount { get; set; }
    }
}
