import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.scss'],
})
export class CreatePostComponent implements OnInit {
  constructor() {}

  @Output() sendPost = new EventEmitter();

  ngOnInit(): void {}

  submitForm(form: NgForm) {
    const body = {
      title: form.value.title,
      body: form.value.body,
    };

    this.sendPost.emit(body);
  }
}
