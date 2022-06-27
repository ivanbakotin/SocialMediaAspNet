import { Component, OnInit } from '@angular/core';

import { PostService } from 'src/app/services/post/post.service';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.scss'],
})
export class OverviewComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {
    console.log('heloo');
  }
}
