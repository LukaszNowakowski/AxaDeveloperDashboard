import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { CreateAccountComponent } from './create-account.component';
import { SecurityService } from '../services/security.service';
import { FormBuilder } from '@angular/forms';

describe('CreateAccountComponent', () => {
  let component: CreateAccountComponent;
  let fixture: ComponentFixture<CreateAccountComponent>;
  let securityService: SecurityService;

  beforeEach(async(() => {
    securityService = jasmine.createSpyObj(SecurityService, ['CreateAccount']);
    TestBed.configureTestingModule({
      declarations: [
        CreateAccountComponent
      ],
      providers: [
        FormBuilder,
        { provide: SecurityService, useValue: securityService },
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateAccountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
