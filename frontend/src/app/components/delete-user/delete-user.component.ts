import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-delete-user',
  templateUrl: './delete-user.component.html',
  styleUrls: ['./delete-user.component.scss'],
})
export class DeleteUserComponent implements OnInit {
  constructor(private userService: UserService) {}

  isEditing: boolean = false;

  ngOnInit(): void {}

  setEditing() {
    this.isEditing = !this.isEditing;
  }

  deleteUser(form: NgForm) {
    this.userService.deleteUser(form.value).subscribe();
    this.setEditing();
  }
}
