import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

import { Post } from 'src/app/interfaces/Post';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss'],
})
export class PostComponent implements OnInit {
  constructor() {}

  @Input() post: Post | any = {};
  @Input() index: number = 1;

  @Output() votePost = new EventEmitter();
  @Output() seePost = new EventEmitter();
  @Output() seeProfile = new EventEmitter();
  @Output() updatePost = new EventEmitter();
  @Output() deletePost = new EventEmitter();

  ngOnInit(): void {}

  vote(postID: number, vote: boolean, index: number) {
    this.votePost.emit({ postID, vote, index });
  }

  see() {
    this.seePost.emit(this.post.id);
  }

  get() {
    this.seeProfile.emit(this.post.userID);
  }

  edit() {
    this.updatePost.emit(this.post.id);
  }

  delete() {
    this.deletePost.emit(this.post.id);
  }

  startEditing() {}

  endEditing() {}
}
