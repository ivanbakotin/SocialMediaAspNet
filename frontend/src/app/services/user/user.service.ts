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

  private searchUsersURL = `${HOSTNAME}User/search/`;
  private recommendedUsersURL = `${HOSTNAME}User/recommended`;
  private deleteUserURL = `${HOSTNAME}User/delete/`;

  public getCurrentUserID() {
    const token = localStorage.getItem('token') || '';
    const tokenPayload = decode(token);
    return (<any>tokenPayload).ID;
  }

  public searchUsers(param: string): Observable<any> {
    return this.http.get(this.searchUsersURL + param, { headers: GetHeader() });
  }

  public getRecommendedUsers(): Observable<any> {
    return this.http.get(this.recommendedUsersURL, { headers: GetHeader() });
  }

  public deleteUser(): Observable<any> {
    return this.http.delete(this.deleteUserURL, { headers: GetHeader() });
  }
}
