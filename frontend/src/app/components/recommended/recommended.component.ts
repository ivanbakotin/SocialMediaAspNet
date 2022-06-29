import { Component, OnInit } from '@angular/core';

import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-recommended',
  templateUrl: './recommended.component.html',
  styleUrls: ['./recommended.component.scss'],
})
export class RecommendedComponent implements OnInit {
  constructor(private userService: UserService) {}

  recommendedUsers: any = [];

  ngOnInit(): void {
    this.getRecommendedUsers();
  }

  getRecommendedUsers() {
    this.userService.getRecommendedUsers().subscribe(
      (response) => {
        console.log(response);
        this.recommendedUsers = response;
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
