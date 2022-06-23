import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { header } from 'src/app/utils/constants';
import { HOSTNAME } from 'src/app/utils/constants';
import { Post } from 'src/app/interfaces/Post';

@Injectable({
  providedIn: 'root',
})
export class PostService {
  constructor(private http: HttpClient) {}

  private getPostsURL = `${HOSTNAME}Post`;
  private getPostURL = `${HOSTNAME}Post/`;
  private createPostURL = `${HOSTNAME}Post/`;
  private updatePostURL = `${HOSTNAME}Post/update/`;
  private deletePostURL = `${HOSTNAME}Post/delete/`;
  private votePostURL = `${HOSTNAME}Post/vote/`;

  public getPosts(): Observable<any> {
    return this.http.get(this.getPostsURL, header);
  }

  public getPost(id: number): Observable<any> {
    return this.http.get(this.getPostURL + id, header);
  }

  public createPost(body: Post): Observable<any> {
    return this.http.post(this.getPostURL, body, header);
  }

  public updatePost(id: number): Observable<any> {
    return this.http.put(this.updatePostURL + id, header);
  }

  public deletePost(id: number): Observable<any> {
    return this.http.delete(this.deletePostURL + id, header);
  }

  public votePost(id: number): Observable<any> {
    return this.http.post(this.votePostURL + id, header);
  }
}
