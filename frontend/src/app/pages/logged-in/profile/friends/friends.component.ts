import { Component, OnInit } from '@angular/core';

import { FriendService } from 'src/app/services/friend/friend.service';

@Component({
  selector: 'app-friends',
  templateUrl: './friends.component.html',
  styleUrls: ['./friends.component.scss'],
})
export class FriendsComponent implements OnInit {
  constructor(private friendService: FriendService) {}

  ngOnInit(): void {
    this.friendService.getFriends(1).subscribe(
      (response) => {
        console.log(response);
      },
      (error) => console.log(error)
    );
  }
}
