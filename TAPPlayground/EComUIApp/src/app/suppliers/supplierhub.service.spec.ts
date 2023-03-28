import { TestBed } from '@angular/core/testing';

import { SupplierhubService } from './supplierhub.service';

describe('SupplierhubService', () => {
  let service: SupplierhubService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SupplierhubService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
