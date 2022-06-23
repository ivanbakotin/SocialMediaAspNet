import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { PostService } from 'src/app/services/post/post.service';

import { Post } from 'src/app/interfaces/Post';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {
    //get profile
    //get friends
  }
}
