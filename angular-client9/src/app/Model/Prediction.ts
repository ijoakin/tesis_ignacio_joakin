export class Prediction {
  public id: number;
  public month: number;
  public day: number;
  public year: number;
  public salepointid: number;
  public productid: number;
  public salepoint: string;
  public product: string;
  public amount: number;
  public date: Date;
  public applied: boolean;

  constructor(id: number, date: Date,
   month: number,
   day: number,
   year: number,
   salepointid: number,
   productid: number,
   salepoint: string,
   product: string,
   amount: number,
   applied: boolean) {
     this.id = id;
     this.month = month;
     this.day = day;
     this.year = year;
     this.salepointid = salepointid;
     this.productid = productid;
     this.salepoint = salepoint;
     this.product = product;
     this.amount = amount;
     this.date = date;
     this.applied = applied;
   }
}
