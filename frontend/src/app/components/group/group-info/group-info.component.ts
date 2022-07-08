import { Component, Input, OnInit } from '@angular/core';

import { GroupService } from 'src/app/services/group/group.service';
import { GroupSharedService } from 'src/app/services/group/group-shared.service';

@Component({
  selector: 'app-group-info',
  templateUrl: './group-info.component.html',
  styleUrls: ['./group-info.component.scss'],
})
export class GroupInfoComponent implements OnInit {
  constructor(
    private groupService: GroupService,
    private groupSharedService: GroupSharedService
  ) {}

  info!: any;
  groupID!: number;

  ngOnInit(): void {
    this.groupSharedService.groupID.subscribe(
      (id) => (
        (this.groupID = id),
        this.groupService.getGroupInfo(this.groupID).subscribe((response) => {
          this.info = response;
        })
      )
    );
  }
}
