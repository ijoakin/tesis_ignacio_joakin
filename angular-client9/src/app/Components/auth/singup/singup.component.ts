import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-singup',
  templateUrl: './singup.component.html',
  styleUrls: ['./singup.component.css']
})
export class SingupComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  onSingup(form: NgForm) {
    const email = form.value.email;
    const password = form.value.password;
    console.log('singup method');
  }

}
