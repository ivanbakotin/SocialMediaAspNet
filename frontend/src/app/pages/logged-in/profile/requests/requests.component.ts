import { Component, OnInit } from '@angular/core';

import { FriendService } from 'src/app/services/friend/friend.service';
import { GrouprequestsService } from 'src/app/services/grouprequests/grouprequests.service';

@Component({
  selector: 'app-requests',
  templateUrl: './requests.component.html',
  styleUrls: ['./requests.component.scss'],
})
export class RequestsComponent implements OnInit {
  constructor(
    private friendService: FriendService,
    private groupRequestsService: GrouprequestsService
  ) {}

  requestsPending: any = [];
  requestsSent: any = [];
  requestsPendingGroup: any = [];
  requestsSentGroup: any = [];

  removeRequest(id: number) {
    this.requestsSent = this.requestsSent.filter((f: any) => f.id !== id);
    this.friendService.declineRequest(id);
  }

  declineRequest(id: number) {
    this.requestsPending = this.requestsPending.filter((f: any) => f.id !== id);
    this.friendService.declineRequest(id);
  }

  acceptRequest(id: number) {
    this.requestsPending = this.requestsPending.filter((f: any) => f.id !== id);
    this.friendService.acceptRequest(id);
  }

  ngOnInit(): void {
    this.getRequestsPending();
    this.getRequestsSent();
    this.getRequestsPendingGroup();
    this.getRequestsSentGroup();
  }

  getRequestsPending() {
    this.friendService.getRequestsPending().subscribe((response) => {
      this.requestsPending = response[0].requests;
    });
  }

  getRequestsSent() {
    this.friendService.getRequestsSent().subscribe((response) => {
      this.requestsSent = response[0].requests;
    });
  }

  getRequestsPendingGroup() {
    this.groupRequestsService
      .getUserGroupRequestsPending()
      .subscribe((response) => {
        console.log(response, 'pending');
      });
  }

  getRequestsSentGroup() {
    this.groupRequestsService
      .getUserGroupRequestsSent()
      .subscribe((response) => {
        console.log(response, 'sent');
      });
  }
}
