import { Component, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

import { UserService } from 'src/app/services/user/user.service';
import { PostService } from 'src/app/services/post/post.service';
import { PostSharedService } from 'src/app/services/post/postShared.service';
import { Post } from 'src/app/interfaces/Post';
import { updateVote } from 'src/app/utils/updateVote';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss'],
})
export class PostComponent implements OnInit {
  constructor(
    private userService: UserService,
    private postService: PostService,
    private sharedService: PostSharedService
  ) {}

  @Input() post!: Post;
  currentUserID!: number;

  ngOnInit(): void {
    this.currentUserID = this.userService.getCurrentUserID();
  }

  vote(vote: boolean) {
    this.postService.votePost(this.post.id, vote).subscribe(
      (response) => {
        updateVote(this.post, vote);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  edit(form: NgForm) {
    this.endEditing();
    this.post.body = form.value.body;
    this.postService.updatePost(this.post.id, form.value.body).subscribe(
      () => {},
      (error) => {
        console.error(error);
      }
    );
  }

  delete() {
    this.sharedService.deletePost(this.post.id);
    this.postService.deletePost(this.post.id).subscribe(
      () => {},
      (error) => {
        console.error(error);
      }
    );
  }

  startEditing() {
    this.post.isEditing = true;
  }

  endEditing() {
    this.post.isEditing = false;
  }
}
