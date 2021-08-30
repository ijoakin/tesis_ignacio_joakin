import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Country } from '../Model/Country';

@Injectable()
export class CountryService {
  constructor(private http: HttpClient) {

  }

  public getAllCountries(): Observable<Country[]> {
    const Url: string = environment.baseUrl + 'Country/GetAllCountries';

    return this.http.get<Country[]>(Url);
  }
  public DeleteCountry(id: string): Observable<boolean> {
      const Url: string = environment.baseUrl + 'country/DeleteCountry';

    return this.http.delete<boolean>(Url, { params: {id: id } });
  }

   public GetCountryById(id: string): Observable<Country> {
    const Url: string = environment.baseUrl + 'country/GetCountryById';
    return this.http.get<Country>(Url, { params : {id: id} });
  }


}
