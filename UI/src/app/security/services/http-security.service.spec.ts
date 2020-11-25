import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { NgxsModule } from '@ngxs/store';

import { HttpSecurityService } from './http-security.service';
import * as servicesState from '../../services/redux/state';

describe('HttpSecurityService', () => {
  let service: HttpSecurityService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule,
        NgxsModule.forRoot([servicesState.ServicesState], {})
      ]
    });
    service = TestBed.inject(HttpSecurityService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
