import { Injectable } from '@angular/core';
import * as models from './security.models';
import * as httpService from './http-security.service';

@Injectable({
  providedIn: 'root'
})
export class SecurityService {
  constructor(private connection: httpService.HttpSecurityService) { }

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
}
