import { Component, OnInit } from '@angular/core';

import { PostService } from 'src/app/services/post/post.service';
import { SharedService } from 'src/app/services/profile/shared.service';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.scss'],
})
export class OverviewComponent implements OnInit {
  constructor(
    private postService: PostService,
    private sharedService: SharedService
  ) {}

  posts: any = [];
  id!: number;

  ngOnInit(): void {
    this.sharedService.userID.subscribe((id) => (this.id = id));
    this.getUserPosts();
  }

  getUserPosts() {
    this.postService.getUserPosts(this.id).subscribe(
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
