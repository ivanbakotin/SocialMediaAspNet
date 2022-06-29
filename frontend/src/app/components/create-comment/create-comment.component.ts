import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

import { CommentService } from 'src/app/services/comment/comment.service';
import { CommentSharedService } from 'src/app/services/comment/commentShared.service';

@Component({
  selector: 'app-create-comment',
  templateUrl: './create-comment.component.html',
  styleUrls: ['./create-comment.component.scss'],
})
export class CreateCommentComponent implements OnInit {
  constructor(
    private sharedService: CommentSharedService,
    private commentService: CommentService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {}

  submitForm(form: NgForm) {
    form.value.postID = this.route.snapshot.params['id'];

    this.commentService.createComment(form.value).subscribe((response) => {
      this.sharedService.addComment(response);
    });
  }
}
