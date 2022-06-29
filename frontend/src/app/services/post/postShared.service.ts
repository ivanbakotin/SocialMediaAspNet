import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

import { Post } from 'src/app/interfaces/Post';

@Injectable({
  providedIn: 'root',
})
export class PostSharedService {
  constructor() {}

  private postSource = new BehaviorSubject<Post[]>([]);
  post = this.postSource.asObservable();

  updatePosts(post: Post[]) {
    this.postSource.next([...post]);
  }

  addPost(post: Post) {
    this.postSource.next([post, ...this.postSource.getValue()]);
  }

  deletePost(id: number) {
    this.postSource.next(this.postSource.getValue().filter((f) => f.id !== id));
  }
}
