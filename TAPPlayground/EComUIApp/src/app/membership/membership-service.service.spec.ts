import { TestBed } from '@angular/core/testing';

import { MembershipService } from './membership-service.service';

describe('MembershipServiceService', () => {
  let service: MembershipService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MembershipService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
