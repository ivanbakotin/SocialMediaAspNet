import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { GetHeader } from 'src/app/utils/constants';
import { HOSTNAME } from 'src/app/utils/constants';

@Injectable({
  providedIn: 'root',
})
export class GrouprequestsService {
  constructor(private http: HttpClient) {}

  private inviteToGroupURL = `${HOSTNAME}GroupRequests/invite/`;
  private getGroupRequestsSentURL = `${HOSTNAME}GroupRequests/requestssent/`;
  private getGroupRequestsPendingURL = `${HOSTNAME}GroupRequests/requestspending/`;
  private getUserGroupRequestsSentURL = `${HOSTNAME}GroupRequests/userrequestssent`;
  private getUserGroupRequestsPendingURL = `${HOSTNAME}GroupRequests/userrequestspending`;

  private acceptRequestURL = `${HOSTNAME}GroupRequests/accept/`;
  private declineRequestURL = `${HOSTNAME}GroupRequests/decline/`;

  public inviteToGroup(GroupID: number, userID: number): Observable<any> {
    return this.http.post(
      this.inviteToGroupURL + GroupID,
      JSON.stringify(userID),
      {
        headers: GetHeader(),
      }
    );
  }

  public acceptRequest(id: number): Observable<any> {
    return this.http.post(
      this.acceptRequestURL + id,
      {},
      {
        headers: GetHeader(),
      }
    );
  }

  public declineRequest(id: number): Observable<any> {
    return this.http.delete(this.declineRequestURL + id, {
      headers: GetHeader(),
    });
  }

  public getGroupRequestsPending(id: number): Observable<any> {
    return this.http.get(this.getGroupRequestsPendingURL + id, {
      headers: GetHeader(),
    });
  }

  public getGroupRequestsSent(id: number): Observable<any> {
    return this.http.get(this.getGroupRequestsPendingURL + id, {
      headers: GetHeader(),
    });
  }

  public getUserGroupRequestsSent(): Observable<any> {
    return this.http.get(this.getUserGroupRequestsSentURL, {
      headers: GetHeader(),
    });
  }

  public getUserGroupRequestsPending(): Observable<any> {
    return this.http.get(this.getUserGroupRequestsPendingURL, {
      headers: GetHeader(),
    });
  }
}
