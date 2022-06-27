import { Component, OnInit } from '@angular/core';

import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss'],
})
export class SearchComponent implements OnInit {
  constructor(private userService: UserService) {}

  ngOnInit(): void {}

  searchResults: any[] = [];

  searchUsers(param: string) {
    this.userService.searchUsers(param).subscribe(
      (response) => {
        this.searchResults = response;
        console.log(response);
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
