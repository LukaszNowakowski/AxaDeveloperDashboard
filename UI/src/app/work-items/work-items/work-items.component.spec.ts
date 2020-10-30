import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { WorkItemsService } from '../services/work-items.service';

import { WorkItemsComponent } from './work-items.component';

describe('WorkItemsComponent', () => {
  let component: WorkItemsComponent;
  let fixture: ComponentFixture<WorkItemsComponent>;
  let service: WorkItemsService;

  beforeEach(async(() => {
    service = jasmine.createSpyObj(WorkItemsService, ["CreateProductionLogUrl"]);
    TestBed.configureTestingModule({
      declarations: [
        WorkItemsComponent
      ],
      providers: [
        { provide: WorkItemsService, useValue: service }
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
