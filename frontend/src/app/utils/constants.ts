import { HttpHeaders } from '@angular/common/http';

export function GetHeader() {
  const body = new HttpHeaders().set(
    'Authorization',
    `Bearer ${localStorage.getItem('token')}`
  );

  return body;
}

export const HOSTNAME = 'https://localhost:44344/api/';
