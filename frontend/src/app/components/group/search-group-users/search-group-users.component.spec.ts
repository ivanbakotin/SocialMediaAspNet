import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchGroupUsersComponent } from './search-group-users.component';

describe('SearchGroupUsersComponent', () => {
  let component: SearchGroupUsersComponent;
  let fixture: ComponentFixture<SearchGroupUsersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchGroupUsersComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SearchGroupUsersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
