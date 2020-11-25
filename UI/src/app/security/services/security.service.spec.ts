import { TestBed } from '@angular/core/testing';
import { HttpSecurityService } from './http-security.service';
import { NgxsModule } from '@ngxs/store';
import * as servicesState from '../../services/redux/state';

import { SecurityService } from './security.service';

describe('SecurityService', () => {
  let service: SecurityService;
  let httpSecurityService: HttpSecurityService;

  beforeEach(() => {
    httpSecurityService = jasmine.createSpyObj(['CreateAccount', 'VerifyCredentials']);
    TestBed.configureTestingModule({
      imports: [
        NgxsModule.forRoot([servicesState.ServicesState], {})
      ],
      providers: [
        { provide: HttpSecurityService, useValue: httpSecurityService }
      ]
    });
    service = TestBed.inject(SecurityService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
