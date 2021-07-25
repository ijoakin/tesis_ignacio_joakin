import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { LoginService } from 'src/app/Services/login.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-singin',
  templateUrl: './singin.component.html',
  styleUrls: ['./singin.component.css']
})
export class SinginComponent implements OnInit {
  public invalidLogin: boolean;
  constructor(@Inject(LoginService) private loginService: LoginService,
  private route: ActivatedRoute,
  private router: Router)  { }

  ngOnInit() {
  }

  login(form: NgForm) {
    debugger;
    const credentials = JSON.stringify(form.value);
    this.loginService.login(credentials).subscribe(response => {
      const token = (<any>response).token;
      localStorage.setItem('jwt', token);
      console.log(token);
      this.invalidLogin = false;
      this.router.navigate(['/']);
    }, err => {
      this.invalidLogin = true;
    });
  }
}
