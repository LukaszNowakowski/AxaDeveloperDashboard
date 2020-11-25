import { Injectable } from '@angular/core';
import * as models from './security.models';
import * as httpService from './http-security.service';
import { Store } from '@ngxs/store';

import { BrowserPersistenceService } from '../../services/browser-persistence.service';
import * as securityActions from '../redux/actions';

@Injectable({
  providedIn: 'root'
})
export class SecurityService {
  private static readonly UserNameKey: string = 'AxaDeveloperDashboard_UserName';
  private static readonly SecurityTokenKey: string = 'AxaDeveloperDashboard_SecurityToken';

  constructor(
    private connection: httpService.HttpSecurityService,
    private store: Store,
    private persistence: BrowserPersistenceService) { }

  public Initialize(): Promise<boolean> {
    const token: string = this.SecurityToken;
    const userName: string = this.UserName;
    if (!!token) {
      this.store.dispatch(new securityActions.AuthenticateUser(userName, token));
      return Promise.resolve(true);
    }

    return Promise.resolve(false);
  }

  public CreateAccount(request: models.CreateUserRequest): Promise<models.CreateUserResponse> {
    const input: httpService.CreateAccountInput = {
      userName: request.UserName,
      displayName: request.DisplayName,
      password: request.Password
    };
    return this.connection.CreateAccount(input)
      .then(response => {
        return {
          Created: response.created
        } as models.CreateUserResponse;
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
          if (request.PersistToken) {
            this.StoreSecurityToken(request.UserName, response.token);
          }
        }

        return {
          CredentialsValid: response.credentialsValid
        } as models.VerifyCredentialsResponse;
      });
  }

  private get SecurityToken(): string {
    return this.persistence.GetValue(SecurityService.SecurityTokenKey);
  }

  private set SecurityToken(value: string) {
    this.persistence.SetValue(SecurityService.SecurityTokenKey, value);
  }

  private get UserName(): string {
    return this.persistence.GetValue(SecurityService.UserNameKey);
  }

  private set UserName(value: string) {
    this.persistence.SetValue(SecurityService.UserNameKey, value);
  }

  private StoreSecurityToken(userName: string, token: string): void {
    this.UserName = userName;
    this.SecurityToken = token;
  }
}
