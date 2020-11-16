import { Component, OnInit } from '@angular/core';
import * as model from './home.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public TasksVisible = true;

  public Tasks: model.AzureWorkItem[] = [];

  constructor() { }

  ngOnInit(): void {
    const result: model.AzureWorkItem[] = [
      { id: 203961, title: 'Remove file system dependency from FetchBatchNetworkPathQueryHandler', areaPath: 'Leonardo\Evolution\Roadmap 2019\Cloud', release: 'R20.09' }
    ];
    this.Tasks = result;
  }

  public PrepareTitle(title: string): string {
    let result: string = title || '';
    if (result.length > 50) {
      result = result.substring(0, 50) + '...';
    }

    return result;
  }
}
