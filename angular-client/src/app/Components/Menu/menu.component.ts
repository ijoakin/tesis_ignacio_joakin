import { Component, Inject, OnInit } from '@angular/core';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html'
})
export class MenuComponent implements OnInit {
  constructor(@Inject(LoginService) private loginService: LoginService) {
  }

  ngOnInit() {
    this.loginService.logOut();
    this.isLoginVisible();
  }

  isLoginVisible() {
    return this.loginService.isLogin();
  }
  logOutClick() {
    this.loginService.logOut();
  }
}
