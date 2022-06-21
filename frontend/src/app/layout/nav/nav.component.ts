import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss'],
})
export class NavComponent implements OnInit {
  constructor(private authService: AuthService) {}

  activeNav: boolean = false;

  ngOnInit(): void {}

  logout() {
    this.authService.logout();
  }

  public handleNav() {
    this.activeNav = !this.activeNav;
  }
}
