import { Component, Input, OnInit } from '@angular/core';

import { GroupRequestsSentSharedService } from 'src/app/services/grouprequests/group-requests-sent-shared.service';
import { GrouprequestsService } from 'src/app/services/grouprequests/grouprequests.service';

@Component({
  selector: 'app-group-request-pending',
  templateUrl: './group-request-pending.component.html',
  styleUrls: ['./group-request-pending.component.scss'],
})
export class GroupRequestPendingComponent implements OnInit {
  constructor(
    private groupService: GrouprequestsService,
    private sharedService: GroupRequestsSentSharedService
  ) {}

  ngOnInit(): void {}

  @Input() request!: any;

  acceptRequest(id: number) {
    this.groupService.acceptRequest(id).subscribe();
    this.sharedService.deleteGroup(id);
  }

  declineRequest(id: number) {
    this.groupService.declineRequest(id).subscribe();
    this.sharedService.deleteGroup(id);
  }
}
