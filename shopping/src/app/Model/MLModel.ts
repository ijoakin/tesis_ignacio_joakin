export class MLModel {
  public country: string;
  public product: string;
  public stockAmount: number;
  public price: number;

  constructor(country: string, product: string, stockAmount: number, price: number) {
    this.country = country;
    this.product = product;
    this.stockAmount = stockAmount;
    this.price = price;
  }
}
