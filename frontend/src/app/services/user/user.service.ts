import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { header } from 'src/app/utils/constants';
import { HOSTNAME } from 'src/app/utils/constants';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}

  private searchUsersURL = `${HOSTNAME}User/search/`;

  public searchUsers(param: string): Observable<any> {
    return this.http.get(this.searchUsersURL + param, header);
  }
}
