import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { FormBuilder } from '@angular/forms';
import { WorkItemsService } from '../services/work-items.service';

import { EnvironmentErrorsComponent } from './environment-errors.component';

describe('EnvironmentErrorsComponent', () => {
  let component: EnvironmentErrorsComponent;
  let fixture: ComponentFixture<EnvironmentErrorsComponent>;
  let workItemsService: WorkItemsService;

  beforeEach(async(() => {
    workItemsService = jasmine.createSpyObj(WorkItemsService, ['CreateProductionLogUrl']);
    TestBed.configureTestingModule({
      declarations: [
        EnvironmentErrorsComponent
      ],
      providers: [
        FormBuilder,
        { provide: WorkItemsService, useValue: workItemsService },
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EnvironmentErrorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
