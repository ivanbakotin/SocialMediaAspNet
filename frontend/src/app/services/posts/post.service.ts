import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { header } from 'src/app/utils/constants';
import { HOSTNAME } from 'src/app/utils/constants';

@Injectable({
  providedIn: 'root',
})
export class PostService {
  constructor(private http: HttpClient) {}

  private getPostsURL = `${HOSTNAME}Post`;
  private getPostURL = `${HOSTNAME}Post/`;
  private updatePostURL = `${HOSTNAME}Post/update/`;
  private deletePostURL = `${HOSTNAME}Post/delete/`;
  private upvotePostURL = `${HOSTNAME}Post/upvote/`;
  private downvotePostURL = `${HOSTNAME}Post/downvote/`;

  public getPosts(): Observable<any> {
    return this.http.get(this.getPostsURL, header);
  }

  public getPost(id: number): Observable<any> {
    return this.http.get(this.getPostURL + id, header);
  }

  public updatePost(id: number): Observable<any> {
    return this.http.get(this.updatePostURL + id, header);
  }

  public deletePost(id: number): Observable<any> {
    return this.http.get(this.deletePostURL + id, header);
  }

  public upvote(id: number): Observable<any> {
    return this.http.get(this.upvotePostURL + id, header);
  }

  public downvote(id: number): Observable<any> {
    return this.http.get(this.downvotePostURL + id, header);
  }
}
