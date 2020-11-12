import { Component, OnInit } from '@angular/core';
import * as EnvironmentsModels from '../services/environments.models';
import { EnvironmentsService } from '../services/environments.service';

@Component({
  selector: 'app-environments',
  templateUrl: './environments.component.html',
  styleUrls: ['./environments.component.scss']
})
export class EnvironmentsComponent implements OnInit {
  public Environments: EnvironmentsModels.Environment[] = [];

  public NewEnvName: string = "";

  constructor(private environments: EnvironmentsService) { }

  ngOnInit(): void {
    this.environments.FetchEnvironments({})
    .then(result => {
      this.Environments = result.Environments;
    })
  }

  public AddEnvironment() {
    var request: EnvironmentsModels.AddEnvironmentRequest = {
      Environment: {
        DisplayName: this.NewEnvName,
        Id: -1,
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
}
