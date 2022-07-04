import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-change-email',
  templateUrl: './change-email.component.html',
  styleUrls: ['./change-email.component.scss'],
})
export class ChangeEmailComponent implements OnInit {
  constructor(private userService: UserService) {}

  isEditing: boolean = false;

  ngOnInit(): void {}

  setEditing() {
    this.isEditing = !this.isEditing;
  }

  changeEmail(form: NgForm) {
    this.userService.changeEmail(form.value).subscribe();
    this.setEditing();
  }
}
