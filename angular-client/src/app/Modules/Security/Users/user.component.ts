import { Component, Inject, OnInit } from '@angular/core';
import { SecurityService } from './../../../Services/security.service';
import { User } from 'src/app/Model/User';
import { Observable } from 'rxjs';

@Component({
  templateUrl: './user.component.html',
  selector: 'app-users'
})
export class UserComponent implements OnInit {
  title: String;
  user: User;
  users: User[];
  p: number;
  constructor(@Inject(SecurityService) private securityService: SecurityService) {

  }
  ngOnInit() {
    this.GetAllUsers();
  }
  public GetAllUsers() {
    this.securityService.getAllUsers()
        .subscribe((data) => { this.users = data; });
  }
}
