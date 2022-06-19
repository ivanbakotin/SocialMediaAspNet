import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

import { LoginUser } from 'src/app/interfaces/LoginUser';
import { RegisterUser } from 'src/app/interfaces/RegisterUser';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient, private router: Router) {}

  public jwtHelper: JwtHelperService = new JwtHelperService();

  public isAuthenticated(): boolean {
    const token = localStorage.getItem('token') || undefined;
    return !this.jwtHelper.isTokenExpired(token);
  }

  loginURL = 'https://localhost:44344/api/Auth/login';
  registerUrl = 'https://localhost:44344/api/Auth/register';

  login(data: LoginUser): Observable<any> {
    return this.http.post(this.loginURL, data);
  }

  register(data: RegisterUser): Observable<any> {
    return this.http.post(this.registerUrl, data);
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/auth']);
  }
}
