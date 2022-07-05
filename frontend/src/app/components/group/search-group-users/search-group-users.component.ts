import { Component, OnInit } from '@angular/core';
import { GroupService } from 'src/app/services/group/group.service';

@Component({
  selector: 'app-search-group-users',
  templateUrl: './search-group-users.component.html',
  styleUrls: ['./search-group-users.component.scss'],
})
export class SearchGroupUsersComponent implements OnInit {
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
