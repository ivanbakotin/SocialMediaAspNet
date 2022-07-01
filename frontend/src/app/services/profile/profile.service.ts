import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { GetHeader, HOSTNAME } from 'src/app/utils/constants';

@Injectable({
  providedIn: 'root',
})
export class ProfileService {
  constructor(private http: HttpClient) {}

  getProfileURL = `${HOSTNAME}Profile/`;
  updateProfileURL = `${HOSTNAME}Profile`;

  public getProfile(id: string | number | null): Observable<any> {
    return this.http.get(this.getProfileURL + id, { headers: GetHeader() });
  }

  public updateProfile(body: any) {
    return this.http.put(this.updateProfileURL, body, { headers: GetHeader() });
  }
}
