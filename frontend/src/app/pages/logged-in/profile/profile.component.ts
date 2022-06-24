import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ProfileService } from 'src/app/services/profile/profile.service';
import { UserService } from 'src/app/services/user/user.service';
import { Profile } from 'src/app/interfaces/Profile';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent implements OnInit {
  constructor(
    private profileService: ProfileService,
    private userService: UserService,
    private route: ActivatedRoute
  ) {}

  profile!: Profile;
  currentUserID!: number;

  ngOnInit(): void {
    this.currentUserID = this.userService.getCurrentUserID();
    console.log(this.currentUserID);
    this.getProfile();
  }

  checkIsFriend() {
    return this.currentUserID == this.profile?.id || this.profile?.isFriend;
  }

  displayFollow() {
    return (
      this.currentUserID != this.profile?.id &&
      !this.profile?.isFriend &&
      !this.profile?.isRequesting &&
      !this.profile?.iAmRequesting
    );
  }

  displayDeclineRequest() {
    return (
      this.currentUserID != this.profile?.id &&
      !this.profile?.isFriend &&
      this.profile?.isRequesting &&
      !this.profile?.iAmRequesting
    );
  }

  displayPendingRequest() {
    return (
      this.currentUserID != this.profile?.id &&
      !this.profile?.isFriend &&
      !this.profile?.isRequesting &&
      this.profile?.iAmRequesting
    );
  }

  getProfile() {
    this.profileService
      .getProfile(this.route.snapshot.paramMap.get('id'))
      .subscribe(
        (response) => {
          console.log(response);
          this.profile = response;
        },
        (error) => {
          console.error(error);
        }
      );
  }
}
