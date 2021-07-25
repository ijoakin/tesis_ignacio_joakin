import { HttpClient } from '@angular/common/http';
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

}
