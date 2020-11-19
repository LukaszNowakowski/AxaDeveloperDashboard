import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Store } from '@ngxs/store';
import * as servicesState from '../../services/redux/state';

export interface CreateAccountInput {
  userName: string;
  displayName: string;
  password: string;
}

export interface CreateAccountOutput {
  created: boolean;
}

export interface VerifyCredentialsInput {
  userName: string;
  password: string;
}

export interface VerifyCredentialsOutput {
  credentialsValid: boolean;
  token: string;
}

@Injectable({
  providedIn: 'root'
})
export class HttpSecurityService {
  constructor(private http: HttpClient, private store: Store) { }

  public CreateAccount(input: CreateAccountInput): Promise<CreateAccountOutput> {
    const baseAddress = this.store.selectSnapshot(servicesState.ServicesState).security;
    return this.http.post<CreateAccountOutput>(
      baseAddress,
      input)
      .toPromise();
  }

  public VerifyCredentials(input: VerifyCredentialsInput): Promise<VerifyCredentialsOutput> {
    const baseAddress = this.store.selectSnapshot(servicesState.ServicesState).security;
    const url = baseAddress + '/createToken';
    return this.http.post<VerifyCredentialsOutput>(
      url,
      input)
      .toPromise();
  }
}
