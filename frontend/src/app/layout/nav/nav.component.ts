import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth/auth.service';

import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss'],
})
export class NavComponent implements OnInit {
  constructor(
    private authService: AuthService,
    private userService: UserService
  ) {}

  currentUserID!: Number;
  activeNav: boolean = false;

  ngOnInit(): void {
    this.currentUserID = this.userService.getCurrentUserID();
  }

  logout() {
    this.authService.logout();
  }

  public handleNav() {
    this.activeNav = !this.activeNav;
  }
}
