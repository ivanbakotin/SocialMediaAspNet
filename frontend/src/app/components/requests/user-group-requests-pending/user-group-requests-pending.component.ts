import { Component, OnInit } from '@angular/core';
import { GroupRequestsPendingSharedService } from 'src/app/services/grouprequests/group-requests-pending-shared.service';
import { GrouprequestsService } from 'src/app/services/grouprequests/grouprequests.service';

@Component({
  selector: 'app-user-group-requests-pending',
  templateUrl: './user-group-requests-pending.component.html',
  styleUrls: ['./user-group-requests-pending.component.scss'],
})
export class UserGroupRequestsPendingComponent implements OnInit {
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
