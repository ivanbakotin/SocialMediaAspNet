import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ProfileService } from 'src/app/services/profile/profile.service';
import { FriendService } from 'src/app/services/friend/friend.service';
import { UserService } from 'src/app/services/user/user.service';
import { Profile } from 'src/app/interfaces/Profile';
import { SharedService } from 'src/app/services/profile/shared.service';
import { DisplayService } from 'src/app/services/profile/display.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent implements OnInit {
  constructor(
    public displayService: DisplayService,
    private friendService: FriendService,
    private profileService: ProfileService,
    private userService: UserService,
    private route: ActivatedRoute,
    private sharedService: SharedService
  ) {}

  profile!: Profile;
  currentUserID!: number;
  currentUsername!: string;

  ngOnInit(): void {
    this.route.params.subscribe((routeParams) => {
      this.getProfile(routeParams['id']);
      this.currentUsername = routeParams['id'];
    });

    this.currentUserID = this.userService.getCurrentUserID();
  }

  sendFriendRequest() {
    this.profile.iAmRequesting = true;
    this.friendService.sendRequest(this.profile.id).subscribe();
  }

  declineRequest() {
    this.profile.isRequesting = false;
    this.profile.iAmRequesting = false;
    this.friendService.declineRequest(this.profile.id).subscribe();
  }

  acceptRequest() {
    this.profile.isFriend = true;
    this.friendService.acceptRequest(this.profile.id).subscribe();
  }

  removeFriend() {
    this.profile.isFriend = false;
    this.friendService.removeFriend(this.profile.id).subscribe();
  }

  getProfile(id: any) {
    this.profileService.getProfile(id).subscribe((response) => {
      this.sharedService.updateProfile(response);
      this.sharedService.updateID(response.id);
      this.profile = response;
    });
  }
}
