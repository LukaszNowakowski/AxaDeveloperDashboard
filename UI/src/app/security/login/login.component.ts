import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SecurityService } from '../services/security.service';
import * as securityModels from '../services/security.models';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public errorMessage = '';
  public loginForm: FormGroup;
  private formSubmitted = false;

  constructor(
    private service: SecurityService,
    private router: Router,
    private fb: FormBuilder) {
  }

  public ngOnInit(): void {
    this.loginForm = this.fb.group({
      userName: ['', [Validators.required]],
      password: ['', [Validators.required]],
      rememberMe: [false, []]
    });
  }

  get RememberMe(): AbstractControl {
    return this.loginForm.controls.rememberMe;
  }

  get UserName(): AbstractControl {
    return this.loginForm.controls.userName;
  }

  get Password(): AbstractControl {
    return this.loginForm.controls.password;
  }

  public Authenticate(): void {
    this.formSubmitted = true;
    if (!this.loginForm.valid) {
      return;
    }

    this.loginForm.disable();
    this.errorMessage = '';
    const request: securityModels.VerifyCredentialsRequest = {
      UserName: this.UserName.value,
      Password: this.Password.value,
      PersistToken: this.RememberMe.value
    };
    this.service
      .Authenticate(request)
      .then(r => {
        if (r && r.CredentialsValid) {
          this.router.navigateByUrl('/home');
        } else {
          this.errorMessage = 'Niepoprawne dane logowania';
        }
      })
      .catch(_ => {
        this.errorMessage = 'Niepoprawne dane logowania';
      })
      .finally(() => {
        this.loginForm.enable();
      });
  }

  public CreateAccount(): void {
    this.router.navigate(['createAccount']);
  }

  public DisplayErrors(control: AbstractControl): boolean {
    return control.invalid && (control.dirty || control.touched || this.formSubmitted);
  }
}
