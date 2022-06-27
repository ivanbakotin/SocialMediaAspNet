import { Component, OnInit } from '@angular/core';

import { PostService } from 'src/app/services/post/post.service';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.scss'],
})
export class OverviewComponent implements OnInit {
  constructor(private postService: PostService) {}

  posts: any = [];

  ngOnInit(): void {
    this.postService.getUserPosts(1).subscribe(
      (response) => {
        this.posts = response;
        console.log(response);
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
