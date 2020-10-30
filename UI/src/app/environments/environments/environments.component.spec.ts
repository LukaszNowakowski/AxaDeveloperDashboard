import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { EnvironmentsService } from '../services/environments.service';

import { EnvironmentsComponent } from './environments.component';
import * as serviceModel from '../../services/redux/model';

describe('EnvironmentsComponent', () => {
  let component: EnvironmentsComponent;
  let fixture: ComponentFixture<EnvironmentsComponent>;
  let service: EnvironmentsService;

  beforeEach(async(() => {
    service = jasmine.createSpyObj(EnvironmentsService, ["FetchEnvironments"]);
    service.FetchEnvironments = jasmine.createSpy("FetchEnvironments").and.returnValue(Promise.resolve<serviceModel.ApisUrls>({ environments: '', workItems: ''}))
    TestBed.configureTestingModule({
      declarations: [
        EnvironmentsComponent
      ],
      providers: [
        { provide: EnvironmentsService, useValue: service }
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EnvironmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
