import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';

import { UserService } from 'src/app/services/user/user.service';
import { Post } from 'src/app/interfaces/Post';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss'],
})
export class PostComponent implements OnInit {
  constructor(private router: Router, private userService: UserService) {}

  currentUserID!: number;

  @Input() post!: Post;
  @Input() index!: number;

  @Output() votePost = new EventEmitter();
  @Output() updatePost = new EventEmitter();
  @Output() deletePost = new EventEmitter();

  ngOnInit(): void {
    this.currentUserID = this.userService.getCurrentUserID();
    console.log(this.currentUserID);
  }

  vote(postID: number, vote: boolean, index: number, voted: boolean | null) {
    this.votePost.emit({ postID, vote, index, voted });
  }

  seeProfile(id: number) {
    this.router.navigate([`profile/${id}`]);
  }

  seePost(id: number) {
    this.router.navigate([`post/${id}`]);
  }

  edit() {
    this.updatePost.emit(this.post.id);
  }

  deleteP(postID: number) {
    this.deletePost.emit(postID);
  }

  startEditing() {}

  endEditing() {}
}
