import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Graph } from 'src/app/Model/Graph';
import { environment } from 'src/environments/environment';

@Injectable()
export class GraphService {

  constructor(private http: HttpClient) {

  }

  public GetDataToGraph(): Observable<Graph[]> {
    const Url: string = environment.baseUrl + 'DBTools/GetDataToGraph';

    return this.http.get<Graph[]>(Url);
  }
}
