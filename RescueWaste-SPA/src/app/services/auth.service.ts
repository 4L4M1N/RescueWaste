import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {map} from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseurl =  'http://localhost:5000/api/auth/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;


constructor(private http: HttpClient) { }
login(model: any) {
  return this.http.post(this.baseurl + 'login', model) // send api request
  .pipe(
    map((response: any) => { // received response through pipe.map and save response
      const user = response;
      if (user) {
        localStorage.setItem('token', user.token);
        this.decodedToken = this.jwtHelper.decodeToken(user.token); // decode token
        console.log(this.decodedToken);
      }
    }
    )
  );
}
  // register method
  register(model: any) {
    return this.http.post(this.baseurl + 'register', model);
  }

  // loggedin method
loggedIn() {
  const token = localStorage.getItem('token');
  // return !!token;
  return !this.jwtHelper.isTokenExpired(token);
}
  // logout method
logOut() {
  localStorage.removeItem('token');
  console.log('Log out successfully');
}
  roleMatch(allowedRole): boolean {
  let isMatch = false;
  const userRole = this.decodedToken.role;
  if (userRole === allowedRole) {
    isMatch = true;
  }
  return isMatch;
}
}
