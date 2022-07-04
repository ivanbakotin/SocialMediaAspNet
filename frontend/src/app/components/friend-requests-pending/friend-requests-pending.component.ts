import { Component, OnInit } from '@angular/core';

import { FriendService } from 'src/app/services/friend/friend.service';
import { GroupRequestsPendingSharedService } from 'src/app/services/grouprequests/group-requests-pending-shared.service';

@Component({
  selector: 'app-friend-requests-pending',
  templateUrl: './friend-requests-pending.component.html',
  styleUrls: ['./friend-requests-pending.component.scss'],
})
export class FriendRequestsPendingComponent implements OnInit {
  constructor(
    private friendService: FriendService,
    private sharedService: GroupRequestsPendingSharedService
  ) {}

  requestsPending: any = [];

  ngOnInit(): void {
    this.getRequestsPending();
    this.sharedService.group.subscribe(
      (group) => (this.requestsPending = group)
    );
  }

  getRequestsPending() {
    this.friendService.getRequestsPending().subscribe((response) => {
      this.sharedService.updateGroups(response[0].requests);
      this.requestsPending = response[0].requests;
    });
  }
}
