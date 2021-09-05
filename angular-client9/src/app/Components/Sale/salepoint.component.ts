import { SalePoint } from 'src/app/Model/SalePoint';
import { SalePointService } from 'src/app/Services/salepoint.service';
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { faEye, faFilm, faTimes } from '@fortawesome/free-solid-svg-icons';
import { Country } from 'src/app/Model/Country';
import { CountryService } from 'src/app/Services/country.service';
import { ModalComponent } from 'src/app/Components/Common/modal.component';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-salepoint',
  templateUrl: './salepoint.component.html'
})
export class SalePointComponent implements OnInit {

  filmIcon = faFilm;
  eyeIcon = faEye;
  timeIcon = faTimes;

  countries: Country[];
  salepoints: SalePoint[];
  salePoint: SalePoint;
  title: String;
  public p: number;

  @ViewChild('modal1') modal1: ModalComponent;
  @ViewChild('modal2') modal2: ModalComponent;
  constructor(@Inject(SalePointService) private salePointService: SalePointService,
  @Inject(CountryService) private countryService: CountryService,
  private toastr: ToastrService,
  ) {

  }
  ngOnInit() {
    this.getAllSalePoints();
    this.getAllCountries();
    this.blankEntities();
  }

  public blankEntities(){
    this.salePoint = {
      address: '',
      country: '',
      countryCategory: '',
      countryId: 0,
      description: '',
      id: 0
    }
  }
  public getAllSalePoints() {
    this.salePointService.getAllSalePoints().subscribe((salepts: SalePoint[]) => this.salepoints = salepts);
  }
  public getAllCountries() {
    this.countryService.getAllCountries().subscribe((countries: Country[]) => this.countries = countries);
  }
  public NewSalePoint() {
    this.blankEntities();
    this.modal1.show();
  }
  public EditSalePoint(id: number) {
     console.log('edit product:' + id);

    this.salePointService.GetById(id)
      .subscribe((data: SalePoint) => this.salePoint = data);

    this.modal1.show();
  }

  public ShowDeleteConfirm(id: number) {
    this.salePoint.id = Number(id);
    this.modal2.show();
  }
  public SaveChanges() {
     this.salePointService.saveChanges(this.salePoint).subscribe((data: boolean) => {
      // show toaster
      this.toastr.success('Se ha actualizado correctamente el punto de venta', 'Products!');
      this.getAllSalePoints();
    });
  }
  public DeleteProduct() {
    this.salePointService.deleteSalePoint(this.salePoint.id).subscribe((data: boolean) => {
      // show toaster
      this.toastr.success('Se ha eliminado correctamente el punto de venta', 'Products!');
      this.getAllSalePoints();
    });
  }

}
