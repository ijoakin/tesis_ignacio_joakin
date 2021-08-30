import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Sale } from '../Model/Sale';
import { environment } from 'src/environments/environment';
import { stringify } from 'querystring';
import { Observable } from 'rxjs';
import { ServerSideSales } from '../Model/ServerSideSales';

@Injectable()
export class SaleService {

  constructor(private http: HttpClient) {

  }
  public Save(sale: Sale) {
    const Url: string = environment.baseUrl + 'sales/SaveSale';

    const salestr = stringify(sale);

    const headers = new HttpHeaders().set('content-type', 'application/json');
    return this.http.post<boolean>(Url, salestr, { headers: headers });
  }
  public getAllSales(page: string): Observable<ServerSideSales> {
    const Url: string = environment.baseUrl + 'sales/GetAllSalesPaginate';
    return this.http.get<ServerSideSales>(Url, { params: { page: page } });
  }

  public getSales() {
    const Url: string = environment.baseUrl + 'sales/GetSales';
    return this.http.get<Sale[]>(Url);
  }
  public GetSaleById(id: string) {
    const Url: string = environment.baseUrl + 'sales/GetSaleById';
    return this.http.get<Sale>(Url, { params: { id: id }} );
  }
  public DeleteSale(id: string) {
    const Url: string = environment.baseUrl + 'sales/DeleteSale';
    return this.http.delete<boolean>(Url, { params: {id: id} });
  }
}
