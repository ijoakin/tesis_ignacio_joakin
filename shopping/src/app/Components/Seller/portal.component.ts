import { Component, Inject, OnInit } from "@angular/core";
import { Country } from "src/app/Model/Country";
import { Product } from "src/app/Model/Product";
import { Stock } from "src/app/Model/Stock";
import { CountryService } from "src/app/Services/country.service";
import { DistanceService } from "src/app/Services/distances.service";
import { PredictionService } from "src/app/Services/prediction.service";
import { ProductService } from "src/app/Services/product.service";
import { SalePointService } from "src/app/Services/salepoint.service";
import { StockService } from "src/app/Services/stock.service";

@Component({
  selector:"app-portal",
  templateUrl:"./portal.component.html"
})

export class PortalComponent implements OnInit {
  public products: Product[];
  public product: Product;
  public countries: Country[];
  public country: Country;
  public showProduct: boolean;
  public stock: Stock;
  public showNotStock: boolean;


  constructor(@Inject(DistanceService) private distanceService: DistanceService,
    @Inject(ProductService) private productService: ProductService,
    @Inject(SalePointService) private salePointService: SalePointService,
    @Inject(CountryService) private countryService: CountryService,
    @Inject(StockService) private stockService: StockService,
    @Inject(PredictionService) private predictionService: PredictionService) {

  }

  public ngOnInit(): void {
    this.getAllProduct();
    this.getAllCoutries();
    this.clearData();
  }

  public clearData() {
    this.country = {
      category: '',
      code: '',
      description: '',
      id: 0
    }
    this.product = {
      description: '',
      id: 0,
      imagen: undefined,
      price: 0,
      productTypeDescription: '',
      productTypeId: 0
    }
    this.showProduct=false;
    this.showNotStock=false;
    this.stock = {
      amount: 0,
      id: 0,
      productDescription: '',
      productId: 0,
      salePointDescription: '',
      salePointId: 0
    }
  }

  public getProduct() {
    if (this.country.id !== 0 && this.product.id !== 0){
      this.showProduct = true;

        this.productService.GetProductById(String(this.product.id))
        .subscribe((data: Product) => {
          this.product = data;
        });
       this.stockService.GetStockBySalePointProduct(String(this.product.id), String(this.country.id))
        .subscribe((data: Stock) => {
          debugger;
          this.stock = data;
          if (this.stock.amount <= 0){
            this.showNotStock=true;
          }
        });
    }
  }

  public getAllProduct() {
    this.productService.GetAllProducts()
        .subscribe((data: Product[]) => this.products = data);
  }
   public getAllCoutries() {
    this.countryService.getAllCountries()
      .subscribe((data: Country[]) => this.countries = data);
  }
}
