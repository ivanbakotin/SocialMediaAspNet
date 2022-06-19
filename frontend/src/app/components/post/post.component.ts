import { Component, Input, OnInit } from '@angular/core';

import { Post } from 'src/app/interfaces/Post';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss'],
})
export class PostComponent implements OnInit {
  constructor() {}

  @Input() post: Post | any = {};

  ngOnInit(): void {
    console.log(this.post);
  }
}
