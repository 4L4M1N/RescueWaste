import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};  // Store username and password as object
  constructor(private authService: AuthService,
              private router: Router) { } // register /inject authservice

  ngOnInit() {
  }
  login() {
    this.authService.login(this.model).subscribe(next => { // pass model to authService.login();
      console.log('Successfully login');
    }, error => {
      console.log('Unable to login');
    }, () => {
      this.router.navigate(['/gUserDashboard']);
    });
  }
  loggedIn() {
    // const token = localStorage.getItem('token');
    // return !!token;
    // const token = this.authService.loggedIn();
    return this.authService.loggedIn();
  }
  logOut() {
    // localStorage.removeItem('token');
    // console.log('Log out successfully');
    this.authService.logOut();
    this.router.navigate(['/home']);
  }

}
