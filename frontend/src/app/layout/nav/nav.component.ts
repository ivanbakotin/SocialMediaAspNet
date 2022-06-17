import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss'],
})
export class NavComponent implements OnInit {
  constructor() {}

  activeNav: boolean = false;

  ngOnInit(): void {}

  public handleNav() {
    this.activeNav = !this.activeNav;
  }
}
