import { Component, Input, OnInit } from '@angular/core';
import { GroupRequestsSentSharedService } from 'src/app/services/grouprequests/group-requests-sent-shared.service';
import { GrouprequestsService } from 'src/app/services/grouprequests/grouprequests.service';

@Component({
  selector: 'app-user-group-request-sent',
  templateUrl: './user-group-request-sent.component.html',
  styleUrls: ['./user-group-request-sent.component.scss'],
})
export class UserGroupRequestSentComponent implements OnInit {
  constructor(
    private groupService: GrouprequestsService,
    private sharedService: GroupRequestsSentSharedService
  ) {}

  ngOnInit(): void {}

  @Input() request!: any;

  removeRequest(id: number) {
    this.groupService.declineRequest(id).subscribe();
    this.sharedService.deleteGroup(id);
  }
}
