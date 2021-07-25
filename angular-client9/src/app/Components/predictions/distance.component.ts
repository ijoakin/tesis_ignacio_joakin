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

  filmIcon = faFilm;
  eyeIcon = faEye;
  timeIcon = faTimes;
  truck = faTruck;

  constructor(@Inject(DistanceService) private distanceService: DistanceService,
  @Inject(ProductService) private productService: ProductService,
  @Inject(SalePointService) private salePointService: SalePointService,
  @Inject(CountryService) private countryService: CountryService) {

  }

  ngOnInit() {
    this.getAllSalePoints();
    this.getAllDistances();
    this.getAllProduct();
    this.getAllCoutries();

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

}
