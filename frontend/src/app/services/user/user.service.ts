import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import decode from 'jwt-decode';

import { HOSTNAME, GetHeader } from 'src/app/utils/constants';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}

  private getCurrentUsernameURL = `${HOSTNAME}User/current`;
  private searchUsersURL = `${HOSTNAME}User/search/`;
  private recommendedUsersURL = `${HOSTNAME}User/recommended`;
  private deleteUserURL = `${HOSTNAME}User/delete/`;
  private changePasswordURL = `${HOSTNAME}User/changepassword/`;
  private changeEmailURL = `${HOSTNAME}User/changeemail/`;

  public getCurrentUserID() {
    const token = localStorage.getItem('token') || '';
    const tokenPayload = decode(token);
    return (<any>tokenPayload).ID;
  }

  public getCurrentUsername(): Observable<any> {
    return this.http.get(this.getCurrentUsernameURL, { headers: GetHeader() });
  }

  public searchUsers(param: string): Observable<any> {
    return this.http.get(this.searchUsersURL + param, { headers: GetHeader() });
  }

  public getRecommendedUsers(): Observable<any> {
    return this.http.get(this.recommendedUsersURL, { headers: GetHeader() });
  }

  public changePassword(body: any): Observable<any> {
    return this.http.put(this.changePasswordURL, body, {
      headers: GetHeader(),
    });
  }

  public changeEmail(body: any): Observable<any> {
    return this.http.put(this.changeEmailURL, body, {
      headers: GetHeader(),
    });
  }

  public deleteUser(body: any): Observable<any> {
    return this.http.delete(this.deleteUserURL, {
      headers: GetHeader(),
      body,
    });
  }
}
