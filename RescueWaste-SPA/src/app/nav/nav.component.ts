import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};  // Store username and password as object
  constructor() { }

  ngOnInit() {
  }
  login() {
    console.log(this.model);
  }

}
