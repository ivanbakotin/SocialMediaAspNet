import { Component, Input, OnInit } from '@angular/core';
import { Post } from 'src/interfaces/Post';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.scss'],
})
export class PostsComponent implements OnInit {
  constructor() {}

  @Input() posts: Post[] = [];

  ngOnInit(): void {}
}
