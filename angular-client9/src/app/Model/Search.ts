export class Search {
  id: number;
  searchtext: string;
  success: boolean;
  amount: number;
  productId: number;
  productDescription: string;
  salePointDescription: string;
  public month: string;
  public year: string;

  constructor(id: number,
    searchtext: string,
    success: boolean,
    amount: number,
    productId: number,
    productDescription: string,
    salePointDescription: string,
    month: string,
    year: string
  ) {
    this.id = id;
    this.searchtext = searchtext;
    this.success = success;
    this.amount = amount;
    this.productId = productId;
    this.productDescription = productDescription;
    this.salePointDescription = salePointDescription;
    this.month = month;
    this.year = year;
  }
}
