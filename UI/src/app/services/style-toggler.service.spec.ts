import { TestBed } from '@angular/core/testing';

import { StyleTogglerService } from './style-toggler.service';

describe('StyleTogglerService', () => {
  let service: StyleTogglerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StyleTogglerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
