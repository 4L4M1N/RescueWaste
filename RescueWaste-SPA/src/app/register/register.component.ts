import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  model: any = {} ;
  roles: any;
  constructor(private authService: AuthService, private router: Router, private http: HttpClient) {
    if (this.authService.loggedIn()) {
      this.router.navigate(['/gUserDashboard']);
    }
   }

  ngOnInit() {
    this.getRoles();
  }
  getRoles() {
    this.http.get('http://localhost:5000/api/role').subscribe(response => {
      this.roles = response;
      console.log(this.roles.name);
    }, error => {
      console.log(error);
    });
  }
  register() {
    console.log(this.model);
  }
  cancel() {
    console.log('Cancel worked');
  }

}
