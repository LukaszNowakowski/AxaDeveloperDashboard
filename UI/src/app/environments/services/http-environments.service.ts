import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Store } from '@ngxs/store';
import * as servicesState from '../../services/redux/state';
import { environment } from 'src/environments/environment';

export interface Link {
  id: number;
  displayName: string;
  url: string;
  icon?: string;
}

export interface Environment {
  id: number;
  displayName: string;
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
    var baseAddress = this.store.selectSnapshot(servicesState.ServicesState).environments;
    return this.http.get<FetchEnvironmentsResponse>(baseAddress)
      .toPromise();
  }

  public AddEnvironment(request: Environment): Promise<AddEnvironmentResponse> {
    var baseAddress = this.store.selectSnapshot(servicesState.ServicesState).environments;
    console.log(baseAddress);
    return this.http.post<AddEnvironmentResponse>(
      baseAddress,
      request)
      .toPromise();
    }
}
