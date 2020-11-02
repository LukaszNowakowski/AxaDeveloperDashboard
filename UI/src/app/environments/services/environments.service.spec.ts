import { TestBed } from '@angular/core/testing';

import { EnvironmentsService } from './environments.service';
import { HttpEnvironmentsService } from './http-environments.service';

describe('EnvironmentsService', () => {
  let service: EnvironmentsService;
  let httpService: HttpEnvironmentsService;

  beforeEach(() => {
    httpService = jasmine.createSpyObj(HttpEnvironmentsService, ["FetchEnvironments"]);
    TestBed.configureTestingModule({
      providers: [
        { provide: HttpEnvironmentsService, useValue: httpService }
      ]
    });
    service = TestBed.inject(EnvironmentsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
