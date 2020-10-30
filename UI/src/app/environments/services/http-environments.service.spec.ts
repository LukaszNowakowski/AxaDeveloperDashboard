import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { NgxsModule, Store } from '@ngxs/store';
import { HttpEnvironmentsService } from './http-environments.service';
import * as state from '../../services/redux/state';

describe('HttpEnvironmentsService', () => {
  let service: HttpEnvironmentsService;
  let store: Store;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule,
        NgxsModule.forRoot([state.ServicesState])
      ]
    });
    service = TestBed.inject(HttpEnvironmentsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
