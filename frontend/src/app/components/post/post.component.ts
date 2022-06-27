import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

import { UserService } from 'src/app/services/user/user.service';
import { Post } from 'src/app/interfaces/Post';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss'],
})
export class PostComponent implements OnInit {
  constructor(private userService: UserService) {}

  currentUserID!: number;

  @Input() post!: Post;
  @Input() index!: number;

  @Output() votePost = new EventEmitter();
  @Output() updatePost = new EventEmitter();
  @Output() deletePost = new EventEmitter();

  ngOnInit(): void {
    this.currentUserID = this.userService.getCurrentUserID();
  }

  vote(postID: number, vote: boolean, index: number, voted: boolean | null) {
    this.votePost.emit({ postID, vote, index, voted });
  }

  edit(postID: number, form: NgForm) {
    this.updatePost.emit({ postID, form: form.value });
    this.endEditing();
  }

  deleteP(postID: number) {
    this.deletePost.emit(postID);
  }

  startEditing() {
    this.post.isEditing = true;
  }

  endEditing() {
    this.post.isEditing = false;
  }
}
