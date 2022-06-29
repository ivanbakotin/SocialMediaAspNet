import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  constructor() {}

  private profileSource = new BehaviorSubject<any>({});
  profile = this.profileSource.asObservable();

  updateProfile(profile: number) {
    this.profileSource.next(profile);
  }

  private userIDSource = new BehaviorSubject<number>(0);
  userID = this.userIDSource.asObservable();

  updateID(id: number) {
    this.userIDSource.next(id);
  }
}
