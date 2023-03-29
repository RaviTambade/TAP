import { TestBed } from '@angular/core/testing';

import { HRHUBService } from './hrhub.service';

describe('HRHUBService', () => {
  let service: HRHUBService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HRHUBService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
