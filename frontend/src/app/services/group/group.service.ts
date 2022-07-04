import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { GetHeader } from 'src/app/utils/constants';
import { HOSTNAME } from 'src/app/utils/constants';

@Injectable({
  providedIn: 'root',
})
export class GroupService {
  constructor(private http: HttpClient) {}

  private getGroupInfoURL = `${HOSTNAME}Group/info/`;
  private getGroupPostsURL = `${HOSTNAME}Group/posts/`;
  private createGroupURL = `${HOSTNAME}Group/create`;
  private getUserGroupsURL = `${HOSTNAME}Group/getusergroups`;
  private deleteGroupURL = `${HOSTNAME}Group/`;

  public getGroupInfo(id: number): Observable<any> {
    return this.http.post(this.getGroupInfoURL + id, { headers: GetHeader() });
  }

  public getGroupPosts(id: number): Observable<any> {
    return this.http.post(this.getGroupPostsURL + id, { headers: GetHeader() });
  }

  public createGroup(body: any): Observable<any> {
    return this.http.post(this.createGroupURL, body, { headers: GetHeader() });
  }

  public getUserGroup(): Observable<any> {
    return this.http.get(this.getUserGroupsURL, { headers: GetHeader() });
  }

  public deleteGroup(id: number): Observable<any> {
    return this.http.delete(this.deleteGroupURL + id, { headers: GetHeader() });
  }
}
