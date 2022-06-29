import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { FriendService } from 'src/app/services/friend/friend.service';
import { SharedService } from 'src/app/services/profile/shared.service';

@Component({
  selector: 'app-friends',
  templateUrl: './friends.component.html',
  styleUrls: ['./friends.component.scss'],
})
export class FriendsComponent implements OnInit {
  constructor(
    private friendService: FriendService,
    private sharedService: SharedService
  ) {}

  friends: any = [];
  userID!: number;

  ngOnInit(): void {
    this.sharedService.userID.subscribe((id) => (this.userID = id));

    this.friendService.getFriends(this.userID).subscribe(
      (response) => {
        this.friends = response[0].friends1.concat(
          response[0].friends2,
          response[0].friends22,
          response[0].friends11
        );
      },
      (error) => console.log(error)
    );
  }

  removeFriend(id: number) {
    this.friends = this.friends.filter((f: any) => f.id !== id);
    this.friendService.removeFriend(id).subscribe();
  }
}
