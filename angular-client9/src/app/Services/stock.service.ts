import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Stock } from '../Model/Stock';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';


@Injectable()
export class StockService {
  constructor(private http: HttpClient) {

  }

  public getAllStock(): Observable<Stock[]> {
    const url: string = environment.baseUrl + 'Stock/GetStockDTOs';
    return this.http.get<Stock[]>(url);
  }

  public GetStockBySalePointProduct(productId: string, countryid:string): Observable<Stock> {
    const url: string = environment.baseUrl + 'Stock/GetStockBySalePointProduct';
    return this.http.get<Stock>(url, { params: {productId: productId, countryid: countryid } });
  }
}
