import { Component, Inject, OnInit } from '@angular/core';
import { Country } from 'src/app/Model/Country';
import { CountryService } from 'src/app/Services/country.service';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html'
})
export class CountryComponent implements OnInit {

  public Countries: Country[];
  public p: number;
  constructor(@Inject(CountryService) private countryService: CountryService) {

  }

  ngOnInit() {
    this.getAllCountries();
  }
  public getAllCountries() {
    this.countryService.getAllCountries()
      .subscribe((data: Country[]) => this.Countries = data);
  }

}
