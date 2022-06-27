import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class DisplayService {
  constructor() {}

  checkIsFriend(currentUserID: number, profile: any) {
    return currentUserID == profile?.id || profile?.isFriend;
  }

  displayRemoveFriend(currentUserID: number, profile: any) {
    return currentUserID != profile?.id && profile?.isFriend;
  }

  displayFollow(currentUserID: number, profile: any) {
    return (
      currentUserID != profile?.id &&
      !profile?.isFriend &&
      !profile?.isRequesting &&
      !profile?.iAmRequesting
    );
  }

  displayRemoveRequest(currentUserID: number, profile: any) {
    return (
      currentUserID != profile?.id &&
      !profile?.isFriend &&
      !profile?.isRequesting &&
      profile?.iAmRequesting
    );
  }

  displayAcceptRequest(currentUserID: number, profile: any) {
    return (
      currentUserID != profile?.id &&
      !profile?.isFriend &&
      profile?.isRequesting &&
      !profile?.iAmRequesting
    );
  }
}
