import { Component, Inject, OnInit } from "@angular/core";
import { Country } from "src/app/Model/Country";
import { Product } from "src/app/Model/Product";
import { Search } from "src/app/Model/Search";
import { Stock } from "src/app/Model/Stock";
import { CountryService } from "src/app/Services/country.service";
import { DistanceService } from "src/app/Services/distances.service";
import { PredictionService } from "src/app/Services/prediction.service";
import { ProductService } from "src/app/Services/product.service";
import { SalePointService } from "src/app/Services/salepoint.service";
import { SearchService } from "src/app/Services/search.service";
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
  public search: Search;


  constructor(@Inject(DistanceService) private distanceService: DistanceService,
    @Inject(ProductService) private productService: ProductService,
    @Inject(SalePointService) private salePointService: SalePointService,
    @Inject(CountryService) private countryService: CountryService,
    @Inject(StockService) private stockService: StockService,
    @Inject(PredictionService) private predictionService: PredictionService,
    @Inject(SearchService) private searchService: SearchService
    ) {

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

  public hideProduct() {
    this.showProduct =false;
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
          this.stock = data;
          if (this.stock.amount <= 0){
            this.showNotStock=true;
            this.search = {
              ProductId: this.product.id,
              amount: 1,
              success: false,
              salePointId: this.stock.salePointId,
              id: 0,
              month: 0,
              salePointDescription:'',
              productDescription: '',
              searchtext: 'fail',
              year: 0
            }
            this.searchService.saveChanges(this.search)
            .subscribe((data: boolean) => {
              //it was ok
            });
          }
          else{
            this.showNotStock=false;
          }
        });
    }
  }
  public comprar() {

    debugger;
    if (this.stock.amount > 0){
        this.search = {
          ProductId: this.product.id,
          amount: 1,
          success: true,
          salePointId: this.stock.salePointId,
          id: 0,
          month: 0,
          salePointDescription:'',
          productDescription: '',
          searchtext: 'success',
          year: 0
        }
        this.searchService.saveChanges(this.search)
        .subscribe((data: boolean) => {
          //it was ok
          alert("se ha generado la venta");
          this.getProduct();
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
