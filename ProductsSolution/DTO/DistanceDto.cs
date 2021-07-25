using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DistanceDto : BaseDTO
    {
        public int Id { get; set; }

        public int SalePoint_origenId { get; set; }

        public string salePointOrigen { get; set; }

        public int SalePoint_destinoId { get; set; }

        public string salePointDestino { get; set; }

        public string countryOrigen { get; set; }

        public string countryDestino { get; set; }

        public int DistanceKm { get; set; }

        public int Productid { get; set; }

        public string ProductDescription { get; set; }

        public int Amount { get; set; }
    }
}
