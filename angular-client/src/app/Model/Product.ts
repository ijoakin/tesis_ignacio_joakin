export class Product {
  public id: number;
  public description: string;
  public price: number;
  public productTypeId: number;
  public productTypeDescription: string;


    constructor(id: number, description: string, price: number, productTypeId: number, productTypeDescription: string) {
      this.id = id;
      this.description = description;
      this.price = price;
      this.productTypeId = productTypeId;
      this.productTypeDescription = productTypeDescription;
    }
}
