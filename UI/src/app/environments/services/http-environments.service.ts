import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Store } from '@ngxs/store';
import * as servicesState from '../../services/redux/state';

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
}
