import { Injectable } from '@angular/core';
import * as models from './environments.models';

@Injectable({
  providedIn: 'root'
})
export class EnvironmentsService {
  public FetchEnvironments(request: models.FetchEnvironmentsRequest): Promise<models.FetchEnvironmentsResponse> {
    return new Promise<models.FetchEnvironmentsResponse>(
      (resolve, reject) => {
        setTimeout(() => {
          try {
            var response: models.FetchEnvironmentsResponse = {
              Environments: []
            };
            response.Environments.push({
              DisplayName: 'DIT01',
              Links: [
                { DisplayName: 'CSA', Url: 'http://ext-env1.ppglobaldirect.intraxa/CustomerService', Icon: 'dashboard' },
                { DisplayName: 'Private Domain', Url: 'http://www-env1.ppglobaldirect.intraxa/Sales/AGDF/DirectAssurance/Motor/Standard/Desktop/LogOn/initLogOn', Icon: 'account_circle' },
                { DisplayName: 'Tools', Url: 'http://ext-env1.ppglobaldirect.intraxa/Tools', Icon: 'build' },
              ]
            });
            response.Environments.push({
              DisplayName: 'DIT02',
              Links: [
                { DisplayName: 'CSA', Url: 'http://ext-env3.ppglobaldirect.intraxa/CustomerService', Icon: 'dashboard' },
                { DisplayName: 'Private Domain', Url: 'http://www-env3.ppglobaldirect.intraxa/Sales/AGDF/DirectAssurance/Motor/Standard/Desktop/LogOn/initLogOn', Icon: 'account_circle' },
                { DisplayName: 'Tools', Url: 'http://ext-env3.ppglobaldirect.intraxa/Tools', Icon: 'build' },
              ]
            });
            resolve(response);
          }
          catch (error) {
            reject(error);
          }
        }, 500);
      }
    )
  }
}
