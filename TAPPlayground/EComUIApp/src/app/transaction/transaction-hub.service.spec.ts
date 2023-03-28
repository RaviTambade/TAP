import { TestBed } from '@angular/core/testing';

import { TransactionHubService } from './transaction-hub.service';

describe('TransactionHubService', () => {
  let service: TransactionHubService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TransactionHubService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
