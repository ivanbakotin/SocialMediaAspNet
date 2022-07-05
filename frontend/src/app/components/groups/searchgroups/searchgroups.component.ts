import { Component, OnInit } from '@angular/core';

import { GroupService } from 'src/app/services/group/group.service';

@Component({
  selector: 'app-searchgroups',
  templateUrl: './searchgroups.component.html',
  styleUrls: ['./searchgroups.component.scss'],
})
export class SearchgroupsComponent implements OnInit {
  constructor(private groupService: GroupService) {}

  ngOnInit(): void {}

  searchResults: any[] = [];

  searchGroups(param: string) {
    if (param) {
      this.groupService.searchGroups(param).subscribe((response: any) => {
        console.log(response);
        this.searchResults = response;
      });
    } else {
      this.searchResults = [];
    }
  }
}
