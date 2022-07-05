import { Component, Input, OnInit } from '@angular/core';

import { UserService } from 'src/app/services/user/user.service';
import { GrouprequestsService } from 'src/app/services/grouprequests/grouprequests.service';
@Component({
  selector: 'app-group-invite',
  templateUrl: './group-invite.component.html',
  styleUrls: ['./group-invite.component.scss'],
})
export class GroupInviteComponent implements OnInit {
  constructor(
    private userService: UserService,
    private grouprequestsService: GrouprequestsService
  ) {}

  ngOnInit(): void {}

  @Input() groupID!: number;

  searchResults: any[] = [];

  inviteToGroup(userID: number) {
    this.grouprequestsService.inviteToGroup(this.groupID, userID).subscribe();
  }

  searchUsers(param: string) {
    if (param) {
      this.userService.searchUsers(param).subscribe((response: any) => {
        this.searchResults = response;
      });
    } else {
      this.searchResults = [];
    }
  }
}
