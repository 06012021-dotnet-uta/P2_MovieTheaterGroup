import { TestBed } from '@angular/core/testing';

import { TheaterDetailsService } from './theater-details.service';

describe('TheaterDetailsService', () => {
  let service: TheaterDetailsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TheaterDetailsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
