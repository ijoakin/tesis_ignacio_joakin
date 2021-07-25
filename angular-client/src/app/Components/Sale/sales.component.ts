import { ToastrService } from 'ngx-toastr';
import { ProductService } from './../../Services/product.service';
import { ModalComponent } from './../Common/modal.component';
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { SaleService } from 'src/app/Services/sale.service';
import { Product } from 'src/app/Model/Product';

import { ServerSideSales } from '../../Model/ServerSideSales';
import { Sale } from 'src/app/Model/Sale';

import { Observable } from 'rxjs';
import { tap, map, filter } from 'rxjs/operators';

@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html'
})
export class SalesComponent implements OnInit {
  @ViewChild('modal1') modal1: ModalComponent;
  @ViewChild('modal2') modal2: ModalComponent;

  public asyncSales: Observable<ServerSideSales>;
  public sales: Sale[];
  public products: Product[];
  public sale: Sale;
  public p = 1;
  public loading: boolean;
  public total = 10;

  constructor(@Inject(SaleService) private saleService: SaleService,
              @Inject(ProductService) private productService: ProductService,
              private toastr: ToastrService) {
  }
  public ngOnInit() {
    console.log('get Sales');
    this.blankSale();
    this.getPage(1);
    this.getAllProducts();
  }
  blankSale() {
    this.sale = {
      amount: 0,
      date:  new Date(),
      id: 0,
      productId: '1',
      salePointId: 0,
      productDescription: '',
      SalePointDescription: '',
      month: '',
      year: ''
    };
  }

  getPage(page: number) {
    this.loading = true;
    console.log(page);

    this.asyncSales = this.saleService.getAllSales(String(page));

    this.asyncSales.subscribe((data) => {
      this.sales = data.data;
      this.total = data.count;
      console.log(data);
      this.loading = false;
    });
    this.p = page;
  }

  public EditSale(id: string) {
    console.log('edit sale:' + id);
    this.saleService.GetSaleById(id).subscribe((data: Sale) => this.sale = data);
    this.modal1.show();
  }
  public ShowDeleteConfirm(id: string) {
    this.sale.id = Number(id);
    this.modal2.show();
  }
  public SaveChanges() {
    this.saleService.Save(this.sale);
  }
  public NewSale() {

  }
  public getAllSales() {
    console.log('getAllSales');
    this.saleService.getSales()
      .subscribe((data: Sale[]) => {
        this.sales = data;
        console.log(this.sales.length);
      });
  }
  public getAllProducts() {
    this.productService.GetAllProductsInsecure().subscribe((data) => {
      this.products = data;
    });
  }
  public DeleteSale() {
    this.saleService.DeleteSale(String(this.sale.id)).subscribe((data) => {
      if (data) {
        this.toastr.success('delete successfully', 'Products!');
        this.getAllSales();
      }
    });
  }
}
