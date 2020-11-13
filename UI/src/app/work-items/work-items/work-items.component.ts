import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { WorkItemsService } from '../services/work-items.service';

@Component({
  selector: 'app-work-items',
  templateUrl: './work-items.component.html',
  styleUrls: ['./work-items.component.scss']
})
export class WorkItemsComponent implements OnInit {
  public form: FormGroup;

  public DisplayProductionErrorOpeningMessage: boolean = false;

  constructor(
    private workItemsService: WorkItemsService,
    private fb: FormBuilder) { }

  ngOnInit() {
    this.form = this.fb.group({
      productionErrorId: ["", [Validators.required]]
    });
  }

  get ProductionErrorId(): AbstractControl {
    return this.form.get("productionErrorId");
  }

  public OpenProductionError() {
    if (!this.form.valid) {
      return;
    }

    let cast = parseInt(this.ProductionErrorId.value);
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
