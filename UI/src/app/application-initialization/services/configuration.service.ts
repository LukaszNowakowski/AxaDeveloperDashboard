import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Store } from '@ngxs/store';

import * as serviceModels from '../../services/redux/model';
import * as actions from '../../services/redux/actions';

@Injectable({
  providedIn: 'root'
})
export class ConfigurationService {
  constructor(private client: HttpClient, private store: Store) { }

  public Configure(): Promise<any> {
    return this.client.get<serviceModels.ApisUrls>("/assets/urls.json")
      .toPromise()
      .then(urls => {
        return this.store.dispatch(new actions.Actions.SetupApiUrls(urls))
          .toPromise();
      });
  }
}
