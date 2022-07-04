import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss'],
})
export class ChangePasswordComponent implements OnInit {
  constructor(private userService: UserService) {}

  isEditing: boolean = false;

  ngOnInit(): void {}

  setEditing() {
    this.isEditing = !this.isEditing;
  }

  changePassword(form: NgForm) {
    this.userService.changePassword(form.value).subscribe();
    this.setEditing();
  }
}
