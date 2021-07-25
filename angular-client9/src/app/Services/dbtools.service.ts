import {Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { ProductType } from '../Model/ProductType';
import { MLModel } from '../Model/MLModel';

@Injectable()
export class DbtoolsService {
  headers: Headers;

  constructor(private http: HttpClient) {
    // this.headers = new Headers({ 'Content-Type': 'application/json', 'Accept': 'q=0.8;application/json;q=0.9' });

  }

  public SimulateSales(amount: string, month: string, year: string): Observable<boolean> {
    // tslint:disable-next-line: no-debugger
    debugger;
    const Url: string = environment.baseUrl + 'DBTools/SimulateSales';
    return this.http.get<boolean>(Url, {params: {count: amount, month, year }});
  }
  public CreateInitialData(): Observable<boolean> {
    const url: string = environment.baseUrl + 'DBTools/CreateInitialData';
    return this.http.get<boolean>(url);
  }
  public DbInitialSalePointStockData(): Observable<boolean> {
    const Url: string = environment.baseUrl + 'DBTools/DbInitialSalePointStockData';

    return this.http.get<boolean>(Url);
  }
  public SimulateFailSearches(amount: string, month: string, year: string): Observable<boolean> {
    const Url: string = environment.baseUrl + 'DBTools/SimulateFailSearches';
    return this.http.get<boolean>(Url, { params: {count: amount, month, year } });
  }

  public getMLModel(): Observable<MLModel[]> {
    const Url: string = environment.baseUrl + 'DBTools/GetMLModel';
    return this.http.get<MLModel[]>(Url);
  }
  public SimulateExecuteProccess(amount: string, month: string, year: string): Observable<boolean> {
    const Url: string = environment.baseUrl + 'DBTools/SimulateExecuteProccess';
    return this.http.get<boolean>(Url, { params: {count: amount, month, year } });
  }
}
