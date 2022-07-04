import { Component, Input, OnInit } from '@angular/core';
import { FriendService } from 'src/app/services/friend/friend.service';
import { GroupRequestsPendingSharedService } from 'src/app/services/grouprequests/group-requests-pending-shared.service';

@Component({
  selector: 'app-request-pending',
  templateUrl: './request-pending.component.html',
  styleUrls: ['./request-pending.component.scss'],
})
export class RequestPendingComponent implements OnInit {
  constructor(
    private friendService: FriendService,
    private sharedService: GroupRequestsPendingSharedService
  ) {}

  @Input() request!: any;

  ngOnInit(): void {}

  acceptRequest(id: number) {
    this.friendService.acceptRequest(id).subscribe();
    this.sharedService.deleteGroup(id);
  }

  declineRequest(id: number) {
    this.friendService.declineRequest(id).subscribe();
    this.sharedService.deleteGroup(id);
  }
}
