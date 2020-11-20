import { TestBed } from '@angular/core/testing';

import { UserEditPreventUnsaveGuard } from './user-edit-prevent-unsave.guard';

describe('UserEditPreventUnsaveGuard', () => {
  let guard: UserEditPreventUnsaveGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(UserEditPreventUnsaveGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
