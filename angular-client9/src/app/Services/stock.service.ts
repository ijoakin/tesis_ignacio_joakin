import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Stock } from '../Model/Stock';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';


@Injectable()
export class StockService {
  constructor(private http: HttpClient) {

  }

  getAllStock(): Observable<Stock[]> {
    const url: string = environment.baseUrl + 'Stock/GetStockDTOs';
    return this.http.get<Stock[]>(url);
  }
}
