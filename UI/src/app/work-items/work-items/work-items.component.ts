import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-work-items',
  templateUrl: './work-items.component.html',
  styleUrls: ['./work-items.component.scss']
})
export class WorkItemsComponent {
  public ProductionErrorId: string = "";
  constructor() { }

  public OpenProductionError() {
    console.log(this.ProductionErrorId);
  }
}
