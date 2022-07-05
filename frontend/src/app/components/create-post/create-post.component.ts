import { Component, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

import { PostSharedService } from 'src/app/services/post/postShared.service';
import { PostService } from 'src/app/services/post/post.service';

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.scss'],
})
export class CreatePostComponent implements OnInit {
  constructor(
    private sharedService: PostSharedService,
    private postService: PostService
  ) {}

  @Input() groupID: number | null = null;

  ngOnInit(): void {}

  submitForm(form: NgForm) {
    form.value.groupID = this.groupID;
    this.postService.createPost(form.value).subscribe((response) => {
      form.reset();
      this.sharedService.addPost(response);
    });
  }
}
