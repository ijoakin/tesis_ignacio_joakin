import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-server',
  templateUrl: './server.component.html',
  styleUrls: ['./server.component.css']
})
export class ServerComponent implements OnInit {

  public allowServer: boolean;
  constructor() { }

  ngOnInit() {
  }

  public onUpdateServerName(event: any) {

  }
  public addServerOnClick() {

  }
}
