import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { faEye, faFilm, faTimes } from '@fortawesome/free-solid-svg-icons';
import { ToastrService } from 'ngx-toastr';
import { ModalComponent } from 'src/app/Components/Common/modal.component';
import { Product } from 'src/app/Model/Product';
import { SalePoint } from 'src/app/Model/SalePoint';
import { Stock } from 'src/app/Model/Stock';
import { ProductService } from 'src/app/Services/product.service';
import { SalePointService } from 'src/app/Services/salepoint.service';
import { StockService } from 'src/app/Services/stock.service';

@Component({
  templateUrl: './stock.component.html',
  selector: 'app-stock'
})
export class StockComponent implements OnInit {
  @ViewChild('modal1') modal1: ModalComponent;
  @ViewChild('modal2') modal2: ModalComponent;
  public stocks: Stock[];
  public p: number;
  public stock: Stock;

  public salePoints: SalePoint[];
  public products: Product[];

  filmIcon = faFilm;
  eyeIcon = faEye;
  timeIcon = faTimes;

  constructor(@Inject(StockService) private stockservice: StockService,
              @Inject(ProductService) private productService: ProductService,
              @Inject(SalePointService) private salePointService: SalePointService,
              private toastr: ToastrService) {

  }
  blankEntities() {
    this.stock = {
      amount: 0,
      id: 0,
      productDescription: '',
      productId: 0,
      salePointDescription: '',
      salePointId: 0,
      country: ''
    }

    this.productService.GetAllProducts().subscribe((data: Product[]) => this.products = data );
    this.salePointService.getAllSalePoints().subscribe((data: SalePoint[]) => this.salePoints = data );
  }

  ngOnInit() {
    this.getAllStock();

    this.blankEntities();
  }
  getAllStock() {
    console.log('getAllStock');
    this.stockservice.getAllStock().subscribe((values) => this.stocks = values);
  }

  EditStock(id: number) {
     console.log('edit product:' + id);

    this.stockservice.GetById(id)
      .subscribe((data: Stock) => this.stock = data);

    this.modal1.show();
  }
  ShowDeleteConfirm(id: number) {
    this.stock.id = Number(id);
    this.modal2.show();
  }

  SaveChanges() {
     this.stockservice.saveChanges(this.stock).subscribe((data: boolean) => {
      // show toaster
      this.toastr.success('Se ha actualizado correctamente el punto de venta', 'Products!');
      this.getAllStock();
    });
  }
  DeleteStock() {
    this.stockservice.deleteSalePoint(this.stock.id).subscribe((data: boolean) => {
      // show toaster
      this.toastr.success('Se ha eliminado correctamente el punto de venta', 'Products!');
      this.getAllStock();
    });
  }


}
