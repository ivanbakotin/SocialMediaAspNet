import { Component, OnInit } from '@angular/core';
import { GroupRequestsSentSharedService } from 'src/app/services/grouprequests/group-requests-sent-shared.service';
import { GrouprequestsService } from 'src/app/services/grouprequests/grouprequests.service';

@Component({
  selector: 'app-user-group-requests-sent',
  templateUrl: './user-group-requests-sent.component.html',
  styleUrls: ['./user-group-requests-sent.component.scss'],
})
export class UserGroupRequestsSentComponent implements OnInit {
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
