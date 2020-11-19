import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { SecurityService } from '../services/security.service';

@Component({
  templateUrl: './create-account.component.html',
  styleUrls: ['./create-account.component.scss']
})
export class CreateAccountComponent implements OnInit {
  public createAccountForm: FormGroup;

  public accountCreated = false;

  private formSubmitted = false;

  constructor(
    private service: SecurityService,
    private fb: FormBuilder) {
  }

  public ngOnInit(): void {
    this.createAccountForm = this.fb.group({
      userName: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(50), Validators.pattern('^[a-zA-Z0-9_\.]*$')]],
      password: ['', [Validators.required, Validators.minLength(8)]],
      repeatPassword: ['', [Validators.required, this.PasswordsMatchValidator('password')]],
      emailAddress: ['', [Validators.required, Validators.maxLength(254), Validators.email]],
      displayName: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(50)]]
    });
  }

  get UserName(): AbstractControl {
    return this.createAccountForm.controls.userName;
  }

  get Password(): AbstractControl {
    return this.createAccountForm.get('password');
  }

  get RepeatPassword(): AbstractControl {
    return this.createAccountForm.get('repeatPassword');
  }

  get EmailAddress(): AbstractControl {
    return this.createAccountForm.controls.emailAddress;
  }

  get DisplayName(): AbstractControl {
    return this.createAccountForm.controls.displayName;
  }

  public DisplayErrors(control: AbstractControl): boolean {
    return control.invalid && (control.dirty || control.touched || this.formSubmitted);
  }

  public PasswordsMatchValidator(passwordKey: string): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      if (!control.parent) {
        return null;
      }

      const passwordControl = control.parent.get(passwordKey);
      if (!passwordControl) {
        return null;
      }

      const password = passwordControl.value;
      const repeatPassword = control.value;
      if (password === repeatPassword) {
        return null;
      }

      return { passwordsdiffer: {} };
    };
  }

  public CreateAccount(): Promise<void> {
    this.formSubmitted = true;
    if (!this.createAccountForm.valid) {
      return Promise.resolve();
    }

    this.createAccountForm.disable();
    return this.service.CreateAccount({
      UserName: this.UserName.value,
      Password: this.Password.value,
      Email: this.EmailAddress.value,
      DisplayName: this.DisplayName.value
    })
      .then(result => {
        if (result.Created) {
          this.accountCreated = true;
        }
      })
      .finally(() => {
        this.createAccountForm.enable();
      });
  }
}
