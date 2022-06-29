import { Component, OnInit } from '@angular/core';

import { FriendService } from 'src/app/services/friend/friend.service';
import { SharedService } from 'src/app/services/profile/shared.service';

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
    console.log();
  }

  declineRequest(id: number) {
    console.log();
  }

  acceptRequest(id: number) {
    console.log();
  }

  ngOnInit(): void {
    this.getRequestsPending();
    this.getRequestsSent();
  }

  getRequestsPending() {
    this.friendService.getRequestsPending().subscribe(
      (response) => {
        this.requestsPending = response[0].requests;
      },
      (error) => console.log(error)
    );
  }

  getRequestsSent() {
    this.friendService.getRequestsSent().subscribe(
      (response) => {
        this.requestsSent = response[0].requests;
      },
      (error) => console.log(error)
    );
  }
}
