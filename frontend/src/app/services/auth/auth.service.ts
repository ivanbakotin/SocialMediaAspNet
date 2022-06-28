import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { GetJSONHeader } from 'src/app/utils/constants';
import { LoginUser } from 'src/app/interfaces/LoginUser';
import { RegisterUser } from 'src/app/interfaces/RegisterUser';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient) {}

  public jwtHelper: JwtHelperService = new JwtHelperService();

  public isAuthenticated(): boolean {
    const token = localStorage.getItem('token') || undefined;
    return !this.jwtHelper.isTokenExpired(token);
  }

  loginURL = 'https://localhost:44344/api/Auth/login';
  registerUrl = 'https://localhost:44344/api/Auth/register';
  isLoggedInURL = 'https://localhost:44344/api/Auth/isloggedin';
  logoutURL = 'https://localhost:44344/api/Auth/logout';

  login(data: LoginUser): Observable<any> {
    return this.http.post(this.loginURL, data);
  }

  register(data: RegisterUser): Observable<any> {
    return this.http.post(this.registerUrl, data);
  }

  isLoggedIn(): Observable<any> {
    return this.http.post(
      this.isLoggedInURL,
      JSON.stringify(localStorage.getItem('token')),
      {
        headers: GetJSONHeader(),
      }
    );
  }

  logout() {
    localStorage.removeItem('token');
    return this.http.delete(this.logoutURL);
  }
}
