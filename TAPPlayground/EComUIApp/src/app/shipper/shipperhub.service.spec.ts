import { TestBed } from '@angular/core/testing';

import { ShipperhubService } from './shipperhub.service';

describe('ShipperhubService', () => {
  let service: ShipperhubService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ShipperhubService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
