import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { GetHeader, HOSTNAME } from 'src/app/utils/constants';

@Injectable({
  providedIn: 'root',
})
export class FriendService {
  constructor(private http: HttpClient) {}

  private getRequestsPendingURL = `${HOSTNAME}Friend/requestspending`;
  private getRequestsSentURL = `${HOSTNAME}Friend/requestssent`;
  private getFriendsURL = `${HOSTNAME}Friend/friends/`;
  private sendRequestURL = `${HOSTNAME}Friend/send/`;
  private acceptRequestURL = `${HOSTNAME}Friend/accept/`;
  private declineRequestURL = `${HOSTNAME}Friend/decline/`;
  private removeFriendURL = `${HOSTNAME}Friend/remove/`;

  getRequestsPending(): Observable<any> {
    return this.http.get(this.getRequestsPendingURL, { headers: GetHeader() });
  }

  getRequestsSent(): Observable<any> {
    return this.http.get(this.getRequestsSentURL, { headers: GetHeader() });
  }

  getFriends(id: number): Observable<any> {
    return this.http.get(this.getFriendsURL + id, { headers: GetHeader() });
  }

  sendRequest(id: number): Observable<any> {
    return this.http.post(this.sendRequestURL + id, JSON.stringify(id), {
      headers: GetHeader(),
    });
  }

  acceptRequest(id: number): Observable<any> {
    return this.http.post(this.acceptRequestURL + id, JSON.stringify(id), {
      headers: GetHeader(),
    });
  }

  declineRequest(id: number): Observable<any> {
    return this.http.delete(this.declineRequestURL + id, {
      headers: GetHeader(),
    });
  }

  removeFriend(id: number): Observable<any> {
    return this.http.delete(this.removeFriendURL + id, {
      headers: GetHeader(),
    });
  }
}
