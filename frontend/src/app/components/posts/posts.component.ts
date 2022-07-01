import { Component, OnInit } from '@angular/core';

import { Post } from 'src/app/interfaces/Post';
import { PostService } from 'src/app/services/post/post.service';
import { PostSharedService } from 'src/app/services/post/postShared.service';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.scss'],
})
export class PostsComponent implements OnInit {
  constructor(
    private postService: PostService,
    private sharedService: PostSharedService
  ) {}

  ngOnInit(): void {
    this.getPosts();
    this.sharedService.post.subscribe((posts) => (this.posts = posts));
  }

  posts: Post[] = [];

  getPosts() {
    this.postService.getPosts().subscribe((response) => {
      this.posts = response;
      this.sharedService.updatePosts(response);
    });
  }
}
