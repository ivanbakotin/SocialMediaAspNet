import { Component, OnInit } from '@angular/core';

import { GrouprequestsService } from 'src/app/services/grouprequests/grouprequests.service';
import { GroupRequestsSentSharedService } from 'src/app/services/grouprequests/group-requests-sent-shared.service';

@Component({
  selector: 'app-group-requests-sent',
  templateUrl: './group-requests-sent.component.html',
  styleUrls: ['./group-requests-sent.component.scss'],
})
export class GroupRequestsSentComponent implements OnInit {
  constructor(
    private groupService: GrouprequestsService,
    private sharedService: GroupRequestsSentSharedService
  ) {}

  requestsSent: any = [];

  ngOnInit(): void {
    this.getRequestsSent();
    this.sharedService.group.subscribe((group) => (this.requestsSent = group));
  }

  getRequestsSent() {
    this.groupService.getUserGroupRequestsSent().subscribe((response) => {
      this.sharedService.updateGroups(response);
      this.requestsSent = response;
    });
  }
}
