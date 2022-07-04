import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class GroupRequestsPendingSharedService {
  constructor() {}

  private groupSource = new BehaviorSubject<any[]>([]);
  group = this.groupSource.asObservable();

  updateGroups(group: any[]) {
    this.groupSource.next([...group]);
  }

  addGroup(group: any) {
    this.groupSource.next([group, ...this.groupSource.getValue()]);
  }

  deleteGroup(id: number) {
    this.groupSource.next(
      this.groupSource.getValue().filter((f) => f.id !== id)
    );
  }
}
