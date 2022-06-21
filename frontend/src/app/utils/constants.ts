import { HttpHeaders } from '@angular/common/http';

export const header = {
  headers: new HttpHeaders().set(
    'Authorization',
    `Bearer ${localStorage.getItem('token')}`
  ),
};

export const HOSTNAME = 'https://localhost:44344/api/';
