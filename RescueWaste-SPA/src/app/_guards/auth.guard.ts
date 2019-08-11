import { Injectable } from '@angular/core';
import { CanActivate, CanDeactivate, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { RegisterComponent } from '../register/register.component';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService,
              private router: Router) { }
  canActivate(): boolean {
    if (this.authService.loggedIn()) {
      return true;
    }
    this.router.navigate(['/home']);
    return false;
  }
  // TODO: Implement CanDeactive
  // canDeactivate(): boolean {
  //   if (this.authService.loggedIn()) {
  //     return false;
  //   }
  //   this.router.navigate(['/register']);
  //   return true;
  // }
}


