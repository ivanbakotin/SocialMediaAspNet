import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

import { GroupService } from 'src/app/services/group/group.service';
import { GroupSharedService } from 'src/app/services/group/group-shared.service';

@Component({
  selector: 'app-create-group',
  templateUrl: './create-group.component.html',
  styleUrls: ['./create-group.component.scss'],
})
export class CreateGroupComponent implements OnInit {
  constructor(
    private groupService: GroupService,
    private groupSharedService: GroupSharedService
  ) {}

  ngOnInit(): void {}

  submitForm(form: NgForm) {
    this.groupService.createGroup(form.value).subscribe((response) => {
      this.groupSharedService.addGroup(response);
    });
  }
}
