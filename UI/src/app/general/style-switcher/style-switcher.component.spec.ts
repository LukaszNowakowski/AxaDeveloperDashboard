import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StyleSwitcherComponent } from './style-switcher.component';

describe('StyleSwitcherComponent', () => {
  let component: StyleSwitcherComponent;
  let fixture: ComponentFixture<StyleSwitcherComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StyleSwitcherComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StyleSwitcherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
