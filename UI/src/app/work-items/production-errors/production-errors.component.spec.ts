import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductionErrorsComponent } from './production-errors.component';

describe('ProductionErrorsComponent', () => {
  let component: ProductionErrorsComponent;
  let fixture: ComponentFixture<ProductionErrorsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductionErrorsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductionErrorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
