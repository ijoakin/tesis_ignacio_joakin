import { Component, Inject, OnInit } from "@angular/core";
import { Distance } from "src/app/Model/Distance";
import { DistanceService } from 'src/app/Services/distances.service';
import { faFilm, faEye, faTimes, faTruck } from '@fortawesome/free-solid-svg-icons';
import { ProductService } from "src/app/Services/product.service";
import { Product } from "src/app/Model/Product";
import { SalePoint } from "src/app/Model/SalePoint";
import { SalePointService } from "src/app/Services/salepoint.service";
import { CountryService } from "src/app/Services/country.service";
import { Country } from "src/app/Model/Country";
import { StockService } from "src/app/Services/stock.service";
import { Stock } from "src/app/Model/Stock";
import { PredictionService } from "src/app/Services/prediction.service";
import { Prediction } from "src/app/Model/Prediction";

@Component({
  templateUrl:'./distance.component.html',
  selector: 'app-distamce'
})
export class DistanceComponent implements OnInit {
  public distances: Distance[];
  public p: number;
  public products: Product[];
  public product: Product;
  public salePoints: SalePoint[];
  public salePoint: SalePoint;
  public country: Country;
  public countries: Country[];
  public ShowStock: boolean;
  public stock: Stock;
  public prediction: Prediction;

  filmIcon = faFilm;
  eyeIcon = faEye;
  timeIcon = faTimes;
  truck = faTruck;

  constructor(@Inject(DistanceService) private distanceService: DistanceService,
    @Inject(ProductService) private productService: ProductService,
    @Inject(SalePointService) private salePointService: SalePointService,
    @Inject(CountryService) private countryService: CountryService,
    @Inject(StockService) private stockService: StockService,
    @Inject(PredictionService) private predictionService: PredictionService
    ) {

  }

  ngOnInit() {
    this.getAllSalePoints();
    //this.getAllDistances();
    this.getAllProduct();
    this.getAllCoutries();
    this.ShowStock = false;

    this.country = {
      id: 0,
      description: '',
      category: '',
      code: ''
    }

    this.salePoint = {
      id: 0,
      address: '',
      country: '',
      countryCategory: '',
      countryId: 0,
      description: ''
    }
    this.product = {
      id: 0,
      description: '',
      imagen: undefined,
      price: 0,
      productTypeDescription: '',
      productTypeId: 0
    }
    this.stock = {
      amount: 0,
      id: 0,
      productDescription: '',
      productId: 0,
      salePointDescription: '',
      salePointId: 0
    }
    this.prediction = {
      id:0,
      amount: 0,
      applied: false,
      day: 0,
      productid: 0,
      salepointid: 0,
      date: undefined,
      month: 0,
      product: '',
      salepoint: '',
      year: 0
    }
  }
  public getAllDistances() {
    this.distanceService.getAllDistances()
    .subscribe((data: Distance[]) => {
      this.distances = data;
    });
  }

  public getAllSalePoints() {
    this.salePointService.getAllSalePoints().subscribe((data: SalePoint[]) => {
      this.salePoints = data;
    });
  }

  applyProductMoved( id: number) {
    let dist = this.distances[id - 1];

    this.predictionService.applyByProductIdCountryId(String(this.product.id),
    String(dist.salePoint_origenId), String(dist.salePoint_destinoId), String(dist.amountToMove))
    .subscribe((data: boolean) => {
      alert (data)
      this.Filtrar();
    });

  }

  public getAllCoutries() {
    this.countryService.getAllCountries()
      .subscribe((data: Country[]) => this.countries = data);
  }

   public getAllProduct() {
    this.productService.GetAllProducts()
        .subscribe((data: Product[]) => this.products = data);

    //this.description = 'Ignacio Joakin';
    //console.log(this.description);
  }
  public Filtrar() {
    //alert(this.country.id);
    var prd: Product;
    var stk: Stock;
    if (this.product.id > 0 && this.country.id >= 0) {
      this.ShowStock = true;

      this.stockService.GetStockBySalePointProduct(String(this.product.id), String(this.country.id))
        .subscribe((data: Stock) => {
          this.stock = data;
        });
      this.predictionService.getPredictionByProductIdCountryId(String(this.product.id), String(this.country.id))
          .subscribe((data: Prediction) => {
          this.prediction = data;
        });

      this.distanceService.getAllDistancesByIdProductIdCountry(String(this.product.id), String(this.country.id))
          .subscribe((data: Distance[]) => {
          this.distances = data;
        });
    }
  }
  public MoveProduct(countryOrigenId: number, cantidad: number) {

  }
  public getProductDescription() {
    var prd: Product;
    /*this.productService.GetProductById(String(this.product.id))
        .subscribe((data: Product) => prd = data);

        if (prd != undefined){
          return prd.description;
        }
    return '';
    */
    var idn: number = this.product.id - 1;

    if (idn > 0){
      return this.products[idn].description;
    }
    return '';
  }


}
