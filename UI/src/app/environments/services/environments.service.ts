import { Injectable } from '@angular/core';
import { Store } from '@ngxs/store';
import * as models from './environments.models';
import * as httpEnvironments from './http-environments.service';
import * as actions from '../redux/actions';

@Injectable({
  providedIn: 'root'
})
export class EnvironmentsService {
  constructor(
    private httpEnvironmentsService: httpEnvironments.HttpEnvironmentsService,
    private store: Store) { }

  public RefreshEnvironments() {
    return this.httpEnvironmentsService.FetchEnvironments()
      .then(envs => {
        return this.store.dispatch(new actions.Actions.SetEnvironments(envs.environments))
          .toPromise()
      });
  }

  public AddEnvironment(request: models.AddEnvironmentRequest): Promise<models.AddEnvironmentResponse> {
    let env = request.Environment;
    return this.httpEnvironmentsService.AddEnvironment({ id: -1, displayName: env.DisplayName, order: -1, links: [] })
      .then(result => {
        if (result.created) {
          return this.httpEnvironmentsService.FetchEnvironments()
            .then(envs => {
              return this.store.dispatch(new actions.Actions.SetEnvironments(envs.environments))
                .toPromise()
                .then(_ => {
                  return { Created: true };
                });
            });
        }

        return { Created: false };
      });
  }
}
