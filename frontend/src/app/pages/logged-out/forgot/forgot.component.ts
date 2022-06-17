import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-forgot',
  templateUrl: './forgot.component.html',
  styleUrls: ['./forgot.component.scss'],
})
export class ForgotComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}

  sendEmail() {
    // send email link with url /reset + cryptocode
    // arrive at link
    // server checks database table for resets
    // send password password changed
  }
}
