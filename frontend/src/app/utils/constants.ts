import { HttpHeaders } from '@angular/common/http';

export function GetHeader() {
  const body = new HttpHeaders()
    .set('Authorization', `Bearer ${localStorage.getItem('token')}`)
    .set('Content-Type', 'application/json');

  return body;
}

export function GetJSONHeader() {
  const body = new HttpHeaders().set('Content-Type', 'application/json');

  return body;
}

export const HOSTNAME = 'https://localhost:44344/api/';
