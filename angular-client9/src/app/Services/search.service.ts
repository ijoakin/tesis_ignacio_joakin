import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Search } from '../Model/Search';


@Injectable()
export class SearchService {
  constructor (private http: HttpClient) {
  }
  getAllSearches() {

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
