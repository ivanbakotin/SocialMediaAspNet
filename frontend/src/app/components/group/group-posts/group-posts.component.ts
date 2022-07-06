import { Component, OnInit } from '@angular/core';

import { GroupService } from 'src/app/services/group/group.service';
import { PostSharedService } from 'src/app/services/post/postShared.service';
import { GroupSharedService } from 'src/app/services/group/group-shared.service';

@Component({
  selector: 'app-group-posts',
  templateUrl: './group-posts.component.html',
  styleUrls: ['./group-posts.component.scss'],
})
export class GroupPostsComponent implements OnInit {
  constructor(
    private sharedService: PostSharedService,
    private groupService: GroupService,
    private groupSharedService: GroupSharedService
  ) {}

  posts: any = [];
  groupID!: number;

  ngOnInit(): void {
    this.groupSharedService.groupID.subscribe((id) => (this.groupID = id));
    this.sharedService.post.subscribe((posts) => (this.posts = posts));

    this.groupService.getGroupPosts(this.groupID).subscribe((response) => {
      this.posts = response;
      this.sharedService.updatePosts(response);
    });
  }
}
