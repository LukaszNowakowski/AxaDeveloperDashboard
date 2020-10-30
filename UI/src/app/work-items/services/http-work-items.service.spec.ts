import { TestBed } from '@angular/core/testing';

import { HttpWorkItemsService } from './http-work-items.service';

describe('HttpWorkItemsService', () => {
  let service: HttpWorkItemsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HttpWorkItemsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
