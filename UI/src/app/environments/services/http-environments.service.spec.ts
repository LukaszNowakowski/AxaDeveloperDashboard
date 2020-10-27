import { TestBed } from '@angular/core/testing';

import { HttpEnvironmentsService } from './http-environments.service';

describe('HttpEnvironmentsService', () => {
  let service: HttpEnvironmentsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HttpEnvironmentsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
