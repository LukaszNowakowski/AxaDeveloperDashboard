import { TestBed } from '@angular/core/testing';

import { WorkItemsService } from './work-items.service';
import { HttpWorkItemsService } from './http-work-items.service';

describe('WorkItemsService', () => {
  let service: WorkItemsService;
  let httpService: HttpWorkItemsService;

  beforeEach(() => {
    httpService = jasmine.createSpyObj(HttpWorkItemsService, ['GetProductionLogPath']);
    TestBed.configureTestingModule({
      providers: [
        { provide: HttpWorkItemsService, useValue: httpService }
      ]
    });
    service = TestBed.inject(WorkItemsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
