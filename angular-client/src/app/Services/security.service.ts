import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Sale } from '../Model/Sale';
import { environment } from 'src/environments/environment';
import { stringify } from 'querystring';
import { User } from '../Model/User';
import { Observable } from 'rxjs';

@Injectable()
export class SecurityService {
  constructor(private http: HttpClient) {

  }
  getAllUsers(): Observable<User[]> {
    const Url: string = environment.baseUrl + 'Security/GetAllUsers';
    return this.http.get<User[]>(Url);
  }
  login(credentials: any) {
    debugger;
    return this.http.post(environment.baseUrl + '/auth/login',
    credentials, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }
  isLogin() {
    return (localStorage.getItem('jwt') === 'null');
  }
  logOut() {
    localStorage.setItem('jwt', null);
  }
}
