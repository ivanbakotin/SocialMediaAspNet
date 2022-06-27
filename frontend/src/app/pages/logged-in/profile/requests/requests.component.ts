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

  ngOnInit(): void {
    this.friendService.getRequestsPending().subscribe(
      (response) => {
        console.log(response);
        this.requestsPending = response[0].requests;
      },
      (error) => console.log(error)
    );

    this.friendService.getRequestsSent().subscribe(
      (response) => {
        console.log(response);
        this.requestsSent = response[0].requests;
      },
      (error) => console.log(error)
    );
  }
}
