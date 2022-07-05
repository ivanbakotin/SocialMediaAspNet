import { Component, OnInit } from '@angular/core';

import { GroupService } from 'src/app/services/group/group.service';
import { GroupSharedService } from 'src/app/services/group/group-shared.service';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.scss'],
})
export class GroupsComponent implements OnInit {
  constructor(
    private groupService: GroupService,
    private groupSharedService: GroupSharedService
  ) {}

  groups: any = [];

  ngOnInit(): void {
    this.groupSharedService.group.subscribe((groups) => (this.groups = groups));
    this.getUserGroups();
  }

  deleteGroup(groupID: number) {
    this.groupSharedService.deleteGroup(groupID);
    this.groupService.deleteGroup(groupID).subscribe();
  }

  getUserGroups() {
    this.groupService.getUserGroup().subscribe((response) => {
      this.groups = response[0];
      this.groupSharedService.updateGroups(response[0]);
    });
  }
}
