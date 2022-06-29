import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { PostService } from 'src/app/services/post/post.service';

@Component({
  selector: 'app-main-post',
  templateUrl: './main-post.component.html',
  styleUrls: ['./main-post.component.scss'],
})
export class MainPostComponent implements OnInit {
  constructor(
    private postService: PostService,
    private route: ActivatedRoute
  ) {}

  post: any = {};

  ngOnInit(): void {
    this.route.params.subscribe((routeParams) => {
      this.getPost(routeParams['id']);
    });
  }

  getPost(id: number) {
    this.postService.getPost(id).subscribe((response) => {
      console.log(response);
      this.post = response;
    });
  }
}
