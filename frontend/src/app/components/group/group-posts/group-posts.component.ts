import { Component, OnInit } from '@angular/core';

import { GroupService } from 'src/app/services/group/group.service';

@Component({
  selector: 'app-group-posts',
  templateUrl: './group-posts.component.html',
  styleUrls: ['./group-posts.component.scss'],
})
export class GroupPostsComponent implements OnInit {
  constructor(private groupService: GroupService) {}

  posts!: any;

  ngOnInit(): void {
    //this.groupService.getGroupPosts().subscribe()
  }
}
