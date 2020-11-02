import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { HttpWorkItemsService } from './http-work-items.service';
import { NgxsModule, Store } from '@ngxs/store';
import * as state from '../../services/redux/state';

describe('HttpWorkItemsService', () => {
  let service: HttpWorkItemsService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule,
        NgxsModule.forRoot([state.ServicesState])
      ]
    });
    service = TestBed.inject(HttpWorkItemsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
