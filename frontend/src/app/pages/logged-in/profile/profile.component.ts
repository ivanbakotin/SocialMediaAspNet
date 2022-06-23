import { Component, OnInit } from '@angular/core';

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
    private userService: UserService
  ) {}

  profile!: Profile;
  currentUserID!: number;

  ngOnInit(): void {
    this.currentUserID = this.userService.getCurrentUserID();
  }

  getProfile() {
    this.profileService.getProfile(this.currentUserID).subscribe(
      (response) => {
        this.profile = response;
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
