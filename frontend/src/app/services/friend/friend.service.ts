import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { GetHeader, HOSTNAME } from 'src/app/utils/constants';

@Injectable({
  providedIn: 'root',
})
export class FriendService {
  constructor(private http: HttpClient) {}

  sendRequestURL = '';
  declineRequestURL = '';
  acceptRequestURL = '';
  removeFriendURL = '';

  sendRequest() {}

  declineRequest() {}

  acceptRequest() {}

  removeFriend() {}
}
