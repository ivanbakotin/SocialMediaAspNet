import { HttpHeaders } from '@angular/common/http';

export function GetHeader() {
  return new HttpHeaders().set(
    'Authorization',
    `Bearer ${localStorage.getItem('token')}`
  );
}

export const HOSTNAME = 'https://localhost:44344/api/';
