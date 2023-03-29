import { TestBed } from '@angular/core/testing';

import { OrderhubService } from './orderhub.service';

describe('OrderhubService', () => {
  let service: OrderhubService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OrderhubService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
