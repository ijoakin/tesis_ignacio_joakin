import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router/src/utils/preactivation';
import { Router } from '@angular/router';
import { JwtHelper} from 'angular-jwt';

@Injectable()
export class AuthGuard implements CanActivate {
  path;
  route;

  constructor(private jwtHelper: JwtHelper, private router: Router) {
  }

  canActivate() {
    const token = localStorage.getItem('jwt');

    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    this.router.navigate(['login']);
    return false;
  }

}
