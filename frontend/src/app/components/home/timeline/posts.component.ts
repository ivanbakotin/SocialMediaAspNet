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

  pageNumber = 1;

  onScrollDown() {
    this.pageNumber++;
    this.getPosts();
    console.log('scrolled down!!');
  }

  ngOnInit(): void {
    this.getPosts();
    this.sharedService.post.subscribe((posts) => (this.posts = posts));
  }

  posts: Post[] = [];

  getPosts() {
    this.postService.getPosts(this.pageNumber).subscribe((response) => {
      this.posts.push(...response);
      console.log(response, this.posts);
      this.sharedService.updatePosts(this.posts);
    });
  }
}
