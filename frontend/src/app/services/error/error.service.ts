import {
  HttpErrorResponse,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { AlertifyService } from '../alertify/alertify.service';

@Injectable({
  providedIn: 'root',
})
export class ErrorService implements HttpInterceptor {
  constructor(private alertyfy: AlertifyService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        if (typeof error.error === 'string') {
          this.alertyfy.error(error.error);
        } else if (error.name) {
          this.alertyfy.error(error.name);
        }
        return throwError(error.error);
      })
    );
  }
}
