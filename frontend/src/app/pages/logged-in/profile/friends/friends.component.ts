import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { FriendService } from 'src/app/services/friend/friend.service';

@Component({
  selector: 'app-friends',
  templateUrl: './friends.component.html',
  styleUrls: ['./friends.component.scss'],
})
export class FriendsComponent implements OnInit {
  constructor(
    private friendService: FriendService,
    private _route: ActivatedRoute
  ) {}

  friends: any = [];

  ngOnInit(): void {
    console.log(this._route);
    this.friendService.getFriends(history.state.navigationId).subscribe(
      (response) => {
        console.log(response);
        this.friends = response;
      },
      (error) => console.log(error)
    );
  }
}
