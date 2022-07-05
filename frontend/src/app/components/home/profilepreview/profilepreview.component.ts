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

  ngOnInit(): void {
    this.userService.getCurrentUsername().subscribe((response) => {
      this.getProfile(response.username);
    });
  }

  getProfile(username: string) {
    this.profileService.getProfile(username).subscribe((response) => {
      this.profile = response;
    });
  }
}
