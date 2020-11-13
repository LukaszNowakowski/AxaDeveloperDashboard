import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EnvironmentErrorsComponent } from './environment-errors.component';

describe('EnvironmentErrorsComponent', () => {
  let component: EnvironmentErrorsComponent;
  let fixture: ComponentFixture<EnvironmentErrorsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EnvironmentErrorsComponent ]
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
