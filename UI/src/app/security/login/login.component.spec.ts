import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';

import { LoginComponent } from './login.component';
import { SecurityService } from '../services/security.service';
import { Component } from '@angular/core';

@Component({
  template: '<h1>LOGIN</h1>'
})
class HomeComponent { }

@Component({
  template: '<h1>LOGIN</h1>'
})
class CreateAccountComponent { }

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;
  let securityService: SecurityService;

  beforeEach(async(() => {
    securityService = jasmine.createSpyObj(SecurityService, ['CreateAccount']);
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule.withRoutes([
          { path: 'home', component: HomeComponent },
          { path: 'createAccount', component: CreateAccountComponent }
        ]),
      ],
      declarations: [
        LoginComponent
      ],
      providers: [
        FormBuilder,
        { provide: SecurityService, useValue: securityService },
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
