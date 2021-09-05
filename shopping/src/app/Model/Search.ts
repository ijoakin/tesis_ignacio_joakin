export class Search {
  id: number;
  searchtext: string;
  success: boolean;
  amount: number;
  ProductId: number;
  productDescription: string;
  salePointDescription: string;
  salePointId: number;
  month: number;
  year: number;

  constructor(id: number,
    searchtext: string,
    success: boolean,
    amount: number,
    ProductId: number,
    productDescription: string,
    SalePointDescription: string,
    month: number,
    year: number,
    salePointId: number
  ) {
    this.id = id;
    this.searchtext = searchtext;
    this.success = success;
    this.amount = amount;
    this.ProductId = ProductId;
    this.productDescription = productDescription;
    this.salePointDescription = SalePointDescription;
    this.month = month;
    this.year = year;
    this.salePointId = salePointId;
  }
}
