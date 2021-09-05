import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment.prod';
import { SalePoint } from '../Model/SalePoint';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class SalePointService {
  constructor(private http: HttpClient) {

  }

  getAllSalePoints(): Observable<SalePoint[]> {
    // var URL = environment.baseUrl
    const url = environment.baseUrl + 'sales/GetSalesPoints';

    return this.http.get<SalePoint[]>(url);
  }

  GetById(id: number): Observable<SalePoint> {
    // var URL = environment.baseUrl
     const Url: string = environment.baseUrl + 'sales/GetById';
    return this.http.get<SalePoint>(Url, { params : {id: String(id) } });
  }

  deleteSalePoint(id: number): Observable<boolean>{
    // var URL = environment.baseUrl
     const Url: string = environment.baseUrl + 'sales/deleteSalePoint';
    return this.http.delete<boolean>(Url, { params : {id: String(id) } });
  }

  public saveChanges(sp: SalePoint): Observable<boolean> {
    const Url: string = environment.baseUrl + 'sales/SaveSalePoint';
    const body = JSON.stringify(sp);

    const headers = new HttpHeaders().set('content-type', 'application/json');
    return this.http.post<boolean>(Url, body, { headers });
  }

}
