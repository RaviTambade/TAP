import { TestBed } from '@angular/core/testing';

import { AccountHubServiceService } from './account-hub-service.service';

describe('AccountHubServiceService', () => {
  let service: AccountHubServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AccountHubServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
