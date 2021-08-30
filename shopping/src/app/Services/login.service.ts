import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable()
export class LoginService {
  constructor(@Inject(HttpClient) private http: HttpClient) {

  }
  login(credentials: any) {
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
