export class Graph {
  public year: number;
  public month: number;
  public success: boolean;
  public amount: number;

  constructor(year: number, month: number, success: boolean, amount: number) {
    this.year = year;
    this.month = month;
    this.success = success;
    this.amount = amount;
  }
}
