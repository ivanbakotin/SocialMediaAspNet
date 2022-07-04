import { Component, OnInit } from '@angular/core';

import { FriendService } from 'src/app/services/friend/friend.service';
import { GroupRequestsSentSharedService } from 'src/app/services/grouprequests/group-requests-sent-shared.service';
@Component({
  selector: 'app-friend-requests-sent',
  templateUrl: './friend-requests-sent.component.html',
  styleUrls: ['./friend-requests-sent.component.scss'],
})
export class FriendRequestsSentComponent implements OnInit {
  constructor(
    private friendService: FriendService,
    private sharedService: GroupRequestsSentSharedService
  ) {}

  requestsSent: any = [];

  ngOnInit(): void {
    this.getRequestsSent();
    this.sharedService.group.subscribe((group) => (this.requestsSent = group));
  }

  getRequestsSent() {
    this.friendService.getRequestsSent().subscribe((response) => {
      this.requestsSent = response[0].requests;
    });
  }
}
