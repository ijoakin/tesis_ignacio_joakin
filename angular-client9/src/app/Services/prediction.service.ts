import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Prediction } from 'src/app/Model/Prediction';
import { Observable } from 'rxjs';

@Injectable()
export class PredictionService {
  headers: Headers;

  constructor(private http: HttpClient) {
    this.headers = new Headers({ 'Content-Type': 'application/json', 'Accept': 'q=0.8;application/json;q=0.9' });
  }
  public GetAllPredictions(): Observable<Prediction[]> {
    const Url: string = environment.baseUrl + 'Predictions/getAllPredictions';

    return this.http.get<Prediction[]>(Url);
  }
  public applyPredictions(): Observable<Boolean> {
    const Url: string = environment.baseUrl + 'Predictions/applyAllPredictions';

    return this.http.get<Boolean>(Url);
  }


  public getPredictionByProductIdCountryId(productid: string, countryid: string): Observable<Prediction> {
    const Url: string = environment.baseUrl + 'Predictions/getAllPredictionsByProductIdCountryId';

    return this.http.get<Prediction>(Url, { params : {productid: productid, countryid: countryid } });

  }

  public applyByProductIdCountryId(productid: string, countryorigenid: string, countryDestinoid: string, amount: string): Observable<boolean> {
    const Url: string = environment.baseUrl + 'Predictions/applyByProductIdCountryId';

    return this.http.get<boolean>(Url, { params : {productid: productid, countryorigenid: countryorigenid, countryDestinoid: countryDestinoid, amount:amount } });

  }


}
