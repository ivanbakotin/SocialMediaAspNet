import { Component, OnInit } from '@angular/core';

import { ProfileService } from 'src/app/services/profile/profile.service';
import { UserService } from 'src/app/services/user/user.service';
import { Profile } from 'src/app/interfaces/Profile';

@Component({
  selector: 'app-profilepreview',
  templateUrl: './profilepreview.component.html',
  styleUrls: ['./profilepreview.component.scss'],
})
export class ProfilepreviewComponent implements OnInit {
  constructor(
    private profileService: ProfileService,
    private userService: UserService
  ) {}

  profile!: Profile;
  currentUserID!: number;

  ngOnInit(): void {
    this.currentUserID = this.userService.getCurrentUserID();
    this.getProfile();
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
