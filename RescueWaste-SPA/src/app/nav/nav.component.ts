import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { AlertifyService } from '../services/alertify.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};  // Store username and password as object
  constructor(public authService: AuthService,
              private router: Router,
              private alertify: AlertifyService) { } // register /inject authservice

  ngOnInit() {
  }
  login() {
    this.authService.login(this.model).subscribe(next => { // pass model to authService.login();
      this.alertify.success('Successfully login');
    }, error => {
      console.log(error);
    }, () => {
      this.router.navigate(['/rescuer']);
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
    this.alertify.message('Loggedout successfully');
    this.router.navigate(['/home']);
  }

}
