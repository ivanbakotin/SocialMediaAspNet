import { Component, OnInit } from '@angular/core';

import { Post } from 'src/app/interfaces/Post';
import { PostService } from 'src/app/services/post/post.service';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.scss'],
})
export class PostsComponent implements OnInit {
  constructor(private postService: PostService) {}

  ngOnInit(): void {
    this.getPosts();
  }

  posts: Post[] = [];

  seePost($event: any) {
    //navigate to post page
  }

  seeProfile($event: any) {
    //navigate to profile page
  }

  vote($event: any) {
    this.postService.votePost($event.postID, $event.vote).subscribe(
      () => {
        // did i upvote and what did i upvote
      },
      (error) => {
        console.error(error);
      }
    );
  }

  updatePost($event: any) {
    this.postService.updatePost($event.postID).subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  deletePost($event: any) {
    this.postService.deletePost($event.postID).subscribe(
      (response) => {
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

  createPost($event: any) {
    this.postService.createPost($event).subscribe(
      (response) => {
        console.log(response);
        this.posts.unshift(response);
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
