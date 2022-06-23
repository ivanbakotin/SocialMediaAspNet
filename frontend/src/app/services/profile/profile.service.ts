import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { HOSTNAME } from 'src/app/utils/constants';
import { header } from 'src/app/utils/constants';

@Injectable({
  providedIn: 'root',
})
export class ProfileService {
  constructor(private http: HttpClient) {}

  getProfileURL = `${HOSTNAME}Profile/`;
  updateProfileURL = `${HOSTNAME}Profile/update`;

  public getProfile(id: number): Observable<any> {
    return this.http.get(this.getProfileURL + id, header);
  }

  public updateProfile(body: any) {
    return this.http.put(this.updateProfileURL, body, header);
  }
}
