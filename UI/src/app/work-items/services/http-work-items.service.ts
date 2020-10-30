import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Store } from '@ngxs/store';
import * as servicesState from '../../services/redux/state';

@Injectable({
  providedIn: 'root'
})
export class HttpWorkItemsService {
   constructor(private http: HttpClient, private store: Store) { }

  public FetchEnvironments(errorId: number): Promise<string> {
    var baseAddress = this.store.selectSnapshot(servicesState.ServicesState).workItems;
    let path = `${baseAddress}/productionLogPath/${errorId}`;
    return this.http.get<string>(path, {})
      .toPromise();
  }
}
