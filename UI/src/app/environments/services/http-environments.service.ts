import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export interface Link {
  displayName: string;
  url: string;
  icon?: string;
}

export interface Environment {
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
  constructor(private http: HttpClient) { }

  public FetchEnvironments(): Promise<FetchEnvironmentsResponse> {
    return this.http.get<FetchEnvironmentsResponse>("http://localhost:6501/environments")
      .toPromise();
  }
}
