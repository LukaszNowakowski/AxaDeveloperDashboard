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

@Injectable({
  providedIn: 'root'
})
export class HttpSecurityService {
  constructor(private http: HttpClient, private store: Store) { }

  public CreateAccount(input: CreateAccountInput): Promise<CreateAccountOutput> {
    const snapshot = this.store.selectSnapshot(servicesState.ServicesState);
    console.log(snapshot);
    const baseAddress = this.store.selectSnapshot(servicesState.ServicesState).security;
    console.log(baseAddress);
    return this.http.post<CreateAccountOutput>(
      baseAddress,
      input)
      .toPromise();
  }
}
