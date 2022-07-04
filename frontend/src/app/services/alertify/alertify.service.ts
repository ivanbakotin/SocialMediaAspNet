import { Injectable } from '@angular/core';
import * as alertify from 'alertifyjs';
import { Observable, Subscription } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AlertifyService {
  constructor() {}

  error(message: string) {
    alertify.error(message);
  }

  prompt(title: string, message: string, func: Observable<any>) {
    alertify.prompt(
      title,
      message,
      function (evt: any, value: any) {
        console.log(value);
        func.subscribe();
        alertify.success('Ok');
      },
      function () {
        alertify.error('Cancel');
      }
    );
  }
}
