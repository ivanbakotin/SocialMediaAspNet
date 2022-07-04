import { Component, OnInit } from '@angular/core';

import { GrouprequestsService } from 'src/app/services/grouprequests/grouprequests.service';
import { GroupRequestsPendingSharedService } from 'src/app/services/grouprequests/group-requests-pending-shared.service';

@Component({
  selector: 'app-group-requests-pending',
  templateUrl: './group-requests-pending.component.html',
  styleUrls: ['./group-requests-pending.component.scss'],
})
export class GroupRequestsPendingComponent implements OnInit {
  constructor(
    private groupService: GrouprequestsService,
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
    this.groupService.getUserGroupRequestsPending().subscribe((response) => {
      this.sharedService.updateGroups(response);
      this.requestsPending = response;
    });
  }
}
