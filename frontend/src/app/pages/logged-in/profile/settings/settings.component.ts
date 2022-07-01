import { Component, OnInit } from '@angular/core';

import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss'],
})
export class SettingsComponent implements OnInit {
  constructor(private userService: UserService) {}

  ngOnInit(): void {}

  changePassword() {
    this.userService.changePassword().subscribe();
  }
}
