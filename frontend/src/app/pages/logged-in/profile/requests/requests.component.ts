import { Component, OnInit } from '@angular/core';

import { FriendService } from 'src/app/services/friend/friend.service';

@Component({
  selector: 'app-requests',
  templateUrl: './requests.component.html',
  styleUrls: ['./requests.component.scss'],
})
export class RequestsComponent implements OnInit {
  constructor(private friendService: FriendService) {}

  requestsPending: any = [];
  requestsSent: any = [];

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
}
