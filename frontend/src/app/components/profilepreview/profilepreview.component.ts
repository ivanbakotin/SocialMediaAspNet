import { Component, OnInit } from '@angular/core';

import { ProfileService } from 'src/app/services/profile/profile.service';

@Component({
  selector: 'app-profilepreview',
  templateUrl: './profilepreview.component.html',
  styleUrls: ['./profilepreview.component.scss'],
})
export class ProfilepreviewComponent implements OnInit {
  constructor(private profileService: ProfileService) {}

  ngOnInit(): void {}

  getProfile() {}
}
