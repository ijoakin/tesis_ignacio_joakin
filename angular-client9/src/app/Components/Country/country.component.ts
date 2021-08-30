import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { faEye, faFilm, faTimes } from '@fortawesome/free-solid-svg-icons';
import { ToastrService } from 'ngx-toastr';
import { ModalComponent } from 'src/app/Components/Common/modal.component';
import { Category } from 'src/app/Model/Category';
import { Country } from 'src/app/Model/Country';
import { CountryService } from 'src/app/Services/country.service';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html'
})
export class CountryComponent implements OnInit {
  @ViewChild('modal1') modal1: ModalComponent;
  @ViewChild('modal2') modal2: ModalComponent;
  public country: Country;
  public Countries: Country[];
  public p: number;
  public categories: Category;

  filmIcon = faFilm;
  eyeIcon = faEye;
  timeIcon = faTimes;

  constructor(@Inject(CountryService) private countryService: CountryService, private toastr: ToastrService) {

  }

  public blankCountry() {
    this.country = {
      description: '',
      id: 0,
      code: '',
      category: ''
    };
  }

  ngOnInit() {
    this.blankCountry();
    this.getAllCountries();
  }
  public getAllCountries() {
    this.countryService.getAllCountries()
      .subscribe((data: Country[]) => this.Countries = data);
  }

  public NewCountry() {

  }

  public SaveChanges() {

  }

  public ShowDeleteConfirm(id: number) {
    this.country.id = Number(id);
    this.modal2.show();
  }
  public EditCountry(id: number) {
    console.log('edit product:' + String(id));

    this.countryService.GetCountryById(String(id))
      .subscribe((data: Country) => this.country = data);

    this.modal1.show();
  }
  public DeleteCountry() {
    this.countryService.DeleteCountry(String(this.country.id)).subscribe((data: boolean) => {
      // show toaster
      this.toastr.success('Removed successfully', 'Products!');
      this.getAllCountries();
    });
  }
}
