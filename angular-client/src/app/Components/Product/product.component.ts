import { SecurityService } from './../../Services/security.service';
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { Product } from 'src/app/Model/Product';
import { ProductService } from '../../Services/product.service';
import { ProductType } from 'src/app/Model/ProductType';
import { ModalComponent } from '../Common/modal.component';

import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html'
})
export class ProductComponent implements OnInit {
  @ViewChild('modal1') modal1: ModalComponent;
  @ViewChild('modal2') modal2: ModalComponent;

  public description: string;
  public products: Product[];
  public product: Product;
  public productsTypes: ProductType[];
  public isDivErrorVisible: boolean;
  public p: number;
  constructor(@Inject(ProductService) private productService: ProductService,
                  private toastr: ToastrService, private securityService: SecurityService) {
  }

  public ngOnInit() {
    // Initial product to edit

    this.blankProduct();
    this.getAllProduct();
    this.getPorductTypes();
    this.isDivErrorVisible = this.securityService.isLogin();
  }
  public blankProduct() {
    this.product = {
      description: '',
      price: 0,
      id: 0,
      productTypeId: 0,
      productTypeDescription: ''
    };
  }

  public getPorductTypes() {
    this.productService.getProductTypes()
      .subscribe((data: ProductType[]) => {
        this.productsTypes = data;
        console.log(this.productsTypes);
      });
  }
  public getAllProduct() {
    this.productService.GetAllProducts()
        .subscribe((data: Product[]) => this.products = data);

    this.description = 'Ignacio Joakin';
    console.log(this.description);
  }
  public EditProduct(id: string) {
    console.log('edit product:' + id);

    this.productService.GetProductById(id)
      .subscribe((data: Product) => this.product = data);

    this.modal1.show();
  }
  public NewProduct() {
    this.blankProduct();
    this.modal1.show();
  }

  public SaveChanges() {
    this.productService.saveChanges(this.product).subscribe((data: boolean) => {
      // show toaster
      if (data) {
        this.toastr.success('Saved successfully', 'Products!');
        this.getAllProduct();
      }

    });
  }
  public ShowDeleteConfirm(id: string) {
    this.product.id = Number(id);
    this.modal2.show();
  }
  public DeleteProduct() {
    this.productService.DeleteProduct(String(this.product.id)).subscribe((data: boolean) => {
      // show toaster
      this.toastr.success('Removed successfully', 'Products!');
      this.getAllProduct();
    });
  }
}
