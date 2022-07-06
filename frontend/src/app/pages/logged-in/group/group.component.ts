import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { GroupSharedService } from 'src/app/services/group/group-shared.service';

@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.scss'],
})
export class GroupComponent implements OnInit {
  constructor(
    private route: ActivatedRoute,
    private groupShared: GroupSharedService
  ) {}

  groupID!: number;

  ngOnInit(): void {
    this.route.params.subscribe((routeParams) => {
      this.groupShared.updateGroupID(routeParams['id']);
    });
  }
}
