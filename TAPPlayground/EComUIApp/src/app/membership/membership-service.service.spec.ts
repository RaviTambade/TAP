import { TestBed } from '@angular/core/testing';

import { MembershipServiceService } from './membership-service.service';

describe('MembershipServiceService', () => {
  let service: MembershipServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MembershipServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
