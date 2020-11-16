import { TestBed } from '@angular/core/testing';
import { NgxsModule } from '@ngxs/store';

import { EnvironmentsService } from './environments.service';
import { HttpEnvironmentsService } from './http-environments.service';
import * as state from '../../services/redux/state';

describe('EnvironmentsService', () => {
  let service: EnvironmentsService;
  let httpService: HttpEnvironmentsService;

  beforeEach(() => {
    httpService = jasmine.createSpyObj(HttpEnvironmentsService, ['FetchEnvironments']);
    TestBed.configureTestingModule({
      imports: [
        NgxsModule.forRoot([state.ServicesState])
      ],
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
