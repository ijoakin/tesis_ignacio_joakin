export class Distance {
  id: number;
  salePoint_origenId: number;
  salePointOrigen: string;
  salePoint_destinoId: number;
  salePointDestino: string;
  countryOrigen: string;
  countryDestino: string;
  distanceKm: number;
  productid: number;
  productdescription: string;
  amount: number;
  amountToMove: number;


  constructor(  id: number,
        salePoint_origenId: number,
        salePointOrigen: string,
        salePoint_destinoId: number,
        salePointDestino: string,
        countryOrigen: string,
        countryDestino: string,
        distanceKm: number,
        productid: number,
        productdescription: string,
        amount: number) {
          this.id = id;
          this.salePoint_origenId = salePoint_origenId;
          this.salePointOrigen = salePointOrigen;
          this.salePoint_destinoId = salePoint_destinoId;
          this.salePointDestino = salePointDestino;
          this.countryOrigen = countryOrigen;
          this.countryDestino = countryDestino;
          this.distanceKm = distanceKm;
          this.productid = productid;
          this.productdescription = productdescription;
          this.amount = amount;
          this.amountToMove = 0;
        }
}


/*
 public int Id { get; set; }

        public int SalePoint_origenId { get; set; }

        public string salePointOrigen { get; set; }

        public int SalePoint_destinoId { get; set; }

        public string salePointDestino { get; set; }

        public string countryOrigen { get; set; }

        public string countryDestino { get; set; }

        public int DistanceKm { get; set; }
 */
