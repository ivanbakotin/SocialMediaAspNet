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
  private voteCommentURL = `${HOSTNAME}Comment/vote/`;
  private updateCommentURL = `${HOSTNAME}Comment/update/`;
  private deleteCommentURL = `${HOSTNAME}Comment/delete/`;
  private createCommentURL = `${HOSTNAME}Comment`;

  getComments(id: number): Observable<any> {
    return this.http.get(this.getCommentsURL + id, { headers: GetHeader() });
  }

  voteComment(id: number): Observable<any> {
    return this.http.post(this.voteCommentURL + id, { headers: GetHeader() });
  }

  updateComment(id: number, body: any): Observable<any> {
    return this.http.put(this.updateCommentURL + id, body, {
      headers: GetHeader(),
    });
  }

  deleteComment(id: number): Observable<any> {
    return this.http.delete(this.deleteCommentURL + id, {
      headers: GetHeader(),
    });
  }

  createComment(id: number, body: any): Observable<any> {
    return this.http.post(this.createCommentURL + id, body, {
      headers: GetHeader(),
    });
  }
}
