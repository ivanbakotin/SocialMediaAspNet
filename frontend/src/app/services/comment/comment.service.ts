import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { HOSTNAME, GetHeader } from 'src/app/utils/constants';

@Injectable({
  providedIn: 'root',
})
export class CommentService {
  constructor(private http: HttpClient) {}

  private getCommentsURL = `${HOSTNAME}Comment/`;

  getComments(id: number): Observable<any> {
    return this.http.get(this.getCommentsURL + id, { headers: GetHeader() });
  }
}
