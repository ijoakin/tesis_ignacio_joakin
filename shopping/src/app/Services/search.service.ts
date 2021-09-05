import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Search } from '../Model/Search';
import { Observable } from 'rxjs';


@Injectable()
export class SearchService {
  constructor (private http: HttpClient) {
  }

  public saveChanges(s: Search): Observable<boolean> {
    const Url: string = environment.baseUrl + 'Searches/SaveIntencionCompra';

    const body = JSON.stringify(s);
    //return this.http.post<boolean>(Url, { params: {productid: productid, salepointid:salepointid } });
    const headers = new HttpHeaders().set('content-type', 'application/json');
    return this.http.post<boolean>(Url, body, { headers });
  }

  public getAllSearches() {

    const Url: string = environment.baseUrl + 'Searches/GetAllSearches';

    const token = localStorage.getItem('jwt');

    return this.http.get<Search[]>(Url, {
      headers: new HttpHeaders({
        'Authorization': 'Bearer ' + token,
        'Content-Type': 'application/json'
      })
    });
  }
}
