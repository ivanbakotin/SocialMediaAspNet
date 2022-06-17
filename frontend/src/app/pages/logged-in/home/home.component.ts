import { Component, OnInit } from '@angular/core';
import { PostService } from 'src/app/services/posts/post.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  constructor(private postService: PostService) {}

  ngOnInit(): void {
    this.getPosts();
  }

  posts = [];

  getPosts() {
    this.postService.getPosts().subscribe(
      (response) => {
        this.posts = response;
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
