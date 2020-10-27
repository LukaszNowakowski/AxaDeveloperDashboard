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

  constructor(private environments: EnvironmentsService) { }

  ngOnInit(): void {
    this.environments.FetchEnvironments({})
    .then(result => {
      this.Environments = result.Environments;
    })
  }
}
