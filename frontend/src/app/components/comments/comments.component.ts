import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { CommentService } from 'src/app/services/comment/comment.service';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.scss'],
})
export class CommentsComponent implements OnInit {
  constructor(
    private commentService: CommentService,
    private route: ActivatedRoute
  ) {}

  comments: any = [];

  ngOnInit(): void {
    this.route.params.subscribe((routeParams) => {
      this.getComments(routeParams['id']);
    });
  }

  getComments(id: number) {
    this.commentService.getComments(id).subscribe((response) => {
      console.log(response);
      this.comments = response;
    });
  }
}
