import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Store } from '@ngxs/store';
import * as servicesState from '../../services/redux/state';

@Injectable({
  providedIn: 'root'
})
export class HttpWorkItemsService {
   constructor(private http: HttpClient, private store: Store) { }

  public GetProductionLogPath(errorId: number): Promise<string> {
    const baseAddress = this.store.selectSnapshot(servicesState.ServicesState).workItems;
    const path = `${baseAddress}/productionLogPath/${errorId}`;
    return this.http.get<string>(path, {})
      .toPromise();
  }
}
