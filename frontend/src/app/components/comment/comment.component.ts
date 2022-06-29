import { Component, OnInit, Input } from '@angular/core';

import { CommentService } from 'src/app/services/comment/comment.service';
import { UserService } from 'src/app/services/user/user.service';
import { Comment } from 'src/app/interfaces/Comment';
import { updateVote } from 'src/app/utils/updateVote';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.scss'],
})
export class CommentComponent implements OnInit {
  constructor(
    private commentService: CommentService,
    private userService: UserService
  ) {}

  @Input() index!: number;
  @Input() comment!: Comment;
  currentUserID: number = 1;

  ngOnInit(): void {
    this.currentUserID = this.userService.getCurrentUserID();
  }

  vote(id: number, vote: boolean) {
    this.commentService.voteComment(id, vote).subscribe(
      () => {
        updateVote(this.comment, vote);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  update(id: number, body: any) {
    this.endEditing();
    this.comment.body = body.value.body;
    this.commentService.updateComment(id, body.value).subscribe(
      () => {},
      (error) => {
        console.error(error);
      }
    );
  }

  delete(id: number) {
    this.commentService.deleteComment(id).subscribe(
      () => {},
      (error) => {
        console.error(error);
      }
    );
  }

  startEditing() {
    this.comment.isEditing = true;
  }

  endEditing() {
    this.comment.isEditing = false;
  }
}
