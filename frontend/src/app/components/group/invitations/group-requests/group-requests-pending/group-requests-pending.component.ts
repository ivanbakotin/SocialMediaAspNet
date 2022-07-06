import { Component, OnInit } from '@angular/core';

import { GrouprequestsService } from 'src/app/services/grouprequests/grouprequests.service';
import { GroupRequestsPendingSharedService } from 'src/app/services/grouprequests/group-requests-pending-shared.service';
import { GroupSharedService } from 'src/app/services/group/group-shared.service';

@Component({
  selector: 'app-group-requests-pending',
  templateUrl: './group-requests-pending.component.html',
  styleUrls: ['./group-requests-pending.component.scss'],
})
export class GroupRequestsPendingComponent implements OnInit {
  constructor(
    private groupService: GrouprequestsService,
    private sharedService: GroupRequestsPendingSharedService,
    private groupSharedService: GroupSharedService
  ) {}

  requestsPending: any = [];
  groupID!: number;

  ngOnInit(): void {
    this.groupSharedService.groupID.subscribe((id) => (this.groupID = id));
    this.getRequestsPending();
    this.sharedService.group.subscribe(
      (group) => (this.requestsPending = group)
    );
  }

  getRequestsPending() {
    this.groupService
      .getGroupRequestsPending(this.groupID)
      .subscribe((response) => {
        this.sharedService.updateGroups(response);
        this.requestsPending = response;
      });
  }
}
