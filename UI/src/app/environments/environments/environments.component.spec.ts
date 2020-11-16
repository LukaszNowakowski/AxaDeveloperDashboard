import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { EnvironmentsService } from '../services/environments.service';

import { EnvironmentsComponent } from './environments.component';
import * as state from '../redux/state';
import { NgxsModule } from '@ngxs/store';

describe('EnvironmentsComponent', () => {
  let component: EnvironmentsComponent;
  let fixture: ComponentFixture<EnvironmentsComponent>;
  let service: EnvironmentsService;

  beforeEach(async(() => {
    service = jasmine.createSpyObj(EnvironmentsService, ['RefreshEnvironments']);
    TestBed.configureTestingModule({
      imports: [
        NgxsModule.forRoot([state.EnvironmentsState])
      ],
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
