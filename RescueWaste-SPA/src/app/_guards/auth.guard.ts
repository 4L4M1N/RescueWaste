import { Injectable } from '@angular/core';
import { CanActivate, CanDeactivate, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { RegisterComponent } from '../register/register.component';
import { AlertifyService } from '../services/alertify.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService,
              private router: Router,
              private alertify: AlertifyService) { }

  canActivate(next: ActivatedRouteSnapshot): boolean {

    const role = next.data.role;
    if (role) {
      const match = this.authService.roleMatch(role);
      console.log(role);
      if (match) {
        return true;
      } else {
        this.router.navigate(['/home']);
        this.alertify.error('you are not permitted');
      }
    }
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


