import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

import { Comment } from 'src/app/interfaces/Comment';

@Injectable({
  providedIn: 'root',
})
export class CommentSharedService {
  constructor() {}

  private commentSource = new BehaviorSubject<Comment[]>([]);
  comment = this.commentSource.asObservable();

  updateComments(comment: Comment[]) {
    this.commentSource.next([...comment]);
  }

  addComment(comment: Comment) {
    this.commentSource.next([comment, ...this.commentSource.getValue()]);
  }

  deleteComment(id: number) {
    this.commentSource.next(
      this.commentSource.getValue().filter((f) => f.id !== id)
    );
  }
}
