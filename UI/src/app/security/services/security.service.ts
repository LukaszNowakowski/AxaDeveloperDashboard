import { Injectable } from '@angular/core';
import * as models from './security.models';
import * as httpService from './http-security.service';
import { Store } from '@ngxs/store';
import * as securityActions from '../redux/actions';

@Injectable({
  providedIn: 'root'
})
export class SecurityService {
  constructor(
    private connection: httpService.HttpSecurityService,
    private store: Store) { }

  public CreateAccount(request: models.CreateUserRequest): Promise<models.CreateUserResponse> {
    const input: httpService.CreateAccountInput = {
      userName: request.UserName,
      displayName: request.DisplayName,
      password: request.Password
    };
    return this.connection.CreateAccount(input)
      .then(response => {
        return <models.CreateUserResponse>{
          Created: response.created
        };
      });
  }

  public Authenticate(request: models.VerifyCredentialsRequest): Promise<models.VerifyCredentialsResponse> {
    const input: httpService.VerifyCredentialsInput = {
      userName: request.UserName,
      password: request.Password
    };
    return this.connection.VerifyCredentials(input)
      .then(response => {
        if (response.credentialsValid) {
          this.store.dispatch(new securityActions.AuthenticateUser(request.UserName, response.token));
        }

        return <models.VerifyCredentialsResponse>{
          CredentialsValid: response.credentialsValid
        };
      });
  }
}
