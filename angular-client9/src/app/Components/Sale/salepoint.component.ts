import { SalePoint } from 'src/app/Model/SalePoint';
import { SalePointService } from 'src/app/Services/salepoint.service';
import { Component, Inject, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-salepoint',
  templateUrl: './salepoint.component.html'
})
export class SalePointComponent implements OnInit {

  salepoints: SalePoint[];
  salePoint: SalePoint;
  title: String;
  public p: number;

  constructor(@Inject(SalePointService) private salePointService: SalePointService) {

  }
  ngOnInit() {
    this.getAllSalePoints();
  }

  public getAllSalePoints() {
    this.salePointService.getAllSalePoints().subscribe((salepts: SalePoint[]) => this.salepoints = salepts);
  }

}
