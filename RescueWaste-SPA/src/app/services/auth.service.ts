import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseurl =  'http://localhost:5000/api/auth/';
constructor(private http: HttpClient) { }
login(model: any) {
  return this.http.post(this.baseurl + 'login', model) // send api request
  .pipe(
    map((response: any) => { // received response through pipe.map and save response
      const user = response;
      if (user) {
        localStorage.setItem('token', user.token);
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
  return !!token;
}
  // logout method
logOut() {
  localStorage.removeItem('token');
  console.log('Log out successfully');
}
}
