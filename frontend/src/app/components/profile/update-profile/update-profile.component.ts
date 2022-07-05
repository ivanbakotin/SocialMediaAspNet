import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

import { SharedService } from 'src/app/services/profile/shared.service';
import { ProfileService } from 'src/app/services/profile/profile.service';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-update-profile',
  templateUrl: './update-profile.component.html',
  styleUrls: ['./update-profile.component.scss'],
})
export class UpdateProfileComponent implements OnInit {
  constructor(
    private profileService: ProfileService,
    private sharedService: SharedService
  ) {}

  profile!: any;
  isEditing: boolean = false;

  ngOnInit(): void {
    this.sharedService.profile.subscribe((profile) => (this.profile = profile));
  }

  setEditing() {
    this.isEditing = !this.isEditing;
  }

  updateProfile(form: NgForm) {
    this.profileService.updateProfile(form.value).subscribe();
    this.setEditing();
  }
}
