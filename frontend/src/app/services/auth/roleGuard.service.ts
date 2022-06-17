import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot } from '@angular/router';
import { AuthService } from './auth.service';
import decode from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class RoleGuardService implements CanActivate {
  constructor(public auth: AuthService, public router: Router) {}

  canActivate(route: ActivatedRouteSnapshot): boolean {
    const token = localStorage.getItem('token') || '';

    const tokenPayload = decode(token);

    if (!this.auth.isAuthenticated() || (<any>tokenPayload).role !== 'admin') {
      this.router.navigate(['auth']);
      return false;
    }

    this.router.navigate(['']);
    return true;
  }
}
