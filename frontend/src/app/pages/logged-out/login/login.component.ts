import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  constructor(private loginService: AuthService, private router: Router) {}

  ngOnInit(): void {}

  submitForm(form: NgForm) {
    const data = {
      email: form.value.email,
      password: form.value.password,
      rememberMe: form.value.rememberMe || false,
    };

    this.loginService.login(data).subscribe((response) => {
      const token = (<any>response).token;
      localStorage.setItem('token', token);
      this.router.navigate(['/home']);
    });
  }
}
