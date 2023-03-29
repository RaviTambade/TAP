import { TestBed } from '@angular/core/testing';

import { ProducthubService } from './producthub.service';

describe('ProducthubService', () => {
  let service: ProducthubService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProducthubService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
