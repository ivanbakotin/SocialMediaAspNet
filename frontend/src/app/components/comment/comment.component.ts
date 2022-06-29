import { Component, OnInit, Input } from '@angular/core';

import { CommentService } from 'src/app/services/comment/comment.service';
import { UserService } from 'src/app/services/user/user.service';
import { Comment } from 'src/app/interfaces/Comment';
import { updateVote } from 'src/app/utils/updateVote';
import { CommentSharedService } from 'src/app/services/comment/commentShared.service';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.scss'],
})
export class CommentComponent implements OnInit {
  constructor(
    private commentService: CommentService,
    private userService: UserService,
    private sharedService: CommentSharedService
  ) {}

  @Input() comment!: Comment;
  currentUserID!: number;

  ngOnInit(): void {
    this.currentUserID = this.userService.getCurrentUserID();
  }

  vote(vote: boolean) {
    this.commentService.voteComment(this.comment.id, vote).subscribe(
      () => {
        updateVote(this.comment, vote);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  update(body: any) {
    this.endEditing();
    this.comment.body = body.value.body;
    this.commentService.updateComment(this.comment.id, body.value).subscribe(
      () => {},
      (error) => {
        console.error(error);
      }
    );
  }

  delete() {
    this.sharedService.deleteComment(this.comment.id);
    this.commentService.deleteComment(this.comment.id).subscribe(
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
