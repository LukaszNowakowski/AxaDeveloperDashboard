import { Component, OnInit } from '@angular/core';
import { WorkItemsService } from '../services/work-items.service';

@Component({
  selector: 'app-work-items',
  templateUrl: './work-items.component.html',
  styleUrls: ['./work-items.component.scss']
})
export class WorkItemsComponent {
  constructor(
    private workItemsService: WorkItemsService) { }

  public GetProductionErrorUrl(errorId: number): Promise<string> {
    return this.workItemsService.CreateProductionLogUrl({ ErrorId: errorId })
      .then(r => {
        if (r.Success) {
          return r.Url;
        }
        else {
          return "";
        }
      });
  }
}
