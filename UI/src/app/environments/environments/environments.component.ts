import { Component, OnInit } from '@angular/core';
import { Select } from '@ngxs/store';
import * as EnvironmentsModels from '../services/environments.models';
import { EnvironmentsService } from '../services/environments.service';
import * as models from '../redux/model';
import { Observable, Observer } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-environments',
  templateUrl: './environments.component.html',
  styleUrls: ['./environments.component.scss']
})
export class EnvironmentsComponent implements OnInit {

  public get Environments(): Observable<EnvironmentsModels.Environment[]> {
    return this.environments$
      .pipe(
        map(e => {
          return e.map(EnvironmentsComponent.MapEnvironment);
        },
      ));
  }

  constructor(private environments: EnvironmentsService) { }
  @Select(state => state.environments.environments) environments$: Observable<models.Environment[]>;

  public NewEnvName = '';

  private static MapEnvironment(source: models.Environment): EnvironmentsModels.Environment {
    return {
      Id: source.id,
      DisplayName: source.displayName,
      Links: source.links.map(EnvironmentsComponent.MapLink)
    } as EnvironmentsModels.Environment;
  }

  private static MapLink(source: models.Link): EnvironmentsModels.Link {
    return {
      Id: source.id,
      DisplayName: source.displayName,
      Url: source.url,
      Icon: source.icon
    } as EnvironmentsModels.Link;
  }

  ngOnInit(): void {
  }

  public AddEnvironment(): void {
    const request: EnvironmentsModels.AddEnvironmentRequest = {
      Environment: {
        DisplayName: this.NewEnvName,
        Id: -1,
        Order: -1,
        Links: []
      }
    };
    this.environments.AddEnvironment(request)
      .then(r => {
        if (r.Created) {
          this.NewEnvName = '';
        }
        else {
          alert('Error');
        }
      });
  }
}
