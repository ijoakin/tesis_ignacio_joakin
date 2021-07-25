export class Search {
  id: number;
  searchtext: string;
  success: boolean;
  amount: number;
  ProductId: number;
  productDescription: string;
  SalePointDescription: string;
  public month: string;
  public year: string;

  constructor(id: number,
    searchtext: string,
    success: boolean,
    amount: number,
    ProductId: number,
    productDescription: string,
    SalePointDescription: string,
    month: string,
    year: string
  ) {
    this.id = id;
    this.searchtext = searchtext;
    this.success = success;
    this.amount = amount;
    this.ProductId = ProductId;
    this.productDescription = productDescription;
    this.SalePointDescription = SalePointDescription;
    this.month = month;
    this.year = year;
  }
}
