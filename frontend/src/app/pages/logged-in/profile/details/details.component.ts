import { Component, OnInit } from '@angular/core';

import { SharedService } from 'src/app/services/profile/shared.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss'],
})
export class DetailsComponent implements OnInit {
  constructor(private sharedService: SharedService) {}

  profile!: any;

  ngOnInit(): void {
    this.sharedService.profile.subscribe((profile) => (this.profile = profile));
  }
}
