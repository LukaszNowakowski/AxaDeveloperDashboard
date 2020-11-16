import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Store } from '@ngxs/store';
import * as servicesState from '../../services/redux/state';

export interface Link {
  id: number;
  displayName: string;
  url: string;
  icon?: string;
  order: number;
}

export interface Environment {
  id: number;
  displayName: string;
  order: number;
  links: Link[];
}

export interface FetchEnvironmentsResponse {
  environments: Environment[];
}

export interface AddEnvironmentResponse {
  created: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class HttpEnvironmentsService {
  constructor(private http: HttpClient, private store: Store) { }

  public FetchEnvironments(): Promise<FetchEnvironmentsResponse> {
    const baseAddress = this.store.selectSnapshot(servicesState.ServicesState).environments;
    return this.http.get<FetchEnvironmentsResponse>(baseAddress)
      .toPromise();
  }

  public AddEnvironment(request: Environment): Promise<AddEnvironmentResponse> {
    const baseAddress = this.store.selectSnapshot(servicesState.ServicesState).environments;
    return this.http.post<AddEnvironmentResponse>(
      baseAddress,
      request)
      .toPromise();
    }
}
