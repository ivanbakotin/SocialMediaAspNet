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
  pageNumber = 1;

  onScrollDown() {
    this.pageNumber++;
    this.getPosts();
  }

  getPosts() {
    this.postService.getPosts(this.pageNumber).subscribe((response) => {
      this.posts.push(...response);
      this.sharedService.updatePosts(this.posts);
    });
  }
}
