import { Component, OnInit } from '@angular/core';

import { GroupSharedService } from 'src/app/services/group/group-shared.service';

@Component({
  selector: 'app-invitations',
  templateUrl: './invitations.component.html',
  styleUrls: ['./invitations.component.scss'],
})
export class InvitationsComponent implements OnInit {
  constructor(private sharedService: GroupSharedService) {}

  groupID!: number;

  ngOnInit(): void {
    this.sharedService.groupID.subscribe((id) => (this.groupID = id));
  }
}
