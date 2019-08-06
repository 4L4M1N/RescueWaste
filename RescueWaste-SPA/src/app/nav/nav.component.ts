import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};  // Store username and password as object
  constructor(private authService: AuthService) { } // register /inject authservice

  ngOnInit() {
  }
  login() {
    this.authService.login(this.model).subscribe(next => { // pass model to authService.login();
      console.log('Successfully login');
    }, error => {
      console.log('Unable to login');
    });
  }

}
