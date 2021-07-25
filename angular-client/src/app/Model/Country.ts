export class Country {
  public id: number;
  public description: string;
  public category: string;
  public code: string;

  constructor(id: number, description: string, category: string, code: string) {
    this.id = id;
    this.description = description;
    this.category = category;
    this.code = code;
  }
}
