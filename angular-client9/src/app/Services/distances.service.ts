import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Distance } from 'src/app/Model/Distance';
import { environment } from 'src/environments/environment';

@Injectable()
export class DistanceService {

  constructor(private http: HttpClient) {

  }

  public getAllDistances(): Observable<Distance[]> {
    const Url: string = environment.baseUrl + 'Country/GetDistances';

    return this.http.get<Distance[]>(Url);
  }
}
