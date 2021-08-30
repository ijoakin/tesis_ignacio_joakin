export class Category {
  public id: number;
  public description: string;
  public maxprice: number;
  public code: string;

  constructor(id: number, description: string, maxprice: number, code: string) {
    this.id = id;
    this.description = description;
    this.maxprice = maxprice;
    this.code = code;
  }
}
