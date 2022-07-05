import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { GroupService } from 'src/app/services/group/group.service';
import { PostSharedService } from 'src/app/services/post/postShared.service';

@Component({
  selector: 'app-group-posts',
  templateUrl: './group-posts.component.html',
  styleUrls: ['./group-posts.component.scss'],
})
export class GroupPostsComponent implements OnInit {
  constructor(
    private sharedService: PostSharedService,
    private groupService: GroupService,
    private route: ActivatedRoute
  ) {}

  posts: any = [];
  @Input() groupID!: number;

  ngOnInit(): void {
    this.sharedService.post.subscribe((posts) => (this.posts = posts));

    this.route.params.subscribe((routeParams) => {
      this.groupService
        .getGroupPosts(routeParams['id'])
        .subscribe((response) => {
          console.log(response);
          this.posts = response;
          this.sharedService.updatePosts(response);
        });
    });
  }
}
