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

  vote($event: any) {
    this.postService.votePost($event.postID, $event.vote).subscribe(
      (response) => {
        this.posts[$event.index] = response;

        /* const currVote = this.posts[$event.index].votes;

        if ($event.voted != null) {
          if ($event.voted) {
            this.posts[$event.index].voted = $event.vote ? null : false;
            this.posts[$event.index].votes = currVote - ($event.vote ? 1 : 2);
          } else {
            this.posts[$event.index].voted = $event.vote ? true : null;
            this.posts[$event.index].votes = currVote + ($event.vote ? 2 : 1);
          }
        } else {
          this.posts[$event.index].voted = $event.vote;
          this.posts[$event.index].votes = currVote + ($event.vote ? 1 : -1);
        } */
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
    console.log($event);
    this.postService.deletePost($event).subscribe(
      () => {
        this.posts = this.posts.filter((post) => post.id != $event);
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
