

export class Stock {
  id: number;
  productId: number;
  productDescription: string;
  salePointId: number;
  salePointDescription: string;
  amount: number;
  // tslint:disable-next-line: max-line-length
  constructor(id: number, productid: number, productDescription: string, salePointId: number, salePointDescription: string, amount: number) {
    this.id = id;
    this.productId = productid;
    this.productDescription = productDescription;
    this.salePointDescription = salePointDescription;
    this.salePointId  = salePointId;
    this.amount = amount;
  }
}
