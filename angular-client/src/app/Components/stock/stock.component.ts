import { Component, OnInit, Inject } from '@angular/core';
import { Stock } from 'src/app/Model/Stock';
import { StockService } from 'src/app/Services/stock.service';

@Component({
  templateUrl: './stock.component.html',
  selector: 'app-stock'
})
export class StockComponent implements OnInit {
  public stocks: Stock[];
  public p: number;
  constructor(@Inject(StockService) private stockservice: StockService) {

  }
  ngOnInit() {
    this.getAllStock();
  }
  getAllStock() {
    console.log('getAllStock');
    this.stockservice.getAllStock().subscribe((values) => this.stocks = values);
  }
}
