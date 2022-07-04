import { Component, Input, OnInit } from '@angular/core';
import { FriendService } from 'src/app/services/friend/friend.service';

import { GroupRequestsSentSharedService } from 'src/app/services/grouprequests/group-requests-sent-shared.service';

@Component({
  selector: 'app-request-sent',
  templateUrl: './request-sent.component.html',
  styleUrls: ['./request-sent.component.scss'],
})
export class RequestSentComponent implements OnInit {
  constructor(
    private friendService: FriendService,
    private sharedService: GroupRequestsSentSharedService
  ) {}

  ngOnInit(): void {}

  @Input() request!: any;

  removeRequest(id: number) {
    this.friendService.declineRequest(id).subscribe();
    this.sharedService.deleteGroup(id);
  }
}
