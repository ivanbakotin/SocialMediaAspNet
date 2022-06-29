import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { CommentService } from 'src/app/services/comment/comment.service';
import { CommentSharedService } from 'src/app/services/comment/commentShared.service';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.scss'],
})
export class CommentsComponent implements OnInit {
  constructor(
    private commentService: CommentService,
    private route: ActivatedRoute,
    private sharedService: CommentSharedService
  ) {}

  comments: any = [];

  ngOnInit(): void {
    this.sharedService.comment.subscribe(
      (comments) => (this.comments = comments)
    );
    this.route.params.subscribe((routeParams) => {
      this.getComments(routeParams['id']);
    });
  }

  getComments(id: number) {
    this.commentService.getComments(id).subscribe((response) => {
      this.sharedService.updateComments(response);
      this.comments = response;
    });
  }
}
