
export class Sale {
  public id: number;
  public productId: string;
  public salePointId: number;
  public amount: number;
  public date: Date;
  public productDescription: string;
  public SalePointDescription: string;
  public month: string;
  public year: string;

  // tslint:disable-next-line:max-line-length
  constructor(id: number, productId: string, salePointId: number,  amount: number, date: Date, productDescription: string,
              salePointDescription: string, month: string, year: string ) {
    this.id = id;
    this.productId = productId;
    this.salePointId = salePointId;
    this.amount = amount;
    this.date = date;
    this.productDescription = productDescription;
    this.SalePointDescription = salePointDescription;
    this.month = month;
    this.year = year;
  }
}
