import { Component } from "@angular/core";

@Component({
  selector:"app-seller",
  templateUrl:"./seller.component.html"
})

export class SellerComponent {

  constructor() {
    //this.showAlert();
  }
  showAlert() {
    alert('testing');
  }
}
