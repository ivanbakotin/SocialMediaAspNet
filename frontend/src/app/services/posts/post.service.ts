import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { header } from 'src/app/utils/constants';

@Injectable({
  providedIn: 'root',
})
export class PostService {
  constructor(private http: HttpClient) {}

  private getPostsUrl = 'https://localhost:44344/api/Post/posts';

  public getPosts(): Observable<any> {
    return this.http.get(this.getPostsUrl, header);
  }
}
