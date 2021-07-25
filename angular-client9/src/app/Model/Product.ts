export class Product {
  public id: number;
  public description: string;
  public price: number;
  public productTypeId: number;
  public productTypeDescription: string;
  public imagen: File;


    constructor(id: number, description: string, price: number, productTypeId: number, productTypeDescription: string, imagen: File) {
      this.id = id;
      this.description = description;
      this.price = price;
      this.productTypeId = productTypeId;
      this.productTypeDescription = productTypeDescription;
      this.imagen = imagen;
    }
}
