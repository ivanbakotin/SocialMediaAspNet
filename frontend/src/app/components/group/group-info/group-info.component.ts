import { Component, Input, OnInit } from '@angular/core';

import { GroupService } from 'src/app/services/group/group.service';

@Component({
  selector: 'app-group-info',
  templateUrl: './group-info.component.html',
  styleUrls: ['./group-info.component.scss'],
})
export class GroupInfoComponent implements OnInit {
  constructor(private groupService: GroupService) {}

  info!: any;
  @Input() groupID!: number;

  ngOnInit(): void {
    this.groupService.getGroupInfo(this.groupID).subscribe((response) => {
      this.info = response;
    });
  }
}
