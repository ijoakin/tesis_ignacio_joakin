import { HttpClient, HttpHeaders } from '@angular/common/http';
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
  GetById(id: number): Observable<Stock> {
    // var URL = environment.baseUrl
     const Url: string = environment.baseUrl + 'Stock/GetById';
    return this.http.get<Stock>(Url, { params : {id: String(id) } });
  }

  deleteSalePoint(id: number): Observable<boolean>{
    // var URL = environment.baseUrl
     const Url: string = environment.baseUrl + 'Stock/deleteStock';
    return this.http.delete<boolean>(Url, { params : {id: String(id) } });
  }

  public saveChanges(sp: Stock): Observable<boolean> {
    const Url: string = environment.baseUrl + 'Stock/SaveStock';
    const body = JSON.stringify(sp);

    const headers = new HttpHeaders().set('content-type', 'application/json');
    return this.http.post<boolean>(Url, body, { headers });
  }
}
