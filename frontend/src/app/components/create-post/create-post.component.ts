import { Component, OnInit } from '@angular/core';
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

  ngOnInit(): void {}

  submitForm(form: NgForm) {
    const body = {
      title: form.value.title,
      body: form.value.body,
    };

    this.postService.createPost(body).subscribe(
      (response) => {
        this.sharedService.addPost(response);
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
