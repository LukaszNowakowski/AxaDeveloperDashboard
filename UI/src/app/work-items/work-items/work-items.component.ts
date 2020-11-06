import { Component } from '@angular/core';
import { WorkItemsService } from '../services/work-items.service';

@Component({
  selector: 'app-work-items',
  templateUrl: './work-items.component.html',
  styleUrls: ['./work-items.component.scss']
})
export class WorkItemsComponent {
  public ProductionErrorId: string = "";

  public DisplayProductionErrorOpeningMessage: boolean = false;

  constructor(private workItemsService: WorkItemsService) { }

  public OpenProductionError() {
    console.log("Started");
    var cast = parseInt(this.ProductionErrorId);
    if (!!cast) {
      this.workItemsService.CreateProductionLogUrl({ ErrorId: cast })
        .then(r => {
          if (r.Success) {
            this.DisplayProductionErrorOpeningMessage = true;
            setTimeout(() => window.open(r.Url), 800);
          }
          else {
            alert(r.Error);
          }
        })
        .finally(() => {
          setTimeout(() => this.DisplayProductionErrorOpeningMessage = false, 2000);
        });
    }
  }
}
