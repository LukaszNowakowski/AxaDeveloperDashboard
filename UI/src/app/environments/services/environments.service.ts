import { Injectable } from '@angular/core';
import * as models from './environments.models';
import * as httpEnvironments from './http-environments.service';

@Injectable({
  providedIn: 'root'
})
export class EnvironmentsService {
  constructor(private httpEnvironmentsService: httpEnvironments.HttpEnvironmentsService) { }

  public FetchEnvironments(request: models.FetchEnvironmentsRequest): Promise<models.FetchEnvironmentsResponse> {
    return this.httpEnvironmentsService.FetchEnvironments()
      .then(result => {
        return <models.FetchEnvironmentsResponse>{
          Environments: result.environments.map(EnvironmentsService.MapEnvironment)
        }
      });
  }

  public AddEnvironment(request: models.AddEnvironmentRequest) : Promise<models.AddEnvironmentResponse> {
    let env = request.Environment;
    return this.httpEnvironmentsService.AddEnvironment({ id: -1, displayName: env.DisplayName, links: []})
      .then(result => {
        return {
          Created: result.created
        };
      });
  }

  private static MapEnvironment(source: httpEnvironments.Environment) : models.Environment {
    return <models.Environment>{
      Id: source.id,
      DisplayName: source.displayName,
      Links: source.links.map(EnvironmentsService.MapLink)
    };
  }

  private static MapLink(source: httpEnvironments.Link): models.Link {
    return <models.Link>{
      Id: source.id,
      DisplayName: source.displayName,
      Url: source.url,
      Icon: source.icon
    };
  }
}
