import { Component, OnInit } from '@angular/core';
import { Select } from '@ngxs/store';
import * as EnvironmentsModels from '../services/environments.models';
import { EnvironmentsService } from '../services/environments.service';
import * as state from '../redux/state';
import * as model from '../redux/model';
import { Observable, Observer } from 'rxjs';
import { from } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-environments',
  templateUrl: './environments.component.html',
  styleUrls: ['./environments.component.scss']
})
export class EnvironmentsComponent implements OnInit {
  @Select(state => state.environments.environments) environments$: Observable<model.Environment[]>;

  public get Environments(): Observable<EnvironmentsModels.Environment[]> {
    return this.environments$
      .pipe(
        map(e => {
          return e.map(EnvironmentsComponent.MapEnvironment)
        }
      ));
  }

  public NewEnvName: string = "";

  constructor(private environments: EnvironmentsService) { }

  ngOnInit(): void {
  }

  public AddEnvironment() {
    var request: EnvironmentsModels.AddEnvironmentRequest = {
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
          this.NewEnvName = "";
        }
        else {
          alert("Error");
        }
      })
  }

  private static MapEnvironment(source: model.Environment): EnvironmentsModels.Environment {
    return <EnvironmentsModels.Environment>{
      Id: source.id,
      DisplayName: source.displayName,
      Links: source.links.map(EnvironmentsComponent.MapLink)
    };
  }

  private static MapLink(source: model.Link): EnvironmentsModels.Link {
    return <EnvironmentsModels.Link>{
      Id: source.id,
      DisplayName: source.displayName,
      Url: source.url,
      Icon: source.icon
    };
  }
}
