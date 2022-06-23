import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { PostService } from 'src/app/services/post/post.service';

import { Post } from 'src/app/interfaces/Post';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  constructor(private postService: PostService) {}

  ngOnInit(): void {
    //get profile
    //get friends
    this.getPosts();
  }

  posts: Post[] = [];

  createPost($event: any) {
    console.log($event);
    this.postService.createPost($event).subscribe(
      (response) => {
        this.posts.unshift(response);
        console.log(response);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  getPosts() {
    this.postService.getPosts().subscribe(
      (response) => {
        console.log(response);
        this.posts = response;
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
