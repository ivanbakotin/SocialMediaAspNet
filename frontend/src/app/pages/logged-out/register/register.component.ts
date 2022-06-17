import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  constructor(private registerService: AuthService, private router: Router) {}

  ngOnInit(): void {}

  error = '';

  submitForm(form: NgForm) {
    if (form.value.password !== form.value.confirm) {
      this.error = 'Passwords do not match!';
      return;
    }

    const body = {
      email: form.value.email,
      password: form.value.password,
    };

    this.registerService.register(body).subscribe(
      () => {
        this.router.navigate(['/auth']);
      },
      (error) => {
        this.error = error.error;
      }
    );
  }
}
